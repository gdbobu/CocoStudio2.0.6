// Decompiled with JetBrains decompiler
// Type: Stetic.Gui
// Assembly: Modules.Communal.Guide, Version=1.0.5464.34347, Culture=neutral, PublicKeyToken=null
// MVID: 170B36F5-747C-4B3C-9529-30988307B6DF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.Guide.dll

using Gtk;

namespace Stetic
{
  internal class Gui
  {
    private static bool initialized;

    internal static void Initialize(Widget iconRenderer)
    {
      if (Gui.initialized)
        return;
      Gui.initialized = true;
    }
  }
}
