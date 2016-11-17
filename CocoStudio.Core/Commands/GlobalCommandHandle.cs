// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.Commands.GlobalCommandHandle
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using CocoStudio.Basic;
using CocoStudio.ControlLib.Windows;
using CocoStudio.Core.ExtensionModel;
using CocoStudio.Core.View;
using CocoStudio.Projects;
using CocoStudio.UndoManager;
using Gtk;
using Modules.Communal.MultiLanguage;
using Mono.Addins;
using MonoDevelop.Core;
using MonoDevelop.Ide.Codons;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;

namespace CocoStudio.Core.Commands
{
  public static class GlobalCommandHandle
  {
    private static IUndoManager taskService;

    public static void InitService()
    {
      GlobalCommandHandle.taskService = TaskServiceSingleton.Instance;
      GlobalCommandHandle.InitCmdBinding();
      GlobalCommandHandle.InitCmdHandleExtension();
    }

    private static void InitCmdHandleExtension()
    {
      try
      {
        ICommandHandle[] extensionObjects = AddinManager.GetExtensionObjects<ICommandHandle>();
        if (extensionObjects == null)
          return;
        foreach (ICommandHandle commandHandle in extensionObjects)
          commandHandle.Initialize();
      }
      catch (Exception ex)
      {
        LogConfig.Logger.Error((object) "InitCmdHandleExtension failed.", ex);
      }
    }

    private static void InitCmdBinding()
    {
      GlobalCommand.NewFileCmd.Update += new EventHandler<CommandUpdateArgs>(GlobalCommandHandle.HasSolution_CanExecute);
      GlobalCommand.RecentProjectCmd.Execute += new EventHandler<CommandRunArgs>(GlobalCommandHandle.RecentFileCmd_Execute);
      GlobalCommand.RecentProjectCmd.Update += new EventHandler<CommandArrayUpdateArgs>(GlobalCommandHandle.RecentFileCmd_Update);
      GlobalCommand.CloseCmd.Execute += new EventHandler<CommandRunArgs>(GlobalCommandHandle.CloseCmd_Execute);
      GlobalCommand.CloseCmd.Update += new EventHandler<CommandUpdateArgs>(GlobalCommandHandle.CloseCmd_CanExecute);
      GlobalCommand.CloseProjectCmd.Execute += new EventHandler<CommandRunArgs>(GlobalCommandHandle.CloseProjectCmd_Execute);
      GlobalCommand.CloseProjectCmd.Update += new EventHandler<CommandUpdateArgs>(GlobalCommandHandle.HasSolution_CanExecute);
      GlobalCommand.SaveCmd.Execute += new EventHandler<CommandRunArgs>(GlobalCommandHandle.SaveCmd_Execute);
      GlobalCommand.SaveCmd.Update += new EventHandler<CommandUpdateArgs>(GlobalCommandHandle.SaveCmd_CanExecute);
      GlobalCommand.SaveAllCmd.Execute += new EventHandler<CommandRunArgs>(GlobalCommandHandle.SaveAllCmd_Execute);
      GlobalCommand.SaveAllCmd.Update += new EventHandler<CommandUpdateArgs>(GlobalCommandHandle.HasSolution_CanExecute);
      GlobalCommand.SaveAsCmd.Execute += new EventHandler<CommandRunArgs>(GlobalCommandHandle.SaveAsCmd_Execute);
      GlobalCommand.SaveAsCmd.Update += new EventHandler<CommandUpdateArgs>(GlobalCommandHandle.HasSolution_CanExecute);
      GlobalCommand.ImportCmd.Update += new EventHandler<CommandUpdateArgs>(GlobalCommandHandle.HasSolution_CanExecute);
      GlobalCommand.ImportProjectCmd.Update += new EventHandler<CommandUpdateArgs>(GlobalCommandHandle.HasSolution_CanExecute);
      GlobalCommand.QuitCmd.Execute += new EventHandler<CommandRunArgs>(GlobalCommandHandle.QuitCmd_Execute);
      GlobalCommand.UndoCmd.Execute += new EventHandler<CommandRunArgs>(GlobalCommandHandle.UndoCmd_Execute);
      GlobalCommand.UndoCmd.Update += new EventHandler<CommandUpdateArgs>(GlobalCommandHandle.UndoCmd_CanExecute);
      GlobalCommand.RedoCmd.Execute += new EventHandler<CommandRunArgs>(GlobalCommandHandle.RedoCmd_Execute);
      GlobalCommand.RedoCmd.Update += new EventHandler<CommandUpdateArgs>(GlobalCommandHandle.RedoCmd_CanExecute);
      GlobalCommand.PadCmd.Execute += new EventHandler<CommandRunArgs>(GlobalCommandHandle.PadCmd_Execute);
      GlobalCommand.PadCmd.Update += new EventHandler<CommandArrayUpdateArgs>(GlobalCommandHandle.PadCmd_Update);
      GlobalCommand.StartLauncherCmd.Execute += new EventHandler<CommandRunArgs>(GlobalCommandHandle.StartLauncherCmd_Execute);
      GlobalCommand.ResetLayoutCmd.Execute += new EventHandler<CommandRunArgs>(GlobalCommandHandle.ResetLayoutCmd_Execute);
      GlobalCommand.SetChineseCmd.Execute += new EventHandler<CommandRunArgs>(GlobalCommandHandle.SetChineseCmd_Execute);
      GlobalCommand.SetEnglishCmd.Execute += new EventHandler<CommandRunArgs>(GlobalCommandHandle.SetEnglishCmd_Execute);
      GlobalCommand.SetJapaneseCmd.Execute += new EventHandler<CommandRunArgs>(GlobalCommandHandle.SetJapaneseCmd_Execute);
      GlobalCommand.SetKoreanCmd.Execute += new EventHandler<CommandRunArgs>(GlobalCommandHandle.SetKoreanCmd_Execute);
      GlobalCommand.SetSpanishCmd.Execute += new EventHandler<CommandRunArgs>(GlobalCommandHandle.SetSpanishCmd_Execute);
      GlobalCommand.SetChineseCmd.Update += new EventHandler<CommandUpdateArgs>(GlobalCommandHandle.SetChineseCmd_Update);
      GlobalCommand.SetEnglishCmd.Update += new EventHandler<CommandUpdateArgs>(GlobalCommandHandle.SetEnglishCmd_Update);
      GlobalCommand.HelpCmd.Execute += new EventHandler<CommandRunArgs>(GlobalCommandHandle.HelpCmd_Execute);
      GlobalCommand.AboutCmd.Execute += new EventHandler<CommandRunArgs>(GlobalCommandHandle.AboutCmd_Execute);
      GlobalCommand.CloseAllCmd.Execute += new EventHandler<CommandRunArgs>(GlobalCommandHandle.CloseAllCmd_Execute);
      GlobalCommand.CloseAllCmd.Update += new EventHandler<CommandUpdateArgs>(GlobalCommandHandle.HasDocument_CanExecute);
      GlobalCommand.CloseOtherCmd.Execute += new EventHandler<CommandRunArgs>(GlobalCommandHandle.CloseOtherCmd_Execute);
      GlobalCommand.CloseOtherCmd.Update += new EventHandler<CommandUpdateArgs>(GlobalCommandHandle.HasDocument_CanExecute);
      GlobalCommand.OpenDirCmd.Execute += new EventHandler<CommandRunArgs>(GlobalCommandHandle.OpenDirCmd_Execute);
      GlobalCommand.OpenDirCmd.Update += new EventHandler<CommandUpdateArgs>(GlobalCommandHandle.HasDocument_CanExecute);
    }

    private static void HasSolution_CanExecute(object sender, CommandUpdateArgs e)
    {
      GlobalCommandHandle.PropertyPad_ReleaseFocus_BeforSaveCmd();
      if (Services.ProjectOperations.CurrentSelectedSolution != null)
        e.Info.Enabled = true;
      else
        e.Info.Enabled = false;
    }

    private static void HasDocument_CanExecute(object sender, CommandUpdateArgs args)
    {
      GlobalCommandHandle.PropertyPad_ReleaseFocus_BeforSaveCmd();
      if (Services.ProjectOperations.CurrentSelectedSolution == null)
        args.Info.Enabled = false;
      else
        args.Info.Enabled = Services.Workbench.ActiveDocument != null;
    }

    private static void PropertyPad_ReleaseFocus_BeforSaveCmd()
    {
      Widget widget = Services.Workbench.Pads.PropertyPad.CurrentWidget();
      if (widget == null)
        return;
      widget.CanFocus = true;
      widget.HasFocus = true;
      widget.HasFocus = false;
      widget.CanFocus = false;
    }

    private static void RecentFileCmd_Execute(object sender, CommandRunArgs args)
    {
      ProjectItemModel dataItem = args.DataItem as ProjectItemModel;
      if (!File.Exists(dataItem.LocalPath))
      {
        MessageBox.Show("该项目不存在", (Window) null, (string) null, MessageBoxImage.Info);
        Services.RecentFileService.ReloadRecentFiles();
      }
      else
        GlobalCommand.OpenCmd.RaiseExecute((object) dataItem.LocalPath);
    }

    private static void RecentFileCmd_Update(object sender, CommandArrayUpdateArgs args)
    {
      foreach (ProjectItemModel projectItemModel in (Collection<ProjectItemModel>) new ObservableCollection<ProjectItemModel>(Services.RecentFileService.ProjectRecordList))
      {
        MenuInfo info = new MenuInfo(projectItemModel.LocalPath.Replace("_", "__"));
        args.Info.Add(info, (object) projectItemModel);
      }
    }

    private static void CloseCmd_Execute(object sender, CommandRunArgs e)
    {
      Services.Workbench.ActiveDocument.Close(false);
    }

    private static void CloseCmd_CanExecute(object sender, CommandUpdateArgs args)
    {
      if (Services.ProjectOperations.CurrentSelectedSolution != null && Services.Workbench.ActiveDocument != null)
      {
        args.Info.Text = LanguageInfo.Dialog_ButtonClose + " " + Path.GetFileName(Services.Workbench.ActiveDocument.Name);
        args.Info.Enabled = true;
      }
      else
        args.Info.Enabled = false;
    }

    private static void CloseProjectCmd_Execute(object sender, CommandRunArgs e)
    {
      Services.ProjectOperations.CloseSolution();
    }

    private static void SaveCmd_Execute(object sender, CommandRunArgs e)
    {
      Services.Workbench.ActiveDocument.Save();
    }

    private static void SaveCmd_CanExecute(object sender, CommandUpdateArgs args)
    {
      GlobalCommandHandle.PropertyPad_ReleaseFocus_BeforSaveCmd();
      if (Services.ProjectOperations.CurrentSelectedSolution != null && Services.Workbench.ActiveDocument != null)
      {
        args.Info.Text = LanguageInfo.Command_Save + " " + Path.GetFileName(Services.Workbench.ActiveDocument.Name);
        if (Services.Workbench.ActiveDocument.IsDirty)
        {
          args.Info.Enabled = true;
          return;
        }
      }
      args.Info.Enabled = false;
    }

    private static void SaveAllCmd_Execute(object sender, CommandRunArgs e)
    {
      Services.Workspace.Save(Services.ProgressMonitors.GetConsoleProgressMonitor(false));
    }

    private static void SaveAsCmd_Execute(object sender, CommandRunArgs e)
    {
      Services.Workbench.SaveAll();
      Solution selectedSolution = Services.ProjectOperations.CurrentSelectedSolution;
      FilePath itemDirectory = selectedSolution.ItemDirectory;
      FilePath fileName = (FilePath) FileChooserDialogModel.GetSaveFilesPath(new string[1]{ "*.ccs" }, LanguageInfo.Dialog_SaveAs, false, (string) selectedSolution.FileName).FileName;
      FilePath filePath = fileName.ParentDirectory.Combine(new string[1]
      {
        fileName.FileNameWithoutExtension
      });
      if (Directory.Exists((string) filePath))
      {
        MessageBox.Show(string.Format(LanguageInfo.MessageBox_Content172, (object) fileName.FileNameWithoutExtension), (Window) null, (string) null, MessageBoxImage.Info);
      }
      else
      {
        try
        {
          Directory.CreateDirectory((string) filePath);
          FileService.CopyDirectory((string) selectedSolution.BaseDirectory, (string) filePath);
          if (selectedSolution.Name != fileName.FileNameWithoutExtension)
          {
            string oldName = (string) filePath.Combine(new string[1]
            {
              selectedSolution.FileName.FileName
            });
            string newName = (string) filePath.Combine(new string[1]
            {
              fileName.FileName
            });
            FileService.RenameFile(oldName, newName);
            Services.ProjectsService.ChangeSolutionName(Services.ProgressMonitors.Default, (FilePath) newName, selectedSolution.FileName.FileNameWithoutExtension, fileName.FileNameWithoutExtension);
          }
          LogConfig.Output.Error((object) LanguageInfo.Output_SaveAsSucceed);
        }
        catch (Exception ex)
        {
          LogConfig.Output.Error((object) LanguageInfo.Output_FailedToSaveFile, ex);
        }
      }
    }

    private static void QuitCmd_Execute(object sender, CommandRunArgs e)
    {
      Services.MainWindow.Quit();
    }

    private static void UndoCmd_Execute(object sender, CommandRunArgs e)
    {
      int num = (int) GlobalCommandHandle.taskService.Undo((object) Services.Workbench.ActiveDocument);
    }

    private static void UndoCmd_CanExecute(object sender, CommandUpdateArgs e)
    {
      e.Info.Enabled = GlobalCommandHandle.taskService.CanUndo((object) Services.Workbench.ActiveDocument);
    }

    private static void RedoCmd_Execute(object sender, CommandRunArgs e)
    {
      int num = (int) GlobalCommandHandle.taskService.Redo((object) Services.Workbench.ActiveDocument);
    }

    private static void RedoCmd_CanExecute(object sender, CommandUpdateArgs e)
    {
      e.Info.Enabled = GlobalCommandHandle.taskService.CanRedo((object) Services.Workbench.ActiveDocument);
    }

    private static void ResetLayoutCmd_Execute(object sender, CommandRunArgs e)
    {
      Services.MainWindow.ResetDefaultLayout();
    }

    private static void PadCmd_Execute(object sender, CommandRunArgs args)
    {
      Pad dataItem = args.DataItem as Pad;
      PadCodon content = dataItem.Content as PadCodon;
      if (!dataItem.Visible)
      {
        Services.MainWindow.ShowPad(content);
        Services.MainWindow.BringToFront(content);
        dataItem.AutoHide = false;
      }
      else
        Services.MainWindow.HidePad(content);
    }

    private static void PadCmd_Update(object sender, CommandArrayUpdateArgs args)
    {
      PadCollection pads = Services.Workbench.Pads;
      if (pads == null)
        return;
      foreach (Pad pad in (List<Pad>) pads)
        args.Info.Add(new MenuInfo(LanguageOption.GetValueBykey(pad.Title))
        {
          Checked = pad.Visible
        }, (object) pad);
    }

    private static void StartLauncherCmd_Execute(object sender, CommandRunArgs e)
    {
      string fileName = string.Empty;
      if (Platform.IsWindows)
        fileName = Path.Combine(Option.AssemblyPath, "Cocos.exe");
      else if (Platform.IsMac)
        fileName = "/Applications/Cocos/Cocos.app/Contents/MacOS/Cocos";
      try
      {
        Process.Start(new ProcessStartInfo(fileName, "-page*2"));
      }
      catch (Exception ex)
      {
        LogConfig.Logger.Error((object) (LanguageInfo.MessageBox226_LauncherStartFailed + "\r\n" + ex.ToString()));
        MessageBox.Show(LanguageInfo.MessageBox226_LauncherStartFailed, (Window) null, (string) null, MessageBoxImage.Info);
      }
    }

    private static void HelpCmd_Execute(object sender, CommandRunArgs e)
    {
      try
      {
        Process.Start(new Uri(LanguageOption.CurrentLanguage != LanguageType.Chinese ? "http://cocostudio.org/help/2.0/english" : "http://cocostudio.org/help/2.0/chinese", UriKind.RelativeOrAbsolute).ToString());
      }
      catch (Exception ex)
      {
      }
    }

    private static void SetChineseCmd_Execute(object sender, CommandRunArgs e)
    {
      LanguageOption.SetDefaultLanguageConfig(LanguageType.Chinese);
      GlobalCommandHandle.showOkInfoDialog("语言设置成功，重启编辑器生效!", "提示", "确定");
    }

    private static void SetEnglishCmd_Execute(object sender, CommandRunArgs e)
    {
      LanguageOption.SetDefaultLanguageConfig(LanguageType.English);
      GlobalCommandHandle.showOkInfoDialog("Set successfully! Please restart Editor now!", "Prompt", "OK");
    }

    private static void SetJapaneseCmd_Execute(object sender, CommandRunArgs e)
    {
      LanguageOption.SetDefaultLanguageConfig(LanguageType.Japanese);
      GlobalCommandHandle.showOkInfoDialog("言語を設定しました。エディターを再起動してください。", "ヒント", "確認");
    }

    private static void SetKoreanCmd_Execute(object sender, CommandRunArgs e)
    {
      LanguageOption.SetDefaultLanguageConfig(LanguageType.Korean);
      GlobalCommandHandle.showOkInfoDialog("언어 설정 성공, 에디터를 재가동하면 적용됩니다!", "알림", "확인");
    }

    private static void SetSpanishCmd_Execute(object sender, CommandRunArgs e)
    {
      LanguageOption.SetDefaultLanguageConfig(LanguageType.Spanish);
      GlobalCommandHandle.showOkInfoDialog("Configuración de lenguaje correcta,el reinicio de editor es válido!", "Recordatorio", "Aceptar");
    }

    private static void showOkInfoDialog(string info, string title, string buttonString)
    {
      ButtonText btnText = new ButtonText(buttonString, MessageBoxButton.OK);
      int num = (int) MessageBox.Show(info, btnText, (Window) null, title, MessageBoxImage.Info);
    }

    private static void SetEnglishCmd_Update(object sender, CommandUpdateArgs e)
    {
      if (LanguageOption.CurrentLanguage == LanguageType.English)
        e.Info.Checked = true;
      else
        e.Info.Checked = false;
    }

    private static void SetChineseCmd_Update(object sender, CommandUpdateArgs e)
    {
      if (LanguageOption.CurrentLanguage == LanguageType.Chinese)
        e.Info.Checked = true;
      else
        e.Info.Checked = false;
    }

    private static void AboutCmd_Execute(object sender, CommandRunArgs e)
    {
      HelpDialog helpDialog = new HelpDialog();
      helpDialog.Run();
      helpDialog.Destroy();
    }

    private static void CloseAllCmd_Execute(object sender, CommandRunArgs e)
    {
      Services.Workbench.CloseAll(false);
    }

    private static void CloseOtherCmd_Execute(object sender, CommandRunArgs e)
    {
      Services.Workbench.CloseAll(true);
    }

    private static void OpenDirCmd_Execute(object sender, CommandRunArgs e)
    {
      try
      {
        string fullPath = Services.Workbench.ActiveDocument.Project.FullPath;
        if (Platform.IsWindows)
          Process.Start("Explorer", "/select," + fullPath);
        else
          Process.Start("open", "-R " + string.Format("\"{0}\"", (object) fullPath));
      }
      catch
      {
        LogConfig.Output.Error((object) LanguageInfo.Output_FailedToOpenDir);
      }
    }
  }
}
