// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.ExtensionModel.MenuHandler
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

namespace CocoStudio.Core.ExtensionModel
{
  public abstract class MenuHandler
  {
    internal void InternalRun()
    {
      this.Run();
    }

    internal void InternalRun(object dataItem)
    {
      this.Run(dataItem);
    }

    internal void InternalUpdate(MenuInfo info)
    {
      this.Update(info);
    }

    internal void InternalUpdate(MenuArrayInfo info)
    {
      this.Update(info);
    }

    protected virtual void Run()
    {
    }

    protected virtual void Run(object dataItem)
    {
      this.Run();
    }

    protected virtual void Update(MenuInfo info)
    {
    }

    protected virtual void Update(MenuArrayInfo info)
    {
    }
  }
}
