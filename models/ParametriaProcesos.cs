using System;
using System.Collections.Generic;

namespace MUNICIPALIDAD_V4.models
{
    public partial class ParametriaProcesos
    {
        public ParametriaProcesos()
        {
            ControlProcesos = new HashSet<ControlProcesos>();
        }

        public int IdProceso { get; set; }
        public string Descripcion { get; set; }
        public string Periodicidad { get; set; }

        public ICollection<ControlProcesos> ControlProcesos { get; set; }
    }
}
