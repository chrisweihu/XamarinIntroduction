using System;

using Xamarin.Forms;

namespace XamarinIntro
{
    public class MainMasterDetailPage : MasterDetailPage,IDisposable
    {
        Color DarkBlue = Color.FromHex("#073975");
        ListView listView;
		public MainMasterDetailPage()
		{
			// Assemble an array of NamedColor objects.
            string[] screens =
			{
                "Home",
				"UI Views",
                "Style, Static/DynamicResource",
                "Data Binding & MVVM",
                "Effect",
                "Custom Renderer",
                "ListView"
            };

			// Create ListView for the master page.
			listView = new ListView
			{
				ItemsSource = screens,
                SeparatorVisibility = SeparatorVisibility.None,
                BackgroundColor = DarkBlue
			};

			Label header = new Label
			{
				Text = "Menu Bar",
				TextColor = Color.White,
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
				HorizontalOptions = LayoutOptions.Center,
                HeightRequest = 70,
                VerticalTextAlignment = TextAlignment.End
			};

			// Create the master page with the ListView.
			this.Master = new ContentPage
			{
                Icon = "hamburger.png",
				Title = header.Text,
				Content = new StackLayout
				{
					Children =
					{
						header,
						listView
					}
				},
                BackgroundColor = DarkBlue
			};

			// Create the detail page using NamedColorPage and wrap it in a
			// navigation page to provide a NavigationBar and Toggle button
			this.Detail = new NavigationPage(new WelcomePage())
            {
                BarBackgroundColor = DarkBlue,
				BarTextColor = Color.White
			};

			// Define a selected handler for the ListView.
            listView.ItemSelected += ListView_ItemSelected;

			// Initialize the ListView selection.
			listView.SelectedItem = screens[0];
		}

        async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
			// Set the BindingContext of the detail page.
			this.IsPresented = false;
			switch ((string)e.SelectedItem)
			{
				case "Home":
					if ((this.Detail as NavigationPage).CurrentPage.GetType() == typeof(WelcomePage))
                        break;
					await (this.Detail as NavigationPage).PopAsync(false);
					await (this.Detail as NavigationPage).PushAsync(new WelcomePage());
					break;
				case "UI Views":
                    await (this.Detail as NavigationPage).PopAsync(false);
                    await (this.Detail as NavigationPage).PushAsync(new XamarinIntroPage());
					break;
				case "Style, Static/DynamicResource":
					await (this.Detail as NavigationPage).PopAsync(false);
                    await (this.Detail as NavigationPage).PushAsync(new StylePage());
					break;

				case "Data Binding & MVVM":
					await (this.Detail as NavigationPage).PopAsync(false);
                    await (this.Detail as NavigationPage).PushAsync(new MvvmBindingPage());
					break;
				case "Effect":
					await (this.Detail as NavigationPage).PopAsync(false);
                    await (this.Detail as NavigationPage).PushAsync(new EffectsPage());
					break;
				case "Custom Renderer":
                    await this.Navigation.PushModalAsync(new NavigationPage(new CustomRenderersPage())
                    {
                        BarBackgroundColor = DarkBlue,
                        BarTextColor = Color.White
                    });

					break;
				case "ListView":
					await (this.Detail as NavigationPage).PopAsync(false);
                    await (this.Detail as NavigationPage).PushAsync(new ListViewPage());
					break;
				default:
					break;
			}
        }

		public void Dispose()
		{
			listView.ItemSelected -= ListView_ItemSelected;
		}
    }
}

