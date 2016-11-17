using CocoStudio.Model.ViewModel;
using System;

namespace CocoStudio.Model.Interface
{
	public interface IRenderUC
	{
		VisualObject RootVisualObject
		{
			get;
			set;
		}

		GameWindow GameWindow
		{
			get;
		}

		IInputDispatch InputDispatch
		{
			get;
		}

		bool ShowAnimationModeTip
		{
			get;
			set;
		}

		CanvasObject GetCanvasGameObject();

		SceneObject GetSceneGameObject();

		PointF ConvertControlToScene(PointF screenPoint);

		PointF ConvertSceneToControl(PointF scenePoint);

		PointF ConvertScreenToScene(PointF screenPoint);

		VisualObject GetHitVisualObject(PointF scenePoint);

		void MoveCanvasToCenter();
	}
}
