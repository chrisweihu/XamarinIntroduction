using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinIntro
{
	public partial class EffectsPage : ContentPage
	{
		int ran = 0;
		Effect eff;
		public EffectsPage()
		{
			InitializeComponent();
            //Add effect dynamically
			eff = Effect.Resolve("XamarinIntro.ShadowEffect");
			txt.Effects.Add(eff);

			txt_rout.Effects.Add(new XamarinIntro.Effects.ShadowEffect() { XOffset = 0, YOffset = -10, Radius = 5 });
			XamarinIntro.Effects.ShadowEffect.SetColor(txt_rout, Color.Green);

			btn.Clicked += (sender, e) => {
				Color c = ++ran % 2 == 1 ? Color.Red : Color.Blue;
				XamarinIntro.Effects.ShadowEffect.SetColor(txt_rout, c);
				XamarinIntro.Effects.ShadowEffect.SetColor(txt_rout_xaml, c);
				XamarinIntro.Effects.ShadowEffect.SetColor(btn, c);
			};
		}
	}
}
