// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.Starter
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using CocoStudio.Basic;
using CocoStudio.UserStatistics;
using Gtk;
using MonoDevelop.Core;
using MonoDevelop.Core.ProgressMonitoring;
using MonoDevelop.Ide;
using MonoDevelop.Ide.Gui;
using System;
using System.IO;

namespace CocoStudio.Core
{
    public static class Starter
    {
        public static void Initialize(EnumEditorIDE editorType, string themeName)
        {
            Starter.SetCurrentIDE(editorType);
            Platform.Initialize();
            try
            {
                GLibLogging.Log.SetLogHandler("", GLibLogging.LogLevelFlags.All, delegate(string log_domain, GLibLogging.LogLevelFlags log_level, string message)
                {
                    LogConfig.Logger.Error(message);
                });
            }
            catch (Exception exception)
            {
                LogConfig.Logger.Error("Error initialising GLib logging.", exception);
            }
            Starter.SetupTheme(themeName);
            Starter.InitApplication();
            DispatchService.Initialize();
            CocoStudio.Core.Service.Runtime.Initialize(Option.AddinConfigFolder, Option.AddinLocationFolder);
            Services.IntinalizeCompleted += new Action<EventArgs>(Starter.Services_IntinalizeCompleted);
            Starter.InitApplication();
        }

        private static void Services_IntinalizeCompleted(EventArgs obj)
        {
            UserStatisticsFactory.Start(ApplicationCurrent.MainWindow);
        }

        public static void Run()
        {
            IProgressMonitor monitor = new ConsoleProgressMonitor();
            CocoStudio.Core.View.Workbench workbench = new CocoStudio.Core.View.Workbench();
            workbench.Initialize(monitor);
            workbench.Show("Cocos Studio");
        }

        private static void InitApplication()
        {
            Application.Init();
            PlatformAdapter.Initialize();
        }

        private static void SetCurrentIDE(EnumEditorIDE editorType)
        {
            Option.SetCurrentIDE(editorType);
        }

        private static void SetupTheme(string themeName)
        {
            try
            {
                Rc.ParseString("gtk-theme-name = Default");
                string path;
                if (string.IsNullOrEmpty(themeName))
                {
                    path = "theme_clearlooks";
                }
                else
                {
                    path = themeName;
                }
                string path2;
                if (Platform.IsWindows)
                {
                    path2 = "gtkrc.win32";
                }
                else
                {
                    path2 = "gtkrc.mac";
                }
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string text = Path.Combine(baseDirectory, path);
                text = Path.Combine(text, path2);
                bool flag = true;
                if (flag)
                {
                    Environment.SetEnvironmentVariable("GTK2_RC_FILES", text);
                }
                else
                {
                    Environment.SetEnvironmentVariable("GTK2_RC_FILES", "D:\\Repository\\CocoStudio-2.0\\CocoStudioMono\\CocoStudio.Core\\theme_clearlooks\\gtkrc.win32");
                    text = "D:\\Repository\\CocoStudio-2.0\\CocoStudioMono\\CocoStudio.Core\\theme_clearlooks\\gtkrc.win32";
                }
                using (FileStream fileStream = new FileStream(text, FileMode.Open, FileAccess.Read))
                {
                    using (TextReader textReader = new StreamReader(fileStream))
                    {
                        string rc_string = textReader.ReadToEnd();
                        Rc.ParseString(rc_string);
                    }
                }
            }
            catch (Exception exception)
            {
                LogConfig.Logger.Error("Read theme file failed,", exception);
            }
        }
    }
}
