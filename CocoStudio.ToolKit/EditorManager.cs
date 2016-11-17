// Decompiled with JetBrains decompiler
// Type: CocoStudio.ToolKit.EditorManager
// Assembly: CocoStudio.ToolKit, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DF66ED6-34A9-42A1-B332-161EEDB05F29
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ToolKit.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;

namespace CocoStudio.ToolKit
{
  public class EditorManager
  {
    private static Hashtable cellCache = new Hashtable();
    private Hashtable editors = new Hashtable();

    internal EditorManager()
    {
      this.LoadEditor(Assembly.GetAssembly(typeof (EditorManager)));
    }

    public void LoadEditor(Assembly editorAssembly)
    {
      foreach (Type type1 in editorAssembly.GetTypes())
      {
        foreach (Attribute customAttribute in Attribute.GetCustomAttributes((MemberInfo) type1))
        {
          if (customAttribute.GetType() == typeof (PropertyEditorTypeAttribute))
          {
            Type type2 = ((PropertyEditorTypeAttribute) customAttribute).Type;
            if (type1.GetInterface("ITypeEditor") != (Type) null && !this.editors.ContainsKey((object) type2))
              this.editors.Add((object) type2, (object) type1);
          }
        }
      }
    }

    public ITypeEditor GetEditor(PropertyItem pd)
    {
      ITypeEditor editor = pd.PropertyDescriptor.GetEditor(typeof (ITypeEditor)) as ITypeEditor;
      if (editor != null && pd.Editor == null)
        return editor;
      EditorAttribute attribute = this.GetAttribute<EditorAttribute>(pd.PropertyDescriptor);
      if (attribute != null)
      {
        Type type = !(pd.DiaplayName == "Display_ColorBlend") ? Type.GetType(attribute.EditorTypeName) : Type.GetType("CocoStudio.Model.Editor.ColorsEditor, CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
        type.GetConstructors();
        if (Activator.CreateInstance(type) is ITypeEditor)
        {
          object instance = Activator.CreateInstance(type, new object[1]{ (object) pd });
          pd.WidgetDate = ((ITypeEditor) instance).ResolveEditor((PropertyItem) null);
          pd.TypeEditor = (ITypeEditor) instance;
          return (ITypeEditor) null;
        }
      }
      return this.GetEditorType(pd.PropertyDescriptor, pd) ?? (ITypeEditor) new DefaultEditor();
    }

    public ITypeEditor GetEditorType(PropertyDescriptor pd, PropertyItem pi)
    {
      Type propertyType = pd.PropertyType;
      if (propertyType.IsEnum)
        return (ITypeEditor) Activator.CreateInstance((Type) this.editors[(object) typeof (Enum)], new object[1]{ (object) pi });
      if (!this.editors.Contains((object) propertyType))
        return (ITypeEditor) null;
      return (ITypeEditor) Activator.CreateInstance((Type) this.editors[(object) propertyType], new object[1]{ (object) pi });
    }

    private T GetAttribute<T>(PropertyDescriptor pd) where T : Attribute
    {
      return PropertyGridUtilities.GetAttribute<T>(pd);
    }
  }
}
