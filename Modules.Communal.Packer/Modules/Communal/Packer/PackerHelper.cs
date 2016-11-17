// Decompiled with JetBrains decompiler
// Type: Modules.Communal.Packer.PackerHelper
// Assembly: Modules.Communal.Packer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C7209B7C-6A4B-4239-96DC-96EFD0A7660A
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.Packer.dll

using CocoStudio.Basic;
using CocoStudio.ControlLib.Windows;
using Gdk;
using Gtk;
using Modules.Communal.MultiLanguage;
using Modules.Communal.PList;
using Nuclex.Game.Packing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Modules.Communal.Packer
{
  internal class PackerHelper
  {
    private float perCountForFullImage = 0.0f;
    private float process = 0.0f;
    public bool bAllCheck = false;
    public bool IsNoFileCollider = true;
    private bool bSelectALL = false;
    private bool bExport = false;
    private bool bFirstPlist = true;
    private List<string> ParseFileList = new List<string>();
    private int paddingPixel;
    private int maxWidth;
    private int maxHeight;
    private string fullPathStr;
    private string projectNameStr;
    private bool clipState;
    private float fResourceScale;
    public string resourcePathStr;
    private int packType;
    private int imageToSaveNum;
    private bool bResult;
    private RectanglePacker rectPacker;
    private List<PackerSprite> spriteList;
    public List<string> saveImageList;
    private ImageFileFormat saveFileFormat;
    public ImageFormat saveImageFormat;
    private Dictionary<string, Bitmap> ImageDirectory;
    private Dictionary<string, PListRoot> PlistDirectory;
    private Dictionary<string, string> CopyFileDirectory;
    private CoverEachFileDialog coverWindow;

    public event System.Action<int> ProgressChangeEvent;

    public PackerHelper()
    {
      this.bResult = true;
      this.bAllCheck = false;
      this.fResourceScale = 1f;
      this.saveImageList = new List<string>();
      this.ImageDirectory = new Dictionary<string, Bitmap>();
      this.PlistDirectory = new Dictionary<string, PListRoot>();
      this.CopyFileDirectory = new Dictionary<string, string>();
    }

    public void Timer_Event(object state)
    {
    }

    public void InitWithData(int padPixel, int maxW, int maxH, int typeIndex = 0)
    {
      this.spriteList = new List<PackerSprite>();
      this.packType = typeIndex;
      this.paddingPixel = padPixel;
      this.maxWidth = this.GetBinaryNum(maxW);
      this.maxHeight = this.GetBinaryNum(maxH);
      this.imageToSaveNum = 0;
    }

    public void InitRectPacker(int typeIndex)
    {
      int binaryNum1 = this.GetBinaryNum(this.maxWidth);
      int binaryNum2 = this.GetBinaryNum(this.maxHeight);
      switch (typeIndex)
      {
        case 0:
          this.rectPacker = (RectanglePacker) new SimpleRectanglePacker(binaryNum1, binaryNum2);
          break;
        case 1:
          this.rectPacker = (RectanglePacker) new CygonRectanglePacker(binaryNum1, binaryNum2);
          break;
        case 2:
          this.rectPacker = (RectanglePacker) new ArevaloRectanglePacker(binaryNum1, binaryNum2);
          break;
        default:
          this.rectPacker = (RectanglePacker) new ArevaloRectanglePacker(binaryNum1, binaryNum2);
          break;
      }
    }

    public bool PackerWithList(List<string> fileNameList, string fullPath, string projectName, bool bClip, ImageFileFormat fileFormat, string resoucesPath, float resourceScale, bool bEachFile = false)
    {
      if (!Directory.Exists(fullPath))
        Directory.CreateDirectory(fullPath);
      this.fullPathStr = fullPath;
      this.projectNameStr = projectName;
      this.saveFileFormat = fileFormat;
      this.bAllCheck = bEachFile;
      switch (this.saveFileFormat)
      {
        case ImageFileFormat.Png:
          this.saveImageFormat = ImageFormat.Png;
          break;
        case ImageFileFormat.Jpeg:
          this.saveImageFormat = ImageFormat.Jpeg;
          break;
      }
      this.resourcePathStr = resoucesPath;
      this.clipState = bClip;
      this.perCountForFullImage = (float) ((double) fileNameList.Count * 1.0 / 200.0);
      this.fResourceScale = resourceScale;
      List<string> stringList = new List<string>();
      foreach (string fileName in fileNameList)
      {
        string extensions = this.GetExtensions(fileName);
        if (extensions == ".png" || extensions == ".jpg")
        {
          string str = fileName;
          if (!Path.IsPathRooted(fileName))
            str = Path.Combine(this.resourcePathStr, fileName);
          Bitmap _map = (Bitmap) null;
          try
          {
            if (File.Exists(str))
            {
              Pixbuf pixbuf = PixbufHelper.Load(str);
              _map = new Bitmap((Stream) new MemoryStream(pixbuf.SaveToBuffer(extensions.Trim('.'))));
              pixbuf.Dispose();
            }
          }
          catch (Exception ex)
          {
            MessageBox.Show("Ex : " + ex.Message, (Gtk.Window) null, (string) null, MessageBoxImage.Info);
            break;
          }
          if (_map != null)
          {
            this.spriteList.Add(new PackerSprite(_map, fileName, this.clipState, true, resourceScale));
            _map.Dispose();
            this.RaiseProcessChange(this.perCountForFullImage);
          }
        }
        else if (this.GetExtensions(fileName) == ".plist")
        {
          stringList.Add(fileName);
          this.CopyPlistAndBigImage(fileName, this.fullPathStr);
          this.RaiseProcessChange(this.perCountForFullImage);
        }
      }
      foreach (string str in stringList)
        fileNameList.Remove(str);
      this.CalculationSpriteList(this.spriteList);
      this.SaveAllFile();
      return this.bResult;
    }

    private void SaveNewFileFirst(bool check)
    {
      List<string> stringList1 = new List<string>();
      foreach (KeyValuePair<string, Bitmap> keyValuePair in this.ImageDirectory)
      {
        if (!check || !File.Exists(keyValuePair.Key))
        {
          keyValuePair.Value.Save(keyValuePair.Key, ImageFormat.Png);
          keyValuePair.Value.Dispose();
          stringList1.Add(keyValuePair.Key);
        }
      }
      foreach (string key in stringList1)
        this.ImageDirectory.Remove(key);
      List<string> stringList2 = new List<string>();
      foreach (KeyValuePair<string, PListRoot> keyValuePair in this.PlistDirectory)
      {
        if (!check || !File.Exists(keyValuePair.Key))
        {
          keyValuePair.Value.Save(keyValuePair.Key, PListFormat.Xml);
          stringList2.Add(keyValuePair.Key);
        }
      }
      foreach (string key in stringList2)
        this.PlistDirectory.Remove(key);
      List<string> stringList3 = new List<string>();
      foreach (KeyValuePair<string, string> keyValuePair in this.CopyFileDirectory)
      {
        if (!check || !File.Exists(keyValuePair.Value))
        {
          File.Copy(keyValuePair.Key, keyValuePair.Value);
          stringList3.Add(keyValuePair.Key);
        }
      }
      foreach (string key in stringList3)
        this.CopyFileDirectory.Remove(key);
    }

    private void SaveAllFile()
    {
      this.SaveNewFileFirst(this.bAllCheck);
      if (!this.bAllCheck)
        return;
      int filecount = this.ImageDirectory.Count + this.PlistDirectory.Count + this.CopyFileDirectory.Count;
      if (filecount > 0)
        this.IsNoFileCollider = false;
      foreach (KeyValuePair<string, Bitmap> keyValuePair in this.ImageDirectory)
      {
        if (this.bSelectALL)
        {
          keyValuePair.Value.Save(keyValuePair.Key, ImageFormat.Png);
          keyValuePair.Value.Dispose();
        }
        else
        {
          this.CoveringJudgment(keyValuePair.Key, filecount);
          if (this.bExport)
          {
            keyValuePair.Value.Save(keyValuePair.Key, ImageFormat.Png);
            keyValuePair.Value.Dispose();
          }
          else if (this.bSelectALL)
            return;
        }
        --filecount;
      }
      foreach (KeyValuePair<string, PListRoot> keyValuePair in this.PlistDirectory)
      {
        if (this.bSelectALL)
        {
          keyValuePair.Value.Save(keyValuePair.Key, PListFormat.Xml);
        }
        else
        {
          this.CoveringJudgment(keyValuePair.Key, filecount);
          if (this.bExport)
            keyValuePair.Value.Save(keyValuePair.Key, PListFormat.Xml);
          else if (this.bSelectALL)
            return;
        }
        --filecount;
      }
      foreach (KeyValuePair<string, string> keyValuePair in this.CopyFileDirectory)
      {
        if (this.bSelectALL)
        {
          File.Copy(keyValuePair.Key, keyValuePair.Value, true);
        }
        else
        {
          this.CoveringJudgment(Path.GetFileName(keyValuePair.Value), filecount);
          if (this.bExport)
            File.Copy(keyValuePair.Key, keyValuePair.Value, true);
          else if (this.bSelectALL)
            break;
        }
        --filecount;
      }
    }

    private string DefaultImageRelativelyPath(string defaultImagePath)
    {
      return Path.Combine("GUI", Path.GetFileName(defaultImagePath));
    }

    public void CalculationSpriteList(List<PackerSprite> spriteFileList)
    {
      if (spriteFileList.Count <= 0)
      {
        this.RaiseProcessChange(100f);
      }
      else
      {
        this.InitRectPacker(this.packType);
        List<PackerSprite> saveSpriteList = new List<PackerSprite>();
        int num1 = 0;
        int num2 = 0;
        foreach (PackerSprite spriteFile in spriteFileList)
        {
          if (spriteFile != null)
          {
            int rectangleWidth = (int) spriteFile.width + this.paddingPixel;
            int rectangleHeight = (int) spriteFile.height + this.paddingPixel;
            System.Drawing.Point placement;
            if (this.rectPacker.TryPack(rectangleWidth, rectangleHeight, out placement))
            {
              num1 = Math.Max(num1, placement.X + rectangleWidth);
              num2 = Math.Max(num2, placement.Y + rectangleHeight);
              spriteFile.SetPosition(placement);
              saveSpriteList.Add(spriteFile);
              this.RaiseProcessChange(this.perCountForFullImage);
            }
            else if (rectangleWidth >= this.maxWidth || rectangleHeight >= this.maxHeight)
            {
              MessageBox.Show(LanguageInfo.MessageBox_Content1, (Gtk.Window) null, (string) null, MessageBoxImage.Info);
              this.bResult = false;
              return;
            }
          }
        }
        int binaryNum = this.GetBinaryNum(num2);
        Bitmap saveBitMap = new Bitmap(Math.Min(this.maxWidth, this.GetBinaryNum(num1)), Math.Min(this.maxHeight, binaryNum));
        Graphics gDraw = Graphics.FromImage((System.Drawing.Image) saveBitMap);
        foreach (PackerSprite packerSprite in saveSpriteList)
        {
          packerSprite.DrawToImage(gDraw, this.resourcePathStr);
          spriteFileList.Remove(packerSprite);
        }
        string strImageName = this.projectNameStr + this.imageToSaveNum.ToString();
        this.SaveImage(saveBitMap, strImageName);
        this.SavePlist(saveSpriteList, strImageName);
        gDraw.Dispose();
        ++this.imageToSaveNum;
        this.CalculationSpriteList(spriteFileList);
      }
    }

    public void CopyPlistAndBigImage(string _fileName, string fullPath)
    {
      string withoutExtension = Path.GetFileNameWithoutExtension(_fileName);
      this.SavePlistList(_fileName, true);
      string str1 = Path.Combine(this.resourcePathStr, _fileName);
      string str2 = Path.Combine(fullPath, _fileName);
      string str3 = Path.Combine(Path.GetDirectoryName(str1), withoutExtension + ".png");
      string str4 = Path.Combine(fullPath, Path.GetDirectoryName(_fileName), withoutExtension + ".png");
      if (!File.Exists(Path.GetDirectoryName(str4)))
        Directory.CreateDirectory(Path.GetDirectoryName(str4));
      if (File.Exists(str3))
      {
        File.Copy(str3, str4, true);
        this.GetResourceNormal(str4);
      }
      if (File.Exists(str1))
        File.Copy(str1, str2, true);
      this.GetResourceNormal(str2);
    }

    private void SavePlistList(string _PlsitFileName, bool isMergePlist = true)
    {
      if (isMergePlist && this.bFirstPlist && (double) this.fResourceScale != 1.0 && PackToolViewModel.Instance.EnumEditorID != EnumEditorIDE.Scene)
      {
        MessageBox.Show(LanguageInfo.MessageBox_Content128, (Gtk.Window) null, (string) null, MessageBoxImage.Info);
        this.bFirstPlist = false;
      }
      if (this.saveImageList.Contains(_PlsitFileName))
        return;
      this.saveImageList.Add(_PlsitFileName);
    }

    public void StartPacker()
    {
      this.EndPakcer();
    }

    public void EndPakcer()
    {
    }

    public void SaveImage(Bitmap saveBitMap, string strImageName)
    {
      string str = Path.Combine(this.fullPathStr, strImageName);
      string key = "";
      switch (this.saveFileFormat)
      {
        case ImageFileFormat.Png:
          key = str + ".png";
          break;
        case ImageFileFormat.Jpeg:
          key = str + ".jpg";
          break;
      }
      this.ImageDirectory.Add(key, saveBitMap);
      this.RaiseProcessChange(100f - this.process);
    }

    public void SavePlist(List<PackerSprite> saveSpriteList, string strImageName)
    {
      this.SavePlistList(strImageName + ".plist", false);
      PListRoot plistRoot = new PListRoot();
      PListDict plistDict1 = new PListDict();
      plistRoot.Root = (IPListElement) plistDict1;
      PListDict plistDict2 = new PListDict();
      plistDict1.Add("frames", (IPListElement) plistDict2);
      foreach (PackerSprite saveSprite in saveSpriteList)
      {
        PListDict plistDict3 = new PListDict();
        plistDict2.Add(saveSprite.name, (IPListElement) plistDict3);
        plistDict3.Add("width", (IPListElement) new PListInteger((long) (int) saveSprite.width));
        plistDict3.Add("height", (IPListElement) new PListInteger((long) (int) saveSprite.height));
        plistDict3.Add("originalWidth", (IPListElement) new PListInteger((long) (int) saveSprite.originalWidth));
        plistDict3.Add("originalHeight", (IPListElement) new PListInteger((long) (int) saveSprite.originalHeight));
        plistDict3.Add("x", (IPListElement) new PListInteger((long) (int) saveSprite.x));
        plistDict3.Add("y", (IPListElement) new PListInteger((long) (int) saveSprite.y));
        plistDict3.Add("offsetX", (IPListElement) new PListReal((double) saveSprite.offsetX));
        plistDict3.Add("offsetY", (IPListElement) new PListReal((double) saveSprite.offsetY));
      }
      string str1 = strImageName + ".png";
      string str2 = Path.Combine(this.fullPathStr, strImageName);
      PListDict plistDict4 = new PListDict();
      plistDict1.Add("metadata", (IPListElement) plistDict4);
      plistDict4.Add("format", (IPListElement) new PListInteger(0L));
      plistDict4.Add("textureFileName", (IPListElement) new PListString(str1));
      plistDict4.Add("realTextureFileName", (IPListElement) new PListString(str1));
      string str3 = "{" + (object) this.maxWidth + "," + (object) this.maxHeight + "}";
      plistDict4.Add("size", (IPListElement) new PListString(str3));
      PListDict plistDict5 = new PListDict();
      plistDict1.Add("texture", (IPListElement) plistDict5);
      plistDict5.Add("width", (IPListElement) new PListInteger((long) this.maxWidth));
      plistDict5.Add("height", (IPListElement) new PListInteger((long) this.maxHeight));
      this.PlistDirectory.Add(str2 + ".plist", plistRoot);
    }

    private void CoveringJudgment(string file, int filecount)
    {
      string fileName = Path.GetFileName(file);
      this.coverWindow = new CoverEachFileDialog();
      this.coverWindow.ConfirmClickHandler += new EventHandler(this.coverWindow_ConfirmClickHandler);
      this.coverWindow.RefreshMessage(fileName, filecount, "");
      this.coverWindow.Run();
      this.coverWindow.Destroy();
    }

    private void coverWindow_ConfirmClickHandler(object sender, EventArgs e)
    {
      this.bSelectALL = this.coverWindow.IsChangeAll;
      this.bExport = this.coverWindow.IsExportCover;
      if (!this.coverWindow.IsUnCancel)
        return;
      this.coverWindow.Destroy();
    }

    private void RaiseProcessChange(float addProcess)
    {
      this.process += addProcess;
      if (this.ProgressChangeEvent == null)
        return;
      this.ProgressChangeEvent((int) this.process);
    }

    private int GetBinaryNum(int num)
    {
      int num1 = 16;
      while (true)
      {
        if (num1 < num)
          num1 *= 2;
        else
          break;
      }
      return num1;
    }

    internal bool PackerCanNotBatchImage(List<string> fileList, string FilePath, string ResourcesPath)
    {
      try
      {
        this.IsCreateDirectory(FilePath);
        if (fileList == null || fileList.Count == 0)
          return true;
        float num = 100f / (float) fileList.Count;
        if (fileList.Count > 0)
        {
          foreach (string file in fileList)
          {
            if (Path.IsPathRooted(file))
              this.DefaultFileCopy(FilePath, file);
            else
              this.FileCopy(ResourcesPath, FilePath, file);
          }
        }
        return true;
      }
      catch (Exception )
      {
        return false;
      }
    }

    internal bool PackerSmallImage(List<string> fileList, string FilePath, string ResourcesPath, bool bcheckFile = false)
    {
      this.bAllCheck = bcheckFile;
      try
      {
        this.IsCreateDirectory(FilePath);
        if (fileList == null || fileList.Count == 0)
          return true;
        float addProcess = 100f / (float) fileList.Count;
        foreach (string file in fileList)
        {
          if (Path.IsPathRooted(file))
          {
            this.DefaultFileCopy(FilePath, file);
          }
          else
          {
            if (this.GetExtensions(file) == ".plist")
            {
              this.SavePlistList(file, true);
              string str = Path.Combine(Path.GetDirectoryName(file), Path.GetFileNameWithoutExtension(file) + ".png");
              this.FileCopy(ResourcesPath, FilePath, str);
            }
            this.FileCopy(ResourcesPath, FilePath, file);
          }
          this.RaiseProcessChange(addProcess);
        }
        this.SaveAllFile();
        return true;
      }
      catch (Exception )
      {
        return false;
      }
    }

    private void SaveDefaultImagePath(string path)
    {
      string path1 = Path.Combine(path, "GUI");
      if (Directory.Exists(path1))
        return;
      Directory.CreateDirectory(path1);
    }

    internal bool PackerAllImage(List<string> defaultFileList, List<string> NotPackDefaultFileList, string FilePath, string ResourcesPath, bool bcheckFile = false)
    {
      this.bAllCheck = bcheckFile;
      try
      {
        this.IsCreateDirectory(FilePath);
        List<string> directory = this.ParseDirectory(ResourcesPath);
        if (defaultFileList != null)
        {
          foreach (string defaultFile in defaultFileList)
          {
            if (Path.IsPathRooted(defaultFile))
              this.DefaultFileCopy(FilePath, defaultFile);
          }
        }
        if (NotPackDefaultFileList != null)
        {
          foreach (string notPackDefaultFile in NotPackDefaultFileList)
          {
            if (Path.IsPathRooted(notPackDefaultFile))
              this.DefaultFileCopy(FilePath, notPackDefaultFile);
          }
        }
        if (directory.Count > 0)
        {
          float addProcess = 100f / (float) directory.Count;
          foreach (string str in directory)
          {
            this.FileCopy(ResourcesPath, FilePath, str);
            this.RaiseProcessChange(addProcess);
          }
        }
        this.SaveAllFile();
        return true;
      }
      catch (Exception )
      {
        return false;
      }
    }

    private void DefaultFileCopy(string FilePath, string item)
    {
      this.SaveDefaultImagePath(FilePath);
      string str = Path.Combine(FilePath, "GUI", Path.GetFileName(item));
      this.CopyFileDirectory.Add(item, str);
    }

    private void FileCopy(string ResourcesPath, string FilePath, string item)
    {
      string str = Path.Combine(ResourcesPath, item);
      string newPath = Path.Combine(FilePath, item);
      this.IsCreateDirectory(newPath);
      if (!(str != newPath) || !File.Exists(str))
        return;
      this.CopyFileDirectory.Add(str, newPath);
    }

    private void IsCreateDirectory(string newPath)
    {
      if (Directory.Exists(Path.GetDirectoryName(newPath)))
        return;
      Directory.CreateDirectory(Path.GetDirectoryName(newPath));
    }

    internal List<string> ParseDirectory(string path)
    {
      string[] files = Directory.GetFiles(path);
      if (files.Length > 0)
      {
        foreach (string str in files)
        {
          if (this.GetExtensions(str) == ".png" || this.GetExtensions(str) == ".jpg" || (this.GetExtensions(str) == ".plist" || this.GetExtensions(str) == ".fnt") || this.GetExtensions(str) == ".ttf")
          {
            if (this.GetExtensions(str) == ".plist")
              this.SavePlistList(this.GetUserResourceRelativePath(str), true);
            this.ParseFileList.Add(this.GetUserResourceRelativePath(str));
          }
        }
      }
      foreach (string directory in (Array) Directory.GetDirectories(path))
      {
        if (!Path.GetFileName(directory).Contains("_PList.Dir"))
          this.ParseDirectory(directory);
      }
      return this.ParseFileList;
    }

    private string GetExtensions(string filePath)
    {
      return Path.GetExtension(filePath).ToLower();
    }

    public string ConvertToMacPath(string path)
    {
      return path.Replace('\\', '/').Trim('/');
    }

    private string GetUserResourceRelativePath(string fullPath)
    {
      return this.ConvertToMacPath(fullPath.Remove(0, this.resourcePathStr.Length));
    }

    private void GetResourceNormal(string filePath)
    {
      if (!File.Exists(filePath))
        return;
      FileInfo fileInfo = new FileInfo(filePath);
      if (fileInfo.Attributes.ToString().IndexOf("ReadOnly") != -1)
        fileInfo.Attributes = FileAttributes.Normal;
    }
  }
}
