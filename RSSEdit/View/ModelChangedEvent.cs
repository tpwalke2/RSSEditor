using System;
using System.Security.Permissions;

namespace Avanteware.RSSEdit {
  [HostProtectionAttribute(SecurityAction.LinkDemand, SharedState = true)]
  public delegate void ModelChangedEventHandler(ModelChangedEventArgs e);

  public class ModelChangedEventArgs : EventArgs {
    private bool _modelChanged;

    public ModelChangedEventArgs() { }
    public ModelChangedEventArgs(bool modelChanged) {
      ModelChanged = modelChanged;
    }

    public bool ModelChanged {
      get {
        return _modelChanged;
      }
      set {
        _modelChanged = value;
      }
    }
  }
}
