using System;
using System.Collections.Generic;

namespace MUNICIPALIDAD_V4.models
{
    public partial class Reclamo
    {
        public Reclamo()
        {
            PruebaGraficaReclamo = new HashSet<PruebaGraficaReclamo>();
            TrabajoReclamo = new HashSet<TrabajoReclamo>();
        }

        public int NroReclamo { get; set; }
        public DateTime? Fecha { get; set; }
        public string Descripcion { get; set; }
        public int? CodTipoReclamo { get; set; }
        public int? CodEstadoReclamo { get; set; }
        public int? Bhabilitado { get; set; }
        public string Calle { get; set; }
        public string Altura { get; set; }
        public string EntreCalles { get; set; }
        public int? IdVecino { get; set; }
        public int? IdUsuario { get; set; }

        public EstadoReclamo CodEstadoReclamoNavigation { get; set; }
        public TipoReclamo CodTipoReclamoNavigation { get; set; }
        public Usuario IdUsuarioNavigation { get; set; }
        public UsuarioVecino IdVecinoNavigation { get; set; }
        public ICollection<PruebaGraficaReclamo> PruebaGraficaReclamo { get; set; }
        public ICollection<TrabajoReclamo> TrabajoReclamo { get; set; }
    }
}
