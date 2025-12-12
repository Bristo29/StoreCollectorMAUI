using StoreCollector.Maui.ViewModels;

namespace StoreCollector.Maui.Views
{
    public partial class ProductosPage : ContentPage
    {
        public ProductosPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var vm = BindingContext as ProductosViewModel;
            vm?.CargarProductosCommand.Execute(null);
        }
    }
}
