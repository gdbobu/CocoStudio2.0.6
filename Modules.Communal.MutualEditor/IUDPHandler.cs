// Decompiled with JetBrains decompiler
// Type: Modules.Communal.MutualEditor.IUDPHandler
// Assembly: Modules.Communal.MutualEditor, Version=1.0.5464.34363, Culture=neutral, PublicKeyToken=null
// MVID: DFA20643-9760-4068-BB56-12AD0ACFA443
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.MutualEditor.dll

using System;

namespace Modules.Communal.MutualEditor
{
  public interface IUDPHandler : IDisposable
  {
    void SendMessage(string data, Action action = Action.Show);
  }
}
