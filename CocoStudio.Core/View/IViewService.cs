// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.View.IViewService
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

namespace CocoStudio.Core.View
{
  public interface IViewService
  {
    void AutoHideAllView();

    void ShowAutoHidedAllView();

    void ShowDockView(string regionName);

    void ShowDocumentView(string regionName);

    void HideAnchorView(string regionName);

    void AotuHideView(string regionName);

    void CloseView(string regionName);
  }
}
