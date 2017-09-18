using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinIntro
{
	public partial class ListViewPage : ContentPage
	{
		bool reverse;
		public ListViewPage()
		{
			InitializeComponent();
			
			////There are no explicit APIs for adding/removing ListView items, 
			////instead you modify the collection of data assigned to the ItemsSource property
			//SimpsonFactory.Characters.Add(new Person() { Name = "Mr. Burns" });
			//SimpsonFactory.Characters.RemoveAt(0);
			//SimpsonFactory.Characters[0] = new Person() { Name = "Chris Hu" };

			//This will trigger Handle_ItemSelected() event handler funciton
			//This will highlight and select the first row on ListView
			listView.SelectedItem = SimpsonFactory.Characters[0];
		}


		void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
		{
			Debug.WriteLine("ItemSelected:: " + e.SelectedItem + "  SelectedItem=" + listView.SelectedItem);
		}

		async void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
		{
			Debug.WriteLine("ItemTapped:: " + e.Item + "  SelectedItem=" + listView.SelectedItem);
			Person p = e.Item as Person;
            await this.DisplayAlert("Item Tapped",p.Name+" Says 'Hi'","Close");
		}

		void OnDelete(object sender, System.EventArgs e)
		{
			SimpsonFactory.Characters.Remove(((sender as MenuItem).CommandParameter as Person));
		}

		async void OnEdit(object sender, System.EventArgs e)
		{
			Person p = (sender as MenuItem).CommandParameter as Person;
			await this.DisplayAlert("OnEdit", p.Name + " Says 'Maybe Next Time, Buddy!'", "Close");
		}

		async void Handle_Refreshing(object sender, System.EventArgs e)
		{
			ListView lv = (ListView)sender;
			Debug.WriteLine("Refreshing:: " + sender + "  e=" + e);
			await Task.Delay(1000);
			List<Person> reversedData = (reverse ? SimpsonFactory.Characters.OrderBy(p => p.Name) : SimpsonFactory.Characters.OrderByDescending(p => p.Name)).ToList();
			SimpsonFactory.Characters.Clear();
			foreach (var p in reversedData)
			{
				SimpsonFactory.Characters.Add(p);
			}
			reverse = !reverse;
			lv.IsRefreshing = false;//Stop Refreshing Animation
		}
	}
}
