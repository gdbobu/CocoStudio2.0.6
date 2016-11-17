// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.SolutionFolder
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using MonoDevelop.Core;
using MonoDevelop.Core.Serialization;
using System.Collections.ObjectModel;

namespace CocoStudio.Projects
{
  [DataInclude(typeof (ResourceGroup))]
  public class SolutionFolder : SolutionItem, IFoldeItem
  {
    private SolutionItemCollection items;

    [ExpandedCollection]
    [ItemProperty("Group")]
    public SolutionItemCollection Items
    {
      get
      {
        if (this.items == null)
          this.items = new SolutionItemCollection(this);
        return this.items;
      }
      private set
      {
        this.items = value;
        foreach (SolutionItem solutionItem in (Collection<SolutionEntityItem>) this.items)
          solutionItem.ParentFolder = this;
      }
    }

    public override string Name { get; set; }

    public FilePath BaseDirectory
    {
      get
      {
        return this.ParentSolution.BaseDirectory;
      }
    }

    internal Project GetProjectContainingFile(FilePath fileName)
    {
      foreach (SolutionEntityItem solutionEntityItem in (Collection<SolutionEntityItem>) this.Items)
        ;
      return (Project) null;
    }
  }
}
