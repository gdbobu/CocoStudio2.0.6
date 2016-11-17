// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.View.PadCollection
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using System;
using System.Collections.Generic;
using System.Linq;

namespace CocoStudio.Core.View
{
  public class PadCollection : List<Pad>
  {
    private Workbench workbench;

    public Pad PropertyPad
    {
      get
      {
        return this.GetPad("Modules.Communal.PropertyGrid.PropertyGridPad");
      }
    }

    public PadCollection(Workbench workbench)
    {
      this.workbench = workbench;
    }

    private Pad GetPad(string id)
    {
      return this.workbench.Pads.FirstOrDefault<Pad>((Func<Pad, bool>) (p => p.Id == id));
    }
  }
}
