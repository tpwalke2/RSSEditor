using System;

namespace Avanteware.RSSEdit {
  public class EditItemPresenter {
    private IRSSItem _item;
    private IEditItemView _view;

    public event ModelChangedEventHandler ApplyChanges;
    public event ModelChangedEventHandler CancelChanges;

    public EditItemPresenter(IEditItemView view) {
      _view = view;
      _item = new RSSItem();

      _view.ApplyItemChanges += new EventHandler(this.View_ApplyItemChanges);
      _view.CancelItemChanges += new EventHandler(this.View_CancelItemChanges);
    }

    public void UpdateView(IRSSItem item) {
      _item = item;

      _view.ItemTitle = _item.Title;
      _view.ItemLink = _item.Link;
      _view.ItemDescription = _item.Description;
    }

    private void View_ApplyItemChanges(object sender, EventArgs e) {
      _item.Title = _view.ItemTitle;
      _item.Link = _view.ItemLink;
      _item.Description = _view.ItemDescription;
      if (ApplyChanges != null) {
        ApplyChanges(new ModelChangedEventArgs(true));
      }
    }

    private void View_CancelItemChanges(object sender, EventArgs e) {
      if (CancelChanges != null) {
        CancelChanges(new ModelChangedEventArgs(false));
      }
    }
  }
}
