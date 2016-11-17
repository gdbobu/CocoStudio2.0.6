// Decompiled with JetBrains decompiler
// Type: Modules.Communal.CocosCreator.StepCocosV3
// Assembly: Modules.Communal.CocosCreator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70C77DE5-8380-4243-AAEF-73AA753A2D70
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.CocosCreator.dll

using CocoStudio.Basic;
using Modules.Communal.MultiLanguage;
using MonoDevelop.Core;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;

namespace Modules.Communal.CocosCreator
{
  internal class StepCocosV3 : CreateStep
  {
    private const string str_Third_Party = "Third_Party";
    private const string str_tools = "tools";
    private const string str_python = "python";
    private const string str_pythonexe = "python.exe";
    private const string str_cocos = "cocos";
    private const string str_cocospy = "cocos.py";
    private const string str_cocos2d_console = "cocos2d-console";
    private const string str_bin = "bin";
    private bool IsPythonProcessing;
    private bool IsPythonSuccess;

    protected override bool OnRun(CreateParams prms)
    {
      this.IsPythonProcessing = false;
      this.IsPythonSuccess = false;
      string path;
      if (Platform.IsMac)
      {
        string path2 = Path.Combine("tools", "cocos2d-console", "bin", "cocos");
        path = Path.Combine(prms.EngineInfo.RootPath, path2);
      }
      else
        path = Path.Combine(Option.SamplesFolder, Path.Combine("Third_Party", "python", "python.exe"));
      if (!File.Exists(path))
      {
        this.SendOutputInfo("Python exec is not exist");
        return false;
      }
      string str = this.CreateParams(prms);
      if (string.IsNullOrEmpty(str))
        return false;
      ProcessStartInfo processStartInfo = new ProcessStartInfo();
      processStartInfo.UseShellExecute = false;
      processStartInfo.Arguments = str;
      processStartInfo.FileName = path;
      processStartInfo.CreateNoWindow = true;
      processStartInfo.RedirectStandardError = true;
      processStartInfo.RedirectStandardInput = true;
      processStartInfo.RedirectStandardOutput = true;
      Process process = new Process();
      process.EnableRaisingEvents = true;
      process.StartInfo = processStartInfo;
      process.Exited += new EventHandler(this.OnProcessExited);
      process.OutputDataReceived += new DataReceivedEventHandler(this.OnOutputReceived);
      try
      {
        this.SendOutputInfo(string.Format("Based on: {0}", (object) prms.EngineInfo.VersionText));
        this.IsPythonProcessing = true;
        process.Start();
        process.BeginOutputReadLine();
        while (this.IsPythonProcessing && !this.Monitor.IsCancelled)
        {
          if (this.Monitor.IsCancelled)
          {
            if (process != null)
            {
              if (!process.HasExited)
                process.Kill();
              process.Dispose();
            }
            return false;
          }
          Thread.Sleep(100);
        }
        return this.IsPythonSuccess;
      }
      catch (Exception ex)
      {
        LogConfig.Output.Error((object) LanguageInfo.StartLauchFail, ex);
        this.SendOutputInfo("Failed to create the project");
        LogConfig.Output.Error((object) ("创建使用3.0引擎代码的项目失败：\r\n" + ex.ToString()));
        if (process != null)
        {
          if (!process.HasExited)
            process.Kill();
          process.Dispose();
        }
        this.IsPythonProcessing = false;
        this.IsPythonSuccess = false;
        return false;
      }
    }

    protected override bool OnCanCreate(CreateParams prms)
    {
      return prms.EngineInfo != null && prms.EngineInfo.MainVersion == 3;
    }

    private string CreateParams(CreateParams info)
    {
      string path = "";
      if (Platform.IsWindows)
      {
        path = Path.Combine(info.EngineInfo.RootPath, "tools", "cocos2d-console", "bin", "cocos.py");
        if (!File.Exists(path))
        {
          this.SendOutputInfo("cocos.py is not exist");
          return "";
        }
      }
      StringBuilder stringBuilder = new StringBuilder();
      if (Platform.IsMac)
        stringBuilder.Append(path);
      else
        stringBuilder.Append(string.Format("\"{0}\"", (object) path));
      stringBuilder.Append(string.Format(" new -p {0} -l {1} -d {2}", (object) info.PkgName, (object) info.Language, (object) info.Directory));
      if ((info.UseCodeIDE || info.EngineInfo.IsDefault) && info.Language != EnumProjectLanguage.cpp)
        stringBuilder.Append(" -t runtime");
      stringBuilder.Append(" " + info.ProjName);
      if (!info.UseSource)
        stringBuilder.Append(" --no-native");
      return stringBuilder.ToString();
    }

    private void OnProcessExited(object sender, EventArgs e)
    {
      this.IsPythonSuccess = (sender as Process).ExitCode == 0;
      this.IsPythonProcessing = false;
    }

    private void OnOutputReceived(object sender, DataReceivedEventArgs e)
    {
      if (string.IsNullOrEmpty(e.Data))
        return;
      this.SendOutputInfo(e.Data);
    }
  }
}
