using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace XamarinIntro
{
    public partial class StylePage : ContentPage
    {
        bool originalStyle = true;

        public StylePage()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, EventArgs e)
        {
			if (originalStyle)
			{
				Resources["Button_Style"] = Resources["Button_Style_2"];
				originalStyle = false;
			}
			else
			{
				Resources["Button_Style"] = Resources["Button_Style_1"];
				originalStyle = true;
			}
        }
    }
}
