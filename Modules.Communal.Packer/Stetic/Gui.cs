// Decompiled with JetBrains decompiler
// Type: Stetic.Gui
// Assembly: Modules.Communal.Packer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: C7209B7C-6A4B-4239-96DC-96EFD0A7660A
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\Modules.Communal.Packer.dll

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
