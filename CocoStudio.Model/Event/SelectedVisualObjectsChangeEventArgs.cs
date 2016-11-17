// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Event.SelectedVisualObjectsChangeEventArgs
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Model.ViewModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace CocoStudio.Model.Event
{
  public class SelectedVisualObjectsChangeEventArgs
  {
    public ReadOnlyCollection<VisualObject> SelectedObject { get; private set; }

    public ReadOnlyCollection<VisualObject> SelectedParentObject { get; private set; }

    public string SourceName { get; set; }

    public bool Handled { get; set; }

    public bool IsDoInNow { get; set; }

    public SelectedVisualObjectsChangeEventArgs(IEnumerable<VisualObject> selectedObject, IEnumerable<VisualObject> selectedParentObject, bool isdoinnow = false)
    {
      this.SelectedObject = selectedObject.ToList<VisualObject>().AsReadOnly();
      this.SelectedParentObject = selectedParentObject.ToList<VisualObject>().AsReadOnly();
      this.IsDoInNow = isdoinnow;
    }
  }
}
