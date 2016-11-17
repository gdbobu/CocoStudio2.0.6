// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.PathDataType
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using MonoDevelop.Core;
using MonoDevelop.Core.Serialization;
using System;
using System.IO;

namespace CocoStudio.Projects
{
  public class PathDataType : PrimitiveDataType
  {
    public PathDataType(Type type)
      : base(type)
    {
      if (type != typeof (string) && type != typeof (FilePath))
        throw new InvalidOperationException("ProjectPathItemProperty can only be applied to fields of type string and FilePath");
    }

    protected override DataNode OnSerialize(SerializationContext serCtx, object mapData, object value)
    {
      FilePath filePath = value is string ? new FilePath((string) value) : (FilePath) value;
      if (filePath.IsNullOrEmpty)
        return (DataNode) null;
      FilePath directoryName = (FilePath) Path.GetDirectoryName(serCtx.BaseFile);
      string str = (string) filePath.ToRelative(directoryName);
      if ((int) Path.DirectorySeparatorChar != (int) serCtx.DirectorySeparatorChar)
        str = str.Replace(Path.DirectorySeparatorChar, serCtx.DirectorySeparatorChar);
      return (DataNode) new DataValue(this.Name, str);
    }

    protected override object OnDeserialize(SerializationContext serCtx, object mapData, DataNode data)
    {
      string relPath = ((DataValue) data).Value;
      if (!string.IsNullOrEmpty(relPath))
      {
        if ((int) Path.DirectorySeparatorChar != (int) serCtx.DirectorySeparatorChar)
          relPath = relPath.Replace(serCtx.DirectorySeparatorChar, Path.DirectorySeparatorChar);
        relPath = FileService.RelativeToAbsolutePath(Path.GetDirectoryName(serCtx.BaseFile), relPath);
      }
      if (this.ValueType == typeof (string))
        return (object) relPath;
      return (object) (FilePath) relPath;
    }
  }
}
