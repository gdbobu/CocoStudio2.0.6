// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.Editor.ImageEventBox
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Core;
using CocoStudio.Projects;
using CocoStudio.ToolKit;
using CocoStudio.UndoManager;
using Gdk;
using Gtk;
using Modules.Communal.MultiLanguage;
using MonoDevelop.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Xwt.GtkBackend;

namespace CocoStudio.Model.Editor
{
  public class ImageEventBox : EventBox
  {
    private static TargetEntry[] target_tableWindows = new TargetEntry[1]
    {
      DragTargetType.CocoStudioTarget
    };
    private Gtk.Menu _contentMenu = new Gtk.Menu();
    private uint? firstClickTime = new uint?();
    private double x = -1.0;
    private double y = -1.0;
    private const int scaleNum = 46;
    protected MonoDevelop.Components.ImageView imageWidget;
    private ResourceFile resourceFile;
    private PropertyItem _propertyItem;
    private PropertyDescriptor _propertyDescriptor;

    public ImageEventBox()
    {
      this.DragMotion += new DragMotionHandler(this.ImageEventBox_DragMotion);
    }

    public ImageEventBox(PropertyItem propertyItem, PropertyDescriptor propertyDescriptor)
      : this()
    {
      Gtk.Drag.DestSet((Gtk.Widget) this, DestDefaults.All, ImageEventBox.target_tableWindows, DragAction.Copy | DragAction.Move | DragAction.Link);
      Gtk.Drag.SourceSet((Gtk.Widget) this, ModifierType.Button1Mask, ImageEventBox.target_tableWindows, DragAction.Copy | DragAction.Move | DragAction.Link);
      this._propertyItem = propertyItem;
      this._propertyDescriptor = propertyDescriptor;
      if (this._propertyItem == null)
        return;
      this.imageWidget = new MonoDevelop.Components.ImageView();
      this.imageWidget.WidthRequest = 46;
      this.imageWidget.HeightRequest = 46;
      this.Add((Gtk.Widget) this.imageWidget);
      this.imageWidget.Show();
      this.Refresh();
      if (propertyItem.Instance is INotifyPropertyChanged)
        (propertyItem.Instance as INotifyPropertyChanged).PropertyChanged += new PropertyChangedEventHandler(this.ImageEventBox_PropertyChanged);
      Gtk.MenuItem menuItem1 = new Gtk.MenuItem(LanguageInfo.Command_OpenDirectory);
      menuItem1.ButtonReleaseEvent += new ButtonReleaseEventHandler(this.item1_ButtonReleaseEvent);
      Gtk.MenuItem menuItem2 = new Gtk.MenuItem(LanguageInfo.Property_CopyFileName);
      menuItem2.ButtonPressEvent += new ButtonPressEventHandler(this.item2_ButtonPressEvent);
      Gtk.MenuItem menuItem3 = new Gtk.MenuItem(LanguageInfo.Property_CopyPhyDir);
      menuItem3.ButtonPressEvent += new ButtonPressEventHandler(this.item3_ButtonPressEvent);
      Gtk.MenuItem menuItem4 = new Gtk.MenuItem(LanguageInfo.Scene_Menucontext_ResetDefault);
      menuItem4.ButtonPressEvent += new ButtonPressEventHandler(this.item4_ButtonPressEvent);
      this._contentMenu.Add((Gtk.Widget) menuItem1);
      this._contentMenu.Add((Gtk.Widget) menuItem2);
      this._contentMenu.Add((Gtk.Widget) menuItem3);
      this._contentMenu.Add((Gtk.Widget) menuItem4);
    }

    private void ImageEventBox_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
      if (!(e.PropertyName == this._propertyDescriptor.Name))
        return;
      this.Refresh();
    }

    public void ImageDispose()
    {
      if (this._propertyItem == null)
        return;
      (this._propertyItem.Instance as INotifyPropertyChanged).PropertyChanged -= new PropertyChangedEventHandler(this.ImageEventBox_PropertyChanged);
    }

    private void item1_ButtonReleaseEvent(object o, ButtonReleaseEventArgs args)
    {
      if ((int) args.Event.Button != 1)
        return;
      this.OpenFile();
    }

    private void item4_ButtonPressEvent(object o, ButtonPressEventArgs args)
    {
      this._propertyItem.SetValue(this._propertyDescriptor.Name, (object) null, (object[]) null);
      this.Refresh();
    }

    private void item3_ButtonPressEvent(object o, ButtonPressEventArgs args)
    {
      if (this.resourceFile == null)
        return;
      Xwt.Clipboard.SetText(this.resourceFile.FullPath);
    }

    private void item2_ButtonPressEvent(object o, ButtonPressEventArgs args)
    {
      if (this.resourceFile == null)
        return;
      Xwt.Clipboard.SetText(this.resourceFile.Name);
    }

    private void OpenFile()
    {
      try
      {
        string fullPath = Services.ProjectOperations.CurrentResourceGroup.RootFolder.FullPath;
        if (this.resourceFile != null && !this.resourceFile.IsDefault)
          fullPath = (string) this.resourceFile.FileName.FullPath;
        if (MonoDevelop.Core.Platform.IsWindows)
          Process.Start("Explorer", "/select," + fullPath);
        else
          Process.Start("open", "-R " + string.Format("\"{0}\"", (object) fullPath));
      }
      catch
      {
      }
    }

    private void SelectFile()
    {
      ResourceFolder rootFolder1 = Services.ProjectOperations.CurrentResourceGroup.RootFolder;
      string[] fileTypes;
      if (this._propertyItem.ResourceFilterDescriptor == null)
      {
        fileTypes = new string[2]
        {
          "*.png",
          "*.jpg"
        };
      }
      else
      {
        fileTypes = new string[this._propertyItem.ResourceFilterDescriptor.FileFilter.Length];
        for (int index = 0; index < this._propertyItem.ResourceFilterDescriptor.FileFilter.Length; ++index)
          fileTypes[index] = "*." + this._propertyItem.ResourceFilterDescriptor.FileFilter[index];
      }
      string[] fileNames = FileChooserDialogModel.GetOpenFilePath(fileTypes, LanguageInfo.MessageBox_Content96, false, rootFolder1.FullPath).FileNames;
      if (MonoDevelop.Core.Platform.IsMac)
        this.HasFocus = false;
      if (fileNames == null || ((IEnumerable<string>) fileNames).Count<string>() == 0)
        return;
      FilePath filePath = (FilePath) ((IEnumerable<string>) fileNames).FirstOrDefault<string>();
      ResourceFolder rootFolder2 = Services.ProjectOperations.CurrentResourceGroup.RootFolder;
      ResourceFolder parent = Services.ProjectOperations.CurrentResourceGroup.FindResourceItem(Path.GetDirectoryName(this.resourceFile == null ? rootFolder1.FullPath : this.resourceFile.FullPath)) as ResourceFolder;
      if (parent == null || filePath.IsChildPathOf(rootFolder2.BaseDirectory))
        parent = rootFolder2;
      IProgressMonitor progressMonitor = Services.ProgressMonitors.Default;
      this.SetValue(Services.ProjectOperations.MessgeDialogImprotResource(parent, (IEnumerable<string>) fileNames).FirstOrDefault<ResourceItem>() as ResourceFile);
    }

    protected override void OnDragDataGet(DragContext context, SelectionData selection_data, uint info, uint time_)
    {
      base.OnDragDataGet(context, selection_data, info, time_);
    }

    private void ImageEventBox_DragMotion(object o, DragMotionArgs args)
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

    protected override bool OnDragDrop(DragContext context, int x, int y, uint time_)
    {
      ResourceInfoDragData dragData = context.GetDragData() as ResourceInfoDragData;
      if (dragData == null || dragData.Items.Count < 1 || !(dragData.Items.FirstOrDefault<ResourceItem>() is ResourceFile))
        return false;
      ResourceFile file = (ResourceFile) dragData.Items.FirstOrDefault<ResourceItem>();
      if (file != null && this.CheckResource(file))
      {
        this.SetValue(file);
        this.resourceFile = file;
      }
      return base.OnDragDrop(context, x, y, time_);
    }

    private bool CheckResource(ResourceFile file)
    {
      if (this._propertyItem.ResourceFilterDescriptor != null)
        return this._propertyItem.ResourceFilterDescriptor.CheckResource(file);
      return file.FileName.Extension.Remove(0, 1).Equals("png", StringComparison.InvariantCultureIgnoreCase) || file.FileName.Extension.Remove(0, 1).Equals("jpg", StringComparison.InvariantCultureIgnoreCase);
    }

    private void SetValue(ResourceFile item)
    {
      if (item == null || this._propertyItem == null)
        return;
      this.resourceFile = item;
      string str = this._propertyItem.ResourceFilterDescriptor != null ? string.Join(",", this._propertyItem.ResourceFilterDescriptor.FileFilter) : ".png,jpg";
      this.imageWidget.TooltipText = string.Format("{0}{1}\r\n{2}", (object) LanguageInfo.Display_SupportFileTypes, (object) str, (object) item.FullPath);
      Xwt.Drawing.Image image = item.PreviewImageInfo == null ? (Xwt.Drawing.Image) null : item.PreviewImageInfo.Image;
      if (image != null)
        this.ScaleImage(image);
      using (CompositeTask.Run(this._propertyItem.DiaplayName))
        this._propertyItem.SetValue(this._propertyDescriptor.Name, (object) item, (object[]) null);
    }

    public void Refresh()
    {
      if (this._propertyItem == null)
        return;
      this.resourceFile = this._propertyDescriptor.GetValue(this._propertyItem.Instance) as ResourceFile;
      string str = this._propertyItem.ResourceFilterDescriptor != null ? string.Join(",", this._propertyItem.ResourceFilterDescriptor.FileFilter) : ".png,jpg";
      if (this.resourceFile != null)
      {
        if (this.resourceFile.IsDefault)
          this.imageWidget.TooltipText = string.Format("{0}{1}", (object) LanguageInfo.Display_SupportFileTypes, (object) str);
        else
          this.imageWidget.TooltipText = string.Format("{0}{1}\r\n{2}", (object) LanguageInfo.Display_SupportFileTypes, (object) str, (object) this.resourceFile.FullPath);
        Xwt.Drawing.Image image = this.resourceFile.PreviewImageInfo == null ? (Xwt.Drawing.Image) null : this.resourceFile.PreviewImageInfo.Image;
        if (image == null)
          return;
        double width = this.resourceFile.PreviewImageInfo.Size.Width;
        double height = this.resourceFile.PreviewImageInfo.Size.Height;
        this.ScaleImage(image);
        if (this._propertyDescriptor.Name == "LabelAtlasFileImage_CNB")
        {
          this._propertyItem.Instance.GetType().GetProperty("CharWidth").SetValue(this._propertyItem.Instance, (object) (int) (width / 12.0), (object[]) null);
          this._propertyItem.Instance.GetType().GetProperty("CharHeight").SetValue(this._propertyItem.Instance, (object) (int) height, (object[]) null);
        }
      }
      else
      {
        this.imageWidget.TooltipText = string.Format("{0}{1}", (object) LanguageInfo.Display_SupportFileTypes, (object) str);
        this.imageWidget.Image = ImageIcon.GetIcon("CocoStudio.DefaultResource.EditorResource.NormalImage.png");
        this.imageWidget.QueueDraw();
      }
    }

    private void ScaleImage(Xwt.Drawing.Image image)
    {
      double num1 = image.Width > image.Height ? image.Width : image.Height;
      if (num1 > 46.0)
      {
        double num2 = 46.0 / num1;
        image = image.Scale(num2, num2);
      }
      this.imageWidget.Image = image;
      this.imageWidget.QueueDraw();
    }

    protected override bool OnButtonReleaseEvent(EventButton evnt)
    {
      if ((int) evnt.Button == 3)
      {
        this.IsFocus = true;
        this._contentMenu.ShowAll();
        GtkWorkarounds.ShowContextMenu(this._contentMenu, (Gtk.Widget) this, evnt);
        if (this.resourceFile == null || this.resourceFile.IsDefault)
        {
          ((IEnumerable<Gtk.Widget>) this._contentMenu.Children).ForEach<Gtk.Widget>((System.Action<Gtk.Widget>) (w => (w as Gtk.MenuItem).Sensitive = false));
          this._contentMenu.Children[3].Sensitive = true;
        }
        else
          ((IEnumerable<Gtk.Widget>) this._contentMenu.Children).ForEach<Gtk.Widget>((System.Action<Gtk.Widget>) (w => (w as Gtk.MenuItem).Sensitive = true));
        return true;
      }
      if (this.IsDoubleClick(evnt, 1U))
        this.SelectFile();
      return base.OnButtonReleaseEvent(evnt);
    }

    private bool IsDoubleClick(EventButton eventbutton, uint buttontype = 1)
    {
      bool flag = false;
      if ((int) eventbutton.Button == (int) buttontype)
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
          uint num = time;
          uint? nullable = this.firstClickTime;
          nullable = nullable.HasValue ? new uint?(num - nullable.GetValueOrDefault()) : new uint?();
          if ((nullable.GetValueOrDefault() >= 1000U ? 0 : (nullable.HasValue ? 1 : 0)) != 0 && Math.Abs(eventbutton.X - this.x) < 0.3 && Math.Abs(eventbutton.Y - this.y) < 0.3)
          {
            flag = true;
            this.firstClickTime = new uint?();
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
        this.firstClickTime = new uint?();
      return flag;
    }
  }
}
