// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.View.DefaultViewDisplayBuilder
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using CocoStudio.Core.ExtensionModel;
using CocoStudio.Projects;
using Mono.Addins;
using MonoDevelop.Core;

namespace CocoStudio.Core.View
{
  [Extension(Path = "CocoStudio/Ide/DisplayBuilder")]
  internal class DefaultViewDisplayBuilder : IViewDisplayBuilder, IDisplayBuilder
  {
    public string Name
    {
      get
      {
        return "MainRenderViewBuilder";
      }
    }

    public bool CanUseAsDefault
    {
      get
      {
        return true;
      }
    }

    public IViewContentExtend CreateContent(FilePath fileName, string mimeType, Project ownerProject)
    {
      IMainRender mainRenderContent = MainWindowPartFactory.CreateMainRenderContent();
      mainRenderContent.Project = ownerProject;
      return (IViewContentExtend) mainRenderContent;
    }

    public bool CanHandle(FilePath fileName, string mimeType, Project ownerProject)
    {
      return ownerProject.ProjectItem is GameProjectFile;
    }
  }
}
