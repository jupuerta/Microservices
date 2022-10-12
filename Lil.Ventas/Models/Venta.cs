using System.Collections.Generic;
using System;

namespace Lil.Ventas.Models
{
    public class Venta
    {
        public string Id { get; set; }
        public DateTime DateVenta { get; set; }
        public string ClienteId { get; set; }
        public double Total { get; set; }

        public List<ElementosVenta> Elementos { get; set; }
    }
}
