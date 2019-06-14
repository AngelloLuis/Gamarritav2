using GalaSoft.MvvmLight.Command;
using Gamarritav2.Views;
using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Gamarritav2.ViewModels
{
    public class MainViewModel
    {
        public ProductsViewModel Products { get; set; }

        public MainViewModel()
        {
            this.Products = new ProductsViewModel();
        }

        public ICommand AddProductCommand
        {
            get
            {
                return new RelayCommand(goToAddProduct);
            }
        }

        private async void goToAddProduct()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new ProductsPage());
        }
    }
}
