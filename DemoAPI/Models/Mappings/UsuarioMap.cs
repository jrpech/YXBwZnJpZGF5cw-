using FluentNHibernate.Mapping;

namespace DemoAPI.Models.Mappings
{
    public class UsuarioMap : ClassMap<Usuario>
    {
        public UsuarioMap()
        {
            Id(x => x.ID).GeneratedBy.Identity();
            Map(x => x.Codigo);
            Map(x => x.Correo);
            Map(x => x.FechaNacimiento);
            Map(x => x.FechaRegistro);
            Map(x => x.MembresiaActual);
            Map(x => x.Nombre);
            Map(x => x.Password);
            Map(x => x.Tipo);
            Map(x => x.TipoLogin);
            Map(x => x.TotalVisitas);
            Map(x => x.UltimoInicio);
            Map(x => x.VisitasActuales);
        }
    }
}