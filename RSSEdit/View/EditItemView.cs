using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Avanteware.RSSEdit {
  public partial class EditItemView : UserControl, IEditItemView {
    private IRSSItem _item = new RSSItem();

    public EditItemView() {
      InitializeComponent();
    }

    public string ItemTitle {
      get {
        return ItemTitleText.Text;
      }
      set {
        ItemTitleText.Text = value;
      }
    }

    public string ItemLink {
      get {
        return ItemLinkText.Text;
      }
      set {
        ItemLinkText.Text = value;
      }
    }

    public string ItemDescription {
      get {
        return ItemDescText.Text;
      }
      set {
        ItemDescText.Text = value;
      }
    }

    public new bool Enabled {
      get {
        foreach (Control ctrl in this.Controls) {
          if (!ctrl.Enabled) { return false; }
        }
        return true;
      }
      set {
        foreach (Control ctrl in this.Controls) {
          ctrl.Enabled = value;
        }
      }
    }

    public void Clear() {
      ItemTitle = "";
      ItemLink = "";
      ItemDescription = "";
    }

    public event EventHandler ApplyItemChanges;
    public event EventHandler CancelItemChanges;
    public event EventHandler ItemChanged;

    private void ApplyButton_Click(object sender, EventArgs e) {
      if (ApplyItemChanges != null) ApplyItemChanges(this, e);
    }

    private void CancelButton_Click(object sender, EventArgs e) {
      if (CancelItemChanges != null) CancelItemChanges(this, e);
    }

    private void ItemTitleText_TextChanged(object sender, EventArgs e) {
      if (ItemChanged != null) ItemChanged(this, e);
    }

    private void ItemLinkText_TextChanged(object sender, EventArgs e) {
      if (ItemChanged != null) ItemChanged(this, e);
    }

    private void ItemDescText_TextChanged(object sender, EventArgs e) {
      if (ItemChanged != null) ItemChanged(this, e);
    }
  }
}
