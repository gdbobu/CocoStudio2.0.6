using CocoStudio.Core;
using CocoStudio.Projects;
using CocoStudio.ToolKit;
using CocoStudio.UndoManager;
using Gdk;
using Gtk;
using Modules.Communal.MultiLanguage;
using MonoDevelop.Components;
using MonoDevelop.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Xwt;
using Xwt.Drawing;
using Xwt.GtkBackend;

namespace CocoStudio.Model.Editor
{
	public class ImageEventBox : EventBox
	{
		private const int scaleNum = 46;

		private static TargetEntry[] target_tableWindows = new TargetEntry[]
		{
			DragTargetType.CocoStudioTarget
		};

		protected MonoDevelop.Components.ImageView imageWidget;

		private ResourceFile resourceFile;

		private PropertyItem _propertyItem;

		private PropertyDescriptor _propertyDescriptor;

		private Gtk.Menu _contentMenu = new Gtk.Menu();

		private uint? firstClickTime = null;

		private double x = -1.0;

		private double y = -1.0;

		public ImageEventBox()
		{
			base.DragMotion += new DragMotionHandler(this.ImageEventBox_DragMotion);
		}

		public ImageEventBox(PropertyItem propertyItem, PropertyDescriptor propertyDescriptor) : this()
		{
			Gtk.Drag.DestSet(this, DestDefaults.All, ImageEventBox.target_tableWindows, DragAction.Copy | DragAction.Move | DragAction.Link);
			Gtk.Drag.SourceSet(this, ModifierType.Button1Mask, ImageEventBox.target_tableWindows, DragAction.Copy | DragAction.Move | DragAction.Link);
			this._propertyItem = propertyItem;
			this._propertyDescriptor = propertyDescriptor;
			if (this._propertyItem != null)
			{
				this.imageWidget = new MonoDevelop.Components.ImageView();
				this.imageWidget.WidthRequest = 46;
				this.imageWidget.HeightRequest = 46;
				base.Add(this.imageWidget);
				this.imageWidget.Show();
				this.Refresh();
				if (propertyItem.Instance is INotifyPropertyChanged)
				{
					(propertyItem.Instance as INotifyPropertyChanged).PropertyChanged += new PropertyChangedEventHandler(this.ImageEventBox_PropertyChanged);
				}
				Gtk.MenuItem menuItem = new Gtk.MenuItem(LanguageInfo.Command_OpenDirectory);
				menuItem.ButtonReleaseEvent += new ButtonReleaseEventHandler(this.item1_ButtonReleaseEvent);
				Gtk.MenuItem menuItem2 = new Gtk.MenuItem(LanguageInfo.Property_CopyFileName);
				menuItem2.ButtonPressEvent += new ButtonPressEventHandler(this.item2_ButtonPressEvent);
				Gtk.MenuItem menuItem3 = new Gtk.MenuItem(LanguageInfo.Property_CopyPhyDir);
				menuItem3.ButtonPressEvent += new ButtonPressEventHandler(this.item3_ButtonPressEvent);
				Gtk.MenuItem menuItem4 = new Gtk.MenuItem(LanguageInfo.Scene_Menucontext_ResetDefault);
				menuItem4.ButtonPressEvent += new ButtonPressEventHandler(this.item4_ButtonPressEvent);
				this._contentMenu.Add(menuItem);
				this._contentMenu.Add(menuItem2);
				this._contentMenu.Add(menuItem3);
				this._contentMenu.Add(menuItem4);
			}
		}

		private void ImageEventBox_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if (e.PropertyName == this._propertyDescriptor.Name)
			{
				this.Refresh();
			}
		}

		public void ImageDispose()
		{
			if (this._propertyItem != null)
			{
				(this._propertyItem.Instance as INotifyPropertyChanged).PropertyChanged -= new PropertyChangedEventHandler(this.ImageEventBox_PropertyChanged);
			}
		}

		private void item1_ButtonReleaseEvent(object o, ButtonReleaseEventArgs args)
		{
			if (args.Event.Button == 1u)
			{
				this.OpenFile();
			}
		}

		private void item4_ButtonPressEvent(object o, ButtonPressEventArgs args)
		{
			this._propertyItem.SetValue(this._propertyDescriptor.Name, null, null);
			this.Refresh();
		}

		private void item3_ButtonPressEvent(object o, ButtonPressEventArgs args)
		{
			if (this.resourceFile != null)
			{
				Xwt.Clipboard.SetText(this.resourceFile.FullPath);
			}
		}

		private void item2_ButtonPressEvent(object o, ButtonPressEventArgs args)
		{
			if (this.resourceFile != null)
			{
				Xwt.Clipboard.SetText(this.resourceFile.Name);
			}
		}

		private void OpenFile()
		{
			try
			{
				ResourceFolder rootFolder = Services.ProjectOperations.CurrentResourceGroup.RootFolder;
				string text = rootFolder.FullPath;
				if (this.resourceFile != null && !this.resourceFile.IsDefault)
				{
					text = this.resourceFile.FileName.FullPath;
				}
				if (MonoDevelop.Core.Platform.IsWindows)
				{
					Process.Start("Explorer", "/select," + text);
				}
				else
				{
					Process.Start("open", "-R " + string.Format("\"{0}\"", text));
				}
			}
			catch
			{
			}
		}

		private void SelectFile()
		{
			ResourceFolder resourceFolder = Services.ProjectOperations.CurrentResourceGroup.RootFolder;
			string[] array;
			if (this._propertyItem.ResourceFilterDescriptor == null)
			{
				array = new string[]
				{
					"*.png",
					"*.jpg"
				};
			}
			else
			{
				array = new string[this._propertyItem.ResourceFilterDescriptor.FileFilter.Length];
				for (int i = 0; i < this._propertyItem.ResourceFilterDescriptor.FileFilter.Length; i++)
				{
					array[i] = "*." + this._propertyItem.ResourceFilterDescriptor.FileFilter[i];
				}
			}
			string[] fileNames = FileChooserDialogModel.GetOpenFilePath(array, LanguageInfo.MessageBox_Content96, false, resourceFolder.FullPath).FileNames;
			if (MonoDevelop.Core.Platform.IsMac)
			{
				base.HasFocus = false;
			}
			if (fileNames != null && fileNames.Count<string>() != 0)
			{
				FilePath filePath = fileNames.FirstOrDefault<string>();
				ResourceFolder rootFolder = Services.ProjectOperations.CurrentResourceGroup.RootFolder;
				string directoryName = System.IO.Path.GetDirectoryName((this.resourceFile == null) ? resourceFolder.FullPath : this.resourceFile.FullPath);
				resourceFolder = (Services.ProjectOperations.CurrentResourceGroup.FindResourceItem(directoryName) as ResourceFolder);
				if (resourceFolder == null || filePath.IsChildPathOf(rootFolder.BaseDirectory))
				{
					resourceFolder = rootFolder;
				}
				IProgressMonitor @default = Services.ProgressMonitors.Default;
				List<ResourceItem> source = Services.ProjectOperations.MessgeDialogImprotResource(resourceFolder, fileNames);
				ResourceFile value = source.FirstOrDefault<ResourceItem>() as ResourceFile;
				this.SetValue(value);
			}
		}

		protected override void OnDragDataGet(DragContext context, SelectionData selection_data, uint info, uint time_)
		{
			base.OnDragDataGet(context, selection_data, info, time_);
		}

		private void ImageEventBox_DragMotion(object o, DragMotionArgs args)
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

		protected override bool OnDragDrop(DragContext context, int x, int y, uint time_)
		{
			object dragData = context.GetDragData();
			ResourceInfoDragData resourceInfoDragData = dragData as ResourceInfoDragData;
			bool result;
			if (resourceInfoDragData == null || resourceInfoDragData.Items.Count < 1 || !(resourceInfoDragData.Items.FirstOrDefault<ResourceItem>() is ResourceFile))
			{
				result = false;
			}
			else
			{
				ResourceFile resourceFile = (ResourceFile)resourceInfoDragData.Items.FirstOrDefault<ResourceItem>();
				if (resourceFile != null)
				{
					if (this.CheckResource(resourceFile))
					{
						this.SetValue(resourceFile);
						this.resourceFile = resourceFile;
					}
				}
				result = base.OnDragDrop(context, x, y, time_);
			}
			return result;
		}

		private bool CheckResource(ResourceFile file)
		{
			bool result;
			if (this._propertyItem.ResourceFilterDescriptor != null)
			{
				result = this._propertyItem.ResourceFilterDescriptor.CheckResource(file);
			}
			else
			{
				result = (file.FileName.Extension.Remove(0, 1).Equals("png", StringComparison.InvariantCultureIgnoreCase) || file.FileName.Extension.Remove(0, 1).Equals("jpg", StringComparison.InvariantCultureIgnoreCase));
			}
			return result;
		}

		private void SetValue(ResourceFile item)
		{
			if (item != null)
			{
				if (this._propertyItem != null)
				{
					this.resourceFile = item;
					string arg;
					if (this._propertyItem.ResourceFilterDescriptor == null)
					{
						arg = ".png,jpg";
					}
					else
					{
						arg = string.Join(",", this._propertyItem.ResourceFilterDescriptor.FileFilter);
					}
					this.imageWidget.TooltipText = string.Format("{0}{1}\r\n{2}", LanguageInfo.Display_SupportFileTypes, arg, item.FullPath);
					Xwt.Drawing.Image image = (item.PreviewImageInfo == null) ? null : item.PreviewImageInfo.Image;
					if (image != null)
					{
						this.ScaleImage(image);
					}
					using (CompositeTask.Run(this._propertyItem.DiaplayName))
					{
						this._propertyItem.SetValue(this._propertyDescriptor.Name, item, null);
					}
				}
			}
		}

		public void Refresh()
		{
			if (this._propertyItem != null)
			{
				this.resourceFile = (this._propertyDescriptor.GetValue(this._propertyItem.Instance) as ResourceFile);
				string arg;
				if (this._propertyItem.ResourceFilterDescriptor == null)
				{
					arg = ".png,jpg";
				}
				else
				{
					arg = string.Join(",", this._propertyItem.ResourceFilterDescriptor.FileFilter);
				}
				if (this.resourceFile != null)
				{
					if (this.resourceFile.IsDefault)
					{
						this.imageWidget.TooltipText = string.Format("{0}{1}", LanguageInfo.Display_SupportFileTypes, arg);
					}
					else
					{
						this.imageWidget.TooltipText = string.Format("{0}{1}\r\n{2}", LanguageInfo.Display_SupportFileTypes, arg, this.resourceFile.FullPath);
					}
					Xwt.Drawing.Image image = (this.resourceFile.PreviewImageInfo == null) ? null : this.resourceFile.PreviewImageInfo.Image;
					if (image != null)
					{
						double width = this.resourceFile.PreviewImageInfo.Size.Width;
						double height = this.resourceFile.PreviewImageInfo.Size.Height;
						this.ScaleImage(image);
						if (this._propertyDescriptor.Name == "LabelAtlasFileImage_CNB")
						{
							this._propertyItem.Instance.GetType().GetProperty("CharWidth").SetValue(this._propertyItem.Instance, (int)(width / 12.0), null);
							this._propertyItem.Instance.GetType().GetProperty("CharHeight").SetValue(this._propertyItem.Instance, (int)height, null);
						}
					}
				}
				else
				{
					this.imageWidget.TooltipText = string.Format("{0}{1}", LanguageInfo.Display_SupportFileTypes, arg);
					this.imageWidget.Image = ImageIcon.GetIcon("CocoStudio.DefaultResource.EditorResource.NormalImage.png");
					this.imageWidget.QueueDraw();
				}
			}
		}

		private void ScaleImage(Xwt.Drawing.Image image)
		{
			double num = (image.Width > image.Height) ? image.Width : image.Height;
			if (num > 46.0)
			{
				double num2 = 46.0 / num;
				image = image.Scale(num2, num2);
			}
			this.imageWidget.Image = image;
			this.imageWidget.QueueDraw();
		}

		protected override bool OnButtonReleaseEvent(EventButton evnt)
		{
			bool result;
			if (evnt.Button == 3u)
			{
				base.IsFocus = true;
				this._contentMenu.ShowAll();
				GtkWorkarounds.ShowContextMenu(this._contentMenu, this, evnt);
				if (this.resourceFile == null || this.resourceFile.IsDefault)
				{
					this._contentMenu.Children.ForEach(delegate(Gtk.Widget w)
					{
						(w as Gtk.MenuItem).Sensitive = false;
					});
					this._contentMenu.Children[3].Sensitive = true;
				}
				else
				{
					this._contentMenu.Children.ForEach(delegate(Gtk.Widget w)
					{
						(w as Gtk.MenuItem).Sensitive = true;
					});
				}
				result = true;
			}
			else
			{
				if (this.IsDoubleClick(evnt, 1u))
				{
					this.SelectFile();
				}
				result = base.OnButtonReleaseEvent(evnt);
			}
			return result;
		}

		private bool IsDoubleClick(EventButton eventbutton, uint buttontype = 1u)
		{
			bool result = false;
			if (eventbutton.Button == buttontype)
			{
				if (!this.firstClickTime.HasValue)
				{
					this.firstClickTime = new uint?(eventbutton.Time);
					this.x = eventbutton.X;
					this.y = eventbutton.Y;
				}
				else
				{
					uint time = eventbutton.Time;
					if (time - this.firstClickTime < 1000u && Math.Abs(eventbutton.X - this.x) < 0.3 && Math.Abs(eventbutton.Y - this.y) < 0.3)
					{
						result = true;
						this.firstClickTime = null;
					}
					else
					{
						this.firstClickTime = new uint?(time);
						this.x = eventbutton.X;
						this.y = eventbutton.Y;
					}
				}
			}
			else
			{
				this.firstClickTime = null;
			}
			return result;
		}
	}
}
