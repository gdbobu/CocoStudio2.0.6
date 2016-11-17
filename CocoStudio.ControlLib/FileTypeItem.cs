// Decompiled with JetBrains decompiler
// Type: CocoStudio.ControlLib.FileTypeItem
// Assembly: CocoStudio.ControlLib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 677D14F9-F98B-4FDA-9ECD-6C6F82FD30A1
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ControlLib.dll

using Gdk;
using GLib;
using Gtk;
using Mono.Unix;
using Stetic;
using System.ComponentModel;

namespace CocoStudio.ControlLib
{
  [ToolboxItem(true)]
  public class FileTypeItem : Bin
  {
    private Color BorderColor = new Color((byte) 7, (byte) 114, (byte) 244);
    private Color NomalFontColor = new Color((byte) 129, (byte) 129, (byte) 141);
    private Color SelectFontColor = new Color((byte) 244, (byte) 244, (byte) 243);
    private Color selectedColor = new Color((byte) 51, (byte) 50, (byte) 55);
    private Color unSelectedColor = new Color((byte) 66, (byte) 65, (byte) 71);
    private Color BackGroundColor;
    private FileTypeInfo fileTypeInfo;
    private EventBox event_root;
    private VBox vbox_main;
    private VBox vbox_picMain;
    private VBox vbox_top;
    private HBox hbox_picMain;
    private HBox hbox_left;
    private ImageBin img_Icon;
    private HBox hbox_rightOccupy;
    private VBox vbox_bottom;
    private Label lab_Name;

    public FileTypeInfo FileTypeInfo
    {
      get
      {
        return this.fileTypeInfo;
      }
      set
      {
        this.fileTypeInfo = value;
      }
    }

    public FileTypeItem()
    {
      this.Build();
      this.event_root.EnterNotifyEvent += new EnterNotifyEventHandler(this.event_root_EnterNotifyEvent);
      this.event_root.ButtonReleaseEvent += new ButtonReleaseEventHandler(this.event_root_ButtonReleaseEvent);
      this.InitiStyle();
      this.InitShow();
    }

    public void Selected()
    {
      this.BackGroundColor = this.selectedColor;
      this.lab_Name.ModifyFg(StateType.Normal, this.SelectFontColor);
      EventBox parentWidget = this.img_Icon.GetParentWidget<EventBox>();
      if (parentWidget == null)
        return;
      parentWidget.QueueDraw();
    }

    public void UnSelected()
    {
      this.BackGroundColor = this.unSelectedColor;
      this.event_root.ModifyBg(StateType.Normal, this.unSelectedColor);
      this.lab_Name.ModifyFg(StateType.Normal, this.NomalFontColor);
      EventBox parentWidget = this.img_Icon.GetParentWidget<EventBox>();
      if (parentWidget == null)
        return;
      parentWidget.QueueDraw();
    }

    private void event_root_ButtonReleaseEvent(object o, ButtonReleaseEventArgs args)
    {
    }

    private void event_root_EnterNotifyEvent(object o, EnterNotifyEventArgs args)
    {
    }

    private void InitiStyle()
    {
      this.event_root.ModifyBg(StateType.Normal, this.unSelectedColor);
    }

    public void InitiaView(FileTypeInfo info)
    {
      this.fileTypeInfo = info;
      this.img_Icon.SetImageView(info.Icon);
      this.lab_Name.LabelProp = info.DisplayName;
    }

    public void InitShow()
    {
      this.BackGroundColor = this.unSelectedColor;
      this.img_Icon.ExposeEvent += new ExposeEventHandler(this.img_Icon_ExposeEvent);
    }

    [ConnectBefore]
    private void img_Icon_ExposeEvent(object o, ExposeEventArgs args)
    {
      if ((int) this.BackGroundColor.Blue != (int) this.selectedColor.Blue)
        return;
      ImageBin imgIcon = this.img_Icon;
      int num1 = 5;
      int num2 = imgIcon.Allocation.X - num1;
      int num3 = imgIcon.Allocation.Y - num1;
      int num4 = imgIcon.Allocation.X + imgIcon.Allocation.Width - 1 + num1;
      int num5 = imgIcon.Allocation.Y - num1;
      int num6 = imgIcon.Allocation.X + imgIcon.Allocation.Width - 1 + num1;
      int num7 = imgIcon.Allocation.Y + imgIcon.Allocation.Height - 1 + num1;
      int num8 = imgIcon.Allocation.X - num1;
      int num9 = imgIcon.Allocation.Y + imgIcon.Allocation.Height - 1 + num1;
      EventBox parentWidget = imgIcon.GetParentWidget<EventBox>();
      if (parentWidget != null)
      {
        GC gc1 = new GC((Drawable) parentWidget.GdkWindow);
        gc1.RgbFgColor = this.unSelectedColor;
        parentWidget.GdkWindow.DrawRectangle(gc1, true, new Rectangle(0, 0, parentWidget.Allocation.Width, parentWidget.Allocation.Height));
        gc1.RgbFgColor = this.selectedColor;
        parentWidget.GdkWindow.DrawRectangle(gc1, true, new Rectangle(num2, num3, num4 - num2, num7 - num5));
        GC gc2 = new GC((Drawable) parentWidget.GdkWindow);
        gc2.RgbFgColor = this.BorderColor;
        parentWidget.GdkWindow.DrawLine(gc2, num2, num3, num4, num5);
        parentWidget.GdkWindow.DrawLine(gc2, num4, num5, num6, num7);
        parentWidget.GdkWindow.DrawLine(gc2, num6, num7, num8, num9);
        parentWidget.GdkWindow.DrawLine(gc2, num8, num9, num2, num3);
      }
    }

    protected virtual void Build()
    {
      Gui.Initialize((Widget) this);
      BinContainer.Attach((Bin) this);
      this.WidthRequest = 76;
      this.HeightRequest = 80;
      this.Name = "CocoStudio.ControlLib.FileTypeItem";
      this.event_root = new EventBox();
      this.event_root.WidthRequest = 72;
      this.event_root.HeightRequest = 72;
      this.event_root.Name = "event_root";
      this.event_root.BorderWidth = 4U;
      this.vbox_main = new VBox();
      this.vbox_main.Name = "vbox_main";
      this.vbox_main.Spacing = 2;
      this.vbox_picMain = new VBox();
      this.vbox_picMain.WidthRequest = 48;
      this.vbox_picMain.HeightRequest = 48;
      this.vbox_picMain.Name = "vbox_picMain";
      this.vbox_picMain.Spacing = 6;
      this.vbox_top = new VBox();
      this.vbox_top.Name = "vbox_top";
      this.vbox_top.Spacing = 6;
      this.vbox_picMain.Add((Widget) this.vbox_top);
      ((Box.BoxChild) this.vbox_picMain[(Widget) this.vbox_top]).Position = 0;
      this.hbox_picMain = new HBox();
      this.hbox_picMain.WidthRequest = 48;
      this.hbox_picMain.Name = "hbox_picMain";
      this.hbox_picMain.Spacing = 6;
      this.hbox_left = new HBox();
      this.hbox_left.Name = "hbox_left";
      this.hbox_left.Spacing = 6;
      this.hbox_picMain.Add((Widget) this.hbox_left);
      ((Box.BoxChild) this.hbox_picMain[(Widget) this.hbox_left]).Position = 0;
      this.img_Icon = new ImageBin();
      this.img_Icon.WidthRequest = 32;
      this.img_Icon.HeightRequest = 32;
      this.img_Icon.Name = "img_Icon";
      this.hbox_picMain.Add((Widget) this.img_Icon);
      Box.BoxChild boxChild1 = (Box.BoxChild) this.hbox_picMain[(Widget) this.img_Icon];
      boxChild1.Position = 1;
      boxChild1.Expand = false;
      boxChild1.Fill = false;
      this.hbox_rightOccupy = new HBox();
      this.hbox_rightOccupy.Name = "hbox_rightOccupy";
      this.hbox_rightOccupy.Spacing = 6;
      this.hbox_picMain.Add((Widget) this.hbox_rightOccupy);
      ((Box.BoxChild) this.hbox_picMain[(Widget) this.hbox_rightOccupy]).Position = 2;
      this.vbox_picMain.Add((Widget) this.hbox_picMain);
      Box.BoxChild boxChild2 = (Box.BoxChild) this.vbox_picMain[(Widget) this.hbox_picMain];
      boxChild2.Position = 1;
      boxChild2.Expand = false;
      boxChild2.Fill = false;
      this.vbox_bottom = new VBox();
      this.vbox_bottom.Name = "vbox_bottom";
      this.vbox_bottom.Spacing = 6;
      this.vbox_picMain.Add((Widget) this.vbox_bottom);
      ((Box.BoxChild) this.vbox_picMain[(Widget) this.vbox_bottom]).Position = 2;
      this.vbox_main.Add((Widget) this.vbox_picMain);
      Box.BoxChild boxChild3 = (Box.BoxChild) this.vbox_main[(Widget) this.vbox_picMain];
      boxChild3.Position = 0;
      boxChild3.Expand = false;
      this.lab_Name = new Label();
      this.lab_Name.Name = "lab_Name";
      this.lab_Name.LabelProp = Catalog.GetString("场景");
      this.vbox_main.Add((Widget) this.lab_Name);
      Box.BoxChild boxChild4 = (Box.BoxChild) this.vbox_main[(Widget) this.lab_Name];
      boxChild4.Position = 1;
      boxChild4.Expand = false;
      boxChild4.Fill = false;
      this.event_root.Add((Widget) this.vbox_main);
      this.Add((Widget) this.event_root);
      if (this.Child != null)
        this.Child.ShowAll();
      this.Hide();
    }
  }
}
