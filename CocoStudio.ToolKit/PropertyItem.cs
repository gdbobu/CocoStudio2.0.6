// Decompiled with JetBrains decompiler
// Type: CocoStudio.ToolKit.PropertyItem
// Assembly: CocoStudio.ToolKit, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DF66ED6-34A9-42A1-B332-161EEDB05F29
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ToolKit.dll

using CocoStudio.Model;
using CocoStudio.UndoManager;
using Gtk;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace CocoStudio.ToolKit
{
  public class PropertyItem
  {
    private int instanceCount = 1;
    private Widget widgetDate;
    private PropertyInfo propertyData;
    private object instance;
    private string categroy;
    private string displayName;
    private int? propertyOrder;
    private Type controlType;
    private bool isBrowsable;
    private EditorAttribute editor;
    private PropertyDescriptor propertyDescriptor;
    private DefaultValueAttribute defaultValue;

    public Widget WidgetDate
    {
      get
      {
        return this.widgetDate;
      }
      set
      {
        this.widgetDate = value;
      }
    }

    public bool IsEnable { get; set; }

    public PropertyInfo PropertyData
    {
      get
      {
        return this.propertyData;
      }
      set
      {
        this.propertyData = value;
      }
    }

    public object Instance
    {
      get
      {
        return this.instance;
      }
      set
      {
        this.instance = value;
      }
    }

    public List<object> InstanceList { get; set; }

    public int InstanceCount
    {
      get
      {
        return this.instanceCount;
      }
      set
      {
        this.instanceCount = value;
      }
    }

    public string Calegory
    {
      get
      {
        return this.categroy;
      }
      set
      {
        this.categroy = value;
      }
    }

    public string DiaplayName
    {
      get
      {
        return this.displayName;
      }
      set
      {
        this.displayName = value;
      }
    }

    public int? PropertyOrder
    {
      get
      {
        return this.propertyOrder;
      }
      set
      {
        this.propertyOrder = value;
      }
    }

    public Type ControlType
    {
      get
      {
        return this.controlType;
      }
      set
      {
        this.controlType = value;
      }
    }

    public bool IsBrowsable
    {
      get
      {
        return this.isBrowsable;
      }
      set
      {
        this.isBrowsable = value;
      }
    }

    public EditorAttribute Editor
    {
      get
      {
        return this.editor;
      }
      set
      {
        this.editor = value;
      }
    }

    public PropertyDescriptor PropertyDescriptor
    {
      get
      {
        return this.propertyDescriptor;
      }
      set
      {
        this.propertyDescriptor = value;
      }
    }

    public DefaultValueAttribute DefaultValueDescriptor
    {
      get
      {
        return this.defaultValue;
      }
      set
      {
        this.defaultValue = value;
      }
    }

    public ValueRangeAttribute ValueRangeDescriptor { get; set; }

    public ResourceFilterAttribute ResourceFilterDescriptor { get; set; }

    public System.Action Action { get; set; }

    public ITypeEditor TypeEditor { get; set; }

    public bool IsSpirt { get; set; }

    public int CatagoryGroup { get; set; }

    public void SetValue(object obj, object value, object[] index)
    {
      if (this.InstanceList != null)
      {
        using (CompositeTask.Run("SetValue"))
        {
          for (int index1 = this.InstanceList.Count - 1; index1 >= 0; --index1)
            this.propertyData.SetValue(this.InstanceList[index1], value, index);
        }
      }
      else
        this.propertyData.SetValue(this.Instance, value, index);
    }

    public void SetValue(string propertyDataName, object value, object[] index)
    {
      if (this.InstanceList == null)
        return;
      using (CompositeTask.Run("SetValue"))
      {
        for (int index1 = this.InstanceList.Count - 1; index1 >= 0; --index1)
          this.InstanceList[index1].GetType().GetProperty(propertyDataName).SetValue(this.InstanceList[index1], value, index);
      }
    }
  }
}
