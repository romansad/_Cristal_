using System;
using System.Collections.Generic;

namespace MUNICIPALIDAD_V4.models
{
    public partial class Sugerencia
    {
        public int IdSugerencia { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaGenerada { get; set; }
        public int? Bhabilitado { get; set; }
        public int? Estado { get; set; }
    }
}
