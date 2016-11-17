// Decompiled with JetBrains decompiler
// Type: Modules.Communal.CocosCreator.StepCocosV2
// Assembly: Modules.Communal.CocosCreator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 70C77DE5-8380-4243-AAEF-73AA753A2D70
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.CocosCreator.dll

using CocoStudio.Basic;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Modules.Communal.CocosCreator
{
  internal class StepCocosV2 : CreateStep
  {
    private string language = "";
    private string src_cocos2dx_lib = "";
    private string dst_cocos2dx_lib = "";
    private string src_project_name = "";
    private string src_package_name = "";
    private string dst_project_name = "";
    private string dst_package_name = "";
    private string src_project_path = "";
    private string dst_project_path = "";
    private string script_dir = "";
    private string[] platforms_list;

    protected override bool OnRun(CreateParams prms)
    {
      if (this.Monitor.IsCancelled)
        return false;
      string str1 = Path.Combine(prms.Directory, prms.ProjName);
      this.InitParams(prms);
      if (Directory.Exists(this.dst_project_path))
      {
        this.SendOutputInfo(string.Format("{0} is already exist", (object) this.dst_project_path));
        return false;
      }
      Directory.CreateDirectory(str1);
      this.SendOutputInfo(string.Format("Based on {0}\r\nRunning command: new\r\nCopying cocos2d-x files... ", (object) prms.EngineInfo.VersionText));
      List<string> stringList1 = new List<string>();
      List<string> stringList2 = new List<string>();
      string str2 = Path.Combine(this.src_cocos2dx_lib, "cocos2dx");
      string str3 = Path.Combine(str1, "cocos2dx");
      stringList1.Add(str2);
      stringList2.Add(str3);
      string str4 = Path.Combine(this.src_cocos2dx_lib, "CocosDenshion");
      string str5 = Path.Combine(str1, "CocosDenshion");
      stringList1.Add(str4);
      stringList2.Add(str5);
      string str6 = Path.Combine(this.src_cocos2dx_lib, "extensions");
      string str7 = Path.Combine(str1, "extensions");
      stringList1.Add(str6);
      stringList2.Add(str7);
      string str8 = Path.Combine(this.src_cocos2dx_lib, "external");
      string str9 = Path.Combine(str1, "external");
      stringList1.Add(str8);
      stringList2.Add(str9);
      if (this.language == "lua" || this.language == "js")
      {
        string str10 = Path.Combine(this.src_cocos2dx_lib, "scripting");
        string str11 = Path.Combine(str1, "scripting");
        stringList1.Add(str10);
        stringList2.Add(str11);
      }
      stringList1.Add(this.src_project_path);
      stringList2.Add(this.dst_project_path);
      for (int index = 0; index < stringList1.Count; ++index)
      {
        if (this.Monitor.IsCancelled || !CreateHelper.CopyFolder(stringList1[index], stringList2[index], this.Monitor))
          return false;
      }
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format("Replace the project name from 'HelloCpp' to '{0}'", (object) prms.ProjName));
      stringBuilder.Append(string.Format("\r\nReplace the project package name from 'org.cocos2dx.hellocpp' to '{0}'", (object) prms.PkgName));
      this.SendOutputInfo(stringBuilder.ToString());
      for (int index = 0; index < this.platforms_list.Length; ++index)
        this.ProcessPlatformProjects(this.platforms_list[index]);
      return true;
    }

    protected override bool OnCanCreate(CreateParams prms)
    {
      return prms.EngineInfo != null && prms.EngineInfo.MainVersion == 2;
    }

    private void InitParams(CreateParams info)
    {
      this.src_cocos2dx_lib = info.EngineInfo.RootPath;
      this.dst_cocos2dx_lib = info.Directory;
      this.script_dir = this.src_cocos2dx_lib + "\\";
      this.dst_project_name = info.ProjName;
      this.dst_project_path = Path.Combine(this.dst_cocos2dx_lib, this.dst_project_name, "projects", this.dst_project_name);
      this.dst_package_name = info.PkgName;
      this.language = info.Language.ToString();
      if ("cpp" == this.language)
      {
        this.src_project_name = "HelloCpp";
        this.src_package_name = "org.cocos2dx.hellocpp";
        this.src_project_path = Path.Combine(this.src_cocos2dx_lib, "template", "multi-platform-cpp");
        this.platforms_list = new string[9]
        {
          "ios",
          "android",
          "win32",
          "winrt",
          "wp8",
          "mac",
          "blackberry",
          "linux",
          "marmalade"
        };
      }
      else if ("lua" == this.language)
      {
        this.src_project_name = "HelloLua";
        this.src_package_name = "org.cocos2dx.hellolua";
        this.src_project_path = Path.Combine(this.src_cocos2dx_lib, "template", "multi-platform-lua");
        this.platforms_list = new string[6]
        {
          "ios",
          "android",
          "win32",
          "blackberry",
          "linux",
          "marmalade"
        };
      }
      else
      {
        if (!("js" == this.language))
          return;
        this.src_project_name = "HelloJavascript";
        this.src_package_name = "org.cocos2dx.HelloJavascript";
        this.src_project_path = Path.Combine(this.src_cocos2dx_lib, "template", "multi-platform-js");
        this.platforms_list = new string[3]
        {
          "ios",
          "android",
          "win32"
        };
      }
    }

    private void ReplaceString(string filepath, string src_string, string dst_string)
    {
      string str1 = "";
      if (File.Exists(filepath))
      {
        StreamReader streamReader = new StreamReader(filepath);
        string str2;
        while ((str2 = streamReader.ReadLine()) != null)
        {
          if (str2.Contains(src_string))
            str2 = str2.Replace(src_string, dst_string);
          str1 = str1 + str2 + (object) '\n';
        }
        streamReader.Close();
      }
      FileStream fileStream = new FileStream(filepath, FileMode.Create);
      StreamWriter streamWriter = new StreamWriter((Stream) fileStream, Encoding.Default);
      streamWriter.Write(str1);
      streamWriter.Close();
      fileStream.Close();
    }

    private void ProcessPlatformProjects(string platform)
    {
      string path1 = Path.Combine(this.dst_project_path, "proj." + platform);
      string newValue = "";
      string path = Path.Combine(this.script_dir, "tools", "project-creator", platform + ".json");
      string json = "";
      if (File.Exists(path))
      {
        json = File.ReadAllText(path);
        if (string.IsNullOrWhiteSpace(json))
          return;
      }
      JObject jobject = !(json == "") ? JObject.Parse(json) : new JObject();
      if (platform == "android")
      {
        string[] strArray1 = this.src_package_name.Split('.');
        string[] strArray2 = this.dst_package_name.Split('.');
        string empty1 = string.Empty;
        string empty2 = string.Empty;
        if (Directory.Exists(Path.Combine(path1, "src", strArray1[0])))
        {
          string sourceDirName = Path.Combine(path1, "src", strArray1[0]);
          string destDirName = Path.Combine(path1, "src", strArray2[0]);
          if (sourceDirName != destDirName)
            Directory.Move(sourceDirName, destDirName);
        }
        if (Directory.Exists(Path.Combine(path1, "src", strArray2[0], strArray1[1])))
        {
          string sourceDirName = Path.Combine(path1, "src", strArray2[0], strArray1[1]);
          string destDirName = Path.Combine(path1, "src", strArray2[0], strArray2[1]);
          if (sourceDirName != destDirName)
            Directory.Move(sourceDirName, destDirName);
        }
        if (Directory.Exists(Path.Combine(path1, "src", strArray2[0], strArray2[1], strArray1[2])))
        {
          string sourceDirName = Path.Combine(path1, "src", strArray2[0], strArray2[1], strArray1[2]);
          string destDirName = Path.Combine(path1, "src", strArray2[0], strArray2[1], strArray2[2]);
          if (sourceDirName != destDirName)
            Directory.Move(sourceDirName, destDirName);
        }
        newValue = Path.Combine(strArray2[0], strArray2[1], strArray2[2]);
      }
      JToken jtoken1 = jobject["rename"];
      if (jtoken1 != null)
      {
        foreach (object obj in (IEnumerable<JToken>) jtoken1)
        {
          string str = obj.ToString().Replace("PACKAGE_PATH", newValue);
          string path2_1 = str.Replace("PROJECT_NAME", this.src_project_name);
          string path2_2 = str.Replace("PROJECT_NAME", this.dst_project_name);
          if (platform == "ios")
          {
            if (Directory.Exists(Path.Combine(path1, path2_1)))
              Directory.Move(Path.Combine(path1, path2_1), Path.Combine(path1, path2_2));
          }
          else if (File.Exists(Path.Combine(path1, path2_1)))
            File.Move(Path.Combine(path1, path2_1), Path.Combine(path1, path2_2));
        }
      }
      JToken jtoken2 = jobject["remove"];
      if (jtoken2 != null)
      {
        foreach (object obj in (IEnumerable<JToken>) jtoken2)
        {
          string path2 = obj.ToString().Replace("PROJECT_NAME", this.dst_project_name);
          if (File.Exists(Path.Combine(path1, path2)))
            Directory.Delete(Path.Combine(path1, path2));
        }
      }
      JToken jtoken3 = jobject["replace_package_name"];
      if (jtoken3 != null)
      {
        foreach (object obj in (IEnumerable<JToken>) jtoken3)
        {
          string path2 = obj.ToString().Replace("PACKAGE_PATH", newValue).Replace("PROJECT_NAME", "dst_project_name");
          if (File.Exists(Path.Combine(path1, path2)))
            this.ReplaceString(Path.Combine(path1, path2), this.src_package_name, this.dst_package_name);
        }
      }
      JToken jtoken4 = jobject["replace_project_name"];
      if (jtoken4 == null)
        return;
      foreach (object obj in (IEnumerable<JToken>) jtoken4)
      {
        string path2 = obj.ToString().Replace("PACKAGE_PATH", newValue).Replace("PROJECT_NAME", this.dst_project_name);
        if (File.Exists(Path.Combine(path1, path2)))
          this.ReplaceString(Path.Combine(path1, path2), this.src_project_name, this.dst_project_name);
      }
    }

    private int GetFileCount(string defaultPath)
    {
      int num1 = 0;
      if ("" == defaultPath)
        defaultPath = Path.Combine(Option.UserCustomerConfigFolder, "Source");
      DirectoryInfo directoryInfo = new DirectoryInfo(defaultPath);
      if (directoryInfo.Parent != null && directoryInfo.Attributes.ToString().IndexOf("System") > -1)
        return 0;
      FileInfo[] files = directoryInfo.GetFiles();
      int num2 = num1 + files.Length;
      foreach (FileSystemInfo directory in directoryInfo.GetDirectories())
        num2 += this.GetFileCount(directory.FullName);
      return num2;
    }
  }
}
