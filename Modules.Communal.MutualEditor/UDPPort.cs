// Decompiled with JetBrains decompiler
// Type: Modules.Communal.MutualEditor.UDPPort
// Assembly: Modules.Communal.MutualEditor, Version=1.0.5464.34363, Culture=neutral, PublicKeyToken=null
// MVID: DFA20643-9760-4068-BB56-12AD0ACFA443
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.MutualEditor.dll

namespace Modules.Communal.MutualEditor
{
  public struct UDPPort
  {
    public string IP;
    public int Port;

    public UDPPort(string ip, int port)
    {
      this.IP = ip;
      this.Port = port;
    }
  }
}
