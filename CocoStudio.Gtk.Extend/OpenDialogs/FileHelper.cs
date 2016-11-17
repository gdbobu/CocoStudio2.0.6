// Decompiled with JetBrains decompiler
// Type: OpenDialogs.FileHelper
// Assembly: CocoStudio.Gtk.Extend, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DBDD1FAC-46EB-4E25-BF62-EB35EC7EDA10
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Gtk.Extend.dll

using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenDialogs
{
  public static class FileHelper
  {
    public static bool IsFileOrDirectory(this string path)
    {
      if (!string.IsNullOrWhiteSpace(path))
      {
        try
        {
          if (Directory.Exists(path))
            return true;
          if (File.Exists(path))
          {
            FileInfo fileInfo = new FileInfo(path);
            return fileInfo != null && fileInfo.Exists;
          }
        }
        catch
        {
        }
      }
      return false;
    }

    public static string GetLnkRealtivePath(this string path)
    {
      LnkHelper.IShellLink shellLink = (LnkHelper.IShellLink) new LnkHelper.ShellLink();
      (shellLink as UCOMIPersistFile).Load(path, 0);
      StringBuilder pszFile = new StringBuilder(260);
      LnkHelper.WIN32_FIND_DATA pfd;
      shellLink.GetPath(pszFile, pszFile.Capacity, out pfd, LnkHelper.SLGP_FLAGS.SLGP_RAWPATH);
      return pszFile.ToString();
    }
  }
}
