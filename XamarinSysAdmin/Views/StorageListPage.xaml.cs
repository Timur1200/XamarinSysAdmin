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
    public partial class StorageListPage : ContentPage
    {
        public StorageListPage()
        {
            InitializeComponent();
        }

        private MaterialList _materialList;

        protected override void OnAppearing()
        {
            LViewPhoto.ItemsSource = Data.get().SelectStorage();
            _materialList = new MaterialList();
        }

        private void SelectNull()
        {
            LViewPhoto.SelectedItem = null;
            _materialList = new MaterialList();
            return;
        }

       async private void LViewPhoto_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (LViewPhoto.SelectedItem == null) return;

            string result = await DisplayPromptAsync("_", "Введите число использованных материалов");
            int i;
            bool intParse = int.TryParse(result, out i);
           if (!intParse)
            {
                await DisplayAlert("Ошибка!","Введено некорректное число.Повторите попытку!","Ок");
                SelectNull();
                return;
            }
            
            Storage storage = LViewPhoto.SelectedItem as Storage;
            if (storage.Amount < i)
            {
                await DisplayAlert("Ошибка!", "На складе не хватает материалов!", $"Ок") ;
                SelectNull();
                return;
            }
            _materialList.AmountInList = i;
            _materialList.ReqId = OrderSpecDetalPage.quire.IdQuire;
            _materialList.MaterId = storage.IdMaterial;

           if (Data.get().InsertMaterialList(_materialList))
            {

                Data.get().UpdateStorage(storage, i);
                await Shell.Current.GoToAsync("..");
            }
            else
            {
                await DisplayAlert("Ошибка!", "Возникла ошибка!", $"Ок");
                SelectNull();
                return;
               
            }



        }
    }
}