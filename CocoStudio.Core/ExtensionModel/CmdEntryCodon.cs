// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.ExtensionModel.CmdEntryCodon
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using CocoStudio.Basic;
using CocoStudio.Core.Commands;
using Modules.Communal.MultiLanguage;
using Mono.Addins;
using MonoDevelop.Components.Commands;
using MonoDevelop.Components.Commands.ExtensionNodes;
using MonoDevelop.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CocoStudio.Core.ExtensionModel
{
  [ExtensionNode(Description = "Mono中的CommandCodon与CommandItemCodon的合并形式")]
  internal class CmdEntryCodon : InstanceExtensionNode
  {
    [NodeAttribute("disabledVisible", "Set to 'false' if the command has to be hidden when disabled. 'true' by default.")]
    private bool disabledVisible = true;
    [NodeAttribute("type", "Type of the command. It can be: normal (the default), check, radio or array.")]
    private string type = "normal";
    [NodeAttribute("isInternal", "是否使用编辑器内部使用的命令")]
    private bool isInternal = false;
    private string widget = (string) null;
    [NodeAttribute("label", "Label", Localizable = true)]
    private string label;
    [NodeAttribute("description", "Description of the command", Localizable = true)]
    private string description;
    [NodeAttribute("shortcut", "Key combination that triggers the command. Control, Alt, Meta, Super and Shift modifiers can be specified using '+' as a separator. Multi-state key bindings can be specified using a '|' between the mode and accel. For example 'Control+D' or 'Control+X|Control+S'")]
    private string shortcut;
    [NodeAttribute("macShortcut", "Mac version of the shortcut. Format is that same as 'shortcut', but the 'Meta' modifier corresponds to the Command key.")]
    private string macShortcut;
    [NodeAttribute("winShortcut", "Win version of the shortcut. Format is that same as 'shortcut'.")]
    private string winShortcut;
    [NodeAttribute("handler", "Class that handles this command. This property is optional.")]
    private string handler;
    private string icon;

    public override object CreateInstance()
    {
      if (this.isInternal)
      {
        Command command = GlobalCommand.GlobalCmdManager.GetCommand((object) this.Id);
        if (command == null)
          return (object) null;
        return (object) new CommandEntry(command);
      }
      if (this.label == null)
        this.label = this.Id;
      this.label = LanguageOption.GetValueBykey(this.label);
      Command command1 = this.CreateCommand();
      GlobalCommand.GlobalCmdManager.RegisterCommand(command1);
      return (object) new CommandEntry(command1);
    }

    private Command CreateCommand()
    {
      ActionType actionType = ActionType.Normal;
      bool flag1 = false;
      bool flag2 = false;
      bool flag3 = false;
      string type = this.type;
      char[] chArray = new char[1]{ '|' };
      foreach (string str in type.Split(chArray))
      {
        switch (str)
        {
          case "check":
            actionType = ActionType.Check;
            if (flag3)
              throw new InvalidOperationException("Action type specified twice.");
            flag3 = true;
            break;
          case "radio":
            actionType = ActionType.Radio;
            if (flag3)
              throw new InvalidOperationException("Action type specified twice.");
            flag3 = true;
            break;
          case "normal":
            actionType = ActionType.Normal;
            if (flag3)
              throw new InvalidOperationException("Action type specified twice.");
            flag3 = true;
            break;
          case "custom":
            if (this.widget == null)
              throw new InvalidOperationException("Widget type not specified in custom command.");
            flag2 = true;
            break;
          case "array":
            flag1 = true;
            break;
          default:
            throw new InvalidOperationException("Unknown command type: " + str);
        }
      }
      if (flag3 && flag2)
        throw new InvalidOperationException("Invalid command type combination: " + this.type);
      Command command;
      if (flag2)
      {
        if (flag1)
          throw new InvalidOperationException("Array custom commands are not allowed.");
        CustomCommand customCommand = new CustomCommand();
        customCommand.Text = this.label;
        customCommand.WidgetType = this.Addin.GetType(this.widget);
        if (customCommand.WidgetType == (Type) null)
          throw new InvalidOperationException("Could not find command type '" + this.widget + "'.");
        command = (Command) customCommand;
      }
      else
      {
        if (this.widget != null)
          throw new InvalidOperationException("Widget type can only be specified for custom commands.");
        ActionCommand actionCommand = new ActionCommand();
        actionCommand.ActionType = actionType;
        actionCommand.CommandArray = flag1;
        if (this.handler != null)
        {
          try
          {
            MenuHandler instance = (MenuHandler) Activator.CreateInstance(this.Addin.GetType(this.handler, true));
            if (instance != null)
            {
              actionCommand.DefaultHandler = (CommandHandler) new CcsCmdHandler(instance);
              actionCommand.DefaultHandlerType = actionCommand.DefaultHandler.GetType();
            }
          }
          catch
          {
            LogConfig.Output.Error((object) string.Format("Failed to create MenuHandler: {0}", (object) this.handler));
          }
        }
        command = (Command) actionCommand;
      }
      command.Id = CmdEntryCodon.ParseCommandId((ExtensionNode) this);
      command.Text = this.label;
      if (this.description != null && this.description.Length > 0)
        command.Description = BrandingService.BrandApplicationName(this.description);
      command.Description = command.Description;
      if (this.icon != null)
        command.Icon = (IconId) CmdEntryCodon.GetStockId(this.Addin, this.icon);
      string str1 = Platform.IsMac ? this.macShortcut : this.shortcut;
      if (Platform.IsWindows && !string.IsNullOrEmpty(this.winShortcut))
        str1 = this.winShortcut;
      string[] strArray = (str1 ?? "").Split(' ');
      command.AccelKey = KeyBindingManager.CanonicalizeBinding(strArray[0]);
      if (strArray.Length > 1)
        command.AlternateAccelKeys = ((IEnumerable<string>) strArray).Skip<string>(1).ToArray<string>();
      command.DisabledVisible = this.disabledVisible;
      CommandCategoryCodon parent = this.Parent as CommandCategoryCodon;
      if (parent != null)
        command.Category = parent.Name;
      return command;
    }

    internal static object ParseCommandId(ExtensionNode codon)
    {
      string id = codon.Id;
      if (id.StartsWith("@"))
        return (object) id.Substring(1);
      return (object) id;
    }

    internal static string GetStockId(RuntimeAddin addin, string icon)
    {
      return icon;
    }
  }
}
