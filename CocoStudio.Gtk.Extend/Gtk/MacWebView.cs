// Decompiled with JetBrains decompiler
// Type: Gtk.MacWebView
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using CocoStudio.Basic;
using MonoMac.AppKit;
using MonoMac.Foundation;
using MonoMac.WebKit;
using System;
using System.Diagnostics;
using Xwt.GtkBackend;

namespace Gtk
{
  public class MacWebView
  {
    public static Widget CreateMacWebView(string url)
    {
      return GtkMacInterop.NSViewToGtkWidget((object) new WebView() { PolicyDelegate = (WebPolicyDelegate) new MacWebView.DownLoadCallback(), UIDelegate = (WebUIDelegate) new MacWebView.MarkdownWebUIDelegate(), MainFrameUrl = url });
    }

    private class DownLoadCallback : WebPolicyDelegate
    {
      private readonly NSString WebActionNavigationTypeKey = new NSString("WebActionNavigationTypeKey");
      private readonly NSString WebActionOriginalUrlKey = new NSString("WebActionOriginalUrlKey");

      public override void DecidePolicyForNavigation(WebView webView, NSDictionary actionInformation, NSUrlRequest request, WebFrame frame, NSObject decisionToken)
      {
        switch (((NSNumber) actionInformation[this.WebActionNavigationTypeKey]).Int32Value)
        {
          case 0:
            // ISSUE: reference to a compiler-generated method
            NSWorkspace.SharedWorkspace.OpenUrl(actionInformation[this.WebActionOriginalUrlKey] as NSUrl);
            WebPolicyDelegate.DecideIgnore(decisionToken);
            break;
          case 1:
          case 2:
          case 4:
            WebPolicyDelegate.DecideIgnore(decisionToken);
            break;
          case 3:
          case 5:
            WebPolicyDelegate.DecideUse(decisionToken);
            break;
        }
      }

      public override void DecidePolicyForNewWindow(WebView webView, NSDictionary actionInformation, NSUrlRequest request, string newFrameName, NSObject decisionToken)
      {
        this.OpenWeb(request.ToString());
      }

      private void OpenWeb(string url)
      {
        try
        {
          using (Process.Start(url))
            ;
        }
        catch (Exception ex)
        {
          LogConfig.Output.Error((object) "Open web address failed.", ex);
        }
      }
    }

    private class MarkdownWebUIDelegate : WebUIDelegate
    {
      public override NSMenuItem[] UIGetContextMenuItems(WebView sender, NSDictionary forElement, NSMenuItem[] defaultMenuItems)
      {
        return (NSMenuItem[]) null;
      }
    }
  }
}
