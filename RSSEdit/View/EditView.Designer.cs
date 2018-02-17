namespace Avanteware.RSSEdit
{
    partial class EditView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditView));
          this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
          this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
          this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
          this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
          this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
          this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
          this.ItemListLabel = new System.Windows.Forms.Label();
          this.ItemListBox = new System.Windows.Forms.ListBox();
          this.ItemEditor = new Avanteware.RSSEdit.EditItemView();
          this.MainToolStripContainer = new System.Windows.Forms.ToolStripContainer();
          this.EditToolStrip = new System.Windows.Forms.ToolStrip();
          this.AddNewItemButton = new System.Windows.Forms.ToolStripButton();
          this.RemoveItemButton = new System.Windows.Forms.ToolStripButton();
          this.MainSplitContainer.Panel1.SuspendLayout();
          this.MainSplitContainer.Panel2.SuspendLayout();
          this.MainSplitContainer.SuspendLayout();
          this.MainToolStripContainer.ContentPanel.SuspendLayout();
          this.MainToolStripContainer.TopToolStripPanel.SuspendLayout();
          this.MainToolStripContainer.SuspendLayout();
          this.EditToolStrip.SuspendLayout();
          this.SuspendLayout();
          // 
          // BottomToolStripPanel
          // 
          this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
          this.BottomToolStripPanel.Name = "BottomToolStripPanel";
          this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
          this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
          this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
          // 
          // TopToolStripPanel
          // 
          this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
          this.TopToolStripPanel.Name = "TopToolStripPanel";
          this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
          this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
          this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
          // 
          // RightToolStripPanel
          // 
          this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
          this.RightToolStripPanel.Name = "RightToolStripPanel";
          this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
          this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
          this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
          // 
          // LeftToolStripPanel
          // 
          this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
          this.LeftToolStripPanel.Name = "LeftToolStripPanel";
          this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
          this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
          this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
          // 
          // ContentPanel
          // 
          this.ContentPanel.Size = new System.Drawing.Size(150, 175);
          // 
          // MainSplitContainer
          // 
          this.MainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
          this.MainSplitContainer.Location = new System.Drawing.Point(0, 0);
          this.MainSplitContainer.Name = "MainSplitContainer";
          // 
          // MainSplitContainer.Panel1
          // 
          this.MainSplitContainer.Panel1.Controls.Add(this.ItemListLabel);
          this.MainSplitContainer.Panel1.Controls.Add(this.ItemListBox);
          this.MainSplitContainer.Panel1.Padding = new System.Windows.Forms.Padding(5);
          this.MainSplitContainer.Panel1MinSize = 50;
          // 
          // MainSplitContainer.Panel2
          // 
          this.MainSplitContainer.Panel2.Controls.Add(this.ItemEditor);
          this.MainSplitContainer.Panel2.Padding = new System.Windows.Forms.Padding(5);
          this.MainSplitContainer.Panel2MinSize = 60;
          this.MainSplitContainer.Size = new System.Drawing.Size(545, 304);
          this.MainSplitContainer.SplitterDistance = 219;
          this.MainSplitContainer.TabIndex = 1;
          // 
          // ItemListLabel
          // 
          this.ItemListLabel.AutoSize = true;
          this.ItemListLabel.Location = new System.Drawing.Point(5, 5);
          this.ItemListLabel.Name = "ItemListLabel";
          this.ItemListLabel.Size = new System.Drawing.Size(32, 13);
          this.ItemListLabel.TabIndex = 1;
          this.ItemListLabel.Text = "Items";
          // 
          // ItemListBox
          // 
          this.ItemListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                      | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
          this.ItemListBox.FormattingEnabled = true;
          this.ItemListBox.HorizontalScrollbar = true;
          this.ItemListBox.Location = new System.Drawing.Point(8, 21);
          this.ItemListBox.Name = "ItemListBox";
          this.ItemListBox.Size = new System.Drawing.Size(203, 277);
          this.ItemListBox.TabIndex = 0;
          this.ItemListBox.SelectedIndexChanged += new System.EventHandler(this.ItemListBox_SelectedIndexChanged);
          // 
          // ItemEditor
          // 
          this.ItemEditor.Dock = System.Windows.Forms.DockStyle.Fill;
          this.ItemEditor.ItemDescription = "";
          this.ItemEditor.ItemLink = "";
          this.ItemEditor.ItemTitle = "";
          this.ItemEditor.Location = new System.Drawing.Point(5, 5);
          this.ItemEditor.Name = "ItemEditor";
          this.ItemEditor.Padding = new System.Windows.Forms.Padding(5);
          this.ItemEditor.Size = new System.Drawing.Size(312, 294);
          this.ItemEditor.TabIndex = 0;
          this.ItemEditor.CancelItemChanges += new System.EventHandler(this.editItemView1_CancelItemChanges);
          this.ItemEditor.ApplyItemChanges += new System.EventHandler(this.editItemView1_ApplyItemChanges);
          // 
          // MainToolStripContainer
          // 
          // 
          // MainToolStripContainer.ContentPanel
          // 
          this.MainToolStripContainer.ContentPanel.Controls.Add(this.MainSplitContainer);
          this.MainToolStripContainer.ContentPanel.Size = new System.Drawing.Size(545, 304);
          this.MainToolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
          this.MainToolStripContainer.Location = new System.Drawing.Point(0, 0);
          this.MainToolStripContainer.Name = "MainToolStripContainer";
          this.MainToolStripContainer.Size = new System.Drawing.Size(545, 329);
          this.MainToolStripContainer.TabIndex = 2;
          this.MainToolStripContainer.Text = "toolStripContainer1";
          // 
          // MainToolStripContainer.TopToolStripPanel
          // 
          this.MainToolStripContainer.TopToolStripPanel.Controls.Add(this.EditToolStrip);
          // 
          // EditToolStrip
          // 
          this.EditToolStrip.Dock = System.Windows.Forms.DockStyle.None;
          this.EditToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddNewItemButton,
            this.RemoveItemButton});
          this.EditToolStrip.Location = new System.Drawing.Point(3, 0);
          this.EditToolStrip.Name = "EditToolStrip";
          this.EditToolStrip.Size = new System.Drawing.Size(89, 25);
          this.EditToolStrip.TabIndex = 0;
          // 
          // AddNewItemButton
          // 
          this.AddNewItemButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
          this.AddNewItemButton.Image = ((System.Drawing.Image)(resources.GetObject("AddNewItemButton.Image")));
          this.AddNewItemButton.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.AddNewItemButton.Name = "AddNewItemButton";
          this.AddNewItemButton.Size = new System.Drawing.Size(23, 22);
          this.AddNewItemButton.Text = "toolStripButton1";
          this.AddNewItemButton.Click += new System.EventHandler(this.AddNewItemButton_Click);
          // 
          // RemoveItemButton
          // 
          this.RemoveItemButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
          this.RemoveItemButton.Image = ((System.Drawing.Image)(resources.GetObject("RemoveItemButton.Image")));
          this.RemoveItemButton.ImageTransparentColor = System.Drawing.Color.Magenta;
          this.RemoveItemButton.Name = "RemoveItemButton";
          this.RemoveItemButton.Size = new System.Drawing.Size(23, 22);
          this.RemoveItemButton.Text = "toolStripButton1";
          this.RemoveItemButton.Click += new System.EventHandler(this.RemoveItemButton_Click);
          // 
          // EditView
          // 
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.Controls.Add(this.MainToolStripContainer);
          this.MinimumSize = new System.Drawing.Size(406, 280);
          this.Name = "EditView";
          this.Size = new System.Drawing.Size(545, 329);
          this.MainSplitContainer.Panel1.ResumeLayout(false);
          this.MainSplitContainer.Panel1.PerformLayout();
          this.MainSplitContainer.Panel2.ResumeLayout(false);
          this.MainSplitContainer.ResumeLayout(false);
          this.MainToolStripContainer.ContentPanel.ResumeLayout(false);
          this.MainToolStripContainer.TopToolStripPanel.ResumeLayout(false);
          this.MainToolStripContainer.TopToolStripPanel.PerformLayout();
          this.MainToolStripContainer.ResumeLayout(false);
          this.MainToolStripContainer.PerformLayout();
          this.EditToolStrip.ResumeLayout(false);
          this.EditToolStrip.PerformLayout();
          this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer MainSplitContainer;
        private System.Windows.Forms.ListBox ItemListBox;
        private EditItemView ItemEditor;
        private System.Windows.Forms.Label ItemListLabel;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.ToolStripContainer MainToolStripContainer;
        private System.Windows.Forms.ToolStrip EditToolStrip;
        private System.Windows.Forms.ToolStripButton AddNewItemButton;
        private System.Windows.Forms.ToolStripButton RemoveItemButton;
    }
}
