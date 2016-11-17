using CocoStudio.EngineAdapterWrap;
using System;

namespace CocoStudio.Model.ViewModel
{
	public class SceneObject : VisualObject
	{
		private CSScene csSceneEntity;

		internal SceneObject(CSScene entity)
		{
			this.csSceneEntity = entity;
		}

		internal override CSVisualObject GetCSVisual()
		{
			return this.csSceneEntity;
		}

		public void AddChild(NodeObject cObject)
		{
			this.GetCSVisual().AddChild(cObject.GetCSVisual());
		}
	}
}
