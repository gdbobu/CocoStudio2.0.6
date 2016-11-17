// Decompiled with JetBrains decompiler
// Type: Stetic.ActionGroups
// Assembly: CocoStudio.ControlLib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 677D14F9-F98B-4FDA-9ECD-6C6F82FD30A1
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ControlLib.dll

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
