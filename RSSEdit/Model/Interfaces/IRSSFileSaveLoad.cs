using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Avanteware.RSSEdit {
  public interface IRSSFileSaveLoad {
    void Save(IRSSFile rssFile, string filename);
    RSSFile Load(string filename);
  }
}
