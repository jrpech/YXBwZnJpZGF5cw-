using DemoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoAPI.Rules
{
    public class UsuarioVR
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

        public bool Insertar(Usuario oUsuario)
        {
            _mensajes.Clear();
            if (string.IsNullOrEmpty(oUsuario.Codigo)) _mensajes.Add("Ingrese el código");
            if (string.IsNullOrEmpty(oUsuario.Correo)) _mensajes.Add("Ingrese el correo");
            if (oUsuario.FechaNacimiento < new DateTime(1600, 01, 01)) _mensajes.Add("Ingrese la fechad de nacimiento");
            if (string.IsNullOrEmpty(oUsuario.Nombre)) _mensajes.Add("Ingrese el nombre");
            if (string.IsNullOrEmpty(oUsuario.Password)) _mensajes.Add("Ingrese la contraseña");
            if (string.IsNullOrEmpty(oUsuario.Tipo)) _mensajes.Add("Ingrese el tipo de usuario");
            if (string.IsNullOrEmpty(oUsuario.TipoLogin)) _mensajes.Add("Ingrese el tipo de login");
            return _mensajes.Count() == 0;
        }
    }
}