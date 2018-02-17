using System;
using System.Collections.Generic;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Interfaces;
using Avanteware.RSSEdit;

namespace Avanteware.RSSEdit.Tests {
  [TestFixture()]
  public class EditPresenterTests {
    private MockRepository _mocks;
    private IEditView _mockView;
    private IEventRaiser selChangedEventRaiser;
    private IEventRaiser applyItemEditsEventRaiser;
    private IEventRaiser cancelItemEditsEventRaiser;
    private IEventRaiser addNewItemEventRaiser;
    private IEventRaiser removeSelectedItemEventRaiser;
    private RSSEditModel _model;
    private EditPresenter _presenter;

    [SetUp()]
    public void Setup() {
      _model = new RSSEditModel();

      _mocks = new MockRepository();
      _mockView = _mocks.DynamicMock<IEditView>();
      _mockView.SelectedItemChanged += null;
      selChangedEventRaiser = LastCall.IgnoreArguments().GetEventRaiser();
      _mockView.ApplyItemEdits += null;
      applyItemEditsEventRaiser = LastCall.IgnoreArguments().GetEventRaiser();
      _mockView.CancelItemEdits += null;
      cancelItemEditsEventRaiser = LastCall.IgnoreArguments().GetEventRaiser();
      _mockView.AddNewItem += null;
      addNewItemEventRaiser = LastCall.IgnoreArguments().GetEventRaiser();
      _mockView.RemoveSelectedItem += null;
      removeSelectedItemEventRaiser = LastCall.IgnoreArguments().GetEventRaiser();
    }

    [Test()]
    public void NoItemSelected() {
      using (_mocks.Record()) {
        Expect.Call(_mockView.SelectedItemIndex).Return(-1);
        _mockView.EditItem = null;
      }

      using (_mocks.Playback()) {
        _presenter = new EditPresenter(_model, _mockView);
        selChangedEventRaiser.Raise(null, null);
      }

      Assert.IsNull(_model.SelectedItem);
    }

    [Test()]
    public void SelectFirstItem() {
      _model.RSSFile = GetHardCodedData();
      IRSSItem item1 = _model.RSSFile.Items[0];

      using (_mocks.Record()) {
        Expect.Call(_mockView.SelectedItemIndex).Return(0);
        _mockView.EditItem = item1;
      }

      using (_mocks.Playback()) {
        _presenter = new EditPresenter(_model, _mockView);
        selChangedEventRaiser.Raise(null, null);
      }

      Assert.AreSame(item1, _model.SelectedItem);
    }

    [Test()]
    public void SelectInvalidItem() {
      _model.RSSFile = GetHardCodedData();

      using (_mocks.Record()) {
        Expect.Call(_mockView.SelectedItemIndex).Return(2).Repeat.Twice();
        _mockView.EditItem = null;
      }

      using (_mocks.Playback()) {
        _presenter = new EditPresenter(_model, _mockView);
        selChangedEventRaiser.Raise(null, null);
      }

      Assert.IsNull(_model.SelectedItem);
    }

    [Test()]
    public void ApplyItemEditsTest() {
      _model.RSSFile = GetHardCodedData();
      _model.SelectedItem = _model.RSSFile.Items[0];
      IRSSItem editedItem = new RSSItem("Item 1", "http://localhost/item1", "An article about item #1");

      using (_mocks.Record()) {
        Expect.Call(_mockView.EditItem).Return(editedItem);
        _mockView.Items = null;
        LastCall.IgnoreArguments();
      }

      using (_mocks.Playback()) {
        _presenter = new EditPresenter(_model, _mockView);
        applyItemEditsEventRaiser.Raise(null, null);
      }

      Assert.AreSame(_model.RSSFile.Items[0], _model.SelectedItem);
      Assert.AreEqual("An article about item #1", _model.SelectedItem.Description);
      Assert.IsTrue(_model.Modified);
    }

    [Test()]
    public void CancelItemEditsTest() {
      _model.RSSFile = GetHardCodedData();
      _model.SelectedItem = _model.RSSFile.Items[0];

      using (_mocks.Record()) {
        _mockView.EditItem = _model.SelectedItem;
      }

      using (_mocks.Playback()) {
        _presenter = new EditPresenter(_model, _mockView);
        cancelItemEditsEventRaiser.Raise(null, null);
      }
    }

    [Test()]
    public void AddNewItem() {
      _model.RSSFile = GetHardCodedData();
      _model.SelectedItem = _model.RSSFile.Items[0];

      using (_mocks.Record()) {
        _mockView.Items = null;
        LastCall.IgnoreArguments();
        _mockView.SelectedItemIndex = 2;
        Expect.Call(_mockView.SelectedItemIndex).Return(2).Repeat.Times(3);
        _mockView.EditItem = null;
        LastCall.IgnoreArguments();
      }

      using (_mocks.Playback()) {
        _presenter = new EditPresenter(_model, _mockView);
        addNewItemEventRaiser.Raise(null, null);
      }

      Assert.IsTrue(_model.Modified);
      Assert.AreEqual(3, _model.RSSFile.Items.Count);
      Assert.AreSame(_model.RSSFile.Items[2], _model.SelectedItem);
    }

    [Test()]
    public void RemoveItem_BadSelection() {
      _model.RSSFile = GetHardCodedData();
      _model.SelectedItem = null;

      using (_mocks.Record()) {
        _mockView.Items = null;
        LastCall.IgnoreArguments();
        Expect.Call(_mockView.SelectedItemIndex).Return(-1);
      }

      using (_mocks.Playback()) {
        _presenter = new EditPresenter(_model, _mockView);
        removeSelectedItemEventRaiser.Raise(null, null);
      }
    }

    [Test()]
    public void RemoveItem_Success() {
      _model.RSSFile = GetHardCodedData();
      _model.RSSFile.Items.Add(new RSSItem("Item 3", "http://localhost/item3", "This is item 3"));
      _model.SelectedItem = _model.RSSFile.Items[2];

      using (_mocks.Record()) {
        _mockView.Items = null;
        LastCall.IgnoreArguments();
        Expect.Call(_mockView.SelectedItemIndex).Return(2);
        _mockView.Items = null;
        LastCall.IgnoreArguments();
        _mockView.SelectedItemIndex = -1;
      }

      using (_mocks.Playback()) {
        _presenter = new EditPresenter(_model, _mockView);
        removeSelectedItemEventRaiser.Raise(null, null);
      }

      Assert.AreEqual(2, _model.RSSFile.Items.Count);
      Assert.IsNull(_model.SelectedItem);
    }

    private RSSFile GetHardCodedData() {
      RSSFile rssFile = new RSSFile();
      rssFile.Title = "RSSEdit Unit Tests";
      rssFile.Link = "http://localhost";
      rssFile.Description = "Testing";
      rssFile.Items.Add(new RSSItem("Item 1", "http://localhost/item1", "This is item 1"));
      rssFile.Items.Add(new RSSItem("Item 2", "http://localhost/item2", "This is item 2"));
      return rssFile;
    }
  }
}
