// Decompiled with JetBrains decompiler
// Type: Jisons.JisonsHttp
// Assembly: Modules.Communal.CocoaChina, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A2EC95C-DDE6-43D1-B2DC-127A321770D0
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.CocoaChina.dll

using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Text;

namespace Jisons
{
  public static class JisonsHttp
  {
    public static CookieContainer CookieContainers = new CookieContainer();
    public static Dictionary<string, string> Cookies = new Dictionary<string, string>();
    public const string IE7 = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; InfoPath.2; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; .NET4.0C; .NET4.0E)";

    static JisonsHttp()
    {
      ServicePointManager.ServerCertificateValidationCallback += (RemoteCertificateValidationCallback) ((se, cert, chain, sslerror) => true);
    }

    internal static HttpWebRequest CreatRequest(this string url, string method)
    {
      HttpWebRequest httpWebRequest = (HttpWebRequest) WebRequest.Create(url);
      httpWebRequest.KeepAlive = false;
      ServicePointManager.DefaultConnectionLimit = 50;
      httpWebRequest.Method = method.ToUpper();
      httpWebRequest.AllowAutoRedirect = true;
      httpWebRequest.CookieContainer = JisonsHttp.CookieContainers;
      httpWebRequest.ContentType = "application/x-www-form-urlencoded";
      httpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; InfoPath.2; .NET CLR 2.0.50727; .NET CLR 3.0.04506.648; .NET CLR 3.5.21022; .NET4.0C; .NET4.0E)";
      httpWebRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
      httpWebRequest.Timeout = 50000;
      return httpWebRequest;
    }

    public static Stream GetResponseOfStream(this string url, string method = "get", string data = "")
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
        HttpWebResponse response = (HttpWebResponse) httpWebRequest.GetResponse();
        using (Stream responseStream = response.GetResponseStream())
        {
          MemoryStream memoryStream = new MemoryStream();
          responseStream.CopyTo((Stream) memoryStream);
          memoryStream.Position = 0L;
          response.Close();
          httpWebRequest.Abort();
          return (Stream) memoryStream;
        }
      }
      catch
      {
        return (Stream) null;
      }
    }

    public static string GetResponseOfString(this string url, string method = "get", string data = "")
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
        HttpWebResponse response = (HttpWebResponse) httpWebRequest.GetResponse();
        foreach (Cookie cookie in response.Cookies)
        {
          JisonsHttp.Cookies[cookie.Name] = cookie.Value;
          JisonsHttp.CookieContainers.Add(cookie);
        }
        using (Stream responseStream = response.GetResponseStream())
        {
          string end = new StreamReader(responseStream, Encoding.UTF8).ReadToEnd();
          response.Close();
          httpWebRequest.Abort();
          return end;
        }
      }
      catch
      {
        return string.Empty;
      }
    }
  }
}
