// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.Commands.GlobalCommand
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using Modules.Communal.MultiLanguage;
using MonoDevelop.Components.Commands;

namespace CocoStudio.Core.Commands
{
  public class GlobalCommand
  {
    public static CommandManager GlobalCmdManager { get; private set; }

    public static CommandProxy NewCmd { get; private set; }

    public static CommandProxy NewFileCmd { get; private set; }

    public static CommandProxy OpenCmd { get; private set; }

    public static CommandArrayProxy RecentProjectCmd { get; private set; }

    public static CommandProxy CloseCmd { get; private set; }

    public static CommandProxy CloseProjectCmd { get; private set; }

    public static CommandProxy SaveCmd { get; private set; }

    public static CommandProxy SaveAllCmd { get; private set; }

    public static CommandProxy SaveAsCmd { get; private set; }

    public static CommandProxy ImportCmd { get; private set; }

    public static CommandProxy ImportFileCmd { get; private set; }

    public static CommandProxy ImportDirCmd { get; private set; }

    public static CommandProxy ImportProjectCmd { get; private set; }

    public static CommandProxy QuitCmd { get; private set; }

    public static CommandProxy PublishCmd { get; private set; }

    public static CommandProxy PublishCodeIDECmd { get; private set; }

    public static CommandProxy PublishXcodeCmd { get; private set; }

    public static CommandProxy PublishVSCmd { get; private set; }

    public static CommandProxy UndoCmd { get; private set; }

    public static CommandProxy RedoCmd { get; private set; }

    public static CommandProxy ProjectSettingCmd { get; private set; }

    public static CommandProxy PreferencesCmd { get; private set; }

    public static CommandProxy ShowRulerCmd { get; private set; }

    public static CommandProxy HideRulerCmd { get; private set; }

    public static CommandProxy ClearGuidesCmd { get; private set; }

    public static CommandProxy LockGuidesCmd { get; private set; }

    public static CommandProxy UnLockGuidesCmd { get; private set; }

    public static CommandProxy NewGuidesCmd { get; private set; }

    public static CommandProxy OpenStartPageCmd { get; private set; }

    public static CommandProxy ResetLayoutCmd { get; private set; }

    public static CommandArrayProxy PadCmd { get; private set; }

    public static CommandProxy HelpCmd { get; private set; }

    public static CommandProxy AboutCmd { get; private set; }

    public static CommandProxy CheckUpdateCmd { get; private set; }

    public static CommandProxy StartLauncherCmd { get; private set; }

    public static CommandProxy SetChineseCmd { get; private set; }

    public static CommandProxy SetEnglishCmd { get; private set; }

    public static CommandProxy SetSpanishCmd { get; private set; }

    public static CommandProxy SetJapaneseCmd { get; private set; }

    public static CommandProxy SetKoreanCmd { get; private set; }

    public static CommandProxy CopyCmd { get; private set; }

    public static CommandProxy CutCmd { get; private set; }

    public static CommandProxy PasteCmd { get; private set; }

    public static CommandProxy DeleteCmd { get; private set; }

    public static CommandProxy DeleteCmd2 { get; private set; }

    public static CommandProxy RefreshCmd { get; private set; }

    public static CommandProxy RenameCmd { get; private set; }

    public static CommandProxy CloseAllCmd { get; private set; }

    public static CommandProxy CloseOtherCmd { get; private set; }

    public static CommandProxy OpenDirCmd { get; private set; }

    public static CommandProxy PlayCmd { get; private set; }

    static GlobalCommand()
    {
      GlobalCommand.GlobalCmdManager = CommandManager.Main;
      GlobalCommand.NewCmd = CommandCreater.CreateCommand((object) CmdEnum.NewCmd, LanguageInfo.Menu_File_NewProject, "Control|Shift|N", "Meta|Shift|N", false, ActionType.Normal);
      GlobalCommand.NewFileCmd = CommandCreater.CreateCommand((object) CmdEnum.NewFileCmd, LanguageInfo.NewFile_Title, "Control|N", "Meta|N", false, ActionType.Normal);
      GlobalCommand.OpenCmd = CommandCreater.CreateCommand((object) CmdEnum.OpenCmd, LanguageInfo.Menu_File_OpenProject, "Control|O", "Meta|O", false, ActionType.Normal);
      GlobalCommand.RecentProjectCmd = CommandCreater.CreateCommandArray((object) CmdEnum.RecentProjectCmd, ActionType.Normal);
      GlobalCommand.CloseCmd = CommandCreater.CreateCommand((object) CmdEnum.CloseCmd, LanguageInfo.Dialog_ButtonClose, (string) null, (string) null, false, ActionType.Normal);
      GlobalCommand.CloseProjectCmd = CommandCreater.CreateCommand((object) CmdEnum.CloseProjectCmd, LanguageInfo.Menu_File_CloseProject, (string) null, (string) null, false, ActionType.Normal);
      GlobalCommand.CloseAllCmd = CommandCreater.CreateCommand((object) CmdEnum.CloseAllCmd, LanguageInfo.Command_CloseAll, (string) null, (string) null, false, ActionType.Normal);
      GlobalCommand.SaveCmd = CommandCreater.CreateCommand((object) CmdEnum.SaveCmd, LanguageInfo.Menu_File_SaveProject, "Control|S", "Meta|S", false, ActionType.Normal);
      GlobalCommand.SaveAllCmd = CommandCreater.CreateCommand((object) CmdEnum.SaveAllCmd, LanguageInfo.Command_SaveAll, "Control|Shift|S", "Shift|Meta|S", false, ActionType.Normal);
      GlobalCommand.SaveAsCmd = CommandCreater.CreateCommand((object) CmdEnum.SaveAsCmd, LanguageInfo.Menu_File_SaveAs, (string) null, (string) null, false, ActionType.Normal);
      GlobalCommand.ImportCmd = CommandCreater.CreateCommand((object) CmdEnum.ImportCmd, LanguageInfo.Menu_File_ImportResources, (string) null, (string) null, false, ActionType.Normal);
      GlobalCommand.ImportFileCmd = CommandCreater.CreateCommand((object) CmdEnum.ImportFileCmd, LanguageInfo.Menu_File_ImportFile, (string) null, (string) null, false, ActionType.Normal);
      GlobalCommand.ImportDirCmd = CommandCreater.CreateCommand((object) CmdEnum.ImportDirCmd, LanguageInfo.Menu_File_ImportFolder, (string) null, (string) null, false, ActionType.Normal);
      GlobalCommand.ImportProjectCmd = CommandCreater.CreateCommand((object) CmdEnum.ImportProjectCmd, LanguageInfo.Scene_Menu_File_ImportProject, (string) null, (string) null, false, ActionType.Normal);
      GlobalCommand.PublishCmd = CommandCreater.CreateCommand((object) CmdEnum.PublishCmd, LanguageInfo.Menu_File_PublishRes, "Control|P", "Meta|P", false, ActionType.Normal);
      GlobalCommand.PublishCodeIDECmd = CommandCreater.CreateCommand((object) CmdEnum.PublishCodeIDECmd, LanguageInfo.Menu_File_PublishToCodeIDE, (string) null, (string) null, false, ActionType.Normal);
      GlobalCommand.PublishXcodeCmd = CommandCreater.CreateCommand((object) CmdEnum.PublishXcodeCmd, LanguageInfo.Menu_File_PublishToXcode, (string) null, (string) null, false, ActionType.Normal);
      GlobalCommand.PublishVSCmd = CommandCreater.CreateCommand((object) CmdEnum.PublishVSCmd, LanguageInfo.Menu_File_PublishToVS, (string) null, (string) null, false, ActionType.Normal);
      GlobalCommand.QuitCmd = CommandCreater.CreateCommand((object) CmdEnum.QuitCmd, LanguageInfo.Menu_File_Exit, "Alt|F4", "Meta|Q", false, ActionType.Normal);
      GlobalCommand.UndoCmd = CommandCreater.CreateCommand((object) CmdEnum.UndoCmd, LanguageInfo.Menu_Edit_Undo, "Control|Z", "Meta|Z", false, ActionType.Normal);
      GlobalCommand.RedoCmd = CommandCreater.CreateCommand((object) CmdEnum.RedoCmd, LanguageInfo.Menu_Edit_Redo, "Control|Y", "Meta|Y", false, ActionType.Normal);
      GlobalCommand.ProjectSettingCmd = CommandCreater.CreateCommand((object) CmdEnum.ProjectSettingCmd, LanguageInfo.ProjSetting, (string) null, (string) null, false, ActionType.Normal);
      GlobalCommand.PreferencesCmd = CommandCreater.CreateCommand((object) CmdEnum.PreferencesCmd, LanguageInfo.Menu_Edit_Preferences, "Control|,", "Meta|,", false, ActionType.Normal);
      GlobalCommand.ShowRulerCmd = CommandCreater.CreateCommand((object) CmdEnum.ShowRulerCmd, LanguageInfo.Menu_View_VisibleRuler, (string) null, (string) null, false, ActionType.Normal);
      GlobalCommand.HideRulerCmd = CommandCreater.CreateCommand((object) CmdEnum.HideRulerCmd, LanguageInfo.Menu_View_HiddenRuler, (string) null, (string) null, false, ActionType.Normal);
      GlobalCommand.ClearGuidesCmd = CommandCreater.CreateCommand((object) CmdEnum.ClearGuidesCmd, LanguageInfo.Menu_View_ClearGuides, (string) null, (string) null, false, ActionType.Normal);
      GlobalCommand.LockGuidesCmd = CommandCreater.CreateCommand((object) CmdEnum.LockGuidesCmd, LanguageInfo.Menu_View_LockGuides, (string) null, (string) null, false, ActionType.Normal);
      GlobalCommand.UnLockGuidesCmd = CommandCreater.CreateCommand((object) CmdEnum.UnLockGuidesCmd, LanguageInfo.Menu_View_UnLockGuides, (string) null, (string) null, false, ActionType.Normal);
      GlobalCommand.NewGuidesCmd = CommandCreater.CreateCommand((object) CmdEnum.NewGuidesCmd, LanguageInfo.Menu_View_NewGuides, (string) null, (string) null, false, ActionType.Normal);
      GlobalCommand.OpenStartPageCmd = CommandCreater.CreateCommand((object) CmdEnum.OpenStartPageCmd, LanguageInfo.MainStartPage, (string) null, (string) null, false, ActionType.Normal);
      GlobalCommand.ResetLayoutCmd = CommandCreater.CreateCommand((object) CmdEnum.ResetLayoutCmd, LanguageInfo.Menu_Window_Reset, (string) null, (string) null, false, ActionType.Normal);
      GlobalCommand.PadCmd = CommandCreater.CreateCommandArray((object) CmdEnum.PadCmd, ActionType.Check);
      GlobalCommand.HelpCmd = CommandCreater.CreateCommand((object) CmdEnum.HelpCmd, LanguageInfo.Menu_Help_ShowHelp, "F1", (string) null, false, ActionType.Normal);
      GlobalCommand.AboutCmd = CommandCreater.CreateCommand((object) CmdEnum.AboutCmd, LanguageInfo.Menu_Help_About, (string) null, (string) null, false, ActionType.Normal);
      GlobalCommand.CheckUpdateCmd = CommandCreater.CreateCommand((object) CmdEnum.CheckUpdateCmd, LanguageInfo.Software_CheckUpdate, (string) null, (string) null, false, ActionType.Normal);
      GlobalCommand.StartLauncherCmd = CommandCreater.CreateCommand((object) CmdEnum.StartLauncherCmd, LanguageInfo.Menu_Help_StartLauncher, (string) null, (string) null, false, ActionType.Normal);
      GlobalCommand.SetChineseCmd = CommandCreater.CreateCommand((object) CmdEnum.SetChineseCmd, LanguageInfo.Menu_Language_SetCN, (string) null, (string) null, false, ActionType.Radio);
      GlobalCommand.SetEnglishCmd = CommandCreater.CreateCommand((object) CmdEnum.SetEnglishCmd, LanguageInfo.Menu_Language_SetEN, (string) null, (string) null, false, ActionType.Radio);
      GlobalCommand.SetSpanishCmd = CommandCreater.CreateCommand((object) CmdEnum.SetSpanishCmd, LanguageInfo.Menu_Language_SetSP, (string) null, (string) null, false, ActionType.Normal);
      GlobalCommand.SetJapaneseCmd = CommandCreater.CreateCommand((object) CmdEnum.SetJapaneseCmd, LanguageInfo.Menu_Language_SetJP, (string) null, (string) null, false, ActionType.Normal);
      GlobalCommand.SetKoreanCmd = CommandCreater.CreateCommand((object) CmdEnum.SetKoreanCmd, LanguageInfo.Menu_Language_SetKO, (string) null, (string) null, false, ActionType.Normal);
      GlobalCommand.CopyCmd = CommandCreater.CreateCommand((object) CmdEnum.CopyCmd, LanguageInfo.Command_Copy, "Control|C", "Meta|C", true, ActionType.Normal);
      GlobalCommand.CutCmd = CommandCreater.CreateCommand((object) CmdEnum.CutCmd, LanguageInfo.UIAnimation_MenuText_CutFrame, "Control|X", "Meta|X", true, ActionType.Normal);
      GlobalCommand.PasteCmd = CommandCreater.CreateCommand((object) CmdEnum.PasteCmd, LanguageInfo.Command_Paste, "Control|V", "Meta|V", true, ActionType.Normal);
      GlobalCommand.DeleteCmd = CommandCreater.CreateCommand((object) CmdEnum.DeleteCmd, LanguageInfo.Command_Delete, "Delete", "BackSpace", true, ActionType.Normal);
      GlobalCommand.DeleteCmd2 = CommandCreater.CreateCommand((object) CmdEnum.DeleteCmd2, LanguageInfo.Command_Delete, "BackSpace", "Delete", true, ActionType.Normal);
      GlobalCommand.RefreshCmd = CommandCreater.CreateCommand((object) CmdEnum.RefreshCmd, LanguageInfo.Command_Refresh, (string) null, (string) null, true, ActionType.Normal);
      GlobalCommand.RenameCmd = CommandCreater.CreateCommand((object) CmdEnum.RenameCmd, LanguageInfo.Command_Rename, "F2", "Meta|R", true, ActionType.Normal);
      GlobalCommand.CloseOtherCmd = CommandCreater.CreateCommand((object) CmdEnum.CloseOtherCmd, LanguageInfo.Command_CloseOther, (string) null, (string) null, false, ActionType.Normal);
      GlobalCommand.OpenDirCmd = CommandCreater.CreateCommand((object) CmdEnum.OpenDirCmd, LanguageInfo.Command_OpenDirectory, (string) null, (string) null, false, ActionType.Normal);
      GlobalCommand.PlayCmd = CommandCreater.CreateCommand((object) CmdEnum.PlayCmd, LanguageInfo.UIAnimation_ToolTip_Play, "F5", (string) null, false, ActionType.Normal);
      GlobalCommandHandle.InitService();
    }
  }
}
