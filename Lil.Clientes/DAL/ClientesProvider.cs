using Lil.Clientes.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lil.Clientes.DAL
{
    public class ClientesProvider:IClientesProvider
    {
        private readonly List<Cliente> repo = new List<Cliente>();

        public ClientesProvider()
        {
            repo.Add(new Cliente() { Id = "1", Name = "Juan", City = "Logroño" });
            repo.Add(new Cliente() { Id = "2", Name = "Pablo", City = "Madrid" });
            repo.Add(new Cliente() { Id = "3", Name = "Lucas", City = "Bilbao" });
            repo.Add(new Cliente() { Id = "4", Name = "Pedro", City = "Barcelona" });
        }
        public Task<Cliente> GetAsync(string id)
        {
            var cliente = repo.FirstOrDefault(c => c.Id == id);
            return Task.FromResult(cliente);
        }
    }
}
