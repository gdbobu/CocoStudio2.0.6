// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.Commands.MenuCreator
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using Gtk;
using MonoDevelop.Components.Commands;
using MonoDevelop.Core;

namespace CocoStudio.Core.Commands
{
  public class MenuCreator
  {
    private static CommandManager cmdManager = GlobalCommand.GlobalCmdManager;

    public static Menu CreatePopupMenu()
    {
      Menu submenu = MenuCreator.CreateMenuSet((object) "", false, (string) null, (string) null).Submenu as Menu;
      submenu.HasTooltip = false;
      return submenu;
    }

    public static MenuItem CreateMenuItem(CommandEntry ce)
    {
      return ce.CreateMenuItem(GlobalCommand.GlobalCmdManager);
    }

    public static MenuItem CreateMenuItem(Command cmd, bool autoHide = false, string label = null)
    {
      MenuCreator.CommandEntryHelper commandEntryHelper = label != null ? new MenuCreator.CommandEntryHelper(cmd, label) : new MenuCreator.CommandEntryHelper(cmd);
      commandEntryHelper.DisabledVisible = !autoHide;
      MenuItem menuItem = commandEntryHelper.GetMenuItem();
      menuItem.HasTooltip = false;
      menuItem.ButtonReleaseEvent += new ButtonReleaseEventHandler(MenuCreator.MenuItemBtnReleasedHandler);
      return menuItem;
    }

    public static MenuItem CreateDelayCloseMenuItem(Command cmd, bool autoHide = false, string label = null)
    {
      MenuCreator.CommandEntryHelper commandEntryHelper = label != null ? new MenuCreator.CommandEntryHelper(cmd, label) : new MenuCreator.CommandEntryHelper(cmd);
      commandEntryHelper.DisabledVisible = !autoHide;
      MenuItem menuItem = commandEntryHelper.GetMenuItem();
      menuItem.HasTooltip = false;
      menuItem.ButtonReleaseEvent += new ButtonReleaseEventHandler(MenuCreator.DelayHideMenuItemBtnReleasedHandler);
      return menuItem;
    }

    public static MenuItem CreateMenuSet(object id, bool autothide = false, string label = null, string icon = null)
    {
      if (id == null)
        id = (object) string.Empty;
      if (label == null)
        label = id.ToString();
      label = StringParserService.Parse(label);
      MenuCreator.CommandEntrySetHelper commandEntrySetHelper = new MenuCreator.CommandEntrySetHelper(label, (IconId) icon);
      commandEntrySetHelper.CommandId = id;
      commandEntrySetHelper.AutoHide = autothide;
      return commandEntrySetHelper.GetMenuItem(MenuCreator.cmdManager);
    }

    public static MenuItem CreateMenuSet(Command cmd, bool autoHide = false, string label = null)
    {
      MenuCreator.CommandEntryHelper commandEntryHelper = label != null ? new MenuCreator.CommandEntryHelper(cmd, label) : new MenuCreator.CommandEntryHelper(cmd);
      commandEntryHelper.DisabledVisible = !autoHide;
      MenuItem menuItem = commandEntryHelper.GetMenuItem();
      menuItem.Submenu = (Widget) MenuCreator.CreatePopupMenu();
      return menuItem;
    }

    public static MenuItem CreateMenuSeperator()
    {
      return (MenuItem) new SeparatorMenuItem();
    }

    public static CommandEntrySet CreateMacCES(object id, bool autoHide = false, string label = null, string icon = null)
    {
      if (id == null)
        id = (object) string.Empty;
      if (label == null)
        label = id.ToString();
      label = StringParserService.Parse(label);
      CommandEntrySet commandEntrySet = new CommandEntrySet(label, (IconId) icon);
      commandEntrySet.CommandId = id;
      commandEntrySet.AutoHide = autoHide;
      return commandEntrySet;
    }

    private static void MenuItemBtnReleasedHandler(object sender, ButtonReleaseEventArgs args)
    {
      args.RetVal = (object) true;
      MenuItem menuItem = sender as MenuItem;
      (menuItem.Parent as Menu).Deactivate();
      menuItem.Activate();
    }

    private static void DelayHideMenuItemBtnReleasedHandler(object sender, ButtonReleaseEventArgs args)
    {
      args.RetVal = (object) true;
      MenuItem menuItem = sender as MenuItem;
      Menu parent = menuItem.Parent as Menu;
      menuItem.Activate();
      parent.Deactivate();
    }

    private class CommandEntryHelper : CommandEntry
    {
      public CommandEntryHelper(Command cmd)
        : base(cmd)
      {
      }

      public CommandEntryHelper(Command cmd, string label)
        : base(cmd.Id, label, true)
      {
      }

      public MenuItem GetMenuItem()
      {
        return this.CreateMenuItem(MenuCreator.cmdManager);
      }

      public ToolItem GetToolItem()
      {
        return this.CreateToolItem(MenuCreator.cmdManager);
      }
    }

    private class CommandEntrySetHelper : CommandEntrySet
    {
      public CommandEntrySetHelper(string name, IconId icon)
        : base(name, icon)
      {
      }

      public MenuItem GetMenuItem(CommandManager cmdManager)
      {
        return this.CreateMenuItem(cmdManager);
      }

      public ToolItem GetToolItem(CommandManager cmdManager)
      {
        return this.CreateToolItem(cmdManager);
      }
    }
  }
}
