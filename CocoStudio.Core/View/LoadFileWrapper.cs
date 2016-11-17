// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.View.LoadFileWrapper
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using CocoStudio.Projects;
using MonoDevelop.Core;
using System;

namespace CocoStudio.Core.View
{
  internal class LoadFileWrapper
  {
    private IViewDisplayBuilder builder;
    private Project project;
    private FileOpenInfo fileInfo;
    private MainWindow workbench;
    private IProgressMonitor monitor;
    private IViewContentExtend newContent;

    public LoadFileWrapper(IProgressMonitor monitor, MainWindow workbench, IViewDisplayBuilder binding, Project project, FileOpenInfo fileInfo)
    {
      this.monitor = monitor;
      this.workbench = workbench;
      this.fileInfo = fileInfo;
      this.builder = binding;
      this.project = project;
    }

    public void Invoke(string fileName)
    {
      try
      {
        if (this.builder.CanHandle((FilePath) fileName, (string) null, this.project))
        {
          this.newContent = this.builder.CreateContent((FilePath) fileName, (string) null, this.project);
          if (this.newContent == null)
            this.monitor.ReportError(string.Format("The file '{0}' could not be opened.", (object) fileName), (Exception) null);
        }
        if (this.project != null)
          this.newContent.Project = this.project;
        if (this.newContent.WorkbenchWindow != null)
        {
          this.newContent.WorkbenchWindow.SelectWindow();
          this.fileInfo.NewContent = this.newContent;
        }
        else
        {
          this.workbench.ShowView(this.newContent, this.fileInfo.BringToFront);
          this.newContent.WorkbenchWindow.DocumentType = this.builder.Name;
          this.fileInfo.NewContent = this.newContent;
        }
      }
      catch (Exception ex)
      {
        this.monitor.ReportError("", ex);
      }
    }
  }
}
