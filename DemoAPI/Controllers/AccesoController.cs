using DemoAPI.Models;
using DemoAPI.Repository;
using Newtonsoft.Json;
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
        public IHttpActionResult GuardarUsuario(Usuario oUsuario)
        {
            if (!rUsuario.Save(oUsuario))
            {
                return Json(new { StatusCode = "error", ResponseMessage = Funciones.FormatoMensajes(rUsuario.Mensajes) });
            }

            return Ok(oUsuario);
        }

        [HttpPost]
        [Route("acceso/membresia/{oTipoMembresia}")]
        public IHttpActionResult GuardarMembresia(TipoMembresia oTipoMembresia)
        {
            if (!rMembresia.Save(oTipoMembresia))
            {
                return Json(new { StatusCode = "error", ResponseMessage = Funciones.FormatoMensajes(rUsuario.Mensajes) });
            }

            return Ok(oTipoMembresia);
        }
    }
}
