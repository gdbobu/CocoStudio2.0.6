// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.IViewContentExtend
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using CocoStudio.Core.View;
using CocoStudio.Projects;
using MonoDevelop.Ide.Gui;
using System;

namespace CocoStudio.Core
{
  public interface IViewContentExtend : IViewContent, IBaseViewContent, IDisposable
  {
    Project Project { get; set; }

    IDocumentWindow WorkbenchWindow { get; set; }

    void Activated();

    void Deactivated();

    void Closing();

    void Closed();
  }
}
