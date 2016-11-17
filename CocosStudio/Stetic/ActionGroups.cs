// Decompiled with JetBrains decompiler
// Type: Stetic.ActionGroups
// Assembly: CocosStudio, Version=2.0.6.0, Culture=neutral, PublicKeyToken=null
// MVID: F931EF05-B4A9-479F-8470-995544832753
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocosStudio.exe

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
