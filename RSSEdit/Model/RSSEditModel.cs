using System;

namespace Avanteware.RSSEdit {
  public sealed class RSSEditModel {
    private string _filename;
    private bool _modified;
    private IRSSFile _rssFile;
    private int _selectedIndex;

    public RSSEditModel() {
      FileName = "";
      RSSFile = new RSSFile();
      Modified = false;
      _selectedIndex = -1;
    }

    public string FileName {
      get {
        return _filename;
      }
      set {
        _filename = value;
      }
    }

    public bool Modified {
      get {
        return _modified;
      }
      set {
        _modified = value;
      }
    }

    public IRSSFile RSSFile {
      get {
        return _rssFile;
      }
      set {
        _rssFile = value;
      }
    }

    /// <summary>
    /// Contains a reference to the currently selected item in Items.
    /// 
    /// When setting this property, if the new value is not found in
    /// Items, then the currently selected item will be changed to the
    /// new reference. For example:
    /// Suppose Items has two Items, "Item 1" and "Item 2" and the
    /// currently selected Item is "Item 1". Suppose the selected item
    /// is set to "Item 3" - "Item 1" will be replaced with "Item 3"
    /// 
    /// The only special case is null - you cannot delete items from
    /// the Items list by setting the SelectedItem property to null.
    /// If SelectedItem is set to null, the model will automatically 
    /// deselect any item.
    /// </summary>
    public IRSSItem SelectedItem {
      get {
        if (_selectedIndex == -1) {
          return null;
        } else {
          return RSSFile.Items[_selectedIndex];
        }
      }
      set {
        if (value == null) {
          _selectedIndex = -1;
        } else {
          int findIndex = RSSFile.Items.IndexOf(value);
          if (findIndex == -1) {
            RSSFile.Items[_selectedIndex] = value;
          } else {
            _selectedIndex = findIndex;
          }
        }
      }
    }

    public void Clear() {
      FileName = "";
      RSSFile = new RSSFile();
      SelectedItem = null;
      Modified = false;
    }
  }
}
