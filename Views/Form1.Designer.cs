namespace DnD5thEdTools.Views
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.loadSpellsButton = new System.Windows.Forms.Button();
            this.ListOfSpells = new System.Windows.Forms.ListView();
            this.BasicSpellDetailsTextBox = new System.Windows.Forms.RichTextBox();
            this.SpellDescriptionTextBox = new System.Windows.Forms.RichTextBox();
            this.Filter_ConcentrationDropdown = new System.Windows.Forms.ComboBox();
            this.Filter_HasSaveDropdown = new System.Windows.Forms.ComboBox();
            this.Filter_RequiresAttackDropdown = new System.Windows.Forms.ComboBox();
            this.Filter_CastingTimeDropdown = new System.Windows.Forms.ComboBox();
            this.Filter_ClassDropdown = new System.Windows.Forms.ComboBox();
            this.Filter_RitualDropdown = new System.Windows.Forms.ComboBox();
            this.Label_Ritual = new System.Windows.Forms.Label();
            this.Label_Class = new System.Windows.Forms.Label();
            this.Label_CastingTime = new System.Windows.Forms.Label();
            this.Label_Attack = new System.Windows.Forms.Label();
            this.Label_HasSave = new System.Windows.Forms.Label();
            this.Label_Concentration = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // loadSpellsButton
            // 
            this.loadSpellsButton.Location = new System.Drawing.Point(12, 8);
            this.loadSpellsButton.Name = "loadSpellsButton";
            this.loadSpellsButton.Size = new System.Drawing.Size(75, 23);
            this.loadSpellsButton.TabIndex = 0;
            this.loadSpellsButton.Text = "Load Spells";
            this.loadSpellsButton.UseVisualStyleBackColor = true;
            this.loadSpellsButton.Click += new System.EventHandler(this.loadSpellsButton_Click);
            // 
            // ListOfSpells
            // 
            this.ListOfSpells.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListOfSpells.Location = new System.Drawing.Point(95, 60);
            this.ListOfSpells.Name = "ListOfSpells";
            this.ListOfSpells.Size = new System.Drawing.Size(967, 307);
            this.ListOfSpells.TabIndex = 1;
            this.ListOfSpells.UseCompatibleStateImageBehavior = false;
            this.ListOfSpells.View = System.Windows.Forms.View.Details;
            this.ListOfSpells.SelectedIndexChanged += new System.EventHandler(this.ListOfSpells_SelectedIndexChanged);
            // 
            // BasicSpellDetailsTextBox
            // 
            this.BasicSpellDetailsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BasicSpellDetailsTextBox.Location = new System.Drawing.Point(95, 373);
            this.BasicSpellDetailsTextBox.Name = "BasicSpellDetailsTextBox";
            this.BasicSpellDetailsTextBox.ReadOnly = true;
            this.BasicSpellDetailsTextBox.Size = new System.Drawing.Size(210, 175);
            this.BasicSpellDetailsTextBox.TabIndex = 4;
            this.BasicSpellDetailsTextBox.Text = "";
            // 
            // SpellDescriptionTextBox
            // 
            this.SpellDescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SpellDescriptionTextBox.Location = new System.Drawing.Point(312, 373);
            this.SpellDescriptionTextBox.Name = "SpellDescriptionTextBox";
            this.SpellDescriptionTextBox.ReadOnly = true;
            this.SpellDescriptionTextBox.Size = new System.Drawing.Size(750, 175);
            this.SpellDescriptionTextBox.TabIndex = 5;
            this.SpellDescriptionTextBox.Text = "";
            // 
            // Filter_ConcentrationDropdown
            // 
            this.Filter_ConcentrationDropdown.FormattingEnabled = true;
            this.Filter_ConcentrationDropdown.Location = new System.Drawing.Point(96, 33);
            this.Filter_ConcentrationDropdown.Name = "Filter_ConcentrationDropdown";
            this.Filter_ConcentrationDropdown.Size = new System.Drawing.Size(121, 21);
            this.Filter_ConcentrationDropdown.TabIndex = 6;
            this.Filter_ConcentrationDropdown.SelectedIndexChanged += new System.EventHandler(this.Filter_ConcentrationDropdown_SelectedIndexChanged);
            // 
            // Filter_HasSaveDropdown
            // 
            this.Filter_HasSaveDropdown.FormattingEnabled = true;
            this.Filter_HasSaveDropdown.Location = new System.Drawing.Point(223, 33);
            this.Filter_HasSaveDropdown.Name = "Filter_HasSaveDropdown";
            this.Filter_HasSaveDropdown.Size = new System.Drawing.Size(121, 21);
            this.Filter_HasSaveDropdown.TabIndex = 7;
            this.Filter_HasSaveDropdown.SelectedIndexChanged += new System.EventHandler(this.Filter_HasSaveDropdown_SelectedIndexChanged);
            // 
            // Filter_RequiresAttackDropdown
            // 
            this.Filter_RequiresAttackDropdown.FormattingEnabled = true;
            this.Filter_RequiresAttackDropdown.Location = new System.Drawing.Point(350, 33);
            this.Filter_RequiresAttackDropdown.Name = "Filter_RequiresAttackDropdown";
            this.Filter_RequiresAttackDropdown.Size = new System.Drawing.Size(121, 21);
            this.Filter_RequiresAttackDropdown.TabIndex = 8;
            this.Filter_RequiresAttackDropdown.SelectedIndexChanged += new System.EventHandler(this.Filter_RequiresAttackDropdown_SelectedIndexChanged);
            // 
            // Filter_CastingTimeDropdown
            // 
            this.Filter_CastingTimeDropdown.FormattingEnabled = true;
            this.Filter_CastingTimeDropdown.Location = new System.Drawing.Point(477, 33);
            this.Filter_CastingTimeDropdown.Name = "Filter_CastingTimeDropdown";
            this.Filter_CastingTimeDropdown.Size = new System.Drawing.Size(121, 21);
            this.Filter_CastingTimeDropdown.TabIndex = 9;
            this.Filter_CastingTimeDropdown.SelectedIndexChanged += new System.EventHandler(this.Filter_CastingTimeDropdown_SelectedIndexChanged);
            // 
            // Filter_ClassDropdown
            // 
            this.Filter_ClassDropdown.FormattingEnabled = true;
            this.Filter_ClassDropdown.Location = new System.Drawing.Point(604, 33);
            this.Filter_ClassDropdown.Name = "Filter_ClassDropdown";
            this.Filter_ClassDropdown.Size = new System.Drawing.Size(121, 21);
            this.Filter_ClassDropdown.TabIndex = 10;
            this.Filter_ClassDropdown.SelectedIndexChanged += new System.EventHandler(this.Filter_ClassDropdown_SelectedIndexChanged);
            // 
            // Filter_RitualDropdown
            // 
            this.Filter_RitualDropdown.FormattingEnabled = true;
            this.Filter_RitualDropdown.Location = new System.Drawing.Point(731, 33);
            this.Filter_RitualDropdown.Name = "Filter_RitualDropdown";
            this.Filter_RitualDropdown.Size = new System.Drawing.Size(121, 21);
            this.Filter_RitualDropdown.TabIndex = 11;
            this.Filter_RitualDropdown.SelectedIndexChanged += new System.EventHandler(this.Filter_RitualDropdown_SelectedIndexChanged);
            // 
            // Label_Ritual
            // 
            this.Label_Ritual.AutoSize = true;
            this.Label_Ritual.Location = new System.Drawing.Point(728, 14);
            this.Label_Ritual.Name = "Label_Ritual";
            this.Label_Ritual.Size = new System.Drawing.Size(34, 13);
            this.Label_Ritual.TabIndex = 12;
            this.Label_Ritual.Text = "Ritual";
            // 
            // Label_Class
            // 
            this.Label_Class.AutoSize = true;
            this.Label_Class.Location = new System.Drawing.Point(604, 14);
            this.Label_Class.Name = "Label_Class";
            this.Label_Class.Size = new System.Drawing.Size(32, 13);
            this.Label_Class.TabIndex = 13;
            this.Label_Class.Text = "Class";
            // 
            // Label_CastingTime
            // 
            this.Label_CastingTime.AutoSize = true;
            this.Label_CastingTime.Location = new System.Drawing.Point(474, 14);
            this.Label_CastingTime.Name = "Label_CastingTime";
            this.Label_CastingTime.Size = new System.Drawing.Size(68, 13);
            this.Label_CastingTime.TabIndex = 14;
            this.Label_CastingTime.Text = "Casting Time";
            // 
            // Label_Attack
            // 
            this.Label_Attack.AutoSize = true;
            this.Label_Attack.Location = new System.Drawing.Point(347, 14);
            this.Label_Attack.Name = "Label_Attack";
            this.Label_Attack.Size = new System.Drawing.Size(83, 13);
            this.Label_Attack.TabIndex = 15;
            this.Label_Attack.Text = "Requires Attack";
            // 
            // Label_HasSave
            // 
            this.Label_HasSave.AutoSize = true;
            this.Label_HasSave.Location = new System.Drawing.Point(220, 14);
            this.Label_HasSave.Name = "Label_HasSave";
            this.Label_HasSave.Size = new System.Drawing.Size(54, 13);
            this.Label_HasSave.TabIndex = 16;
            this.Label_HasSave.Text = "Has Save";
            // 
            // Label_Concentration
            // 
            this.Label_Concentration.AutoSize = true;
            this.Label_Concentration.Location = new System.Drawing.Point(96, 14);
            this.Label_Concentration.Name = "Label_Concentration";
            this.Label_Concentration.Size = new System.Drawing.Size(73, 13);
            this.Label_Concentration.TabIndex = 17;
            this.Label_Concentration.Text = "Concentration";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 560);
            this.Controls.Add(this.Label_Concentration);
            this.Controls.Add(this.Label_HasSave);
            this.Controls.Add(this.Label_Attack);
            this.Controls.Add(this.Label_CastingTime);
            this.Controls.Add(this.Label_Class);
            this.Controls.Add(this.Label_Ritual);
            this.Controls.Add(this.Filter_RitualDropdown);
            this.Controls.Add(this.Filter_ClassDropdown);
            this.Controls.Add(this.Filter_CastingTimeDropdown);
            this.Controls.Add(this.Filter_RequiresAttackDropdown);
            this.Controls.Add(this.Filter_HasSaveDropdown);
            this.Controls.Add(this.Filter_ConcentrationDropdown);
            this.Controls.Add(this.SpellDescriptionTextBox);
            this.Controls.Add(this.BasicSpellDetailsTextBox);
            this.Controls.Add(this.ListOfSpells);
            this.Controls.Add(this.loadSpellsButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loadSpellsButton;
        private System.Windows.Forms.ListView ListOfSpells;
        private System.Windows.Forms.RichTextBox BasicSpellDetailsTextBox;
        private System.Windows.Forms.RichTextBox SpellDescriptionTextBox;
        private System.Windows.Forms.ComboBox Filter_ConcentrationDropdown;
        private System.Windows.Forms.ComboBox Filter_HasSaveDropdown;
        private System.Windows.Forms.ComboBox Filter_RequiresAttackDropdown;
        private System.Windows.Forms.ComboBox Filter_CastingTimeDropdown;
        private System.Windows.Forms.ComboBox Filter_ClassDropdown;
        private System.Windows.Forms.ComboBox Filter_RitualDropdown;
        private System.Windows.Forms.Label Label_Ritual;
        private System.Windows.Forms.Label Label_Class;
        private System.Windows.Forms.Label Label_CastingTime;
        private System.Windows.Forms.Label Label_Attack;
        private System.Windows.Forms.Label Label_HasSave;
        private System.Windows.Forms.Label Label_Concentration;
    }
}

