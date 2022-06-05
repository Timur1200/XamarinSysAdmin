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
    public partial class SpecOrderPage : ContentPage
    {
        public SpecOrderPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            LView.ItemsSource = RequestsAPI.get().SelectQuireSpec();
        }
       async private void LView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            OrderSpecDetalPage.quire = LView.SelectedItem as Quire;

            await Shell.Current.GoToAsync(nameof(OrderSpecDetalPage));
        }
    }
}