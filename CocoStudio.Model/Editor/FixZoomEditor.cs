// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Editor.FixZoomEditor
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.ToolKit;
using Gtk;
using System;
using System.ComponentModel;
using System.Timers;

namespace CocoStudio.Model.Editor
{
  public class FixZoomEditor : BaseEditor, ITypeEditor
  {
    private FixZoom animation = new FixZoom();
    private Timer timer;
    private Table table;
    private Table firTable;
    private Table secTable;
    private ToggleButton top;
    private ToggleButton bottom;
    private ToggleButton left;
    private ToggleButton right;
    private ToggleButton center;

    public FixZoomEditor(PropertyItem propertyItem)
      : base(propertyItem)
    {
    }

    public FixZoomEditor()
      : base((PropertyItem) null)
    {
    }

    public Widget ResolveEditor(PropertyItem item = null)
    {
      this.table = new Table(1U, 2U, false);
      this.firTable = new Table(3U, 3U, false);
      this.secTable = new Table(1U, 1U, false);
      this.top = new ToggleButton("top");
      this.top.Name = "top";
      this.bottom = new ToggleButton("bottom");
      this.bottom.Name = "bottom";
      this.left = new ToggleButton("left");
      this.left.Name = "left";
      this.right = new ToggleButton("right");
      this.right.Name = "right";
      this.center = new ToggleButton("center");
      this.center.Name = "center";
      this.top.WidthRequest = this.bottom.WidthRequest = this.left.WidthRequest = this.right.WidthRequest = this.center.WidthRequest = 60;
      this.top.HeightRequest = this.bottom.HeightRequest = this.left.HeightRequest = this.right.HeightRequest = this.center.HeightRequest = 30;
      this.top.Clicked += new EventHandler(this.button_Clicked);
      this.bottom.Clicked += new EventHandler(this.button_Clicked);
      this.left.Clicked += new EventHandler(this.button_Clicked);
      this.right.Clicked += new EventHandler(this.button_Clicked);
      this.center.Clicked += new EventHandler(this.button_Clicked);
      this.firTable.Attach((Widget) this.top, 1U, 2U, 0U, 1U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this.firTable.Attach((Widget) this.bottom, 1U, 2U, 2U, 3U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this.firTable.Attach((Widget) this.left, 0U, 1U, 1U, 2U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this.firTable.Attach((Widget) this.right, 2U, 3U, 1U, 2U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this.firTable.Attach((Widget) this.center, 1U, 2U, 1U, 2U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this.firTable.ShowAll();
      this.animation.WidthRequest = 92;
      this.animation.HeightRequest = 52;
      this.secTable.Attach((Widget) this.animation, 0U, 1U, 0U, 1U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this.secTable.ShowAll();
      this.table.Attach((Widget) this.firTable, 0U, 1U, 0U, 1U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this.table.Attach((Widget) this.secTable, 1U, 2U, 0U, 1U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this.table.ShowAll();
      this.timer = new Timer();
      this.timer.Elapsed += new ElapsedEventHandler(this.timer_Elapsed);
      this.timer.Interval = 100.0;
      this.timer.Start();
      return (Widget) this.table;
    }

    private void button_Clicked(object sender, EventArgs e)
    {
      ToggleButton toggleButton = sender as ToggleButton;
      switch (toggleButton.Label)
      {
        case "top":
          this.animation.IsTop = toggleButton.Active;
          break;
        case "bottom":
          this.animation.IsBottom = toggleButton.Active;
          break;
        case "left":
          this.animation.IsLeft = toggleButton.Active;
          break;
        case "right":
          this.animation.IsRight = toggleButton.Active;
          break;
        case "center":
          this.animation.IsCenter = toggleButton.Active;
          break;
      }
    }

    private void SetControl()
    {
    }

    private void timer_Elapsed(object sender, ElapsedEventArgs e)
    {
      this.animation.QueueDraw();
    }

    public void EditorDispose()
    {
      this.Dispose();
    }

    public void RefreshData()
    {
      this.SetControl();
    }

    protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
    }
  }
}
