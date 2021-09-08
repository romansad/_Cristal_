using System;
using System.Collections.Generic;

namespace MUNICIPALIDAD_V4.models
{
    public partial class Rol
    {
        public Rol()
        {
            Paginaxrol = new HashSet<Paginaxrol>();
            Usuario = new HashSet<Usuario>();
        }

        public int IdRol { get; set; }
        public string NombreRol { get; set; }
        public int? Bhabilitado { get; set; }

        public ICollection<Paginaxrol> Paginaxrol { get; set; }
        public ICollection<Usuario> Usuario { get; set; }
    }
}
