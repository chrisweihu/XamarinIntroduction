using System;
using Xamarin.Forms;

namespace XamarinIntro.Effects
{
	public class ShadowEffect : RoutingEffect
	{
		public double Radius { set; get; }
		public double XOffset { set; get; }
		public double YOffset { set; get; }

		public static readonly BindableProperty ColorProperty = BindableProperty.CreateAttached("Color",
																								typeof(Color),
																								typeof(ShadowEffect),
																								Color.Black);

		public static Color GetColor(Xamarin.Forms.VisualElement view) { return (Color)view.GetValue(ColorProperty); }
		public static void SetColor(Xamarin.Forms.VisualElement view, Color color) { view.SetValue(ColorProperty, color); }

		public ShadowEffect() : base("Xamarin.ShadowEffect")
		{

		}
	}
}