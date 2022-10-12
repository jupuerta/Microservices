using Lil.Clientes.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Lil.Clientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController:ControllerBase
    {
        private readonly IClientesProvider clientesRepository;
        public ClientesController(IClientesProvider clientesRepository)
        {
            this.clientesRepository = clientesRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(string id)
        {
            var cliente = await clientesRepository.GetAsync(id);

            if (cliente != null) { return Ok(cliente); }

            return NotFound();
        }
    }
}
