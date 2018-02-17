namespace Avanteware.RSSEdit
{
    partial class AppMain
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppMain));
          this.MainToolStripContainer = new System.Windows.Forms.ToolStripContainer();
          this.menuStrip1 = new System.Windows.Forms.MenuStrip();
          this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
          this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
          this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
          this.SaveRSSDialog = new System.Windows.Forms.SaveFileDialog();
          this.OpenRSSDialog = new System.Windows.Forms.OpenFileDialog();
          this.MainToolStripContainer.TopToolStripPanel.SuspendLayout();
          this.MainToolStripContainer.SuspendLayout();
          this.menuStrip1.SuspendLayout();
          this.SuspendLayout();
          // 
          // MainToolStripContainer
          // 
          // 
          // MainToolStripContainer.ContentPanel
          // 
          this.MainToolStripContainer.ContentPanel.Size = new System.Drawing.Size(558, 406);
          this.MainToolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
          this.MainToolStripContainer.Location = new System.Drawing.Point(0, 0);
          this.MainToolStripContainer.Name = "MainToolStripContainer";
          this.MainToolStripContainer.Size = new System.Drawing.Size(558, 430);
          this.MainToolStripContainer.TabIndex = 0;
          this.MainToolStripContainer.Text = "toolStripContainer1";
          // 
          // MainToolStripContainer.TopToolStripPanel
          // 
          this.MainToolStripContainer.TopToolStripPanel.Controls.Add(this.menuStrip1);
          // 
          // menuStrip1
          // 
          this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
          this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
          this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
          this.menuStrip1.Location = new System.Drawing.Point(0, 0);
          this.menuStrip1.Name = "menuStrip1";
          this.menuStrip1.Size = new System.Drawing.Size(558, 24);
          this.menuStrip1.TabIndex = 0;
          this.menuStrip1.Text = "menuStrip1";
          // 
          // fileToolStripMenuItem
          // 
          this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.propertiesToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
          this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
          this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
          this.fileToolStripMenuItem.Text = "&File";
          // 
          // newToolStripMenuItem
          // 
          this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
          this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
          this.newToolStripMenuItem.Name = "newToolStripMenuItem";
          this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
          this.newToolStripMenuItem.Text = "&New...";
          this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
          // 
          // openToolStripMenuItem
          // 
          this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
          this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
          this.openToolStripMenuItem.Name = "openToolStripMenuItem";
          this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
          this.openToolStripMenuItem.Text = "&Open...";
          this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
          // 
          // saveToolStripMenuItem
          // 
          this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
          this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Transparent;
          this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
          this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
          this.saveToolStripMenuItem.Text = "&Save";
          this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
          // 
          // saveAsToolStripMenuItem
          // 
          this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
          this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
          this.saveAsToolStripMenuItem.Text = "Save &As...";
          this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
          // 
          // toolStripMenuItem1
          // 
          this.toolStripMenuItem1.Name = "toolStripMenuItem1";
          this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
          // 
          // propertiesToolStripMenuItem
          // 
          this.propertiesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("propertiesToolStripMenuItem.Image")));
          this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
          this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
          this.propertiesToolStripMenuItem.Text = "&Properties...";
          this.propertiesToolStripMenuItem.Click += new System.EventHandler(this.propertiesToolStripMenuItem_Click);
          // 
          // toolStripMenuItem2
          // 
          this.toolStripMenuItem2.Name = "toolStripMenuItem2";
          this.toolStripMenuItem2.Size = new System.Drawing.Size(149, 6);
          // 
          // exitToolStripMenuItem
          // 
          this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
          this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
          this.exitToolStripMenuItem.Text = "E&xit";
          this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
          // 
          // helpToolStripMenuItem
          // 
          this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
          this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
          this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
          this.helpToolStripMenuItem.Text = "&Help";
          // 
          // aboutToolStripMenuItem
          // 
          this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
          this.aboutToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
          this.aboutToolStripMenuItem.Text = "&About AvanteWare RSSEdit";
          this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
          // 
          // SaveRSSDialog
          // 
          this.SaveRSSDialog.DefaultExt = "xml";
          this.SaveRSSDialog.Filter = "RSS files (*.xml)|*.xml|All files (*.*)|*.* ";
          this.SaveRSSDialog.InitialDirectory = global::Avanteware.RSSEdit.Properties.Settings.Default.SavePath;
          this.SaveRSSDialog.Title = "Save RSS File";
          // 
          // OpenRSSDialog
          // 
          this.OpenRSSDialog.AddExtension = false;
          this.OpenRSSDialog.DefaultExt = "xml";
          this.OpenRSSDialog.Filter = "RSS files (*.xml)|*.xml|All files (*.*)|*.* ";
          this.OpenRSSDialog.InitialDirectory = global::Avanteware.RSSEdit.Properties.Settings.Default.OpenPath;
          this.OpenRSSDialog.Title = "Open RSS File";
          // 
          // AppMain
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.ClientSize = new System.Drawing.Size(558, 430);
          this.Controls.Add(this.MainToolStripContainer);
          this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::Avanteware.RSSEdit.Properties.Settings.Default, "AppMainLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
          this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
          this.Location = global::Avanteware.RSSEdit.Properties.Settings.Default.AppMainLocation;
          this.MainMenuStrip = this.menuStrip1;
          this.MinimumSize = new System.Drawing.Size(500, 400);
          this.Name = "AppMain";
          this.Text = "RSSEdit";
          this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AppMain_FormClosing);
          this.MainToolStripContainer.TopToolStripPanel.ResumeLayout(false);
          this.MainToolStripContainer.TopToolStripPanel.PerformLayout();
          this.MainToolStripContainer.ResumeLayout(false);
          this.MainToolStripContainer.PerformLayout();
          this.menuStrip1.ResumeLayout(false);
          this.menuStrip1.PerformLayout();
          this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer MainToolStripContainer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog SaveRSSDialog;
        private System.Windows.Forms.OpenFileDialog OpenRSSDialog;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    }
}

