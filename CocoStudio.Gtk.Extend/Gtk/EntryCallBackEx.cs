// Decompiled with JetBrains decompiler
// Type: Gtk.EntryCallBackEx
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using Gdk;
using GLib;
using Gtk.Controls;
using System;
using System.Text.RegularExpressions;

namespace Gtk
{
  public class EntryCallBackEx : EntryEx
  {
    private string oldValue = string.Empty;
    private bool canSet = false;
    private bool isPress = false;
    private string regexFormat = "^[A-Za-z_]$|^[A-Za-z_]+[A-Za-z0-9_]*[A-Za-z0-9_]$";
    private string regexFormat_singleInput = "^[A-Za-z0-9]{1}$|^[_]{1}$";
    private string strValue;

    public string RegexFormat
    {
      get
      {
        return this.regexFormat;
      }
      set
      {
        this.regexFormat = value;
      }
    }

    public string RegexFormat_singleInput
    {
      get
      {
        return this.regexFormat_singleInput;
      }
      set
      {
        this.regexFormat_singleInput = value;
      }
    }

    public string Value
    {
      get
      {
        return this.strValue;
      }
      set
      {
        this.strValue = value;
        if (string.IsNullOrEmpty(this.strValue))
          this.strValue = "";
        this.Text = this.strValue;
        this.oldValue = value;
      }
    }

    public event EventHandler<EntryCallBackEventArgs> EntryValueChanged;

    public EntryCallBackEx()
    {
      this.HeightRequest = 22;
      this.TextInserted += new TextInsertedHandler(this.EntryCallBackEx_TextInserted);
    }

    [ConnectBefore]
    private void EntryCallBackEx_TextInserted(object o, TextInsertedArgs args)
    {
      this.canSet = false;
      if (this.CheckSingleValue(args.Text))
      {
        this.canSet = true;
      }
      else
      {
        if (!this.CheckFinalValue(args.Text))
          return;
        this.canSet = true;
      }
    }

    private bool CheckSingleValue(string value)
    {
      if (string.IsNullOrEmpty(value.Trim()))
        return false;
      return new Regex(this.RegexFormat_singleInput).IsMatch(value.Trim());
    }

    private bool CheckFinalValue(string value)
    {
      if (value == null)
        return false;
      if (string.IsNullOrWhiteSpace(value))
        return true;
      return new Regex(this.RegexFormat).IsMatch(value.Trim());
    }

    protected override void OnTextInserted(string text, ref int position)
    {
      if (!this.canSet)
        return;
      base.OnTextInserted(text.Trim(), ref position);
    }

    protected override bool OnKeyReleaseEvent(EventKey evnt)
    {
      if ((evnt.Key == Gdk.Key.Return || evnt.Key == Gdk.Key.KP_Enter || evnt.Key == Gdk.Key.ISO_Enter) && this.IsFocus)
      {
        if (this.CheckFinalValue(this.Text))
        {
          this.Value = this.Text.Trim();
          if (this.EntryValueChanged != null)
            this.EntryValueChanged((object) this, new EntryCallBackEventArgs(this.Value));
          this.oldValue = this.Value;
        }
        else
        {
          this.Value = this.oldValue;
          return false;
        }
      }
      return base.OnKeyReleaseEvent(evnt);
    }

    protected override bool OnButtonPressEvent(EventButton evnt)
    {
      if ((int) evnt.Button == 1)
        this.isPress = true;
      return base.OnButtonPressEvent(evnt);
    }

    protected override bool OnFocusOutEvent(EventFocus evnt)
    {
      this.SelectRegion(0, 0);
      if (this.isPress)
      {
        try
        {
          if (this.CheckFinalValue(this.Text))
          {
            this.Value = this.Text.Trim();
            if (this.EntryValueChanged != null)
              this.EntryValueChanged((object) this, new EntryCallBackEventArgs(this.Value));
          }
          else
          {
            this.Value = this.oldValue;
            return false;
          }
        }
        catch
        {
          this.Value = this.oldValue;
        }
      }
      this.isPress = false;
      this.canSet = false;
      return base.OnFocusOutEvent(evnt);
    }
  }
}
