using System;
using System.Collections.Generic;

namespace MUNICIPALIDAD_V4.models
{
    public partial class TipoDatoAbierto
    {
        public TipoDatoAbierto()
        {
            DatosAbiertos = new HashSet<DatosAbiertos>();
        }

        public int IdTipoDato { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? Bhabilitado { get; set; }

        public ICollection<DatosAbiertos> DatosAbiertos { get; set; }
    }
}
