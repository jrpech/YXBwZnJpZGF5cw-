using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoAPI.Rules
{
    public class TipoMembresiaVR
    {
        List<string> _mensajes = new List<string>();
        public List<string> Mensajes
        {
            get
            {
                if (_mensajes == null) _mensajes = new List<string>();
                return _mensajes;
            }
        }

        public bool Insertar(TipoMembresia oTipoMembresia)
        {
            _mensajes.Clear();
            if (string.IsNullOrEmpty(oTipoMembresia.Color)) _mensajes.Add("Ingrese el color");
            if (string.IsNullOrEmpty(oTipoMembresia.Nombre)) _mensajes.Add("Ingrese le nombre");
            if (oTipoMembresia.NumeroDeVisiatas == 0) _mensajes.Add("Ingrese el número de visitas");
            return _mensajes.Count() == 0;
        }
    }
}