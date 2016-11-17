// Decompiled with JetBrains decompiler
// Type: Gtk.WebViewWrapper
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using Microsoft.CSharp.RuntimeBinder;
using MonoDevelop.Core;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Gtk
{
  public class WebViewWrapper : WidgetWrapper
  {
    private object webViewBackend;

    public WebViewWrapper(Widget widget, object webViewBackend)
      : base(widget)
    {
      this.webViewBackend = webViewBackend;
    }

    public override void Shown()
    {
      if (!Platform.IsWindows)
        return;
      this.SetScrollHide(this.webViewBackend);
    }

    private void SetScrollHide(object webViewBackend)
    {
      try
      {
          Type type = webViewBackend.GetType();
          FieldInfo field = type.GetField("view", BindingFlags.Instance | BindingFlags.NonPublic);
          dynamic value = field.GetValue(webViewBackend);
          value.ScrollBarsEnabled = false;
          value.IsWebBrowserContextMenuEnabled = false;
      }
      catch (Exception ex)
      {
      }
    }
  }
}
