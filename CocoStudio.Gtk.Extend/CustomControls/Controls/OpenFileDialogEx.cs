// Decompiled with JetBrains decompiler
// Type: CustomControls.Controls.OpenFileDialogEx
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using OpenDialogs;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace CustomControls.Controls
{
  public class OpenFileDialogEx : UserControl
  {
    private string lable_OpenFloder = "文件夹:";
    private string lable_SelectTexg = "选择文件夹";
    private string lable_CancelText = "取消";
    private SetWindowPosFlags UFLAGSHIDE = SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOACTIVATE | SetWindowPosFlags.SWP_HIDEWINDOW | SetWindowPosFlags.SWP_NOOWNERZORDER;
    private FolderViewMode mDefaultViewMode = FolderViewMode.Default;
    private IContainer components = (IContainer) null;
    private DummyForm form;
    protected OpenFileDialog dlgOpen;
    protected TextBox textBox1;

    public virtual string Lable_OpenFloder
    {
      get
      {
        return this.lable_OpenFloder;
      }
    }

    public virtual string Lable_SelectTexg
    {
      get
      {
        return this.lable_SelectTexg;
      }
    }

    public virtual string Lable_CancelText
    {
      get
      {
        return this.lable_CancelText;
      }
    }

    public OpenFileDialog OpenDialog
    {
      get
      {
        return this.dlgOpen;
      }
    }

    [DefaultValue(FolderViewMode.Default)]
    public FolderViewMode DefaultViewMode
    {
      get
      {
        return this.mDefaultViewMode;
      }
      set
      {
        this.mDefaultViewMode = value;
      }
    }

    public virtual event EventHandler SelectedNameChanged;

    public event OpenFileDialogEx.FileNameChangedHandler FileNameChanged;

    public event OpenFileDialogEx.FileNameChangedHandler FolderNameChanged;

    public event EventHandler ClosingDialog;

    protected event OpenFileDialogEx.FilesChangedHandler FilesSelected;

    public OpenFileDialogEx()
    {
      this.InitializeComponent();
      this.DefaultViewMode = FolderViewMode.Default;
      this.OpenDialog.AddExtension = false;
      this.OpenDialog.CheckFileExists = false;
      this.OpenDialog.ValidateNames = true;
      this.OpenDialog.ShowHelp = true;
      this.SizeChanged += new EventHandler(this.OpenFileDialogEx_SizeChanged);
      this.OpenDialog.HelpRequest += new EventHandler(this.OpenDialog_HelpRequest);
      this.Disposed += new EventHandler(this.OpenFileDialogEx_Disposed);
      this.OpenDialog.DereferenceLinks = true;
    }

    private void OpenFileDialogEx_Disposed(object sender, EventArgs e)
    {
      WindowHelper.ShowCurrentWindowHandle();
    }

    private void OpenDialog_HelpRequest(object sender, EventArgs e)
    {
      this.Close();
      this.OnSelectedNameChanged();
    }

    private void OpenFileDialogEx_SizeChanged(object sender, EventArgs e)
    {
      this.textBox1.Width = this.Width + 1;
    }

    public virtual void OnFileNameChanged(string fileName)
    {
      if (this.FileNameChanged == null)
        return;
      this.FileNameChanged(this, fileName);
    }

    public virtual void OnFolderNameChanged(string folderName)
    {
      if (this.FolderNameChanged == null)
        return;
      this.FolderNameChanged(this, folderName);
    }

    public virtual void OnFilesSelectedHandle(IntPtr handle)
    {
      if (this.FilesSelected == null)
        return;
      this.FilesSelected(this, handle);
    }

    public virtual void OnClosingDialog()
    {
      if (this.ClosingDialog == null)
        return;
      this.ClosingDialog((object) this, new EventArgs());
    }

    public virtual void OnSelectedNameChanged()
    {
      if (this.SelectedNameChanged == null)
        return;
      this.SelectedNameChanged((object) this, EventArgs.Empty);
    }

    public virtual void SetShowText(string directorypath)
    {
      if (!new DirectoryInfo(directorypath).Exists)
        return;
      this.OpenDialog.InitialDirectory = directorypath;
    }

    public void ShowDialog()
    {
      this.ShowDialog((IWin32Window) null);
    }

    public void ShowDialog(IWin32Window owner)
    {
      this.form = new DummyForm(this, this.Lable_OpenFloder, this.Lable_SelectTexg, this.Lable_CancelText);
      this.form.Show(owner);
      NativeMethods.SetWindowPos(this.form.Handle, IntPtr.Zero, 0, 0, 0, 0, this.UFLAGSHIDE);
      this.form.WatchForActivate = true;
      try
      {
        int num = (int) this.dlgOpen.ShowDialog((IWin32Window) this.form);
      }
      catch (Exception )
      {
      }
      this.form.Dispose();
      this.form.Close();
      this.Dispose();
    }

    public void Close()
    {
      if (this.form == null)
        return;
      this.form.Dispose();
      this.form.Close();
      this.Dispose();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.dlgOpen = new OpenFileDialog();
      this.textBox1 = new TextBox();
      this.SuspendLayout();
      this.textBox1.Name = "textBox1";
      this.textBox1.TabIndex = 0;
      this.Controls.Add((Control) this.textBox1);
      this.Name = "OpenFileDialogEx";
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public delegate void FileNameChangedHandler(OpenFileDialogEx sender, string filePath);

    protected delegate void FilesChangedHandler(OpenFileDialogEx sender, IntPtr handle);
  }
}
