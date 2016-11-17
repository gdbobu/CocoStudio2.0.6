// Decompiled with JetBrains decompiler
// Type: Modules.Communal.MutualEditor.BaseHandler
// Assembly: Modules.Communal.MutualEditor, Version=1.0.5464.34363, Culture=neutral, PublicKeyToken=null
// MVID: DFA20643-9760-4068-BB56-12AD0ACFA443
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.MutualEditor.dll

using CocoStudio.Core;
using System;

namespace Modules.Communal.MutualEditor
{
  internal abstract class BaseHandler : IUDPHandler, IDisposable
  {
    private bool hasInit = false;
    private bool hasBindEvent = false;
    protected UDPSocket socket = (UDPSocket) null;

    protected event EventHandler<MessageArgs> Recived
    {
      add
      {
        if (this.socket == null)
          return;
        this.socket.Recived += value;
      }
      remove
      {
        if (this.socket == null)
          return;
        this.socket.Recived -= value;
      }
    }

    public BaseHandler()
    {
      if (this.hasInit)
        return;
      this.socket = new UDPSocket("127.0.0.1", this.GetStartPort());
      Services.IntinalizeCompleted += new System.Action<EventArgs>(this.HandleInitializeComplete);
      this.hasInit = true;
    }

    private void HandleInitializeComplete(EventArgs args)
    {
      if (this.hasBindEvent)
        return;
      this.Recived += new EventHandler<MessageArgs>(this.HandleMessageRecived);
      this.hasBindEvent = true;
    }

    public void SendMessage(string data, Action action = Action.Show)
    {
      if (this.socket == null)
        return;
      int startPort = this.GetStartPort();
      Message message = new Message() { SentIP = this.socket.Port.IP, Sentport = this.socket.Port.Port.ToString(), ReciveIP = this.socket.Port.IP };
      message.Data = data;
      message.Action = action;
      for (int index = 0; index < 7; ++index)
      {
        int num = startPort + index;
        if (this.socket.Port.Port != num)
        {
          message.RecivePort = num.ToString();
          this.socket.Sent(message);
        }
      }
    }

    public void Dispose()
    {
      if (this.socket != null)
        this.socket.Dispose();
      if (this.hasInit)
        Services.IntinalizeCompleted -= new System.Action<EventArgs>(this.HandleInitializeComplete);
      if (!this.hasBindEvent)
        return;
      this.Recived -= new EventHandler<MessageArgs>(this.HandleMessageRecived);
    }

    private void HandleMessageRecived(object sender, MessageArgs args)
    {
      this.OnHandleMessageRecived(sender, args);
    }

    protected virtual void OnHandleMessageRecived(object sender, MessageArgs args)
    {
    }

    protected virtual int GetStartPort()
    {
      return 9000;
    }
  }
}
