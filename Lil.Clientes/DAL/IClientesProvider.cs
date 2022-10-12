using Lil.Clientes.Models;
using System.Threading.Tasks;

namespace Lil.Clientes.DAL
{
    public interface IClientesProvider
    {
        Task<Cliente> GetAsync(string id);
    }
}
