using System;
using System.Collections.Generic;

namespace MUNICIPALIDAD_V4.models
{
    public partial class Trabajo
    {
        public Trabajo()
        {
            PruebaGraficaDenuncia = new HashSet<PruebaGraficaDenuncia>();
        }

        public int NroTrabajo { get; set; }
        public string Descripcion { get; set; }
        public DateTime? Fecha { get; set; }
        public int NroDenuncia { get; set; }
        public int? IdUsuario { get; set; }
        public int? Bhabilitado { get; set; }

        public Usuario IdUsuarioNavigation { get; set; }
        public Denuncia NroDenunciaNavigation { get; set; }
        public ICollection<PruebaGraficaDenuncia> PruebaGraficaDenuncia { get; set; }
    }
}
