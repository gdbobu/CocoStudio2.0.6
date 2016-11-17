// Decompiled with JetBrains decompiler
// Type: Modules.Communal.CocosCreator.CreateStep
// Assembly: Modules.Communal.CocosCreator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70C77DE5-8380-4243-AAEF-73AA753A2D70
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.CocosCreator.dll

using CocoStudio.Basic;
using System;

namespace Modules.Communal.CocosCreator
{
  internal class CreateStep : ICreateStep
  {
    protected CocosCreateMonitor Monitor;

    public bool Run(CreateParams prms, CocosCreateMonitor monitor)
    {
      this.Monitor = monitor;
      try
      {
        return this.OnRun(prms);
      }
      catch (Exception ex)
      {
        this.SendOutputInfo("Failed to create");
        LogConfig.Logger.Error((object) ("新建项目时出错：\r\n" + ex.ToString()));
        return false;
      }
    }

    protected virtual bool OnRun(CreateParams prms)
    {
      throw new NotImplementedException();
    }

    public bool CanCreate(CreateParams prms)
    {
      return this.OnCanCreate(prms);
    }

    protected virtual bool OnCanCreate(CreateParams prms)
    {
      throw new NotImplementedException();
    }

    protected void SendOutputInfo(string info)
    {
      if (this.Monitor == null || string.IsNullOrEmpty(info))
        return;
      this.Monitor.SendInfo(info);
    }
  }
}
