// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.Component.SelectInfo
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using System.Collections.Generic;

namespace CocoStudio.Model.ViewModel.Component
{
  public sealed class SelectInfo
  {
    public IEnumerable<VisualObject> SelectedObjects { get; set; }

    public IEnumerable<VisualObject> SelectedParentObjects { get; set; }

    public SelectInfo(IEnumerable<VisualObject> list1, IEnumerable<VisualObject> list2)
    {
      this.SelectedObjects = list1;
      this.SelectedParentObjects = list2;
    }
  }
}
