namespace StoreCollector.Maui.Models
{
    public class DetalleVenta
    {
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }

        public Producto Producto { get; set; } // opcional para mostrar info del producto
    }
}
