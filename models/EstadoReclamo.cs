using System;
using System.Collections.Generic;

namespace MUNICIPALIDAD_V4.models
{
    public partial class EstadoReclamo
    {
        public EstadoReclamo()
        {
            Reclamo = new HashSet<Reclamo>();
        }

        public int CodEstadoReclamo { get; set; }
        public string Nombre { get; set; }
        public int? Bhabilitado { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Reclamo> Reclamo { get; set; }
    }
}
