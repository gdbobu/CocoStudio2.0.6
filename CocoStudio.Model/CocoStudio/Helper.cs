using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace CocoStudio
{
	public static class Helper
	{
		public static void ForEach<T>(this IEnumerable<T> items, Action<T> action)
		{
			foreach (T current in items)
			{
				action(current);
			}
		}

		public static void ForEachWithTypeMatch<T, R>(this IEnumerable<T> items, Action<R> action) where R : class
		{
			foreach (T current in items)
			{
				R r = current as R;
				if (r != null)
				{
					action(r);
				}
			}
		}

		public static void RemoveAllItem<T>(this IList<T> items)
		{
			if (items != null)
			{
				int num = items.Count<T>();
				if (num > 0)
				{
					for (int i = num - 1; i >= 0; i--)
					{
						items.RemoveAt(i);
					}
				}
			}
		}

		public static void Copy(this DirectoryInfo dirInfo, string targetDirName, FileAttributes attributes = FileAttributes.Normal)
		{
			try
			{
				if (!Directory.Exists(targetDirName))
				{
					Directory.CreateDirectory(targetDirName);
				}
				DirectoryInfo directoryInfo = new DirectoryInfo(targetDirName);
				directoryInfo.Attributes = attributes;
				string[] directories = Directory.GetDirectories(dirInfo.FullName);
				FileInfo[] files = dirInfo.GetFiles();
				if (directories.Length > 0)
				{
					string[] array = directories;
					for (int i = 0; i < array.Length; i++)
					{
						string path = array[i];
						DirectoryInfo directoryInfo2 = new DirectoryInfo(path);
						FileAttributes attributes2 = directoryInfo2.Attributes;
						string targetDirName2 = Path.Combine(targetDirName, directoryInfo2.Name);
						directoryInfo2.Copy(targetDirName2, attributes2);
					}
				}
				if (files.Length > 0)
				{
					FileInfo[] array2 = files;
					for (int i = 0; i < array2.Length; i++)
					{
						FileInfo fileInfo = array2[i];
						string destFileName = Path.Combine(targetDirName, fileInfo.Name);
						fileInfo.CopyTo(destFileName, true);
					}
				}
			}
			catch (Exception var_9_EF)
			{
			}
		}

		public static void KillProc(string strProcName)
		{
			try
			{
				Process[] processesByName = Process.GetProcessesByName(strProcName);
				for (int i = 0; i < processesByName.Length; i++)
				{
					Process process = processesByName[i];
					if (!process.CloseMainWindow())
					{
						process.Kill();
					}
				}
			}
			catch
			{
			}
		}
	}
}
