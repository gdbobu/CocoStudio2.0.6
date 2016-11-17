// Decompiled with JetBrains decompiler
// Type: Modules.Communal.Guide.GuideUC
// Assembly: Modules.Communal.Guide, Version=1.0.5464.34347, Culture=neutral, PublicKeyToken=null
// MVID: 170B36F5-747C-4B3C-9529-30988307B6DF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.Guide.dll

using Gdk;
using GLib;
using Gtk;
using Modules.Communal.MultiLanguage;
using Mono.Unix;
using MonoDevelop.Components;
using Pango;
using Stetic;
using System;
using System.Timers;

namespace Modules.Communal.Guide
{
  public class GuideUC : Gtk.Window
  {
    private int currentImageIndex = 0;
    private int imageListCount = GuideXMLHelp.GetImagePathList().Count;
    public bool DontShowAgain = false;
    private const int defaultSaveTimeInterval = 5;
    private Timer timer;
    private ImageView currentImage;
    private VBox vbox_root;
    private Label label_occupy3;
    private Label label_title;
    private ImageBin imagebin1;
    private HSeparator hseparator1;
    private HBox hbox_bottom;
    private HBox hbox_checkBtnExpand;
    private VBox vbox_expand;
    private CheckButton cbtn_show;
    private VBox vbox_btnPreviousBorder;
    private Button btn_previous;
    private VBox vbox_btnNextBorder;
    private Button btn_next;
    private Label label_occupy;

    private event EventHandler<EventArgs> Closed;

    public GuideUC()
      : base(Gtk.WindowType.Toplevel)
    {
      this.TypeHint = WindowTypeHint.Dialog;
      this.Build();
      this.InitStyle();
      this.InitMultyLanguage();
      this.SetGuideInfo(0);
      this.ChangeButtonContent();
      this.btn_previous.Sensitive = false;
      this.InitTimer();
    }

    private void InitStyle()
    {
      this.Modal = true;
      this.Resizable = false;
      this.label_title.ModifyFont(new FontDescription()
      {
        AbsoluteSize = 28.0 * Pango.Scale.PangoScale
      });
      this.hseparator1.ModifyBg(StateType.Normal, new Gdk.Color((byte) 83, (byte) 83, (byte) 83));
    }

    private void InitMultyLanguage()
    {
      this.Title = LanguageInfo.guide_TempTitle;
      this.cbtn_show.Label = LanguageInfo.guide_IsDisplay;
      this.btn_previous.Label = LanguageInfo.guide_Previows;
      this.btn_next.Label = LanguageInfo.guide_Next;
    }

    private void InitTimer()
    {
      this.timer = new Timer();
      this.timer.Interval = 5.0;
      this.timer.Elapsed += new ElapsedEventHandler(this.TimerTickHandle);
      this.timer.Start();
      this.DeleteEvent += new DeleteEventHandler(this.GuideUC_DeleteEvent);
      this.Closed += new EventHandler<EventArgs>(this.TimerCloseHandler);
    }

    private void TimerTickHandle(object sender, EventArgs e)
    {
      if (this.currentImageIndex + 1 < this.imageListCount)
        this.currentImageIndex = this.currentImageIndex + 1;
      int num = (int) GLib.Timeout.Add(0U, (TimeoutHandler) (() =>
      {
        this.SetGuideInfo(this.currentImageIndex);
        this.ChangeButtonContent();
        return false;
      }));
    }

    private void TimerCloseHandler(object sender, EventArgs e)
    {
      this.timer.Stop();
      GuideXMLHelp.SaveGuideConfig(new bool?(!this.DontShowAgain));
    }

    private void GuideUC_DeleteEvent(object o, DeleteEventArgs args)
    {
      this.Closed((object) this, (EventArgs) null);
    }

    private void SetGuideInfo(int currentIndex)
    {
      string image = GuideXMLHelp.GetImagePathList()[currentIndex].Image;
      this.label_title.Text = GuideXMLHelp.GetImagePathList()[currentIndex].Text;
      this.imagebin1.SetImageView(GuideXMLHelp.GainImage(image));
    }

    private void ChangeButtonContent()
    {
      this.btn_next.Label = this.currentImageIndex != this.imageListCount - 1 ? LanguageInfo.guide_Next : LanguageInfo.guide_LastOne;
      if (this.currentImageIndex == 0)
        this.btn_previous.Sensitive = false;
      else
        this.btn_previous.Sensitive = true;
    }

    protected void OnCbtnToggled(object sender, EventArgs e)
    {
      this.DontShowAgain = (sender as CheckButton).Active;
    }

    protected void OnBtnPreviousClicked(object sender, EventArgs e)
    {
      this.timer.Stop();
      if (this.currentImageIndex - 1 >= 0)
        this.currentImageIndex = this.currentImageIndex - 1;
      this.SetGuideInfo(this.currentImageIndex);
      this.ChangeButtonContent();
    }

    protected void OnBtnNextClicked(object sender, EventArgs e)
    {
      this.timer.Stop();
      if (this.currentImageIndex + 1 < this.imageListCount)
        this.currentImageIndex = this.currentImageIndex + 1;
      this.SetGuideInfo(this.currentImageIndex);
      if (this.btn_next.Label == LanguageInfo.guide_LastOne && this.currentImageIndex == this.imageListCount - 1)
        this.DeleteGuideUC();
      this.ChangeButtonContent();
    }

    private void DeleteGuideUC()
    {
      this.Destroy();
      this.Closed((object) this, (EventArgs) null);
    }

    protected void OnKeyDown(object o, KeyPressEventArgs args)
    {
      if (args.Event.Key != Gdk.Key.Escape)
        return;
      this.DeleteGuideUC();
    }

    protected virtual void Build()
    {
      Gui.Initialize((Widget) this);
      this.WidthRequest = 720;
      this.HeightRequest = 615;
      this.Name = "Modules.Communal.Guide.GuideUC";
      this.Title = Catalog.GetString("GuideUC");
      this.WindowPosition = WindowPosition.CenterOnParent;
      this.vbox_root = new VBox();
      this.vbox_root.Name = "vbox_root";
      this.vbox_root.Spacing = 6;
      this.label_occupy3 = new Label();
      this.label_occupy3.HeightRequest = 15;
      this.label_occupy3.Name = "label_occupy3";
      this.vbox_root.Add((Widget) this.label_occupy3);
      ((Box.BoxChild) this.vbox_root[(Widget) this.label_occupy3]).Position = 0;
      this.label_title = new Label();
      this.label_title.HeightRequest = 35;
      this.label_title.Name = "label_title";
      this.label_title.LabelProp = Catalog.GetString("label1");
      this.vbox_root.Add((Widget) this.label_title);
      Box.BoxChild boxChild1 = (Box.BoxChild) this.vbox_root[(Widget) this.label_title];
      boxChild1.Position = 1;
      boxChild1.Expand = false;
      boxChild1.Fill = false;
      this.imagebin1 = new ImageBin();
      this.imagebin1.WidthRequest = 720;
      this.imagebin1.HeightRequest = 480;
      this.imagebin1.Events = EventMask.ButtonPressMask;
      this.imagebin1.Name = "imagebin1";
      this.vbox_root.Add((Widget) this.imagebin1);
      Box.BoxChild boxChild2 = (Box.BoxChild) this.vbox_root[(Widget) this.imagebin1];
      boxChild2.Position = 2;
      boxChild2.Expand = false;
      boxChild2.Fill = false;
      this.hseparator1 = new HSeparator();
      this.hseparator1.Name = "hseparator1";
      this.vbox_root.Add((Widget) this.hseparator1);
      Box.BoxChild boxChild3 = (Box.BoxChild) this.vbox_root[(Widget) this.hseparator1];
      boxChild3.Position = 3;
      boxChild3.Expand = false;
      boxChild3.Fill = false;
      this.hbox_bottom = new HBox();
      this.hbox_bottom.Name = "hbox_bottom";
      this.hbox_checkBtnExpand = new HBox();
      this.hbox_checkBtnExpand.Name = "hbox_checkBtnExpand";
      this.hbox_checkBtnExpand.Spacing = 6;
      this.vbox_expand = new VBox();
      this.vbox_expand.Name = "vbox_expand";
      this.vbox_expand.Spacing = 6;
      this.cbtn_show = new CheckButton();
      this.cbtn_show.CanFocus = true;
      this.cbtn_show.Name = "cbtn_show";
      this.cbtn_show.Label = Catalog.GetString("下次打开时不再显示该窗口");
      this.cbtn_show.DrawIndicator = true;
      this.cbtn_show.UseUnderline = true;
      this.vbox_expand.Add((Widget) this.cbtn_show);
      Box.BoxChild boxChild4 = (Box.BoxChild) this.vbox_expand[(Widget) this.cbtn_show];
      boxChild4.Position = 0;
      boxChild4.Fill = false;
      this.hbox_checkBtnExpand.Add((Widget) this.vbox_expand);
      Box.BoxChild boxChild5 = (Box.BoxChild) this.hbox_checkBtnExpand[(Widget) this.vbox_expand];
      boxChild5.Position = 0;
      boxChild5.Expand = false;
      this.hbox_bottom.Add((Widget) this.hbox_checkBtnExpand);
      Box.BoxChild boxChild6 = (Box.BoxChild) this.hbox_bottom[(Widget) this.hbox_checkBtnExpand];
      boxChild6.Position = 0;
      boxChild6.Padding = 18U;
      this.vbox_btnPreviousBorder = new VBox();
      this.vbox_btnPreviousBorder.Name = "vbox_btnPreviousBorder";
      this.vbox_btnPreviousBorder.Spacing = 6;
      this.btn_previous = new Button();
      this.btn_previous.WidthRequest = 80;
      this.btn_previous.HeightRequest = 35;
      this.btn_previous.CanFocus = true;
      this.btn_previous.Name = "btn_previous";
      this.btn_previous.UseUnderline = true;
      this.btn_previous.Label = Catalog.GetString("GtkButton");
      this.vbox_btnPreviousBorder.Add((Widget) this.btn_previous);
      Box.BoxChild boxChild7 = (Box.BoxChild) this.vbox_btnPreviousBorder[(Widget) this.btn_previous];
      boxChild7.Position = 0;
      boxChild7.Fill = false;
      this.hbox_bottom.Add((Widget) this.vbox_btnPreviousBorder);
      Box.BoxChild boxChild8 = (Box.BoxChild) this.hbox_bottom[(Widget) this.vbox_btnPreviousBorder];
      boxChild8.Position = 1;
      boxChild8.Expand = false;
      boxChild8.Fill = false;
      this.vbox_btnNextBorder = new VBox();
      this.vbox_btnNextBorder.Name = "vbox_btnNextBorder";
      this.vbox_btnNextBorder.Spacing = 6;
      this.btn_next = new Button();
      this.btn_next.WidthRequest = 80;
      this.btn_next.HeightRequest = 35;
      this.btn_next.CanFocus = true;
      this.btn_next.Name = "btn_next";
      this.btn_next.UseUnderline = true;
      this.btn_next.Label = Catalog.GetString("GtkButton");
      this.vbox_btnNextBorder.Add((Widget) this.btn_next);
      Box.BoxChild boxChild9 = (Box.BoxChild) this.vbox_btnNextBorder[(Widget) this.btn_next];
      boxChild9.Position = 0;
      boxChild9.Expand = false;
      boxChild9.Fill = false;
      this.hbox_bottom.Add((Widget) this.vbox_btnNextBorder);
      Box.BoxChild boxChild10 = (Box.BoxChild) this.hbox_bottom[(Widget) this.vbox_btnNextBorder];
      boxChild10.Position = 2;
      boxChild10.Expand = false;
      boxChild10.Fill = false;
      boxChild10.Padding = 10U;
      this.label_occupy = new Label();
      this.label_occupy.Name = "label_occupy";
      this.hbox_bottom.Add((Widget) this.label_occupy);
      Box.BoxChild boxChild11 = (Box.BoxChild) this.hbox_bottom[(Widget) this.label_occupy];
      boxChild11.Position = 3;
      boxChild11.Expand = false;
      boxChild11.Fill = false;
      boxChild11.Padding = 10U;
      this.vbox_root.Add((Widget) this.hbox_bottom);
      Box.BoxChild boxChild12 = (Box.BoxChild) this.vbox_root[(Widget) this.hbox_bottom];
      boxChild12.Position = 4;
      boxChild12.Expand = false;
      boxChild12.Fill = false;
      boxChild12.Padding = 10U;
      this.Add((Widget) this.vbox_root);
      if (this.Child != null)
        this.Child.ShowAll();
      this.DefaultWidth = 738;
      this.DefaultHeight = 615;
      this.Show();
      this.KeyPressEvent += new KeyPressEventHandler(this.OnKeyDown);
      this.cbtn_show.Toggled += new EventHandler(this.OnCbtnToggled);
      this.btn_previous.Clicked += new EventHandler(this.OnBtnPreviousClicked);
      this.btn_next.Clicked += new EventHandler(this.OnBtnNextClicked);
    }
  }
}
