using CocoStudio.ToolKit;
using Gtk;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace CocoStudio.Model.Editor
{
	public class UIListViewEditor : BaseEditor, ITypeEditor
	{
		private UIListViewEditorWidget widget;

		private IListViewType CurrentValue;

		private List<string> PropertyName;

		public UIListViewEditor(PropertyItem propertyItem) : base(propertyItem)
		{
		}

		public UIListViewEditor() : base(null)
		{
		}

		public Widget ResolveEditor(PropertyItem item = null)
		{
			this.widget = new UIListViewEditorWidget();
			this.PropertyName = new List<string>();
			this.widget.Init(Enum.GetNames(typeof(ListViewDirectionType)), Enum.GetNames(typeof(ListViewHorizontal)), Enum.GetNames(typeof(ListViewVertical)));
			this.CurrentValue = (this._propertyItem.Instance as IListViewType);
			this.SetControl();
			this.CreatePropertyNameList();
			this.widget.ValueChanged += new EventHandler<ListViewEvent>(this.widget_ValueChanged);
			return this.widget;
		}

		private void widget_ValueChanged(object sender, ListViewEvent e)
		{
			this.UpDateData(delegate
			{
				switch (e.TialType)
				{
				case 0:
					this.CurrentValue.DirectionType = e.NumType + ListViewDirectionType.Vertical;
					break;
				case 1:
					this.CurrentValue.HorizontalType = (ListViewHorizontal)e.NumType;
					break;
				case 2:
					this.CurrentValue.VerticalType = e.NumType + ListViewVertical.Align_Top;
					break;
				}
			});
		}

		public void SetControl()
		{
			this.widget.SetValue(delegate
			{
				this.widget.SetControl(this.CurrentValue.DirectionType - ListViewDirectionType.Vertical, (int)this.CurrentValue.HorizontalType, (int)this.CurrentValue.VerticalType);
			});
		}

		protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			foreach (string current in this.PropertyName)
			{
				if (e.PropertyName == current)
				{
					this.UpDateData(delegate
					{
						this.SetControl();
					});
				}
			}
		}

		private void CreatePropertyNameList()
		{
			MemberInfo[] members = this.CurrentValue.GetType().GetMembers();
			MemberInfo[] array = members;
			for (int i = 0; i < array.Length; i++)
			{
				MemberInfo memberInfo = array[i];
				this.PropertyName.Add(memberInfo.Name);
			}
		}

		public void EditorDispose()
		{
			base.Dispose();
		}

		public void RefreshData()
		{
			this.SetControl();
		}
	}
}
