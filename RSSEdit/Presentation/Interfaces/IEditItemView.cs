using System;

namespace Avanteware.RSSEdit {
  public interface IEditItemView {
    event EventHandler ApplyItemChanges;
    event EventHandler CancelItemChanges;
    event EventHandler ItemChanged;

    string ItemTitle { get; set; }
    string ItemLink { get; set; }
    string ItemDescription { get; set; }
    bool Enabled { get; set; }
    void Clear();
  }
}
