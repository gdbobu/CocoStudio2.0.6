// Decompiled with JetBrains decompiler
// Type: Modules.Communal.CocosCreator.ProjectCreator
// Assembly: Modules.Communal.CocosCreator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70C77DE5-8380-4243-AAEF-73AA753A2D70
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.CocosCreator.dll

using CocoStudio.Basic;
using CocoStudio.Core;
using CocoStudio.Projects;
using System.Collections.Generic;
using System.IO;

namespace Modules.Communal.CocosCreator
{
  internal class ProjectCreator : IProjectCreator
  {
    public CocosInfo GetCocosInfo(string path = null, bool isAutoCheck = false)
    {
      return CocosInfo.CreateCustomInfo(path, isAutoCheck);
    }

    public void CreateCocosProject(CreateParams prms, CocosCreateMonitor monitor)
    {
      monitor.Start();
      if (prms == null)
      {
        monitor.SendInfo("The create params is null");
        monitor.Finish(false);
      }
      else
      {
        string path = Path.Combine(prms.Directory, prms.ProjName);
        if (Directory.Exists(path))
        {
          try
          {
            monitor.SendInfo("Delete exist files");
            new DirectoryInfo(path).Delete(true);
          }
          catch
          {
            monitor.SendInfo("Failed to delete exist files");
            monitor.Finish(false);
            return;
          }
        }
        foreach (ICreateStep createStep in new List<ICreateStep>() { (ICreateStep) new StepCocosV2(), (ICreateStep) new StepCocosV3(), (ICreateStep) new StepIntelCCF(), (ICreateStep) new StepX86() })
        {
          if (createStep.CanCreate(prms) && !createStep.Run(prms, monitor))
          {
            monitor.Finish(false);
            return;
          }
        }
        monitor.Finish(true);
      }
    }

    public void SaveStatus(CreateParams prms, Solution sln = null)
    {
      if (sln == null)
        sln = this.GetSolutionByPath(prms.Directory, prms.ProjName);
      if (sln == null)
      {
        LogConfig.Output.Error((object) "获取项目失败");
      }
      else
      {
        CocosProperties cocosProperties = new CocosProperties(sln);
        if (prms.EngineInfo != null)
        {
          cocosProperties.UseCocos = true;
          cocosProperties.Language = prms.Language;
          cocosProperties.EngineMainVersion = prms.EngineInfo.MainVersion;
          cocosProperties.EngineVersionText = prms.EngineInfo.VersionText;
          cocosProperties.UseSource = prms.UseSource;
          cocosProperties.UseCocosCodeIDE = prms.UseCodeIDE;
        }
        else
          cocosProperties.UseCocos = false;
        cocosProperties.Save();
      }
    }

    private Solution GetSolutionByPath(string directory, string name)
    {
      return Services.ProjectsService.GetWrapperSolution(Services.ProjectsService.DefaultMonitor, Path.Combine(directory, name, name + ".ccs"));
    }
  }
}
