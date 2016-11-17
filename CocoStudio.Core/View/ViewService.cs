// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.View.ViewService
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using System;

namespace CocoStudio.Core.View
{
  public class ViewService : IViewService
  {
    private MainWindow mainWindow;

    public ViewService(MainWindow mainWindow)
    {
      this.mainWindow = mainWindow;
    }

    public void ShowDocumentView(string documentID)
    {
    }

    public void AutoHideAllView()
    {
    }

    public void ShowAutoHidedAllView()
    {
      throw new NotImplementedException();
    }

    public void ShowDockView(string regionName)
    {
    }

    public void HideAnchorView(string regionName)
    {
    }

    public void AotuHideView(string regionName)
    {
    }

    public void CloseView(string regionName)
    {
    }
  }
}
