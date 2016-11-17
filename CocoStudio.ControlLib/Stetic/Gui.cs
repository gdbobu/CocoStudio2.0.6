// Decompiled with JetBrains decompiler
// Type: Stetic.Gui
// Assembly: CocoStudio.ControlLib, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 677D14F9-F98B-4FDA-9ECD-6C6F82FD30A1
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.ControlLib.dll

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
