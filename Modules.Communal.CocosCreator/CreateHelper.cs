// Decompiled with JetBrains decompiler
// Type: Modules.Communal.CocosCreator.CreateHelper
// Assembly: Modules.Communal.CocosCreator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70C77DE5-8380-4243-AAEF-73AA753A2D70
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.CocosCreator.dll

using CocoStudio.Basic;
using CocoStudio.Core;
using CocoStudio.Core.Events;
using System;
using System.IO;

namespace Modules.Communal.CocosCreator
{
  public class CreateHelper
  {
    private static ProjectCreator creator;

    public static IProjectCreator Creator
    {
      get
      {
        if (CreateHelper.creator == null)
          CreateHelper.creator = new ProjectCreator();
        return (IProjectCreator) CreateHelper.creator;
      }
    }

    public static void Initialize()
    {
      Services.ProjectOperations.CurrentSelectedSolutionChanged += new EventHandler<SolutionEventArgs>(CreateHelper.HandleSolutionChanged);
    }

    private static void HandleSolutionChanged(object sender, SolutionEventArgs e)
    {
      if (e.Solution == null)
        return;
      VersionHelper.SetDefaultSerializer(e.Solution);
    }

    internal static bool CopyFolder(string srcPath, string dstPath, CocosCreateMonitor monitor)
    {
      try
      {
        if (monitor.IsCancelled)
          return false;
        if (!Directory.Exists(dstPath))
          Directory.CreateDirectory(dstPath);
        string[] files = Directory.GetFiles(srcPath);
        if (files.Length > 0)
        {
          foreach (string str in files)
          {
            string destFileName = Path.Combine(dstPath, Path.GetFileName(str));
            File.Copy(str, destFileName, true);
          }
        }
        foreach (string directory in Directory.GetDirectories(srcPath))
        {
          if (monitor.IsCancelled)
            return false;
          string dstPath1 = Path.Combine(dstPath, Path.GetFileName(directory));
          if (!CreateHelper.CopyFolder(directory, dstPath1, monitor))
            return false;
        }
        return true;
      }
      catch (Exception ex)
      {
        if (monitor != null)
          monitor.SendInfo("Failed to copy file");
        LogConfig.Logger.Error((object) ("复制文件失败：\r\n" + ex.ToString()));
        return false;
      }
    }
  }
}
