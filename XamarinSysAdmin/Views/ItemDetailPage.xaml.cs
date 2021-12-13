using System.ComponentModel;
using Xamarin.Forms;
using XamarinSysAdmin.ViewModels;

namespace XamarinSysAdmin.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}