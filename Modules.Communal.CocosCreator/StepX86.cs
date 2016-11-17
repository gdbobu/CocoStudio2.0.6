// Decompiled with JetBrains decompiler
// Type: Modules.Communal.CocosCreator.StepX86
// Assembly: Modules.Communal.CocosCreator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70C77DE5-8380-4243-AAEF-73AA753A2D70
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.CocosCreator.dll

using CocoStudio.Basic;
using System.IO;

namespace Modules.Communal.CocosCreator
{
  internal class StepX86 : CreateStep
  {
    protected override bool OnRun(CreateParams prms)
    {
      this.SendOutputInfo("Optimize x86 compiler");
      string path1 = "";
      string path2 = "";
      string path1_1 = Path.Combine(Option.AssemblyPath, "Publish", "AppMKFile");
      switch (prms.X86Type)
      {
        case ECompilerType.Null:
          path2 = Path.Combine(path1_1, "x86.mk");
          break;
        case ECompilerType.GCC:
          path2 = Path.Combine(path1_1, "x86GCC.mk");
          break;
        case ECompilerType.ICC:
          path2 = Path.Combine(path1_1, "x86ICC.mk");
          break;
      }
      if (prms.EngineInfo.MainVersion == 2)
        path1 = Path.Combine(prms.Directory, prms.ProjName, "projects", prms.ProjName, "proj.android", "jni", "Application.mk");
      else if (prms.EngineInfo.MainVersion == 3)
      {
        if (prms.Language == EnumProjectLanguage.cpp)
          path1 = Path.Combine(prms.Directory, prms.ProjName, "proj.android", "jni", "Application.mk");
        else
          path1 = Path.Combine(prms.Directory, prms.ProjName, "frameworks", "runtime-src", "proj.android", "jni", "Application.mk");
      }
      StreamReader streamReader = File.OpenText(path2);
      string end = streamReader.ReadToEnd();
      streamReader.Close();
      StreamWriter streamWriter = new StreamWriter(path1, true);
      streamWriter.Write("\r\n" + end);
      streamWriter.Close();
      return true;
    }

    protected override bool OnCanCreate(CreateParams prms)
    {
      if (prms.EngineInfo == null || !prms.UseSource)
        return false;
      return prms.UseX86;
    }
  }
}
