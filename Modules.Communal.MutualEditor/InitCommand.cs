// Decompiled with JetBrains decompiler
// Type: Modules.Communal.MutualEditor.InitCommand
// Assembly: Modules.Communal.MutualEditor, Version=1.0.5464.34363, Culture=neutral, PublicKeyToken=null
// MVID: DFA20643-9760-4068-BB56-12AD0ACFA443
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.MutualEditor.dll

using CocoStudio.Basic;
using CocoStudio.Core;
using CocoStudio.Core.Commands;
using CocoStudio.Core.ExtensionModel;
using Gtk;
using Modules.Communal.MultiLanguage;
using Mono.Addins;
using MonoDevelop.Components;
using MonoDevelop.Core;
using System;
using System.IO;

namespace Modules.Communal.MutualEditor
{
  [Extension(Type = typeof (ICommandHandle))]
  public class InitCommand : ICommandHandle
  {
    public void Initialize()
    {
      GlobalCommand.OpenCmd.Execute += new EventHandler<CommandRunArgs>(InitCommand.OpenCmd_Execute);
    }

    private static void OpenCmd_Execute(object sender, CommandRunArgs e)
    {
      string str = (string) null;
      if (e.DataItem == null)
      {
        string lastBrowserLocation = Services.RecentFileService.LastBrowserLocation;
        if (Option.IsXP)
        {
          str = FileChooserDialogModel.GetOpenFilePath(new string[1]{ "*.ccs" }, "Open File", false, lastBrowserLocation).FileName;
          Services.RecentFileService.LastBrowserLocation = Path.GetDirectoryName(str);
        }
        else
        {
          SelectFileDialog selectFileDialog = new SelectFileDialog();
          selectFileDialog.Title = LanguageInfo.Menu_File_OpenProject;
          selectFileDialog.Action = FileChooserAction.Open;
          selectFileDialog.SelectMultiple = false;
          selectFileDialog.CurrentFolder = (FilePath) lastBrowserLocation;
          selectFileDialog.AddFilter("Solution Files", "*.ccs");
          if (selectFileDialog.Run())
          {
            str = (string) selectFileDialog.SelectedFile;
            Services.RecentFileService.LastBrowserLocation = Path.GetDirectoryName(str);
          }
        }
      }
      else
        str = e.DataItem.ToString();
      StartInfoService.Instance.HandleOpenSolution(str);
    }
  }
}
