// Decompiled with JetBrains decompiler
// Type: CocoStudio.Model.ViewModel.GameWindow
// Assembly: CocoStudio.Model, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9A645332-034C-44D3-9062-5E94EDCB75FF
// Assembly location: C:\Program Files (x86)\Cocos\Cocos Studio 2\CocoStudio.Model.dll

using CocoStudio.Core;
using CocoStudio.EngineAdapterWrap;
using CocoStudio.Model.Window;
using System;

namespace CocoStudio.Model.ViewModel
{
  public class GameWindow : IDisposable, IService
  {
    private CSWindow csWindow;
    private CanvasObject canvasEntity;
    private SceneObject sceneEntity;

    public GameWindow(Gdk.Window gdkWindow)
    {
      this.csWindow = WindowHelp.CreateCSWindow(gdkWindow);
      this.sceneEntity = new SceneObject(this.csWindow.GetScene());
      this.canvasEntity = new CanvasObject(this.csWindow.GetCanvas());
    }

    public GameWindow(IntPtr windowHandle, int width, int height)
    {
      this.csWindow = WindowHelp.CreateCSWindow(windowHandle, width, height);
      this.sceneEntity = new SceneObject(this.csWindow.GetScene());
      this.canvasEntity = new CanvasObject(this.csWindow.GetCanvas());
    }

    public CanvasObject GetCanvasGameObject()
    {
      return this.canvasEntity;
    }

    public SceneObject GetSceneGameObject()
    {
      return this.sceneEntity;
    }

    public void Draw()
    {
      this.csWindow.Draw(0);
    }

    public void SetViewRect(int x, int y, int width, int height)
    {
      this.csWindow.SetViewRect(x, y, width, height);
    }

    public void SetResourcePath(string path)
    {
      CSCocosHelp.SetResourcePath(path);
    }

    public void Dispose()
    {
    }

    public void UpdateOpenGLContext(bool isShowing, Gdk.Window window)
    {
      WindowHelp.UpdateOpenGLContext(isShowing, this.csWindow, window);
    }
  }
}
