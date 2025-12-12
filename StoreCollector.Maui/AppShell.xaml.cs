using StoreCollector.Maui.Views;

namespace StoreCollector.Maui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(NuevoProductoPage), typeof(NuevoProductoPage));
            Routing.RegisterRoute(nameof(ProductosPage), typeof(ProductosPage));
        }
    }
}
