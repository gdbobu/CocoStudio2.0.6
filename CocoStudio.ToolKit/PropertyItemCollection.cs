// Decompiled with JetBrains decompiler
// Type: CocoStudio.ToolKit.PropertyItemCollection
// Assembly: CocoStudio.ToolKit, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DF66ED6-34A9-42A1-B332-161EEDB05F29
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ToolKit.dll

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace CocoStudio.ToolKit
{
  public class PropertyItemCollection : ReadOnlyObservableCollection<PropertyItem>
  {
    private bool _preventNotification = false;

    public ObservableCollection<PropertyItem> EditableCollection { get; private set; }

    public PropertyItemCollection(ObservableCollection<PropertyItem> editableCollection)
      : base(editableCollection)
    {
      this.EditableCollection = editableCollection;
    }

    internal void Update(IEnumerable<PropertyItem> items)
    {
      this._preventNotification = true;
      if (items != null)
      {
        this.EditableCollection.Clear();
        foreach (PropertyItem propertyItem in items)
          this.EditableCollection.Add(propertyItem);
      }
      this._preventNotification = false;
      this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
    }

    public void GoupleBy(string name)
    {
    }

    public void SortBy(string name, ListSortDirection sortDirection)
    {
    }

    protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs args)
    {
      if (this._preventNotification)
        return;
      base.OnCollectionChanged(args);
    }
  }
}
