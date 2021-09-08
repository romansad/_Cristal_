using System;
using System.Collections.Generic;

namespace MUNICIPALIDAD_V4.models
{
    public partial class Detalleboleta
    {
        public int IdDetalleBoleta { get; set; }
        public int IdBoleta { get; set; }
        public int IdImpuesto { get; set; }
        public int? Bhabilitado { get; set; }
        public decimal? Importe { get; set; }
        public int? Estado { get; set; }

        public Boleta IdBoletaNavigation { get; set; }
        public Impuestoinmobiliario IdImpuestoNavigation { get; set; }
    }
}
