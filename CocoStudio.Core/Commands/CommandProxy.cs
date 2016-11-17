// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.Commands.CommandProxy
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using MonoDevelop.Components.Commands;
using System;

namespace CocoStudio.Core.Commands
{
  public class CommandProxy : ActionCommand
  {
    public event EventHandler<CommandRunArgs> Execute;

    public event EventHandler<CommandUpdateArgs> Update;

    internal CommandProxy()
    {
      this.DefaultHandler = (CommandHandler) new CommandProxy.DefaultCommandHanle(this);
      this.DefaultHandlerType = this.DefaultHandler.GetType();
    }

    public void RaiseExecute(object dataItem = null)
    {
      if (this.Execute == null)
        return;
      this.Execute((object) this, new CommandRunArgs(dataItem));
    }

    private void RaiseCanExecute(CommandInfo cmdInfo)
    {
      if (this.Execute == null)
        cmdInfo.Enabled = false;
      else if (this.Update != null)
        this.Update((object) this, new CommandUpdateArgs(cmdInfo));
      else
        cmdInfo.Enabled = true;
    }

    private class DefaultCommandHanle : CommandHandler
    {
      private CommandProxy command;

      public DefaultCommandHanle(CommandProxy command)
      {
        this.command = command;
      }

      protected override void Run()
      {
        this.command.RaiseExecute((object) null);
      }

      protected override void Update(CommandInfo info)
      {
        this.command.RaiseCanExecute(info);
      }
    }
  }
}
