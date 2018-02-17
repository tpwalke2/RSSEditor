using System.Collections.Generic;

namespace Avanteware.RSSEdit {
  public interface IRSSFile : IRSSItem {
    IList<IRSSItem> Items { get; set; }
  }
}
