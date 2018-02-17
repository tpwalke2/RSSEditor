using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Avanteware.RSSEdit {
  public partial class AppMain : Form, IAppMain {
    private EditView _editView;
    
    public event EventHandler GenerateNewFile;
    public event EventHandler OpenExistingFile;
    public event EventHandler SaveCurrentFile;
    public event EventHandler SaveCurrentFileAs;
    public event EventHandler EditFileProperties;
    public event CancelEventHandler ExitApplication;
    public event EventHandler ShowApplicationInformation;

    public AppMain() {
      InitializeComponent();

      _editView = new EditView();

      MainToolStripContainer.ContentPanel.Controls.Add(_editView);
      _editView.Dock = DockStyle.Fill;
      _editView.Show();
    }

    public string GetOpenFileName() {
      return getFileName(OpenRSSDialog, "OpenPath");
    }

    public string GetSaveFileName() {
      return getFileName(SaveRSSDialog, "SavePath");
    }

    public void UpdateView(string title, IList<IRSSItem> items) {
      if (title.Equals("")) {
        title = "Untitled";
      }
      this.Text = title;

      _editView.Items = items;
    }

    public QuestionResult AskQuestion(string Prompt) {
      DialogResult result = MessageBox.Show(this, Prompt, Application.ProductName, MessageBoxButtons.YesNoCancel);
      switch (result) {
        case DialogResult.Yes:
          return QuestionResult.Yes;
        case DialogResult.No:
          return QuestionResult.No;
        case DialogResult.Cancel:
        default:
          return QuestionResult.Cancel;
      }
    }

    public IEditView ChildEditView {
      get {
        return _editView;
      }
    }

    private string getFileName(FileDialog dialog, string propertyName) {
      if (dialog.ShowDialog(this) == DialogResult.OK) {
        FileInfo fi = new FileInfo(dialog.FileName);
        Properties.Settings.Default[propertyName] = fi.DirectoryName;
        return dialog.FileName;
      }
      return "";
    }

    private void newToolStripMenuItem_Click(object sender, EventArgs e) {
      if (GenerateNewFile != null) {
        GenerateNewFile(this, e);
      }
    }

    private void openToolStripMenuItem_Click(object sender, EventArgs e) {
      if (OpenExistingFile != null) {
        OpenExistingFile(this, e);
      }
    }

    private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
      if (SaveCurrentFile != null) {
        SaveCurrentFile(this, e);
      }
    }

    private void saveAsToolStripMenuItem_Click(object sender, EventArgs e) {
      if (SaveCurrentFileAs != null) {
        SaveCurrentFileAs(this, e);
      }
    }

    private void propertiesToolStripMenuItem_Click(object sender, EventArgs e) {
      if (EditFileProperties != null) {
        EditFileProperties(this, e);
      }
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
      if (ExitApplication != null) {
        ExitApplication(this, new FormClosingEventArgs(CloseReason.UserClosing, false));
      }
    }

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e) {
      if (ShowApplicationInformation != null) {
        ShowApplicationInformation(this, e);
      }
    }

    private void AppMain_FormClosing(object sender, FormClosingEventArgs e) {
      if (e.CloseReason == CloseReason.UserClosing) {
        if (ExitApplication != null) {
          ExitApplication(this, e);
        }
      }
    }
  }
}
