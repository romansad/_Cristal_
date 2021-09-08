using System.Collections.Generic;

namespace MUNICIPALIDAD_V4.models
{
    public partial class PruebaGrafica
    {
        public PruebaGrafica()
        {
            Trabajo = new HashSet<Trabajo>();
        }

        public int NroImagen { get; set; }
        public byte[] Imagen { get; set; }

        public ICollection<Trabajo> Trabajo { get; set; }
    }
}
