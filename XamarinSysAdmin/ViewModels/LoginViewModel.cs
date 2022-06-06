using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamarinSysAdmin.Models;
using XamarinSysAdmin.Services;
using XamarinSysAdmin.Views;

namespace XamarinSysAdmin.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        private string login;
        private string pass;
        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
        }

        public string Login
        {
            get => login;
            set => SetProperty(ref login, value);
        }
        public string Pass
        {
            get => pass;
            set => SetProperty(ref pass, value);
        }

        private async void OnLoginClicked(object obj)
        {
            try { 
            {
                foreach (var user in RequestsAPI.get().SelectUsers())
                {
                    if (login == user.Login && pass == user.Pass)
                    {
                            Personal.Auth(user);
                            
                        await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
                        Pass = "";
                        return;
                    }
                }
                foreach (var user in RequestsAPI.get().SelectSpec())
                {
                    if (login == user.Login && pass == user.Pass)
                    {
                            Personal.Auth(user);
                            await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
                        Pass = "";
                            
                            return;
                    }
                }
                await App.Current.MainPage.DisplayAlert("ВНИМАНИЕ!", "Неверно введен логин или пароль", $"ОК");
            } 
        }
            catch
            {
                await App.Current.MainPage.DisplayAlert("Ошибка!", "Возникли проблемы при подключении к серверу", "Ok");
            }

           
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one
            // Префикс с `//` переключает на другой стек навигации вместо нажатия на активный
            
        }
    }
}
