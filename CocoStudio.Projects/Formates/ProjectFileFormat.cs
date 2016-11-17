// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.Formates.ProjectFileFormat
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using Mono.Addins;
using MonoDevelop.Core;
using MonoDevelop.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace CocoStudio.Projects.Formates
{
  [Extension(typeof (IFileFormat))]
  public class ProjectFileFormat : FileFormat
  {
    private static HashSet<Type> projectContentList;

    static ProjectFileFormat()
    {
      ProjectFileFormat.CollectProjectContentType();
    }

    private static void CollectProjectContentType()
    {
      ProjectFileFormat.projectContentList = new HashSet<Type>();
      foreach (TypeExtensionNode extensionNode in AddinManager.GetExtensionNodes(typeof (IProjectContent)))
        ProjectFileFormat.projectContentList.Add(extensionNode.Type);
      AddinManager.AddExtensionNodeHandler(typeof (IProjectContent), new ExtensionNodeEventHandler(ProjectFileFormat.OnProjectContentExtensionChange));
    }

    private static void OnProjectContentExtensionChange(object sender, ExtensionNodeEventArgs args)
    {
      TypeExtensionNode extensionNode = args.ExtensionNode as TypeExtensionNode;
      if (ProjectFileFormat.projectContentList.Contains(extensionNode.Type))
        return;
      ProjectFileFormat.projectContentList.Add(extensionNode.Type);
    }

    protected override bool OnCanReadFile(FilePath file, Type expectedObjectType)
    {
      if (!expectedObjectType.Equals(typeof (ProjectFile)) || !FileFormat.CheckFileSuffix(file, ".csd"))
        return false;
      string localName = XElement.Load((string) file).Name.LocalName;
      return !(localName != typeof (ProjectFile).Name) || !(localName != typeof (GameProjectFile).Name);
    }

    protected override bool OnCanWriteFile(object obj)
    {
      return obj.GetType().Equals(typeof (ProjectFile)) || obj.GetType().Equals(typeof (GameProjectFile));
    }

    protected override object OnReadFile(FilePath file, Type expectedType, IProgressMonitor monitor)
    {
      Type type = Type.GetType(typeof (ProjectFile).Namespace + "." + XElement.Load((string) file).Name.LocalName);
      return base.OnReadFile(file, type, monitor);
    }

    protected override XmlDataSerializer CreateSerializer(FilePath file)
    {
      XmlDataSerializer serializer = base.CreateSerializer(file);
      foreach (Type projectContent in ProjectFileFormat.projectContentList)
        serializer.SerializationContext.Serializer.DataContext.IncludeType(projectContent);
      foreach (Type dataModel in ProjectsService.Instance.DataModelManager.GetDataModelCollection())
        serializer.SerializationContext.Serializer.DataContext.IncludeType(dataModel);
      return serializer;
    }
  }
}
