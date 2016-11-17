using CocoStudio.Core;
using CocoStudio.EngineAdapterWrap;
using CocoStudio.Model.Window;
using Gdk;
using System;

namespace CocoStudio.Model.ViewModel
{
	public class GameWindow : IDisposable, IService
	{
		private CSWindow csWindow;

		private CanvasObject canvasEntity;

		private SceneObject sceneEntity;

		public GameWindow(Window gdkWindow)
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

		public void UpdateOpenGLContext(bool isShowing, Window window)
		{
			WindowHelp.UpdateOpenGLContext(isShowing, this.csWindow, window);
		}
	}
}
