using Lil.Ventas.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Lil.Ventas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController: ControllerBase
    {
        private readonly IVentasProvider ventasRepository;

        public VentasController(IVentasProvider ventasRepository)
        {
            this.ventasRepository = ventasRepository;
        }

        [HttpGet("{clienteId}")]
        public async Task<IActionResult> GetAsync(string clienteId)
        {
            var ventas = await ventasRepository.GetAsync(clienteId);

            if (ventas != null && ventas.Any())
            {
                return Ok(ventas);
            }

            return NotFound();
        }
    }
}
