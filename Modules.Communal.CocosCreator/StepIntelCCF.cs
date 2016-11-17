// Decompiled with JetBrains decompiler
// Type: Modules.Communal.CocosCreator.StepIntelCCF
// Assembly: Modules.Communal.CocosCreator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70C77DE5-8380-4243-AAEF-73AA753A2D70
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.CocosCreator.dll

using CocoStudio.Basic;
using System;
using System.IO;

namespace Modules.Communal.CocosCreator
{
  internal class StepIntelCCF : CreateStep
  {
    protected override bool OnRun(CreateParams prms)
    {
      this.SendOutputInfo("Copy Intel CCF sample files");
      string srcPath = Path.Combine(Option.SamplesFolder, "Third_Party", "ccfSample");
      string str1 = Path.Combine(prms.Directory, prms.ProjName, "ccfSample");
      CreateHelper.CopyFolder(srcPath, str1, this.Monitor);
      bool flag = false;
      try
      {
        int num = prms.EngineInfo.VersionText.IndexOf('3');
        if (Convert.ToInt32(prms.EngineInfo.VersionText.Substring(num + 2, 1)) >= 2)
          flag = true;
      }
      catch
      {
        flag = false;
      }
      if (flag)
      {
        string str2 = Path.Combine(str1, "EarthWarrior3D-CSDK", "cocos2d");
        if (!Directory.Exists(str2))
          Directory.CreateDirectory(str2);
        CreateHelper.CopyFolder(prms.EngineInfo.RootPath, str2, this.Monitor);
      }
      return true;
    }

    protected override bool OnCanCreate(CreateParams prms)
    {
      if (prms.EngineInfo == null || prms.EngineInfo.MainVersion != 3 || prms.Language != EnumProjectLanguage.cpp)
        return false;
      return prms.UseCCF;
    }
  }
}
