using System;

namespace Avanteware.RSSEdit {
  public class EditPresenter {
    private RSSEditModel _model;
    private IEditView _view;

    public EditPresenter(RSSEditModel model, IEditView view) {
      _model = model;
      _view = view;

      _view.Items = _model.RSSFile.Items;
      _view.SelectedItemChanged += new EventHandler(this.EditView_SelectionChanged);
      _view.ApplyItemEdits += new EventHandler(this.EditView_ApplyItemEdits);
      _view.CancelItemEdits += new EventHandler(this.EditView_CancelItemEdits);
      _view.AddNewItem += new EventHandler(this.EditView_AddNewItem);
      _view.RemoveSelectedItem += new EventHandler(this.EditView_RemoveSelectedItem);
    }

    private void EditView_SelectionChanged(object sender, EventArgs e) {
      SetModelSelectedItem();
    }

    private void EditView_ApplyItemEdits(object sender, EventArgs e) {
      IRSSItem viewItem = _view.EditItem;
      if (!_model.SelectedItem.Equals(viewItem)) {
        _model.SelectedItem = viewItem;
        _model.Modified = true;
        _view.Items = _model.RSSFile.Items;
      }
    }

    private void EditView_CancelItemEdits(object sender, EventArgs e) {
      _view.EditItem = _model.SelectedItem;
    }

    private void EditView_AddNewItem(object sender, EventArgs e) {
      _model.RSSFile.Items.Add(new RSSItem("New Item", "", ""));
      _model.Modified = true;
      _view.Items = _model.RSSFile.Items;
      _view.SelectedItemIndex = _model.RSSFile.Items.Count - 1;
      SetModelSelectedItem();
    }

    private void EditView_RemoveSelectedItem(object sender, EventArgs e) {
      int selIndex = _view.SelectedItemIndex;
      if (selIndex != -1) {
        _model.RSSFile.Items.Remove(_model.SelectedItem);
        _model.Modified = true;
        _view.Items = _model.RSSFile.Items;
        _view.SelectedItemIndex = -1;
        _model.SelectedItem = null;
      }
    }

    private void SetModelSelectedItem() {
      if ((_view.SelectedItemIndex == -1) || (_view.SelectedItemIndex >= _model.RSSFile.Items.Count)) {
        _model.SelectedItem = null;
      } else {
        _model.SelectedItem = _model.RSSFile.Items[_view.SelectedItemIndex];
      }
      _view.EditItem = _model.SelectedItem;
    }
  }
}
