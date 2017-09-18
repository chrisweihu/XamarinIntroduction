using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinIntro.iOS;

[assembly: ExportRenderer(typeof(XamarinIntro.Views.SketchView), typeof(SketchViewRenderer))]
namespace XamarinIntro.iOS
{
	class SketchViewRenderer : ViewRenderer<XamarinIntro.Views.SketchView, PaintView>
	{
		protected override void OnElementChanged(ElementChangedEventArgs<XamarinIntro.Views.SketchView> e)
		{
			base.OnElementChanged(e);

			if (Control == null)//Always check against multiple OnElementChanged(e) method invoked such as when ListView CellRenderer is used
			{
				PaintView paintView = new PaintView();
				paintView.SetInkColor(this.Element.InkColor.ToUIColor());
				paintView.LineDrawn += PaintViewLineDrawn;
				SetNativeControl(paintView);//Manually set the native control when derived from Xamarin.Forms.View

				MessagingCenter.Subscribe<Views.SketchView>(this, "Clear", OnMessageClear);
			}
		}

		void OnMessageClear(XamarinIntro.Views.SketchView sender)
		{
			if (sender == Element)
				Control.Clear();
		}

		private void PaintViewLineDrawn(object sender, System.EventArgs e)
		{
			((XamarinIntro.Views.ISketchController)Element)?.SendSketchUpdated();
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			if (e.PropertyName == XamarinIntro.Views.SketchView.InkColorProperty.PropertyName)
			{
				Control.SetInkColor(Element.InkColor.ToUIColor());
			}
		}

		protected override void Dispose(bool disposing)
		{
			MessagingCenter.Unsubscribe<XamarinIntro.Views.SketchView>(this, "Clear");
			Control.LineDrawn -= PaintViewLineDrawn;
		}
	}
}