// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.ProjectsService
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using CocoStudio.Basic;
using CocoStudio.Model;
using CocoStudio.Projects.Formates;
using MonoDevelop.Core;
using System;
using System.Collections.Generic;
using System.IO;

namespace CocoStudio.Projects
{
    public class ProjectsService
    {
        private static ProjectsService instance;

        internal FileFormatManager FormatManager
        {
            get;
            private set;
        }

        internal ProjectBindingManager ProjectBindingManager
        {
            get;
            private set;
        }

        internal ProcesserManager ProcesserManager
        {
            get;
            private set;
        }

        internal PreviewImageService PreviemImageService
        {
            get;
            private set;
        }

        public DataModelManager DataModelManager
        {
            get;
            private set;
        }

        public ISerializeManager SerializeManager
        {
            get;
            private set;
        }

        public Solution CurrentSolution
        {
            get;
            set;
        }

        public ResourceGroup CurrentResourceGroup
        {
            get
            {
                return this.GetResourceGroup(this.CurrentSolution);
            }
        }

        public IProgressMonitor DefaultMonitor
        {
            get;
            set;
        }

        public static ProjectsService Instance
        {
            get
            {
                if (ProjectsService.instance == null)
                {
                    ProjectsService.instance = new ProjectsService();
                }
                return ProjectsService.instance;
            }
        }

        private ProjectsService()
        {
            this.FormatManager = new FileFormatManager();
            this.ProjectBindingManager = new ProjectBindingManager();
            this.ProcesserManager = new ProcesserManager();
            this.SerializeManager = new SerializeManager();
            this.PreviemImageService = new PreviewImageService();
            this.DataModelManager = new DataModelManager();
        }

        public Solution GetWrapperSolution(IProgressMonitor monitor, string filename)
        {
            List<FileFormat> fileFormats = this.FormatManager.GetFileFormats(filename, typeof(Solution));
            Solution solution;
            if (fileFormats.Count == 0)
            {
                solution = new Solution();
                ProjectsService.SetSolutionLocation(filename, solution);
                Project item = this.ReadProject(monitor, filename);
                ResourceGroup resourceGroup = new ResourceGroup(solution);
                resourceGroup.RootFolder.Items.Add(item);
                solution.RootFolder.Items.Add(resourceGroup);
                return solution;
            }
            solution = this.ReadWorkspaceItem(monitor, filename);
            ProjectsService.SetSolutionLocation(filename, solution);
            return solution;
        }

        public ResourceItem ReadResourceItem(IProgressMonitor monitor, string itemFileName)
        {
            Type typeFromHandle = typeof(ResourceItem);
            List<FileFormat> fileFormats = this.FormatManager.GetFileFormats(itemFileName, typeof(ResourceItem));
            IFileFormat format;
            if (fileFormats != null && fileFormats.Count > 0)
            {
                format = fileFormats[0];
            }
            else
            {
                format = this.FormatManager.GetDefaultResourceFormat();
            }
            ResourceItem resourceItem = this.ReadFile(monitor, itemFileName, typeFromHandle, format) as ResourceItem;
            if (resourceItem == null)
            {
                throw new InvalidOperationException("Invalid file format: " + itemFileName);
            }
            return resourceItem;
        }

        public Project ReadProject(IProgressMonitor monitor, string filename)
        {
            IFileFormat fileFormat;
            return this.ReadFile(monitor, filename, typeof(Project), out fileFormat) as Project;
        }

        internal Solution ReadWorkspaceItem(IProgressMonitor monitor, string filename)
        {
            return this.ReadSolution(monitor, filename);
        }

        internal Solution ReadSolution(IProgressMonitor monitor, string filename)
        {
            IFileFormat fileFormat;
            return this.ReadFile(monitor, filename, typeof(Solution), out fileFormat) as Solution;
        }

        public void ChangeSolutionName(IProgressMonitor monitor, FilePath newSolutionPath, string oldName, string newName)
        {
            Solution solution = this.ReadSolution(monitor, newSolutionPath);
            solution.SetLocation(newSolutionPath.ParentDirectory, newName);
            solution.Save(monitor);
            string preferencesFileName = solution.GetPreferencesFileName();
            string text = Path.Combine(newSolutionPath.ParentDirectory, oldName + solution.cfgFileSuffix);
            if (File.Exists(text))
            {
                FileService.RenameFile(text, preferencesFileName);
            }
        }

        private static void SetSolutionLocation(string filename, Solution solution)
        {
            string directoryName = Path.GetDirectoryName(filename);
            solution.SetLocation(directoryName, Path.GetFileNameWithoutExtension(filename));
        }

        public bool IsProjectFile(string fileName)
        {
            return this.FormatManager.GetFileFormats(fileName, typeof(Project)).Count > 0;
        }

        public bool IsProjectFile(ResourceData resourceData)
        {
            FilePath p = new FilePath(resourceData.Path);
            string fileName = p.ToAbsolute(this.CurrentSolution.ItemDirectory);
            return this.IsProjectFile(fileName);
        }

        internal bool IsImageFile(string fileName)
        {
            return this.FormatManager.GetFileFormats(fileName, typeof(ImageFile)).Count > 0;
        }

        internal bool IsImageFile(ResourceData resourceData)
        {
            FilePath tmp = new FilePath(resourceData.Path);
            string fileName = tmp.ToAbsolute(this.CurrentSolution.ItemDirectory);
            return this.IsImageFile(fileName);
        }

        private object ReadFile(IProgressMonitor monitor, string file, Type expectedType, IFileFormat format)
        {
            object obj = format.ReadFile(file, expectedType, monitor);
            if (obj == null)
            {
                throw new InvalidOperationException("Invalid file format: " + file);
            }
            return obj;
        }

        private object ReadFile(IProgressMonitor monitor, string file, Type expectedType, out IFileFormat format)
        {
            List<FileFormat> fileFormats = this.FormatManager.GetFileFormats(file, expectedType);
            if (fileFormats.Count == 0)
            {
                throw new InvalidOperationException("Unknown file format: " + file);
            }
            format = fileFormats[0];
            return this.ReadFile(monitor, file, expectedType, format);
        }

        private string GetTargetFile(string file)
        {
            return file;
        }

        internal void Save(IProgressMonitor monitor, WorkspaceItem workspaceItem)
        {
            workspaceItem.OnSave(monitor);
        }

        internal void InternalWriteWorkspaceItem(IProgressMonitor monitor, FilePath file, WorkspaceItem item)
        {
            FilePath filePath = this.WriteFile(monitor, file, item, item.FileFormat);
            if (filePath != null)
            {
                item.FileName = filePath;
                return;
            }
            throw new InvalidOperationException("FileFormat not provided for workspace item '" + item.Name + "'");
        }

        internal ProjectFile InternalReadProjectFile(IProgressMonitor monitor, string file)
        {
            IFileFormat fileFormat;
            ProjectFile projectFile = this.ReadFile(monitor, file, typeof(ProjectFile), out fileFormat) as ProjectFile;
            projectFile.FileName = file;
            return projectFile;
        }

        private FilePath WriteFile(IProgressMonitor monitor, FilePath file, object item, FileFormat fileFormat)
        {
            fileFormat.WriteFile(file, item, monitor);
            if (monitor.AsyncOperation.Success)
            {
                return file;
            }
            return null;
        }

        internal FileFormat GetDefaultFormat(object obj)
        {
            List<FileFormat> fileFormatsForObject = this.FormatManager.GetFileFormatsForObject(obj);
            if (fileFormatsForObject.Count == 0)
            {
                throw new InvalidOperationException("Can't handle objects of type '" + obj.GetType() + "'");
            }
            return fileFormatsForObject[0];
        }

        internal void InternalWriteProjectFile(IProgressMonitor monitor, FilePath file, ProjectFile item)
        {
            FilePath filePath = this.WriteFile(monitor, file, item, item.FileFormat);
            if (filePath != null)
            {
                item.FileName = filePath;
                return;
            }
            throw new InvalidOperationException("FileFormat not provided for workspace item '" + item.Name + "'");
        }

        public Project CreateProject(string type, ProjectCreateInformation info)
        {
            info.ContentType = type;
            foreach (IProjectBinding current in this.ProjectBindingManager.ProjectBindings)
            {
                if (current.CanCreateProject(type))
                {
                    return current.CreateProject(info);
                }
            }
            throw new InvalidOperationException("Project type '" + type + "' not found");
        }

        public Solution CreateSolution(string directory, string name)
        {
            string text = Path.Combine(directory, name);
            if (!Directory.Exists(text))
            {
                Directory.CreateDirectory(text);
            }
            Solution solution = new Solution();
            solution.SetLocation(text, name);
            ResourceGroup item = new ResourceGroup(solution);
            solution.RootFolder.Items.Add(item);
            return solution;
        }

        private ResourceGroup GetResourceGroup(Solution solution)
        {
            if (solution != null)
            {
                return solution.RootFolder.Items[0] as ResourceGroup;
            }
            return null;
        }

        internal IPublishProcesser GetPublishProcesser(ResourceData resourceData)
        {
            return this.ProcesserManager.GetPublishProcesser(resourceData);
        }

        public FilePath GetFullPath(ResourceData resourceData)
        {
            if (resourceData.Type == EnumResourceType.Default)
            {
                return Option.GetEditorResourceFullPath(resourceData.Path);
            }
            if (resourceData.Type == EnumResourceType.None || resourceData.Type == EnumResourceType.PlistSubImage)
            {
                throw new ArgumentException("Can't convert to full path.");
            }
            FilePath tmp = new FilePath(resourceData.Path);
            return tmp.ToAbsolute(this.CurrentSolution.ItemDirectory);
        }

        public ICompositeResourceProcesser GetCompositeResourceProcesser(string filePath)
        {
            if (!Path.IsPathRooted(filePath))
            {
                throw new ArgumentException("File path must be a absolute path.");
            }
            return this.ProcesserManager.GetPairResourceProcesser(filePath);
        }

        internal void NotifyResourceFileChanged(ChangedResourceCollection changedResourceCollection)
        {
            if (this.CurrentResourceGroup == null)
            {
                return;
            }
            IProjectFile rootFolder = this.CurrentResourceGroup.RootFolder;
            rootFolder.UpdateUsedResources(this.DefaultMonitor, changedResourceCollection);
        }

        public string SerializeGameProject(PublishInfo info, IProjectFile projFile)
        {
            IGameProjectSerializer currentSerializer = this.SerializeManager.CurrentSerializer;
            if (currentSerializer == null)
            {
                return "There is no publisher";
            }
            return currentSerializer.Serialize(info, projFile);
        }
    }
}
