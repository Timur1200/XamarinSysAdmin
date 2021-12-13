using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using XamarinSysAdmin.Services;
using XamarinSysAdmin.Views;

namespace XamarinSysAdmin.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "Главная";
            AuthCommand = new Command(async () => {
                try { 
               var u = Data.get().SelectSpec();
                foreach (var a in u)
                {
                    var res = await App.Current.MainPage.DisplayAlert(a.FIo, a.Login, "Ok", "Cancel");

                  /*  if (res)
                    {//logic} else {//logic}
                    }
                  */
                    await Shell.Current.GoToAsync($"//{nameof(ItemsPage)}");
                }
                }
                catch
                {
                    await App.Current.MainPage.DisplayAlert("Ошибка!", "Возникли проблемы при подключении к серверу", "Ok");
                }
        });
        }

        public ICommand AuthCommand { get; }
    }
}