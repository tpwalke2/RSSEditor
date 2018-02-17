using System;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Interfaces;
using Avanteware.RSSEdit;

namespace Avanteware.RSSEdit.Tests {
  [TestFixture()]
  public class EditItemPresenterTests {
    private MockRepository _mocks;
    private IEditItemView _mockView;
    private IEventRaiser applyChangesEventRaiser;
    private IEventRaiser cancelChangesEventRaiser;
    private RSSEditModel _model;
    private EditItemPresenter _presenter;
    private bool _eventHandled;

    [SetUp()]
    public void Setup() {
      _mocks = new MockRepository();
      _mockView = _mocks.DynamicMock<IEditItemView>();
      _model = new RSSEditModel();
      
      _eventHandled = false;

      _mockView.ApplyItemChanges += null;
      applyChangesEventRaiser = LastCall.IgnoreArguments().GetEventRaiser();
      _mockView.CancelItemChanges += null;
      cancelChangesEventRaiser = LastCall.IgnoreArguments().GetEventRaiser();
    }

    [TearDown()]
    public void TearDown() {
      _mocks.VerifyAll();
    }

    [Test()]
    public void UpdateViewTest() {
      IRSSItem item = new RSSItem("Testing", "http://localhost/testing", "This is a test");

      using (_mocks.Record()) {
        _mockView.ItemTitle = "Testing";
        _mockView.ItemLink = "http://localhost/testing";
        _mockView.ItemDescription = "This is a test";
      }

      using (_mocks.Playback()) {
        _presenter = new EditItemPresenter(_mockView);
        _presenter.UpdateView(item);
      }
    }

    [Test()]
    public void ApplyItemChanges_NoItemInitiallyGiven() {
      using (_mocks.Record()) {
        Expect.Call(_mockView.ItemTitle).Return("");
        Expect.Call(_mockView.ItemLink).Return("");
        Expect.Call(_mockView.ItemDescription).Return("");
      }

      using (_mocks.Playback()) {
        _presenter = new EditItemPresenter(_mockView);
        applyChangesEventRaiser.Raise(null, null);
      }
    }

    [Test()]
    public void ApplyItemChanges_EventHandlerRegistered() {
      IRSSItem item = new RSSItem("Testing", "http://localhost/testing", "This is a test");

      using (_mocks.Record()) {
        _mockView.ItemTitle = "Testing";
        _mockView.ItemLink = "http://localhost/testing";
        _mockView.ItemDescription = "This is a test";
        Expect.Call(_mockView.ItemTitle).Return("Testing");
        Expect.Call(_mockView.ItemLink).Return("http://localhost/testing");
        Expect.Call(_mockView.ItemDescription).Return("This is a test");
      }

      using (_mocks.Playback()) {
        _presenter = new EditItemPresenter(_mockView);
        _presenter.UpdateView(item);
        _presenter.ApplyChanges += new ModelChangedEventHandler(this.Presenter_DefaultEventHandler);
        applyChangesEventRaiser.Raise(null, null);
      }

      Assert.IsTrue(_eventHandled);
    }

    [Test()]
    public void ApplyItemChanges_EventHandlerUnregistered() {
      IRSSItem item = new RSSItem("Testing", "http://localhost/testing", "This is a test");

      using (_mocks.Record()) {
        _mockView.ItemTitle = "Testing";
        _mockView.ItemLink = "http://localhost/testing";
        _mockView.ItemDescription = "This is a test";
        Expect.Call(_mockView.ItemTitle).Return("Testing");
        Expect.Call(_mockView.ItemLink).Return("http://localhost/testing");
        Expect.Call(_mockView.ItemDescription).Return("This is a test");
      }

      using (_mocks.Playback()) {
        _presenter = new EditItemPresenter(_mockView);
        _presenter.UpdateView(item);

        applyChangesEventRaiser.Raise(null, null);
      }

      Assert.IsFalse(_eventHandled);
    }

    [Test()]
    public void CancelItemChanges_EventHandlerRegistered() {
      using (_mocks.Record()) {
      }

      using (_mocks.Playback()) {
        _presenter = new EditItemPresenter(_mockView);
        _presenter.CancelChanges += new ModelChangedEventHandler(this.Presenter_DefaultEventHandler);
        cancelChangesEventRaiser.Raise(null, null);
      }

      Assert.IsTrue(_eventHandled);
    }

    [Test()]
    public void CancelItemChanges_EventHandlerUnregistered() {
      using (_mocks.Record()) {
      }

      using (_mocks.Playback()) {
        _presenter = new EditItemPresenter(_mockView);
        cancelChangesEventRaiser.Raise(null, null);
      }

      Assert.IsFalse(_eventHandled);
    }

    private void Presenter_DefaultEventHandler(ModelChangedEventArgs e) {
      _eventHandled = true;
    }
  }
}
