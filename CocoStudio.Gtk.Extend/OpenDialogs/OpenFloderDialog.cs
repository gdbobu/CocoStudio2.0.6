// Decompiled with JetBrains decompiler
// Type: OpenDialogs.OpenFloderDialog
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using CustomControls.Controls;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace OpenDialogs
{
  public class OpenFloderDialog : OpenFileDialogEx
  {
    private IContainer components = (IContainer) null;

    public DirectoryInfo Info { get; private set; }

    public OpenFloderDialog()
    {
      this.InitializeComponent();
      this.OpenDialog.Multiselect = false;
      this.OpenDialog.Filter = "folders|*.\n";
    }

    public override void OnFileNameChanged(string fileName)
    {
      this.SetShowText(fileName);
    }

    public override void OnFolderNameChanged(string folderName)
    {
      this.SetShowText(folderName);
    }

    public override void SetShowText(string directorypath)
    {
      if (!string.IsNullOrWhiteSpace(directorypath))
      {
        DirectoryInfo directoryInfo = new DirectoryInfo(directorypath);
        if (directoryInfo.Exists)
        {
          base.SetShowText(directorypath);
          this.textBox1.Text = directoryInfo.Name;
          this.Info = directoryInfo;
          return;
        }
      }
      this.Info = (DirectoryInfo) null;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.SuspendLayout();
      this.AutoScaleDimensions = new SizeF(6f, 12f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Name = "OpenFloderDialog";
      this.ResumeLayout(false);
    }
  }
}
