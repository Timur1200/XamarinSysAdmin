using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XamarinSysAdmin.Models;
using XamarinSysAdmin.ViewModels;
using XamarinSysAdmin.Views;

namespace XamarinSysAdmin
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public static AppShell aShell;
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(NewOrderPage), typeof(NewOrderPage));
            Routing.RegisterRoute(nameof(ClientOrderDetalPage), typeof(ClientOrderDetalPage));
            Routing.RegisterRoute(nameof(OrderSpecDetalPage), typeof(OrderSpecDetalPage));
            Routing.RegisterRoute(nameof(StorageListPage), typeof(StorageListPage));

            aShell = this;
            
            
        }

        private void allVisible()
        {
            aShell.AboutItem.FlyoutItemIsVisible = true;
            aShell.BrowseItem.FlyoutItemIsVisible = true;
            aShell.ClientOrderItem.FlyoutItemIsVisible = false;

            
        }
        public static void Reload()
        {

            aShell.allVisible();

            if (Personal.Session.Acc == 2)
            {
                
            }

            else if (Personal.Session.Acc == 1)
            {
             //   aShell.BrowseItem.FlyoutItemIsVisible = false;
            }

            else if (Personal.Session.Acc == 0)
            {
                aShell.ClientOrderItem.FlyoutItemIsVisible = true;
            }
            
            
        }
        
        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
