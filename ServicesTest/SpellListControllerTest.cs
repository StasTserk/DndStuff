using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System.Collections.Generic;
using System.Linq;
using Data.Models;
using Data.Repositories.Interfaces;
using Services.Controllers;

namespace ServicesTest
{
    [TestClass]
    public class SpellListControllerTest
    {
        [TestMethod]
        public void TestGetSpellsSingleSpell()
        {
            // Load a single spell called "Test Spell" into the mock data source
            Spell singleSpell = new Spell { Name = "Test Spell" };
            ISpellLoader spellLoader = MockRepository.GenerateMock<ISpellLoader>();
            spellLoader.Stub(s => s.GetSpells())
                .Return(new List<Spell> { singleSpell });

            SpellListController controller = new SpellListController(spellLoader);

            // Controller should return the spell
            Assert.AreEqual(controller.GetUnfilteredSpells().First(), singleSpell);
        }

        [TestMethod]
        public void TestGetSpellsSingleSpellByNamePositive()
        {
            // Load a single spell called "Test Spell" into the mock data source
            Spell singleSpell = new Spell { Name = "Test Spell" };
            ISpellLoader spellLoader = MockRepository.GenerateMock<ISpellLoader>();
            spellLoader.Stub(s => s.GetSpells())
                .Return(new List<Spell> { singleSpell });

            SpellListController controller = new SpellListController(spellLoader);

            // controller should return the single spell because the name matches
            Assert.AreEqual(controller.GetSpellByName("Test Spell"), singleSpell);
        }

        [TestMethod]
        public void TestGetSpellsSingleSpellByNameNegative()
        {
            // Load a single spell called "Test Spell" into the mock data source
            Spell singleSpell = new Spell { Name = "Test Spell" };
            ISpellLoader spellLoader = MockRepository.GenerateMock<ISpellLoader>();
            spellLoader.Stub(s => s.GetSpells())
                .Return(new List<Spell> { singleSpell });

            SpellListController controller = new SpellListController(spellLoader);
            
            // controller should return nothing since names do not match
            Assert.AreEqual(controller.GetSpellByName("Test Spells"), null);
        }
    }
}
