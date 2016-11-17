using CocoStudio.EngineAdapterWrap;
using System;
using System.ComponentModel;

namespace CocoStudio.Model.ViewModel
{
	[DisplayName("Display_Component_Primitive")]
	public class PrimitiveObject : NodeObject
	{
		protected override void CreateCSObject()
		{
			this.innerNode = new CSPrimitive();
		}

		private CSPrimitive GetCom()
		{
			return this.GetCSVisual() as CSPrimitive;
		}

		public void AddASBox(string boxName, float width, float height, float centerX, float centerY)
		{
			this.GetCom().AddASBox(boxName, width, height, centerX, centerY);
		}

		public void ResetBoxSize(string boxName, float width, float height, float centerX, float centerY)
		{
			this.GetCom().ResetBoxSize(boxName, width, height, centerX, centerY);
		}

		public void SetVisible(bool isVisible)
		{
			this.GetCom().SetVisible(isVisible);
		}

		public override object Clone()
		{
			return new PrimitiveObject
			{
				Name = this.Name
			};
		}
	}
}
