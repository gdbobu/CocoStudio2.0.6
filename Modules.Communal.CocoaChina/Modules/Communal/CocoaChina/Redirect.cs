// Decompiled with JetBrains decompiler
// Type: Modules.Communal.CocoaChina.Redirect
// Assembly: Modules.Communal.CocoaChina, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1A2EC95C-DDE6-43D1-B2DC-127A321770D0
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.CocoaChina.dll

using System.Diagnostics;

namespace Modules.Communal.CocoaChina
{
  public class Redirect
  {
    private static string RedirectUrl = "http://open.cocoachina.com/login_oauth/login_action?";
    public const string CocoStudioUrl = "http://open.cocoachina.com/";

    public static void RedirectCocoaChina(string name, string password)
    {
      Process.Start(Redirect.RedirectCocoaChinaUrl(name, password));
    }

    public static string RedirectCocoaChinaUrl(string name, string password)
    {
      User user = new User() { UserName = name, PassWord = password };
      return Redirect.RedirectUrl + user.RedirectData;
    }
  }
}
