using Lil.Busqueda.Interfaces;
using Lil.Busqueda.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lil.Busqueda.Services
{
    public class VentaServices:IVentasServices
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public VentaServices(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ICollection<Venta>> GetAsync(string clienteId)
        {
            var clienteHttp = _httpClientFactory.CreateClient("ventaService");
            var respuesta = await clienteHttp.GetAsync($"api/ventas/{clienteId}");
            if (respuesta.IsSuccessStatusCode)
            {
                var content = await respuesta.Content.ReadAsStringAsync();
                var ventas = JsonConvert.DeserializeObject<ICollection<Venta>>(content);
                return ventas;
            }
            return null;
        }
    }
}
