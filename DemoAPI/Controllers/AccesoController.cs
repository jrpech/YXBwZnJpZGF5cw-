using DemoAPI.Models;
using DemoAPI.Repository;
using DemoAPI.Rules;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoAPI.Controllers
{
    public class AccesoController : ApiController
    {
        #region Varibales
        UsuarioRepository _ruser;
        UsuarioRepository rUsuario
        {
            get
            {
                if (_ruser == null) _ruser = new UsuarioRepository();
                return _ruser;
            }
        }
        TipoMembresiaRepository _rmemb;
        TipoMembresiaRepository rMembresia
        {
            get
            {
                if (_rmemb == null) _rmemb = new TipoMembresiaRepository();
                return _rmemb;
            }
        }
        #endregion

        [HttpGet]
        [Route("acceso/{usuario}/{password}")]
        public IHttpActionResult Acceder(string usuario, string password)
        {
            if (!rUsuario.Accesar(usuario, password))
            {
                return Json(new { StatusCode = "error", ResponseMessage = Funciones.FormatoMensajes(rUsuario.Mensajes) });
            }
            return Json(new { StatusCode = "Success", ResponseMessage = "Acceso concedido" });
        }

        [HttpGet]
        [Route("acceso/usuarios")]
        public string Usuarios()
        {
            var lsusuario = rUsuario.GetAll();
            return JsonConvert.SerializeObject(lsusuario);
        }

        [HttpGet]
        [Route("acceso/membresias")]
        public string Menbresias()
        {
            var lista = rMembresia.GetAll();
            return JsonConvert.SerializeObject(lista);
        }

        [HttpGet]
        [Route("acceso/usuario/{id}")]
        public string GetUsuario(int id)
        {
            var r = rUsuario.GetById(id);
            return JsonConvert.SerializeObject(r);
        }

        [HttpGet]
        [Route("acceso/membresia/{id}")]
        public string GetMembresia(int id)
        {
            var r = rMembresia.GetById(id);
            return JsonConvert.SerializeObject(r);
        }

        [Route("acceso/usuario")]
        public IHttpActionResult GuardarUsuario(object val)
        {
            Usuario oUsuario = null;
            if (val.GetType() == typeof(Usuario)) oUsuario = (Usuario)val;
            else if (val.GetType() == typeof(JObject))
            {
                JObject a = (JObject)val;
                var algo = a.Root.GetType();
                oUsuario = a.ToObject<Usuario>();
            }

            if (oUsuario == null) oUsuario = new Usuario();
            if (oUsuario.ID == 0) oUsuario.FechaRegistro = DateTime.Now;
            oUsuario.UltimoInicio = DateTime.Now;

            UsuarioVR vrUsaurio = new UsuarioVR();
            if (!vrUsaurio.Insertar(oUsuario))
            {
                return Json(new { StatusCode = "error", ResponseMessage = Funciones.FormatoMensajes(vrUsaurio.Mensajes) });
            }
            rUsuario._session.Clear();
            if (!rUsuario.Save(oUsuario))
            {
                return Json(new { StatusCode = "error", ResponseMessage = Funciones.FormatoMensajes(rUsuario.Mensajes) });
            }
            rUsuario._session.Flush();
            return Ok(oUsuario);
        }

        [HttpPost]
        [Route("acceso/membresia")]
        public IHttpActionResult GuardarMembresia(object val)
        {
            TipoMembresia oTipoMembresia = null;
            if (val.GetType() == typeof(TipoMembresia)) oTipoMembresia = (TipoMembresia)val;
            else if (val.GetType() == typeof(JObject))
            {
                JObject a = (JObject)val;
                var algo = a.Root.GetType();
                oTipoMembresia = a.ToObject<TipoMembresia>();
            }

            TipoMembresiaVR vrTipoMembresia = new TipoMembresiaVR();
            if (!vrTipoMembresia.Insertar(oTipoMembresia))
            {
                return Json(new { StatusCode = "error", ResponseMessage = Funciones.FormatoMensajes(vrTipoMembresia.Mensajes) });
            }

            rMembresia._session.Clear();
            if (!rMembresia.Save(oTipoMembresia))
            {
                return Json(new { StatusCode = "error", ResponseMessage = Funciones.FormatoMensajes(rMembresia.Mensajes) });
            }
            rMembresia._session.Flush();
            return Ok(oTipoMembresia);
        }
    }
}
