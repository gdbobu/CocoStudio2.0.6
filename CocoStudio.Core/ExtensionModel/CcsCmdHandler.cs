// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.ExtensionModel.CcsCmdHandler
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using MonoDevelop.Components.Commands;

namespace CocoStudio.Core.ExtensionModel
{
  internal class CcsCmdHandler : CommandHandler
  {
    private MenuHandler Handler;

    public CcsCmdHandler(MenuHandler handler)
    {
      this.Handler = handler;
    }

    protected override void Run()
    {
      this.Handler.InternalRun();
    }

    protected override void Run(object dataItem)
    {
      this.Handler.InternalRun(dataItem);
    }

    protected override void Update(CommandInfo info)
    {
      this.Handler.InternalUpdate(new MenuInfo(info));
    }

    protected override void Update(CommandArrayInfo info)
    {
      this.Handler.InternalUpdate(new MenuArrayInfo(info));
    }
  }
}
