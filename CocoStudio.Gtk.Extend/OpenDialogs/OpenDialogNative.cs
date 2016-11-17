// Decompiled with JetBrains decompiler
// Type: OpenDialogs.OpenDialogNative
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using CustomControls.Controls;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace OpenDialogs
{
  public class OpenDialogNative : NativeWindow, IDisposable
  {
    public string Lable_OpenFloder = "文件夹:";
    public string Lable_SelectTexg = "选择文件夹";
    public string Lable_CancelText = "取消";
    private SetWindowPosFlags UFLAGSSIZE = SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOACTIVATE | SetWindowPosFlags.SWP_NOOWNERZORDER;
    private SetWindowPosFlags UFLAGSHIDE = SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOACTIVATE | SetWindowPosFlags.SWP_HIDEWINDOW | SetWindowPosFlags.SWP_NOOWNERZORDER;
    private SetWindowPosFlags UFLAGSZORDER = SetWindowPosFlags.SWP_NOSIZE | SetWindowPosFlags.SWP_NOMOVE | SetWindowPosFlags.SWP_NOACTIVATE;
    private bool mIsClosing = false;
    private bool mInitializated = false;
    private RECT mOpenDialogWindowRect = new RECT();
    private RECT mOpenDialogClientRect = new RECT();
    private Size mOriginalSize;
    private IntPtr mOpenDialogHandle;
    private IntPtr mListViewPtr;
    private WINDOWINFO mListViewInfo;
    private IntPtr mComboFolders;
    private WINDOWINFO mComboFoldersInfo;
    private IntPtr mGroupButtons;
    private WINDOWINFO mGroupButtonsInfo;
    private IntPtr mComboFileName;
    private WINDOWINFO mComboFileNameInfo;
    private IntPtr mComboExtensions;
    private WINDOWINFO mComboExtensionsInfo;
    private IntPtr mOpenButton;
    private WINDOWINFO mOpenButtonInfo;
    private IntPtr mCancelButton;
    private WINDOWINFO mCancelButtonInfo;
    private IntPtr mHelpButton;
    private WINDOWINFO mHelpButtonInfo;
    private OpenFileDialogEx mSourceControl;
    private IntPtr mToolBarFolders;
    private WINDOWINFO mToolBarFoldersInfo;
    private IntPtr mLabelFileName;
    private WINDOWINFO mLabelFileNameInfo;
    private IntPtr mLabelFileType;
    private WINDOWINFO mLabelFileTypeInfo;
    private IntPtr mChkReadOnly;
    private WINDOWINFO mChkReadOnlyInfo;
    private IntPtr ParentHandle;

    public BaseDialogNative BaseDialogNative { get; private set; }

    public bool IsClosing
    {
      get
      {
        return this.mIsClosing;
      }
      set
      {
        this.mIsClosing = value;
      }
    }

    public OpenDialogNative(IntPtr handle, OpenFileDialogEx sourceControl, IntPtr parentHandle, string lable_OpenFloder, string lable_SelectTexg, string lable_CancelText)
    {
      this.Lable_OpenFloder = lable_OpenFloder;
      this.Lable_SelectTexg = lable_SelectTexg;
      this.Lable_CancelText = lable_CancelText;
      this.ParentHandle = parentHandle;
      this.mOpenDialogHandle = handle;
      this.mSourceControl = sourceControl;
      this.AssignHandle(this.mOpenDialogHandle);
    }

    private void BaseDialogNative_FileNameChanged(BaseDialogNative sender, string filePath)
    {
      if (this.mSourceControl == null)
        return;
      this.mSourceControl.OnFileNameChanged(filePath);
    }

    private void BaseDialogNative_FolderNameChanged(BaseDialogNative sender, string folderName)
    {
      if (this.mSourceControl == null)
        return;
      this.mSourceControl.OnFolderNameChanged(folderName);
    }

    private void BaseDialogNative_FilesSelectedChanged(BaseDialogNative sender, IntPtr handle)
    {
      if (this.mSourceControl == null)
        return;
      this.mSourceControl.OnFilesSelectedHandle(handle);
    }

    public void Dispose()
    {
      this.ReleaseHandle();
      if (this.BaseDialogNative == null)
        return;
      this.BaseDialogNative.FileNameChanged -= new BaseDialogNative.FileNameChangedHandler(this.BaseDialogNative_FileNameChanged);
      this.BaseDialogNative.FolderNameChanged -= new BaseDialogNative.FileNameChangedHandler(this.BaseDialogNative_FolderNameChanged);
      this.BaseDialogNative.FilesSelected -= new BaseDialogNative.FilesChangedHandler(this.BaseDialogNative_FilesSelectedChanged);
      this.BaseDialogNative.Dispose();
    }

    private void PopulateWindowsHandlers()
    {
      NativeMethods.EnumChildWindows(this.mOpenDialogHandle, new NativeMethods.EnumWindowsCallBack(this.OpenFileDialogEnumWindowCallBack), 1);
    }

    private bool OpenFileDialogEnumWindowCallBack(IntPtr hwnd, int lParam)
    {
      StringBuilder stringBuilder = new StringBuilder(256);
      NativeMethods.GetClassName(hwnd, stringBuilder, stringBuilder.Capacity);
      int dlgCtrlId = NativeMethods.GetDlgCtrlID(hwnd);
      WINDOWINFO pwi;
      NativeMethods.GetWindowInfo(hwnd, out pwi);
      if (stringBuilder.ToString().StartsWith("#32770"))
      {
        this.BaseDialogNative = new BaseDialogNative(hwnd);
        this.BaseDialogNative.FileNameChanged += new BaseDialogNative.FileNameChangedHandler(this.BaseDialogNative_FileNameChanged);
        this.BaseDialogNative.FolderNameChanged += new BaseDialogNative.FileNameChangedHandler(this.BaseDialogNative_FolderNameChanged);
        this.BaseDialogNative.FilesSelected += new BaseDialogNative.FilesChangedHandler(this.BaseDialogNative_FilesSelectedChanged);
        return true;
      }
      switch ((ControlsID) dlgCtrlId)
      {
        case ControlsID.ComboFileName:
          if (stringBuilder.ToString().ToLower() == "comboboxex32")
          {
            this.mComboFileName = hwnd;
            this.mComboFileNameInfo = pwi;
            NativeMethods.ShowWindow(hwnd, 0);
            break;
          }
          break;
        case ControlsID.LeftToolBar:
          this.mToolBarFolders = hwnd;
          this.mToolBarFoldersInfo = pwi;
          break;
        case ControlsID.DefaultView:
          this.mListViewPtr = hwnd;
          NativeMethods.GetWindowInfo(hwnd, out this.mListViewInfo);
          if (this.mSourceControl.DefaultViewMode != FolderViewMode.Default)
          {
            NativeMethods.SendMessage(this.mListViewPtr, 273, (int) this.mSourceControl.DefaultViewMode, 0);
            break;
          }
          break;
        case ControlsID.ComboFileType:
          this.mComboExtensions = hwnd;
          this.mComboExtensionsInfo = pwi;
          NativeMethods.ShowWindow(hwnd, 0);
          break;
        case ControlsID.ComboFolder:
          this.mComboFolders = hwnd;
          this.mComboFoldersInfo = pwi;
          break;
        case ControlsID.ButtonOpen:
          this.mOpenButton = hwnd;
          this.mOpenButtonInfo = pwi;
          break;
        case ControlsID.ButtonCancel:
          this.mCancelButton = hwnd;
          this.mCancelButtonInfo = pwi;
          NativeMethods.SetWindowText(hwnd, this.Lable_CancelText);
          break;
        case ControlsID.ButtonHelp:
          this.mHelpButton = hwnd;
          this.mHelpButtonInfo = pwi;
          NativeMethods.SetWindowText(hwnd, this.Lable_SelectTexg);
          break;
        case ControlsID.CheckBoxReadOnly:
          this.mChkReadOnly = hwnd;
          this.mChkReadOnlyInfo = pwi;
          NativeMethods.ShowWindow(hwnd, 0);
          break;
        case ControlsID.GroupFolder:
          this.mGroupButtons = hwnd;
          this.mGroupButtonsInfo = pwi;
          break;
        case ControlsID.LabelFileType:
          this.mLabelFileType = hwnd;
          this.mLabelFileTypeInfo = pwi;
          NativeMethods.ShowWindow(hwnd, 0);
          break;
        case ControlsID.LabelFileName:
          this.mLabelFileName = hwnd;
          this.mLabelFileNameInfo = pwi;
          NativeMethods.SetWindowText(hwnd, this.Lable_OpenFloder);
          break;
      }
      return true;
    }

    private void InitControls()
    {
      this.mInitializated = true;
      NativeMethods.GetClientRect(this.mOpenDialogHandle, ref this.mOpenDialogClientRect);
      NativeMethods.GetWindowRect(this.mOpenDialogHandle, ref this.mOpenDialogWindowRect);
      this.PopulateWindowsHandlers();
      this.SetCustomPosition(true);
      NativeMethods.SetParent(this.mSourceControl.Handle, this.mOpenDialogHandle);
      NativeMethods.SetWindowPos(this.mSourceControl.Handle, (IntPtr) 1L, 0, 0, 0, 0, this.UFLAGSZORDER);
    }

    private void SetCustomPosition(bool islocation = false)
    {
      RECT rect1 = new RECT();
      NativeMethods.GetWindowRect(this.mComboFileName, ref rect1);
      RECT rect2 = new RECT();
      NativeMethods.GetWindowRect(this.mOpenDialogHandle, ref rect2);
      uint num1 = (uint) ((int) rect1.left - (int) rect2.left - 8);
      uint num2 = (uint) ((int) rect1.top - (int) rect2.top - 30);
      if (islocation)
      {
        this.mSourceControl.Location = new Point((int) num1, (int) num2);
        RECT rect3 = new RECT();
        NativeMethods.GetWindowRect(this.mOpenButton, ref rect3);
        NativeMethods.SetWindowPos(this.mHelpButton, (IntPtr) 0, (int) rect3.left - (int) rect2.left - 8, (int) num2, (int) rect3.Width, (int) rect3.Height, SetWindowPosFlags.SWP_SHOWWINDOW);
        NativeMethods.ShowWindow(this.mOpenButton, 0);
      }
      else
        this.mSourceControl.Width = (int) rect1.Width;
    }

    protected override void WndProc(ref Message m)
    {
      bool flag = false;
      switch (m.Msg)
      {
        case 24:
          this.mInitializated = true;
          this.InitControls();
          break;
        case 70:
          if (!this.mIsClosing)
          {
            if (!this.mInitializated)
            {
              float num1;
              float num2 = num1 = 96f;
              using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero))
              {
                num2 = graphics.DpiX;
                num1 = graphics.DpiY;
              }
              WINDOWPOS structure = (WINDOWPOS) Marshal.PtrToStructure(m.LParam, typeof (WINDOWPOS));
              structure.cy = (int) (400.0 * ((double) num2 / 96.0));
              Marshal.StructureToPtr((object) structure, m.LParam, true);
            }
            if (!this.mComboFileName.Equals((object) IntPtr.Zero))
              this.SetCustomPosition(false);
            break;
          }
          break;
        case 642:
          if (m.WParam == (IntPtr) 1L && !this.mIsClosing)
          {
            this.mIsClosing = true;
            this.mSourceControl.OnClosingDialog();
            NativeMethods.SetWindowPos(this.mOpenDialogHandle, IntPtr.Zero, 0, 0, 0, 0, this.UFLAGSHIDE);
            NativeMethods.GetWindowRect(this.mOpenDialogHandle, ref this.mOpenDialogWindowRect);
            NativeMethods.SetWindowPos(this.mOpenDialogHandle, IntPtr.Zero, (int) this.mOpenDialogWindowRect.left, (int) this.mOpenDialogWindowRect.top, this.mOriginalSize.Width, this.mOriginalSize.Height, this.UFLAGSSIZE);
            break;
          }
          break;
        case 2:
          if (!this.mIsClosing)
          {
            this.mIsClosing = true;
            NativeMethods.SetWindowPos(this.mOpenDialogHandle, IntPtr.Zero, 0, 0, 0, 0, this.UFLAGSHIDE);
            NativeMethods.GetWindowRect(this.mOpenDialogHandle, ref this.mOpenDialogWindowRect);
            NativeMethods.SetWindowPos(this.mOpenDialogHandle, IntPtr.Zero, (int) this.mOpenDialogWindowRect.left, (int) this.mOpenDialogWindowRect.top, this.mOriginalSize.Width, this.mOriginalSize.Height, this.UFLAGSSIZE);
            break;
          }
          break;
        case 5:
          flag = true;
          break;
      }
      base.WndProc(ref m);
      if (!flag || this.mComboFileName.Equals((object) IntPtr.Zero))
        return;
      this.SetCustomPosition(false);
    }
  }
}
