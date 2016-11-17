using CocoStudio.Core;
using CocoStudio.EngineAdapterWrap;
using CocoStudio.Model.ViewModel;
using CocoStudio.UndoManager.Recorder;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace CocoStudio.Model.DataModel
{
	internal static class GameProjectLoader
	{
		public static GameProjectLoadResult LoadProject(GameProjectData objectData)
		{
			GameProjectLoadResult result;
			if (objectData == null || objectData.ObjectData == null)
			{
				result = null;
			}
			else
			{
				GameProjectLoadResult gameProjectLoadResult = new GameProjectLoadResult();
				Dictionary<int, VisualObject> dictionary = new Dictionary<int, VisualObject>();
				CSCocosHelp.RefreshLayoutSystemState(false);
				BaseRecorder.IsCreateDefaultRecorder = false;
				gameProjectLoadResult.RootObject = GameProjectLoader.ConvertObject(objectData.ObjectData, gameProjectLoadResult, dictionary);
				gameProjectLoadResult.RootObject.CanEdit = true;
				CSCocosHelp.RefreshLayoutSystemState(true);
				BaseRecorder.IsCreateDefaultRecorder = true;
				GameProjectLoader.RefreshObjectsRecorder(gameProjectLoadResult.RootObject);
				if (objectData.Animation != null)
				{
					gameProjectLoadResult.TimelineAction = GameProjectLoader.ConvertTimeLineAction(objectData.Animation, gameProjectLoadResult.RootObject, dictionary);
				}
				result = gameProjectLoadResult;
			}
			return result;
		}

		public static GameProjectData SaveProject(NodeObject vObject, TimelineAction action)
		{
			GameProjectData result;
			if (vObject == null)
			{
				result = null;
			}
			else
			{
				NodeObjectData objectData = GameProjectLoader.ConvertObjectData(vObject);
				TimelineActionData timelineActionData = new TimelineActionData();
				timelineActionData.Duration = action.Duration;
				timelineActionData.Speed = action.Speed;
				GameProjectLoader.ConvertTimeLineActionData(vObject, timelineActionData);
				result = new GameProjectData
				{
					ObjectData = objectData,
					Animation = timelineActionData
				};
			}
			return result;
		}

		private static void RefreshObjectsRecorder(NodeObject vObject)
		{
			vObject.BindingRecorder(null);
			foreach (NodeObject current in vObject.Children)
			{
				GameProjectLoader.RefreshObjectsRecorder(current);
			}
		}

		private static NodeObject ConvertObject(NodeObjectData objectData, GameProjectLoadResult gResult, Dictionary<int, VisualObject> objectDictionary)
		{
			Type viewModelType = Services.ProjectsService.DataModelManager.GetViewModelType(objectData.GetType());
			NodeObject nodeObject = Activator.CreateInstance(viewModelType, true) as NodeObject;
			NodeObject result;
			if (nodeObject == null)
			{
				result = null;
			}
			else
			{
				nodeObject.IsAutoSize = objectData.IsAutoSize;
				PropertyAccessorHandler[] properties = objectData.GetProperties();
				PropertyAccessorHandler[] array = properties;
				for (int i = 0; i < array.Length; i++)
				{
					PropertyAccessorHandler propertyAccessorHandler = array[i];
					string propertyName = propertyAccessorHandler.PropertyName;
					if (!(propertyName == "Children"))
					{
						PropertyInfo property = nodeObject.GetType().GetProperty(propertyName);
						object obj = propertyAccessorHandler.GetValue(objectData, null);
						if (property != null && obj != null)
						{
							object value = obj;
							if (!property.PropertyType.Equals(propertyAccessorHandler.PropertyType))
							{
								if (!(obj is IDataConvert))
								{
									string message = string.Format("Property type are not same, the item is {0}, ViewType is {1}, DataType is {2}, Can use IDataConvert interface to convert.", nodeObject.GetType().Name, property.PropertyType.Name, propertyAccessorHandler.PropertyType.Name);
									throw new InvalidCastException(message);
								}
								value = ((IDataConvert)obj).CreateViewModel();
							}
							property.SetValue(nodeObject, value, null);
						}
					}
				}
				if (!objectDictionary.ContainsKey(nodeObject.ActionTag))
				{
					objectDictionary.Add(nodeObject.ActionTag, nodeObject);
				}
				if (objectData != null)
				{
					((IDataInitialize)objectData).DataInitialize(nodeObject);
				}
				Type type = nodeObject.GetType();
				if (gResult.TypeIndex.ContainsKey(type))
				{
					if (nodeObject.ObjectIndex > gResult.TypeIndex[type])
					{
						gResult.TypeIndex[type] = nodeObject.ObjectIndex;
					}
				}
				else
				{
					gResult.TypeIndex.Add(type, nodeObject.ObjectIndex);
				}
				if (objectData.Children != null)
				{
					foreach (NodeObjectData current in objectData.Children)
					{
						NodeObject item = GameProjectLoader.ConvertObject(current, gResult, objectDictionary);
						nodeObject.Children.Add(item);
					}
				}
				nodeObject.IsAutoSize = false;
				result = nodeObject;
			}
			return result;
		}

		private static NodeObjectData ConvertObjectData(NodeObject nObject)
		{
			Type dataModelType = Services.ProjectsService.DataModelManager.GetDataModelType(nObject.GetType());
			NodeObjectData nodeObjectData = Activator.CreateInstance(dataModelType, true) as NodeObjectData;
			NodeObjectData result;
			if (nodeObjectData == null)
			{
				result = null;
			}
			else
			{
				PropertyInfo[] properties = nObject.GetType().GetProperties();
				PropertyInfo[] array = properties;
				for (int i = 0; i < array.Length; i++)
				{
					PropertyInfo propertyInfo = array[i];
					string name = propertyInfo.Name;
					if (!(name == "Children"))
					{
						PropertyInfo property = nodeObjectData.GetType().GetProperty(name);
						object value = propertyInfo.GetValue(nObject, null);
						if (property != null && value != null)
						{
							object obj = value;
							if (!property.PropertyType.Equals(propertyInfo.PropertyType))
							{
								obj = Activator.CreateInstance(property.PropertyType, true);
								if (!(obj is IDataConvert))
								{
									string message = string.Format("Property type are not same, the item is {0}, ViewType is {1}, DataType is {2}, Can use IDataConvert interface to convert.", nObject.GetType().Name, propertyInfo.PropertyType.Name, property.PropertyType.Name);
									throw new InvalidCastException(message);
								}
								((IDataConvert)obj).SetData(value);
							}
							property.SetValue(nodeObjectData, obj, null);
						}
					}
				}
				if (nObject.Children == null || nObject.Children.Count <= 0)
				{
					result = nodeObjectData;
				}
				else
				{
					nodeObjectData.Children = new List<NodeObjectData>();
					foreach (NodeObject current in nObject.Children)
					{
						NodeObjectData item = GameProjectLoader.ConvertObjectData(current);
						nodeObjectData.Children.Add(item);
					}
					result = nodeObjectData;
				}
			}
			return result;
		}

		private static TimelineAction ConvertTimeLineAction(TimelineActionData objectData, VisualObject vObject, Dictionary<int, VisualObject> objectTagDictionary)
		{
			TimelineAction timelineAction = new TimelineAction();
			timelineAction.Duration = objectData.Duration;
			timelineAction.Speed = objectData.Speed;
			TimelineAction result;
			if (objectData.Timelines == null || objectData.Timelines.Count <= 0)
			{
				result = timelineAction;
			}
			else
			{
				foreach (TimelineData current in objectData.Timelines)
				{
					if (objectTagDictionary.ContainsKey(current.ActionTag))
					{
						NodeObject nodeObject = objectTagDictionary[current.ActionTag] as NodeObject;
						if (nodeObject != null)
						{
							Timeline timeline = Timeline.CreateTimeline(current.FrameType, nodeObject);
							if (current.Frames != null && current.Frames.Count > 0)
							{
								foreach (FrameData current2 in current.Frames)
								{
									Frame item = GameProjectLoader.ConvertTimeLineFrame(current2, current.FrameType);
									timeline.Frames.Add(item);
								}
							}
						}
					}
				}
				result = timelineAction;
			}
			return result;
		}

		private static Frame ConvertTimeLineFrame(FrameData objectData, string typeStr)
		{
			string name = objectData.GetType().Name;
			string typeName = objectData.GetType().FullName.Replace("CocoStudio.Model.DataModel", "CocoStudio.Model.ViewModel").Replace(name, typeStr);
			Frame frame = Activator.CreateInstance(Type.GetType(typeName), true) as Frame;
			Frame result;
			if (frame == null)
			{
				result = null;
			}
			else
			{
				PropertyInfo[] properties = objectData.GetType().GetProperties();
				PropertyInfo[] array = properties;
				for (int i = 0; i < array.Length; i++)
				{
					PropertyInfo propertyInfo = array[i];
					string name2 = propertyInfo.Name;
					PropertyInfo property = frame.GetType().GetProperty(name2);
					object value = propertyInfo.GetValue(objectData, null);
					if (property != null && value != null)
					{
						object value2 = value;
						if (!property.PropertyType.Equals(propertyInfo.PropertyType))
						{
							if (!(value is IDataConvert))
							{
								string message = string.Format("Property type are not same, the item is {0}, ViewType is {1}, DataType is {2}, Can use IDataConvert interface to convert.", frame.GetType().Name, property.PropertyType.Name, propertyInfo.PropertyType.Name);
								throw new InvalidCastException(message);
							}
							value2 = ((IDataConvert)value).CreateViewModel();
						}
						property.SetValue(frame, value2, null);
					}
				}
				result = frame;
			}
			return result;
		}

		private static void ConvertTimeLineActionData(NodeObject nObject, TimelineActionData nTimelineActionData)
		{
			foreach (NodeObject current in nObject.Children)
			{
				GameProjectLoader.ConvertTimeLineActionData(current, nTimelineActionData);
				foreach (Timeline current2 in current.Timelines)
				{
					if (current2.Frames.Count > 0)
					{
						TimelineData timelineData = new TimelineData();
						timelineData.ActionTag = current.ActionTag;
						timelineData.FrameType = current2.FrameType;
						timelineData.Frames = new List<FrameData>();
						foreach (Frame current3 in current2.OrderedFrames)
						{
							string name = current3.GetType().BaseType.Name;
							if (name == "Frame")
							{
								name = current3.GetType().Name;
							}
							string newValue = name + "Data";
							string typeName = current3.GetType().FullName.Replace("CocoStudio.Model.ViewModel", "CocoStudio.Model.DataModel").Replace(current3.GetType().Name, newValue);
							FrameData frameData = Activator.CreateInstance(Type.GetType(typeName), true) as FrameData;
							if (frameData != null)
							{
								PropertyInfo[] properties = current3.GetType().GetProperties();
								PropertyInfo[] array = properties;
								for (int i = 0; i < array.Length; i++)
								{
									PropertyInfo propertyInfo = array[i];
									string name2 = propertyInfo.Name;
									if (!(name2 == "Children"))
									{
										PropertyInfo property = frameData.GetType().GetProperty(name2);
										object value = propertyInfo.GetValue(current3, null);
										if (property != null && value != null)
										{
											object obj = value;
											if (!property.PropertyType.Equals(propertyInfo.PropertyType))
											{
												obj = Activator.CreateInstance(property.PropertyType, true);
												if (!(obj is IDataConvert))
												{
													string message = string.Format("Property type are not same, the item is {0}, ViewType is {1}, DataType is {2}, Can use IDataConvert interface to convert.", nObject.GetType().Name, propertyInfo.PropertyType.Name, property.PropertyType.Name);
													throw new InvalidCastException(message);
												}
												((IDataConvert)obj).SetData(value);
											}
											property.SetValue(frameData, obj, null);
										}
									}
								}
								timelineData.Frames.Add(frameData);
							}
						}
						nTimelineActionData.Timelines.Add(timelineData);
					}
				}
			}
		}
	}
}
