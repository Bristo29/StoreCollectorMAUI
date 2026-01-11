using StoreCollector.Maui.ViewModels;
using System.Diagnostics;

namespace StoreCollector.Maui.Views
{
    public partial class ProductosPage : ContentPage
    {
        private readonly ProductosViewModel _viewModel;

        public ProductosPage(ProductosViewModel productosViewModel)
        {
            InitializeComponent();
            _viewModel = productosViewModel;
            BindingContext = _viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Llamada asíncrona correcta
            await _viewModel.CargarProductosAsync();
        }
    }
}