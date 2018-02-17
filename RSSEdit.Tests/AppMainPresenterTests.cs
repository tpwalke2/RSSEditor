using System;
using System.Collections.Generic;
using System.ComponentModel;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Interfaces;
using Avanteware.RSSEdit;

namespace Avanteware.RSSEdit.Tests {
  [TestFixture()]
  public class AppMainPresenterTests {
    private MockRepository _mocks;
    private IAppMain _mockView;
    private IEventRaiser genNewFileEventRaiser;
    private IEventRaiser openFileEventRaiser;
    private IEventRaiser saveFileEventRaiser;
    private IEventRaiser saveFileAsEventRaiser;
    private IEventRaiser editPropertiesEventRaiser;
    private IEventRaiser exitAppEventRaiser;
    private IEventRaiser showAppInfoEventRaiser;
    private IRSSFileSaveLoad _mockPersister;
    private RSSEditModel _model;
    private AppMainPresenter _presenter;
    private bool _eventHandled;

    [SetUp()]
    public void Setup() {
      _model = new RSSEditModel();

      _mocks = new MockRepository();
      _mockView = _mocks.DynamicMock<IAppMain>();
      _mockPersister = _mocks.DynamicMock<IRSSFileSaveLoad>();

      _eventHandled = false;
      
      // set up event expectations
      _mockView.GenerateNewFile += null;
      genNewFileEventRaiser = LastCall.IgnoreArguments().GetEventRaiser();
      _mockView.OpenExistingFile += null;
      openFileEventRaiser = LastCall.IgnoreArguments().GetEventRaiser();
      _mockView.SaveCurrentFile += null;
      saveFileEventRaiser = LastCall.IgnoreArguments().GetEventRaiser();
      _mockView.SaveCurrentFileAs += null;
      saveFileAsEventRaiser = LastCall.IgnoreArguments().GetEventRaiser();
      _mockView.EditFileProperties += null;
      editPropertiesEventRaiser = LastCall.IgnoreArguments().GetEventRaiser();
      _mockView.ExitApplication += null;
      exitAppEventRaiser = LastCall.IgnoreArguments().GetEventRaiser();
      _mockView.ShowApplicationInformation += null;
      showAppInfoEventRaiser = LastCall.IgnoreArguments().GetEventRaiser();
    }

    [TearDown()]
    public void TearDown() {
      _mocks.VerifyAll();
    }

    [Test()]
    public void GenerateNewFileUnregisteredEventHandler() {
      _model.RSSFile = GetHardCodedData();
      _model.FileName = "fakefilename.xml";
      _model.Modified = false;

      using (_mocks.Record()) {
        _mockView.UpdateView("", new List<IRSSItem>());
      }

      using (_mocks.Playback()) {
        _presenter = new AppMainPresenter(_model, _mockView, _mockPersister);
        genNewFileEventRaiser.Raise(null, null);
      }

      Assert.AreEqual("", _model.FileName);
      Assert.IsFalse(_model.Modified);
      Assert.AreEqual(null, _model.SelectedItem);
      Assert.AreEqual("", _model.RSSFile.Title);
      Assert.AreEqual("", _model.RSSFile.Link);
      Assert.AreEqual("", _model.RSSFile.Description);
      Assert.AreEqual(0, _model.RSSFile.Items.Count);
      Assert.IsFalse(_eventHandled);
    }

    [Test()]
    public void GenerateNewFile_UnmodifiedModelCancelClickedInNew() {
      _model.RSSFile = GetHardCodedData();
      _model.FileName = "fakefilename.xml";
      _model.Modified = false;

      using (_mocks.Record()) {
        _mockView.UpdateView("RSSEdit Unit Tests", _model.RSSFile.Items);
      }

      using (_mocks.Playback()) {
        _presenter = new AppMainPresenter(_model, _mockView, _mockPersister);
        _presenter.EditFileProperties += new EditItemPropertiesEventHandler(this.Presenter_EditFilePropertiesNoChangesMade);
        genNewFileEventRaiser.Raise(null, null);
      }

      Assert.AreEqual("fakefilename.xml", _model.FileName);
      Assert.IsFalse(_model.Modified);
      Assert.AreEqual(null, _model.SelectedItem);
      Assert.AreEqual("RSSEdit Unit Tests", _model.RSSFile.Title);
      Assert.AreEqual("http://localhost", _model.RSSFile.Link);
      Assert.AreEqual("Testing", _model.RSSFile.Description);
      Assert.AreEqual(1, _model.RSSFile.Items.Count);
      Assert.IsTrue(_eventHandled);
    }

    [Test()]
    public void GenerateNewFileUninitializedModel() {
      using (_mocks.Record()) {
        _mockView.UpdateView("", _model.RSSFile.Items);
      }

      using (_mocks.Playback()) {
        _presenter = new AppMainPresenter(_model, _mockView, _mockPersister);
        _presenter.EditFileProperties += new EditItemPropertiesEventHandler(this.Presenter_EditFilePropertiesChangesMade);
        genNewFileEventRaiser.Raise(null, null);
      }

      Assert.AreEqual("", _model.FileName);
      Assert.IsFalse(_model.Modified);
      Assert.AreEqual(null, _model.SelectedItem);
      Assert.AreEqual("", _model.RSSFile.Title);
      Assert.AreEqual("", _model.RSSFile.Link);
      Assert.AreEqual("", _model.RSSFile.Description);
      Assert.AreEqual(0, _model.RSSFile.Items.Count);
      Assert.IsTrue(_eventHandled);
    }

    [Test()]
    public void GenerateNewFileUnmodifiedModel() {
      _model.RSSFile = GetHardCodedData();
      _model.FileName = "fakefilename.xml";
      _model.Modified = false;

      using (_mocks.Record()) {
        _mockView.UpdateView("This is a new title", new List<IRSSItem>());
      }

      using (_mocks.Playback()) {
        _presenter = new AppMainPresenter(_model, _mockView, _mockPersister);
        _presenter.EditFileProperties += new EditItemPropertiesEventHandler(this.Presenter_EditFileProperties_WithActualChanges);
        genNewFileEventRaiser.Raise(null, null);
      }

      Assert.AreEqual("", _model.FileName);
      Assert.IsFalse(_model.Modified);
      Assert.AreEqual(null, _model.SelectedItem);
      Assert.AreEqual("This is a new title", _model.RSSFile.Title);
      Assert.AreEqual("http://127.0.0.1/NewLink", _model.RSSFile.Link);
      Assert.AreEqual("This is some new descriptive text", _model.RSSFile.Description);
      Assert.AreEqual(0, _model.RSSFile.Items.Count);
      Assert.IsTrue(_eventHandled);
    }

    [Test()]
    public void GenerateNewFileModifiedModelSave() {
      _model.RSSFile = GetHardCodedData();
      _model.FileName = "fakefilename.xml";
      _model.Modified = true;

      using (_mocks.Record()) {
        Expect.Call(_mockView.AskQuestion(null)).IgnoreArguments().Return(QuestionResult.Yes);
        _mockPersister.Save(_model.RSSFile, _model.FileName);
        _mockView.UpdateView("", new List<IRSSItem>());
      }

      using (_mocks.Playback()) {
        _presenter = new AppMainPresenter(_model, _mockView, _mockPersister);
        _presenter.EditFileProperties += new EditItemPropertiesEventHandler(this.Presenter_EditFilePropertiesChangesMade);
        genNewFileEventRaiser.Raise(null, null);
      }

      Assert.AreEqual("", _model.FileName);
      Assert.IsFalse(_model.Modified);
      Assert.AreEqual(null, _model.SelectedItem);
      Assert.AreEqual("", _model.RSSFile.Title);
      Assert.AreEqual("", _model.RSSFile.Link);
      Assert.AreEqual("", _model.RSSFile.Description);
      Assert.AreEqual(0, _model.RSSFile.Items.Count);
      Assert.IsTrue(_eventHandled);
    }

    [Test()]
    public void GenerateNewFileModifiedModelNoSave() {
      _model.RSSFile = GetHardCodedData();
      _model.FileName = "fakefilename.xml";
      _model.Modified = true;

      using (_mocks.Record()) {
        Expect.Call(_mockView.AskQuestion(null)).IgnoreArguments().Return(QuestionResult.No);
        _mockView.UpdateView("", new List<IRSSItem>());
      }

      using (_mocks.Playback()) {
        _presenter = new AppMainPresenter(_model, _mockView, _mockPersister);
        _presenter.EditFileProperties += new EditItemPropertiesEventHandler(this.Presenter_EditFilePropertiesChangesMade);
        genNewFileEventRaiser.Raise(null, null);
      }

      Assert.AreEqual("", _model.FileName);
      Assert.IsFalse(_model.Modified);
      Assert.AreEqual(null, _model.SelectedItem);
      Assert.AreEqual("", _model.RSSFile.Title);
      Assert.AreEqual("", _model.RSSFile.Link);
      Assert.AreEqual("", _model.RSSFile.Description);
      Assert.AreEqual(0, _model.RSSFile.Items.Count);
      Assert.IsTrue(_eventHandled);
    }

    [Test()]
    public void GenerateNewFileModifiedModelCancel() {
      _model.RSSFile = GetHardCodedData();
      _model.FileName = "fakefilename.xml";
      _model.Modified = true;

      using (_mocks.Record()) {
        Expect.Call(_mockView.AskQuestion(null)).IgnoreArguments().Return(QuestionResult.Cancel);
        _mockView.UpdateView(null, null);
        LastCall.IgnoreArguments().Repeat.Never();
      }

      using (_mocks.Playback()) {
        _presenter = new AppMainPresenter(_model, _mockView, _mockPersister);
        genNewFileEventRaiser.Raise(null, null);
      }

      Assert.AreEqual("fakefilename.xml", _model.FileName);
      Assert.IsTrue(_model.Modified);
      Assert.AreEqual(null, _model.SelectedItem);
      Assert.AreEqual("RSSEdit Unit Tests", _model.RSSFile.Title);
      Assert.AreEqual("http://localhost", _model.RSSFile.Link);
      Assert.AreEqual("Testing", _model.RSSFile.Description);
      Assert.AreEqual(1, _model.RSSFile.Items.Count);
    }

    [Test()]
    public void OpenExistingFileUninitializedModel() {
      using (_mocks.Record()) {
        Expect.Call(_mockView.GetOpenFileName()).Return("fakefilename.xml");
        Expect.Call(_mockPersister.Load("fakefilename.xml")).Return(GetHardCodedData());
        _mockView.UpdateView("RSSEdit Unit Tests", null);
        LastCall.IgnoreArguments();
      }

      using (_mocks.Playback()) {
        _presenter = new AppMainPresenter(_model, _mockView, _mockPersister);
        openFileEventRaiser.Raise(null, null);
      }

      Assert.AreEqual("fakefilename.xml", _model.FileName);
      Assert.IsFalse(_model.Modified);
      Assert.AreEqual(null, _model.SelectedItem);
      Assert.AreEqual("RSSEdit Unit Tests", _model.RSSFile.Title);
      Assert.AreEqual("http://localhost", _model.RSSFile.Link);
      Assert.AreEqual("Testing", _model.RSSFile.Description);
      Assert.AreEqual(1, _model.RSSFile.Items.Count);
    }

    [Test()]
    public void OpenExistingFileUnmodifiedModel() {
      _model.FileName = "donotcare.xml";
      _model.Modified = false;

      using (_mocks.Record()) {
        Expect.Call(_mockView.GetOpenFileName()).Return("fakefilename.xml");
        Expect.Call(_mockPersister.Load("fakefilename.xml")).Return(GetHardCodedData());
        _mockView.UpdateView("RSSEdit Unit Tests", null);
        LastCall.IgnoreArguments();
      }

      using (_mocks.Playback()) {
        _presenter = new AppMainPresenter(_model, _mockView, _mockPersister);
        openFileEventRaiser.Raise(null, null);
      }

      Assert.AreEqual("fakefilename.xml", _model.FileName);
      Assert.IsFalse(_model.Modified);
      Assert.AreEqual(null, _model.SelectedItem);
      Assert.AreEqual("RSSEdit Unit Tests", _model.RSSFile.Title);
      Assert.AreEqual("http://localhost", _model.RSSFile.Link);
      Assert.AreEqual("Testing", _model.RSSFile.Description);
      Assert.AreEqual(1, _model.RSSFile.Items.Count);
    }

    [Test()]
    public void OpenExistingFileModifiedModelSave() {
      _model.FileName = "donotcare.xml";
      _model.Modified = true;

      using (_mocks.Record()) {
        Expect.Call(_mockView.AskQuestion(null)).IgnoreArguments().Return(QuestionResult.Yes);
        _mockPersister.Save(_model.RSSFile, _model.FileName);
        Expect.Call(_mockView.GetOpenFileName()).Return("fakefilename.xml");
        Expect.Call(_mockPersister.Load("fakefilename.xml")).Return(GetHardCodedData());
        _mockView.UpdateView("RSSEdit Unit Tests", null);
        LastCall.IgnoreArguments();
      }

      using (_mocks.Playback()) {
        _presenter = new AppMainPresenter(_model, _mockView, _mockPersister);
        openFileEventRaiser.Raise(null, null);
      }

      Assert.AreEqual("fakefilename.xml", _model.FileName);
      Assert.IsFalse(_model.Modified);
      Assert.AreEqual(null, _model.SelectedItem);
      Assert.AreEqual("RSSEdit Unit Tests", _model.RSSFile.Title);
      Assert.AreEqual("http://localhost", _model.RSSFile.Link);
      Assert.AreEqual("Testing", _model.RSSFile.Description);
      Assert.AreEqual(1, _model.RSSFile.Items.Count);
    }

    [Test()]
    public void OpenExistingFileModifiedModelNoSave() {
      _model.FileName = "donotcare.xml";
      _model.Modified = true;

      using (_mocks.Record()) {
        Expect.Call(_mockView.AskQuestion(null)).IgnoreArguments().Return(QuestionResult.No);
        Expect.Call(_mockView.GetOpenFileName()).Return("fakefilename.xml");
        Expect.Call(_mockPersister.Load("fakefilename.xml")).Return(GetHardCodedData());
        _mockView.UpdateView("RSSEdit Unit Tests", null);
        LastCall.IgnoreArguments();
      }

      using (_mocks.Playback()) {
        _presenter = new AppMainPresenter(_model, _mockView, _mockPersister);
        openFileEventRaiser.Raise(null, null);
      }

      Assert.AreEqual("fakefilename.xml", _model.FileName);
      Assert.IsFalse(_model.Modified);
      Assert.AreEqual(null, _model.SelectedItem);
      Assert.AreEqual("RSSEdit Unit Tests", _model.RSSFile.Title);
      Assert.AreEqual("http://localhost", _model.RSSFile.Link);
      Assert.AreEqual("Testing", _model.RSSFile.Description);
      Assert.AreEqual(1, _model.RSSFile.Items.Count);
    }

    [Test()]
    public void OpenExistingFileModifiedModelCancel() {
      _model.FileName = "donotcare.xml";
      _model.Modified = true;

      using (_mocks.Record()) {
        Expect.Call(_mockView.AskQuestion(null)).IgnoreArguments().Return(QuestionResult.Cancel);
      }

      using (_mocks.Playback()) {
        _presenter = new AppMainPresenter(_model, _mockView, _mockPersister);
        openFileEventRaiser.Raise(null, null);
      }

      Assert.AreEqual("donotcare.xml", _model.FileName);
      Assert.IsTrue(_model.Modified);
      Assert.AreEqual(null, _model.SelectedItem);
      Assert.AreEqual("", _model.RSSFile.Title);
      Assert.AreEqual("", _model.RSSFile.Link);
      Assert.AreEqual("", _model.RSSFile.Description);
      Assert.AreEqual(0, _model.RSSFile.Items.Count);
    }

    [Test()]
    public void SaveCurrentFileModelHasFilename() {
      _model.RSSFile = GetHardCodedData();
      _model.FileName = "fakefilename.xml";
      _model.Modified = true;

      using (_mocks.Record()) {
        _mockPersister.Save(_model.RSSFile, _model.FileName);
        _mockView.UpdateView("RSSEdit Unit Tests", _model.RSSFile.Items);
      }

      using (_mocks.Playback()) {
        _presenter = new AppMainPresenter(_model, _mockView, _mockPersister);
        saveFileEventRaiser.Raise(null, null);
      }

      Assert.IsFalse(_model.Modified);
    }

    [Test()]
    public void SaveCurrentFileModelFilenameEmpty() {
      _model.RSSFile = GetHardCodedData();
      _model.FileName = "";
      _model.Modified = true;

      using (_mocks.Record()) {
        Expect.Call(_mockView.GetSaveFileName()).Return("fakefilename.xml");
        _mockPersister.Save(_model.RSSFile, "fakefilename.xml");
        _mockView.UpdateView("RSSEdit Unit Tests", _model.RSSFile.Items);
      }

      using (_mocks.Playback()) {
        _presenter = new AppMainPresenter(_model, _mockView, _mockPersister);
        saveFileEventRaiser.Raise(null, null);
      }

      Assert.IsFalse(_model.Modified);
      Assert.AreEqual("fakefilename.xml", _model.FileName);
    }

    [Test()]
    public void SaveCurrentFileEmptyFilenameReturned() {
      _model.RSSFile = GetHardCodedData();
      _model.FileName = "";
      _model.Modified = true;

      using (_mocks.Record()) {
        Expect.Call(_mockView.GetSaveFileName()).Return("");
      }

      using (_mocks.Playback()) {
        _presenter = new AppMainPresenter(_model, _mockView, _mockPersister);
        saveFileEventRaiser.Raise(null, null);
      }

      Assert.IsTrue(_model.Modified);
      Assert.AreEqual("", _model.FileName);
    }

    [Test()]
    public void SaveFileAs() {
      _model.RSSFile = GetHardCodedData();
      _model.FileName = "";
      _model.Modified = true;

      using (_mocks.Record()) {
        Expect.Call(_mockView.GetSaveFileName()).Return("fakefilename.xml");
        _mockPersister.Save(_model.RSSFile, "fakefilename.xml");
        _mockView.UpdateView("RSSEdit Unit Tests", _model.RSSFile.Items);
      }

      using (_mocks.Playback()) {
        _presenter = new AppMainPresenter(_model, _mockView, _mockPersister);
        saveFileAsEventRaiser.Raise(null, null);
      }

      Assert.IsFalse(_model.Modified);
      Assert.AreEqual("fakefilename.xml", _model.FileName);
    }

    [Test()]
    public void SaveFileAsEmptyFilenameReturned() {
      _model.RSSFile = GetHardCodedData();
      _model.FileName = "";
      _model.Modified = true;

      using (_mocks.Record()) {
        Expect.Call(_mockView.GetSaveFileName()).Return("");
      }

      using (_mocks.Playback()) {
        _presenter = new AppMainPresenter(_model, _mockView, _mockPersister);
        saveFileAsEventRaiser.Raise(null, null);
      }

      Assert.IsTrue(_model.Modified);
      Assert.AreEqual("", _model.FileName);
    }

    [Test()]
    public void EditFilePropertiesNoChanges() {
      _eventHandled = false;

      using (_mocks.Record()) {
      }

      using (_mocks.Playback()) {
        _presenter = new AppMainPresenter(_model, _mockView, _mockPersister);
        _presenter.EditFileProperties += new EditItemPropertiesEventHandler(this.Presenter_EditFilePropertiesNoChangesMade);
        editPropertiesEventRaiser.Raise(null, null);
      }

      Assert.IsTrue(_eventHandled);
    }

    [Test()]
    public void EditFilePropertiesChangesMade() {
      _eventHandled = false;

      using (_mocks.Record()) {
        _mockView.UpdateView("", _model.RSSFile.Items);
      }

      using (_mocks.Playback()) {
        _presenter = new AppMainPresenter(_model, _mockView, _mockPersister);
        _presenter.EditFileProperties += new EditItemPropertiesEventHandler(this.Presenter_EditFilePropertiesChangesMade);
        editPropertiesEventRaiser.Raise(null, null);
      }

      Assert.IsTrue(_eventHandled);
    }

    [Test()]
    public void ExitAppUninitializedModel() {
      using (_mocks.Record()) {
      }

      using (_mocks.Playback()) {
        _presenter = new AppMainPresenter(_model, _mockView, _mockPersister);
        _presenter.ExitApplication += new CancelEventHandler(this.Presenter_ExitApplicationEventHandler);
        exitAppEventRaiser.Raise(null, new CancelEventArgs());
      }

      Assert.IsTrue(_eventHandled);
    }

    [Test()]
    public void ExitAppUnmodifiedModel() {
      _model.FileName = "donotcare.xml";
      _model.Modified = false;

      using (_mocks.Record()) {
      }

      using (_mocks.Playback()) {
        _presenter = new AppMainPresenter(_model, _mockView, _mockPersister);
        _presenter.ExitApplication += new CancelEventHandler(this.Presenter_ExitApplicationEventHandler);
        exitAppEventRaiser.Raise(null, new CancelEventArgs());
      }

      Assert.IsTrue(_eventHandled);
    }

    [Test()]
    public void ExitAppModifiedModelSave() {
      _model.RSSFile = GetHardCodedData();
      _model.FileName = "fakefilename.xml";
      _model.Modified = true;

      using (_mocks.Record()) {
        Expect.Call(_mockView.AskQuestion(null)).IgnoreArguments().Return(QuestionResult.Yes);
        _mockPersister.Save(_model.RSSFile, _model.FileName);
      }

      using (_mocks.Playback()) {
        _presenter = new AppMainPresenter(_model, _mockView, _mockPersister);
        _presenter.ExitApplication += new CancelEventHandler(this.Presenter_ExitApplicationEventHandler);
        exitAppEventRaiser.Raise(null, new CancelEventArgs());
      }

      Assert.IsTrue(_eventHandled);
    }

    [Test()]
    public void ExitAppModifiedModelNoSave() {
      _model.RSSFile = GetHardCodedData();
      _model.FileName = "fakefilename.xml";
      _model.Modified = true;

      using (_mocks.Record()) {
        Expect.Call(_mockView.AskQuestion(null)).IgnoreArguments().Return(QuestionResult.No);
      }

      using (_mocks.Playback()) {
        _presenter = new AppMainPresenter(_model, _mockView, _mockPersister);
        _presenter.ExitApplication += new CancelEventHandler(this.Presenter_ExitApplicationEventHandler);
        exitAppEventRaiser.Raise(null, new CancelEventArgs());
      }

      Assert.IsTrue(_eventHandled);
    }

    [Test()]
    public void ExitAppModifiedModelCancel() {
      _model.RSSFile = GetHardCodedData();
      _model.FileName = "fakefilename.xml";
      _model.Modified = true;
      CancelEventArgs args = new CancelEventArgs(false);

      using (_mocks.Record()) {
        Expect.Call(_mockView.AskQuestion(null)).IgnoreArguments().Return(QuestionResult.Cancel);
      }

      using (_mocks.Playback()) {
        _presenter = new AppMainPresenter(_model, _mockView, _mockPersister);
        _presenter.ExitApplication += new CancelEventHandler(this.Presenter_ExitApplicationEventHandler);
        exitAppEventRaiser.Raise(null, args);
      }

      Assert.IsFalse(_eventHandled);
      Assert.IsTrue(args.Cancel);
    }

    [Test()]
    public void ShowApplicationInformation() {
      _eventHandled = false;

      using (_mocks.Record()) {
      }

      using (_mocks.Playback()) {
        _presenter = new AppMainPresenter(_model, _mockView, _mockPersister);
        _presenter.ShowApplicationInformation += new EventHandler(this.Presenter_DefaultEventHandler);
        showAppInfoEventRaiser.Raise(null, null);
      }

      Assert.IsTrue(_eventHandled);
    }

    private RSSFile GetHardCodedData() {
      RSSFile rssFile = new RSSFile();
      rssFile.Title = "RSSEdit Unit Tests";
      rssFile.Link = "http://localhost";
      rssFile.Description = "Testing";
      rssFile.Items.Add(new RSSItem("Item 1", "http://localhost/item1", "This is item 1"));
      return rssFile;
    }

    private void Presenter_DefaultEventHandler(object sender, EventArgs e) {
      _eventHandled = true;
    }

    private void Presenter_ExitApplicationEventHandler(object sender, CancelEventArgs e) {
      _eventHandled = true;
    }

    private void Presenter_EditFilePropertiesNoChangesMade(EditItemPropertiesEventArgs e) {
      _eventHandled = true;
      e.ItemChanged = false;
    }

    private void Presenter_EditFilePropertiesChangesMade(EditItemPropertiesEventArgs e) {
      _eventHandled = true;
      e.ItemChanged = true;
    }

    private void Presenter_EditFileProperties_WithActualChanges(EditItemPropertiesEventArgs e) {
      _eventHandled = true;
      e.ItemChanged = true;

      e.EditItem.Title = "This is a new title";
      e.EditItem.Link = "http://127.0.0.1/NewLink";
      e.EditItem.Description = "This is some new descriptive text";
    }
  }
}
