using System;
using System.Collections.Generic;

namespace MUNICIPALIDAD_V4.models
{
    public partial class PruebaGraficaReclamo
    {
        public int NroImagen { get; set; }
        public byte[] Imagen { get; set; }
        public int? NroReclamo { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdVecino { get; set; }
        public int? Bhabilitado { get; set; }

        public Usuario IdUsuarioNavigation { get; set; }
        public UsuarioVecino IdVecinoNavigation { get; set; }
        public Reclamo NroReclamoNavigation { get; set; }
    }
}
