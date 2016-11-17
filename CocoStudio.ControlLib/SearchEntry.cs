// Decompiled with JetBrains decompiler
// Type: CocoStudio.ControlLib.SearchEntry
// Assembly: CocoStudio.ControlLib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 677D14F9-F98B-4FDA-9ECD-6C6F82FD30A1
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ControlLib.dll

using Gdk;
using GLib;
using Gtk;
using MonoDevelop.Components;
using MonoDevelop.Ide.Gui;
using System;
using System.ComponentModel;
using Xwt.GtkBackend;

namespace CocoStudio.ControlLib
{
  [ToolboxItem(true)]
  public class SearchEntry : EventBox
  {
    private int active_filter_id = -1;
    private uint changed_timeout_id = 0;
    private bool ready = false;
    private bool hasFrame = true;
    private bool customRoundedShapeDrawing = false;
    private bool forceFilterButtonVisible = true;
    private bool toggling = false;
    private Gtk.Alignment alignment;
    private Gtk.Alignment entryAlignment;
    private HBox box;
    private Entry entry;
    private CSImageButton filter_button;
    private CSImageButton clear_button;
    private Menu menu;
    private string empty_message;
    private EventHandler activated_event;
    private bool roundedShape;
    private EventBox statusLabelEventBox;

    public bool ForceFilterButtonVisible
    {
      get
      {
        return this.forceFilterButtonVisible;
      }
      set
      {
        this.forceFilterButtonVisible = value;
        this.ShowHideButtons();
      }
    }

    public Menu Menu
    {
      get
      {
        return this.menu;
      }
      set
      {
        this.menu = value;
        this.menu.Deactivated += new EventHandler(this.OnMenuDeactivated);
      }
    }

    public Entry Entry
    {
      get
      {
        return this.entry;
      }
    }

    public bool HasFrame
    {
      get
      {
        return this.hasFrame;
      }
      set
      {
        this.hasFrame = value;
        this.QueueDraw();
      }
    }

    public bool RoundedShape
    {
      get
      {
        return this.roundedShape;
      }
      set
      {
        this.roundedShape = value;
        if (value)
          this.entry.Name = "search-entry";
        else
          this.entry.Name = "";
        this.ShowHideButtons();
        this.QueueDraw();
      }
    }

    public Xwt.Drawing.Image FilterButtonPixbuf
    {
      get
      {
        return this.filter_button.Image;
      }
      set
      {
        this.filter_button.Image = value;
      }
    }

    public Xwt.Drawing.Image ClearButtonPixbuf
    {
      get
      {
        return this.clear_button.Image;
      }
      set
      {
        this.clear_button.Image = value;
      }
    }

    public bool IsCheckMenu { get; set; }

    public int ActiveFilterID
    {
      get
      {
        return this.active_filter_id;
      }
      set
      {
        if (value == this.active_filter_id)
          return;
        this.active_filter_id = value;
        this.OnFilterChanged();
      }
    }

    public string EmptyMessage
    {
      get
      {
        return this.entry.Sensitive ? this.empty_message : string.Empty;
      }
      set
      {
        this.empty_message = value;
        this.entry.QueueDraw();
      }
    }

    public string Query
    {
      get
      {
        return this.entry.Text.Trim();
      }
      set
      {
        this.entry.Text = value.Trim();
      }
    }

    public bool IsQueryAvailable
    {
      get
      {
        return this.Query != null && this.Query != string.Empty;
      }
    }

    public bool Ready
    {
      get
      {
        return this.ready;
      }
      set
      {
        this.ready = value;
      }
    }

    public new bool HasFocus
    {
      get
      {
        return this.entry.HasFocus;
      }
      set
      {
        this.entry.HasFocus = true;
      }
    }

    public Entry InnerEntry
    {
      get
      {
        return this.entry;
      }
    }

    private event EventHandler filter_changed;

    private event EventHandler entry_changed;

    public event EventHandler Changed
    {
      add
      {
        this.entry_changed += value;
      }
      remove
      {
        this.entry_changed -= value;
      }
    }

    public event EventHandler Activated
    {
      add
      {
        this.activated_event += value;
      }
      remove
      {
        this.activated_event -= value;
      }
    }

    public event EventHandler FilterChanged
    {
      add
      {
        this.filter_changed += value;
      }
      remove
      {
        this.filter_changed -= value;
      }
    }

    public event EventHandler RequestMenu;

    public SearchEntry()
    {
      this.AppPaintable = true;
      this.BuildWidget();
      this.BuildMenu();
      this.InitButtonPixbuf();
      this.NoShowAll = true;
    }

    private void InitButtonPixbuf()
    {
      this.filter_button.Image = ImageIcon.GetIcon("CocoStudio.DefaultResource.ResourcePanelResource.search.png");
      this.clear_button.Image = ImageIcon.GetIcon("CocoStudio.DefaultResource.ResourcePanelResource.Close.png");
      Gdk.Color backGroundColor = this.filter_button.ImageWidget.BackGroundColor;
      Gdk.Color focusBackGroundColor = this.filter_button.ImageWidget.FocusBackGroundColor;
      this.filter_button.ImageWidget.BackGroundColor = focusBackGroundColor;
      this.filter_button.ImageWidget.FocusBackGroundColor = backGroundColor;
      this.clear_button.ImageWidget.BackGroundColor = focusBackGroundColor;
      this.clear_button.ImageWidget.FocusBackGroundColor = backGroundColor;
    }

    private void BuildWidget()
    {
      float yscale = 0.0f;
      if (MonoDevelop.Core.Platform.IsWindows)
        yscale = (float) GtkWorkarounds.GetScaleFactor((Widget) this);
      this.alignment = new Gtk.Alignment(0.5f, 0.5f, 1f, yscale);
      this.alignment.SetPadding(1U, 1U, 0U, 0U);
      this.VisibleWindow = false;
      this.box = new HBox();
      this.entry = (Entry) new SearchEntry.FramelessEntry(this);
      this.filter_button = new CSImageButton();
      this.clear_button = new CSImageButton();
      this.entryAlignment = new Gtk.Alignment(0.5f, 0.5f, 1f, 1f);
      this.alignment.SetPadding(0U, 0U, 0U, 0U);
      this.entryAlignment.Add((Widget) this.entry);
      this.box.PackStart((Widget) this.filter_button, false, false, 0U);
      this.box.PackStart((Widget) this.entryAlignment, true, true, 0U);
      this.box.PackStart((Widget) this.clear_button, false, false, 0U);
      this.alignment.Add((Widget) this.box);
      this.Add((Widget) this.alignment);
      this.alignment.ShowAll();
      this.entry.StyleSet += new StyleSetHandler(this.OnInnerEntryStyleSet);
      this.entry.StateChanged += new StateChangedHandler(this.OnInnerEntryStateChanged);
      this.entry.FocusInEvent += new FocusInEventHandler(this.OnInnerEntryFocusEvent);
      this.entry.FocusOutEvent += new FocusOutEventHandler(this.OnInnerEntryFocusEvent);
      this.entry.Changed += new EventHandler(this.OnInnerEntryChanged);
      this.entry.Activated += (EventHandler) ((param0, param1) => this.NotifyActivated());
      this.filter_button.CanFocus = false;
      this.clear_button.CanFocus = false;
      this.filter_button.ButtonReleaseEvent += new ButtonReleaseEventHandler(this.OnButtonReleaseEvent);
      this.clear_button.ButtonReleaseEvent += new ButtonReleaseEventHandler(this.OnButtonReleaseEvent);
      this.clear_button.Clicked += new EventHandler(this.OnClearButtonClicked);
      this.ShowHideButtons();
    }

    protected override void OnSizeRequested(ref Requisition requisition)
    {
      if (this.HeightRequest != -1 && this.box.HeightRequest != this.HeightRequest)
        this.box.HeightRequest = this.HeightRequest;
      if (this.box.HeightRequest != -1 && this.HeightRequest == -1)
        this.box.HeightRequest = -1;
      base.OnSizeRequested(ref requisition);
    }

    public EventBox AddLabelWidget(Label label)
    {
      this.box.Remove((Widget) this.clear_button);
      this.statusLabelEventBox = new EventBox();
      this.statusLabelEventBox.Child = (Widget) label;
      this.box.PackStart((Widget) this.statusLabelEventBox, false, false, 0U);
      this.box.PackStart((Widget) this.clear_button, false, false, 0U);
      this.UpdateStyle();
      this.box.ShowAll();
      return this.statusLabelEventBox;
    }

    private void NotifyActivated()
    {
      if (this.activated_event == null)
        return;
      this.activated_event((object) this, EventArgs.Empty);
    }

    private void BuildMenu()
    {
      this.menu = new Menu();
      this.menu.Deactivated += new EventHandler(this.OnMenuDeactivated);
    }

    public void PopupFilterMenu()
    {
      this.ShowMenu(0U);
    }

    private void ShowMenu(uint time)
    {
      this.OnRequestMenu(EventArgs.Empty);
      if (this.menu.Children.Length <= 0)
        return;
      this.menu.Popup((Widget) null, (Widget) null, new MenuPositionFunc(this.OnPositionMenu), 0U, time);
      this.menu.ShowAll();
    }

    private void ShowHideButtons()
    {
      this.clear_button.Visible = this.entry.Text.Length > 0;
      this.entryAlignment.RightPadding = this.clear_button.Visible || !this.roundedShape ? 0U : 6U;
      this.filter_button.Visible = this.ForceFilterButtonVisible || this.menu != null && this.menu.Children.Length > 0;
      this.entryAlignment.LeftPadding = this.filter_button.Visible || !this.roundedShape ? 0U : 6U;
    }

    private void OnPositionMenu(Menu menu, out int x, out int y, out bool push_in)
    {
      int x1;
      int num;
      this.filter_button.GdkWindow.GetOrigin(out x1, out num);
      int y1;
      this.GdkWindow.GetOrigin(out num, out y1);
      x = x1 + this.filter_button.Allocation.X;
      y = y1 + this.Allocation.Y + this.SizeRequest().Height;
      push_in = true;
    }

    private void OnMenuDeactivated(object o, EventArgs args)
    {
      this.filter_button.QueueDraw();
    }

    private void OnMenuItemToggled(object o, EventArgs args)
    {
      if (this.IsCheckMenu || this.toggling || !(o is SearchEntry.FilterMenuItem))
        return;
      this.toggling = true;
      SearchEntry.FilterMenuItem filterMenuItem1 = (SearchEntry.FilterMenuItem) o;
      foreach (MenuItem menuItem in (Gtk.Container) this.menu)
      {
        if (menuItem is SearchEntry.FilterMenuItem)
        {
          SearchEntry.FilterMenuItem filterMenuItem2 = (SearchEntry.FilterMenuItem) menuItem;
          if (filterMenuItem2 != filterMenuItem1)
            filterMenuItem2.Active = false;
        }
      }
      filterMenuItem1.Active = true;
      this.ActiveFilterID = filterMenuItem1.ID;
      this.toggling = false;
    }

    private void OnInnerEntryChanged(object o, EventArgs args)
    {
      this.ShowHideButtons();
      if (this.changed_timeout_id > 0U)
        Source.Remove(this.changed_timeout_id);
      if (!this.Ready)
        return;
      this.changed_timeout_id = GLib.Timeout.Add(25U, new TimeoutHandler(this.OnChangedTimeout));
    }

    private bool OnChangedTimeout()
    {
      this.OnChanged();
      return false;
    }

    private void UpdateStyle()
    {
      Gdk.Color color = this.entry.Style.Base(this.entry.State);
      this.filter_button.ModifyBg(this.entry.State, color);
      this.clear_button.ModifyBg(this.entry.State, color);
      if (this.statusLabelEventBox != null)
        this.statusLabelEventBox.ModifyBg(this.entry.State, color);
      this.box.BorderWidth = 0U;
      int num = this.entry.SizeRequest().Height + this.entry.Style.Ythickness * 2 - Math.Max(Math.Max(this.entry.SizeRequest().Height, this.filter_button.SizeRequest().Height), this.clear_button.SizeRequest().Height);
      if (num <= 1)
        return;
      this.box.BorderWidth = (uint) (num / 2);
    }

    private void OnInnerEntryStyleSet(object o, StyleSetArgs args)
    {
      this.UpdateStyle();
    }

    private void OnInnerEntryStateChanged(object o, EventArgs args)
    {
      this.UpdateStyle();
    }

    private void OnInnerEntryFocusEvent(object o, EventArgs args)
    {
      this.QueueDraw();
    }

    private void OnButtonReleaseEvent(object o, ButtonReleaseEventArgs args)
    {
      if ((int) args.Event.Button != 1)
        return;
      this.entry.HasFocus = true;
      if (o != this.filter_button)
        return;
      this.ShowMenu(args.Event.Time);
    }

    protected virtual void OnRequestMenu(EventArgs e)
    {
      EventHandler requestMenu = this.RequestMenu;
      if (requestMenu == null)
        return;
      requestMenu((object) this, e);
    }

    public void GrabFocusEntry()
    {
      this.entry.GrabFocus();
    }

    private void OnClearButtonClicked(object o, EventArgs args)
    {
      this.active_filter_id = 0;
      this.entry.Text = string.Empty;
      this.NotifyActivated();
    }

    protected override void OnDestroyed()
    {
      if (this.menu != null)
      {
        this.menu.Destroy();
        this.menu = (Menu) null;
      }
      base.OnDestroyed();
    }

    protected override bool OnKeyPressEvent(EventKey evnt)
    {
      if (evnt.Key != Gdk.Key.Escape)
        return base.OnKeyPressEvent(evnt);
      this.active_filter_id = 0;
      this.entry.Text = string.Empty;
      this.NotifyActivated();
      return true;
    }

    protected override bool OnExposeEvent(EventExpose evnt)
    {
      Gdk.Rectangle rectangle = new Gdk.Rectangle(this.alignment.Allocation.X, this.box.Allocation.Y, this.alignment.Allocation.Width, this.box.Allocation.Height);
      if (this.hasFrame && (!this.roundedShape || this.roundedShape && !this.customRoundedShapeDrawing))
        Gtk.Style.PaintShadow(this.entry.Style, (Drawable) this.GdkWindow, StateType.Normal, ShadowType.In, evnt.Area, (Widget) this.entry, "entry", rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
      else if (!this.roundedShape)
      {
        using (Cairo.Context cr = Gdk.CairoHelper.Create((Drawable) this.GdkWindow))
        {
          cr.RoundedRectangle((double) rectangle.X + 0.5, (double) rectangle.Y + 0.5, (double) (rectangle.Width - 1), (double) (rectangle.Height - 1), 4.0);
          HelperMethods.SetSourceColor(cr, this.entry.Style.Base(StateType.Normal).ToCairoColor());
          cr.Fill();
        }
      }
      else
      {
        using (Cairo.Context context = Gdk.CairoHelper.Create((Drawable) this.GdkWindow))
        {
          SearchEntry.RoundBorder(context, (double) rectangle.X + 0.5, (double) rectangle.Y + 0.5, (double) (rectangle.Width - 1), (double) (rectangle.Height - 1));
          HelperMethods.SetSourceColor(context, this.entry.Style.Base(StateType.Normal).ToCairoColor());
          context.Fill();
        }
      }
      this.PropagateExpose(this.Child, evnt);
      if (this.hasFrame && this.roundedShape && this.customRoundedShapeDrawing)
      {
        using (Cairo.Context context = Gdk.CairoHelper.Create((Drawable) this.GdkWindow))
        {
          SearchEntry.RoundBorder(context, (double) rectangle.X + 0.5, (double) rectangle.Y + 0.5, (double) (rectangle.Width - 1), (double) (rectangle.Height - 1));
          HelperMethods.SetSourceColor(context, Styles.WidgetBorderColor);
          context.LineWidth = 1.0;
          context.Stroke();
        }
      }
      return true;
    }

    private static void RoundBorder(Cairo.Context ctx, double x, double y, double w, double h)
    {
      double radius = h / 2.0;
      ctx.Arc(x + radius, y + radius, radius, Math.PI / 2.0, 3.0 * Math.PI / 2.0);
      ctx.LineTo(x + w - radius, y);
      ctx.Arc(x + w - radius, y + radius, radius, 3.0 * Math.PI / 2.0, 5.0 * Math.PI / 2.0);
      ctx.LineTo(x + radius, y + h);
      ctx.ClosePath();
    }

    protected override void OnShown()
    {
      base.OnShown();
      this.ShowHideButtons();
    }

    protected virtual void OnChanged()
    {
      if (!this.Ready)
        return;
      EventHandler entryChanged = this.entry_changed;
      if (entryChanged == null)
        return;
      entryChanged((object) this, EventArgs.Empty);
    }

    protected virtual void OnFilterChanged()
    {
      EventHandler filterChanged = this.filter_changed;
      if (filterChanged != null)
        filterChanged((object) this, EventArgs.Empty);
      if (!this.IsQueryAvailable)
        return;
      this.OnInnerEntryChanged((object) this, EventArgs.Empty);
    }

    public CheckMenuItem AddFilterOption(int id, string label)
    {
      if (id < 0)
        throw new ArgumentException("id", "must be >= 0");
      SearchEntry.FilterMenuItem filterMenuItem = new SearchEntry.FilterMenuItem(id, label);
      filterMenuItem.Toggled += new EventHandler(this.OnMenuItemToggled);
      this.menu.Append((Widget) filterMenuItem);
      if (this.ActiveFilterID < 0)
        filterMenuItem.Toggle();
      this.filter_button.Visible = true;
      return (CheckMenuItem) filterMenuItem;
    }

    public MenuItem AddMenuItem(string label)
    {
      MenuItem menuItem = new MenuItem(label);
      this.menu.Append((Widget) menuItem);
      return menuItem;
    }

    public void AddFilterSeparator()
    {
      this.menu.Append((Widget) new SeparatorMenuItem());
    }

    public void RemoveFilterOption(int id)
    {
      SearchEntry.FilterMenuItem filterMenuItem = this.FindFilterMenuItem(id);
      if (filterMenuItem == null)
        return;
      this.menu.Remove((Widget) filterMenuItem);
    }

    public void ActivateFilter(int id)
    {
      SearchEntry.FilterMenuItem filterMenuItem = this.FindFilterMenuItem(id);
      if (filterMenuItem == null)
        return;
      filterMenuItem.Toggle();
    }

    private SearchEntry.FilterMenuItem FindFilterMenuItem(int id)
    {
      foreach (MenuItem menuItem in (Gtk.Container) this.menu)
      {
        if (menuItem is SearchEntry.FilterMenuItem && ((SearchEntry.FilterMenuItem) menuItem).ID == id)
          return (SearchEntry.FilterMenuItem) menuItem;
      }
      return (SearchEntry.FilterMenuItem) null;
    }

    public string GetLabelForFilterID(int id)
    {
      SearchEntry.FilterMenuItem filterMenuItem = this.FindFilterMenuItem(id);
      if (filterMenuItem == null)
        return (string) null;
      return filterMenuItem.Label;
    }

    public void CancelSearch()
    {
      this.entry.Text = string.Empty;
      this.ActivateFilter(0);
    }

    protected override void OnStateChanged(StateType previous_state)
    {
      base.OnStateChanged(previous_state);
      this.entry.Sensitive = this.State != StateType.Insensitive;
      this.filter_button.Sensitive = this.State != StateType.Insensitive;
      this.clear_button.Sensitive = this.State != StateType.Insensitive;
    }

    private class FilterMenuItem : CheckMenuItem
    {
      private int id;
      private string label;

      public int ID
      {
        get
        {
          return this.id;
        }
      }

      public string Label
      {
        get
        {
          return this.label;
        }
      }

      public new event EventHandler Toggled;

      public FilterMenuItem(int id, string label)
        : base(label)
      {
        this.id = id;
        this.label = label;
        this.DrawAsRadio = true;
      }

      protected override void OnActivated()
      {
        base.OnActivated();
        if (this.Toggled == null)
          return;
        this.Toggled((object) this, EventArgs.Empty);
      }
    }

    private class FramelessEntry : Entry
    {
      private SearchEntry parent;
      private Pango.Layout layout;
      private Gdk.GC text_gc;

      public FramelessEntry(SearchEntry parent)
      {
        this.parent = parent;
        this.HasFrame = false;
        parent.StyleSet += new StyleSetHandler(this.OnParentStyleSet);
        this.WidthChars = 1;
      }

      private void OnParentStyleSet(object o, EventArgs args)
      {
        this.RefreshGC();
        this.QueueDraw();
      }

      private void RefreshGC()
      {
        this.text_gc = (Gdk.GC) null;
      }

      protected override void OnDestroyed()
      {
        this.parent.StyleSet -= new StyleSetHandler(this.OnParentStyleSet);
        base.OnDestroyed();
      }

      public static Gdk.Color ColorBlend(Gdk.Color a, Gdk.Color b)
      {
        double num1 = 0.5;
        if (num1 < 0.0 || num1 > 1.0)
          throw new ApplicationException("blend < 0.0 || blend > 1.0");
        double num2 = 1.0 - num1;
        int num3 = (int) a.Red >> 8;
        int num4 = (int) a.Green >> 8;
        int num5 = (int) a.Blue >> 8;
        int num6 = (int) b.Red >> 8;
        int num7 = (int) b.Green >> 8;
        int num8 = (int) b.Blue >> 8;
        double num9 = (double) (num3 + num6);
        double num10 = (double) (num4 + num7);
        double num11 = (double) (num5 + num8);
        Gdk.Color color = new Gdk.Color((byte) (num9 * num2), (byte) (num10 * num2), (byte) (num11 * num2));
        Colormap.System.AllocColor(ref color, true, true);
        return color;
      }

      protected override bool OnExposeEvent(EventExpose evnt)
      {
        if (evnt.Window == this.GdkWindow)
          return true;
        bool flag = base.OnExposeEvent(evnt);
        if (this.text_gc == null)
        {
          this.text_gc = new Gdk.GC((Drawable) evnt.Window);
          this.text_gc.Copy(this.Style.TextGC(StateType.Normal));
          this.text_gc.RgbFgColor = SearchEntry.FramelessEntry.ColorBlend(this.parent.Style.Base(StateType.Normal), this.parent.Style.Text(StateType.Normal));
        }
        if (this.Text.Length > 0 || this.HasFocus || this.parent.EmptyMessage == null)
          return flag;
        if (this.layout == null)
        {
          this.layout = new Pango.Layout(this.PangoContext);
          this.layout.FontDescription = this.PangoContext.FontDescription.Copy();
        }
        this.layout.SetMarkup(this.parent.EmptyMessage);
        int width;
        int height;
        this.layout.GetPixelSize(out width, out height);
        evnt.Window.DrawLayout(this.text_gc, 2, (this.SizeRequest().Height - height) / 2, this.layout);
        return flag;
      }

      protected override bool OnButtonPressEvent(EventButton evnt)
      {
        if ((int) evnt.Button == 3)
          return false;
        return base.OnButtonPressEvent(evnt);
      }
    }
  }
}
