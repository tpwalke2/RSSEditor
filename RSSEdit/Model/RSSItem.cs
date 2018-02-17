namespace Avanteware.RSSEdit {
 public class RSSItem : IRSSItem {
    private string _title;
    private string _link;
    private string _description;

    public RSSItem() {
      Title = "";
      Link = "";
      Description = "";
    }

    public RSSItem(string title, string link, string desc) {
      Title = title;
      Link = link;
      Description = desc;
    }

    public string Title {
      get {
        return _title;
      }
      set {
        _title = value;
      }
    }

    public string Link {
      get {
        return _link;
      }
      set {
        _link = value;
      }
    }

    public string Description {
      get {
        return _description;
      }
      set {
        _description = value;
      }
    }

    public override bool Equals(object obj) {
      if (obj == null || GetType() != obj.GetType()) return false;
      RSSItem other = (RSSItem)obj;
      if (!Title.Equals(other.Title)) return false;
      if (!Link.Equals(other.Link)) return false;
      if (!Description.Equals(other.Description)) return false;
      return true;
    }

    public override int GetHashCode() {
      return base.GetHashCode();
    }
  }
}
