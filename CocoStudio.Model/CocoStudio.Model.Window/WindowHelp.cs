using CocoStudio.EngineAdapterWrap;
using Gdk;
using Gtk;
using System;
using Xwt.GtkBackend;

namespace CocoStudio.Model.Window
{
	internal static class WindowHelp
	{
		private static Gdk.Window gdkWindow;

		public static CSWindow CreateCSWindow(Gdk.Window gdkWindow)
		{
			CSWindow result;
			if (Platform.IsMac)
			{
				result = WindowHelp.CreateMac(gdkWindow);
			}
			else
			{
				if (!Platform.IsWindows)
				{
					throw new NotImplementedException();
				}
				result = WindowHelp.CreateWin32(gdkWindow);
			}
			return result;
		}

		public static CSWindow CreateCSWindow(IntPtr windowHandle, int width, int height)
		{
			return new CSWindow(windowHandle.ToInt32(), width, height, WindowHelp.GetStartupPath());
		}

		public static void UpdateOpenGLContext(bool isShowing, CSWindow csWindow, Gdk.Window gdkWindow)
		{
			if (Platform.IsWindows)
			{
				if (isShowing && gdkWindow != null)
				{
					bool flag = NativeGdkWin.Gdk_window_ensure_native(gdkWindow.Handle);
					csWindow.UpdateOpenGLContext(isShowing, NativeGdkWin.GetWindowHandle(gdkWindow.Handle).ToInt32());
					System.GC.Collect();
				}
			}
			else
			{
				if (!Platform.IsMac)
				{
					throw new NotImplementedException();
				}
				csWindow.UpdateOpenGLContext(isShowing, 0);
			}
		}

		private static CSWindow CreateMac(Gdk.Window window)
		{
			WindowHelp.gdkWindow = window;
			IntPtr windowHandle = NativeGdkMac.GetWindowHandle(WindowHelp.gdkWindow.Handle);
			IntPtr nSViewHandle = NativeGdkMac.GetNSViewHandle(WindowHelp.gdkWindow.Handle);
			int width;
			int height;
			WindowHelp.gdkWindow.GetSize(out width, out height);
			string startupPath = WindowHelp.GetStartupPath();
			return new CSWindow(windowHandle, nSViewHandle, width, height, startupPath);
		}

		private static CSWindow CreateWin32(Gdk.Window gdkWindow)
		{
			NativeGdkWin.Gdk_window_ensure_native(gdkWindow.Handle);
			IntPtr windowHandle = NativeGdkWin.GetWindowHandle(gdkWindow.Handle);
			int width;
			int heigth;
			gdkWindow.GetSize(out width, out heigth);
			return new CSWindow(windowHandle.ToInt32(), width, heigth, WindowHelp.GetStartupPath());
		}

		private static string GetStartupPath()
		{
			return AppDomain.CurrentDomain.BaseDirectory;
		}
	}
}
