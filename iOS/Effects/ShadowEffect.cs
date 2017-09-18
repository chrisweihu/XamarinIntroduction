using System;
using System.ComponentModel;
using System.Linq;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("Xamarin")]
[assembly: ExportEffect(typeof(XamarinIntro.iOS.Effects.ShadowEffect), "ShadowEffect")]
namespace XamarinIntro.iOS.Effects
{
	public class ShadowEffect : PlatformEffect
	{
		protected override void OnAttached()
		{
			XamarinIntro.Effects.ShadowEffect eff = (XamarinIntro.Effects.ShadowEffect)this.Element.Effects.FirstOrDefault(e => e is XamarinIntro.Effects.ShadowEffect);
			if (eff != null)
			{
				Control.Layer.ShadowRadius = (nfloat)eff.Radius;
				Control.Layer.ShadowColor = XamarinIntro.Effects.ShadowEffect.GetColor((Xamarin.Forms.VisualElement)Element).ToCGColor();
				Control.Layer.ShadowOffset = new CoreGraphics.CGSize(eff.XOffset, eff.YOffset);
				Control.Layer.ShadowOpacity = 1.0f;
			}
		}

		protected override void OnDetached()
		{

		}

		protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
		{
			base.OnElementPropertyChanged(args);
			System.Diagnostics.Debug.WriteLine(args.PropertyName);
			if (args.PropertyName == XamarinIntro.Effects.ShadowEffect.ColorProperty.PropertyName)
			{
				Control.Layer.ShadowColor = XamarinIntro.Effects.ShadowEffect.GetColor((Xamarin.Forms.VisualElement)Element).ToCGColor();
			}
		}
	}
}