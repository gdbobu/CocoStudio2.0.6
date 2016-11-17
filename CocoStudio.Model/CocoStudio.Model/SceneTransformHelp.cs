using CocoStudio.Model.Interface;
using System;

namespace CocoStudio.Model
{
	public class SceneTransformHelp
	{
		public static IRenderUC RenderUC
		{
			get;
			private set;
		}

		static SceneTransformHelp()
		{
		}

		public static PointF ConvertControlToScene(PointF screenPoint)
		{
			return SceneTransformHelp.RenderUC.ConvertControlToScene(screenPoint);
		}

		public static PointF ConvertSceneToControl(PointF sencePoint)
		{
			return SceneTransformHelp.RenderUC.ConvertSceneToControl(sencePoint);
		}

		public static PointF ConvertScreenToScene(PointF screenPoint)
		{
			return SceneTransformHelp.RenderUC.ConvertScreenToScene(screenPoint);
		}

		public static void SetRenderUC(IRenderUC renderUC)
		{
			SceneTransformHelp.RenderUC = renderUC;
		}
	}
}
