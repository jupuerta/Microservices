namespace Lil.Ventas.Models
{
    public class ElementosVenta
    {
        public string VentaId { get; set; }
        public int Id { get; set; }
        public string ProductoId { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
    }
}
