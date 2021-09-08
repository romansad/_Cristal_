using System;
using System.Collections.Generic;

namespace MUNICIPALIDAD_V4.models
{
    public partial class Prioridad
    {
        public Prioridad()
        {
            Denuncia = new HashSet<Denuncia>();
        }

        public int NroPrioridad { get; set; }
        public string NombrePrioridad { get; set; }
        public string Descripcion { get; set; }
        public int? Bhabilitado { get; set; }

        public ICollection<Denuncia> Denuncia { get; set; }
    }
}
