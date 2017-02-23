using DemoAPI.Models;
using FluentNHibernate.Mapping;

namespace DemoAPI.Models.Mappings
{
    public class TipoMembresiaMap : ClassMap<TipoMembresia>
    {
        public TipoMembresiaMap()
        {
            Id(x => x.ID);
            Map(x => x.Color);
            Map(x => x.Estado);
            Map(x => x.Nombre);
            Map(x => x.NumeroDeVisiatas);
            Map(x => x.PorcientoDescuento);
        }
    }
}