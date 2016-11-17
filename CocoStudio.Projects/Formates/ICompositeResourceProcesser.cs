// Decompiled with JetBrains decompiler
// Type: CocoStudio.Projects.Formates.ICompositeResourceProcesser
// Assembly: CocoStudio.Projects, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DCF182CC-57DB-4DD6-AF38-C89A798411CC
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Projects.dll

using Mono.Addins;
using System.Collections.Generic;

namespace CocoStudio.Projects.Formates
{
  [TypeExtensionPoint]
  public interface ICompositeResourceProcesser
  {
    bool CanProcess(string filePath);

    List<string> GetMatchedImages(string filePath);
  }
}
