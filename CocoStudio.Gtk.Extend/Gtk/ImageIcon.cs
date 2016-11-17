// Decompiled with JetBrains decompiler
// Type: Gtk.ImageIcon
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using CocoStudio.Basic;
using CocoStudio.DefaultResource;
using Gdk;
using Modules.Communal.MultiLanguage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Xwt.GtkBackend;

namespace Gtk
{
  public class ImageIcon
  {
    private static IconFactory iconFactory = new IconFactory();
    private static Dictionary<string, Xwt.Drawing.Image> icons = new Dictionary<string, Xwt.Drawing.Image>();
    private static int previewIconCacheMax = 50;
    private static Queue<string> previewIconNames = new Queue<string>();
    private static Dictionary<string, Xwt.Drawing.Image> previewIcons = new Dictionary<string, Xwt.Drawing.Image>();
    private const string hightDPIResourceName = "@2x";
    private const IconSize defaultIconSize = IconSize.Button;
    private static Assembly defaultResourceAssembly;

    public static bool IsRetinaScreen
    {
      get
      {
        return ImageIcon.ScaleFactor == 2.0;
      }
    }

    public static double ScaleFactor
    {
      get
      {
        return GtkWorkarounds.GetScaleFactor((Widget) ApplicationCurrent.MainWindow);
      }
    }

    public static Assembly DefaultResourceAssembly
    {
      get
      {
        if (ImageIcon.defaultResourceAssembly == (Assembly) null)
          ImageIcon.defaultResourceAssembly = typeof (Resources).Assembly;
        return ImageIcon.defaultResourceAssembly;
      }
    }

    static ImageIcon()
    {
      ImageIcon.iconFactory.AddDefault();
    }

    public static Xwt.Drawing.Image GetIcon(string resourceID)
    {
      Xwt.Drawing.Image image = (Xwt.Drawing.Image) null;
      if (ImageIcon.icons.TryGetValue(resourceID, out image))
        return image;
      Stream stream = Assembly.GetCallingAssembly().GetManifestResourceStream(resourceID) ?? Resources.GetResourceStream(resourceID);
      if (stream != null)
        ImageIcon.icons[resourceID] = image = Xwt.Drawing.Image.FromStream(stream);
      return image;
    }

    public static Xwt.Drawing.Image GetIconFromFile(string filePath)
    {
      Path.GetExtension(filePath);
      if (!File.Exists(filePath))
        return (Xwt.Drawing.Image) null;
      try
      {
        Xwt.Drawing.Image image1 = (Xwt.Drawing.Image) null;
        using (FileStream fileStream = File.Open(filePath, FileMode.Open, FileAccess.Read))
          image1 = Xwt.Drawing.Image.FromStream((Stream) fileStream);
        List<Xwt.Drawing.Image> imageList = new List<Xwt.Drawing.Image>();
        string resource2xId = ImageIcon.GetResource2xID(filePath);
        if (File.Exists(resource2xId))
        {
          using (FileStream fileStream = File.Open(resource2xId, FileMode.Open, FileAccess.Read))
          {
            Xwt.Drawing.Image image2 = Xwt.Drawing.Image.FromStream((Stream) fileStream);
            imageList.Add(image2);
          }
        }
        if (imageList.Count > 0)
        {
          imageList.Insert(0, image1);
          image1 = Xwt.Drawing.Image.CreateMultiResolutionImage((IEnumerable<Xwt.Drawing.Image>) imageList);
        }
        return image1;
      }
      catch (Exception ex)
      {
        LogConfig.Logger.Debug((object) LanguageInfo.MessageBox_Content170, ex);
        return (Xwt.Drawing.Image) null;
      }
    }

    public static Xwt.Drawing.Image GetPreviewIcon(string filePath, out double width, out double height, bool isFouse = false)
    {
      filePath = Path.Combine(filePath);
      Xwt.Drawing.Image image = (Xwt.Drawing.Image) null;
      if (!isFouse && ImageIcon.previewIcons.TryGetValue(filePath, out image))
      {
        width = image.Width;
        height = image.Height;
        return image;
      }
      image = ImageIcon.GetImageFromFile(filePath);
      if (image != null)
      {
        width = image.Width;
        height = image.Height;
        if (ImageIcon.previewIconNames.Count<string>() >= ImageIcon.previewIconCacheMax)
        {
          string key = ImageIcon.previewIconNames.Dequeue();
          ImageIcon.previewIcons.Remove(key);
        }
        double num = 1.0;
        if (image.Width > 46.0 && image.Width >= image.Height)
          num = 46.0 / image.Width;
        if (image.Height > 46.0 && image.Height >= image.Width)
          num = 46.0 / image.Height;
        image = image.Scale(num, num);
        ImageIcon.previewIcons[filePath] = image;
        ImageIcon.previewIconNames.Enqueue(filePath);
      }
      else
      {
        width = 0.0;
        height = 0.0;
      }
      return image;
    }

    private static Xwt.Drawing.Image GetImageFromFile(string filepath)
    {
      Xwt.Drawing.Image image = (Xwt.Drawing.Image) null;
      if (File.Exists(filepath))
      {
        using (FileStream fileStream = File.Open(filepath, FileMode.Open, FileAccess.Read))
          image = Xwt.Drawing.Image.FromStream((Stream) fileStream);
      }
      return image;
    }

    public static Pixbuf GetPixbuf(string resourceID)
    {
      Assembly callingAssembly = Assembly.GetCallingAssembly();
      IconSet iconSet = IconFactory.LookupDefault(resourceID);
      if (iconSet == null)
      {
        iconSet = new IconSet();
        ImageIcon.LoadIcon(iconSet, resourceID, callingAssembly);
        ImageIcon.iconFactory.Add(resourceID, iconSet);
      }
      return iconSet.RenderIcon(Widget.DefaultStyle, TextDirection.Ltr, StateType.Normal, IconSize.Button, (Widget) null, (string) null, ImageIcon.ScaleFactor);
    }

    private static void LoadIcon(IconSet iconSet, string resourceID, Assembly callingAssembly)
    {
      Pixbuf pixbuf1 = ImageIcon.LoadResource(resourceID, callingAssembly);
      Pixbuf pixbuf2 = ImageIcon.LoadResource2x(resourceID, callingAssembly);
      IconSource iconSource1 = new IconSource();
      ImageIcon.ConfigIconSource(pixbuf1, iconSource1);
      if (pixbuf2 != null)
      {
        GtkWorkarounds.SetSourceScale(iconSource1, 1.0);
        GtkWorkarounds.SetSourceScaleWildcarded(iconSource1, false);
        IconSource iconSource2 = new IconSource();
        ImageIcon.ConfigIconSource(pixbuf2, iconSource2);
        GtkWorkarounds.SetSourceScale(iconSource2, ImageIcon.ScaleFactor);
        GtkWorkarounds.SetSourceScaleWildcarded(iconSource2, false);
        iconSet.AddSource(iconSource2);
      }
      else
        iconSet.AddSource(iconSource1);
    }

    private static void ConfigIconSource(Pixbuf pixbuf, IconSource iconSource)
    {
      iconSource.Pixbuf = pixbuf;
      iconSource.Size = IconSize.Button;
      iconSource.SizeWildcarded = false;
    }

    private static Pixbuf LoadResource2x(string resourceID, Assembly callingAssembly)
    {
      return ImageIcon.LoadResource(ImageIcon.GetResource2xID(resourceID), callingAssembly);
    }

    private static Pixbuf LoadResource(string resourceID, Assembly callingAssembly)
    {
      Stream stream = callingAssembly.GetManifestResourceStream(resourceID) ?? Resources.GetResourceStream(resourceID);
      byte[] buffer;
      using (stream)
      {
        if (stream == null || stream.Length < 0L)
          return (Pixbuf) null;
        buffer = new byte[stream.Length];
        stream.Read(buffer, 0, (int) stream.Length);
      }
      return new Pixbuf(buffer);
    }

    private static string GetResource2xID(string resourceID)
    {
      string path2 = Path.GetFileNameWithoutExtension(resourceID) + "@2x" + Path.GetExtension(resourceID);
      if (Path.IsPathRooted(resourceID))
        path2 = Path.Combine(Path.GetDirectoryName(resourceID), path2);
      return path2;
    }
  }
}
