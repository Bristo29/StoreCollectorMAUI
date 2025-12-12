using System.Collections.ObjectModel;
using System.Windows.Input;
using StoreCollector.Maui.Models;
using StoreCollector.Maui.Services;
using StoreCollector.Maui.Views;

namespace StoreCollector.Maui.ViewModels
{
    public class ProductosViewModel : BaseViewModel
    {
        private readonly ProductoService _service;

        public ObservableCollection<Producto> Productos { get; private set; }
        public ICommand CargarProductosCommand { get; }
        public ICommand NuevoProductoCommand { get; }

        public ProductosViewModel()
        {
            _service = new ProductoService();
            Productos = new ObservableCollection<Producto>();

            CargarProductosCommand = new Command(async () => await CargarProductos());
            NuevoProductoCommand = new Command(async () => await IrANuevoProducto());
        }

        private async Task CargarProductos()
        {
            IsBusy = true;

            try
            {
                Productos.Clear();
                var lista = await _service.GetProductos();

                if (lista != null)
                {
                    foreach (var p in lista)
                        Productos.Add(p);
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task IrANuevoProducto()
        {
            await Shell.Current.GoToAsync(nameof(NuevoProductoPage));
        }
    }
}
