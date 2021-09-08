using System;
using System.Collections.Generic;

namespace MUNICIPALIDAD_V4.models
{
    public partial class TrabajoSolicitud
    {
        public int NroTrabajo { get; set; }
        public string Descripcion { get; set; }
        public DateTime? Fecha { get; set; }
        public int NroSolicitud { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdVecino { get; set; }
        public int? Bhabilitado { get; set; }

        public Usuario IdUsuarioNavigation { get; set; }
        public UsuarioVecino IdVecinoNavigation { get; set; }
        public Solicitud NroSolicitudNavigation { get; set; }
    }
}
