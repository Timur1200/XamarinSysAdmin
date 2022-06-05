using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinSysAdmin.Models;
using XamarinSysAdmin.Services;

namespace XamarinSysAdmin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewOrderPage : ContentPage
    {
        public NewOrderPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            quire = new Quire();
            
            quire.Date1 =  DateTime.Now;
            quire.Status = 0;
            quire.UserId = Personal.Session.Id;
            BindingContext = quire;
            
        }

        private Quire quire;
        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(quire.Desc)
                && !String.IsNullOrWhiteSpace(quire.Theme);
        }

       async private void BackClick(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }

      async private void SaveClick(object sender, EventArgs e)
        {
            bool res = await DisplayAlert("Подтвердить действие", "Отправить запрос?", "Да", "Нет");

            if (!res)
              {
                await DisplayAlert("Уведомление","Действие отменено","ОК");
                return;
              }
           

            if (RequestsAPI.get().InsertQuire(quire))
            {
                await DisplayAlert("Успешно!", "Запрос отправлен!", "ОК");
                BackClick(null, null);
            }
            else
            {
                await DisplayAlert("Ошибка!", "Возникли ошибки при отправке данных на сервер", "ОК");
            }
            
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            
                BtnSave.IsEnabled = ValidateSave();
            
        }

        
    }
}