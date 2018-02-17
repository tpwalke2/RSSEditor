using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Avanteware.RSSEdit {
  public partial class EditView : UserControl, IEditView {
    private IList<IRSSItem> _items;
    
    public event EventHandler SelectedItemChanged;
    public event EventHandler ApplyItemEdits;
    public event EventHandler CancelItemEdits;
    public event EventHandler AddNewItem;
    public event EventHandler RemoveSelectedItem;

    public EditView() {
      InitializeComponent();
      EditItem = null;
    }

    private void ItemListBox_SelectedIndexChanged(object sender, EventArgs e) {
      if (SelectedItemChanged != null) SelectedItemChanged(this, e);
      RemoveItemButton.Enabled = (SelectedItemIndex != -1);
    }

    private void editItemView1_ApplyItemChanges(object sender, EventArgs e) {
      if (ApplyItemEdits != null) ApplyItemEdits(this, e);
    }

    private void editItemView1_CancelItemChanges(object sender, EventArgs e) {
      if (CancelItemEdits != null) CancelItemEdits(this, e);
    }

    private void AddNewItemButton_Click(object sender, EventArgs e) {
      if (AddNewItem != null) AddNewItem(this, e);
    }

    private void RemoveItemButton_Click(object sender, EventArgs e) {
      if (RemoveSelectedItem != null) RemoveSelectedItem(this, e);
    }

    public int SelectedItemIndex {
      get {
        return ItemListBox.SelectedIndex;
      }
      set {
        ItemListBox.SelectedIndex = value;
      }
    }

    public IRSSItem EditItem {
      get {
        return new RSSItem(ItemEditor.ItemTitle, ItemEditor.ItemLink, ItemEditor.ItemDescription);
      }
      set {
        if (value == null) {
          ItemEditor.Clear();
          ItemEditor.Enabled = false;
        } else {
          ItemEditor.ItemTitle = value.Title;
          ItemEditor.ItemLink = value.Link;
          ItemEditor.ItemDescription = value.Description;
          ItemEditor.Enabled = true;
        }
        ItemEditor.Visible = ItemEditor.Enabled;
      }
    }

    public IList<IRSSItem> Items {
      get {
        return _items;
      }
      set {
        _items = value;
        ItemListBox.DataSource = null;
        ItemListBox.Items.Clear();
        ItemListBox.DataSource = _items;
        ItemListBox.DisplayMember = "Title";
      }
    }

    public IEditItemView ChildEditItemView {
      get {
        return ItemEditor;
      }
    }
  }
}
