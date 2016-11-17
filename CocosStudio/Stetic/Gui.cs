// Decompiled with JetBrains decompiler
// Type: Stetic.Gui
// Assembly: CocosStudio, Version=2.0.6.0, Culture=neutral, PublicKeyToken=null
// MVID: F931EF05-B4A9-479F-8470-995544832753
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocosStudio.exe

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
