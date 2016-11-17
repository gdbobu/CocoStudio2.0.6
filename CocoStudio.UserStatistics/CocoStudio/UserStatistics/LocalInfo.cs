// Decompiled with JetBrains decompiler
// Type: CocoStudio.UserStatistics.LocalInfo
// Assembly: CocoStudio.UserStatistics, Version=1.3.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8836CE71-EF24-435F-B92F-7A743482F0F7
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.UserStatistics.dll

using Gdk;
using MonoDevelop.Core;
using System;
using System.Globalization;
using System.Management;
using System.Net.NetworkInformation;

namespace CocoStudio.UserStatistics
{
  public class LocalInfo
  {
    public string installationID = "";
    public static Hyperic.Sigar.Sigar sigar;
    public string OSName;
    public string OSVersion;
    public string OSBit;
    public string OSLan;
    public string FrameVer;
    public string OSMemory;
    public string ScreenResulotion;
    public string ScreenCount;
    public string ScreenDpi;
    public string CPUCoreCount;
    public string MACAddress;
    public string isVM;

    public LocalInfo()
    {
      try
      {
        this.init();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
      }
    }

    private void init()
    {
      this.OSVersion = Environment.OSVersion.ToString();
      this.OSBit = Environment.Is64BitOperatingSystem ? "x64" : "x86";
      this.OSLan = this.GetLanguage();
      this.FrameVer = Environment.Version.ToString();
      this.ScreenResulotion = Screen.Default.Width.ToString() + "*" + (object) Screen.Default.Height;
      this.ScreenCount = Screen.Default.NMonitors.ToString();
      this.ScreenDpi = this.GetDPI().ToString();
      this.CPUCoreCount = Environment.ProcessorCount.ToString();
      this.OSName = this.GetOSName();
      this.MACAddress = LocalInfo.GetMacAddress();
      this.isVM = this.GetIsVM().ToString();
    }

    private static int GetPhisicalMemory()
    {
      if (Platform.IsMac)
        return 0;
      ManagementObjectCollection.ManagementObjectEnumerator enumerator = new ManagementObjectSearcher() { Query = ((ObjectQuery) new SelectQuery("Win32_PhysicalMemory ", "", new string[1]{ "Capacity" })) }.Get().GetEnumerator();
      long num = 0;
      while (enumerator.MoveNext())
      {
        ManagementBaseObject current = enumerator.Current;
        if (current.Properties["Capacity"].Value != null)
        {
          try
          {
            num += long.Parse(current.Properties["Capacity"].Value.ToString());
          }
          catch
          {
            return 0;
          }
        }
      }
      return (int) (num / 1024L / 1024L);
    }

    private string GetLanguage()
    {
      return CultureInfo.InstalledUICulture.NativeName.ToString();
    }

    private double GetDPI()
    {
      return Screen.Default.Resolution;
    }

    public string GetOSName()
    {
      Version version = Environment.OSVersion.Version;
      return !Platform.IsWindows ? "MacOSX" : (version.Major != 5 || version.Minor != 0 ? (version.Major != 5 || version.Minor != 1 ? (version.Major != 5 || version.Minor != 2 ? (version.Major != 6 || version.Minor != 0 ? (version.Major != 6 || version.Minor != 1 ? (version.Major != 6 || version.Minor != 2 ? "未知" : "Windows8") : "Windows7") : "Windows Vista") : "Windows 2003") : "Windows XP") : "Windows 2000");
    }

    public static string GetMacAddress()
    {
      string str = "";
      try
      {
        foreach (NetworkInterface networkInterface in NetworkInterface.GetAllNetworkInterfaces())
        {
          if (!networkInterface.GetPhysicalAddress().ToString().Equals(""))
          {
            str = networkInterface.GetPhysicalAddress().ToString();
            for (int index = 1; index < 6; ++index)
              str = str.Insert(3 * index - 1, ":");
            break;
          }
        }
      }
      catch
      {
      }
      return str;
    }

    public bool GetIsVM()
    {
      return false;
    }
  }
}
