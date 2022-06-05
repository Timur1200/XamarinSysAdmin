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
    public partial class ClientOrdersPage : ContentPage
    {
        public ClientOrdersPage()
        {
            InitializeComponent();
            

        }

        protected override void OnAppearing()
        {
            LView.ItemsSource = RequestsAPI.get().SelectQuire0();
        }

      async  private void LView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
            ClientOrderDetalPage.quire = LView.SelectedItem as Quire;
            await Shell.Current.GoToAsync(nameof(ClientOrderDetalPage));
        }

        async private  void  NewOrderClick(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(NewOrderPage));
        }
    }
}