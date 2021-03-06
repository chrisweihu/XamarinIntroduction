﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace XamarinIntro.ViewModels
{
    public class SimpleViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

		string _title;
		public string Title
		{
			get { return _title; }
			set { _title = value; OnPropertyChanged("Title"); }
		}

		string _userName;
		public string UserName
		{
			get { return _userName; }
			set { _userName = value; OnPropertyChanged("UserName"); }
		}

        public ICommand ClickCommand { get; private set; }

        public SimpleViewModel()
        {
            ClickCommand = new Xamarin.Forms.Command<string>((obj) => { 
                App.Current.MainPage.DisplayAlert("ClickCommand", obj, "OK"); 
            }); 
        }
		
	}
}