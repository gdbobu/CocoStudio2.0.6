// Decompiled with JetBrains decompiler
// Type: OpenDialogs.BaseDialogNative
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace OpenDialogs
{
  public class BaseDialogNative : NativeWindow, IDisposable
  {
    private IntPtr mhandle;

    public event BaseDialogNative.ComfirmChangedHandler ComfirmChanged;

    public event BaseDialogNative.FileNameChangedHandler FileNameChanged;

    public event BaseDialogNative.FileNameChangedHandler FolderNameChanged;

    public event BaseDialogNative.FilesChangedHandler FilesSelected;

    public BaseDialogNative(IntPtr handle)
    {
      this.mhandle = handle;
      this.AssignHandle(handle);
    }

    public void Dispose()
    {
      this.ReleaseHandle();
    }

    protected override void WndProc(ref Message m)
    {
      if (m.Msg == 78)
      {
        OFNOTIFY structure = (OFNOTIFY) Marshal.PtrToStructure(m.LParam, typeof (OFNOTIFY));
        if ((int) structure.hdr.code == -602)
        {
          StringBuilder stringBuilder = new StringBuilder(102400);
          NativeMethods.SendMessage(NativeMethods.GetParent(this.mhandle), 1125, 102400, stringBuilder);
          if (this.FileNameChanged != null)
            this.FileNameChanged(this, stringBuilder.ToString());
        }
        else if ((int) structure.hdr.code == -603)
        {
          StringBuilder stringBuilder = new StringBuilder(256);
          NativeMethods.SendMessage(NativeMethods.GetParent(this.mhandle), 1126, 256, stringBuilder);
          if (this.FolderNameChanged != null)
            this.FolderNameChanged(this, stringBuilder.ToString());
        }
        if (this.FilesSelected != null)
          this.FilesSelected(this, this.mhandle);
      }
      base.WndProc(ref m);
    }

    public delegate void FileNameChangedHandler(BaseDialogNative sender, string filePath);

    public delegate void ComfirmChangedHandler(BaseDialogNative sender);

    public delegate void FilesChangedHandler(BaseDialogNative sender, IntPtr handle);
  }
}
