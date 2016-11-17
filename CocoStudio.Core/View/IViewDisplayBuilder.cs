// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.View.IViewDisplayBuilder
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using CocoStudio.Projects;
using MonoDevelop.Core;

namespace CocoStudio.Core.View
{
  public interface IViewDisplayBuilder : IDisplayBuilder
  {
    string Name { get; }

    IViewContentExtend CreateContent(FilePath fileName, string mimeType, Project ownerProject);
  }
}
