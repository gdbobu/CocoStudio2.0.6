// Decompiled with JetBrains decompiler
// Type: Modules.Communal.CocosCreator.IProjectCreator
// Assembly: Modules.Communal.CocosCreator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70C77DE5-8380-4243-AAEF-73AA753A2D70
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.CocosCreator.dll

using CocoStudio.Projects;

namespace Modules.Communal.CocosCreator
{
  public interface IProjectCreator
  {
    CocosInfo GetCocosInfo(string path = "", bool isAutoCheck = false);

    void CreateCocosProject(CreateParams prms, CocosCreateMonitor monitor);

    void SaveStatus(CreateParams prms, Solution sln = null);
  }
}
