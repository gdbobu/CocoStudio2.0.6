// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.Commands.FileTabCommand
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using Gtk;
using MonoDevelop.Components.Commands;

namespace CocoStudio.Core.Commands
{
  internal class FileTabCommand
  {
    private static Menu tabPopupMenu;

    public static Menu TabPopupMenu
    {
      get
      {
        if (FileTabCommand.tabPopupMenu == null)
          FileTabCommand.tabPopupMenu = FileTabCommand.InitPopupMenu();
        return FileTabCommand.tabPopupMenu;
      }
    }

    private static Menu InitPopupMenu()
    {
      Menu popupMenu = MenuCreator.CreatePopupMenu();
      popupMenu.Append((Widget) MenuCreator.CreateMenuItem((Command) GlobalCommand.CloseCmd, false, (string) null));
      popupMenu.Append((Widget) MenuCreator.CreateMenuItem((Command) GlobalCommand.CloseAllCmd, false, (string) null));
      popupMenu.Append((Widget) MenuCreator.CreateMenuItem((Command) GlobalCommand.CloseOtherCmd, false, (string) null));
      popupMenu.Append((Widget) MenuCreator.CreateMenuSeperator());
      popupMenu.Append((Widget) MenuCreator.CreateMenuItem((Command) GlobalCommand.SaveCmd, false, (string) null));
      popupMenu.Append((Widget) MenuCreator.CreateMenuItem((Command) GlobalCommand.SaveAllCmd, false, (string) null));
      popupMenu.Append((Widget) MenuCreator.CreateMenuSeperator());
      popupMenu.Append((Widget) MenuCreator.CreateMenuItem((Command) GlobalCommand.OpenDirCmd, false, (string) null));
      return popupMenu;
    }

    public enum FileTabCommands
    {
      CloseAll,
      CloseAllButThis,
    }
  }
}
