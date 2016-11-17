// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.Commands.CommandCreater
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using Mono.Addins;
using MonoDevelop.Components.Commands;
using MonoDevelop.Core;
using System;

namespace CocoStudio.Core.Commands
{
  public class CommandCreater : TypeExtensionNode
  {
    public static CommandProxy CreateCommand(object cmdEnum, string label, string shortCut = null, string macShortCut = null, bool isLocal = false, ActionType cmdType = ActionType.Normal)
    {
      CommandProxy actionCommand = CommandCreater.CreateActionCommand(cmdEnum, cmdType, label, shortCut, macShortCut, false) as CommandProxy;
      if (isLocal)
      {
        actionCommand.Execute += new EventHandler<CommandRunArgs>(CommandCreater.EmptyRootCmd_Execute);
        actionCommand.Update += new EventHandler<CommandUpdateArgs>(CommandCreater.DisableAndBypass_CanExecute);
      }
      return actionCommand;
    }

    public static CommandArrayProxy CreateCommandArray(object cmdEnum, ActionType cmdType = ActionType.Normal)
    {
      return CommandCreater.CreateActionCommand(cmdEnum, cmdType, cmdEnum.ToString() + "队列", (string) null, (string) null, true) as CommandArrayProxy;
    }

    private static ActionCommand CreateActionCommand(object cmdEnum, ActionType cmdType, string label, string shortCut, string macShortCut, bool isArray)
    {
      ActionCommand actionCommand = !isArray ? (ActionCommand) new CommandProxy() : (ActionCommand) new CommandArrayProxy();
      actionCommand.ActionType = cmdType;
      actionCommand.CommandArray = isArray;
      actionCommand.Id = (object) (cmdEnum.GetType().FullName + "." + cmdEnum.ToString());
      actionCommand.Text = label;
      if (macShortCut == null)
        macShortCut = shortCut;
      string binding = Platform.IsMac ? macShortCut : shortCut;
      if (Platform.IsWindows && !string.IsNullOrEmpty(shortCut))
        binding = shortCut;
      actionCommand.AccelKey = KeyBindingManager.CanonicalizeBinding(binding);
      GlobalCommand.GlobalCmdManager.RegisterCommand((Command) actionCommand);
      return actionCommand;
    }

    private static void EmptyRootCmd_Execute(object sender, CommandRunArgs e)
    {
    }

    private static void DisableAndBypass_CanExecute(object sender, CommandUpdateArgs e)
    {
      e.Info.Bypass = true;
      e.Info.Enabled = false;
    }
  }
}
