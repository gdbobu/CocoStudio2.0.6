// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.ProjectNest
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Core;
using CocoStudio.Model.DataModel;
using CocoStudio.Model.Visiter;
using CocoStudio.Projects;
using Modules.Communal.MultiLanguage;

namespace CocoStudio.Model.ViewModel
{
  public static class ProjectNest
  {
    public static string CheckNest(this Project project, Project primaryProject = null)
    {
      if (NodeType.Scene.ToString() == project.GetProjectType())
      {
        string projectType = Services.ProjectOperations.CurrentSelectedProject.GetProjectType();
        string str = "";
        if (NodeType.Scene.ToString() == projectType)
          str = LanguageInfo.NewFile_Scene;
        else if (NodeType.Layer.ToString() == projectType)
          str = LanguageInfo.NewFile_Layer;
        else if (NodeType.Node.ToString() == projectType)
          str = LanguageInfo.Display_Component_Entity;
        return str + LanguageInfo.MessageBox206_NestedSenceError;
      }
      if (primaryProject != null && project.HasReferencedProject(primaryProject))
        return string.Format(LanguageInfo.Output_ProjectRefLoop, (object) project.FileName.FileName);
      return (string) null;
    }
  }
}
