// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.NodeCollection
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using System;
using System.Collections.Specialized;

namespace CocoStudio.Model.ViewModel
{
  public class NodeCollection : ObjectCollection<NodeObject>
  {
    private NodeObject parentObject;

    public NodeCollection(NodeObject parentObject)
    {
      this.parentObject = parentObject;
    }

    protected override void OnInsert(int index, NodeObject item)
    {
      if (item == null)
        throw new ArgumentException("Child should not be null.");
      this.parentObject.InsertChild(index, item);
      item.Parent = this.parentObject;
      item.AfterAdded();
      item.BindingRecorder((string) null);
      item.AncestorObjectChanged((BaseObject) item, NotifyCollectionChangedAction.Add);
    }

    protected override void OnAdd(NodeObject item)
    {
      if (item == null)
        throw new ArgumentException("Child should not be null.");
      this.parentObject.InsertChild(this.Count, item);
      item.Parent = this.parentObject;
      item.AfterAdded();
      item.BindingRecorder((string) null);
      item.AncestorObjectChanged((BaseObject) item, NotifyCollectionChangedAction.Add);
    }

    protected override void OnRemove(NodeObject item)
    {
      if (item == null)
        throw new ArgumentException("Child should not be null.");
      item.BeforeRemoved();
      item.AncestorObjectChanged((BaseObject) item, NotifyCollectionChangedAction.Remove);
      item.Parent = (NodeObject) null;
      this.parentObject.RemoveChild(item);
    }
  }
}
