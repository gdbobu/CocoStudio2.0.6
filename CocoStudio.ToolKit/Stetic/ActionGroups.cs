// Decompiled with JetBrains decompiler
// Type: Stetic.ActionGroups
// Assembly: CocoStudio.ToolKit, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1DF66ED6-34A9-42A1-B332-161EEDB05F29
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ToolKit.dll

using Gtk;
using System;

namespace Stetic
{
  internal class ActionGroups
  {
    public static ActionGroup GetActionGroup(Type type)
    {
      return ActionGroups.GetActionGroup(type.FullName);
    }

    public static ActionGroup GetActionGroup(string name)
    {
      return (ActionGroup) null;
    }
  }
}
