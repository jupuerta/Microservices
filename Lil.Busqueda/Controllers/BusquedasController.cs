using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Lil.Busqueda.Interfaces;

namespace Lil.Busqueda.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusquedasController: ControllerBase
    {
        private readonly IClientesServices _clientesService;
        private readonly IProductosServices _productosService;
        private readonly IVentasServices _ventasService;
        public BusquedasController(IClientesServices clientesService, IProductosServices productosService, IVentasServices ventasService)
        {
            _clientesService = clientesService;
            _productosService = productosService;
            _ventasService = ventasService;
        }

        [HttpGet("clientes/{clienteId}")]
        public async Task<ActionResult> SearchAsync(string clienteId)
        {
            if (string.IsNullOrWhiteSpace(clienteId))
            {
                return BadRequest();
            }

            try
            {
                var cliente = await _clientesService.GetAsync(clienteId);

                var ventas = await _ventasService.GetAsync(clienteId);

                foreach (var venta in ventas)
                {
                    foreach (var item in venta.Elementos)
                    {
                        var product = await _productosService.GetAsync(item.ProductoId);

                        item.Producto = product;
                    }
                }

                var result = new
                {
                    Cliente = cliente,
                    Venta = ventas
                };

                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
