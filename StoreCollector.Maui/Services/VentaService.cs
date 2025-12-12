using StoreCollector.Maui.Models;

namespace StoreCollector.Maui.Services
{
    public class VentaService
    {
        private readonly ApiService _api;

        public VentaService()
        {
            _api = new ApiService();
        }

        public Task<List<Venta>> ObtenerVentas()
        {
            return _api.GetAsync<List<Venta>>("/api/ventas");
        }

        public Task<Venta> RegistrarVenta(List<DetalleVenta> detalles)
        {
            var dto = new
            {
                productos = detalles.Select(d => new {
                    productoId = d.ProductoId,
                    cantidad = d.Cantidad
                }).ToList()
            };

            return _api.PostAsync<object, Venta>("/api/ventas", dto);
        }
    }
}
