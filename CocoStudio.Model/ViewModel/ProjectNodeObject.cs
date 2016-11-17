// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.ProjectNodeObject
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Core;
using CocoStudio.EngineAdapterWrap;
using CocoStudio.Model.Editor;
using CocoStudio.Model.Visiter;
using CocoStudio.Projects;
using CocoStudio.ToolKit;
using CocoStudio.UndoManager;
using MonoDevelop.Core;
using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace CocoStudio.Model.ViewModel
{
  [DisplayName("Display_Component_Entity")]
  public class ProjectNodeObject : NodeObject, ISingleNode
  {
    private ResourceFile filePath = (ResourceFile) null;
    private NodeObject rootObject;

    public Project Project { get; private set; }

    [Category("Group_Feature")]
    [DefaultValue(null)]
    [PropertyOrder(81)]
    [UndoProperty]
    [ResourceFilter(new string[] {"csd"})]
    [DisplayName("Display_File")]
    [Browsable(true)]
    [System.ComponentModel.Editor(typeof (ResourceFileEditor), typeof (ResourceFileEditor))]
    public ResourceFile FileData
    {
      get
      {
        return this.filePath;
      }
      set
      {
        if (this.filePath == value)
          return;
        this.filePath = value;
        this.Project = value as Project;
        this.ReloadProject();
        using (CompositeTask.Run(this.GetType().Name + "FileData"))
        {
          this.RaisePropertyChanged<PointF>((Expression<Func<PointF>>) (() => this.Size));
          this.RaisePropertyChanged<ResourceFile>((Expression<Func<ResourceFile>>) (() => this.FileData));
        }
      }
    }

    [DisplayName("Display_AnchorPoint")]
    [UndoProperty]
    [PropertyOrder(7)]
    [Browsable(false)]
    [Category("Group_Routine")]
    [System.ComponentModel.Editor(typeof (AnchorPointEditor), typeof (AnchorPointEditor))]
    public override ScaleValue AnchorPoint
    {
      get
      {
        return this.GetCSVisual().GetAnchorPoint();
      }
      set
      {
        if (!this.IsTransformEnabled)
          return;
        this.GetCSVisual().SetAnchorPoint(value);
        this.RaisePropertyChanged<ScaleValue>((Expression<Func<ScaleValue>>) (() => this.AnchorPoint));
      }
    }

    public ProjectNodeObject()
    {
    }

    public ProjectNodeObject(Project project)
    {
      this.FileData = (ResourceFile) project;
    }

    public ProjectNodeObject(CSNode customWidget)
      : base(customWidget)
    {
    }

    private CSNode GetInnerObject()
    {
      return this.innerNode;
    }

    protected override void CreateCSObject()
    {
      this.innerNode = new CSNode();
    }

    protected override void InitData()
    {
      base.InitData();
      this.OperationFlag &= ~OperationMask.AnchorMoveFlag;
    }

    private void LoadProject(Project project)
    {
      if (project == null || !project.IsValid)
        return;
      string fileName = (string) this.Project.FileName;
      IProgressMonitor consoleProgressMonitor = Services.ProgressMonitors.GetConsoleProgressMonitor(false);
      Project project1 = Services.ProjectsService.ReadProject(consoleProgressMonitor, fileName);
      project1.Load(consoleProgressMonitor);
      if (!consoleProgressMonitor.AsyncOperation.Success)
        return;
      this.rootObject = project1.GetRootNode();
      if (this.rootObject != null)
        this.rootObject.GetCSVisual().SetZOrder(-1);
      this.innerNode.AddChild(this.rootObject.GetCSVisual());
    }

    protected override void SetValue(object cObject, object cInnerObject)
    {
      base.SetValue(cObject, cInnerObject);
      ProjectNodeObject projectNodeObject = cObject as ProjectNodeObject;
      if (projectNodeObject == null)
        return;
      projectNodeObject.FileData = this.FileData;
    }

    internal void ReloadProject()
    {
      if (this.rootObject != null)
        this.innerNode.RemoveChild(this.rootObject.GetCSVisual());
      this.LoadProject(this.Project);
    }
  }
}
