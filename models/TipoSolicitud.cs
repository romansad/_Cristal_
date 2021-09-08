using System;
using System.Collections.Generic;

namespace MUNICIPALIDAD_V4.models
{
    public partial class TipoSolicitud
    {
        public TipoSolicitud()
        {
            Solicitud = new HashSet<Solicitud>();
        }

        public int CodTipoSolicitud { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? Bhabilitado { get; set; }
        public int? TiempoMaxTratamiento { get; set; }

        public ICollection<Solicitud> Solicitud { get; set; }
    }
}
