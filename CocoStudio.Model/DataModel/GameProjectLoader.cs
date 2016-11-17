// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.DataModel.GameProjectLoader
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Core;
using CocoStudio.EngineAdapterWrap;
using CocoStudio.Model.ViewModel;
using CocoStudio.UndoManager.Recorder;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;

namespace CocoStudio.Model.DataModel
{
  internal static class GameProjectLoader
  {
    public static GameProjectLoadResult LoadProject(GameProjectData objectData)
    {
      if (objectData == null || objectData.ObjectData == null)
        return (GameProjectLoadResult) null;
      GameProjectLoadResult gResult = new GameProjectLoadResult();
      Dictionary<int, VisualObject> dictionary = new Dictionary<int, VisualObject>();
      CSCocosHelp.RefreshLayoutSystemState(false);
      BaseRecorder.IsCreateDefaultRecorder = false;
      gResult.RootObject = GameProjectLoader.ConvertObject(objectData.ObjectData, gResult, dictionary);
      gResult.RootObject.CanEdit = true;
      CSCocosHelp.RefreshLayoutSystemState(true);
      BaseRecorder.IsCreateDefaultRecorder = true;
      GameProjectLoader.RefreshObjectsRecorder(gResult.RootObject);
      if (objectData.Animation != null)
        gResult.TimelineAction = GameProjectLoader.ConvertTimeLineAction(objectData.Animation, (VisualObject) gResult.RootObject, dictionary);
      return gResult;
    }

    public static GameProjectData SaveProject(NodeObject vObject, TimelineAction action)
    {
      if (vObject == null)
        return (GameProjectData) null;
      NodeObjectData nodeObjectData = GameProjectLoader.ConvertObjectData(vObject);
      TimelineActionData nTimelineActionData = new TimelineActionData();
      nTimelineActionData.Duration = action.Duration;
      nTimelineActionData.Speed = action.Speed;
      GameProjectLoader.ConvertTimeLineActionData(vObject, nTimelineActionData);
      return new GameProjectData()
      {
        ObjectData = nodeObjectData,
        Animation = nTimelineActionData
      };
    }

    private static void RefreshObjectsRecorder(NodeObject vObject)
    {
      vObject.BindingRecorder((string) null);
      foreach (NodeObject child in (Collection<NodeObject>) vObject.Children)
        GameProjectLoader.RefreshObjectsRecorder(child);
    }

    private static NodeObject ConvertObject(NodeObjectData objectData, GameProjectLoadResult gResult, Dictionary<int, VisualObject> objectDictionary)
    {
      NodeObject instance = Activator.CreateInstance(Services.ProjectsService.DataModelManager.GetViewModelType(objectData.GetType()), true) as NodeObject;
      if (instance == null)
        return (NodeObject) null;
      instance.IsAutoSize = objectData.IsAutoSize;
      foreach (PropertyAccessorHandler property1 in objectData.GetProperties())
      {
        string propertyName = property1.PropertyName;
        if (!(propertyName == "Children"))
        {
          PropertyInfo property2 = instance.GetType().GetProperty(propertyName);
          object obj1 = property1.GetValue((object) objectData, (object[]) null);
          if (property2 != (PropertyInfo) null && obj1 != null)
          {
            object obj2 = obj1;
            if (!property2.PropertyType.Equals(property1.PropertyType))
            {
              if (!(obj1 is IDataConvert))
                throw new InvalidCastException(string.Format("Property type are not same, the item is {0}, ViewType is {1}, DataType is {2}, Can use IDataConvert interface to convert.", (object) instance.GetType().Name, (object) property2.PropertyType.Name, (object) property1.PropertyType.Name));
              obj2 = ((IDataConvert) obj1).CreateViewModel();
            }
            property2.SetValue((object) instance, obj2, (object[]) null);
          }
        }
      }
      if (!objectDictionary.ContainsKey(instance.ActionTag))
        objectDictionary.Add(instance.ActionTag, (VisualObject) instance);
      IDataInitialize dataInitialize = (IDataInitialize) objectData;
      if (dataInitialize != null)
        dataInitialize.DataInitialize((VisualObject) instance);
      Type type = instance.GetType();
      if (gResult.TypeIndex.ContainsKey(type))
      {
        if (instance.ObjectIndex > gResult.TypeIndex[type])
          gResult.TypeIndex[type] = instance.ObjectIndex;
      }
      else
        gResult.TypeIndex.Add(type, instance.ObjectIndex);
      if (objectData.Children != null)
      {
        foreach (NodeObjectData child in objectData.Children)
        {
          NodeObject nodeObject = GameProjectLoader.ConvertObject(child, gResult, objectDictionary);
          instance.Children.Add(nodeObject);
        }
      }
      instance.IsAutoSize = false;
      return instance;
    }

    private static NodeObjectData ConvertObjectData(NodeObject nObject)
    {
      NodeObjectData instance = Activator.CreateInstance(Services.ProjectsService.DataModelManager.GetDataModelType(nObject.GetType()), true) as NodeObjectData;
      if (instance == null)
        return (NodeObjectData) null;
      foreach (PropertyInfo property1 in nObject.GetType().GetProperties())
      {
        string name = property1.Name;
        if (!(name == "Children"))
        {
          PropertyInfo property2 = instance.GetType().GetProperty(name);
          object viewObject = property1.GetValue((object) nObject, (object[]) null);
          if (property2 != (PropertyInfo) null && viewObject != null)
          {
            object obj = viewObject;
            if (!property2.PropertyType.Equals(property1.PropertyType))
            {
              obj = Activator.CreateInstance(property2.PropertyType, true);
              if (!(obj is IDataConvert))
                throw new InvalidCastException(string.Format("Property type are not same, the item is {0}, ViewType is {1}, DataType is {2}, Can use IDataConvert interface to convert.", (object) nObject.GetType().Name, (object) property1.PropertyType.Name, (object) property2.PropertyType.Name));
              ((IDataConvert) obj).SetData(viewObject);
            }
            property2.SetValue((object) instance, obj, (object[]) null);
          }
        }
      }
      if (nObject.Children == null || nObject.Children.Count <= 0)
        return instance;
      instance.Children = new List<NodeObjectData>();
      foreach (NodeObject child in (Collection<NodeObject>) nObject.Children)
      {
        NodeObjectData nodeObjectData = GameProjectLoader.ConvertObjectData(child);
        instance.Children.Add(nodeObjectData);
      }
      return instance;
    }

    private static TimelineAction ConvertTimeLineAction(TimelineActionData objectData, VisualObject vObject, Dictionary<int, VisualObject> objectTagDictionary)
    {
      TimelineAction timelineAction = new TimelineAction();
      timelineAction.Duration = objectData.Duration;
      timelineAction.Speed = objectData.Speed;
      if (objectData.Timelines == null || objectData.Timelines.Count <= 0)
        return timelineAction;
      foreach (TimelineData timeline1 in objectData.Timelines)
      {
        if (objectTagDictionary.ContainsKey(timeline1.ActionTag))
        {
          NodeObject objectTag = objectTagDictionary[timeline1.ActionTag] as NodeObject;
          if (objectTag != null)
          {
            Timeline timeline2 = Timeline.CreateTimeline(timeline1.FrameType, objectTag);
            if (timeline1.Frames != null && timeline1.Frames.Count > 0)
            {
              foreach (FrameData frame1 in timeline1.Frames)
              {
                Frame frame2 = GameProjectLoader.ConvertTimeLineFrame(frame1, timeline1.FrameType);
                timeline2.Frames.Add(frame2);
              }
            }
          }
        }
      }
      return timelineAction;
    }

    private static Frame ConvertTimeLineFrame(FrameData objectData, string typeStr)
    {
      string name1 = objectData.GetType().Name;
      Frame instance = Activator.CreateInstance(Type.GetType(objectData.GetType().FullName.Replace("CocoStudio.Model.DataModel", "CocoStudio.Model.ViewModel").Replace(name1, typeStr)), true) as Frame;
      if (instance == null)
        return (Frame) null;
      foreach (PropertyInfo property1 in objectData.GetType().GetProperties())
      {
        string name2 = property1.Name;
        PropertyInfo property2 = instance.GetType().GetProperty(name2);
        object obj1 = property1.GetValue((object) objectData, (object[]) null);
        if (property2 != (PropertyInfo) null && obj1 != null)
        {
          object obj2 = obj1;
          if (!property2.PropertyType.Equals(property1.PropertyType))
          {
            if (!(obj1 is IDataConvert))
              throw new InvalidCastException(string.Format("Property type are not same, the item is {0}, ViewType is {1}, DataType is {2}, Can use IDataConvert interface to convert.", (object) instance.GetType().Name, (object) property2.PropertyType.Name, (object) property1.PropertyType.Name));
            obj2 = ((IDataConvert) obj1).CreateViewModel();
          }
          property2.SetValue((object) instance, obj2, (object[]) null);
        }
      }
      return instance;
    }

    private static void ConvertTimeLineActionData(NodeObject nObject, TimelineActionData nTimelineActionData)
    {
      foreach (NodeObject child in (Collection<NodeObject>) nObject.Children)
      {
        GameProjectLoader.ConvertTimeLineActionData(child, nTimelineActionData);
        foreach (Timeline timeline in (Collection<Timeline>) child.Timelines)
        {
          if (timeline.Frames.Count > 0)
          {
            TimelineData timelineData = new TimelineData();
            timelineData.ActionTag = child.ActionTag;
            timelineData.FrameType = timeline.FrameType;
            timelineData.Frames = new List<FrameData>();
            foreach (Frame orderedFrame in timeline.OrderedFrames)
            {
              string name1 = orderedFrame.GetType().BaseType.Name;
              if (name1 == "Frame")
                name1 = orderedFrame.GetType().Name;
              string newValue = name1 + "Data";
              FrameData instance = Activator.CreateInstance(Type.GetType(orderedFrame.GetType().FullName.Replace("CocoStudio.Model.ViewModel", "CocoStudio.Model.DataModel").Replace(orderedFrame.GetType().Name, newValue)), true) as FrameData;
              if (instance != null)
              {
                foreach (PropertyInfo property1 in orderedFrame.GetType().GetProperties())
                {
                  string name2 = property1.Name;
                  if (!(name2 == "Children"))
                  {
                    PropertyInfo property2 = instance.GetType().GetProperty(name2);
                    object viewObject = property1.GetValue((object) orderedFrame, (object[]) null);
                    if (property2 != (PropertyInfo) null && viewObject != null)
                    {
                      object obj = viewObject;
                      if (!property2.PropertyType.Equals(property1.PropertyType))
                      {
                        obj = Activator.CreateInstance(property2.PropertyType, true);
                        if (!(obj is IDataConvert))
                          throw new InvalidCastException(string.Format("Property type are not same, the item is {0}, ViewType is {1}, DataType is {2}, Can use IDataConvert interface to convert.", (object) nObject.GetType().Name, (object) property1.PropertyType.Name, (object) property2.PropertyType.Name));
                        ((IDataConvert) obj).SetData(viewObject);
                      }
                      property2.SetValue((object) instance, obj, (object[]) null);
                    }
                  }
                }
                timelineData.Frames.Add(instance);
              }
            }
            nTimelineActionData.Timelines.Add(timelineData);
          }
        }
      }
    }
  }
}
