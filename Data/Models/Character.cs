using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using Data.Models.Choices;
using Data.Models.Effects;
using Data.Models.Effects.BackgroundEffects;
using Data.Models.Items;
using Data.Models.Managers;
using GalaSoft.MvvmLight;

namespace Data.Models
{
    public enum AlignmentType
    {
        LawfulGood,
        Good,
        ChaoticGood,
        Lawful,
        Neutral,
        Chaotic,
        LawfulEvil,
        Evil,
        ChaoticEvil
    }

    public class Character
        : ObservableObject
    {
        #region Backing Fields
        private readonly ICollection<IOtherProficencyEffect> _proficiencyEffects;
        private readonly ICollection<IFeatureEffect> _featureEffects;
        private readonly ICollection<ISpeedEffect> _speedEffects;
        private readonly ICollection<IEquippable> _equippedItems;
        private readonly ICollection<IItem> _inventory;
        private readonly ICollection<string> _personalityTraits;
        private readonly ICollection<string> _characterBonds;
        private readonly ICollection<string> _characterFlaws;
        private readonly ICollection<string> _characterIdeals;
        private readonly ObservableCollection<IChoice> _oustandingChoices;
        private readonly ObservableCollection<IChoice> _completedChoices;
        private Race _race;
        private Background _background;
        private IEnumerable<Skill> _skills;
        private IEnumerable<Stat> _stats;
        private AlignmentType _alignment;

        #endregion

        #region Properties

        public ObservableCollection<IChoice> OutstandingChoices 
        {
            get { return _oustandingChoices; }
        }

        public ObservableCollection<IChoice> CompletedChoices
        {
            get { return _completedChoices; }
        }

        public IEnumerable<Stat> Stats {
            get { return _stats; }
            set
            {
                _stats = value;
                _stats.First(s => s.Type == StatType.Dexterity).PropertyChanged +=
                    UpdateInitiative;

                foreach (var stat in value)
                {
                    stat.PropertyChanged += UpdatePointBuyEquivalent;
                }
            }
        }

        public IEnumerable<Skill> Skills 
        {
            get
            {
                return _skills;
            }
            set
            {
                _skills = value;
                _skills.First(s => s.Type == SkillType.Perception).PropertyChanged +=
                    UpdatePassivePerception;
            } 
        }

        public int PassivePerception
        {
            get { return 10 + Skills.First(s => s.Type == SkillType.Perception).Modifier; }
        }

        public int Initiative
        {
            get { return Stats.First(s => s.Type == StatType.Dexterity).Modifier; }
        }
        
        public int ExperiencePoints { get; set; }

        public int Speed
        {
            get
            {
                return _speedEffects.Aggregate(
                    0, (speed, mod) => mod.GetSpeed(speed));
            }
        }

        public string PlayerName { get; set; }
        
        public string CharacterName { get; set; }
        
        public Race Race 
        {
            get
            {
                return _race;
            }
            set
            {
                _race = value;
                RaisePropertyChanged(() => Race.Name);
                RaisePropertyChanged(() => Race);
            } 
        }
        
        public LevelModifiers LevelModifiers { get; set; }
        
        public ArmorClass Armor { get; set; }

        public AlignmentType Alignment
        {
            get {return _alignment;}
            set
            {
                _alignment = value;
                RaisePropertyChanged(() => Alignment);
            }
        }
        
        public IEnumerable<Proficiency> OtherProficiencies
        {
            get
            {
                var profList = new List<Proficiency>();
                foreach (var prof in _proficiencyEffects)
                {
                    prof.GetProficencyList(profList);
                }
                return profList.GroupBy(p => p.Name).Select(g => g.First());
            }
        }

        public IEnumerable<CharacterFeature> FeaturesAndTraits
        {
            get
            {
                var featureList = new List<CharacterFeature>();
                foreach (var prof in _featureEffects)
                {
                    prof.GetFeatureList(featureList);
                }
                return featureList;
            }
        }

        public IEnumerable<IEquippable> EquippedItems
        {
            get { return _equippedItems;}
        }
        
        public IEnumerable<IItem> Inventory 
        {
            get { return _inventory; }
        }

        public int PointBuyEquivalent
        {
            get { return Stats.Sum(s => s.PointBuyEquivalent); }
        }

        public IEnumerable<string> PersonalityTraits { get { return _personalityTraits; } }
        public IEnumerable<string> CharacterBonds { get { return _characterBonds; } }
        public IEnumerable<string> CharacterFlaws { get { return _characterFlaws; } }
        public IEnumerable<string> CharacterIdeals { get { return _characterIdeals; } }

        public Background Background
        {
            get {return _background; }
            set
            {
                _background = value;
                RaisePropertyChanged(() => Background);
            }
        }

        public ClassCustomization ClassCustomization { get; set; }

        public ISpellBookManager SpellBook { get; set; }

        public IEnumerable<Spell> KnownSpells
        {
            get
            {
                return SpellBook != null 
                    ? SpellBook.GetCharacterKnownSpells() 
                    : new List<Spell>();
            }
        }

        public IEnumerable<Spell> PreparedSpells
        {
            get
            {
                return SpellBook != null
                    ? SpellBook.GetCharacterPreparedSpells()
                    : new List<Spell>();
            }
        } 

        #endregion

        #region Constructors
        public Character()
        {
            _featureEffects = new List<IFeatureEffect>();
            _proficiencyEffects = new List<IOtherProficencyEffect>();
            _equippedItems = new List<IEquippable>();
            _inventory = new List<IItem>();
            _speedEffects = new List<ISpeedEffect>();
            _oustandingChoices = new ObservableCollection<IChoice>();
            _completedChoices = new ObservableCollection<IChoice>();
            _personalityTraits = new List<string>();
            _characterBonds = new List<string>();
            _characterFlaws = new List<string>();
            _characterIdeals = new List<string>();
        }
        #endregion

        #region Choice Handling

        // TODO reowrk massive logic flaw (dealing with ChoiceEffects instead of choices directly?)
        public void AddChoice(IChoice choice)
        {
            _oustandingChoices.Add(choice);
            RaisePropertyChanged(() => OutstandingChoices);
        }

        public void RemoveChoice(IChoice choice)
        {
            _oustandingChoices.Remove(choice);
            RaisePropertyChanged(() => OutstandingChoices);
        }

        public void MakeChoice(IChoice choiceSet, IChoiceOption choiceOption)
        {
            if (choiceSet == null || choiceOption == null) return;

            choiceSet.MakeChoice(choiceOption);
            _oustandingChoices.Remove(choiceSet);
            _completedChoices.Add(choiceSet);

            RaisePropertyChanged(() => CompletedChoices);
            RaisePropertyChanged(() => OutstandingChoices);
        }

        #endregion

        #region Backgrounds

        public void AddBackgroundTrait(string trait)
        {              
            _personalityTraits.Add(trait);
            RaisePropertyChanged(() => PersonalityTraits);
        }              
                       
        public void AddBackgroundFlaw(string flaw)
        {              
            _characterFlaws.Add(flaw);
            RaisePropertyChanged(() => CharacterFlaws);
        }              
                       
        public void AddBackgroundIdeal(string ideal)
        {              
            _characterIdeals.Add(ideal);
            RaisePropertyChanged(() => CharacterIdeals);
        }

        public void AddBackgroundBond(string bond)
        {
            _characterBonds.Add(bond);
            RaisePropertyChanged(() => CharacterBonds);
        }

        public void RemoveBackgroundTrait(string trait)
        {
            _personalityTraits.Remove(trait);
            RaisePropertyChanged(() => PersonalityTraits);
        }

        public void RemoveBackgroundFlaw(string flaw)
        {
            _characterFlaws.Remove(flaw);
            RaisePropertyChanged(() => CharacterFlaws);
        }

        public void RemoveBackgroundIdeal(string ideal)
        {
            _characterIdeals.Remove(ideal);
            RaisePropertyChanged(() => CharacterIdeals);
        }

        public void RemoveBackgroundBond(string bond)
        {
            _characterBonds.Remove(bond);
            RaisePropertyChanged(() => CharacterBonds);
        }

        #endregion

        #region Item Handling
        public void Equip(IEquippable equippableItem)
        {
            var slot = equippableItem.GetSlot();
            // If slot is taken, unequip item already in the slot
            if (_equippedItems.Any(i => i.GetSlot() == slot))
            {
                Unequip(_equippedItems.First(i => i.GetSlot() == slot));
            }

            // add item to equipped item collection, apply item effects, 
            // remove from inventory
            _equippedItems.Add(equippableItem);
            equippableItem.EquipOn(this);
            _inventory.Remove(equippableItem);

            RaisePropertyChanged(() => Inventory);
            RaisePropertyChanged(() => EquippedItems);
        }

        public void Unequip(IEquippable equippableItem)
        {
            // Remove item from inventory, remove effects, add to inventory
            _equippedItems.Remove(equippableItem);
            equippableItem.RemoveFrom(this);
            _inventory.Add(equippableItem);

            RaisePropertyChanged(() => Inventory);
            RaisePropertyChanged(() => EquippedItems);
        }
        #endregion

        #region Event Handling
        private void UpdatePassivePerception(object sender, PropertyChangedEventArgs e)
        {
            RaisePropertyChanged(() => PassivePerception);
        }

        private void UpdateInitiative(object sender, PropertyChangedEventArgs e)
        {
            RaisePropertyChanged(() => Initiative);
        }

        private void UpdatePointBuyEquivalent(object sender, PropertyChangedEventArgs e)
        {
            RaisePropertyChanged(() => PointBuyEquivalent);
        }
        #endregion

        #region Effects handling
        public void AddProficiencyEffect(IOtherProficencyEffect otherProficencyEffect)
        {
            _proficiencyEffects.Add(otherProficencyEffect);
            RaisePropertyChanged(() => OtherProficiencies);
        }

        public void RemoveProficiencyEffect(IOtherProficencyEffect otherProficencyEffect)
        {
            _proficiencyEffects.Remove(otherProficencyEffect);
            RaisePropertyChanged(() => OtherProficiencies);
        }

        public void AddFeatureEffect(IFeatureEffect featureEffect)
        {
            _featureEffects.Add(featureEffect);
            RaisePropertyChanged(() => FeaturesAndTraits);
        }

        public void RemoveFeatureEffect(IFeatureEffect featureEffect)
        {
            _featureEffects.Remove(featureEffect);
            RaisePropertyChanged(() => FeaturesAndTraits);
        }

        public void AddSpeedEffect(ISpeedEffect speedEffect)
        {
            _speedEffects.Add(speedEffect);
            RaisePropertyChanged(() => Speed);
        }

        public void RemoveSpeedEffect(ISpeedEffect speedEffect)
        {
            _speedEffects.Remove(speedEffect);
            RaisePropertyChanged(() => Speed);
        }
        #endregion
    }
}