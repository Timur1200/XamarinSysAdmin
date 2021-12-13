using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinSysAdmin.Models;

namespace XamarinSysAdmin.Views
{
    public partial class AboutPage : ContentPage
    {
         public  AboutPage()
        {
          

            InitializeComponent();
           
            

        }
        protected override void OnAppearing()
        {
            BindingContext = Personal.Session;
        }
        private async void Go()
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}