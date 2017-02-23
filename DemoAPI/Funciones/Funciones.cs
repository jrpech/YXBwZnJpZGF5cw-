using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoAPI
{
    public class Funciones
    {
        public static string FormatoMensajes(List<string> mensajes)
        {
            string mensaje = "";
            foreach (var m in mensajes)
            {
                mensaje += m + "<br/>";
            }
            if (!string.IsNullOrEmpty(mensaje))
            {
                mensaje = mensaje.Remove(mensaje.Length - 5, 5);
            }

            return mensaje;
        }
    }
}