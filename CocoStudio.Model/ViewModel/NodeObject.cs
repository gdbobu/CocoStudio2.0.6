// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.NodeObject
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Basic;
using CocoStudio.Core;
using CocoStudio.EngineAdapterWrap;
using CocoStudio.Lib.Prism;
using CocoStudio.Model.Editor;
using CocoStudio.Model.Event;
using CocoStudio.Model.Visiter;
using CocoStudio.Projects;
using CocoStudio.ToolKit;
using CocoStudio.UndoManager;
using Gdk;
using Gtk;
using Modules.Communal.MultiLanguage;
using MonoDevelop.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq.Expressions;

namespace CocoStudio.Model.ViewModel
{
  [Catagory("Group_Feature", 2, 0)]
  [Catagory("Group_Routine", 0, 0)]
  [Catagory("grid_sudoku", 1, 0)]
  [Catagory("CallBack_Feature", 8, 1)]
  [Catagory("Thing_feature", 3, 0)]
  [Catagory("Display_ControlLayout", -1, 0)]
  [Catagory("Frame_Feature", 5, 1)]
  [Catagory("Physics_Feature", 6, 1)]
  [Catagory("Category_Component_Layout", 7, 1)]
  public class NodeObject : VisualObject, IDragSource, IDropTarget, IPropertyTitle
  {
    protected bool IsAddToCurrent = true;
    protected bool CanShowMessage = false;
    private CSNode.ObjectState OldState = CSNode.ObjectState.Default;
    protected CSNode innerNode;
    private NodeObject parent;

    [Browsable(false)]
    public NodeObject Parent
    {
      get
      {
        return this.parent;
      }
      internal set
      {
        this.parent = value;
        this.RaisePropertyChanged<NodeObject>((Expression<Func<NodeObject>>) (() => this.Parent));
      }
    }

    [Browsable(false)]
    [UndoProperty]
    public NodeCollection Children { get; private set; }

    public virtual int ObjectIndex { get; set; }

    public override bool IsSelected
    {
      get
      {
        return base.IsSelected;
      }
      set
      {
        base.IsSelected = value;
        if (value)
          this.SetObjectState(CSNode.ObjectState.Seleted);
        else
          this.SetObjectState(CSNode.ObjectState.Default);
      }
    }

    [UndoProperty]
    public virtual bool PrePositionEnabled
    {
      get
      {
        return this.innerNode.IsPrePositionEnabled();
      }
      set
      {
        this.innerNode.SetPrePositionEnabled(value);
        if (Services.TaskService.IsRunningCompositeTask)
        {
          this.RaisePropertyChanged<PointF>((Expression<Func<PointF>>) (() => this.Position));
          this.RaisePropertyChanged<PointF>((Expression<Func<PointF>>) (() => this.PrePosition));
          this.RaisePropertyChanged<bool>((Expression<Func<bool>>) (() => this.PrePositionEnabled));
        }
        else
        {
          using (CompositeTask.Run("PrePositionEnabled"))
          {
            this.RaisePropertyChanged<PointF>((Expression<Func<PointF>>) (() => this.Position));
            this.RaisePropertyChanged<PointF>((Expression<Func<PointF>>) (() => this.PrePosition));
            this.RaisePropertyChanged<bool>((Expression<Func<bool>>) (() => this.PrePositionEnabled));
          }
        }
      }
    }

    [Category("Group_Routine")]
    [DisplayName("Display_PositionType")]
    [UndoProperty]
    [PropertyOrder(5)]
    [Browsable(false)]
    public virtual LayoutRefrencePoint RefrencePoint
    {
      get
      {
        return (LayoutRefrencePoint) this.innerNode.GetPositionType();
      }
      set
      {
        this.innerNode.SetPositionType((int) value);
        this.RaisePropertyChanged<LayoutRefrencePoint>((Expression<Func<LayoutRefrencePoint>>) (() => this.RefrencePoint));
      }
    }

    public virtual PointF PrePosition
    {
      get
      {
        return this.innerNode.GetPrePosition();
      }
      set
      {
        this.innerNode.SetPrePosition(value);
        this.RaisePropertyChanged<PointF>((Expression<Func<PointF>>) (() => this.Position));
      }
    }

    [UndoProperty]
    public virtual bool PreSizeEnable
    {
      get
      {
        return this.innerNode.IsPreSizeEnabled();
      }
      set
      {
        this.innerNode.SetPreSizeEnabled(value);
        this.RefreshBoundingBox(false);
        if (Services.TaskService.IsRunningCompositeTask)
        {
          this.RaisePropertyChanged<PointF>((Expression<Func<PointF>>) (() => this.Size));
          this.RaisePropertyChanged<bool>((Expression<Func<bool>>) (() => this.PreSizeEnable));
        }
        else
        {
          using (CompositeTask.Run("PreSizeEnable"))
          {
            this.RaisePropertyChanged<PointF>((Expression<Func<PointF>>) (() => this.Size));
            this.RaisePropertyChanged<bool>((Expression<Func<bool>>) (() => this.PreSizeEnable));
          }
        }
      }
    }

    public virtual PointF PreSize
    {
      get
      {
        return this.innerNode.GetPreSize();
      }
      set
      {
        this.innerNode.SetPreSize(value);
        this.RefreshBoundingBox(false);
        this.RaisePropertyChanged<PointF>((Expression<Func<PointF>>) (() => this.Size));
      }
    }

    [Browsable(false)]
    [Category("Group_Routine")]
    [PropertyOrder(3)]
    [UndoProperty]
    [DisplayName("Display_CascadeColor")]
    public virtual bool CascadeColor
    {
      get
      {
        return this.innerNode.GetCascadeColorEnabled();
      }
      set
      {
        this.innerNode.SetCascadeColorEnabled(value);
        this.RaisePropertyChanged<bool>((Expression<Func<bool>>) (() => this.CascadeColor));
      }
    }

    [DisplayName("Display_CascadeAlpha")]
    [PropertyOrder(4)]
    [UndoProperty]
    [Category("Group_Routine")]
    [Browsable(false)]
    public virtual bool CascadeAlpha
    {
      get
      {
        return this.innerNode.GetCascadeOpacityEnabled();
      }
      set
      {
        this.innerNode.SetCascadeOpacityEnabled(value);
        this.RaisePropertyChanged<bool>((Expression<Func<bool>>) (() => this.CascadeAlpha));
      }
    }

    [Browsable(true)]
    [UndoProperty]
    [DisplayName("Display_Name")]
    [Category("Group_Routine")]
    public override string Name
    {
      get
      {
        return this.name;
      }
      set
      {
        base.Name = value;
      }
    }

    [DisplayName("Display_Target")]
    [Category("Group_Routine")]
    [Browsable(true)]
    [DefaultValue(-1)]
    [UndoProperty]
    public virtual int Tag
    {
      get
      {
        return this.GetCSVisual().GetTag();
      }
      set
      {
        this.GetCSVisual().SetTag(value);
        this.RaisePropertyChanged<int>((Expression<Func<int>>) (() => this.Tag));
      }
    }

    public bool IconVisible
    {
      get
      {
        return this.innerNode.GetIconVisible();
      }
      set
      {
        this.innerNode.SetIconVisible(value);
      }
    }

    [Browsable(false)]
    [PropertyOrder(0)]
    [System.ComponentModel.Editor(typeof (CallBackPropertyRootEditor), typeof (CallBackPropertyRootEditor))]
    [Category("CallBack_Feature")]
    [UndoProperty]
    [DisplayName("CallBack_ClassName")]
    public virtual string CustomClassName { get; set; }

    [Browsable(false)]
    [UndoProperty]
    [Category("CallBack_Feature")]
    [System.ComponentModel.Editor(typeof (CallBackPropertyEditor), typeof (CallBackPropertyEditor))]
    [PropertyOrder(0)]
    [DisplayName("CallBack_Method")]
    public virtual EnumCallBack CallBackType { get; set; }

    public virtual string CallBackName { get; set; }

    [Browsable(false)]
    public virtual bool IsDraggable
    {
      get
      {
        return true;
      }
    }

    public NodeObject()
    {
      this.CreateCSObject();
      this.InitData();
    }

    public NodeObject(CSNode comEntiy)
    {
      this.innerNode = comEntiy;
      this.CreateCSObject();
      this.InitData();
    }

    protected virtual void CreateCSObject()
    {
      if (this.innerNode != null)
        return;
      this.innerNode = new CSNode();
    }

    internal override CSVisualObject GetCSVisual()
    {
      return (CSVisualObject) this.innerNode;
    }

    protected virtual void RefreshObjectIndex()
    {
      if (Services.ProjectOperations.CurrentSelectedProject == null)
        return;
      this.ObjectIndex = Services.ProjectOperations.CurrentSelectedProject.GetTypeIndex(this.GetType());
    }

    protected virtual void InitData()
    {
      this.Tag = VisualObject.tag++;
      this.Children = new NodeCollection(this);
      this.RefreshObjectIndex();
      string name = this.GetType().Name;
      this.Name = name.Substring(0, name.Length - 6) + "_" + (object) this.ObjectIndex;
      this.IsTransformEnabled = true;
      this.CallBackType = EnumCallBack.None;
    }

    public bool HasFrame(string frameType)
    {
      foreach (Timeline timeline in (Collection<Timeline>) this.Timelines)
      {
        if (timeline.FrameType == frameType)
        {
          if (timeline.Frames.Count > 0)
            return true;
          break;
        }
      }
      return false;
    }

    internal override void RefreshBoundingBox(bool bRefresh = false)
    {
      if (bRefresh)
        this.RaisePropertyChanged<PointF>((Expression<Func<PointF>>) (() => this.Size), false);
      this.innerNode.RefreshBoundingObjects();
      foreach (NodeObject child in (Collection<NodeObject>) this.Children)
      {
        if (child.PreSizeEnable)
          child.RefreshBoundingBox(true);
      }
    }

    internal virtual void InsertChild(int index, NodeObject nObject)
    {
      this.GetCSVisual().InsertChild(index, nObject.GetCSVisual());
      nObject.OperationFlag |= OperationMask.MoveFlag;
      nObject.RefreshBoundingBox(true);
      nObject.Parent = this;
    }

    internal virtual void RemoveChild(NodeObject nObject)
    {
      this.GetCSVisual().RemoveChild(nObject.GetCSVisual());
      nObject.Parent = (NodeObject) null;
    }

    internal virtual void AfterAdded()
    {
    }

    internal virtual void BeforeRemoved()
    {
    }

    public override IEnumerable<VisualObject> GetVisualChildren()
    {
      return (IEnumerable<VisualObject>) this.Children;
    }

    protected override void OnDragEnter(DragMotionArgs e)
    {
      this.CanShowMessage = true;
      this.OldState = this.innerNode.GetObjectState();
      if (!this.CanReceiveModelObject(e.Context.GetDragData() as ModelDragData) || !this.IsHitTestVisible)
        return;
      this.SetObjectState(CSNode.ObjectState.DragOver);
    }

    protected override void OnDragLeave(DragMotionArgs e)
    {
      this.CanShowMessage = false;
      e.SetAllowDragAction((DragAction) 0);
      this.SetObjectState(this.OldState);
    }

    protected override bool OnDragOver(DragMotionArgs e)
    {
      if (!e.Context.GetDataPresent(typeof (ResourceInfoDragData)) || this.CanReceiveResourceObject(e.Context.GetDragData() as ResourceInfoDragData))
        return base.OnDragOver(e);
      e.SetAllowDragAction((DragAction) 0);
      return false;
    }

    protected override void OnDragDrop(DragDropArgs e)
    {
      if (e.Context.GetDataPresent(typeof (ResourceInfoDragData)))
      {
        string str = this.CanDragDrop(e);
        if (str != null)
        {
          LogConfig.Output.Error((object) str, (Exception) null);
          return;
        }
      }
      bool runningCompositeTask = Services.TaskService.IsRunningCompositeTask;
      if (!runningCompositeTask)
        Services.TaskService.BeginCompositeTask("Drag drop GameObject");
      List<VisualObject> visualObjectList = new List<VisualObject>();
      if (e.Context.GetDataPresent(typeof (ResourceInfoDragData)))
      {
        ResourceInfoDragData dragData = (ResourceInfoDragData) e.Context.GetDragData();
        if ((object) dragData == null)
          return;
        foreach (ResourceItem resourceFile in (IEnumerable<ResourceItem>) dragData.Items)
        {
          if (!(resourceFile is ResourceFolder))
          {
            NodeObject objectFromFile = this.CreateObjectFromFile(resourceFile);
            if (objectFromFile != null)
            {
              this.LoadNodeObject(objectFromFile, new PointF((float) e.X, (float) e.Y));
              visualObjectList.Add((VisualObject) objectFromFile);
            }
          }
        }
      }
      else if (e.Context.GetDataPresent(typeof (ModelDragData)))
      {
        NodeObject gObject = ((ModelDragData) e.Context.GetDragData()).MetaData.CreateObject();
        this.LoadNodeObject(gObject, new PointF((float) e.X, (float) e.Y));
        visualObjectList.Add((VisualObject) gObject);
      }
      this.SetObjectState(CSNode.ObjectState.Default);
      EventAggregator.Instance.GetEvent<SelectedVisualObjectsChangeEvent>().Publish(new SelectedVisualObjectsChangeEventArgs((IEnumerable<VisualObject>) visualObjectList, (IEnumerable<VisualObject>) visualObjectList, false));
      if (runningCompositeTask)
        return;
      Services.TaskService.EndCompositeTask();
    }

    private string CanDragDrop(DragDropArgs e)
    {
      ResourceInfoDragData dragData = e.Context.GetDragData() as ResourceInfoDragData;
      GameProjectFile projectItem = Services.ProjectOperations.CurrentSelectedProject.ProjectItem as GameProjectFile;
      foreach (ResourceItem resourceItem in (IEnumerable<ResourceItem>) dragData.Items)
      {
        if ((FilePath) resourceItem.FullPath == projectItem.FileName)
          return LanguageInfo.MessageBox207_NestedSelfError;
        Project project = resourceItem as Project;
        if (project != null)
        {
          string str = project.CheckNest(projectItem.Project);
          if (!string.IsNullOrEmpty(str))
            return str;
        }
      }
      return (string) null;
    }

    protected virtual bool CanReceiveModelObject(ModelDragData objectData)
    {
      return false;
    }

    protected virtual bool CanReceiveResourceObject(ResourceInfoDragData objectData)
    {
      if (objectData == null || !(Services.ProjectOperations.CurrentSelectedProject.ProjectItem is GameProjectFile))
        return false;
      foreach (ResourceItem resourceItem in (IEnumerable<ResourceItem>) objectData.Items)
      {
        if (!(resourceItem is ImageFile) && !(resourceItem is PlistImageFile) && !(resourceItem is Project))
          return false;
      }
      return true;
    }

    protected virtual void LoadNodeObject(NodeObject gObject, PointF coord)
    {
      if (gObject == null)
        return;
      PointF scene = SceneTransformHelp.ConvertControlToScene(coord);
      NodeObject nodeObject = !this.IsAddToCurrent ? Services.ProjectOperations.CurrentSelectedProject.GetRootNode() : this;
      PointF self = nodeObject.TransformToSelf(scene);
      gObject.Position = self;
      nodeObject.Children.Add(gObject);
    }

    protected virtual NodeObject CreateObjectFromFile(ResourceItem resourceFile)
    {
      if (resourceFile is ImageFile || resourceFile is PlistImageFile)
        return (NodeObject) new SpriteObject(resourceFile as ResourceFile);
      if (resourceFile is Project)
      {
        Project project = resourceFile as Project;
        if (project.IsGameProject())
          return (NodeObject) new ProjectNodeObject(project);
      }
      else if (resourceFile is AudioFile)
        return (NodeObject) new SimpleAudioObject(resourceFile as ResourceFile);
      return (NodeObject) null;
    }

    public virtual bool CanDrop(object node, DropPosition mode, bool copy)
    {
      if (copy || !(node is NodeObject) || this.IsAncestor(node as NodeObject))
        return false;
      NodeObject nodeObject = node as NodeObject;
      switch (mode)
      {
        case DropPosition.InsertBefore:
          if (this.Parent == null || !this.Parent.CanDrop(node, DropPosition.Add, copy))
            return false;
          break;
        case DropPosition.InsertAfter:
          if (this.Parent == null || !this.Parent.CanDrop(node, DropPosition.Add, copy))
            return false;
          break;
      }
      return true;
    }

    public virtual void Drop(List<object> node, DropPosition mode, bool copy)
    {
      bool runningCompositeTask = Services.TaskService.IsRunningCompositeTask;
      if (!runningCompositeTask)
        Services.TaskService.BeginCompositeTask("Drag drop GameObject");
      foreach (object obj in node)
      {
        if (!copy)
        {
          IDragSource dragSource = obj as IDragSource;
          if (dragSource != null)
            dragSource.Detach();
        }
        NodeObject gameObjectData = obj as NodeObject;
        if (gameObjectData != null)
          this.LoadDropObject(gameObjectData, mode);
      }
      if (runningCompositeTask)
        return;
      Services.TaskService.EndCompositeTask();
    }

    public virtual void Detach()
    {
      if (this.Parent == null)
        return;
      this.Parent.Children.Remove(this);
    }

    protected virtual void LoadDropObject(NodeObject gameObjectData, DropPosition mode)
    {
      switch (mode)
      {
        case DropPosition.Add:
          this.Children.Add(gameObjectData);
          break;
        case DropPosition.InsertBefore:
          this.Parent.Children.Insert(this.Parent.Children.IndexOf(this), gameObjectData);
          break;
        case DropPosition.InsertAfter:
          this.Parent.Children.Insert(this.Parent.Children.IndexOf(this) + 1, gameObjectData);
          break;
      }
    }

    internal bool IsAncestor(NodeObject obj)
    {
      if (obj == null)
        return false;
      if (obj == this.Parent)
        return true;
      if (this.Parent != null)
        return this.Parent.IsAncestor(obj);
      return false;
    }

    internal virtual void AncestorObjectChanged(BaseObject sourceObj, NotifyCollectionChangedAction action)
    {
      if (action == NotifyCollectionChangedAction.Add)
        this.CollectResources();
      else if (action == NotifyCollectionChangedAction.Remove)
        this.ClearResources();
      if (this.Children == null)
        return;
      foreach (NodeObject child in (Collection<NodeObject>) this.Children)
        child.AncestorObjectChanged(sourceObj, action);
    }

    protected override void OnKeyDown(KeyPressEventArgs e)
    {
      PointF vectorByKey = this.GetVectorByKey(e.Event.Key);
      if (vectorByKey == null || !this.OperationFlag.HasFlag((Enum) OperationMask.MoveFlag))
        return;
      this.Position = new PointF(this.Position.X + vectorByKey.X, this.Position.Y + vectorByKey.Y);
    }

    protected override void OnKeyUp(KeyReleaseEventArgs e)
    {
    }

    protected override void OnMouseMove(MouseEventArgsExtend args)
    {
    }

    public override object Clone()
    {
      Type type = this.GetType();
      CSNode instance1 = Activator.CreateInstance(this.GetCSVisual().GetType()) as CSNode;
      NodeObject instance2 = Activator.CreateInstance(type, new object[1]
      {
        (object) instance1
      }) as NodeObject;
      this.SetValue((object) instance2, (object) instance1);
      this.SetAnimation((object) instance2);
      foreach (NodeObject child in (Collection<NodeObject>) this.Children)
        instance2.Children.Add((NodeObject) child.Clone());
      return (object) instance2;
    }

    protected virtual void SetAnimation(object cObject)
    {
      foreach (Timeline timeline1 in (Collection<Timeline>) this.Timelines)
      {
        Timeline timeline2 = Timeline.CreateTimeline(timeline1.FrameType, cObject as NodeObject);
        foreach (Frame orderedFrame in timeline1.OrderedFrames)
        {
          Frame frame = Frame.CreateFrame(orderedFrame);
          timeline2.Frames.Add(frame);
        }
      }
    }

    protected virtual void SetValue(object cObject, object cInnerObject)
    {
      NodeObject nodeObject = cObject as NodeObject;
      if (nodeObject == null)
        return;
      nodeObject.Name = this.Name + "_Copy";
      nodeObject.CanEdit = this.CanEdit;
      nodeObject.OperationFlag = this.OperationFlag;
      nodeObject.Alpha = this.Alpha;
      nodeObject.CColor = this.CColor;
      nodeObject.Visible = this.Visible;
      nodeObject.ZOrder = this.ZOrder;
      nodeObject.Scale = this.Scale;
      nodeObject.Position = this.Position;
      nodeObject.RotationSkew = this.RotationSkew;
      nodeObject.AnchorPoint = this.AnchorPoint;
      nodeObject.VisibleForFrame = this.VisibleForFrame;
      nodeObject.Parent = this.Parent;
      nodeObject.PrePositionEnabled = this.PrePositionEnabled;
      nodeObject.FrameEvent = this.FrameEvent;
      nodeObject.CustomClassName = this.CustomClassName;
    }

    public virtual bool GetChildGlobalIndex(NodeObject vObject, ref int index)
    {
      ++index;
      if (this.Children == null || this.Children.Count == 0)
        return false;
      foreach (NodeObject child in (Collection<NodeObject>) this.Children)
      {
        if (child == vObject || child.GetChildGlobalIndex(vObject, ref index))
          return true;
      }
      return false;
    }

    public virtual void SetObjectState(CSNode.ObjectState objectState)
    {
      this.innerNode.SetObjectState(objectState);
    }
  }
}
