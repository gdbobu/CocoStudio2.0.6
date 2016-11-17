// Decompiled with JetBrains decompiler
// Type: Modules.Communal.CocosCreator.CreateParams
// Assembly: Modules.Communal.CocosCreator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70C77DE5-8380-4243-AAEF-73AA753A2D70
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.CocosCreator.dll

using CocoStudio.Basic;

namespace Modules.Communal.CocosCreator
{
  public class CreateParams
  {
    public string ProjName { get; private set; }

    public string Directory { get; private set; }

    public string PkgName { get; private set; }

    public CocosInfo EngineInfo { get; private set; }

    public EnumProjectLanguage Language { get; private set; }

    public bool UseCCF { get; set; }

    public bool UseX86 { get; set; }

    public ECompilerType X86Type { get; set; }

    public bool UseSource { get; set; }

    public bool UseCodeIDE { get; set; }

    public bool OpenWithCodeIDE { get; set; }

    public CreateParams(string projectName, string directory)
    {
      this.ProjName = projectName;
      this.Directory = directory;
      this.PkgName = "";
      this.EngineInfo = (CocosInfo) null;
      this.Language = EnumProjectLanguage.none;
      this.UseCCF = false;
      this.UseX86 = false;
      this.X86Type = ECompilerType.Null;
      this.UseSource = false;
      this.UseCodeIDE = false;
      this.OpenWithCodeIDE = false;
    }

    public CreateParams(string projectName, string directory, string packageName, CocosInfo engineInfo, EnumProjectLanguage language)
    {
      this.ProjName = projectName;
      this.Directory = directory;
      this.PkgName = packageName;
      this.EngineInfo = engineInfo;
      this.Language = language;
      this.UseCCF = false;
      this.UseX86 = false;
      this.X86Type = ECompilerType.Null;
      this.UseSource = true;
      this.UseCodeIDE = true;
      this.OpenWithCodeIDE = false;
    }
  }
}
