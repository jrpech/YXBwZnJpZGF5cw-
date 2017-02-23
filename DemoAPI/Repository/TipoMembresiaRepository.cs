using DemoAPI.Models;
using Eupa.net.Core.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoAPI.Repository
{
    public class TipoMembresiaRepository : RepositoryBase<TipoMembresia>
    {
        public override TipoMembresia GetById(object id)
        {
            return _session.Get<TipoMembresia>(id);
        }
    }
}