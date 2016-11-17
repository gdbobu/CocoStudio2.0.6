// Decompiled with JetBrains decompiler
// Type: Gtk.WebViewBox
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using Xwt;

namespace Gtk
{
  public class WebViewBox : EventBox
  {
    private string url = (string) null;
    public WebView webView;

    public string Url
    {
      get
      {
        return this.url;
      }
      set
      {
        this.url = value;
        if (this.webView == null)
          return;
        this.webView.Url = this.url;
      }
    }

    public WebViewBox()
    {
      this.CreateWebView();
      this.WidthRequest = 0;
      this.HeightRequest = 0;
    }

    public void CreateWebView()
    {
      this.webView = new WebView();
      this.Add(Toolkit.CurrentEngine.GetNativeWidget((Xwt.Widget) this.webView) as Widget);
    }
  }
}
