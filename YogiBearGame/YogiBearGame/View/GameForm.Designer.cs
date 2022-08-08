
namespace YogiBearGame
{
    partial class GameForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this._toolLabelPicnic = new System.Windows.Forms.ToolStripStatusLabel();
            this._toolLabelPicnicBasketCounter = new System.Windows.Forms.ToolStripStatusLabel();
            this._toolLabelTime = new System.Windows.Forms.ToolStripStatusLabel();
            this._toolLabelGameTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this._menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this._menuFileNewGame = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._menuFileLoadGame = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._menuFileExitGame = new System.Windows.Forms.ToolStripMenuItem();
            this._menuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this._menuSettingsSmall = new System.Windows.Forms.ToolStripMenuItem();
            this._menuSettingsMedium = new System.Windows.Forms.ToolStripMenuItem();
            this._menuSettingsLarge = new System.Windows.Forms.ToolStripMenuItem();
            this._menuTime = new System.Windows.Forms.ToolStripMenuItem();
            this._menuTimeStart = new System.Windows.Forms.ToolStripMenuItem();
            this._menuTimeStop = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolLabelPicnic,
            this._toolLabelPicnicBasketCounter,
            this._toolLabelTime,
            this._toolLabelGameTime});
            this.statusStrip.Location = new System.Drawing.Point(0, 537);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(584, 24);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // _toolLabelPicnic
            // 
            this._toolLabelPicnic.Name = "_toolLabelPicnic";
            this._toolLabelPicnic.Size = new System.Drawing.Size(125, 19);
            this._toolLabelPicnic.Text = "Picked picnic baskets: ";
            // 
            // _toolLabelPicnicBasketCounter
            // 
            this._toolLabelPicnicBasketCounter.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this._toolLabelPicnicBasketCounter.Name = "_toolLabelPicnicBasketCounter";
            this._toolLabelPicnicBasketCounter.Size = new System.Drawing.Size(17, 19);
            this._toolLabelPicnicBasketCounter.Text = "0";
            // 
            // _toolLabelTime
            // 
            this._toolLabelTime.Name = "_toolLabelTime";
            this._toolLabelTime.Size = new System.Drawing.Size(39, 19);
            this._toolLabelTime.Text = "Time: ";
            // 
            // _toolLabelGameTime
            // 
            this._toolLabelGameTime.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this._toolLabelGameTime.Name = "_toolLabelGameTime";
            this._toolLabelGameTime.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._toolLabelGameTime.Size = new System.Drawing.Size(47, 19);
            this._toolLabelGameTime.Text = "0:00:00";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuFile,
            this._menuSettings,
            this._menuTime});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(584, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // _menuFile
            // 
            this._menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuFileNewGame,
            this.toolStripSeparator1,
            this._menuFileLoadGame,
            this.toolStripSeparator2,
            this._menuFileExitGame});
            this._menuFile.Name = "_menuFile";
            this._menuFile.Size = new System.Drawing.Size(37, 20);
            this._menuFile.Text = "File";
            // 
            // _menuFileNewGame
            // 
            this._menuFileNewGame.Name = "_menuFileNewGame";
            this._menuFileNewGame.Size = new System.Drawing.Size(173, 22);
            this._menuFileNewGame.Text = "New game";
            this._menuFileNewGame.Click += new System.EventHandler(this.MenuFileNewGame_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(170, 6);
            // 
            // _menuFileLoadGame
            // 
            this._menuFileLoadGame.Name = "_menuFileLoadGame";
            this._menuFileLoadGame.Size = new System.Drawing.Size(173, 22);
            this._menuFileLoadGame.Text = "Load gametables...";
            this._menuFileLoadGame.Click += new System.EventHandler(this.MenuLoadGameTables);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(170, 6);
            // 
            // _menuFileExitGame
            // 
            this._menuFileExitGame.Name = "_menuFileExitGame";
            this._menuFileExitGame.Size = new System.Drawing.Size(173, 22);
            this._menuFileExitGame.Text = "Exit";
            this._menuFileExitGame.Click += new System.EventHandler(this.MenuFileExit_Click);
            // 
            // _menuSettings
            // 
            this._menuSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuSettingsSmall,
            this._menuSettingsMedium,
            this._menuSettingsLarge});
            this._menuSettings.Name = "_menuSettings";
            this._menuSettings.Size = new System.Drawing.Size(61, 20);
            this._menuSettings.Text = "Settings";
            // 
            // _menuSettingsSmall
            // 
            this._menuSettingsSmall.CheckOnClick = true;
            this._menuSettingsSmall.Name = "_menuSettingsSmall";
            this._menuSettingsSmall.Size = new System.Drawing.Size(148, 22);
            this._menuSettingsSmall.Text = "Small table";
            this._menuSettingsSmall.Click += new System.EventHandler(this.MenuGameSmall_Click);
            // 
            // _menuSettingsMedium
            // 
            this._menuSettingsMedium.CheckOnClick = true;
            this._menuSettingsMedium.Name = "_menuSettingsMedium";
            this._menuSettingsMedium.Size = new System.Drawing.Size(148, 22);
            this._menuSettingsMedium.Text = "Medium table";
            this._menuSettingsMedium.Click += new System.EventHandler(this.MenuGameMedium_Click);
            // 
            // _menuSettingsLarge
            // 
            this._menuSettingsLarge.CheckOnClick = true;
            this._menuSettingsLarge.Name = "_menuSettingsLarge";
            this._menuSettingsLarge.Size = new System.Drawing.Size(148, 22);
            this._menuSettingsLarge.Text = "Large table";
            this._menuSettingsLarge.Click += new System.EventHandler(this.MenuGameLarge_Click);
            // 
            // _menuTime
            // 
            this._menuTime.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._menuTimeStart,
            this._menuTimeStop});
            this._menuTime.Name = "_menuTime";
            this._menuTime.Size = new System.Drawing.Size(45, 20);
            this._menuTime.Text = "Time";
            // 
            // _menuTimeStart
            // 
            this._menuTimeStart.Name = "_menuTimeStart";
            this._menuTimeStart.Size = new System.Drawing.Size(98, 22);
            this._menuTimeStart.Text = "Start";
            this._menuTimeStart.Click += new System.EventHandler(this.MenuStart_Click);
            // 
            // _menuTimeStop
            // 
            this._menuTimeStop.Name = "_menuTimeStop";
            this._menuTimeStop.Size = new System.Drawing.Size(98, 22);
            this._menuTimeStop.Text = "Stop";
            this._menuTimeStop.Click += new System.EventHandler(this.MenuStop_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.Title = "Game Tables Browser";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "GameForm";
            this.Text = "Yogi Bear Game";
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem _menuFile;
        private System.Windows.Forms.ToolStripMenuItem _menuFileNewGame;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem _menuFileLoadGame;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem _menuFileExitGame;
        private System.Windows.Forms.ToolStripMenuItem _menuSettings;
        private System.Windows.Forms.ToolStripMenuItem _menuSettingsSmall;
        private System.Windows.Forms.ToolStripMenuItem _menuSettingsMedium;
        private System.Windows.Forms.ToolStripMenuItem _menuSettingsLarge;
        private System.Windows.Forms.ToolStripMenuItem _menuTime;
        private System.Windows.Forms.ToolStripMenuItem _menuTimeStart;
        private System.Windows.Forms.ToolStripMenuItem _menuTimeStop;
        private System.Windows.Forms.ToolStripStatusLabel _toolLabelPicnicBasketCounter;
        private System.Windows.Forms.ToolStripStatusLabel _toolLabelGameTime;
        private System.Windows.Forms.ToolStripStatusLabel _toolLabelPicnic;
        private System.Windows.Forms.ToolStripStatusLabel _toolLabelTime;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

