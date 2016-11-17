// Decompiled with JetBrains decompiler
// Type: Modules.Communal.Packer.PListImageReader
// Assembly: Modules.Communal.Packer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C7209B7C-6A4B-4239-96DC-96EFD0A7660A
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.Packer.dll

using Modules.Communal.Packer.PlistReader;
using Modules.Communal.PList;
using Modules.Communal.PList.Internal;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Modules.Communal.Packer
{
  public class PListImageReader
  {
    private PlistImageFormat plistFormatAnalysis;
    private PListDict rootElement;
    private string plistFilePath;
    private List<ImageInfo> imageList;

    public List<ImageInfo> ImageList
    {
      get
      {
        if (this.imageList == null)
          this.imageList = this.plistFormatAnalysis.ToImageList(this.rootElement);
        return this.imageList;
      }
    }

    public string ImageFilePath { get; private set; }

    public PListImageReader(string plistFilePath)
    {
      PListImageReader.CheckFile(plistFilePath);
      PListRoot listRoot = (PListRoot) null;
      using (FileStream fileStream = File.Open(plistFilePath, FileMode.Open, FileAccess.Read))
        listRoot = PListRoot.Load((Stream) fileStream);
      if (listRoot == null || listRoot.Root == null || !(listRoot.Root is PListDict))
        throw new ArgumentException("给定的PList文件格式不正确.");
      if (!PListImageReader.CheckPList(listRoot))
        throw new ArgumentException("给定的PList文件,不是大图合并的文件.");
      this.rootElement = listRoot.Root as PListDict;
      this.plistFilePath = plistFilePath;
      this.plistFormatAnalysis = PlistImageFormatFactory.CreatePlistFormat(this.rootElement);
      this.ImageFilePath = this.plistFormatAnalysis.GetImageFilePath(plistFilePath);
      if (this.ImageFilePath == null || !File.Exists(this.ImageFilePath))
        throw new ArgumentException("对应的图片文件不存在.");
    }

    private static bool CheckFile(string plistFilePath)
    {
      if (!File.Exists(plistFilePath))
        throw new FileNotFoundException(plistFilePath);
      if (!plistFilePath.ToLower().EndsWith(".plist"))
        throw new ArgumentException("必须使用.plist文件初始化");
      return true;
    }

    public bool IsContainSubImage(string key)
    {
      if (this.imageList == null)
        this.imageList = this.plistFormatAnalysis.ToImageList(this.rootElement);
      foreach (ImageInfo image in this.imageList)
      {
        if (image.Name == key)
          return true;
      }
      return false;
    }

    private static bool CheckPList(PListRoot listRoot)
    {
      return ((Dictionary<string, IPListElement>) listRoot.Root).ContainsKey("metadata");
    }

    public static bool CheckIsImage(string plistFilePath)
    {
      if (!PListImageReader.CheckFile(plistFilePath))
        return false;
      PListRoot listRoot = (PListRoot) null;
      using (FileStream fileStream = File.Open(plistFilePath, FileMode.Open, FileAccess.Read))
        listRoot = PListRoot.Load((Stream) fileStream);
      return PListImageReader.CheckPList(listRoot);
    }

    public static string GetMatchImageFile(string plistFilePath)
    {
      PlistImageFormat plistFormat = PlistImageFormatFactory.CreatePlistFormat(plistFilePath);
      if (plistFormat != null)
        return plistFormat.GetImageFilePath(plistFilePath);
      return string.Empty;
    }

    public string GetValueByKey(string key)
    {
      string str = (string) null;
      if (this.rootElement != null)
        str = ((PListElement<string>) this.rootElement[key]).Value;
      return str;
    }

    public void SaveAllSubImage(string dirPath)
    {
      this.SaveAllSubImage(dirPath, false, true);
    }

    public void SaveAllSubImage(string dirPath, bool isRetainEdge, bool isHideDir)
    {
      GC.Collect();
      if (!File.Exists(this.ImageFilePath))
        return;
      if (!Directory.Exists(dirPath))
      {
        DirectoryInfo directory = Directory.CreateDirectory(dirPath);
        if (isHideDir)
          directory.Attributes = FileAttributes.Hidden;
      }
      using (FileStream fileStream = File.Open(this.ImageFilePath, FileMode.Open, FileAccess.Read))
      {
        Bitmap bigImage = new Bitmap((Stream) fileStream);
        foreach (ImageInfo image in this.ImageList)
        {
          Bitmap bitmap = !isRetainEdge ? this.CreateSubImage(bigImage, image) : this.CreateSubImageWithEdge(bigImage, image);
          bitmap.Save(Path.Combine(dirPath, image.FileName), ImageFormat.Png);
          bitmap.Dispose();
        }
        bigImage.Dispose();
      }
    }

    private Bitmap CreateSubImage(Bitmap bigImage, ImageInfo imageInfo)
    {
      Rectangle bounding = imageInfo.Bounding;
      Rectangle rect = bounding;
      if (imageInfo.IsRotation)
        rect = new Rectangle(bounding.X, bounding.Y, bounding.Height, bounding.Width);
      Bitmap bitmap = bigImage.Clone(rect, bigImage.PixelFormat);
      if (imageInfo.IsRotation)
        bitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);
      return bitmap;
    }

    private Bitmap CreateSubImageWithEdge(Bitmap bigImage, ImageInfo imageInfo)
    {
      using (Bitmap subImage = this.CreateSubImage(bigImage, imageInfo))
      {
        Bitmap bitmap = new Bitmap(imageInfo.SourceSize.Width, imageInfo.SourceSize.Height, bigImage.PixelFormat);
        Graphics graphics = Graphics.FromImage((Image) bitmap);
        graphics.DrawImage((Image) subImage, new Rectangle(imageInfo.SourceLocation, imageInfo.Bounding.Size));
        graphics.Dispose();
        return bitmap;
      }
    }
  }
}
