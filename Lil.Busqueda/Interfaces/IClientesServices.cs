using Lil.Busqueda.Models;
using System.Threading.Tasks;

namespace Lil.Busqueda.Interfaces
{
    public interface IClientesServices
    {
        Task<Cliente> GetAsync(string id);
    }
}
