using System;
using System.Collections.Generic;

namespace MUNICIPALIDAD_V4.models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Denuncia = new HashSet<Denuncia>();
            PruebaGraficaDenuncia = new HashSet<PruebaGraficaDenuncia>();
            PruebaGraficaReclamo = new HashSet<PruebaGraficaReclamo>();
            Reclamo = new HashSet<Reclamo>();
            Sesiones = new HashSet<Sesiones>();
            Solicitud = new HashSet<Solicitud>();
            Trabajo = new HashSet<Trabajo>();
            TrabajoReclamo = new HashSet<TrabajoReclamo>();
            TrabajoSolicitud = new HashSet<TrabajoSolicitud>();
        }

        public int IdUsuario { get; set; }
        public string NombreUser { get; set; }
        public string Contrasenia { get; set; }
        public int? IdPersona { get; set; }
        public int? Bhabilitado { get; set; }
        public int? IdTipoUsuario { get; set; }
        public DateTime? FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }

        public Persona IdPersonaNavigation { get; set; }
        public Rol IdTipoUsuarioNavigation { get; set; }
        public ICollection<Denuncia> Denuncia { get; set; }
        public ICollection<PruebaGraficaDenuncia> PruebaGraficaDenuncia { get; set; }
        public ICollection<PruebaGraficaReclamo> PruebaGraficaReclamo { get; set; }
        public ICollection<Reclamo> Reclamo { get; set; }
        public ICollection<Sesiones> Sesiones { get; set; }
        public ICollection<Solicitud> Solicitud { get; set; }
        public ICollection<Trabajo> Trabajo { get; set; }
        public ICollection<TrabajoReclamo> TrabajoReclamo { get; set; }
        public ICollection<TrabajoSolicitud> TrabajoSolicitud { get; set; }
    }
}
