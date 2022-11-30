using API.Gateway.HttpMessajeHandler.Interfaces;
using API.Gateway.HttpMessajeHandler.Modelos;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;


namespace TiendaServicios.Api.Gateway.ImplementRemote
{
    public class CuentaConsulta : ICuentaConsulta
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly ILogger<ClienteConsulta> _logger;

        public CuentaConsulta(IHttpClientFactory httpClient, ILogger<ClienteConsulta> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<(bool resultado, Cuenta cuenta, string MensajeError)> ObtieneCuenta(int id)
        {
            try
            {
                var cliente = _httpClient.CreateClient("CuentaServicio");
                var response = await cliente.GetAsync($"/Cuenta/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var contenido = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var resultado = JsonSerializer.Deserialize<Cuenta>(contenido, options);
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
