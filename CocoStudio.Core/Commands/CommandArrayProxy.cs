// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.Commands.CommandArrayProxy
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using MonoDevelop.Components.Commands;
using System;

namespace CocoStudio.Core.Commands
{
  public class CommandArrayProxy : ActionCommand
  {
    public event EventHandler<CommandRunArgs> Execute;

    public event EventHandler<CommandArrayUpdateArgs> Update;

    internal CommandArrayProxy()
    {
      this.DefaultHandler = (CommandHandler) new CommandArrayProxy.DefaultCommandHanle(this);
      this.DefaultHandlerType = this.DefaultHandler.GetType();
    }

    private void RaiseExecute(object dataItem)
    {
      if (this.Execute == null)
        return;
      this.Execute((object) this, new CommandRunArgs(dataItem));
    }

    private void RaiseCanArrayExecute(CommandArrayInfo cmdArrayInfo)
    {
      if (this.Update == null)
        return;
      this.Update((object) this, new CommandArrayUpdateArgs(cmdArrayInfo));
    }

    private class DefaultCommandHanle : CommandHandler
    {
      private CommandArrayProxy command;

      public DefaultCommandHanle(CommandArrayProxy command)
      {
        this.command = command;
      }

      protected override void Run(object dataItem)
      {
        this.command.RaiseExecute(dataItem);
      }

      protected override void Update(CommandArrayInfo info)
      {
        this.command.RaiseCanArrayExecute(info);
      }
    }
  }
}
