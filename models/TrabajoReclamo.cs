using System;
using System.Collections.Generic;

namespace MUNICIPALIDAD_V4.models
{
    public partial class TrabajoReclamo
    {
        public int NroTrabajo { get; set; }
        public string Descripcion { get; set; }
        public DateTime? Fecha { get; set; }
        public int NroReclamo { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdVecino { get; set; }
        public int? Bhabilitado { get; set; }

        public Usuario IdUsuarioNavigation { get; set; }
        public UsuarioVecino IdVecinoNavigation { get; set; }
        public Reclamo NroReclamoNavigation { get; set; }
    }
}
