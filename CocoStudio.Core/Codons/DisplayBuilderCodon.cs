// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.Codons.DisplayBuilderCodon
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using Mono.Addins;

namespace CocoStudio.Core.Codons
{
  public class DisplayBuilderCodon : TypeExtensionNode
  {
    public object Binding
    {
      get
      {
        return this.GetInstance();
      }
    }
  }
}
