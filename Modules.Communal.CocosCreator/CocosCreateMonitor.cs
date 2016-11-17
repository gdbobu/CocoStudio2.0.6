// Decompiled with JetBrains decompiler
// Type: Modules.Communal.CocosCreator.CocosCreateMonitor
// Assembly: Modules.Communal.CocosCreator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70C77DE5-8380-4243-AAEF-73AA753A2D70
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.CocosCreator.dll

using System;
using System.Text;
using System.Threading;

namespace Modules.Communal.CocosCreator
{
  public class CocosCreateMonitor
  {
    private bool needSendOutputEvent;
    private StringBuilder outputBuilder;
    private CancellationTokenSource cts;

    public string FullOutputInfo
    {
      get
      {
        if (this.outputBuilder == null)
          return "";
        return this.outputBuilder.ToString();
      }
    }

    public bool HasStarted { get; private set; }

    public bool IsCreating { get; private set; }

    public bool IsSuccessed { get; private set; }

    public bool IsCancelled
    {
      get
      {
        return this.cts.Token.IsCancellationRequested;
      }
    }

    public event EventHandler<OutputEventArgs> OutputUpdated;

    public event EventHandler<FinishedArgs> Finished;

    public CocosCreateMonitor(bool needSendOutputEvent)
    {
      this.needSendOutputEvent = needSendOutputEvent;
      this.HasStarted = false;
      this.IsSuccessed = false;
      this.IsCreating = false;
      this.cts = new CancellationTokenSource();
      this.outputBuilder = new StringBuilder();
    }

    public void Reset(bool needSendOutputEvent)
    {
      this.needSendOutputEvent = needSendOutputEvent;
      this.HasStarted = false;
      this.IsSuccessed = false;
      this.IsCreating = false;
      this.outputBuilder.Clear();
      if (this.cts != null)
        this.cts.Dispose();
      this.cts = new CancellationTokenSource();
    }

    public void Cancel()
    {
      this.cts.Cancel();
    }

    internal void SendInfo(string info)
    {
      this.outputBuilder.Append(info + "\r\n");
      if (!this.needSendOutputEvent || this.OutputUpdated == null)
        return;
      this.OutputUpdated((object) this, new OutputEventArgs(info));
    }

    internal void Start()
    {
      this.IsSuccessed = false;
      this.IsCreating = true;
      this.HasStarted = true;
    }

    internal void Finish(bool isSuccess)
    {
      this.IsSuccessed = isSuccess;
      this.IsCreating = false;
      if (this.Finished == null)
        return;
      this.Finished((object) this, new FinishedArgs(isSuccess));
    }
  }
}
