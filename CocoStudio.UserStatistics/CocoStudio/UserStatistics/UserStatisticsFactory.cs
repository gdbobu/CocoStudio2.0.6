// Decompiled with JetBrains decompiler
// Type: CocoStudio.UserStatistics.UserStatisticsFactory
// Assembly: CocoStudio.UserStatistics, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8836CE71-EF24-435F-B92F-7A743482F0F7
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UserStatistics.dll

using CocoStudio.Basic;
using GLib;
using Gtk;
using System;
using System.Collections.Generic;

namespace CocoStudio.UserStatistics
{
  public static class UserStatisticsFactory
  {
    private static List<IUserStatistics> listTracker = new List<IUserStatistics>();

    public static List<IUserStatistics> ListTracker
    {
      get
      {
        return UserStatisticsFactory.listTracker;
      }
      set
      {
        UserStatisticsFactory.listTracker = value;
      }
    }

    public static event System.Action<EventArgs> UnHandledExceptionEvent;

    static UserStatisticsFactory()
    {
      UserStatisticsFactory.ListTracker.Add((IUserStatistics) new UserStatisitcsGoogle());
      UserStatisticsFactory.ListTracker.Add((IUserStatistics) new UserStatisitcsCS());
      UserStatisticsFactory.InitUnhandledException();
    }

    public static void Start(Window mainWindow)
    {
      CocosStudioClient.SentCocosStudioClientorg();
      if (mainWindow is IWindowClosed)
        (mainWindow as IWindowClosed).Closed += new EventHandler<EventArgs>(UserStatisticsFactory.UserStatisticsFactory_Closed);
      foreach (IUserStatistics userStatistics in UserStatisticsFactory.ListTracker)
        userStatistics.EditorInfo = new EditorInfo(Option.CurrentEditorIDE.ToString(), Option.EditorVersion);
    }

    private static void UserStatisticsFactory_Closed(object sender, EventArgs e)
    {
      UserStatisticsFactory.Exit();
    }

    private static void Exit()
    {
      foreach (IUserStatistics userStatistics in UserStatisticsFactory.ListTracker)
        userStatistics.Exit();
    }

    public static void ExitAll()
    {
      foreach (IUserStatistics userStatistics in UserStatisticsFactory.ListTracker)
        userStatistics.ExitAll();
    }

    private static void InitUnhandledException()
    {
      ExceptionManager.UnhandledException += new UnhandledExceptionHandler(UserStatisticsFactory.HandleUnhandledException);
      AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UserStatisticsFactory.HandleDomainUnhandledException);
    }

    private static void HandleDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
      UserStatisticsFactory.HandledException(e.ExceptionObject as Exception);
    }

    private static void HandleUnhandledException(UnhandledExceptionArgs args)
    {
      UserStatisticsFactory.HandledException(args.ExceptionObject as Exception);
    }

    private static void HandledException(Exception ex)
    {
      if (UserStatisticsFactory.UnHandledExceptionEvent != null)
        UserStatisticsFactory.UnHandledExceptionEvent(new EventArgs());
      LogConfig.Logger.Error((object) "Unhandled exception.", ex);
      foreach (IUserStatistics userStatistics in UserStatisticsFactory.ListTracker)
        userStatistics.UnHandledException(ex);
      MessageBox.Show(ex.Message, (Window) null, "Error", MessageBoxImage.Info);
      Environment.Exit(-1);
    }
  }
}
