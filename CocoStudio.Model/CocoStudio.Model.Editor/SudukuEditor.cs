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

		public SudukuEditor(PropertyItem propertyItem) : base(propertyItem)
		{
		}

		public SudukuEditor() : base(null)
		{
		}

		public Widget ResolveEditor(PropertyItem item = null)
		{
			this._table = new Table(2u, 1u, false);
			this._checkButton = new CheckButtonEx();
			this._checkButton.Label = "九宫格";
			this._sudukuTable = new Table(2u, 2u, false);
			this._tableRight = new Table(3u, 1u, false);
			this._tableBottom = new Table(1u, 3u, false);
			this._left = new EntryIntEx();
			this._left.Name = "left";
			this._right = new EntryIntEx();
			this._right.Name = "right";
			this._top = new EntryIntEx();
			this._top.Name = "top";
			this._bottom = new EntryIntEx();
			this._bottom.Name = "bottom";
			this._left.WidthRequest = (this._right.WidthRequest = (this._top.WidthRequest = (this._bottom.WidthRequest = 30)));
			this._left.IntegerNum = (this._right.IntegerNum = (this._top.IntegerNum = (this._bottom.IntegerNum = 0)));
			this._imageWidget = new ImageView();
			this._imageWidget.Image = ImageIcon.GetIcon("CocoStudio.DefaultResource.ComponentResource.Multi.png");
			this._tableRight.Attach(this._top, 0u, 1u, 0u, 1u, AttachOptions.Fill, AttachOptions.Fill, 0u, 0u);
			Label label = new Label();
			label.WidthRequest = 5;
			this._tableRight.Attach(label, 0u, 1u, 1u, 2u, AttachOptions.Fill, AttachOptions.Expand, 0u, 0u);
			this._tableRight.Attach(this._bottom, 0u, 1u, 2u, 3u, AttachOptions.Fill, AttachOptions.Fill, 0u, 0u);
			this._tableRight.ShowAll();
			this._tableBottom.Attach(this._left, 0u, 1u, 0u, 1u, AttachOptions.Fill, AttachOptions.Fill, 0u, 0u);
			Label label2 = new Label();
			label2.WidthRequest = 5;
			this._tableBottom.Attach(label2, 1u, 2u, 0u, 1u, AttachOptions.Fill, AttachOptions.Expand, 0u, 0u);
			this._tableBottom.Attach(this._right, 2u, 3u, 0u, 1u, AttachOptions.Fill, AttachOptions.Fill, 0u, 0u);
			this._tableBottom.ShowAll();
			this._sudukuTable.Attach(this._imageWidget, 0u, 1u, 0u, 1u, AttachOptions.Fill, AttachOptions.Fill, 0u, 0u);
			this._sudukuTable.Attach(this._tableRight, 1u, 2u, 0u, 1u, AttachOptions.Fill, AttachOptions.Fill, 0u, 0u);
			this._sudukuTable.Attach(this._tableBottom, 0u, 1u, 1u, 2u, AttachOptions.Fill, AttachOptions.Fill, 0u, 0u);
			this._sudukuTable.ShowAll();
			this._table.Attach(this._checkButton, 0u, 1u, 0u, 1u, AttachOptions.Fill, AttachOptions.Fill, 0u, 0u);
			this._table.Attach(this._sudukuTable, 0u, 1u, 1u, 2u, AttachOptions.Fill, AttachOptions.Fill, 0u, 0u);
			this._table.ShowAll();
			this._left.EntryValueChanged += new EventHandler<EntryIntEventArgs>(this.EntryValueChanged);
			this._right.EntryValueChanged += new EventHandler<EntryIntEventArgs>(this.EntryValueChanged);
			this._top.EntryValueChanged += new EventHandler<EntryIntEventArgs>(this.EntryValueChanged);
			this._top.EntryValueChanged += new EventHandler<EntryIntEventArgs>(this.EntryValueChanged);
			this._checkButton.Clicked += new EventHandler(this._checkButton_Clicked);
			return this._table;
		}

		private void _checkButton_Clicked(object sender, EventArgs e)
		{
			this._sudukuTable.Sensitive = this._checkButton.Active;
		}

		private void EntryValueChanged(object sender, EntryIntEventArgs e)
		{
			EntryIntEx entryIntEx = sender as EntryIntEx;
			string empty = string.Empty;
			string name = entryIntEx.Name;
			if (name != null)
			{
				if (!(name == "top"))
				{
					if (!(name == "bottom"))
					{
						if (!(name == "left"))
						{
							if (!(name == "right"))
							{
							}
						}
					}
				}
			}
			this._propertyItem.SetValue(empty, e.Value, null);
		}

		public void EditorDispose()
		{
			base.Dispose();
		}

		public void RefreshData()
		{
			this.SetControl();
		}

		private void SetControl()
		{
			this._left.Value = (double)this._propertyItem.Instance.GetType().GetProperty("").GetValue(this._propertyItem.Instance, null);
			this._right.Value = (double)this._propertyItem.Instance.GetType().GetProperty("").GetValue(this._propertyItem.Instance, null);
			this._top.Value = (double)this._propertyItem.Instance.GetType().GetProperty("").GetValue(this._propertyItem.Instance, null);
			this._bottom.Value = (double)this._propertyItem.Instance.GetType().GetProperty("").GetValue(this._propertyItem.Instance, null);
		}

		protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
		}
	}
}
