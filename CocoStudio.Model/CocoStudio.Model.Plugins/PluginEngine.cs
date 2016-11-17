using CocoStudio.Basic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace CocoStudio.Model.Plugins
{
	public static class PluginEngine
	{
		private const string pathName = "Path";

		public static bool IsLoaded
		{
			get;
			private set;
		}

		public static List<Assembly> AssemblyList
		{
			get;
			private set;
		}

		public static List<string> CppDLLList
		{
			get;
			private set;
		}

		public static List<Assembly> LoadPlugins()
		{
			if (!Directory.Exists(Option.AddinLocationFolder))
			{
				throw new ArgumentNullException("The plugin path is null or the plugin path directory does not exist.");
			}
			List<Assembly> assemblyList;
			if (PluginEngine.IsLoaded)
			{
				assemblyList = PluginEngine.AssemblyList;
			}
			else
			{
				PluginEngine.IsLoaded = true;
				PluginEngine.SetEnvironmentPath();
				string[] files = Directory.GetFiles(Option.AddinLocationFolder, "*.dll");
				PluginEngine.AssemblyList = new List<Assembly>();
				PluginEngine.CppDLLList = new List<string>();
				PluginEngine.LoadAssembly(files, PluginEngine.AssemblyList, PluginEngine.CppDLLList);
				assemblyList = PluginEngine.AssemblyList;
			}
			return assemblyList;
		}

		private static void LoadAssembly(string[] fileArray, List<Assembly> assemblyList, List<string> cppdllList)
		{
			for (int i = 0; i < fileArray.Length; i++)
			{
				string text = fileArray[i];
				try
				{
					if (PluginEngine.IsManagedAssembly(text))
					{
						Assembly item = Assembly.LoadFrom(text);
						assemblyList.Add(item);
					}
					else
					{
						DllAPIWrap.LoadLibrary(text);
						cppdllList.Add(text);
					}
				}
				catch (Exception exception)
				{
					LogConfig.Output.Error("load managed dll failed. The file is " + text, exception);
				}
			}
		}

		private static bool IsManagedAssembly(string fileName)
		{
			bool result;
			using (Stream stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
			{
				using (BinaryReader binaryReader = new BinaryReader(stream))
				{
					if (stream.Length < 64L)
					{
						result = false;
					}
					else
					{
						stream.Position = 60L;
						uint num = binaryReader.ReadUInt32();
						if (num == 0u)
						{
							num = 128u;
						}
						if ((ulong)num > (ulong)(stream.Length - 256L))
						{
							result = false;
						}
						else
						{
							stream.Position = (long)((ulong)num);
							uint num2 = binaryReader.ReadUInt32();
							if (num2 != 17744u)
							{
								result = false;
							}
							else
							{
								stream.Position += 20L;
								ushort num3 = binaryReader.ReadUInt16();
								if (num3 != 267 && num3 != 523)
								{
									result = false;
								}
								else
								{
									ushort num4 = (ushort)((ulong)num + (ulong)((num3 == 267) ? 232L : 248L));
									stream.Position = (long)((ulong)num4);
									uint num5 = binaryReader.ReadUInt32();
									if (num5 == 0u)
									{
										result = false;
									}
									else
									{
										result = true;
									}
								}
							}
						}
					}
				}
			}
			return result;
		}

		private static void SetEnvironmentPath()
		{
			string text = Environment.GetEnvironmentVariable("Path");
			text = text + ";" + Option.AddinLocationFolder;
			Environment.SetEnvironmentVariable("Path", text);
		}
	}
}
