// Decompiled with JetBrains decompiler
// Type: CocoStudio.UserStatistics.BaseUserStatistics
// Assembly: CocoStudio.UserStatistics, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8836CE71-EF24-435F-B92F-7A743482F0F7
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UserStatistics.dll

using System;

namespace CocoStudio.UserStatistics
{
  public class BaseUserStatistics : IUserStatistics
  {
    protected double m_time = 0.0;
    private EditorInfo editorInfo;

    public EditorInfo EditorInfo
    {
      get
      {
        return this.editorInfo;
      }
      set
      {
        this.editorInfo = value;
        this.Init();
      }
    }

    protected BaseUserStatistics()
    {
    }

    private void Init()
    {
      try
      {
        this.OnInit();
      }
      catch (Exception ex)
      {
      }
    }

    protected virtual void OnExit()
    {
      this.m_time = (double) Environment.TickCount - this.m_time;
    }

    protected virtual void OnInit()
    {
      this.m_time = (double) Environment.TickCount;
    }

    protected bool IsStartFromLaunch()
    {
      string[] commandLineArgs = Environment.GetCommandLineArgs();
      return commandLineArgs != null && commandLineArgs.Length > 0 && commandLineArgs[0].Contains("Start By Launch");
    }

    public void Exit()
    {
      this.OnExit();
    }

    public virtual void ExitAll()
    {
    }

    public virtual void UnHandledException(Exception ex)
    {
    }
  }
}
