using System;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("Xamarin")]
[assembly: ExportEffect(typeof(XamarinIntro.Droid.Effects.ShadowEffect), "ShadowEffect")]
namespace XamarinIntro.Droid.Effects
{
	public class ShadowEffect : PlatformEffect
	{
		float radius, distanceX, distanceY;
		protected override void OnAttached()
		{
			XamarinIntro.Effects.ShadowEffect eff = (XamarinIntro.Effects.ShadowEffect)this.Element.Effects.FirstOrDefault(e => e is XamarinIntro.Effects.ShadowEffect);
			if (eff != null)
			{
				radius = (float)eff.Radius;
				distanceX = (float)eff.XOffset;
				distanceY = (float)eff.YOffset;
				var control = Control as Android.Widget.TextView;
				Android.Graphics.Color color = XamarinIntro.Effects.ShadowEffect.GetColor((Xamarin.Forms.VisualElement)Element).ToAndroid();
				control.SetShadowLayer(radius, distanceX, distanceY, color);
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
				XamarinIntro.Effects.ShadowEffect eff = (XamarinIntro.Effects.ShadowEffect)this.Element.Effects.FirstOrDefault(e => e is XamarinIntro.Effects.ShadowEffect);
				if (eff != null)
				{
					radius = (float)eff.Radius;
					distanceX = (float)eff.XOffset;
					distanceY = (float)eff.YOffset;
					var control = Control as Android.Widget.TextView;
					Android.Graphics.Color color = XamarinIntro.Effects.ShadowEffect.GetColor((Xamarin.Forms.VisualElement)Element).ToAndroid();
					control.SetShadowLayer(radius, distanceX, distanceY, color);
				}
			}
		}
	}
}