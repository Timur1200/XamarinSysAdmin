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
    public partial class AdminOrderDetalPage : ContentPage
    {
        public AdminOrderDetalPage()
        {
            InitializeComponent();
        }
        public static Quire _quire { get; set; } 
        protected override void OnAppearing()
        {
            BindingContext = _quire;
            SpecPicker.ItemsSource = RequestsAPI.get().SelectOnlySpec();
        }

       async private void SaveClick(object sender, EventArgs e)
        {
          if (SpecPicker.SelectedItem == null)
            {
                await DisplayAlert("Ошибка","Вы не выбрали специалиста","ок");
                return;
            }
            Spec s = SpecPicker.SelectedItem as Spec;
            if (RequestsAPI.get().UpdateQuireAdmin(_quire, s))
            {
                await DisplayAlert("Успешно", "Данные были отправлены", "ок");
                await Shell.Current.GoToAsync("..");
            }
            else
            {
                await DisplayAlert("Ошибка","Возникли проблемы при отправки данных","ок");
            }
          
        }
    }
}