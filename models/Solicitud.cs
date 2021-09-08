using System;
using System.Collections.Generic;

namespace MUNICIPALIDAD_V4.models
{
    public partial class Solicitud
    {
        public Solicitud()
        {
            TrabajoSolicitud = new HashSet<TrabajoSolicitud>();
        }

        public int NroSolicitud { get; set; }
        public DateTime? Fecha { get; set; }
        public string Descripcion { get; set; }
        public int? CodTipoSolicitud { get; set; }
        public int? CodEstadoSolicitud { get; set; }
        public int? Bhabilitado { get; set; }
        public int? IdVecino { get; set; }
        public int? IdUsuario { get; set; }

        public EstadoSolicitud CodEstadoSolicitudNavigation { get; set; }
        public TipoSolicitud CodTipoSolicitudNavigation { get; set; }
        public Usuario IdUsuarioNavigation { get; set; }
        public UsuarioVecino IdVecinoNavigation { get; set; }
        public ICollection<TrabajoSolicitud> TrabajoSolicitud { get; set; }
    }
}
