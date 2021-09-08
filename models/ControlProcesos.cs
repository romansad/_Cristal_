using System;
using System.Collections.Generic;

namespace MUNICIPALIDAD_V4.models
{
    public partial class ControlProcesos
    {
        public int IdEjecucion { get; set; }
        public int IdProceso { get; set; }
        public DateTime? FechaEjecucion { get; set; }

        public ParametriaProcesos IdProcesoNavigation { get; set; }
    }
}
