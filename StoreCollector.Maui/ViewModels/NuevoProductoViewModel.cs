using System.Windows.Input;
using StoreCollector.Maui.Models;
using StoreCollector.Maui.Services;

namespace StoreCollector.Maui.ViewModels
{
    // debe ser public
    public class NuevoProductoViewModel : BindableObject
    {
        private readonly ProductoService _service;

        public NuevoProductoViewModel(ProductoService service)
        {
            _service = service;
        }

        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string Categoria { get; set; }
        public string CodigoBarras { get; set; }

        public ICommand GuardarCommand => new Command(async () =>
        {
            var dto = new ProductoDTO
            {
                Nombre = Nombre,
                Descripcion = Descripcion,
                Precio = Precio,
                Stock = Stock,
                Categoria = Categoria,
                CodigoBarras = CodigoBarras
            };

            await _service.CrearProducto(dto);

            // volver a la pagina anterior (mantiene el VM singleton en Products)
            await Shell.Current.GoToAsync("..");
        });
    }
}
