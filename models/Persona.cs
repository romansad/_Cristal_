using System;
using System.Collections.Generic;

namespace MUNICIPALIDAD_V4.models
{
    public partial class Persona
    {
        public Persona()
        {
            Lote = new HashSet<Lote>();
            Usuario = new HashSet<Usuario>();
            UsuarioVecino = new HashSet<UsuarioVecino>();
        }

        public int IdPersona { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Dni { get; set; }
        public string Cuil { get; set; }
        public string Mail { get; set; }
        public string Domicilio { get; set; }
        public string Altura { get; set; }
        public DateTime? FechaNac { get; set; }
        public int? Bhabilitado { get; set; }
        public int? BtieneUser { get; set; }

        public ICollection<Lote> Lote { get; set; }
        public ICollection<Usuario> Usuario { get; set; }
        public ICollection<UsuarioVecino> UsuarioVecino { get; set; }
    }
}
