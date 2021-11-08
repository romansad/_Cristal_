using System;
using System.Collections.Generic;

namespace MUNICIPALIDAD_V4.models
{
    public partial class DatosAbiertos
    {
        public int IdArchivo { get; set; }
        public string NombreArchivo { get; set; }
        public string Extension { get; set; }
        public double? Tamaño { get; set; }
        public string Ubicacion { get; set; }
        public int? Bhabilitado { get; set; }
        public int? IdTipoDato { get; set; }

        public TipoDatoAbierto IdTipoDatoNavigation { get; set; }
    }
}
