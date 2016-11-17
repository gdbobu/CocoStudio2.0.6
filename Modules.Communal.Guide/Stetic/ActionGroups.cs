// Decompiled with JetBrains decompiler
// Type: Stetic.ActionGroups
// Assembly: Modules.Communal.Guide, Version=1.0.5464.34347, Culture=neutral, PublicKeyToken=null
// MVID: 170B36F5-747C-4B3C-9529-30988307B6DF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.Guide.dll

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
