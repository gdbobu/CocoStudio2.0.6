// Decompiled with JetBrains decompiler
// Type: Stetic.ActionGroups
// Assembly: Modules.Communal.Packer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C7209B7C-6A4B-4239-96DC-96EFD0A7660A
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.Packer.dll

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
