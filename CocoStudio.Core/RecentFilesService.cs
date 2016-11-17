// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.RecentFilesService
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using CocoStudio.Basic;
using CocoStudio.Lib.Prism;
using MonoDevelop.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace CocoStudio.Core
{
  public class RecentFilesService
  {
    private string lastBrowserLocationKey = "RecentLastBrowseDir";
    private string lastCreatePrjDirectoryKey = "RecentLastCreateDir";
    private string cocosCodeIDEDirKey = "RecentCocosCodeIDEDir";
    private string newPackageNameKey = "NewPackageName";
    private string newCocosPathKey = "NewCocosPath";
    private string newLanguageKey = "NewLanguage";
    private string newUseSourceKey = "NewUseSource";
    private string newUseCodeIDEKey = "NewUseCodeIDE";
    private string newUseCCFKey = "NewUseCCF";
    private string newUseX86Key = "NewUseX86";
    private string newCompilerTypeKey = "NewCompilerType";
    private const int maxRecordCount = 10;
    private const string recentlyRecordDirName = "RecentRecord";
    private const string recordFileSuffix = "recent.config";
    private const string DefaultFolder = "CocosProjects";
    private string recordFilePath;
    private Dictionary<string, object> dictionary;
    private List<string> keyList;
    private List<ProjectItemModel> projectRecordList;

    public IEnumerable<ProjectItemModel> ProjectRecordList
    {
      get
      {
        return (IEnumerable<ProjectItemModel>) this.projectRecordList;
      }
    }

    public string LastBrowserLocation
    {
      get
      {
        string directory = (string) this.GetValueByKey(this.lastBrowserLocationKey, (object) string.Empty);
        if (!this.CheckDiskValidity(directory))
          directory = string.Empty;
        if (string.IsNullOrWhiteSpace(directory))
          return Option.MyDocumentsFolder;
        return directory;
      }
      set
      {
        this.SetValueByKey(this.lastBrowserLocationKey, !File.Exists(value) ? (object) value : (object) Path.GetDirectoryName(value));
        this.SaveRecord();
      }
    }

    public string LastCreatePrjDirectory
    {
      get
      {
        string directory = (string) this.GetValueByKey(this.lastCreatePrjDirectoryKey, (object) string.Empty);
        if (!this.CheckDiskValidity(directory))
          directory = string.Empty;
        if (string.IsNullOrEmpty(directory))
        {
          if (Platform.IsWindows)
            directory = Path.Combine(Path.GetDirectoryName(Option.UserCustomerConfigFolder), "CocosProjects");
          else if (Platform.IsMac)
            directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Documents", "CocosProjects");
        }
        return directory;
      }
      set
      {
        this.SetValueByKey(this.lastCreatePrjDirectoryKey, (object) value);
        this.SaveRecord();
      }
    }

    public string CocosCodeIDEDir
    {
      get
      {
        return (string) this.GetValueByKey(this.cocosCodeIDEDirKey, (object) string.Empty);
      }
      set
      {
        this.SetValueByKey(this.cocosCodeIDEDirKey, (object) value);
        this.SaveRecord();
      }
    }

    public string NewPackageName
    {
      get
      {
        string valueByKey = (string) this.GetValueByKey(this.newPackageNameKey, (object) string.Empty);
        if (string.IsNullOrEmpty(valueByKey) || string.IsNullOrWhiteSpace(valueByKey))
          return "org.CocosStudio.ProjectName";
        return valueByKey;
      }
      set
      {
        this.SetValueByKey(this.newPackageNameKey, (object) value);
      }
    }

    public string NewCocosPath
    {
      get
      {
        return (string) this.GetValueByKey(this.newCocosPathKey, (object) string.Empty);
      }
      set
      {
        this.SetValueByKey(this.newCocosPathKey, (object) value);
      }
    }

    public EnumProjectLanguage NewLanguage
    {
      get
      {
        return (EnumProjectLanguage) Enum.Parse(typeof (EnumProjectLanguage), this.GetValueByKey(this.newLanguageKey, (object) EnumProjectLanguage.cpp).ToString());
      }
      set
      {
        this.SetValueByKey(this.newLanguageKey, (object) value);
      }
    }

    public bool NewUseSource
    {
      get
      {
        return Convert.ToBoolean(this.GetValueByKey(this.newUseSourceKey, (object) true));
      }
      set
      {
        this.SetValueByKey(this.newUseSourceKey, (object) value);
      }
    }

    public bool NewUseCodeIDE
    {
      get
      {
        return Convert.ToBoolean(this.GetValueByKey(this.newUseCodeIDEKey, (object) false));
      }
      set
      {
        this.SetValueByKey(this.newUseCodeIDEKey, (object) value);
      }
    }

    public bool NewUseCCF
    {
      get
      {
        return Convert.ToBoolean(this.GetValueByKey(this.newUseCCFKey, (object) false));
      }
      set
      {
        this.SetValueByKey(this.newUseCCFKey, (object) value);
      }
    }

    public bool NewUseX86
    {
      get
      {
        return Convert.ToBoolean(this.GetValueByKey(this.newUseX86Key, (object) false));
      }
      set
      {
        this.SetValueByKey(this.newUseX86Key, (object) value);
      }
    }

    public ECompilerType NewCompilerType
    {
      get
      {
        return (ECompilerType) Enum.Parse(typeof (ECompilerType), this.GetValueByKey(this.newCompilerTypeKey, (object) ECompilerType.Null).ToString());
      }
      set
      {
        this.SetValueByKey(this.newCompilerTypeKey, (object) value);
      }
    }

    public event EventHandler<RecentProjectChangeEventArgs> RecentProjectChanged;

    public RecentFilesService(bool Islauncher = false)
    {
      this.projectRecordList = new List<ProjectItemModel>();
      this.dictionary = new Dictionary<string, object>();
      this.keyList = new List<string>();
      this.keyList.Add(this.lastBrowserLocationKey);
      this.keyList.Add(this.lastCreatePrjDirectoryKey);
      this.keyList.Add(this.cocosCodeIDEDirKey);
      this.keyList.Add(this.newPackageNameKey);
      this.keyList.Add(this.newCocosPathKey);
      this.keyList.Add(this.newLanguageKey);
      this.keyList.Add(this.newUseSourceKey);
      this.keyList.Add(this.newUseCodeIDEKey);
      this.keyList.Add(this.newUseCCFKey);
      this.keyList.Add(this.newUseX86Key);
      this.keyList.Add(this.newCompilerTypeKey);
      this.Init(Islauncher);
    }

    private void Init(bool Islauncher)
    {
      if (this.CheckAndCreateDir())
        this.InitProjectList();
      if (Islauncher)
        return;
      this.InitEvent();
    }

    private void InitEvent()
    {
      if (Services.MainWindow == null)
        return;
      IEventAggregator eventsService = Services.EventsService;
      Services.MainWindow.Closed += new EventHandler<EventArgs>(this.OnApplicationQuit);
    }

    private bool CheckAndCreateDir()
    {
      string configFileByName = Option.GetUserConfigFileByName("RecentRecord");
      if (Directory.Exists(configFileByName))
        return true;
      try
      {
        Directory.CreateDirectory(configFileByName);
        return true;
      }
      catch (Exception ex)
      {
        LogConfig.Logger.Error((object) "Create recently project record dir failed.", ex);
        return false;
      }
    }

    private void InitProjectList()
    {
      this.recordFilePath = Path.Combine(Option.UserCustomerConfigFolder, "RecentRecord", "recent.config");
      if (!File.Exists(this.recordFilePath))
        return;
      this.ReadRecord();
    }

    public void ReloadRecentFiles()
    {
      if (this.projectRecordList == null)
        this.projectRecordList = new List<ProjectItemModel>();
      else
        this.projectRecordList.Clear();
      this.InitProjectList();
    }

    public void RemoveItem(string path)
    {
      foreach (ProjectItemModel projectRecord in this.projectRecordList)
      {
        if (projectRecord.LocalPath.Equals(path))
        {
          this.RemoveItem(projectRecord);
          break;
        }
      }
    }

    public void RemoveItem(ProjectItemModel item)
    {
      this.projectRecordList.Remove(item);
      this.SaveRecord();
      this.RecentProjectChanged((object) this, new RecentProjectChangeEventArgs(item, EnumRecentPrjChangeType.Remove));
    }

    public void AddFile(string filePath)
    {
      this.AddRecord(filePath);
    }

    private object GetValueByKey(string key, object defaultVal)
    {
      if (!this.dictionary.ContainsKey(key))
        return defaultVal;
      object obj;
      this.dictionary.TryGetValue(key, out obj);
      return obj;
    }

    private void SetValueByKey(string key, object value)
    {
      if (this.dictionary.ContainsKey(key))
        this.dictionary[key] = value;
      else
        this.dictionary.Add(key, value);
    }

    private void ReadRecord()
    {
      try
      {
        XElement xelement1 = XElement.Load(this.recordFilePath);
        foreach (XElement element in xelement1.Elements((XName) "ProjectList").Elements<XElement>())
        {
          string str = element.Attribute((XName) "LocalPath").Value;
          if (File.Exists(str))
            this.projectRecordList.Add(new ProjectItemModel(str));
        }
        foreach (string key in this.keyList)
        {
          XElement xelement2 = xelement1.Element((XName) key);
          if (xelement2 != null)
            this.dictionary.Add(key, (object) xelement2.Value);
        }
      }
      catch (Exception ex)
      {
        LogConfig.Logger.Error((object) "Read recently project record file failed.", ex);
      }
    }

    public void SaveRecord()
    {
      try
      {
        XElement xelement1 = new XElement((XName) "StartPageConfig");
        xelement1.SetAttributeValue((XName) "Type", (object) Option.CurrentEditorIDE);
        XElement xelement2 = new XElement((XName) "ProjectList");
        xelement1.Add((object) xelement2);
        foreach (ProjectItemModel projectRecord in this.projectRecordList)
        {
          XElement xelement3 = new XElement((XName) "Project");
          xelement3.SetAttributeValue((XName) "LocalPath", (object) projectRecord.LocalPath);
          xelement2.Add((object) xelement3);
        }
        foreach (KeyValuePair<string, object> keyValuePair in this.dictionary)
          xelement1.Add((object) new XElement((XName) keyValuePair.Key, keyValuePair.Value));
        xelement1.Save(this.recordFilePath);
      }
      catch (Exception ex)
      {
        LogConfig.Logger.Error((object) "Save recently project record file failed.", ex);
      }
    }

    private void AddRecord(string filePath)
    {
      ProjectItemModel prj1 = this.projectRecordList.FirstOrDefault<ProjectItemModel>((Func<ProjectItemModel, bool>) (a => a.LocalPath.Equals(filePath, StringComparison.CurrentCultureIgnoreCase)));
      if (prj1 == null)
      {
        ProjectItemModel prj2 = new ProjectItemModel(filePath);
        this.projectRecordList.Insert(0, prj2);
        if (this.projectRecordList.Count > 10)
          this.projectRecordList.RemoveAt(this.projectRecordList.Count - 1);
        if (this.RecentProjectChanged == null)
          return;
        this.SaveRecord();
        this.RecentProjectChanged((object) this, new RecentProjectChangeEventArgs(prj2, EnumRecentPrjChangeType.New));
      }
      else
      {
        this.projectRecordList.Remove(prj1);
        this.projectRecordList.Insert(0, prj1);
        if (this.RecentProjectChanged != null)
        {
          this.SaveRecord();
          this.RecentProjectChanged((object) this, new RecentProjectChangeEventArgs(prj1, EnumRecentPrjChangeType.Reorder));
        }
      }
    }

    private bool CheckDiskValidity(string directory)
    {
      if (string.IsNullOrEmpty(directory))
        return true;
      if (Platform.IsMac)
      {
        if (Directory.Exists(directory))
          return true;
        try
        {
          Directory.CreateDirectory(directory);
          Directory.Delete(directory);
          return true;
        }
        catch
        {
          return false;
        }
      }
      else
        return Directory.Exists(Directory.GetDirectoryRoot(directory));
    }

    private void OnApplicationQuit(object sender, EventArgs args)
    {
      this.SaveRecord();
    }
  }
}
