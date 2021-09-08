using System;
using System.Collections.Generic;

namespace MUNICIPALIDAD_V4.models
{
    public partial class Tipopago
    {
        public Tipopago()
        {
            Pago = new HashSet<Pago>();
        }

        public int IdTipoPago { get; set; }
        public int? Bhabilitado { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Pago> Pago { get; set; }
    }
}
