using CocoStudio.Model.ViewModel;
using CocoStudio.ToolKit;
using Gtk;
using Modules.Communal.MultiLanguage;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.Editor
{
	[PropertyEditorType(typeof(ResourceFileEditor))]
	public class ResourceFileEditor : BaseEditor, ITypeEditor
	{
		private ResourceFileImport widget;

		public ResourceFileEditor(PropertyItem propertyItem) : base(propertyItem)
		{
		}

		public ResourceFileEditor() : base(null)
		{
		}

		public Widget ResolveEditor(PropertyItem item)
		{
			string txt = LanguageInfo.Property_ImportFile;
			if (this._propertyItem.Instance is GameMapObject)
			{
				txt = LanguageInfo.Property_ImportMap;
			}
			if (this._propertyItem.Instance is SimpleAudioObject)
			{
				txt = LanguageInfo.Property_ImportAudio;
			}
			if (this._propertyItem.Instance is ParticleObject)
			{
				txt = LanguageInfo.Property_ImportParticle;
			}
			this.widget = new ResourceFileImport(this._propertyItem, txt, "");
			return this.widget;
		}

		protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == this._propertyItem.PropertyData.Name)
			{
				this.widget.ScenceSetValue();
			}
		}

		public void EditorDispose()
		{
			base.Dispose();
		}

		public void RefreshData()
		{
			this.widget.ScenceSetValue();
		}
	}
}
