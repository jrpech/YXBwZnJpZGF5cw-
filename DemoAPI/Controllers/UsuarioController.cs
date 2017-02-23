using DemoAPI.Models;
using DemoAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoAPI.Controllers
{
    public class UsuarioController : ApiController
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
        #endregion
        public IEnumerable<Usuario> GetAllUsuarios()
        {
            return rUsuario.GetAll();
        }

        [Route("usuario/{user}/{contrasenia}")]
        public IHttpActionResult GetAcceso(string user, string contrasenia)
        {
            if (!rUsuario.Accesar(user, contrasenia))
            {
                return Json(new { StatusCode = "error", ResponseMessage = Funciones.FormatoMensajes(rUsuario.Mensajes) });
            }
            return Ok();
        }

        [Route("usuario/{user}")]
        public IHttpActionResult GuardarUsuario(Usuario user)
        {
            user.Codigo = String.Format("{0:00000}", 1);
            user.FechaRegistro = DateTime.Now;
            user.MembresiaActual = 0;
            user.Tipo = "";
            user.TipoLogin = "";
            user.UltimoInicio = DateTime.Now;

            if (!rUsuario.Save(user))
            {
                return Json(new { StatusCode = "error", ResponseMessage = Funciones.FormatoMensajes(rUsuario.Mensajes) });
            }
            return Json(new { StatusCode = "success", ResponseMessage = "user created" });
        }

        [Route("usuario/usuarios")]
        public string GetUsuarios()
        {
            //return Newtonsoft.Json.JsonConvert.SerializeObject(lsUsuarios);
            //_ruser = new UsuarioRepository();
            var r = rUsuario.GetAll();
            return Newtonsoft.Json.JsonConvert.SerializeObject(r);
        }
        //[Route("usuario/usuarios")]
        //public string GetUsuarios()
        //{
        //    return Newtonsoft.Json.JsonConvert.SerializeObject(lsUsuarios);
        //}
        public HttpResponseMessage PostUsuario(Usuario user)
        {
            if (rUsuario.Save(user))
            {

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, user);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = user.ID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, Funciones.FormatoMensajes(rUsuario.Mensajes));
            }
        }
    }
}
