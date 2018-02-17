namespace Avanteware.RSSEdit {
  partial class FileProperties {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.ItemEditor = new Avanteware.RSSEdit.EditItemView();
      this.SuspendLayout();
      // 
      // ItemEditor
      // 
      this.ItemEditor.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ItemEditor.ItemDescription = "";
      this.ItemEditor.ItemLink = "";
      this.ItemEditor.ItemTitle = "";
      this.ItemEditor.Location = new System.Drawing.Point(0, 5);
      this.ItemEditor.Name = "ItemEditor";
      this.ItemEditor.Padding = new System.Windows.Forms.Padding(5);
      this.ItemEditor.Size = new System.Drawing.Size(294, 263);
      this.ItemEditor.TabIndex = 0;
      this.ItemEditor.CancelItemChanges += new System.EventHandler(this.ItemEditor_CancelItemChanges);
      this.ItemEditor.ItemChanged += new System.EventHandler(this.ItemEditor_ItemChanged);
      this.ItemEditor.ApplyItemChanges += new System.EventHandler(this.ItemEditor_ApplyItemChanges);
      // 
      // FileProperties
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(294, 268);
      this.Controls.Add(this.ItemEditor);
      this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::Avanteware.RSSEdit.Properties.Settings.Default, "FormPropertiesLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Location = global::Avanteware.RSSEdit.Properties.Settings.Default.FormPropertiesLocation;
      this.MinimumSize = new System.Drawing.Size(300, 300);
      this.Name = "FileProperties";
      this.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "File Properties";
      this.ResumeLayout(false);

    }

    #endregion

    private EditItemView ItemEditor;
  }
}