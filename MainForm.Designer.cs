namespace ROMacroManager
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.lblProfile = new System.Windows.Forms.Label();
            this.cmbProfiles = new System.Windows.Forms.ComboBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblShortcuts = new System.Windows.Forms.Label();
            this.btnApplyToGame = new System.Windows.Forms.Button();
            this.btnLoadFromGame = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblProfile
            // 
            this.lblProfile.AutoSize = true;
            this.lblProfile.Location = new System.Drawing.Point(15, 14);
            this.lblProfile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProfile.Name = "lblProfile";
            this.lblProfile.Size = new System.Drawing.Size(44, 14);
            this.lblProfile.TabIndex = 0;
            this.lblProfile.Text = "Profile:";
            // 
            // cmbProfiles
            // 
            this.cmbProfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProfiles.FormattingEnabled = true;
            this.cmbProfiles.Location = new System.Drawing.Point(66, 11);
            this.cmbProfiles.Margin = new System.Windows.Forms.Padding(4);
            this.cmbProfiles.Name = "cmbProfiles";
            this.cmbProfiles.Size = new System.Drawing.Size(150, 22);
            this.cmbProfiles.TabIndex = 1;
            this.cmbProfiles.SelectedIndexChanged += new System.EventHandler(this.CmbProfiles_SelectedIndexChanged);
            // 
            // btnNew
            // 
            this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNew.Location = new System.Drawing.Point(231, 11);
            this.btnNew.Margin = new System.Windows.Forms.Padding(4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(70, 23);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Location = new System.Drawing.Point(307, 11);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(70, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Location = new System.Drawing.Point(382, 11);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(70, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // lblShortcuts
            // 
            this.lblShortcuts.AutoSize = true;
            this.lblShortcuts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblShortcuts.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShortcuts.Location = new System.Drawing.Point(11, 41);
            this.lblShortcuts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblShortcuts.Name = "lblShortcuts";
            this.lblShortcuts.Size = new System.Drawing.Size(88, 14);
            this.lblShortcuts.TabIndex = 5;
            this.lblShortcuts.Text = "Shortcut List";
            // 
            // btnApplyToGame
            // 
            this.btnApplyToGame.BackColor = System.Drawing.Color.LightGreen;
            this.btnApplyToGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnApplyToGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApplyToGame.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApplyToGame.Location = new System.Drawing.Point(244, 319);
            this.btnApplyToGame.Margin = new System.Windows.Forms.Padding(4);
            this.btnApplyToGame.Name = "btnApplyToGame";
            this.btnApplyToGame.Size = new System.Drawing.Size(125, 30);
            this.btnApplyToGame.TabIndex = 6;
            this.btnApplyToGame.Text = "Save to RO";
            this.btnApplyToGame.UseVisualStyleBackColor = false;
            this.btnApplyToGame.Click += new System.EventHandler(this.BtnApplyToGame_Click);
            // 
            // btnLoadFromGame
            // 
            this.btnLoadFromGame.BackColor = System.Drawing.Color.PowderBlue;
            this.btnLoadFromGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoadFromGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadFromGame.Location = new System.Drawing.Point(110, 319);
            this.btnLoadFromGame.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoadFromGame.Name = "btnLoadFromGame";
            this.btnLoadFromGame.Size = new System.Drawing.Size(125, 30);
            this.btnLoadFromGame.TabIndex = 7;
            this.btnLoadFromGame.Text = "Load from RO";
            this.btnLoadFromGame.UseVisualStyleBackColor = false;
            this.btnLoadFromGame.Click += new System.EventHandler(this.BtnLoadFromGame_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 361);
            this.Controls.Add(this.btnLoadFromGame);
            this.Controls.Add(this.btnApplyToGame);
            this.Controls.Add(this.lblShortcuts);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.cmbProfiles);
            this.Controls.Add(this.lblProfile);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RO Macro Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProfile;
        private System.Windows.Forms.ComboBox cmbProfiles;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblShortcuts;
        private System.Windows.Forms.Button btnApplyToGame;
        private System.Windows.Forms.Button btnLoadFromGame;
    }
}