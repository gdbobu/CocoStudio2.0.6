// Decompiled with JetBrains decompiler
// Type: Modules.Communal.StartAutoRecover.StartRecoverService
// Assembly: Modules.Communal.StartAutoRecover, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1ED8AC94-4706-4252-8E2E-1C9E40B45791
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.StartAutoRecover.dll

using CocoStudio.Basic;
using CocoStudio.Core;
using CocoStudio.Core.Events;
using CocoStudio.Model.DataModel;
using CocoStudio.Projects;
using CocoStudio.UserStatistics;
using MonoDevelop.Core;
using MonoDevelop.Core.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Xml;

namespace Modules.Communal.StartAutoRecover
{
  public class StartRecoverService
  {
    private static StartRecoverService startRecoverService = (StartRecoverService) null;
    private string lastSolutionFile = "CocosStudio.cfg";

    public static string ProjectFilePathByDoubleClick { get; set; }

    public static StartRecoverService Instance
    {
      get
      {
        if (StartRecoverService.startRecoverService == null)
          StartRecoverService.startRecoverService = new StartRecoverService();
        return StartRecoverService.startRecoverService;
      }
    }

    public void InitializeEvent()
    {
      UserStatisticsFactory.UnHandledExceptionEvent += new Action<EventArgs>(StartRecoverService.UnHandledExceptionEvent);
      Services.ProjectOperations.CurrentSelectedSolutionClosing += new EventHandler<SolutionEventArgs>(StartRecoverService.ProjectOperations_CurrentSelectedSolutionClosing);
      Services.MainWindow.Closing += new EventHandler<CancelEventArgs>(StartRecoverService.MainWindow_Closing);
      Services.Workspace.LoadWorkspaceItemSuccessedEvent += new EventHandler<EventArgs>(StartRecoverService.Workspace_LoadWorkspaceItemSuccessedEvent);
    }

    private static void Workspace_LoadWorkspaceItemSuccessedEvent(object sender, EventArgs e)
    {
      StartRecoverService.Instance.OpenLastDocuments();
      StartRecoverService.Instance.OpenDocumentByDoubleClick();
    }

    private static void MainWindow_Closing(object sender, CancelEventArgs e)
    {
      StartRecoverService.Instance.SaveLastSolution(Services.ProjectOperations.CurrentSelectedSolution != null ? Services.ProjectOperations.CurrentSelectedSolution.FileName.ToString() : (string) null);
      StartRecoverService.Instance.SaveOpenedDocuments();
    }

    private static void ProjectOperations_CurrentSelectedSolutionClosing(object sender, SolutionEventArgs e)
    {
      StartRecoverService.Instance.SaveLastSolution((string) null);
      StartRecoverService.Instance.SaveOpenedDocuments();
    }

    private static void UnHandledExceptionEvent(EventArgs obj)
    {
      StartRecoverService.Instance.SaveLastSolution((string) null);
    }

    public string LoadLastSolutionArgs()
    {
      string preferencesFileName = this.GetPreferencesFileName();
      if (!File.Exists(preferencesFileName))
        return (string) null;
      XmlTextReader xmlTextReader = new XmlTextReader(preferencesFileName);
      try
      {
        int content = (int) xmlTextReader.MoveToContent();
        if (xmlTextReader.LocalName != "LastSolutionArgs")
          return (string) null;
        string path = Path.Combine(((LastSolutionArgs) new XmlDataSerializer(new DataContext()) { SerializationContext = { BaseFile = preferencesFileName } }.Deserialize((XmlReader) xmlTextReader, typeof (LastSolutionArgs))).LastSolutonFilePath);
        if (File.Exists(path))
          return path;
        this.SaveLastSolution((string) null);
        return (string) null;
      }
      catch (Exception ex)
      {
        LogConfig.Logger.Error((object) "Exception while loading last solution params.", ex);
        return (string) null;
      }
      finally
      {
        xmlTextReader.Close();
      }
    }

    private void SaveLastSolution(string lastSolutonFilePath)
    {
      LogConfig.Logger.Info((object) ("Save last solution params: " + lastSolutonFilePath));
      string preferencesFileName = this.GetPreferencesFileName();
      LastSolutionArgs lastSolutionArgs = new LastSolutionArgs();
      lastSolutionArgs.LastSolutonFilePath = lastSolutonFilePath;
      XmlTextWriter xmlTextWriter = (XmlTextWriter) null;
      try
      {
        xmlTextWriter = new XmlTextWriter(preferencesFileName, Encoding.UTF8);
        xmlTextWriter.Formatting = Formatting.Indented;
        new XmlDataSerializer(new DataContext())
        {
          SerializationContext = {
            BaseFile = preferencesFileName
          }
        }.Serialize((XmlWriter) xmlTextWriter, (object) lastSolutionArgs);
      }
      catch (Exception ex)
      {
        LogConfig.Logger.Error((object) ("Could not save last solution params: " + this.GetPreferencesFileName()), ex);
      }
      finally
      {
        if (xmlTextWriter != null)
          xmlTextWriter.Close();
      }
    }

    private string GetPreferencesFileName()
    {
      string str = Path.Combine(Option.UserCustomerConfigFolder, "LastSolutionTemp");
      if (!Directory.Exists(str))
        Directory.CreateDirectory(str);
      return Path.Combine(str, this.lastSolutionFile);
    }

    private void SaveOpenedDocuments()
    {
      try
      {
        if (Services.ProjectOperations.CurrentSelectedSolution == null)
          return;
        List<Document> documentList = new List<Document>(Services.Workbench.Documents);
        List<FilePathData> filePathDataList = new List<FilePathData>();
        if (documentList != null)
        {
          foreach (Document document in documentList)
            filePathDataList.Add(new FilePathData((ResourceFile) document.Project));
        }
        PropertyBag userProperties = Services.ProjectOperations.CurrentSelectedSolution.UserProperties;
        userProperties.SetValue<List<FilePathData>>("OpenedDocuments", filePathDataList);
        Project project = Services.Workbench.ActiveDocument != null ? Services.Workbench.ActiveDocument.Project : (Project) null;
        userProperties.SetValue<FilePathData>("ActiveDocuments", new FilePathData((ResourceFile) project));
        Services.ProjectOperations.CurrentSelectedSolution.SaveUserProperties();
      }
      catch (Exception ex)
      {
        LogConfig.Logger.Error((object) "Exception while saving infomation opened documents! ", ex);
      }
    }

    private void OpenLastDocuments()
    {
      try
      {
        if (Services.ProjectOperations.CurrentSelectedSolution == null)
          return;
        List<FilePathData> filePathDataList = Services.ProjectOperations.CurrentSelectedSolution.UserProperties.GetValue<List<FilePathData>>("OpenedDocuments");
        if (filePathDataList == null || filePathDataList.Count == 0)
          return;
        FilePathData filePathData1 = Services.ProjectOperations.CurrentSelectedSolution.UserProperties.GetValue<FilePathData>("ActiveDocuments");
        if (filePathData1 == null)
          return;
        Project file1 = filePathData1.File as Project;
        if (file1 == null)
          return;
        foreach (FilePathData filePathData2 in filePathDataList)
        {
          if (filePathData2 != null)
          {
            Project file2 = filePathData2.File as Project;
            if (file2 != null)
            {
              bool bringToFront = false;
              if (file1.FileName == file2.FileName)
                bringToFront = true;
              Services.Workbench.OpenDocument(file2.FileName, file2, bringToFront);
            }
          }
        }
      }
      catch (Exception ex)
      {
        LogConfig.Logger.Error((object) "Exception while open last documents! ", ex);
      }
    }

    private void OpenDocumentByDoubleClick()
    {
      try
      {
        if (!string.IsNullOrEmpty(StartRecoverService.ProjectFilePathByDoubleClick))
        {
          Project resourceItem = Services.ProjectOperations.CurrentResourceGroup.FindResourceItem(StartRecoverService.ProjectFilePathByDoubleClick) as Project;
          if (resourceItem != null && resourceItem.FileName != (FilePath) ((string) null))
            Services.Workbench.OpenDocument(resourceItem.FileName, resourceItem, true);
        }
        StartRecoverService.ProjectFilePathByDoubleClick = string.Empty;
      }
      catch (Exception ex)
      {
        LogConfig.Logger.Error((object) "Exception while open the document which is started by double click! ", ex);
      }
    }
  }
}
