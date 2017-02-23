using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoAPI.Models
{
    [Serializable()]
    public class TipoMembresia
    {
        public virtual int ID { get; set; }
        public virtual string Nombre { get; set; }
        public virtual int NumeroDeVisiatas { get; set; }
        public virtual decimal PorcientoDescuento { get; set; }
        public virtual string Color { get; set; }
        public virtual string Estado { get; set; }
    }
}