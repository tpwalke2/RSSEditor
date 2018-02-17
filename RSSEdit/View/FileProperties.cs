using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Avanteware.RSSEdit {
  public partial class FileProperties : Form, IEditItemView {
    public FileProperties() {
      InitializeComponent();
    }

    public string ItemTitle {
      get {
        return ItemEditor.ItemTitle;
      }
      set {
        ItemEditor.ItemTitle = value;
      }
    }

    public string ItemLink {
      get {
        return ItemEditor.ItemLink;
      }
      set {
        ItemEditor.ItemLink = value;
      }
    }

    public string ItemDescription {
      get {
        return ItemEditor.ItemDescription;
      }
      set {
        ItemEditor.ItemDescription = value;
      }
    }

    public new bool Enabled {
      get {
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

    private void ItemEditor_ApplyItemChanges(object sender, EventArgs e) {

      if (ApplyItemChanges != null) {
        ApplyItemChanges(this, e);
      }
    }

    private void ItemEditor_CancelItemChanges(object sender, EventArgs e) {
      if (CancelItemChanges != null) {
        CancelItemChanges(this, e);
      }
    }

    private void ItemEditor_ItemChanged(object sender, EventArgs e) {
      if (ItemChanged != null) {
        ItemChanged(this, e);
      }
    }
  }
}
