// Decompiled with JetBrains decompiler
// Type: Modules.Communal.MutualEditor.StartInfoService
// Assembly: Modules.Communal.MutualEditor, Version=1.0.5464.34363, Culture=neutral, PublicKeyToken=null
// MVID: DFA20643-9760-4068-BB56-12AD0ACFA443
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.MutualEditor.dll

using CocoStudio.Basic;
using CocoStudio.Core;
using CocoStudio.Projects;
using GLib;
using Gtk;
using Modules.Communal.CocosCreator;
using Modules.Communal.MultiLanguage;
using Modules.Communal.StartAutoRecover;
using MonoDevelop.Core;
using System;
using System.Diagnostics;
using System.IO;

namespace Modules.Communal.MutualEditor
{
  public class StartInfoService
  {
    private static StartInfoService startInfoService = (StartInfoService) null;
    private string argsProjFilePath = string.Empty;
    private string argsSlnFilePath = string.Empty;
    private string projectName = string.Empty;
    private string projectPath = string.Empty;

    public static StartInfoService Instance
    {
      get
      {
        if (StartInfoService.startInfoService == null)
          StartInfoService.startInfoService = new StartInfoService();
        return StartInfoService.startInfoService;
      }
    }

    protected StartInfoService()
    {
      MutualCore.Init();
      this.argsProjFilePath = this.argsSlnFilePath = string.Empty;
    }

    private void OpenProject(string projFilePath)
    {
      string str = this.PreCheckFilePathLegal(projFilePath);
      projFilePath = Path.Combine(projFilePath);
      if (string.IsNullOrEmpty(str))
      {
        string ccsFilePath = this.GetCCSFilePath(projFilePath);
        string fullPath = Path.GetFullPath((string) Services.ProjectsService.CurrentSolution.FileName);
        if (string.IsNullOrEmpty(ccsFilePath))
        {
          str = string.Format("%s %s", (object) ccsFilePath, (object) LanguageInfo.MessageBox_Content100);
        }
        else
        {
          if (!fullPath.Equals(ccsFilePath))
            this.OpenSolution(ccsFilePath);
          Project resourceItem = Services.ProjectOperations.CurrentResourceGroup.FindResourceItem(projFilePath) as Project;
          if (resourceItem == null)
            str = string.Format("%s %s", (object) projFilePath, (object) LanguageInfo.MessageBox_Content100);
          else
            Services.Workbench.OpenDocument(resourceItem);
        }
      }
      if (string.IsNullOrEmpty(str))
        return;
      LogConfig.Logger.Error((object) str);
    }

    private void OpenSolution(string slnFilePath)
    {
      string str = this.PreCheckFilePathLegal(slnFilePath);
      slnFilePath = Path.Combine(slnFilePath);
      if (string.IsNullOrEmpty(str))
      {
        Solution selectedSolution = Services.ProjectOperations.CurrentSelectedSolution;
        if (selectedSolution == null)
          Services.Workspace.OpenWorkspaceItem(slnFilePath);
        else if (Path.GetFullPath((string) selectedSolution.FileName) == slnFilePath)
        {
          LogConfig.Output.Error((object) LanguageInfo.OpenSameProject);
        }
        else
        {
          if (!Services.ProjectOperations.CloseSolution())
            return;
          int num = (int) GLib.Timeout.Add(100U, (TimeoutHandler) (() =>
          {
            Services.Workspace.OpenWorkspaceItem(slnFilePath);
            return false;
          }));
        }
      }
      if (!string.IsNullOrEmpty(str))
        LogConfig.Output.Error((object) str);
    }

    private string PreCheckFilePathLegal(string prjSlnPath)
    {
      string str = string.Empty;
      if (!File.Exists(prjSlnPath))
        str = string.Format("%s %s", (object) prjSlnPath, (object) LanguageInfo.MessageBox_Content100);
      else if (RegexModel.IsHaveChinese(prjSlnPath))
        str = LanguageInfo.MessageBox212_NotChinese;
      return str;
    }

    public void OpenArgsProjSln()
    {
      string str = string.Empty;
      if (string.IsNullOrEmpty(this.projectName))
      {
        bool flag1 = !string.IsNullOrEmpty(this.argsSlnFilePath);
        bool flag2 = !string.IsNullOrEmpty(this.argsProjFilePath);
        if (flag1)
        {
          str = this.PreCheckFilePathLegal(this.argsSlnFilePath);
          if (string.IsNullOrEmpty(str))
          {
            Services.Workspace.OpenWorkspaceItem(this.argsSlnFilePath);
            if (flag2)
              StartRecoverService.ProjectFilePathByDoubleClick = this.argsProjFilePath;
          }
        }
        else
          this.HandleLatestOpenSolution();
      }
      else
      {
        Solution newSolution = Services.ProjectOperations.CreateNewSolution(this.projectPath, this.projectName);
        CreateHelper.Creator.SaveStatus(new CreateParams(this.projectName, this.projectPath), newSolution);
        Services.ProjectOperations.OpenSolution(newSolution);
        Services.ProjectOperations.CreateDefalutSceneProject(true);
      }
      if (string.IsNullOrEmpty(str))
        return;
      LogConfig.Output.Error((object) str);
    }

    public bool PreCheckArgs(string[] args)
    {
      bool flag1 = args == null || args.Length < 1;
      if (!flag1)
      {
        string[] commandLineArgs = Environment.GetCommandLineArgs();
        string str = commandLineArgs[commandLineArgs.Length - 1].Trim();
        string lower = Path.GetExtension(str).ToLower();
        if (str.Contains("*"))
        {
          string[] strArray = str.Split('*');
          this.projectName = strArray[0];
          this.projectPath = strArray[1];
        }
        else if (lower == ".csd")
        {
          this.argsProjFilePath = str;
          this.argsSlnFilePath = this.GetCCSFilePath(str);
        }
        else if (lower == ".ccs")
          this.argsSlnFilePath = str;
        bool flag2 = false;
        if (string.IsNullOrEmpty(this.projectName))
          flag2 = SolutionLockHandler.Instance.IsSolutionLocked(this.argsSlnFilePath);
        if (flag2)
        {
          MutualCore.Instance.SendMessage(this.argsSlnFilePath, Action.Show);
          MutualCore.Instance.Dispose();
        }
        else
          flag1 = true;
      }
      return flag1;
    }

    public bool PreCheckLauncher()
    {
      return SolutionLockHandler.Instance.IsFileLocked("");
    }

    public void HandleOpenSolution(string solutionFilePath)
    {
      solutionFilePath = Path.Combine(solutionFilePath);
      Solution selectedSolution = Services.ProjectOperations.CurrentSelectedSolution;
      if (selectedSolution != null && Path.GetFullPath((string) selectedSolution.FileName) == solutionFilePath)
      {
        LogConfig.Output.Error((object) LanguageInfo.OpenSameProject);
      }
      else
      {
        bool flag = SolutionLockHandler.Instance.IsSolutionLocked(solutionFilePath);
        string empty = string.Empty;
        if (flag)
        {
          MutualCore.Instance.SendMessage(solutionFilePath, Action.Show);
          LogConfig.Logger.Error((object) LanguageInfo.OpenSameProject);
        }
        else
          this.OpenSolution(solutionFilePath);
      }
    }

    private void HandleLatestOpenSolution()
    {
      try
      {
        if (Services.ProjectsService.CurrentSolution != null)
          return;
        string slnFilePath = StartRecoverService.Instance.LoadLastSolutionArgs();
        if (slnFilePath == null || SolutionLockHandler.Instance.IsSolutionLocked(slnFilePath))
          return;
        this.OpenSolution(slnFilePath);
      }
      catch (Exception ex)
      {
        LogConfig.Logger.Error((object) "Exception while handle the latest solution! ", ex);
      }
    }

    public void HandleMacStartOpen(string projOrSlnPath)
    {
      if (!Platform.IsMac)
        return;
      string str1 = this.PreCheckFilePathLegal(projOrSlnPath);
      if (string.IsNullOrEmpty(str1))
      {
        projOrSlnPath = Path.Combine(projOrSlnPath);
        string csdFilePath = projOrSlnPath;
        string str2 = projOrSlnPath;
        bool flag1 = Path.GetExtension(projOrSlnPath).ToLower() == ".csd";
        if (flag1)
          str2 = this.GetCCSFilePath(csdFilePath);
        bool flag2 = Services.ProjectsService.CurrentSolution == null;
        if (!flag2 && Services.ProjectsService.CurrentSolution.FileName == (FilePath) str2)
        {
          MutualCore.ShowCurrApplication();
          return;
        }
        if (SolutionLockHandler.Instance.IsSolutionLocked(str2))
        {
          MutualCore.Instance.SendMessage(str2, Action.Show);
          str1 = LanguageInfo.OpenSameProject;
        }
        else if (flag2)
        {
          Services.Workspace.OpenWorkspaceItem(str2);
          if (flag1)
            StartRecoverService.ProjectFilePathByDoubleClick = csdFilePath;
        }
        else
        {
          try
          {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.EnableRaisingEvents = false;
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.Arguments = projOrSlnPath;
            string str3 = Path.Combine(Option.AssemblyPath, "CocosStudio");
            processStartInfo.FileName = str3;
            process.StartInfo = processStartInfo;
            if (!process.Start())
              str1 = LanguageInfo.OpenProjectFail;
          }
          catch (Exception ex)
          {
            str1 = LanguageInfo.OpenProjectFail + ex.ToString();
          }
        }
      }
      if (string.IsNullOrEmpty(str1))
        return;
      LogConfig.Output.Error((object) str1);
    }

    private string GetCCSFilePath(string csdFilePath)
    {
      return this.DirRecursion(new DirectoryInfo(Path.GetDirectoryName(csdFilePath)));
    }

    private string DirRecursion(DirectoryInfo panrentDirInfo)
    {
      string str = string.Empty;
      if (panrentDirInfo.Name.Equals("CocosStudio", StringComparison.OrdinalIgnoreCase))
      {
        FileInfo[] files = panrentDirInfo.Parent.GetFiles("*.ccs");
        if (files.Length > 0)
          return files[0].FullName;
      }
      else
        str = this.DirRecursion(panrentDirInfo.Parent);
      return str;
    }
  }
}
