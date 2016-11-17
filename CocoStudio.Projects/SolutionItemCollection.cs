// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.SolutionItemCollection
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using MonoDevelop.Core.Serialization;

namespace CocoStudio.Projects
{
  [DataItem("ResourceGroup")]
  public class SolutionItemCollection : ItemCollection<SolutionEntityItem>
  {
    private SolutionFolder parentSolutionFolder;

    public SolutionItemCollection()
    {
    }

    public SolutionItemCollection(SolutionFolder parentSolutionFolder)
    {
      this.parentSolutionFolder = parentSolutionFolder;
    }

    protected override void OnAdd(SolutionEntityItem item)
    {
      if (this.parentSolutionFolder == null)
        return;
      item.ParentFolder = this.parentSolutionFolder;
      item.ParentSolution = this.parentSolutionFolder.ParentSolution;
    }

    protected override void OnRemove(SolutionEntityItem item)
    {
      item.ParentFolder = (SolutionFolder) null;
      item.ParentSolution = (Solution) null;
    }
  }
}
