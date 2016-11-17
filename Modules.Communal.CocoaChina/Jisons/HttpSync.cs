// Decompiled with JetBrains decompiler
// Type: Jisons.HttpSync
// Assembly: Modules.Communal.CocoaChina, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A2EC95C-DDE6-43D1-B2DC-127A321770D0
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.CocoaChina.dll

using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace Jisons
{
  public class HttpSync
  {
    public bool IsPost = false;
    public ManualResetEvent allDone = new ManualResetEvent(false);
    private const int BUFFER_SIZE = 1024;
    private const int DefaultTimeout = 60000;
    private string exceptionMessage;

    public event EventHandler<HttpSync.HttpSyncArgs> OnResived;

    protected void Resived(string msg)
    {
      if (this.OnResived == null)
        return;
      this.OnResived((object) this, new HttpSync.HttpSyncArgs()
      {
        Message = msg
      });
    }

    public void GetSyncResponseOfString(string url, string method = "get", string data = "")
    {
      try
      {
        HttpWebRequest httpWebRequest = url.CreatRequest(method);
        if (method.ToUpper() == "POST" && data != null)
        {
          byte[] bytes = new ASCIIEncoding().GetBytes(data);
          httpWebRequest.ContentLength = (long) bytes.Length;
          Stream requestStream = httpWebRequest.GetRequestStream();
          requestStream.Write(bytes, 0, bytes.Length);
          requestStream.Close();
        }
        try
        {
          RequestState requestState = new RequestState();
          requestState.request = httpWebRequest;
          ThreadPool.RegisterWaitForSingleObject(httpWebRequest.BeginGetResponse(new AsyncCallback(this.RespCallback), (object) requestState).AsyncWaitHandle, new WaitOrTimerCallback(this.TimeoutCallback), (object) httpWebRequest, 60000, true);
          this.allDone.WaitOne();
          requestState.response.Close();
        }
        catch (Exception ex)
        {
          this.exceptionMessage = ex.Message;
          this.Resived(this.exceptionMessage);
        }
      }
      catch (Exception ex)
      {
        this.exceptionMessage = ex.Message;
        this.Resived(this.exceptionMessage);
      }
    }

    private void TimeoutCallback(object state, bool timedOut)
    {
      if (!timedOut)
        return;
      HttpWebRequest httpWebRequest = state as HttpWebRequest;
      if (httpWebRequest != null)
        httpWebRequest.Abort();
    }

    private void RespCallback(IAsyncResult asynchronousResult)
    {
      try
      {
        RequestState asyncState = (RequestState) asynchronousResult.AsyncState;
        HttpWebRequest request = asyncState.request;
        asyncState.response = (HttpWebResponse) request.EndGetResponse(asynchronousResult);
        Stream responseStream = asyncState.response.GetResponseStream();
        asyncState.streamResponse = responseStream;
        responseStream.BeginRead(asyncState.BufferRead, 0, 1024, new AsyncCallback(this.ReadCallBack), (object) asyncState);
        return;
      }
      catch (WebException ex)
      {
        this.exceptionMessage = ex.Message;
      }
      this.allDone.Set();
      this.Resived(this.exceptionMessage);
    }

    private void ReadCallBack(IAsyncResult asyncResult)
    {
      RequestState asyncState = (RequestState) asyncResult.AsyncState;
      try
      {
        Stream streamResponse = asyncState.streamResponse;
        int count = streamResponse.EndRead(asyncResult);
        if (count > 0)
        {
          asyncState.requestData.Append(Encoding.ASCII.GetString(asyncState.BufferRead, 0, count));
          streamResponse.BeginRead(asyncState.BufferRead, 0, 1024, new AsyncCallback(this.ReadCallBack), (object) asyncState);
          return;
        }
        streamResponse.Close();
      }
      catch (WebException ex)
      {
        this.exceptionMessage = ex.Message;
      }
      this.allDone.Set();
      this.Resived(string.IsNullOrWhiteSpace(this.exceptionMessage) ? asyncState.requestData.ToString() : this.exceptionMessage);
    }

    public class HttpSyncArgs : EventArgs
    {
      public string Message { get; set; }
    }
  }
}
