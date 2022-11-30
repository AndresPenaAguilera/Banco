using API.Gateway.HttpMessajeHandler.Interfaces;
using API.Gateway.HttpMessajeHandler.Modelos;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;


namespace TiendaServicios.Api.Gateway.ImplementRemote
{
    public class ClienteConsulta : IClienteConsulta
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly ILogger<ClienteConsulta> _logger;

        public ClienteConsulta(IHttpClientFactory httpClient, ILogger<ClienteConsulta> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<(bool resultado, Cliente Cliente, string MensajeError)> ObtieneCliente(int id)
        {
            try
            {
                var cliente = _httpClient.CreateClient("ClienteServicio");
                var response = await cliente.GetAsync($"/Cliente/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var contenido = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var resultado = JsonSerializer.Deserialize<Cliente>(contenido, options);
                    return (true, resultado, null);
                }

                return (false, null, response.ReasonPhrase);

            }
            catch (Exception e)
            {
                _logger?.LogError(e.ToString());
                return (false, null, e.Message);
            }
        }
    }
}
