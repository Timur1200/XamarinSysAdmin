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
            LViewPhoto.ItemsSource = Data.get().SelectMaterialList();
        }

       async private void AddMaterial(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(StorageListPage));
        }

        private void LViewPhoto_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

      async private void SaveClick(object sender, EventArgs e)
        {
            bool ready = await DisplayAlert("Внимание!","Вы действительно хотите отправить? Потом внести изменения не получится ","Да","Нет");

            if (ready)
            {
                Data.get().UpdateQuire(quire, AnsEntry.Text);
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

        }
    }
}