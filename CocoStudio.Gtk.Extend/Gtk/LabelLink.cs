// Decompiled with JetBrains decompiler
// Type: Gtk.LabelLink
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using Gdk;
using Mono.Unix;
using Pango;
using Stetic;
using System;
using System.ComponentModel;

namespace Gtk
{
  [ToolboxItem(true)]
  public class LabelLink : Bin
  {
    private bool IsInWhenPressed = false;
    private bool _allowRightClick = true;
    private ButtonState currentState;
    private Gdk.Color normalColor;
    private Gdk.Color hoverColor;
    private Gdk.Color pressedColor;
    private EventBox evtbx_root;
    private Label label_display;

    public bool IsMouseIn { get; private set; }

    public object LabelContent { get; private set; }

    public ButtonState CurrentState
    {
      get
      {
        return this.currentState;
      }
      set
      {
        this.currentState = value;
        if (this.currentState == ButtonState.Normal)
        {
          this.label_display.ModifyFg(StateType.Normal, this.NormalColor);
          this.GdkWindow.Cursor = (Cursor) null;
        }
        else if (this.currentState == ButtonState.Hover)
        {
          this.label_display.ModifyFg(StateType.Normal, this.HoverColor);
          this.GdkWindow.Cursor = new Cursor(CursorType.Hand1);
        }
        else
        {
          if (this.currentState != ButtonState.Pressed)
            return;
          this.label_display.ModifyFg(StateType.Normal, this.PressedColor);
        }
      }
    }

    public Gdk.Color NormalColor
    {
      get
      {
        return this.normalColor;
      }
      set
      {
        this.normalColor = value;
        if (this.CurrentState != ButtonState.Normal)
          return;
        this.label_display.ModifyFg(StateType.Normal, this.normalColor);
      }
    }

    public Gdk.Color HoverColor
    {
      get
      {
        return this.hoverColor;
      }
      set
      {
        this.hoverColor = value;
        if (this.CurrentState != ButtonState.Hover)
          return;
        this.label_display.ModifyFg(StateType.Normal, this.hoverColor);
      }
    }

    public Gdk.Color PressedColor
    {
      get
      {
        return this.pressedColor;
      }
      set
      {
        this.pressedColor = value;
        if (this.CurrentState != ButtonState.Pressed)
          return;
        this.label_display.ModifyFg(StateType.Normal, this.pressedColor);
      }
    }

    public bool AllowRightClick
    {
      get
      {
        return this._allowRightClick;
      }
      set
      {
        this._allowRightClick = value;
      }
    }

    public Label Label
    {
      get
      {
        return this.label_display;
      }
    }

    public event EventHandler<LabelClickedEventArgs> LeftClicked;

    public event EventHandler<LabelClickedEventArgs> RightClicked;

    public LabelLink(string labelTxt = null)
    {
      this.Build();
      if (labelTxt != null)
        this.SetLabelText(labelTxt);
      this.Init();
    }

    private void Init()
    {
      this.IsMouseIn = false;
      this.NormalColor = LabelStyleSetting.LabelNormalColor;
      this.HoverColor = LabelStyleSetting.LabelHoverColor;
      this.PressedColor = LabelStyleSetting.LabelPressedColor;
      this.currentState = ButtonState.Normal;
      this.label_display.ModifyFg(StateType.Normal, this.NormalColor);
      this.label_display.ModifyFont(new FontDescription()
      {
        AbsoluteSize = LabelStyleSetting.LinkSize
      });
    }

    public void SetContent(object o)
    {
      this.LabelContent = o;
    }

    public void SetLabelText(string txt)
    {
      this.label_display.Text = txt;
    }

    public void SetLabelFontSize(int size)
    {
      this.label_display.SetFontSize((double) size);
    }

    public void SetLabelAlign(float x, float y)
    {
      this.label_display.Xalign = x;
      this.label_display.Yalign = y;
    }

    public void SetTooltip(string tooltip)
    {
      this.label_display.TooltipText = tooltip;
    }

    public void SetFontSize(double size)
    {
      this.label_display.ModifyFont(new FontDescription()
      {
        AbsoluteSize = size
      });
    }

    public void SetBackGroundColor(Gdk.Color bgColor)
    {
      this.evtbx_root.ModifyBg(StateType.Normal, bgColor);
    }

    public void SetForeGroundColor(Gdk.Color fgColor)
    {
      this.label_display.ModifyFg(StateType.Normal, fgColor);
    }

    protected void OnMousePressed(object o, ButtonPressEventArgs args)
    {
      this.IsInWhenPressed = true;
      if (!this._allowRightClick && (int) args.Event.Button == 3)
        this.CurrentState = ButtonState.Hover;
      else
        this.CurrentState = ButtonState.Pressed;
    }

    protected void OnMouseReleased(object o, ButtonReleaseEventArgs args)
    {
      if (!this._allowRightClick && (int) args.Event.Button == 3)
        return;
      if (this.IsMouseIn && this.IsInWhenPressed)
      {
        this.CurrentState = ButtonState.Hover;
        if (args.Event.State.HasFlag((Enum) ModifierType.Button1Mask))
        {
          if (this.LeftClicked != null)
            this.LeftClicked((object) this, new LabelClickedEventArgs(this.LabelContent));
        }
        else if (args.Event.State.HasFlag((Enum) ModifierType.Button3Mask) && this.RightClicked != null)
          this.RightClicked((object) this, new LabelClickedEventArgs(this.LabelContent));
      }
      else
        this.CurrentState = ButtonState.Normal;
      this.IsInWhenPressed = false;
    }

    protected void OnMouseEnter(object o, EnterNotifyEventArgs args)
    {
      this.IsMouseIn = true;
      this.CurrentState = ButtonState.Hover;
    }

    protected void OnMouseLeave(object o, LeaveNotifyEventArgs args)
    {
      this.IsMouseIn = false;
      this.CurrentState = ButtonState.Normal;
    }

    protected virtual void Build()
    {
      Gui.Initialize((Widget) this);
      BinContainer.Attach((Bin) this);
      this.Name = "Gtk.LabelLink";
      this.evtbx_root = new EventBox();
      this.evtbx_root.Name = "evtbx_root";
      this.label_display = new Label();
      this.label_display.Name = "label_display";
      this.label_display.LabelProp = Catalog.GetString("label1");
      this.evtbx_root.Add((Widget) this.label_display);
      this.Add((Widget) this.evtbx_root);
      if (this.Child != null)
        this.Child.ShowAll();
      this.Hide();
      this.evtbx_root.EnterNotifyEvent += new EnterNotifyEventHandler(this.OnMouseEnter);
      this.evtbx_root.LeaveNotifyEvent += new LeaveNotifyEventHandler(this.OnMouseLeave);
      this.evtbx_root.ButtonPressEvent += new ButtonPressEventHandler(this.OnMousePressed);
      this.evtbx_root.ButtonReleaseEvent += new ButtonReleaseEventHandler(this.OnMouseReleased);
    }
  }
}
