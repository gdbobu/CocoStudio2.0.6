// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Editor.SudukuEditor
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.ToolKit;
using Gtk;
using Gtk.Controls;
using MonoDevelop.Components;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.Editor
{
  public class SudukuEditor : BaseEditor, ITypeEditor
  {
    private Table _table;
    private CheckButtonEx _checkButton;
    private Table _sudukuTable;
    private EntryIntEx _left;
    private EntryIntEx _right;
    private EntryIntEx _top;
    private EntryIntEx _bottom;
    private Table _tableRight;
    private Table _tableBottom;
    private ImageView _imageWidget;

    public SudukuEditor(PropertyItem propertyItem)
      : base(propertyItem)
    {
    }

    public SudukuEditor()
      : base((PropertyItem) null)
    {
    }

    public Widget ResolveEditor(PropertyItem item = null)
    {
      this._table = new Table(2U, 1U, false);
      this._checkButton = new CheckButtonEx();
      this._checkButton.Label = "九宫格";
      this._sudukuTable = new Table(2U, 2U, false);
      this._tableRight = new Table(3U, 1U, false);
      this._tableBottom = new Table(1U, 3U, false);
      this._left = new EntryIntEx();
      this._left.Name = "left";
      this._right = new EntryIntEx();
      this._right.Name = "right";
      this._top = new EntryIntEx();
      this._top.Name = "top";
      this._bottom = new EntryIntEx();
      this._bottom.Name = "bottom";
      this._left.WidthRequest = this._right.WidthRequest = this._top.WidthRequest = this._bottom.WidthRequest = 30;
      this._left.IntegerNum = this._right.IntegerNum = this._top.IntegerNum = this._bottom.IntegerNum = 0;
      this._imageWidget = new ImageView();
      this._imageWidget.Image = ImageIcon.GetIcon("CocoStudio.DefaultResource.ComponentResource.Multi.png");
      this._tableRight.Attach((Widget) this._top, 0U, 1U, 0U, 1U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      Label label1 = new Label();
      label1.WidthRequest = 5;
      this._tableRight.Attach((Widget) label1, 0U, 1U, 1U, 2U, AttachOptions.Fill, AttachOptions.Expand, 0U, 0U);
      this._tableRight.Attach((Widget) this._bottom, 0U, 1U, 2U, 3U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this._tableRight.ShowAll();
      this._tableBottom.Attach((Widget) this._left, 0U, 1U, 0U, 1U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      Label label2 = new Label();
      label2.WidthRequest = 5;
      this._tableBottom.Attach((Widget) label2, 1U, 2U, 0U, 1U, AttachOptions.Fill, AttachOptions.Expand, 0U, 0U);
      this._tableBottom.Attach((Widget) this._right, 2U, 3U, 0U, 1U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this._tableBottom.ShowAll();
      this._sudukuTable.Attach((Widget) this._imageWidget, 0U, 1U, 0U, 1U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this._sudukuTable.Attach((Widget) this._tableRight, 1U, 2U, 0U, 1U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this._sudukuTable.Attach((Widget) this._tableBottom, 0U, 1U, 1U, 2U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this._sudukuTable.ShowAll();
      this._table.Attach((Widget) this._checkButton, 0U, 1U, 0U, 1U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this._table.Attach((Widget) this._sudukuTable, 0U, 1U, 1U, 2U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this._table.ShowAll();
      this._left.EntryValueChanged += new EventHandler<EntryIntEventArgs>(this.EntryValueChanged);
      this._right.EntryValueChanged += new EventHandler<EntryIntEventArgs>(this.EntryValueChanged);
      this._top.EntryValueChanged += new EventHandler<EntryIntEventArgs>(this.EntryValueChanged);
      this._top.EntryValueChanged += new EventHandler<EntryIntEventArgs>(this.EntryValueChanged);
      this._checkButton.Clicked += new EventHandler(this._checkButton_Clicked);
      return (Widget) this._table;
    }

    private void _checkButton_Clicked(object sender, EventArgs e)
    {
      this._sudukuTable.Sensitive = this._checkButton.Active;
    }

    private void EntryValueChanged(object sender, EntryIntEventArgs e)
    {
      EntryIntEx entryIntEx = sender as EntryIntEx;
      string empty = string.Empty;
      switch (entryIntEx.Name)
      {
        default:
          this._propertyItem.SetValue(empty, (object) e.Value, (object[]) null);
          break;
      }
    }

    public void EditorDispose()
    {
      this.Dispose();
    }

    public void RefreshData()
    {
      this.SetControl();
    }

    private void SetControl()
    {
      this._left.Value = (double) this._propertyItem.Instance.GetType().GetProperty("").GetValue(this._propertyItem.Instance, (object[]) null);
      this._right.Value = (double) this._propertyItem.Instance.GetType().GetProperty("").GetValue(this._propertyItem.Instance, (object[]) null);
      this._top.Value = (double) this._propertyItem.Instance.GetType().GetProperty("").GetValue(this._propertyItem.Instance, (object[]) null);
      this._bottom.Value = (double) this._propertyItem.Instance.GetType().GetProperty("").GetValue(this._propertyItem.Instance, (object[]) null);
    }

    protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
    }
  }
}
