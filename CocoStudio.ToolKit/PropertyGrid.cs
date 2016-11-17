// Decompiled with JetBrains decompiler
// Type: CocoStudio.ToolKit.PropertyGrid
// Assembly: CocoStudio.ToolKit, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DF66ED6-34A9-42A1-B332-161EEDB05F29
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ToolKit.dll

using CocoStudio.Model;
using CocoStudio.UndoManager;
using Gdk;
using Gtk;
using Modules.Communal.MultiLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace CocoStudio.ToolKit
{
  public class PropertyGrid : EventBox
  {
    private Table _propertyTable = new Table(3U, 1U, false);
    private CompactScrolledWindow _sw = new CompactScrolledWindow();
    private int widthRequest = 100;
    private int _selectTab = 0;
    private EditorManager _editorManager;
    private GeneralGrid _generalGrid;
    private GeneralTitle _titleTable;
    private PropertyGridExpand _expand;
    private List<PropertyItem> _property;
    private Gtk.Container container;
    private bool isRootNode;
    private object currentObject;

    public object CurrentObject
    {
      get
      {
        return this.currentObject;
      }
      set
      {
        this.currentObject = value;
      }
    }

    public PropertyGrid()
      : this(new EditorManager())
    {
      this.WidgetFlags |= WidgetFlags.AppPaintable;
      this.Events |= EventMask.PointerMotionMask;
    }

    public PropertyGrid(EditorManager manager)
    {
      this._editorManager = manager;
      this._expand = new PropertyGridExpand(this._editorManager, this);
      this._sw.HScrollbar.Visible = true;
      this._sw.VScrollbar.Visible = true;
      this.container = (Gtk.Container) new EventBox();
      this._sw.AddWithViewport((Widget) this.container);
      this.container.Name = "CocoStudio.ToolKit.PropertyGrid.EventBox";
      this._sw.Name = "CocoStudio.ToolKit.PropertyGrid.CompactScrolledWindow";
      this.Add((Widget) this._propertyTable);
    }

    protected override bool OnButtonPressEvent(EventButton evnt)
    {
      this.CanFocus = true;
      this.HasFocus = true;
      this.HasFocus = false;
      this.CanFocus = false;
      return base.OnButtonPressEvent(evnt);
    }

    public void SetCurrentObject(IEnumerable<object> obj, bool isEnable = true, bool isRootNode = false, string rootType = "")
    {
      this.isRootNode = isRootNode;
      this.currentObject = (object) obj;
      if (this._property != null)
      {
        foreach (PropertyItem propertyItem in this._property)
        {
          if (propertyItem != null && propertyItem.TypeEditor != null)
            propertyItem.TypeEditor.EditorDispose();
        }
      }
      foreach (Widget child in this.container.Children)
        this.container.Remove(child);
      foreach (Widget child in this._propertyTable.Children)
        this._propertyTable.Remove(child);
      if (this._property == null)
        this._property = new List<PropertyItem>();
      this._property.Clear();
      if (obj == null)
        return;
      List<object> source = new List<object>();
      foreach (object obj1 in obj)
      {
        object item = obj1;
        if (source.FirstOrDefault<object>((Func<object, bool>) (w => w.GetType().Name == item.GetType().Name)) == null)
          source.Add(item);
      }
      if (source.Count<object>() == 0)
        return;
      PropertyDescriptorCollection propertyDescriptors1 = PropertyGridUtilities.GetPropertyDescriptors(this.currentObject = source[0]);
      List<PropertyDescriptor> propertyDescriptorList = new List<PropertyDescriptor>();
      foreach (PropertyDescriptor propertyDescriptor in propertyDescriptors1)
        propertyDescriptorList.Add(propertyDescriptor);
      for (int index1 = 1; index1 <= source.Count - 1; ++index1)
      {
        PropertyDescriptorCollection propertyDescriptors2 = PropertyGridUtilities.GetPropertyDescriptors(source[index1]);
        for (int index2 = propertyDescriptorList.Count - 1; index2 >= 0; --index2)
        {
          PropertyDescriptor propertyDescriptor1 = propertyDescriptorList[index2];
          if (!propertyDescriptors2.Contains(propertyDescriptor1))
          {
            propertyDescriptorList.RemoveAt(index2);
          }
          else
          {
            PropertyDescriptor propertyDescriptor2 = propertyDescriptors2.Find(propertyDescriptor1.Name, true);
            if (propertyDescriptor2 != null && (propertyDescriptor2.Attributes.OfType<BrowsableAttribute>().FirstOrDefault<BrowsableAttribute>() == null || !propertyDescriptor2.Attributes.OfType<BrowsableAttribute>().FirstOrDefault<BrowsableAttribute>().Browsable))
              propertyDescriptorList.RemoveAt(index2);
          }
        }
      }
      ITransform currentObject = this.currentObject as ITransform;
      foreach (PropertyDescriptor property in propertyDescriptorList)
      {
        if (property.Attributes.Contains((Attribute) new UndoPropertyAttribute()) || !string.IsNullOrEmpty(property.Category))
        {
          PropertyItem propertyItem = PropertyGridUtilities.CreatePropertyItem(property, obj.LastOrDefault<object>());
          if (propertyItem != null)
          {
            propertyItem.IsEnable = isEnable;
            propertyItem.InstanceList = obj.ToList<object>();
            propertyItem.InstanceCount = obj.Count<object>();
            if (obj.Count<object>() <= 1 || !(propertyItem.Calegory != "Group_Routine"))
              this._property.Add(propertyItem);
          }
        }
      }
      int type = this._selectTab;
      if (this.currentObject is IPropertyTitle)
      {
        this._generalGrid = new GeneralGrid(new List<string>()
        {
          LanguageInfo.BasicProperty,
          LanguageInfo.AdvancedProperty
        }, 0, this._selectTab);
        this._generalGrid.TabChanged += new EventHandler<TabEventArgs>(this._generalGrid_TabChanged);
        this._propertyTable.Attach((Widget) this._generalGrid, 0U, 1U, 0U, 1U, AttachOptions.Expand | AttachOptions.Fill, AttachOptions.Fill, 1U, 0U);
        this._generalGrid.Show();
        this._titleTable = new GeneralTitle(this._editorManager);
        this._propertyTable.Attach((Widget) this._titleTable.hBox, 0U, 1U, 1U, 2U, AttachOptions.Expand | AttachOptions.Fill, AttachOptions.Fill, 1U, 0U);
        this._titleTable.hBox.Show();
        if (this.currentObject is IPropertyTitle)
          this._titleTable.SetImage(obj.Count<object>() == 1 ? this.currentObject : (object) null, obj.Count<object>(), rootType);
        List<PropertyItem> list = this._property.Where<PropertyItem>((Func<PropertyItem, bool>) (w => w.DiaplayName == "Display_Name" || w.DiaplayName == "Display_Target")).ToList<PropertyItem>();
        if (list != null)
          this._titleTable.SetControl(list);
        if (list != null)
          list.ForEach((System.Action<PropertyItem>) (w => this._property.Remove(w)));
        PropertyItem propertyItem = this._property.FirstOrDefault<PropertyItem>((Func<PropertyItem, bool>) (w => w.DiaplayName == "CallBack_ClassName"));
        if (propertyItem != null)
        {
          if (isRootNode)
          {
            this._property.Clear();
            this._property.Add(propertyItem);
          }
          else
            this._property.Remove(propertyItem);
        }
      }
      else
        type = 0;
      this.AddTable(type);
    }

    private void _generalGrid_TabChanged(object sender, TabEventArgs e)
    {
      if (this._property != null)
      {
        foreach (PropertyItem propertyItem in this._property)
        {
          if (propertyItem != null && propertyItem.TypeEditor != null)
            propertyItem.TypeEditor.EditorDispose();
        }
      }
      this.container.Remove((Widget) this._expand.ExpandTable);
      this._selectTab = e.TabType;
      this.AddTable(this._selectTab);
    }

    private void AddTable(int type = 0)
    {
      this._expand.Populate(this.currentObject, this._property, type, (object) null);
      this.container.Add((Widget) this._expand.ExpandTable);
      this._expand.ExpandTable.Show();
      this._propertyTable.Attach((Widget) this._sw, 0U, 1U, 2U, 3U, AttachOptions.Expand | AttachOptions.Fill, AttachOptions.Expand | AttachOptions.Fill, 0U, 0U);
      this.container.Show();
      this._sw.Show();
      this._propertyTable.Show();
      this.widthRequest = 100;
    }

    public void RefreshData()
    {
      if (this._property == null || this.currentObject == null)
        return;
      foreach (PropertyItem propertyItem in this._property)
      {
        if (propertyItem.TypeEditor != null)
          propertyItem.TypeEditor.RefreshData();
      }
    }
  }
}
