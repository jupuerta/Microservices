using Lil.Productos.Models;
using System.Threading.Tasks;

namespace Lil.Productos.DAL
{
    public interface IProductosProvider
    {
        Task<Producto> GetAsync(string id);
    }
}
