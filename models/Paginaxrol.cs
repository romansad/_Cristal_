using System;
using System.Collections.Generic;

namespace MUNICIPALIDAD_V4.models
{
    public partial class Paginaxrol
    {
        public int IdPaginaxRol { get; set; }
        public int? IdPagina { get; set; }
        public int? IdRol { get; set; }
        public int? Bhabilitado { get; set; }

        public Pagina IdPaginaNavigation { get; set; }
        public Rol IdRolNavigation { get; set; }
    }
}
