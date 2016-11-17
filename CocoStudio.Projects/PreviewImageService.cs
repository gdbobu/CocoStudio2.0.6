// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.PreviewImageService
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using System.Collections.Generic;
using System.IO;
using Xwt;
using Xwt.Drawing;

namespace CocoStudio.Projects
{
  public class PreviewImageService
  {
    private static Queue<ResourceItem> previewImageQueue = new Queue<ResourceItem>();
    private static Dictionary<ResourceItem, PreviewImageInfo> previewImageDic = new Dictionary<ResourceItem, PreviewImageInfo>();
    private const int MaxSize = 200;
    public const int MaxCount = 30;

    internal PreviewImageService()
    {
      PreviewImageService.previewImageDic = new Dictionary<ResourceItem, PreviewImageInfo>();
    }

    public PreviewImageInfo GetImage(ResourceItem image)
    {
      if (!File.Exists(image.PreviewImagePath) || !ProjectsService.Instance.IsImageFile(image.PreviewImagePath))
        return (PreviewImageInfo) null;
      if (image.IsNeedRefresh() || !PreviewImageService.previewImageDic.ContainsKey(image))
        this.UpdateImage(image);
      if (PreviewImageService.previewImageDic.ContainsKey(image))
        return PreviewImageService.previewImageDic[image];
      return (PreviewImageInfo) null;
    }

    internal void UpdateImage(ResourceItem image)
    {
      if (!File.Exists(image.PreviewImagePath) || !ProjectsService.Instance.IsImageFile(image.PreviewImagePath))
        return;
      Image image1 = Image.FromFile(image.PreviewImagePath);
      PreviewImageInfo previewImageInfo = new PreviewImageInfo(image1.Size, (Image) null);
      if (image1.Height > 200.0 || image1.Width > 200.0)
      {
        Size relativeSize = this.GetRelativeSize(image1.Size);
        image1 = image1.WithSize(relativeSize.Width, relativeSize.Height);
      }
      previewImageInfo.Image = image1;
      if (PreviewImageService.previewImageQueue.Contains(image))
      {
        PreviewImageService.previewImageDic[image] = previewImageInfo;
      }
      else
      {
        PreviewImageService.previewImageQueue.Enqueue(image);
        PreviewImageService.previewImageDic.Add(image, previewImageInfo);
      }
      if (PreviewImageService.previewImageQueue.Count <= 30)
        return;
      ResourceItem key = PreviewImageService.previewImageQueue.Dequeue();
      PreviewImageService.previewImageDic.Remove(key);
    }

    private Size GetRelativeSize(Size size)
    {
      double num1 = size.Width > size.Height ? size.Width : size.Height;
      if (num1 <= 200.0)
        return size;
      double num2 = 200.0 / num1;
      return new Size(size.Width * num2, size.Height * num2);
    }
  }
}
