using Lil.Ventas.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lil.Ventas.DAL
{
    public interface IVentasProvider
    {
        Task<ICollection<Venta>> GetAsync(string clienteId);

    }
}
