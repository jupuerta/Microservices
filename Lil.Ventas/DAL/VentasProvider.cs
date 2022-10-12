using Lil.Ventas.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace Lil.Ventas.DAL
{
    public class VentasProvider:IVentasProvider
    {
        private readonly List<Venta> repo = new List<Venta>();

        public VentasProvider()
        {
            repo.Add(new Venta()
            {
                Id = "0001",
                ClienteId = "1",
                DateVenta = DateTime.Now.AddMonths(-1),
                Total = 100,
                Elementos = new List<ElementosVenta>()
                {
                    new ElementosVenta() { VentaId = "0001", Id = 1, Precio = 20, ProductoId = "2", Cantidad = 3},
                    new ElementosVenta() { VentaId = "0001", Id = 1, Precio = 50, ProductoId = "23", Cantidad = 2}
                }
            });
            repo.Add(new Venta()
            {
                Id = "0002",
                ClienteId = "2",
                DateVenta = DateTime.Now.AddMonths(-2),
                Total = 100,
                Elementos = new List<ElementosVenta>()
                {
                    new ElementosVenta() { VentaId = "0002", Id = 1, Precio = 20, ProductoId = "2", Cantidad = 3},
                    new ElementosVenta() { VentaId = "0002", Id = 2, Precio = 50, ProductoId = "4", Cantidad = 1}
                }
            });
            repo.Add(new Venta()
            {
                Id = "0003",
                ClienteId = "2",
                DateVenta = DateTime.Now.AddMonths(-3),
                Total = 100,
                Elementos = new List<ElementosVenta>()
                {
                    new ElementosVenta() { VentaId = "0003", Id = 1, Precio = 20, ProductoId = "2", Cantidad = 3},
                    new ElementosVenta() { VentaId = "0003", Id = 2, Precio = 50, ProductoId = "4", Cantidad = 1}
                }
            });
            repo.Add(new Venta()
            {
                Id = "0004",
                ClienteId = "3",
                DateVenta = DateTime.Now.AddDays(-10),
                Total = 50,
                Elementos = new List<ElementosVenta>()
                {
                    new ElementosVenta() { VentaId = "0004", Id = 1, Precio = 20, ProductoId = "2", Cantidad = 3},
                    new ElementosVenta() { VentaId = "0004", Id = 1, Precio = 50, ProductoId = "5", Cantidad = 1}
                }
            });
        }

        public Task<ICollection<Venta>> GetAsync(string clienteId)
        {
            var ventas = repo.Where(c => c.ClienteId == clienteId).ToList();
            return Task.FromResult((ICollection<Venta>)ventas);
        }
    }
}
