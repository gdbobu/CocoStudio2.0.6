// Decompiled with JetBrains decompiler
// Type: Modules.Communal.MutualEditor.UDPSocket
// Assembly: Modules.Communal.MutualEditor, Version=1.0.5464.34363, Culture=neutral, PublicKeyToken=null
// MVID: DFA20643-9760-4068-BB56-12AD0ACFA443
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.MutualEditor.dll

using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Modules.Communal.MutualEditor
{
  public class UDPSocket : IDisposable
  {
    private bool runningFlag = false;
    private Socket socket;
    private EndPoint remotePoint;
    private Thread witeThread;

    public UDPPort Port { get; private set; }

    public event EventHandler<MessageArgs> Recived;

    public UDPSocket(string iP, int port)
    {
      this.Port = this.Start(iP, port);
    }

    ~UDPSocket()
    {
      this.Dispose();
    }

    protected virtual void OnRecived(Message msg)
    {
      if (this.Recived == null)
        return;
      this.Recived((object) this, new MessageArgs()
      {
        Message = msg
      });
    }

    private UDPPort Start(string iP, int port)
    {
      UDPPort udpPort = new UDPPort(iP, port);
      try
      {
        IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(iP), 0);
        this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        this.socket.ReceiveBufferSize = 1024;
        this.socket.SendBufferSize = 1024;
        while (true)
        {
          ipEndPoint.Port = port;
          try
          {
            this.socket.Bind((EndPoint) ipEndPoint);
            udpPort.Port = ipEndPoint.Port;
            break;
          }
          catch
          {
          }
          ++port;
        }
        this.runningFlag = true;
        this.remotePoint = (EndPoint) new IPEndPoint(IPAddress.Parse(udpPort.IP), udpPort.Port);
        this.witeThread = new Thread(new ThreadStart(this.Listen));
        this.witeThread.Start();
      }
      catch
      {
      }
      return udpPort;
    }

    private void Listen()
    {
      byte[] buffer = new byte[102400];
      while (this.runningFlag)
      {
        if (this.socket == null || this.socket.Available < 1)
        {
          Thread.Sleep(200);
        }
        else
        {
          try
          {
            if (this.socket.ReceiveFrom(buffer, ref this.remotePoint) > 0)
              this.OnRecived(new MemoryStream(buffer).DeSerializeBinary<Message>());
          }
          catch
          {
          }
        }
      }
    }

    public bool Sent(Message message)
    {
      IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(message.ReciveIP), int.Parse(message.RecivePort));
      byte[] array = message.SerializeBinary().ToArray();
      try
      {
        this.socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, 100);
        this.socket.SendTo(array, array.Length, SocketFlags.None, (EndPoint) ipEndPoint);
      }
      catch
      {
        return false;
      }
      return true;
    }

    private void Close()
    {
      this.runningFlag = false;
      if (this.socket == null)
        return;
      this.socket.Close();
      this.witeThread.Abort();
      this.socket = (Socket) null;
    }

    public void Dispose()
    {
      this.runningFlag = false;
      if (this.socket == null)
        return;
      this.Close();
    }
  }
}
