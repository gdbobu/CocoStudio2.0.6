// Decompiled with JetBrains decompiler
// Type: Jisons.RequestState
// Assembly: Modules.Communal.CocoaChina, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A2EC95C-DDE6-43D1-B2DC-127A321770D0
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.CocoaChina.dll

using System.IO;
using System.Net;
using System.Text;

namespace Jisons
{
  public class RequestState
  {
    private const int BUFFER_SIZE = 10240;
    public StringBuilder requestData;
    public byte[] BufferRead;
    public HttpWebRequest request;
    public HttpWebResponse response;
    public Stream streamResponse;

    public RequestState()
    {
      this.BufferRead = new byte[10240];
      this.requestData = new StringBuilder("");
      this.request = (HttpWebRequest) null;
      this.streamResponse = (Stream) null;
    }
  }
}
