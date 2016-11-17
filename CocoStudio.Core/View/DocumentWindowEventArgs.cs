// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.View.DocumentWindowEventArgs
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using System.ComponentModel;

namespace CocoStudio.Core.View
{
  public class DocumentWindowEventArgs : CancelEventArgs
  {
    public bool Forced { get; private set; }

    public bool WasActive { get; private set; }

    public DocumentWindowEventArgs(bool force, bool wasActive)
    {
      this.Forced = force;
      this.WasActive = wasActive;
    }
  }
}
