using DemoAPI.Models;
using Eupa.net.Core.Clases;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoAPI.Repository
{
    public class UsuarioRepository : RepositoryBase<Usuario>
    {
        public UsuarioRepository()
        {

        }

        public bool Accesar(string usuario, string contrasenia)
        {
            _exito = false;
            _mensajes = new List<string>();
            _errores = new List<string>();
            try
            {
                var user = _session.Query<Usuario>().FirstOrDefault(a => a.Correo.ToLower() == usuario.ToLower() && a.Password.Equals(contrasenia));
                if (user == null) _mensajes.Add("El usuario y/o contraseña es incorrecto");
                else _exito = true;
            }
            catch (Exception ex)
            {
                while (ex != null)
                {
                    _errores.Add(ex.Message);
                    ex = ex.InnerException;
                }
                _mensajes.Add("Ocurrio un problema al realizar la operación solicitada.");
            }

            return _exito;
        }

        public override Usuario GetById(object id)
        {
            _exito = false;
            _errores = new List<string>();
            _mensajes = new List<string>();
            Usuario Entidad = null;
            try
            {
                Entidad = _session.Get<Usuario>(id);
                _exito = true;
            }
            catch (Exception ex)
            {
                while (ex != null)
                {
                    _errores.Add(ex.Message);
                    ex = ex.InnerException;
                }
                _mensajes.Add("Ocurrio un problema al realizar la operación solicitada.");
            }
            return Entidad;
        }
    }
}