// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.SerializeManager
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using Mono.Addins;
using System.Collections.Generic;

namespace CocoStudio.Projects
{
  internal class SerializeManager : ISerializeManager
  {
    private List<IGameProjectSerializer> serializerList;

    public IGameProjectSerializer CurrentSerializer
    {
      get
      {
        return this.GetSerializerById("Serializer_FlatBuffers");
      }
      set
      {
        if (value == null)
          return;
        Solution currentSolution = ProjectsService.Instance.CurrentSolution;
        if (currentSolution == null)
          return;
        currentSolution.UserProperties.SetValue<string>("CustomSerializer", value.ID);
        currentSolution.SaveUserProperties();
      }
    }

    public IGameProjectSerializer DefaultSerializer
    {
      get
      {
        return this.GetSerializerById("Serializer_FlatBuffers");
      }
    }

    internal SerializeManager()
    {
      this.serializerList = new List<IGameProjectSerializer>();
      foreach (IGameProjectSerializer extensionObject in AddinManager.GetExtensionObjects<IGameProjectSerializer>())
        this.serializerList.Add(extensionObject);
    }

    public List<IGameProjectSerializer> GetSerializerList()
    {
      List<IGameProjectSerializer> projectSerializerList = new List<IGameProjectSerializer>();
      foreach (IGameProjectSerializer serializer in this.serializerList)
        projectSerializerList.Add(serializer);
      return projectSerializerList;
    }

    private IGameProjectSerializer GetSerializerById(string id)
    {
      foreach (IGameProjectSerializer serializer in this.serializerList)
      {
        if (serializer.ID.Equals(id))
          return serializer;
      }
      return (IGameProjectSerializer) null;
    }
  }
}
