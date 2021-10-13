using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MUNICIPALIDAD_V4.clases
{
    public class Post
    {
        public decimal total { get; set; }
        public  string descripcion { get; set; }
        public  string currency { get; set; }
        public string reference { get; set; }
        public Boolean test { get; set; }
        public string return_url { get; set; }
        public Customer customer { get; set; }
      

    }
}
