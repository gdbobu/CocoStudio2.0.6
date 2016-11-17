// Decompiled with JetBrains decompiler
// Type: Modules.Communal.CocosCreator.CocosProperties
// Assembly: Modules.Communal.CocosCreator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70C77DE5-8380-4243-AAEF-73AA753A2D70
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.CocosCreator.dll

using CocoStudio.Basic;
using CocoStudio.Projects;
using System.IO;

namespace Modules.Communal.CocosCreator
{
  public class CocosProperties
  {
    private Solution solution;

    public bool UseCocos
    {
      get
      {
        if (this.solution == null)
          return false;
        return this.solution.UserProperties.GetValue<bool>("publishHasCocos2dxCode", true);
      }
      set
      {
        if (this.solution == null)
          return;
        this.solution.UserProperties.SetValue<bool>("publishHasCocos2dxCode", value);
      }
    }

    public int EngineMainVersion
    {
      get
      {
        if (this.solution == null)
          return 0;
        return this.solution.UserProperties.GetValue<int>("publishCocos2dxMainVersion", 3);
      }
      set
      {
        if (this.solution == null)
          return;
        this.solution.UserProperties.SetValue<int>("publishCocos2dxMainVersion", value);
      }
    }

    public string EngineVersionText
    {
      get
      {
        if (this.solution == null)
          return string.Empty;
        return this.solution.UserProperties.GetValue<string>("publishCocos2dxVersionText", string.Empty);
      }
      set
      {
        if (this.solution == null)
          return;
        this.solution.UserProperties.SetValue<string>("publishCocos2dxVersionText", value);
      }
    }

    public EnumProjectLanguage Language
    {
      get
      {
        if (this.solution == null)
          return EnumProjectLanguage.none;
        EnumProjectLanguage enumProjectLanguage = this.solution.UserProperties.GetValue<EnumProjectLanguage>("publishCocos2dxCodeLanguage", EnumProjectLanguage.none);
        if (enumProjectLanguage == EnumProjectLanguage.none)
          enumProjectLanguage = !this.TestIsCpp() ? EnumProjectLanguage.lua : EnumProjectLanguage.cpp;
        return enumProjectLanguage;
      }
      set
      {
        if (this.solution == null)
          return;
        this.solution.UserProperties.SetValue<EnumProjectLanguage>("publishCocos2dxCodeLanguage", value);
      }
    }

    public bool UseSource
    {
      get
      {
        if (this.solution == null)
          return false;
        return this.solution.UserProperties.GetValue<bool>("publishIsUseCocosSourceCode", true);
      }
      set
      {
        if (this.solution == null)
          return;
        this.solution.UserProperties.SetValue<bool>("publishIsUseCocosSourceCode", value);
      }
    }

    public bool UseCocosCodeIDE
    {
      get
      {
        if (this.solution == null)
          return false;
        return this.solution.UserProperties.GetValue<bool>("publishIsUseCocosCodeIDE", true);
      }
      set
      {
        if (this.solution == null)
          return;
        this.solution.UserProperties.SetValue<bool>("publishIsUseCocosCodeIDE", value);
      }
    }

    public CocosProperties(Solution sln)
    {
      this.solution = sln;
    }

    public void Save()
    {
      if (this.solution == null)
        return;
      this.solution.SaveUserProperties();
    }

    private bool TestIsCpp()
    {
      return this.solution != null && !File.Exists(Path.Combine((string) this.solution.BaseDirectory, ".project"));
    }
  }
}
