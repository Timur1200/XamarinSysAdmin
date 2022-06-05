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
    public partial class OrderSpecDetalPage : ContentPage
    {
        public static Quire quire { get; set; }
        public OrderSpecDetalPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            BindingContext = quire;
            LViewPhoto.ItemsSource = RequestsAPI.get().SelectMaterialList();
        }

       async private void AddMaterial(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(StorageListPage));
        }
        MaterialList _materialList { get; set; }
        private async void LViewPhoto_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
             _materialList = (LViewPhoto.SelectedItem as MaterialList);
           
        }

      async private void SaveClick(object sender, EventArgs e)
        {
            bool ready = await DisplayAlert("Внимание!","Вы действительно хотите отправить? Потом внести изменения не получится ","Да","Нет");

            if (ready)
            {
                RequestsAPI.get().UpdateQuire(quire, AnsEntry.Text);
               await DisplayAlert("Уведомление","Данные были успешно отправлены","ок");
                await Shell.Current.GoToAsync("..");
            }

            else
            {
                await DisplayAlert("Уведомление","Действие отменено","ок");
            }
        }

        private void DelMaterialClicked(object sender, EventArgs e)
        {
            RequestsAPI.get().DeleteMaterialList(_materialList);
            LViewPhoto.ItemsSource = RequestsAPI.get().SelectMaterialList();
        }
    }
}