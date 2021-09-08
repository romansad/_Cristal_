using System;
using System.Collections.Generic;

namespace MUNICIPALIDAD_V4.models
{
    public partial class PrioridadReclamo
    {
        public int NroPrioridad { get; set; }
        public string NombrePrioridad { get; set; }
        public int? Bhabilitado { get; set; }
        public string Descripcion { get; set; }
    }
}
