using StoreCollector.Maui.Models;

namespace StoreCollector.Maui.Services
{
    public class ProductoService
    {
        private readonly ApiService _api;

        public ProductoService(ApiService api)
        {
            _api = api;
        }


        public Task<List<Producto>> GetProductos()
        {
            return _api.GetAsync<List<Producto>>("/api/productos");
        }

        public Task<Producto> GetProducto(int id)
        {
            return _api.GetAsync<Producto>($"/api/productos/{id}");
        }

        public Task<Producto> CrearProducto(ProductoDTO dto)
        {
            return _api.PostAsync<ProductoDTO, Producto>("/api/productos", dto);
        }

        public Task ActualizarProducto(int id, ProductoDTO dto)
        {
            return _api.PutAsync($"/api/productos/{id}", dto);
        }

        public Task BorrarProducto(int id)
        {
            return _api.DeleteAsync($"/api/productos/{id}");
        }
    }
}
