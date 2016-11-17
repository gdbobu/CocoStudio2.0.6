using CocoStudio.Basic;
using CocoStudio.Projects;
using Mono.Addins;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.IO;

namespace CocoStudio.Model.ExtensionModel
{
	[Extension(typeof(IGameProjectSerializer))]
	internal class JsonSerializer : IGameProjectSerializer
	{
		private const string displayName = "Json";

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
			JsonConverter item = new StringEnumConverter();
			this.Setting.Converters.Add(item);
		}

		public string Serialize(PublishInfo info, IProjectFile projFile)
		{
			string result;
			try
			{
				string path = info.DestinationFilePath.ChangeExtension(".json");
				string contents = JsonConvert.SerializeObject(projFile, this.Setting);
				if (File.Exists(path))
				{
					File.Delete(path);
				}
				File.WriteAllText(path, contents);
				result = string.Empty;
			}
			catch (Exception ex)
			{
				LogConfig.Logger.Error("发布Json失败：\r\n" + ex.ToString());
				result = string.Format("Failed to publish to json, {0}", ex.Message);
			}
			return result;
		}
	}
}
