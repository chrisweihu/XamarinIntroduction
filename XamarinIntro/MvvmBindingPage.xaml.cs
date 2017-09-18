using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XamarinIntro.ViewModels;

namespace XamarinIntro
{
    public partial class MvvmBindingPage : ContentPage
    {
        public MvvmBindingPage()
        {
            InitializeComponent();

            this.BindingContext = new SimpleViewModel(){
                Title="Data Binding & MVVM",
                UserName="Chris Hu"
            };
        }
    }
}
