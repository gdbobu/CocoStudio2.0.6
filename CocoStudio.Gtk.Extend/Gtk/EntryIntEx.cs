// Decompiled with JetBrains decompiler
// Type: Gtk.EntryIntEx
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using Gdk;
using GLib;
using Gtk.Controls;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gtk
{
  public class EntryIntEx : EntryEx
  {
    private int maxValue = int.MaxValue;
    private bool canSet = false;
    private int minValue = int.MinValue;
    private bool allowWhip = false;
    private bool isScroll = false;
    private double oldValue = 0.0;
    private bool isPress = false;
    private double scrollnum = 1.0;
    private bool canZero = true;
    private double intValue = 0.0;
    private bool isReSetValue = false;
    private bool isRound = false;
    private const char macdot = '。';
    private const char dot = '.';
    private const char macsub = '－';
    private const char sub = '-';

    public int MaxValue
    {
      get
      {
        return this.maxValue;
      }
      set
      {
        this.maxValue = value;
      }
    }

    public int MinValue
    {
      get
      {
        return this.minValue;
      }
      set
      {
        this.minValue = value;
      }
    }

    public bool AllowWhip
    {
      get
      {
        return this.allowWhip;
      }
      set
      {
        this.allowWhip = value;
      }
    }

    public bool IsFouceChanged { get; set; }

    public bool IsInteger { get; set; }

    public int IntegerNum { get; set; }

    public double ScrollNum
    {
      get
      {
        return this.scrollnum;
      }
      set
      {
        this.scrollnum = value;
      }
    }

    public bool CanZero
    {
      get
      {
        return this.canZero;
      }
      set
      {
        this.canZero = value;
      }
    }

    public double Value
    {
      get
      {
        return this.intValue;
      }
      set
      {
        if (this.IsRound)
        {
          if (value > (double) this.MaxValue)
            value %= (double) this.MaxValue;
          if (value < (double) this.MinValue)
            value = value % (double) this.MaxValue + (double) this.MaxValue;
        }
        else
        {
          if (value > (double) this.MaxValue)
            value = (double) this.MaxValue;
          if (value < (double) this.MinValue)
            value = (double) this.MinValue;
        }
        this.intValue = value;
        this.isReSetValue = true;
        if (this.IsInteger)
          this.Text = value.ToString("F0");
        else
          this.Text = value.ToString(string.Format("F{0}", (object) this.IntegerNum));
        this.oldValue = value;
        this.isReSetValue = false;
      }
    }

    public bool IsRound
    {
      get
      {
        return this.isRound;
      }
      set
      {
        this.isRound = value;
      }
    }

    public event EventHandler<EntryIntEventArgs> EntryValueChanged;

    public EntryIntEx()
    {
      this.IntegerNum = 1;
      this.HeightRequest = 22;
      this.TextInserted += new TextInsertedHandler(this.EntryIntEx_TextInserted);
    }

    [ConnectBefore]
    private void EntryIntEx_TextInserted(object o, TextInsertedArgs args)
    {
      if (this.isReSetValue || this.allowWhip)
      {
        this.canSet = true;
      }
      else
      {
        this.canSet = false;
        List<char> list = this.Text.ToList<char>();
        list.InsertRange(args.Position, (IEnumerable<char>) args.Text);
        string s = new string(list.ToArray()).Replace('。', '.').Replace('－', '-');
        double result = -1.0;
        if (double.TryParse(s, out result))
          this.canSet = true;
        if (args.Position != 0 || (int) args.Text.FirstOrDefault<char>() != 45 && (int) args.Text.FirstOrDefault<char>() != 65293)
          return;
        this.canSet = true;
      }
    }

    protected override void OnTextInserted(string text, ref int position)
    {
      if (this.allowWhip)
        base.OnTextInserted(text.Trim(), ref position);
      else if (this.isReSetValue)
      {
        base.OnTextInserted(text, ref position);
        this.isReSetValue = false;
      }
      else
      {
        this.isPress = true;
        text = text.Replace('。', '.').Replace('－', '-');
        if (!this.isScroll)
        {
          if (!this.canSet)
            return;
          this.canSet = false;
          double result = -1.0;
          if (double.TryParse(text, out result))
            text = !this.IsInteger ? Math.Round(result, this.IntegerNum).ToString() : Math.Round(result, 0).ToString();
        }
        base.OnTextInserted(text.Trim(), ref position);
      }
    }

    protected override void OnFocusGrabbed()
    {
      if (this.Text == '-'.ToString())
        this.Text = "";
      base.OnFocusGrabbed();
    }

    protected override bool OnKeyPressEvent(EventKey evnt)
    {
      if (evnt.Key != Gdk.Key.Up && evnt.Key != Gdk.Key.Down)
        return base.OnKeyPressEvent(evnt);
      this.KeyScroll(evnt.Key == Gdk.Key.Up ? 0 : 1);
      return true;
    }

    protected override bool OnKeyReleaseEvent(EventKey evnt)
    {
      if (string.IsNullOrEmpty(this.Text))
        return false;
      if ((evnt.Key == Gdk.Key.Return || evnt.Key == Gdk.Key.KP_Enter || evnt.Key == Gdk.Key.ISO_Enter) && this.IsFocus)
      {
        double result = 0.0;
        if (double.TryParse(this.Text, out result))
        {
          if (result == 0.0 && !this.CanZero)
          {
            this.Value = this.oldValue;
            return false;
          }
          this.Value = result;
          if (this.EntryValueChanged != null)
            this.EntryValueChanged((object) this, new EntryIntEventArgs(this.Value));
          this.oldValue = this.Value;
        }
      }
      return base.OnKeyReleaseEvent(evnt);
    }

    protected override bool OnScrollEvent(EventScroll evnt)
    {
      if (string.IsNullOrEmpty(this.Text) || !this.IsFocus)
        return false;
      this.KeyScroll(evnt.Direction == ScrollDirection.Up ? 0 : 1);
      return true;
    }

    private void KeyScroll(int type)
    {
      double result = 0.0;
      if (!double.TryParse(this.Text, out result))
        return;
      double num;
      if (type == 0)
      {
        num = result + this.ScrollNum;
        if (num == 0.0 && !this.CanZero)
          num += this.ScrollNum;
      }
      else
      {
        num = result - this.ScrollNum;
        if (num == 0.0 && !this.CanZero)
          num -= this.ScrollNum;
      }
      this.isScroll = true;
      if (this.IsInteger)
        this.Text = Math.Round(num, 0).ToString();
      else
        this.Text = Math.Round(num, this.IntegerNum).ToString();
      this.isScroll = false;
      this.IsFocus = true;
      this.Value = num;
      if (this.EntryValueChanged != null)
        this.EntryValueChanged((object) this, new EntryIntEventArgs(this.Value));
      this.SelectRegion(0, this.Text.Length);
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
        if (!string.IsNullOrEmpty(this.Text))
        {
          try
          {
            double num = Convert.ToDouble(this.Text);
            if (num == 0.0 && !this.CanZero)
            {
              this.Value = this.oldValue;
              return false;
            }
            if (num != this.oldValue || num == this.oldValue && this.oldValue == 0.0)
            {
              this.Value = num;
              if (this.EntryValueChanged != null)
                this.EntryValueChanged((object) this, new EntryIntEventArgs(num));
            }
          }
          catch
          {
            if (this.IsFouceChanged)
            {
              this.allowWhip = true;
              this.Text = '-'.ToString();
              this.allowWhip = false;
            }
            else
              this.Value = this.oldValue;
          }
        }
        else if (this.IsFouceChanged)
        {
          this.allowWhip = true;
          this.Text = '-'.ToString();
          this.allowWhip = false;
        }
        else
          this.Value = this.oldValue;
      }
      this.isPress = false;
      this.canSet = false;
      return base.OnFocusOutEvent(evnt);
    }

    public void SetEntryPRoperty(bool isInteger, int integerNum, double scrollNum)
    {
      this.IsInteger = isInteger;
      this.IntegerNum = integerNum;
      this.ScrollNum = scrollNum;
    }
  }
}
