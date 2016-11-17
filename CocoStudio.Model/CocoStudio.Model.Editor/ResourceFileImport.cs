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
		private Table FileTable;

		private Button fileButton;

		private Label fileLabel;

		private LabelLink linkLabel;

		private TargetEntry[] target_tableWindows = new TargetEntry[]
		{
			DragTargetType.CocoStudioTarget
		};

		private PropertyItem _propertyItem;

		private string _displayName = "";

		public string PryFilePath
		{
			get;
			set;
		}

		public string FilePath
		{
			get;
			set;
		}

		public string LabelToopTip
		{
			get;
			set;
		}

		public string ButtonText
		{
			get;
			set;
		}

		public ResourceFileImport()
		{
			Gtk.Drag.DestSet(this, DestDefaults.All, this.target_tableWindows, DragAction.Copy | DragAction.Move | DragAction.Link);
			Gtk.Drag.SourceSet(this, ModifierType.Button1Mask, this.target_tableWindows, DragAction.Copy | DragAction.Move | DragAction.Link);
			base.DragMotion += new DragMotionHandler(this.ResourceFileImport_DragMotion);
			this.FileTable = new Table(1u, 3u, false);
			this.fileButton = new Button();
			this.fileLabel = new Label();
			this.fileButton.WidthRequest = 90;
			this.fileButton.HeightRequest = 25;
			this.fileLabel.Text = "";
			this.fileLabel.MaxWidthChars = 20;
			this.linkLabel = new LabelLink(null);
			this.linkLabel.SetLabelText("");
			this.linkLabel.SetLabelFontSize(12);
			this.linkLabel.AllowRightClick = false;
			this.linkLabel.LeftClicked += new EventHandler<LabelClickedEventArgs>(this.linkLabel_LeftClicked);
			this.fileButton.Label = this.ButtonText;
			this.FileTable.Attach(this.fileLabel, 0u, 1u, 0u, 1u, AttachOptions.Fill, AttachOptions.Fill, 0u, 0u);
			this.FileTable.Attach(this.linkLabel, 1u, 2u, 0u, 1u, AttachOptions.Fill, AttachOptions.Fill, 0u, 0u);
			this.FileTable.Attach(this.fileButton, 2u, 3u, 0u, 1u, AttachOptions.Fill, AttachOptions.Fill, 0u, 0u);
			this.fileButton.Show();
			this.fileButton.Clicked += new EventHandler(this.fileButton_Clicked);
			base.Add(this.FileTable);
			base.ShowAll();
		}

		private void ResourceFileImport_DragMotion(object o, DragMotionArgs args)
		{
			object dragData = args.Context.GetDragData();
			ResourceInfoDragData resourceInfoDragData = dragData as ResourceInfoDragData;
			if (resourceInfoDragData == null)
			{
				args.SetAllowDragAction((DragAction)0);
				args.RetVal = true;
			}
			else
			{
				ResourceFile resourceFile = resourceInfoDragData.Items.FirstOrDefault<ResourceItem>() as ResourceFile;
				if (resourceFile == null || !this.CheckResource(resourceFile))
				{
					args.SetAllowDragAction((DragAction)0);
					args.RetVal = true;
				}
			}
		}

		private void linkLabel_LeftClicked(object sender, LabelClickedEventArgs e)
		{
			PropertyDescriptorCollection propertyDescriptors = PropertyGridUtilities.GetPropertyDescriptors(this._propertyItem.Instance);
			foreach (PropertyDescriptor propertyDescriptor in propertyDescriptors)
			{
				if (propertyDescriptor.Name == this._displayName)
				{
					using (CompositeTask.Run(this._propertyItem.DiaplayName))
					{
						propertyDescriptor.ResetValue(this._propertyItem.Instance);
					}
					this.ScenceSetValue();
					IPlayControl playControl = this._propertyItem.Instance as IPlayControl;
					if (playControl != null)
					{
						playControl.Start();
					}
					break;
				}
			}
		}

		public ResourceFileImport(PropertyItem propertyItem, string txt = "", string displayName = "") : this()
		{
			if (string.IsNullOrEmpty(txt))
			{
				txt = LanguageInfo.Property_ImportFile;
			}
			this._propertyItem = propertyItem;
			this._displayName = displayName;
			if (string.IsNullOrEmpty(this._displayName))
			{
				this._displayName = this._propertyItem.PropertyData.Name;
			}
			this.ButtonText = txt;
			ResourceFile resourceFile = this._propertyItem.Instance.GetType().GetProperty(this._displayName).GetValue(this._propertyItem.Instance, null) as ResourceFile;
			if (resourceFile != null)
			{
				this.fileLabel.Text = resourceFile.Name;
				this.fileLabel.TooltipText = resourceFile.FullPath;
				this.linkLabel.SetLabelText(string.Format(" {0} ", LanguageInfo.Property_Reset));
			}
			this.fileButton.Label = this.ButtonText;
			if (this._propertyItem.ResourceFilterDescriptor != null)
			{
				this.fileButton.TooltipText = LanguageOption.GetValueBykey("Display_SupportFileTypes") + string.Join(",", this._propertyItem.ResourceFilterDescriptor.FileFilter);
			}
		}

		protected override void OnDragDataReceived(DragContext context, int x, int y, SelectionData selection_data, uint info, uint time_)
		{
			base.OnDragDataReceived(context, x, y, selection_data, info, time_);
		}

		protected override bool OnDragDrop(DragContext context, int x, int y, uint time_)
		{
			object dragData = context.GetDragData();
			ResourceInfoDragData resourceInfoDragData = dragData as ResourceInfoDragData;
			bool result;
			if (resourceInfoDragData == null)
			{
				result = false;
			}
			else
			{
				ResourceFile resourceFile = resourceInfoDragData.Items.FirstOrDefault<ResourceItem>() as ResourceFile;
				if (resourceFile != null && this.CheckResource(resourceFile))
				{
					this.SetValue(resourceFile);
				}
				result = base.OnDragDrop(context, x, y, time_);
			}
			return result;
		}

		private bool CheckResource(ResourceFile file)
		{
			string[] fileFilter = this._propertyItem.ResourceFilterDescriptor.FileFilter;
			bool result;
			for (int i = 0; i < fileFilter.Length; i++)
			{
				string b = fileFilter[i];
				if (file.FileName.Extension.Remove(0, 1).ToLower() == b)
				{
					result = true;
					return result;
				}
			}
			result = false;
			return result;
		}

		private void fileButton_Clicked(object sender, EventArgs e)
		{
			ResourceFolder rootFolder = Services.ProjectOperations.CurrentResourceGroup.RootFolder;
			string[] array = new string[this._propertyItem.ResourceFilterDescriptor.FileFilter.Length];
			for (int i = 0; i < this._propertyItem.ResourceFilterDescriptor.FileFilter.Length; i++)
			{
				array[i] = "*." + this._propertyItem.ResourceFilterDescriptor.FileFilter[i];
			}
			string[] fileNames = FileChooserDialogModel.GetOpenFilePath(array, LanguageInfo.MessageBox_Content96, false, rootFolder.FullPath).FileNames;
			if (fileNames != null && fileNames.Count<string>() != 0)
			{
				List<ResourceItem> source = Services.ProjectOperations.MessgeDialogImprotResource(rootFolder, fileNames);
				ResourceFile value = source.FirstOrDefault<ResourceItem>() as ResourceFile;
				this.SetValue(value);
				IPlayControl playControl = this._propertyItem.Instance as IPlayControl;
				if (playControl != null)
				{
					playControl.Start();
				}
			}
		}

		private void SetValue(ResourceFile file)
		{
			if (file != null && file.IsValid)
			{
				if (file != null)
				{
					string text = this.CheckNest(file);
					if (!string.IsNullOrEmpty(text))
					{
						LogConfig.Output.Error(text, null);
						return;
					}
					using (CompositeTask.Run(this._propertyItem.DiaplayName))
					{
						this._propertyItem.SetValue(this._propertyItem.Instance, file, null);
					}
					IPlayControl playControl = this._propertyItem.Instance as IPlayControl;
					if (playControl != null)
					{
						playControl.Start();
					}
				}
				this.ScenceSetValue();
			}
		}

		private string CheckNest(ResourceFile value)
		{
			Project project = value as Project;
			string result;
			if (project == null)
			{
				result = null;
			}
			else
			{
				Project currentSelectedProject = Services.ProjectOperations.CurrentSelectedProject;
				if (currentSelectedProject == null)
				{
					result = null;
				}
				else
				{
					GameProjectFile gameProjectFile = currentSelectedProject.ProjectItem as GameProjectFile;
					if (gameProjectFile == null)
					{
						result = "No Project";
					}
					else if (project.FullPath == gameProjectFile.FileName)
					{
						result = LanguageInfo.MessageBox207_NestedSelfError;
					}
					else
					{
						result = project.CheckNest(currentSelectedProject);
					}
				}
			}
			return result;
		}

		public void ScenceSetValue()
		{
			ResourceFile resourceFile = this._propertyItem.Instance.GetType().GetProperty(this._displayName).GetValue(this._propertyItem.Instance, null) as ResourceFile;
			if (resourceFile != null)
			{
				this.fileLabel.Text = resourceFile.Name;
				this.fileLabel.TooltipText = resourceFile.FullPath;
				this.linkLabel.SetLabelText(string.Format(" {0} ", LanguageInfo.Property_Reset));
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
