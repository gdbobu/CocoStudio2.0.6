// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.RelativeResourcePathItemProperty
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using MonoDevelop.Core.Serialization;

namespace CocoStudio.Projects
{
  public class RelativeResourcePathItemProperty : ItemPropertyAttribute
  {
    public RelativeResourcePathItemProperty()
    {
      this.SerializationDataType = typeof (RelativePathDataType);
    }

    public RelativeResourcePathItemProperty(string name)
      : base(name)
    {
      this.SerializationDataType = typeof (RelativePathDataType);
    }
  }
}
