using StoreCollector.Maui.ViewModels;

namespace StoreCollector.Maui.Views
{
    public partial class NuevoProductoPage : ContentPage
    {
        private readonly NuevoProductoViewModel vm;

        // ✔ ÚNICO constructor válido con DI
        public NuevoProductoPage(NuevoProductoViewModel viewModel)
        {
            InitializeComponent();
            vm = viewModel;
            BindingContext = vm;
        }
    }
}
