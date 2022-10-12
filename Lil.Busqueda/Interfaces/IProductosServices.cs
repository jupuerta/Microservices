using Lil.Busqueda.Models;
using System.Threading.Tasks;

namespace Lil.Busqueda.Interfaces
{
    public interface IProductosServices
    {
        Task<Producto> GetAsync(string id);
    }
}
