// Decompiled with JetBrains decompiler
// Type: OpenDialogs.DummyForm
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using CustomControls.Controls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace OpenDialogs
{
  public class DummyForm : Form
  {
    public string Lable_OpenFloder = "文件夹:";
    public string Lable_SelectTexg = "选择";
    public string Lable_CancelText = "取消";
    private OpenDialogNative mNativeDialog = (OpenDialogNative) null;
    private OpenFileDialogEx mFileDialogEx = (OpenFileDialogEx) null;
    private bool mWatchForActivate = false;
    private IntPtr mOpenDialogHandle = IntPtr.Zero;

    public bool WatchForActivate
    {
      get
      {
        return this.mWatchForActivate;
      }
      set
      {
        this.mWatchForActivate = value;
      }
    }

    public DummyForm(OpenFileDialogEx fileDialogEx, string lable_OpenFloder, string lable_SelectTexg, string lable_CancelText)
    {
      if (CultureInfo.CurrentCulture.ToString().Equals("zh-CN"))
      {
        this.Lable_OpenFloder = lable_OpenFloder;
        this.Lable_SelectTexg = lable_SelectTexg;
        this.Lable_CancelText = lable_CancelText;
      }
      else
      {
        this.Lable_OpenFloder = "Folder:";
        this.Lable_SelectTexg = "Select";
        this.Lable_CancelText = "Cancel";
      }
      this.mFileDialogEx = fileDialogEx;
      this.Text = "";
      this.StartPosition = FormStartPosition.Manual;
      this.Location = new Point(-32000, -32000);
      this.ShowInTaskbar = false;
    }

    protected override void OnClosing(CancelEventArgs e)
    {
      if (this.mNativeDialog != null)
        this.mNativeDialog.Dispose();
      base.OnClosing(e);
    }

    protected override void WndProc(ref Message m)
    {
      if (this.mWatchForActivate && m.Msg == 6)
      {
        this.mWatchForActivate = false;
        this.mOpenDialogHandle = m.LParam;
        this.mNativeDialog = new OpenDialogNative(m.LParam, this.mFileDialogEx, this.Handle, this.Lable_OpenFloder, this.Lable_SelectTexg, this.Lable_CancelText);
      }
      base.WndProc(ref m);
    }
  }
}
