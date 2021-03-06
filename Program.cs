﻿using System;
using System.Windows.Forms;
using DnD5thEdTools.Views;
using DnD5thEdTools.Controllers;
using DnD5thEdTools.Repositories;
using Providers;

namespace DnD5thEdTools
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ISpellDetailProvider spellDetail = new SpellDetailProvider();
            ISpellLoader loader = new SpellLoader();
            ISpellListController controller = new SpellListController(loader);
            ISimpleSpellListView spellGridView = new SimpleSpellListView();
            IRtfProvider formatProvider = new MarkdownToAnsiRtfProvider();

            Application.Run(new Form1(controller, spellGridView, spellDetail, formatProvider));
        }
    }
}
