// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Command.CommandHandles
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Core.Commands;
using CocoStudio.Core.ExtensionModel;
using CocoStudio.Model.ViewModel;
using Mono.Addins;
using System;

namespace CocoStudio.Model.Command
{
  [Extension(Type = typeof (ICommandHandle))]
  internal class CommandHandles : ICommandHandle
  {
    public void Initialize()
    {
      GlobalCommand.PlayCmd.Execute += new EventHandler<CommandRunArgs>(CommandHandles.PlayCmd_Execute);
    }

    private static void PlayCmd_Execute(object sender, CommandRunArgs e)
    {
      TimelineActionManager.Instance.Play(!TimelineActionManager.Instance.IsPlaying);
    }
  }
}
