// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.DataModel.ActionTagManager
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Core;
using CocoStudio.Core.Events;
using System;

namespace CocoStudio.Model.DataModel
{
  public class ActionTagManager
  {
    private static int tag = 0;

    static ActionTagManager()
    {
      Services.ProjectOperations.CurrentSelectedSolutionChanged += new EventHandler<SolutionEventArgs>(ActionTagManager.HandleCurrentSelectedSolutionChanged);
    }

    private static void HandleCurrentSelectedSolutionChanged(object sender, SolutionEventArgs e)
    {
      ActionTagManager.ResetObjectActionTag();
    }

    public static int CreateObjectActionTag()
    {
      return Guid.NewGuid().ToString().GetHashCode();
    }

    public static void RefreshObjectActionTag(int iTag)
    {
      if (ActionTagManager.tag >= iTag)
        return;
      ActionTagManager.tag = iTag;
    }

    public static void ResetObjectActionTag()
    {
      ActionTagManager.tag = 0;
    }
  }
}
