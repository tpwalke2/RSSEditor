using System.Collections.Generic;

namespace Avanteware.RSSEdit {
  public class RSSFile : IRSSFile {
    private RSSItem _data = new RSSItem();
    private IList<IRSSItem> _items;

    public RSSFile() {
      Title = "";
      Link = "";
      Description = "";
      _items = new List<IRSSItem>();
    }

    public RSSFile(string title, string link, string desc, IList<IRSSItem> items) {
      Title = title;
      Link = link;
      Description = desc;
      Items = items;
    }

    public string Title {
      get {
        return _data.Title;
      }
      set {
        _data.Title = value;
      }
    }

    public string Link {
      get {
        return _data.Link;
      }
      set {
        _data.Link = value;
      }
    }

    public string Description {
      get {
        return _data.Description;
      }
      set {
        _data.Description = value;
      }
    }

    public IList<IRSSItem> Items {
      get {
        return _items;
      }
      set {
        _items = value;
      }
    }
  }
}
