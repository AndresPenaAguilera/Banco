using Microsoft.Extensions.Logging;
using Movimientos.Interfaces.Aplicacion;
using Movimientos.Modelos.Mensajes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Movimientos.Aplicacion.ConsultasExternas
{
    public class ConsultaClientes : IConsultaClientes
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly ILogger<ConsultaClientes> _logger;

        public ConsultaClientes(IHttpClientFactory httpClient, ILogger<ConsultaClientes> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<(bool resultado, DatosCliente Cliente, string MensajeError)> ObtieneCliente(int id)
        {
            try
            {
                var clienteHTTP = _httpClient.CreateClient("Clientes");
                var response = await clienteHTTP.GetAsync($"api/CreadorClientes/{ id }");
                if (response.IsSuccessStatusCode)
                {
                    var contenido = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var resultado = JsonSerializer.Deserialize<DatosCliente>(contenido, options);
                    return (true, resultado, null);
                }

                return (false, null, response.ReasonPhrase);
            }
            catch(Exception e)
            {
                _logger?.LogError(e.ToString());
                return (false, null, e.Message);
            }
        }
    }
}
