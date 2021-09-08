using System;
using System.Collections.Generic;

namespace MUNICIPALIDAD_V4.models
{
    public partial class EstadoSolicitud
    {
        public EstadoSolicitud()
        {
            Solicitud = new HashSet<Solicitud>();
        }

        public int CodEstadoSolicitud { get; set; }
        public string Nombre { get; set; }
        public int? Bhabilitado { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Solicitud> Solicitud { get; set; }
    }
}
