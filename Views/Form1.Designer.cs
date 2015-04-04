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
            this.SuspendLayout();
            // 
            // loadSpellsButton
            // 
            this.loadSpellsButton.Location = new System.Drawing.Point(13, 13);
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
            this.ListOfSpells.Location = new System.Drawing.Point(95, 13);
            this.ListOfSpells.Name = "ListOfSpells";
            this.ListOfSpells.Size = new System.Drawing.Size(967, 336);
            this.ListOfSpells.TabIndex = 1;
            this.ListOfSpells.UseCompatibleStateImageBehavior = false;
            this.ListOfSpells.View = System.Windows.Forms.View.Details;
            this.ListOfSpells.SelectedIndexChanged += new System.EventHandler(this.ListOfSpells_SelectedIndexChanged);
            // 
            // BasicSpellDetailsTextBox
            // 
            this.BasicSpellDetailsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BasicSpellDetailsTextBox.Location = new System.Drawing.Point(95, 356);
            this.BasicSpellDetailsTextBox.Name = "BasicSpellDetailsTextBox";
            this.BasicSpellDetailsTextBox.ReadOnly = true;
            this.BasicSpellDetailsTextBox.Size = new System.Drawing.Size(210, 149);
            this.BasicSpellDetailsTextBox.TabIndex = 4;
            this.BasicSpellDetailsTextBox.Text = "";
            // 
            // SpellDescriptionTextBox
            // 
            this.SpellDescriptionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SpellDescriptionTextBox.Location = new System.Drawing.Point(312, 356);
            this.SpellDescriptionTextBox.Name = "SpellDescriptionTextBox";
            this.SpellDescriptionTextBox.ReadOnly = true;
            this.SpellDescriptionTextBox.Size = new System.Drawing.Size(750, 149);
            this.SpellDescriptionTextBox.TabIndex = 5;
            this.SpellDescriptionTextBox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 517);
            this.Controls.Add(this.SpellDescriptionTextBox);
            this.Controls.Add(this.BasicSpellDetailsTextBox);
            this.Controls.Add(this.ListOfSpells);
            this.Controls.Add(this.loadSpellsButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button loadSpellsButton;
        private System.Windows.Forms.ListView ListOfSpells;
        private System.Windows.Forms.RichTextBox BasicSpellDetailsTextBox;
        private System.Windows.Forms.RichTextBox SpellDescriptionTextBox;
    }
}

