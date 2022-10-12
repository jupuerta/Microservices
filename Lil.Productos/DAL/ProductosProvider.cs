using Lil.Productos.Models;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using System.Linq;

namespace Lil.Productos.DAL
{
    public class ProductosProvider : IProductosProvider
    {
        private List<Producto> repo = new List<Producto>();

        public ProductosProvider()
        {
            for (int i = 0; i < 100; i++)
            {
                repo.Add(new Producto()
                {
                    Id = (i + 1).ToString(),
                    Nombre = $"Producto {i + 1}",
                    Precio = (double)i * Math.PI
                });
            }
        }
        public Task<Producto> GetAsync(string id)
        {
            var product = repo.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(product);
        }
    }
}
