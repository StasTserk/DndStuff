using System;
using System.Collections;
using System.Collections.Generic;
using CharacterSheetVisualizer.Model;
using GalaSoft.MvvmLight;

namespace CharacterSheetVisualizer.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class BaseCharacterStatsViewModel : ViewModelBase
    {
        public Character Character
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the BaseCharacterStatsViewModel class.
        /// </summary>
        public BaseCharacterStatsViewModel()
        {
            Character = new Character();
        }
    }
}