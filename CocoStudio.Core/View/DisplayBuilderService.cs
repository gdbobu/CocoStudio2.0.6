// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.View.DisplayBuilderService
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using CocoStudio.Projects;
using Mono.Addins;
using MonoDevelop.Core;
using System.Collections.Generic;
using System.Linq;

namespace CocoStudio.Core.View
{
  public static class DisplayBuilderService
  {
    public static IEnumerable<T> GetBuilder<T>()
    {
      return AddinManager.GetExtensionObjects("CocoStudio/Ide/DisplayBuilder", true).OfType<T>();
    }

    internal static IEnumerable<IDisplayBuilder> GetDisplayBuilders(FilePath filePath, string mimeType, Project ownerProject)
    {
      foreach (IDisplayBuilder displayBuilder in DisplayBuilderService.GetBuilder<IDisplayBuilder>())
      {
        if (displayBuilder.CanHandle(filePath, mimeType, ownerProject))
          yield return displayBuilder;
      }
    }
  }
}
