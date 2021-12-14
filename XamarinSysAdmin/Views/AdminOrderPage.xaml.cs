using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinSysAdmin.Models;
using XamarinSysAdmin.Services;

namespace XamarinSysAdmin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminOrderPage : ContentPage
    {
        public AdminOrderPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            LView.ItemsSource = Data.get().SelectQuireAdmin();
        }

       async private void LView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            AdminOrderDetalPage._quire = LView.SelectedItem as Quire;
            await Shell.Current.GoToAsync(nameof(AdminOrderDetalPage));
        }
    }
}