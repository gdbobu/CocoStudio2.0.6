// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Editor.ResourceFileImport
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Basic;
using CocoStudio.Core;
using CocoStudio.Model.ViewModel;
using CocoStudio.Projects;
using CocoStudio.ToolKit;
using CocoStudio.UndoManager;
using Gdk;
using Gtk;
using Modules.Communal.MultiLanguage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace CocoStudio.Model.Editor
{
  public class ResourceFileImport : EventBox
  {
    private TargetEntry[] target_tableWindows = new TargetEntry[1]
    {
      DragTargetType.CocoStudioTarget
    };
    private string _displayName = "";
    private Table FileTable;
    private Button fileButton;
    private Label fileLabel;
    private LabelLink linkLabel;
    private PropertyItem _propertyItem;

    public string PryFilePath { get; set; }

    public string FilePath { get; set; }

    public string LabelToopTip { get; set; }

    public string ButtonText { get; set; }

    public ResourceFileImport()
    {
      Gtk.Drag.DestSet((Widget) this, DestDefaults.All, this.target_tableWindows, DragAction.Copy | DragAction.Move | DragAction.Link);
      Gtk.Drag.SourceSet((Widget) this, ModifierType.Button1Mask, this.target_tableWindows, DragAction.Copy | DragAction.Move | DragAction.Link);
      this.DragMotion += new DragMotionHandler(this.ResourceFileImport_DragMotion);
      this.FileTable = new Table(1U, 3U, false);
      this.fileButton = new Button();
      this.fileLabel = new Label();
      this.fileButton.WidthRequest = 90;
      this.fileButton.HeightRequest = 25;
      this.fileLabel.Text = "";
      this.fileLabel.MaxWidthChars = 20;
      this.linkLabel = new LabelLink((string) null);
      this.linkLabel.SetLabelText("");
      this.linkLabel.SetLabelFontSize(12);
      this.linkLabel.AllowRightClick = false;
      this.linkLabel.LeftClicked += new EventHandler<LabelClickedEventArgs>(this.linkLabel_LeftClicked);
      this.fileButton.Label = this.ButtonText;
      this.FileTable.Attach((Widget) this.fileLabel, 0U, 1U, 0U, 1U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this.FileTable.Attach((Widget) this.linkLabel, 1U, 2U, 0U, 1U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this.FileTable.Attach((Widget) this.fileButton, 2U, 3U, 0U, 1U, AttachOptions.Fill, AttachOptions.Fill, 0U, 0U);
      this.fileButton.Show();
      this.fileButton.Clicked += new EventHandler(this.fileButton_Clicked);
      this.Add((Widget) this.FileTable);
      this.ShowAll();
    }

    public ResourceFileImport(PropertyItem propertyItem, string txt = "�", string displayName = "�")
      : this()
    {
      if (string.IsNullOrEmpty(txt))
        txt = LanguageInfo.Property_ImportFile;
      this._propertyItem = propertyItem;
      this._displayName = displayName;
      if (string.IsNullOrEmpty(this._displayName))
        this._displayName = this._propertyItem.PropertyData.Name;
      this.ButtonText = txt;
      ResourceFile resourceFile = this._propertyItem.Instance.GetType().GetProperty(this._displayName).GetValue(this._propertyItem.Instance, (object[]) null) as ResourceFile;
      if (resourceFile != null)
      {
        this.fileLabel.Text = resourceFile.Name;
        this.fileLabel.TooltipText = resourceFile.FullPath;
        this.linkLabel.SetLabelText(string.Format(" {0} ", (object) LanguageInfo.Property_Reset));
      }
      this.fileButton.Label = this.ButtonText;
      if (this._propertyItem.ResourceFilterDescriptor == null)
        return;
      this.fileButton.TooltipText = LanguageOption.GetValueBykey("Display_SupportFileTypes") + string.Join(",", this._propertyItem.ResourceFilterDescriptor.FileFilter);
    }

    private void ResourceFileImport_DragMotion(object o, DragMotionArgs args)
    {
      ResourceInfoDragData dragData = args.Context.GetDragData() as ResourceInfoDragData;
      if (dragData == null)
      {
        args.SetAllowDragAction((DragAction) 0);
        args.RetVal = (object) true;
      }
      else
      {
        ResourceFile file = dragData.Items.FirstOrDefault<ResourceItem>() as ResourceFile;
        if (file == null || !this.CheckResource(file))
        {
          args.SetAllowDragAction((DragAction) 0);
          args.RetVal = (object) true;
        }
      }
    }

    private void linkLabel_LeftClicked(object sender, LabelClickedEventArgs e)
    {
      foreach (PropertyDescriptor propertyDescriptor in PropertyGridUtilities.GetPropertyDescriptors(this._propertyItem.Instance))
      {
        if (propertyDescriptor.Name == this._displayName)
        {
          using (CompositeTask.Run(this._propertyItem.DiaplayName))
            propertyDescriptor.ResetValue(this._propertyItem.Instance);
          this.ScenceSetValue();
          IPlayControl instance = this._propertyItem.Instance as IPlayControl;
          if (instance == null)
            break;
          instance.Start();
          break;
        }
      }
    }

    protected override void OnDragDataReceived(DragContext context, int x, int y, SelectionData selection_data, uint info, uint time_)
    {
      base.OnDragDataReceived(context, x, y, selection_data, info, time_);
    }

    protected override bool OnDragDrop(DragContext context, int x, int y, uint time_)
    {
      ResourceInfoDragData dragData = context.GetDragData() as ResourceInfoDragData;
      if (dragData == null)
        return false;
      ResourceFile file = dragData.Items.FirstOrDefault<ResourceItem>() as ResourceFile;
      if (file != null && this.CheckResource(file))
        this.SetValue(file);
      return base.OnDragDrop(context, x, y, time_);
    }

    private bool CheckResource(ResourceFile file)
    {
      foreach (string str in this._propertyItem.ResourceFilterDescriptor.FileFilter)
      {
        if (file.FileName.Extension.Remove(0, 1).ToLower() == str)
          return true;
      }
      return false;
    }

    private void fileButton_Clicked(object sender, EventArgs e)
    {
      ResourceFolder rootFolder = Services.ProjectOperations.CurrentResourceGroup.RootFolder;
      string[] fileTypes = new string[this._propertyItem.ResourceFilterDescriptor.FileFilter.Length];
      for (int index = 0; index < this._propertyItem.ResourceFilterDescriptor.FileFilter.Length; ++index)
        fileTypes[index] = "*." + this._propertyItem.ResourceFilterDescriptor.FileFilter[index];
      string[] fileNames = FileChooserDialogModel.GetOpenFilePath(fileTypes, LanguageInfo.MessageBox_Content96, false, rootFolder.FullPath).FileNames;
      if (fileNames == null || ((IEnumerable<string>) fileNames).Count<string>() == 0)
        return;
      this.SetValue(Services.ProjectOperations.MessgeDialogImprotResource(rootFolder, (IEnumerable<string>) fileNames).FirstOrDefault<ResourceItem>() as ResourceFile);
      IPlayControl instance = this._propertyItem.Instance as IPlayControl;
      if (instance == null)
        return;
      instance.Start();
    }

    private void SetValue(ResourceFile file)
    {
      if (file == null || !file.IsValid)
        return;
      if (file != null)
      {
        string str = this.CheckNest(file);
        if (!string.IsNullOrEmpty(str))
        {
          LogConfig.Output.Error((object) str, (Exception) null);
          return;
        }
        using (CompositeTask.Run(this._propertyItem.DiaplayName))
          this._propertyItem.SetValue(this._propertyItem.Instance, (object) file, (object[]) null);
        IPlayControl instance = this._propertyItem.Instance as IPlayControl;
        if (instance != null)
          instance.Start();
      }
      this.ScenceSetValue();
    }

    private string CheckNest(ResourceFile value)
    {
      Project project = value as Project;
      if (project == null)
        return (string) null;
      Project currentSelectedProject = Services.ProjectOperations.CurrentSelectedProject;
      if (currentSelectedProject == null)
        return (string) null;
      GameProjectFile projectItem = currentSelectedProject.ProjectItem as GameProjectFile;
      if (projectItem == null)
        return "No Project";
      if ((MonoDevelop.Core.FilePath) project.FullPath == projectItem.FileName)
        return LanguageInfo.MessageBox207_NestedSelfError;
      return project.CheckNest(currentSelectedProject);
    }

    public void ScenceSetValue()
    {
      ResourceFile resourceFile = this._propertyItem.Instance.GetType().GetProperty(this._displayName).GetValue(this._propertyItem.Instance, (object[]) null) as ResourceFile;
      if (resourceFile != null)
      {
        this.fileLabel.Text = resourceFile.Name;
        this.fileLabel.TooltipText = resourceFile.FullPath;
        this.linkLabel.SetLabelText(string.Format(" {0} ", (object) LanguageInfo.Property_Reset));
      }
      else
      {
        this.fileLabel.Text = "";
        this.fileLabel.TooltipText = "";
        this.linkLabel.SetLabelText("");
      }
    }
  }
}
