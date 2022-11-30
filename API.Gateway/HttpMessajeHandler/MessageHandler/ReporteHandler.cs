using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Threading;
using API.Gateway.HttpMessajeHandler.Interfaces;
using API.Gateway.HttpMessajeHandler.Modelos;
using System.Collections.Generic;
using System.Globalization;

namespace API.Gateway.HttpMessajeHandler.MessageHandler
{
   
    public class ReporteHandler : DelegatingHandler
    {
        private readonly ILogger<ReporteHandler> _logger;
        private readonly IClienteConsulta _clienteConsulta;
        private readonly ICuentaConsulta _cuentaConsulta;

        public ReporteHandler(ILogger<ReporteHandler> logger, IClienteConsulta clienteConsulta, ICuentaConsulta cuentaConsulta)
        {
            _logger = logger;
            _clienteConsulta = clienteConsulta;
            _cuentaConsulta = cuentaConsulta;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {

            var tiempo = Stopwatch.StartNew();

            _logger.LogInformation("Inicia el request");

            var response = await base.SendAsync(request, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                var contenido = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var resultado = JsonSerializer.Deserialize<ReporteMovimientosDatos>(contenido, options);

                var responseCliente = await _clienteConsulta.ObtieneCliente(resultado.idCliente);
               
                string nombre = string.Empty;

                if(responseCliente.resultado)
                {
                    nombre = responseCliente.Cliente.Nombre;
                }

                List<ReporteMovimientos> reporteMovimientos = new List<ReporteMovimientos>();
                decimal saldoInicial = 0;
                decimal saldoDiponible = 0;
                foreach (var movimiento in resultado.movimientos)
                {
                    saldoInicial = saldoDiponible;
                    var responseCuenta = await _cuentaConsulta.ObtieneCuenta(movimiento.IdCuenta);

                    if (responseCuenta.resultado)
                    {
                        var cuenta = responseCuenta.cuenta;

                        saldoDiponible = (saldoInicial + movimiento.Valor);

                        var movimientoReporte = new ReporteMovimientos()
                        {
                            Fecha = movimiento.Fecha.ToString("dd/MM/yyyy"),
                            Nombre = nombre,
                            NumeroCuenta = cuenta.Numero.ToString(),
                            Tipo = cuenta.Tipo == 'A' ? "Ahorros":"Corriente",
                            SaldoInicial = "",
                            Estado = cuenta.Estado.ToString(),
                            Movimiento = String.Format(CultureInfo.InvariantCulture, "{0:0,0.0}", movimiento.Valor),
                            SaldoDisponible = saldoDiponible.ToString()
                    };

                        reporteMovimientos.Add(movimientoReporte);

                    }
                }

                var resultadoStr = JsonSerializer.Serialize(reporteMovimientos);
                response.Content = new StringContent(resultadoStr, System.Text.Encoding.UTF8, "application/json");
            }

            _logger.LogInformation($"Este proceso se ejecuto en: {tiempo.ElapsedMilliseconds}ms");

            return response;
        }
    }
}
