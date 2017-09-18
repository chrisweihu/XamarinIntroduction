using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinIntro
{
	public partial class CustomRenderersPage : ContentPage
	{
		public CustomRenderersPage()
		{
			InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, true);

			ToolbarItems.Add(new ToolbarItem("Random Color", null, OnColorClicked));
            ToolbarItems.Add(new ToolbarItem("Close", null, OnCloseClicked));
		}

		void OnColorClicked()
		{
			sketchView.InkColor = GetRandomColor();
		}
		void OnCloseClicked()
		{
            this.Navigation.PopModalAsync();
		}

		Random rand = new Random();
		Color GetRandomColor()
		{
			return new Color(rand.NextDouble(), rand.NextDouble(), rand.NextDouble());
		}
	}
}
