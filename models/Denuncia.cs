using System;
using System.Collections.Generic;

namespace MUNICIPALIDAD_V4.models
{
    public partial class Denuncia
    {
        public Denuncia()
        {
            PruebaGraficaDenuncia = new HashSet<PruebaGraficaDenuncia>();
            Trabajo = new HashSet<Trabajo>();
        }

        public int NroDenuncia { get; set; }
        public DateTime? Fecha { get; set; }
        public string Descripcion { get; set; }
        public int? CodTipoDenuncia { get; set; }
        public int? CodEstadoDenuncia { get; set; }
        public string NombreInfractor { get; set; }
        public string ApellidoInfractor { get; set; }
        public int? IdUsuario { get; set; }
        public int? Bhabilitado { get; set; }
        public string MailNotificacion { get; set; }
        public string MovilNotificacion { get; set; }
        public string EntreCalles { get; set; }
        public string Altura { get; set; }
        public string Calle { get; set; }
        public int? NroPrioridad { get; set; }

        public EstadoDenuncia CodEstadoDenunciaNavigation { get; set; }
        public TipoDenuncia CodTipoDenunciaNavigation { get; set; }
        public Usuario IdUsuarioNavigation { get; set; }
        public Prioridad NroPrioridadNavigation { get; set; }
        public ICollection<PruebaGraficaDenuncia> PruebaGraficaDenuncia { get; set; }
        public ICollection<Trabajo> Trabajo { get; set; }
    }
}
