using System;
using System.Collections.Generic;

namespace MUNICIPALIDAD_V4.models
{
    public partial class TipoDenuncia
    {
        public TipoDenuncia()
        {
            Denuncia = new HashSet<Denuncia>();
        }

        public int CodTipoDenuncia { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? TiempoMaxTratamiento { get; set; }
        public int? Bhabilitado { get; set; }

        public ICollection<Denuncia> Denuncia { get; set; }
    }
}
