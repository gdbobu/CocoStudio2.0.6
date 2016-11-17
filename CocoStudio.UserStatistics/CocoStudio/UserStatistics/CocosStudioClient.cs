// Decompiled with JetBrains decompiler
// Type: CocoStudio.UserStatistics.CocosStudioClient
// Assembly: CocoStudio.UserStatistics, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8836CE71-EF24-435F-B92F-7A743482F0F7
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UserStatistics.dll

using CocoStudio.Basic;
using Jisons;
using MonoDevelop.Core;
using System;
using System.Threading.Tasks;

namespace CocoStudio.UserStatistics
{
  public static class CocosStudioClient
  {
    private const string homeUrl = "http://c.kp747.com/k.js?id=�";
    private const string macID = "b10050c03040e2e7�";
    private const string winID = "c1a0a070b0b09227�";

    public static string CocosStudioOrg
    {
      get
      {
        if (Platform.IsMac)
          return CocosStudioClient.GetFullUrl("b10050c03040e2e7");
        return CocosStudioClient.GetFullUrl("c1a0a070b0b09227");
      }
    }

    public static void SentCocosStudioClientorg()
    {
      Task.Factory.StartNew((Action) (() => CocosStudioClient.CocosStudioOrg.GetResponseOfString("get", "")));
    }

    private static string GetFullUrl(string applicationID)
    {
      string macAddress = LocalInfo.GetMacAddress();
      return string.Format("{0}{1}&ref={2}&uv={3}", (object) "http://c.kp747.com/k.js?id=", (object) applicationID, (object) Option.EditorVersion, (object) macAddress);
    }
  }
}
