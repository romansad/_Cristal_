using System;
using System.Collections.Generic;

namespace MUNICIPALIDAD_V4.models
{
    public partial class Impuestoinmobiliario
    {
        public Impuestoinmobiliario()
        {
            Detalleboleta = new HashSet<Detalleboleta>();
        }

        public int IdImpuesto { get; set; }
        public int? Mes { get; set; }
        public int? Año { get; set; }
        public DateTime? FechaEmision { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public int? Estado { get; set; }
        public decimal? ImporteBase { get; set; }
        public decimal? InteresValor { get; set; }
        public decimal? ImporteFinal { get; set; }
        public int? Bhabilitado { get; set; }
        public int IdLote { get; set; }

        public Lote IdLoteNavigation { get; set; }
        public ICollection<Detalleboleta> Detalleboleta { get; set; }
    }
}
