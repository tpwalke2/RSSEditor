using System;
using System.Collections.Generic;

namespace Avanteware.RSSEdit {
  public interface IEditView {
    event EventHandler SelectedItemChanged;
    event EventHandler ApplyItemEdits;
    event EventHandler CancelItemEdits;
    event EventHandler AddNewItem;
    event EventHandler RemoveSelectedItem;

    IEditItemView ChildEditItemView { get; }
    IList<IRSSItem> Items { get; set; }
    int SelectedItemIndex { get; set; }
    IRSSItem EditItem { get; set; }
  }
}
