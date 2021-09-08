using System;
using System.Collections.Generic;

namespace MUNICIPALIDAD_V4.models
{
    public partial class TipoReclamo
    {
        public TipoReclamo()
        {
            Reclamo = new HashSet<Reclamo>();
        }

        public int CodTipoReclamo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? Bhabilitado { get; set; }
        public int? TiempoMaxTratamiento { get; set; }

        public ICollection<Reclamo> Reclamo { get; set; }
    }
}
