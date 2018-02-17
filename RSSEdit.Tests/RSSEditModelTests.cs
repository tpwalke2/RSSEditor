using System;
using NUnit.Framework;

namespace Avanteware.RSSEdit.Tests {
  [TestFixture()]
  public class RSSEditModelTests {
    private RSSEditModel _model;

    [SetUp()]
    public void SetUp() {
      _model = new RSSEditModel();
    }
      
    [Test()]
    public void DifferentInstancesOfModel() {
      RSSEditModel model2 = new RSSEditModel();
      Assert.IsFalse(_model == model2);
    }

    [Test()]
    public void SelectedItemPointsToListItem() {
      _model.RSSFile = GetHardCodedData();
      _model.SelectedItem = _model.RSSFile.Items[0];

      Assert.AreSame(_model.RSSFile.Items[0], _model.SelectedItem);
    }

    [Test()]
    public void ChangingSelectedItemValueChangesListItem() {
      _model.RSSFile = GetHardCodedData();
      _model.SelectedItem = _model.RSSFile.Items[0];

      _model.SelectedItem.Title = "Item #1";

      Assert.AreEqual("Item #1", _model.RSSFile.Items[0].Title);
    }

    [Test()]
    public void ChangingSelectedItemReferenceChangesListItem() {
      _model.RSSFile = GetHardCodedData();
      _model.SelectedItem = _model.RSSFile.Items[0];
      _model.SelectedItem = new RSSItem("Item #1", "http://localhost/item1", "This is an article about item #1");

      Assert.AreSame(_model.RSSFile.Items[0], _model.SelectedItem);
    }

    [Test()]
    public void NullingSelectedItemDoesNotNullListItems() {
      _model.RSSFile = GetHardCodedData();
      _model.SelectedItem = _model.RSSFile.Items[0];
      _model.SelectedItem = null;

      Assert.IsNull(_model.SelectedItem);
      Assert.IsNotNull(_model.RSSFile.Items[0]);
      Assert.IsNotNull(_model.RSSFile.Items[1]);
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
