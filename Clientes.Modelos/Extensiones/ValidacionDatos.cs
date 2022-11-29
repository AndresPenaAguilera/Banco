using System;

namespace Clientes.Modelos.Extensiones
{
    public static class ValidacionDatos
    {
        public static void ExcepcionCampoVacio(this string campo, string mensajeExcepcion)
        {
            if (string.IsNullOrEmpty(campo))
                throw new Exception(mensajeExcepcion);
        }
    }
}
