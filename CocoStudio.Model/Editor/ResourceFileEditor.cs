// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Editor.ResourceFileEditor
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Model.ViewModel;
using CocoStudio.ToolKit;
using Gtk;
using Modules.Communal.MultiLanguage;
using System.ComponentModel;

namespace CocoStudio.Model.Editor
{
  [PropertyEditorType(typeof (ResourceFileEditor))]
  public class ResourceFileEditor : BaseEditor, ITypeEditor
  {
    private ResourceFileImport widget;

    public ResourceFileEditor(PropertyItem propertyItem)
      : base(propertyItem)
    {
    }

    public ResourceFileEditor()
      : base((PropertyItem) null)
    {
    }

    public Widget ResolveEditor(PropertyItem item)
    {
      string txt = LanguageInfo.Property_ImportFile;
      if (this._propertyItem.Instance is GameMapObject)
        txt = LanguageInfo.Property_ImportMap;
      if (this._propertyItem.Instance is SimpleAudioObject)
        txt = LanguageInfo.Property_ImportAudio;
      if (this._propertyItem.Instance is ParticleObject)
        txt = LanguageInfo.Property_ImportParticle;
      this.widget = new ResourceFileImport(this._propertyItem, txt, "");
      return (Widget) this.widget;
    }

    protected override void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
      if (!(e.PropertyName == this._propertyItem.PropertyData.Name))
        return;
      this.widget.ScenceSetValue();
    }

    public void EditorDispose()
    {
      this.Dispose();
    }

    public void RefreshData()
    {
      this.widget.ScenceSetValue();
    }
  }
}
