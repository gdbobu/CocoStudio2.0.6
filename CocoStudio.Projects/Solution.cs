// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.Solution
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using CocoStudio.Basic;
using MonoDevelop.Core;
using MonoDevelop.Core.Serialization;
using System;
using System.Collections.ObjectModel;
using System.IO;

namespace CocoStudio.Projects
{
[DataInclude(typeof(SolutionFolder))]
	public class Solution : WorkspaceItem, IPublish
	{
		public const string FileSuffix = ".ccs";

		public const string DefaultPublishDirectoryName = "res";

		[ItemProperty("PropertyGroup/Version")]
		private string version = Option.EditorVersion.ToString();

		[ItemProperty("PropertyGroup/Type")]
		private string type = "CocosStudio";

		private SolutionFolder rootFolder;

		private FilePath itemDirectory;

		[ItemProperty("PropertyGroup/Name")]
		public override string Name
		{
			get;
			set;
		}

		public Version Version
		{
			get
			{
				return new Version(this.version);
			}
			set
			{
				this.version = value.ToString();
			}
		}

		[ItemProperty("SolutionFolder")]
		public SolutionFolder RootFolder
		{
			get
			{
				if (this.rootFolder == null)
				{
					this.rootFolder = new SolutionFolder();
					this.rootFolder.ParentSolution = this;
				}
				return this.rootFolder;
			}
			internal set
			{
				this.rootFolder = value;
			}
		}

		public override FilePath ItemDirectory
		{
			get
			{
				return this.itemDirectory;
			}
		}

		public string PublishDirectory
		{
			get;
			private set;
		}

		public void Publish(IProgressMonitor monitor, PublishInfo info)
		{
			if (!Directory.Exists(info.PublishDirectory))
			{
				Directory.CreateDirectory(info.PublishDirectory);
			}
		}

		public void Initialize(IProgressMonitor monitor)
		{
			if (this.type == "Flash")
			{
				this.ConvertFlashSolution(monitor);
				this.type = "CocosStudio";
			}
			foreach (SolutionEntityItem current in this.RootFolder.Items)
			{
				IInitialize initialize = current as IInitialize;
				if (initialize != null)
				{
					initialize.Initialize(monitor);
				}
			}
			this.SetPublishDirectory();
		}

		private void SetPublishDirectory()
		{
			if (!base.UserProperties.HasValue("PublishDirectory"))
			{
				base.UserProperties.SetValue<string>("PublishDirectory", "res");
			}
            FilePath t = new FilePath(base.UserProperties.GetValue<string>("PublishDirectory"));
			this.PublishDirectory = t.ToAbsolute(base.BaseDirectory);
		}

		private void ConvertFlashSolution(IProgressMonitor monitor)
		{
			ResourceFolder parentFolder = ((ResourceGroup)this.RootFolder.Items[0]).RootFolder;
			if (Directory.Exists(this.itemDirectory))
			{
				this.LoadFlashResource(monitor, parentFolder, this.itemDirectory);
			}
		}

		private void LoadFlashResource(IProgressMonitor monitor, ResourceFolder parentFolder, string parentDirectory)
		{
			string[] fileSystemEntries = Directory.GetFileSystemEntries(parentDirectory);
			string[] array = fileSystemEntries;
			for (int i = 0; i < array.Length; i++)
			{
				string itemFileName = array[i];
				ResourceItem resourceItem = ProjectsService.Instance.ReadResourceItem(monitor, itemFileName);
				if (resourceItem != null)
				{
					parentFolder.Items.Add(resourceItem);
				}
				if (resourceItem is ResourceFolder)
				{
					this.LoadFlashResource(monitor, resourceItem as ResourceFolder, resourceItem.FullPath);
				}
			}
		}

		public override Project GetProjectContainingFile(FilePath fileName)
		{
			return this.RootFolder.GetProjectContainingFile(fileName);
		}

		public void SetLocation(FilePath baseDirectory, string name)
		{
			this.FileName = baseDirectory.Combine(new string[]
			{
				name + ".ccs"
			});
			this.Name = name;
			this.itemDirectory = baseDirectory.Combine(new string[]
			{
				"CocosStudio".ToLower()
			});
			if (!Directory.Exists(this.itemDirectory))
			{
				Directory.CreateDirectory(this.itemDirectory);
			}
		}

		public override int GetHashCode()
		{
			return this.FileName.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			return obj is Solution && this.FileName == ((Solution)obj).FileName;
		}
	} 
}
