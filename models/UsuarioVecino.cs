using System;
using System.Collections.Generic;

namespace MUNICIPALIDAD_V4.models
{
    public partial class UsuarioVecino
    {
        public UsuarioVecino()
        {
            PruebaGraficaReclamo = new HashSet<PruebaGraficaReclamo>();
            Reclamo = new HashSet<Reclamo>();
            Solicitud = new HashSet<Solicitud>();
            TrabajoReclamo = new HashSet<TrabajoReclamo>();
            TrabajoSolicitud = new HashSet<TrabajoSolicitud>();
        }

        public int IdVecino { get; set; }
        public string NombreUser { get; set; }
        public string Contrasenia { get; set; }
        public int? IdPersona { get; set; }
        public int? Bhabilitado { get; set; }
        public DateTime? FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }

        public Persona IdPersonaNavigation { get; set; }
        public ICollection<PruebaGraficaReclamo> PruebaGraficaReclamo { get; set; }
        public ICollection<Reclamo> Reclamo { get; set; }
        public ICollection<Solicitud> Solicitud { get; set; }
        public ICollection<TrabajoReclamo> TrabajoReclamo { get; set; }
        public ICollection<TrabajoSolicitud> TrabajoSolicitud { get; set; }
    }
}
