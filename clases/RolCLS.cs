using System.Collections.Generic;

namespace MUNICIPALIDAD_V4.clases
{
    public class RolCLS
    {
        public int IidRol { get; set; }
        public string NombreRol { get; set; }
        public int BHabilitado { get; set; }
        public string Valores { get; set; } //Para agregar
        public List<PaginaCLS> ListaPagina { get; set; } //Para Editar Paginas de Accesso

    }
}
