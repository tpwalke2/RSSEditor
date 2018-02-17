using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Avanteware.RSSEdit {
  public class AppMainPresenter {
    private RSSEditModel _model;
    private IAppMain _view;
    private IRSSFileSaveLoad _persister;

    // this is for unit testing only
    public AppMainPresenter(RSSEditModel model, IAppMain view, IRSSFileSaveLoad persister) {
      _model = model;
      _view = view;
      _persister = persister;

      SetupViewEventHandlers();
    }
    
    public AppMainPresenter(RSSEditModel model, IAppMain view) {
      _model = model;
      _view = view;
      _persister = new RSSFileSaveLoad();

      SetupViewEventHandlers();
    }

    public event CancelEventHandler ExitApplication;
    public event EditItemPropertiesEventHandler EditFileProperties;
    public event EventHandler ShowApplicationInformation;

    private void SetupViewEventHandlers() {
      _view.GenerateNewFile += new EventHandler(this.MainView_GenerateNewFile);
      _view.OpenExistingFile += new EventHandler(this.MainView_OpenExistingFile);
      _view.SaveCurrentFile += new EventHandler(this.MainView_SaveCurrentFile);
      _view.SaveCurrentFileAs += new EventHandler(this.MainView_SaveCurrentFileAs);
      _view.EditFileProperties += new EventHandler(this.MainView_EditFileProperties);
      _view.ExitApplication += new CancelEventHandler(this.MainView_ExitApplication);
      _view.ShowApplicationInformation += new EventHandler(this.MainView_ShowApplicationInformation);
    }

    private void saveRSSFile(string filename) {
      if (filename.Equals("")) {
        filename = _view.GetSaveFileName();
      }

      if (!filename.Equals("")) {
        _model.FileName = filename;
        _persister.Save(_model.RSSFile, filename);
        _model.Modified = false;
      }
    }

    private void openRSSFile(string filename) {
      if (!filename.Equals("")) {
        _model.FileName = filename;
        _model.RSSFile = _persister.Load(_model.FileName);
        _model.Modified = false;
      }
    }

    private QuestionResult SaveIfModified() {
      if (_model.Modified) {
        return _view.AskQuestion("Save changes before continuing?");
      }
      return QuestionResult.No;
    }

    private void MainView_GenerateNewFile(object sender, EventArgs e) {
      switch (SaveIfModified()) {
        case QuestionResult.Yes:
          saveRSSFile(_model.FileName);
          break;
        case QuestionResult.Cancel:
          return;
      }
      if (EditFileProperties != null) {
        IRSSItem item = new RSSItem();
        EditItemPropertiesEventArgs editItemPropertiesEvent = new EditItemPropertiesEventArgs(item);
        EditFileProperties(editItemPropertiesEvent);
        if (editItemPropertiesEvent.ItemChanged) {
          _model.Clear();

          _model.RSSFile.Title = item.Title;
          _model.RSSFile.Link = item.Link;
          _model.RSSFile.Description = item.Description;
        }
      } else {
        _model.Clear();
      }
      _view.UpdateView(_model.RSSFile.Title, _model.RSSFile.Items);
    }

    private void MainView_OpenExistingFile(object sender, EventArgs e) {
      switch (SaveIfModified()) {
        case QuestionResult.Yes:
          saveRSSFile(_model.FileName);
          openRSSFile(_view.GetOpenFileName());
          break;
        case QuestionResult.No:
          openRSSFile(_view.GetOpenFileName());
          break;
        case QuestionResult.Cancel:
          return;
      }
      _view.UpdateView(_model.RSSFile.Title, _model.RSSFile.Items);
    }

    private void MainView_SaveCurrentFile(object sender, EventArgs e) {
      saveRSSFile(_model.FileName);
      _view.UpdateView(_model.RSSFile.Title, _model.RSSFile.Items);
    }

    private void MainView_SaveCurrentFileAs(object sender, EventArgs e) {
      saveRSSFile("");
      _view.UpdateView(_model.RSSFile.Title, _model.RSSFile.Items);
    }

    private void MainView_EditFileProperties(object sender, EventArgs e) {
      EditItemPropertiesEventArgs evt = new EditItemPropertiesEventArgs(_model.RSSFile);
      EditFileProperties(evt);
      if (evt.ItemChanged) {
        _view.UpdateView(_model.RSSFile.Title, _model.RSSFile.Items);
      }
    }

    private void MainView_ExitApplication(object sender, CancelEventArgs e) {
      switch (SaveIfModified()) {
        case QuestionResult.Yes:
          saveRSSFile(_model.FileName);
          break;
        case QuestionResult.Cancel:
          e.Cancel = true;
          return;
      }
      if (ExitApplication != null) {
        e.Cancel = false;
        ExitApplication(sender, e);
      }
    }

    private void MainView_ShowApplicationInformation(object sender, EventArgs e) {
      if (ShowApplicationInformation != null) {
        ShowApplicationInformation(this, e);
      }
    }
  }
}
