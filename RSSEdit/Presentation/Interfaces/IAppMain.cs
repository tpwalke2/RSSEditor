using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Avanteware.RSSEdit {
  public enum QuestionResult { Yes, No, OK, Cancel }

  public interface IAppMain {
    event EventHandler GenerateNewFile;
    event EventHandler OpenExistingFile;
    event EventHandler SaveCurrentFile;
    event EventHandler SaveCurrentFileAs;
    event EventHandler EditFileProperties;
    event CancelEventHandler ExitApplication;
    event EventHandler ShowApplicationInformation;

    string GetOpenFileName();
    string GetSaveFileName();
    void UpdateView(string title, IList<IRSSItem> items);
    QuestionResult AskQuestion(string Prompt);
    IEditView ChildEditView { get; }
  }
}
