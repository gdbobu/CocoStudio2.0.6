// Decompiled with JetBrains decompiler
// Type: Gtk.CcsColorButton
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using Gdk;
using Stetic;
using System;
using System.ComponentModel;

namespace Gtk
{
  [ToolboxItem(true)]
  public class CcsColorButton : Bin
  {
    private Color BlackNormalBorder = new Color((byte) 38, (byte) 38, (byte) 40);
    private Color BlackPressedBorder = new Color((byte) 37, (byte) 37, (byte) 38);
    private Color BlueHoverBorder = new Color((byte) 29, (byte) 75, (byte) 120);
    private Color GrayNormalBg = new Color((byte) 75, (byte) 75, (byte) 82);
    private Color GrayPressedBg = new Color((byte) 61, (byte) 61, (byte) 65);
    public bool isMouseIn = false;
    private bool isInWhenPressed = false;
    private Color currentColor;
    private EventBox evtbx_border;
    private EventBox evtbx_bg;
    private EventBox evtbx_color;

    public Color CurrentColor
    {
      get
      {
        return this.currentColor;
      }
      set
      {
        this.currentColor = value;
        this.evtbx_color.ModifyBg(StateType.Normal, value);
      }
    }

    public event EventHandler<ColorSetEventArgs> ColorSet;

    public CcsColorButton()
    {
      this.Build();
      this.CurrentColor = new Color(byte.MaxValue, byte.MaxValue, byte.MaxValue);
      this.SetButtonStyle(CcsColorButton.BtnState.Normal);
    }

    public CcsColorButton(Color initColor)
    {
      this.Build();
      this.CurrentColor = initColor;
      this.SetButtonStyle(CcsColorButton.BtnState.Normal);
    }

    private void SetButtonStyle(CcsColorButton.BtnState state)
    {
      switch (state)
      {
        case CcsColorButton.BtnState.Normal:
          this.evtbx_border.ModifyBg(StateType.Normal, this.BlackNormalBorder);
          this.evtbx_bg.ModifyBg(StateType.Normal, this.GrayNormalBg);
          break;
        case CcsColorButton.BtnState.Hover:
          this.evtbx_border.ModifyBg(StateType.Normal, this.BlueHoverBorder);
          this.evtbx_bg.ModifyBg(StateType.Normal, this.GrayNormalBg);
          break;
        case CcsColorButton.BtnState.Pressed:
          this.evtbx_border.ModifyBg(StateType.Normal, this.BlackPressedBorder);
          this.evtbx_bg.ModifyBg(StateType.Normal, this.GrayPressedBg);
          break;
      }
    }

    protected void OnMouseEnter(object o, EnterNotifyEventArgs args)
    {
      this.isMouseIn = true;
      this.SetButtonStyle(CcsColorButton.BtnState.Hover);
    }

    protected void OnMouseLeave(object o, LeaveNotifyEventArgs args)
    {
      if (args.Event.Detail == NotifyType.Inferior)
        return;
      this.isMouseIn = false;
      this.SetButtonStyle(CcsColorButton.BtnState.Normal);
    }

    protected void OnButtonPress(object o, ButtonPressEventArgs args)
    {
      this.isInWhenPressed = true;
      this.SetButtonStyle(CcsColorButton.BtnState.Pressed);
    }

    protected void OnButtonRelease(object o, ButtonReleaseEventArgs args)
    {
      if (this.isMouseIn)
      {
        if (this.isInWhenPressed)
        {
          this.SetButtonStyle(CcsColorButton.BtnState.Normal);
          this.ColorClick();
        }
        else
          this.SetButtonStyle(CcsColorButton.BtnState.Hover);
      }
      else
        this.SetButtonStyle(CcsColorButton.BtnState.Normal);
      this.isInWhenPressed = false;
    }

    public void ColorClick()
    {
      ColorPickerDialog colorPickerDialog = new ColorPickerDialog(this.CurrentColor);
      if (colorPickerDialog.Run() == -5)
      {
        this.CurrentColor = colorPickerDialog.ColorPicker.CurrentColor;
        if (this.ColorSet != null)
          this.ColorSet((object) this, new ColorSetEventArgs(this.CurrentColor));
      }
      colorPickerDialog.Destroy();
    }

    protected virtual void Build()
    {
      Gui.Initialize((Widget) this);
      BinContainer.Attach((Bin) this);
      this.Name = "Gtk.CcsColorButton";
      this.evtbx_border = new EventBox();
      this.evtbx_border.Name = "evtbx_border";
      this.evtbx_bg = new EventBox();
      this.evtbx_bg.Name = "evtbx_bg";
      this.evtbx_bg.BorderWidth = 1U;
      this.evtbx_color = new EventBox();
      this.evtbx_color.Name = "evtbx_color";
      this.evtbx_color.BorderWidth = 3U;
      this.evtbx_bg.Add((Widget) this.evtbx_color);
      this.evtbx_border.Add((Widget) this.evtbx_bg);
      this.Add((Widget) this.evtbx_border);
      if (this.Child != null)
        this.Child.ShowAll();
      this.Hide();
      this.evtbx_border.EnterNotifyEvent += new EnterNotifyEventHandler(this.OnMouseEnter);
      this.evtbx_border.LeaveNotifyEvent += new LeaveNotifyEventHandler(this.OnMouseLeave);
      this.evtbx_border.ButtonPressEvent += new ButtonPressEventHandler(this.OnButtonPress);
      this.evtbx_border.ButtonReleaseEvent += new ButtonReleaseEventHandler(this.OnButtonRelease);
    }

    private enum BtnState
    {
      Normal,
      Hover,
      Pressed,
    }
  }
}
