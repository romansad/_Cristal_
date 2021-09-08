using System;
using System.Collections.Generic;

namespace MUNICIPALIDAD_V4.models
{
    public partial class Lote
    {
        public Lote()
        {
            Impuestoinmobiliario = new HashSet<Impuestoinmobiliario>();
        }

        public int IdLote { get; set; }
        public int? Manzana { get; set; }
        public int? NroLote { get; set; }
        public string Calle { get; set; }
        public string Altura { get; set; }
        public decimal? SupTerreno { get; set; }
        public decimal? SupEdificada { get; set; }
        public string NomenclaturaCatastral { get; set; }
        public string TipoInmueble { get; set; }
        public string EstadoInmueble { get; set; }
        public decimal? BaseImponible { get; set; }
        public decimal? ValuacionTotal { get; set; }
        public int? EstadoDeuda { get; set; }
        public int? IdPersona { get; set; }

        public Persona IdPersonaNavigation { get; set; }
        public ICollection<Impuestoinmobiliario> Impuestoinmobiliario { get; set; }
    }
}
