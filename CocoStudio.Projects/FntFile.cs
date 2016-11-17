// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.FntFile
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using CocoStudio.Basic;
using CocoStudio.Model;
using CocoStudio.Projects.Formates;
using MonoDevelop.Core;
using MonoDevelop.Core.Serialization;
using System;
using System.IO;

namespace CocoStudio.Projects
{
    [DataItem(Name = "Fnt")]
    public class FntFile : ResourceFile
    {
        public const string FileSuffix = ".fnt";

        private static ICompositeResourceProcesser pairResourceProcesser;

        internal override string PreviewImagePath
        {
            get
            {
                return PairResourceHelp.GetMatchedImage(base.FullPath, ".png");
            }
        }

        private FntFile()
        {
        }

        public FntFile(FilePath file)
            : base(file)
        {
        }

        public FntFile(ResourceData resourceData)
            : base(resourceData)
        {
        }

        protected override void OnSetLocation(FilePath newFilePath, bool isRename = true)
        {
            string directoryName = Path.GetDirectoryName(newFilePath);
            FilePath filePath = this.PreviewImagePath;
            string dstFile = Path.Combine(directoryName, filePath.FileName);
            if (!isRename)
            {
                try
                {
                    FileService.MoveFile(filePath, dstFile);
                }
                catch (Exception ex)
                {
                    LogConfig.Output.Error(ex.Message, ex);
                }
            }
            base.OnSetLocation(newFilePath, isRename);
        }

        protected override void OnDelete()
        {
            //TODO:
            //this.PreviewImagePath.Delete();
            base.FileName.Delete();
            base.OnDelete();
        }

        protected override ICompositeResourceProcesser GetCompositeResourceProcesser()
        {
            if (FntFile.pairResourceProcesser == null)
            {
                FntFile.pairResourceProcesser = ProjectsService.Instance.GetCompositeResourceProcesser(base.FileName);
            }
            return FntFile.pairResourceProcesser;
        }

        protected override bool OnCheckValid()
        {
            bool flag = base.OnCheckValid();
            if (flag && this.PreviewImagePath == null)
            {
                flag = false;
            }
            return flag;
        }
    }
}
