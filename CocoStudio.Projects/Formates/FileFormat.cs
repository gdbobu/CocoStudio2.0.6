// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.Formates.FileFormat
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using CocoStudio.Basic;
using MonoDevelop.Core;
using MonoDevelop.Core.Serialization;
using System;

namespace CocoStudio.Projects.Formates
{
  public abstract class FileFormat : IFileFormat
  {
    internal static ResourceTypeManager ResourceTypeManager { get; private set; }

    static FileFormat()
    {
      FileFormat.ResourceTypeManager = new ResourceTypeManager();
    }

    public bool CanReadFile(FilePath file, Type expectedObjectType)
    {
      try
      {
        return this.OnCanReadFile(file, expectedObjectType);
      }
      catch (Exception ex)
      {
        LogConfig.Logger.Error((object) "Check file formate failed.", ex);
        return false;
      }
    }

    public bool CanWriteFile(object obj)
    {
      return this.OnCanWriteFile(obj);
    }

    protected abstract bool OnCanWriteFile(object obj);

    protected abstract bool OnCanReadFile(FilePath file, Type expectedObjectType);

    protected static bool CheckFileSuffix(FilePath file, string suffix)
    {
      return file.Extension.Equals(suffix, StringComparison.OrdinalIgnoreCase);
    }

    public void WriteFile(FilePath file, object obj, IProgressMonitor monitor)
    {
      try
      {
        this.OnWriteFile(file, obj, monitor);
      }
      catch (Exception ex)
      {
        monitor.ReportError("Write file failed.", ex);
      }
    }

    protected virtual void OnWriteFile(FilePath file, object obj, IProgressMonitor monitor)
    {
      this.CreateSerializer(file).Serialize((string) file, obj);
    }

    public object ReadFile(FilePath file, Type expectedType, IProgressMonitor monitor)
    {
      try
      {
        return this.OnReadFile(file, expectedType, monitor);
      }
      catch (Exception ex)
      {
        monitor.ReportError("Read file failed.", ex);
        return (object) null;
      }
    }

    protected virtual object OnReadFile(FilePath file, Type expectedType, IProgressMonitor monitor)
    {
      return this.CreateSerializer(file).Deserialize((string) file, expectedType);
    }

    protected virtual XmlDataSerializer CreateSerializer(FilePath file)
    {
      return new XmlDataSerializer(new DataContext()) { SerializationContext = { DirectorySeparatorChar = '/' } };
    }
  }
}
