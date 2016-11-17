// Decompiled with JetBrains decompiler
// Type: Modules.Communal.MutualEditor.Message
// Assembly: Modules.Communal.MutualEditor, Version=1.0.5464.34363, Culture=neutral, PublicKeyToken=null
// MVID: DFA20643-9760-4068-BB56-12AD0ACFA443
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.MutualEditor.dll

using System;

namespace Modules.Communal.MutualEditor
{
  [Serializable]
  public class Message
  {
    public string SentIP = "127.0.0.1";
    public string ReciveIP = "127.0.0.1";
    public string Sentport;
    public string RecivePort;
    public Action Action;
    public string Data;
  }
}
