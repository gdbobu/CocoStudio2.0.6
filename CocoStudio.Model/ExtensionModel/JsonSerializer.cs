// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ExtensionModel.JsonSerializer
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Basic;
using CocoStudio.Projects;
using Mono.Addins;
using MonoDevelop.Core;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.IO;

namespace CocoStudio.Model.ExtensionModel
{
  [Extension(typeof (IGameProjectSerializer))]
  internal class JsonSerializer : IGameProjectSerializer
  {
    private const string displayName = "Json�";
    private JsonSerializerSettings Setting;

    public string ID
    {
      get
      {
        return "Serializer_Json";
      }
    }

    public string Label
    {
      get
      {
        return "Json";
      }
    }

    public JsonSerializer()
    {
      this.InitSerializeSetting();
    }

    private void InitSerializeSetting()
    {
      this.Setting = new JsonSerializerSettings();
      this.Setting.DefaultValueHandling = DefaultValueHandling.Include;
      this.Setting.NullValueHandling = NullValueHandling.Ignore;
      this.Setting.ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor;
      this.Setting.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
      this.Setting.TypeNameHandling = TypeNameHandling.None;
      this.Setting.Formatting = Formatting.Indented;
      this.Setting.Converters.Add((JsonConverter) new StringEnumConverter());
    }

    public string Serialize(PublishInfo info, IProjectFile projFile)
    {
      try
      {
        string path = (string) (FilePath) info.DestinationFilePath.ChangeExtension(".json");
        string contents = JsonConvert.SerializeObject((object) projFile, this.Setting);
        if (File.Exists(path))
          File.Delete(path);
        File.WriteAllText(path, contents);
        return string.Empty;
      }
      catch (Exception ex)
      {
        LogConfig.Logger.Error((object) ("发布Json失败：\r\n" + ex.ToString()));
        return string.Format("Failed to publish to json, {0}", (object) ex.Message);
      }
    }
  }
}
