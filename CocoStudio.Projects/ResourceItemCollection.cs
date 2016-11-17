// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.ResourceItemCollection
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

namespace CocoStudio.Projects
{
  public class ResourceItemCollection : ItemCollection<ResourceItem>
  {
    private ResourceItem parentItem;

    private ResourceItemCollection()
    {
    }

    public ResourceItemCollection(ResourceItem parentItem)
    {
      this.parentItem = parentItem;
    }

    protected override void OnAdd(ResourceItem item)
    {
      item.Parent = this.parentItem;
    }

    protected override void OnRemove(ResourceItem item)
    {
      item.Parent = (ResourceItem) null;
    }
  }
}
