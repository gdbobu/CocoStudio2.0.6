using CocoStudio.Basic;
using CocoStudio.EngineAdapterWrap;
using CocoStudio.ToolKit;
using CocoStudio.UndoManager;
using PostSharp.Aspects;
using PostSharp.Aspects.Internals;
using PostSharp.ImplementationDetails_c065fe4d;
using PostSharp.Reflection;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace CocoStudio.Model.ViewModel
{
    [Serializable]
    public class WidgetObject : NodeObject
	{

        public bool TouchEnable { get; set; }

		[CompilerGenerated]
		private sealed class <TouchEnable>c__Binding : LocationBinding<bool>
		{
			public static WidgetObject.<TouchEnable>c__Binding singleton = new WidgetObject.<TouchEnable>c__Binding();

			[DebuggerNonUserCode]
			private <TouchEnable>c__Binding()
			{
			}

			public override DeclarationIdentifier get_DeclarationIdentifier()
			{
				return new DeclarationIdentifier(-4582977439099322367L);
			}

			public override LocationInfo get_LocationInfo()
			{
				return <>z__a_1._2;
			}

			public override void SetValue(ref object instance, Arguments index, bool value, object aspectArgs)
			{
				WidgetObject widgetObject = (WidgetObject)instance;
				if (widgetObject.GetInnerWidget().GetTouchEnabled() != value)
				{
					widgetObject.GetInnerWidget().SetTouchEnabled(value);
					widgetObject.RaisePropertyChanged<bool>(() => widgetObject.TouchEnable);
				}
			}

			public override bool GetValue(ref object instance, Arguments index, object aspectArgs)
			{
				return ((WidgetObject)instance).<get_TouchEnable>z__OriginalMethod();
			}
		}

		private EnumCallBack callBackType = EnumCallBack.None;

		protected string callBackName = "";

		[Browsable(false)]
		public CSWidget CustomWidgetInstance
		{
			get;
			private set;
		}

		[PropertyOrder(2), UndoProperty, Browsable(true), Category("Group_Routine"), DefaultValue(true), DisplayName("Display_CanUse")]
		public virtual bool TouchEnable
		{
			get
			{
				return this.<get_TouchEnable>z__OriginalMethod();
			}
			set
			{
				Arguments empty = Arguments.Empty;
				LocationInterceptionArgsImpl<bool> locationInterceptionArgsImpl = new LocationInterceptionArgsImpl<bool>(this, empty);
				locationInterceptionArgsImpl.DeclarationIdentifier = new DeclarationIdentifier(-4582977439099322360L);
				locationInterceptionArgsImpl.TypedBinding = WidgetObject.<TouchEnable>c__Binding.singleton;
				locationInterceptionArgsImpl.TypedValue = value;
				locationInterceptionArgsImpl.LocationName = "TouchEnable";
				<>z__a_1.a0.OnSetValue(locationInterceptionArgsImpl);
			}
		}

		[UndoProperty, Browsable(true)]
		public override EnumCallBack CallBackType
		{
			get
			{
				return this.callBackType;
			}
			set
			{
				this.callBackType = value;
				this.RaisePropertyChanged<EnumCallBack>(() => this.CallBackType);
			}
		}

		[UndoProperty]
		public override string CallBackName
		{
			get
			{
				return this.callBackName;
			}
			set
			{
				this.callBackName = value;
				this.RaisePropertyChanged<string>(() => this.CallBackName);
			}
		}

		private CSWidget GetInnerWidget()
		{
			return this.innerNode as CSWidget;
		}

		public WidgetObject()
		{
		}

		public WidgetObject(CSWidget comEntiy) : base(comEntiy)
		{
			this.CustomWidgetInstance = comEntiy;
		}

		protected override void CreateCSObject()
		{
			if (this.innerNode == null)
			{
				this.innerNode = new CSWidget();
			}
		}

		protected override void InitData()
		{
			base.InitData();
			this.IsAddToCurrent = false;
		}

		protected override void SetValue(object cObject, object cInnerObject)
		{
			CSWidget cSWidget = cInnerObject as CSWidget;
			if (cSWidget != null)
			{
				cSWidget.CloneWidgetCustomProperty(this.GetInnerWidget());
			}
			base.SetValue(cObject, cInnerObject);
			WidgetObject widgetObject = cObject as WidgetObject;
			if (widgetObject != null)
			{
				widgetObject.TouchEnable = this.TouchEnable;
				widgetObject.CallBackName = this.CallBackName;
				widgetObject.CallBackType = this.CallBackType;
			}
		}

		private bool <get_TouchEnable>z__OriginalMethod()
		{
			return this.GetInnerWidget().GetTouchEnabled();
		}
	}
}
