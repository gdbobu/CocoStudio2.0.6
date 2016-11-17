using Gdk;
using Modules.Communal.MultiLanguage;
using System;
using System.Collections.Generic;

namespace CocoStudio.Model
{
	public static class CanvasSizes
	{
		private static List<string> sizeList;

		public static Dictionary<string, string> SizeDirctionary;

		public static List<string> SizeList
		{
			get
			{
				return CanvasSizes.sizeList;
			}
		}

		static CanvasSizes()
		{
			CanvasSizes.InitSizeList();
			CanvasSizes.SizeDirctionary = new Dictionary<string, string>();
		}

		private static void InitSizeList()
		{
			CanvasSizes.sizeList = new List<string>();
			CanvasSizes.sizeList.Add("480 * 320");
			CanvasSizes.sizeList.Add("320 * 480");
			CanvasSizes.sizeList.Add("960 * 640");
			CanvasSizes.sizeList.Add("640 * 960");
			CanvasSizes.sizeList.Add("1024 * 768");
			CanvasSizes.sizeList.Add("768 * 1024");
			CanvasSizes.sizeList.Add(LanguageInfo.MainTool_itemCustomSize);
		}

		public static string FormatString(this Size size)
		{
			return string.Format("{0} * {1}", size.Width, size.Height);
		}

		public static Size ConvertToSize(this string sizeStr)
		{
			double num = Convert.ToDouble(sizeStr.Substring(0, sizeStr.IndexOf("*") - 1));
			double num2 = Convert.ToDouble(sizeStr.Substring(sizeStr.IndexOf("*") + 1));
			return new Size((int)num, (int)num2);
		}

		public static bool IsDefaultSize(string size)
		{
			return CanvasSizes.SizeList.Contains(size);
		}
	}
}
