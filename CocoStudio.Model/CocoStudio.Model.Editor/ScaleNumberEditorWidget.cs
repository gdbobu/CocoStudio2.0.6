using CocoStudio.ToolKit;
using System;

namespace CocoStudio.Model.Editor
{
	public class ScaleNumberEditorWidget : NumberEditorWidget
	{
		public event EventHandler<PointEvent> ImageStatusChanged;

		public ScaleNumberEditorWidget(bool showImage = false) : base(showImage, false, 30)
		{
			this.PointImage.ImageStatusChanged += new EventHandler<PointEvent>(this.PointImage_ImageStatusChanged);
		}

		private void PointImage_ImageStatusChanged(object sender, PointEvent e)
		{
			if (this.ImageStatusChanged != null)
			{
				this.ImageStatusChanged(sender, e);
			}
		}

		public void SetImageStatus(bool status)
		{
			this.PointImage.SetCurrentImage(status);
		}
	}
}
