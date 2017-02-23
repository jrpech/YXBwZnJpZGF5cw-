using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoAPI.Models
{
    [Serializable()]
    public class Usuario
    {
        public virtual int ID { get; set; }
        public virtual string Correo { get; set; }
        public virtual string Nombre { get; set; }
        public virtual string Password { get; set; }
        public virtual DateTime FechaNacimiento { get; set; }
        public virtual int TotalVisitas { get; set; }
        public virtual int VisitasActuales { get; set; }
        public virtual DateTime FechaRegistro { get; set; }
        public virtual string TipoLogin { get; set; }
        public virtual DateTime UltimoInicio { get; set; }
        public virtual int MembresiaActual { get; set; }
        public virtual string Tipo { get; set; }
        public virtual string Codigo { get; set; }
    }
}