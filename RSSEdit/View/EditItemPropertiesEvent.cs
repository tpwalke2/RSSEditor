using System;
using System.Security.Permissions;

namespace Avanteware.RSSEdit {
  [HostProtectionAttribute(SecurityAction.LinkDemand, SharedState = true)]
  public delegate void EditItemPropertiesEventHandler(EditItemPropertiesEventArgs e);

  public class EditItemPropertiesEventArgs : EventArgs {
    private IRSSItem _editItem;
    private bool _itemChanged;

    public EditItemPropertiesEventArgs() { }
    public EditItemPropertiesEventArgs(IRSSItem editItem) {
      EditItem = editItem;
    }
    public EditItemPropertiesEventArgs(IRSSItem editItem, bool itemChanged) {
      EditItem = editItem;
      ItemChanged = itemChanged;
    }

    public IRSSItem EditItem {
      get {
        return _editItem;
      }
      set {
        _editItem = value;
      }
    }

    public bool ItemChanged {
      get {
        return _itemChanged;
      }
      set {
        _itemChanged = value;
      }
    }
  }
}
