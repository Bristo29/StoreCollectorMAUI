using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using StoreCollector.Maui.Models;
using StoreCollector.Maui.Services;
using StoreCollector.Maui.Views;

namespace StoreCollector.Maui.ViewModels
{
    public class ProductosViewModel : BaseViewModel
    {
        private readonly ProductoService _service;

        public ObservableCollection<Producto> Productos { get; set; }
        public ICommand CargarProductosCommand { get; }
        public ICommand NuevoProductoCommand { get; }

        public ProductosViewModel(ProductoService productoService)
        {
            _service = productoService;
            Productos = new ObservableCollection<Producto>();

            // Los commands siguen siendo necesarios para el RefreshView y otros bindings
            CargarProductosCommand = new Command(async () => await CargarProductosAsync());
            NuevoProductoCommand = new Command(async () => await IrANuevoProducto());

            Debug.WriteLine("✅ ProductosViewModel creado correctamente");
        }

        // ✅ Método público async para llamar desde el code-behind
        public async Task CargarProductosAsync()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Debug.WriteLine("=== INICIANDO CARGA DE PRODUCTOS ===");

                Productos.Clear();

                var lista = await _service.GetProductos();

                Debug.WriteLine($"📦 Productos recibidos del servicio: {lista?.Count ?? 0}");

                if (lista != null && lista.Any())
                {
                    foreach (var p in lista)
                    {
                        Debug.WriteLine($"  ➜ Agregando: ID={p.Id}, Nombre={p.Nombre}, Precio={p.Precio}, Stock={p.Stock}");
                        Productos.Add(p);
                    }

                    Debug.WriteLine($"✅ Total en ObservableCollection: {Productos.Count}");
                }
                else
                {
                    Debug.WriteLine("⚠️ La lista está vacía o es null");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"❌ ERROR al cargar productos: {ex.Message}");
                Debug.WriteLine($"StackTrace: {ex.StackTrace}");

                await Application.Current.MainPage.DisplayAlert("Error",
                    $"No se pudieron cargar los productos: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
                Debug.WriteLine($"IsBusy cambiado a: {IsBusy}");
            }
        }

        private async Task IrANuevoProducto()
        {
            await Shell.Current.GoToAsync(nameof(NuevoProductoPage));
        }
    }
}