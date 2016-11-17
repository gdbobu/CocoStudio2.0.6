// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Event.SelectedObjectsChangeEventArgs
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using System.Collections.ObjectModel;

namespace CocoStudio.Model.Event
{
  public class SelectedObjectsChangeEventArgs
  {
    public ReadOnlyCollection<object> SelectedObject { get; private set; }

    public bool Handled { get; set; }

    public SelectedObjectsChangeEventArgs(ReadOnlyCollection<object> selectedObject)
    {
      this.SelectedObject = selectedObject;
    }
  }
}
