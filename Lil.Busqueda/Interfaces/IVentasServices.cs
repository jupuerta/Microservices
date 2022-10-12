using Lil.Busqueda.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lil.Busqueda.Interfaces
{
    public interface IVentasServices
    {
        Task<ICollection<Venta>> GetAsync(string clienteId);
    }
}
