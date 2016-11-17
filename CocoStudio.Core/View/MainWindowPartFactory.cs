// Decompiled with JetBrains decompiler
// Type: CocoStudio.Core.View.MainWindowPartFactory
// Assembly: CocoStudio.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 664CC19D-01B7-42F7-9640-243AA07066CE
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Core.dll

using CocoStudio.Core.ExtensionModel;
using Gtk;
using Mono.Addins;

namespace CocoStudio.Core.View
{
  public class MainWindowPartFactory
  {
    public static Widget CreateMainToolbarWidget()
    {
      return MainWindowPartFactory.GetExtensionPart<Widget>("/CocoStudio/Ide/MainToolbar", true);
    }

    public static IMainTool GetMainTool()
    {
      return MainWindowPartFactory.GetExtensionPart<IMainTool>("/CocoStudio/Ide/MainToolbar", true);
    }

    public static Widget CreateMainStatus()
    {
      return MainWindowPartFactory.GetExtensionPart<Widget>("/CocoStudio/Ide/MainStatus", true);
    }

    public static Widget CreateMainStartPage()
    {
      return MainWindowPartFactory.GetExtensionPart<Widget>("/CocoStudio/Ide/MainStartPage", true);
    }

    public static IMainRender CreateMainRenderContent()
    {
      return MainWindowPartFactory.GetExtensionPart<IMainRender>("/CocoStudio/Ide/Render", false);
    }

    public static Widget CreateMainMenu()
    {
      return MainWindowPartFactory.GetExtensionPart<Widget>("/CocoStudio/Ide/MainMenuBar", true);
    }

    private static T GetExtensionPart<T>(string extensionPath, bool isCache = true) where T : class
    {
      object[] extensionObjects = AddinManager.GetExtensionObjects(extensionPath, isCache);
      if (extensionObjects == null || extensionObjects.Length <= 0)
        return default (T);
      return extensionObjects[0] as T;
    }
  }
}
