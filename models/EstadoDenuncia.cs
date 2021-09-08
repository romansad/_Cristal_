using System;
using System.Collections.Generic;

namespace MUNICIPALIDAD_V4.models
{
    public partial class EstadoDenuncia
    {
        public EstadoDenuncia()
        {
            Denuncia = new HashSet<Denuncia>();
        }

        public int CodEstadoDenuncia { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int? Bhabilitado { get; set; }

        public ICollection<Denuncia> Denuncia { get; set; }
    }
}
