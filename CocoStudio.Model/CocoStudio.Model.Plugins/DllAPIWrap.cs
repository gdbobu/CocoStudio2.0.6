using System;
using System.Runtime.InteropServices;

namespace CocoStudio.Model.Plugins
{
	internal static class DllAPIWrap
	{
		[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetDllDirectory(string lpPathName);

		[DllImport("kernel32.dll")]
		public static extern uint GetLastError();

		[DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
		public static extern IntPtr LoadLibrary(string lpFileName);
	}
}
