using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Avanteware.RSSEdit {
  public class RSSEditAppContext : ApplicationContext {
    private RSSEditModel _model;

    private AppMain _mainView;
    private AppMainPresenter _mainPresenter;
    private IEditView _editView;
    private EditPresenter _editPresenter;
    private IEditItemView _editItemView;
    private EditItemPresenter _editItemPresenter;

    private FileProperties _filePropertiesView;
    private EditItemPresenter _filePropertiesPresenter;
    private bool _filePropertiesChanged;

    private AboutRSSEdit _aboutView;

    public RSSEditAppContext() {
      _model = new RSSEditModel();

      // views and presenters for main window
      _mainView = new AppMain();
      _mainPresenter = new AppMainPresenter(_model, _mainView);
      _mainPresenter.ExitApplication += new CancelEventHandler(this.MainPresenter_ExitApplication);
      _mainPresenter.EditFileProperties += new EditItemPropertiesEventHandler(this.MainPresenter_EditFileProperties);
      _mainPresenter.ShowApplicationInformation += new EventHandler(this.MainPresenter_ShowApplicationInformation);
      
      _editView = _mainView.ChildEditView;
      _editPresenter = new EditPresenter(_model, _editView);

      _editItemView = _editView.ChildEditItemView;
      _editItemPresenter = new EditItemPresenter(_editItemView);

      // view and presenter for file properties window
      _filePropertiesView = new FileProperties();
      _filePropertiesPresenter = new EditItemPresenter(_filePropertiesView);
      _filePropertiesPresenter.ApplyChanges += new ModelChangedEventHandler(this.FilePropertiesPresenter_FinishEdit);
      _filePropertiesPresenter.CancelChanges += new ModelChangedEventHandler(this.FilePropertiesPresenter_FinishEdit);
      _filePropertiesChanged = false;

      _aboutView = new AboutRSSEdit();
      
      _mainView.Show();
    }

    private void MainPresenter_ExitApplication(object sender, CancelEventArgs e) {
      Properties.Settings.Default.Save();
      Application.Exit();
    }

    private void MainPresenter_EditFileProperties(EditItemPropertiesEventArgs e) {
      _filePropertiesPresenter.UpdateView(e.EditItem);
      _filePropertiesView.ShowDialog(_mainView);
      e.ItemChanged = _filePropertiesChanged;
    }

    private void FilePropertiesPresenter_FinishEdit(ModelChangedEventArgs e) {
      _filePropertiesView.Hide();
      _filePropertiesChanged = e.ModelChanged;
    }

    private void MainPresenter_ShowApplicationInformation(object sender, EventArgs e) {
      _aboutView.ShowDialog(_mainView);
    }  
  }
}
