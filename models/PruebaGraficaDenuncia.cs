using System;
using System.Collections.Generic;

namespace MUNICIPALIDAD_V4.models
{
    public partial class PruebaGraficaDenuncia
    {
        public int NroImagen { get; set; }
        public byte[] Imagen { get; set; }
        public int? NroDenuncia { get; set; }
        public int? IdUsuario { get; set; }
        public int? Bhabilitado { get; set; }
        public string Foto { get; set; }
        public int? NroTrabajo { get; set; }

        public Usuario IdUsuarioNavigation { get; set; }
        public Denuncia NroDenunciaNavigation { get; set; }
        public Trabajo NroTrabajoNavigation { get; set; }
    }
}
