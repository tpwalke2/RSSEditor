namespace Avanteware.RSSEdit {
  partial class EditItemView {
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.CancelButton = new System.Windows.Forms.Button();
      this.ApplyButton = new System.Windows.Forms.Button();
      this.ItemDescText = new System.Windows.Forms.TextBox();
      this.ItemDescLabel = new System.Windows.Forms.Label();
      this.ItemLinkText = new System.Windows.Forms.TextBox();
      this.ItemLinkLabel = new System.Windows.Forms.Label();
      this.ItemTitleText = new System.Windows.Forms.TextBox();
      this.ItemTitleLabel = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // CancelButton
      // 
      this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.CancelButton.Location = new System.Drawing.Point(225, 212);
      this.CancelButton.Name = "CancelButton";
      this.CancelButton.Size = new System.Drawing.Size(75, 23);
      this.CancelButton.TabIndex = 15;
      this.CancelButton.Text = "&Cancel";
      this.CancelButton.UseVisualStyleBackColor = true;
      this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
      // 
      // ApplyButton
      // 
      this.ApplyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.ApplyButton.Location = new System.Drawing.Point(144, 212);
      this.ApplyButton.Name = "ApplyButton";
      this.ApplyButton.Size = new System.Drawing.Size(75, 23);
      this.ApplyButton.TabIndex = 14;
      this.ApplyButton.Text = "&Apply";
      this.ApplyButton.UseVisualStyleBackColor = true;
      this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
      // 
      // ItemDescText
      // 
      this.ItemDescText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.ItemDescText.Location = new System.Drawing.Point(74, 54);
      this.ItemDescText.Multiline = true;
      this.ItemDescText.Name = "ItemDescText";
      this.ItemDescText.Size = new System.Drawing.Size(226, 152);
      this.ItemDescText.TabIndex = 13;
      this.ItemDescText.TextChanged += new System.EventHandler(this.ItemDescText_TextChanged);
      // 
      // ItemDescLabel
      // 
      this.ItemDescLabel.AutoSize = true;
      this.ItemDescLabel.Location = new System.Drawing.Point(8, 57);
      this.ItemDescLabel.Name = "ItemDescLabel";
      this.ItemDescLabel.Size = new System.Drawing.Size(60, 13);
      this.ItemDescLabel.TabIndex = 12;
      this.ItemDescLabel.Text = "Description";
      // 
      // ItemLinkText
      // 
      this.ItemLinkText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.ItemLinkText.Location = new System.Drawing.Point(74, 28);
      this.ItemLinkText.Name = "ItemLinkText";
      this.ItemLinkText.Size = new System.Drawing.Size(226, 20);
      this.ItemLinkText.TabIndex = 11;
      this.ItemLinkText.TextChanged += new System.EventHandler(this.ItemLinkText_TextChanged);
      // 
      // ItemLinkLabel
      // 
      this.ItemLinkLabel.AutoSize = true;
      this.ItemLinkLabel.Location = new System.Drawing.Point(8, 31);
      this.ItemLinkLabel.Name = "ItemLinkLabel";
      this.ItemLinkLabel.Size = new System.Drawing.Size(27, 13);
      this.ItemLinkLabel.TabIndex = 10;
      this.ItemLinkLabel.Text = "Link";
      // 
      // ItemTitleText
      // 
      this.ItemTitleText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.ItemTitleText.Location = new System.Drawing.Point(74, 2);
      this.ItemTitleText.Name = "ItemTitleText";
      this.ItemTitleText.Size = new System.Drawing.Size(226, 20);
      this.ItemTitleText.TabIndex = 9;
      this.ItemTitleText.TextChanged += new System.EventHandler(this.ItemTitleText_TextChanged);
      // 
      // ItemTitleLabel
      // 
      this.ItemTitleLabel.AutoSize = true;
      this.ItemTitleLabel.Location = new System.Drawing.Point(8, 5);
      this.ItemTitleLabel.Name = "ItemTitleLabel";
      this.ItemTitleLabel.Size = new System.Drawing.Size(27, 13);
      this.ItemTitleLabel.TabIndex = 8;
      this.ItemTitleLabel.Text = "Title";
      // 
      // EditItemView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.CancelButton);
      this.Controls.Add(this.ApplyButton);
      this.Controls.Add(this.ItemDescText);
      this.Controls.Add(this.ItemDescLabel);
      this.Controls.Add(this.ItemLinkText);
      this.Controls.Add(this.ItemLinkLabel);
      this.Controls.Add(this.ItemTitleText);
      this.Controls.Add(this.ItemTitleLabel);
      this.Name = "EditItemView";
      this.Padding = new System.Windows.Forms.Padding(5);
      this.Size = new System.Drawing.Size(308, 242);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button CancelButton;
    private System.Windows.Forms.Button ApplyButton;
    private System.Windows.Forms.TextBox ItemDescText;
    private System.Windows.Forms.Label ItemDescLabel;
    private System.Windows.Forms.TextBox ItemLinkText;
    private System.Windows.Forms.Label ItemLinkLabel;
    private System.Windows.Forms.TextBox ItemTitleText;
    private System.Windows.Forms.Label ItemTitleLabel;
  }
}
