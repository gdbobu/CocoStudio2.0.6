// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.ImportResourceResult
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using CocoStudio.ControlLib;
using CocoStudio.Projects;
using System.Collections.Generic;
using System.Threading;

namespace CocoStudio.Core
{
  public class ImportResourceResult
  {
    public List<ResourceItem> ImportResources { get; set; }

    public List<ResourceItem> AddResourcePanelItems { get; set; }

    internal DialogResult DialogResult { get; set; }

    public IEnumerable<string> FileTypeSuffix { get; set; }

    internal CancellationToken Token { get; set; }

    public ImportResourceResult()
    {
      this.ImportResources = new List<ResourceItem>();
      this.AddResourcePanelItems = new List<ResourceItem>();
      this.DialogResult = new DialogResult();
      this.Token = CancellationToken.None;
    }
  }
}
