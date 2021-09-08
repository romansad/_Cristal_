using System;
using System.Collections.Generic;

namespace MUNICIPALIDAD_V4.models
{
    public partial class Boleta
    {
        public Boleta()
        {
            Detalleboleta = new HashSet<Detalleboleta>();
        }

        public int IdBoleta { get; set; }
        public DateTime? FechaGenerada { get; set; }
        public DateTime? FechaPago { get; set; }
        public int? Estado { get; set; }
        public int? Bhabilitado { get; set; }
        public string TipoMoneda { get; set; }
        public string Url { get; set; }
        public decimal? Importe { get; set; }
        public DateTime? FechaVencimiento { get; set; }

        public ICollection<Detalleboleta> Detalleboleta { get; set; }
    }
}
