// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.ProjectCreateInformation
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using MonoDevelop.Core;
using System.Collections.Generic;

namespace CocoStudio.Projects
{
  public class ProjectCreateInformation
  {
    public FilePath FileName { get; set; }

    public IProjectContent Content { get; set; }

    public string ContentType { get; set; }

    public IList<ResourceItem> SelectedResourceItem { get; private set; }

    public float Width { get; private set; }

    public float Height { get; set; }

    public ProjectCreateInformation(FilePath fileName, IProjectContent content = null, IList<ResourceItem> selectedItems = null, float width = 0.0f, float height = 0.0f)
    {
      this.FileName = fileName;
      this.SelectedResourceItem = selectedItems;
      this.Width = width;
      this.Height = height;
    }
  }
}
