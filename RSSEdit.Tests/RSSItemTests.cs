using NUnit.Framework;

namespace Avanteware.RSSEdit.Tests {
  [TestFixture()]
  public class RSSItemTests {
    [Test()]
    public void Equals_Success_SameReference() {
      RSSItem item = new RSSItem();
      Assert.IsTrue(item.Equals(item));
    }

    [Test()]
    public void Equals_Success_SameData() {
      RSSItem item1 = new RSSItem("An item title", "http://anylink", "An item description");
      RSSItem other = new RSSItem("An item title", "http://anylink", "An item description");
      Assert.IsTrue(item1.Equals(other));
    }

    [Test()]
    public void Equals_DifferentTypes() {
      RSSItem item = new RSSItem();
      string s = "Not an RSSItem";
      Assert.IsFalse(item.Equals(s));
    }

    [Test()]
    public void Equals_Null() {
      RSSItem item = new RSSItem();
      Assert.IsFalse(item.Equals(null));
    }

    [Test()]
    public void Equals_DifferentTitle() {
      RSSItem item1 = new RSSItem("Item 1", "http://anylink", "An item description");
      RSSItem other = new RSSItem("Other Item", "http://anylink", "An item description");
      Assert.IsFalse(item1.Equals(other));
    }

    [Test()]
    public void Equals_DifferentLink() {
      RSSItem item1 = new RSSItem("An item title", "http://localhost/item1", "An item description");
      RSSItem other = new RSSItem("An item title", "http://localhost/other", "An item description");
      Assert.IsFalse(item1.Equals(other));
    }

    [Test()]
    public void Equals_DifferentDescription() {
      RSSItem item1 = new RSSItem("An item title", "http://anylink", "This is item #1");
      RSSItem other = new RSSItem("An item title", "http://anylink", "This is another item");
      Assert.IsFalse(item1.Equals(other));
    }
  }
}
