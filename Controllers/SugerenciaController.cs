using Microsoft.AspNetCore.Mvc;
using MUNICIPALIDAD_V4.clases;
using MUNICIPALIDAD_V4.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MUNICIPALIDAD_V4.Controllers
{
    public class SugerenciaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        [Route("api/Sugerencia/ListarTiposReclamo")]
        public IEnumerable<TipoReclamoCLS> ListarTiposReclamo()
        {
            List<TipoReclamoCLS> listaTipoReclamo;
            using (M_VPSA_V3Context bd = new M_VPSA_V3Context())
            {

                listaTipoReclamo = (from tipoReclamo in bd.TipoReclamo
                                    where tipoReclamo.Bhabilitado == 1
                                    select new TipoReclamoCLS
                                    {
                                        cod_Tipo_Reclamo = tipoReclamo.CodTipoReclamo,
                                        nombre = tipoReclamo.Nombre,
                                        descripcion = tipoReclamo.Descripcion
                                    }).ToList();
                return listaTipoReclamo;
            }

        }

        [HttpPost]
        [Route("api/Sugerencia/guardarSugerencia")]
        public int guardarSugerencia([FromBody] SugerenciaCLS sugerenciaCLS)
        {
            int rpta = 0;
            try
            {
                using (M_VPSA_V3Context bd = new M_VPSA_V3Context())
                {
                    Sugerencia oSugerencia = new Sugerencia();
                    oSugerencia.Descripcion = sugerenciaCLS.descripcion;
                    oSugerencia.Bhabilitado = 1;
                    oSugerencia.Estado = 1;
                    bd.Sugerencia.Add(oSugerencia);
                    bd.SaveChanges();
                }
                rpta = 1;
            }
            
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                rpta = 0;
            }
            return rpta;
        }
        [HttpGet]
        [Route("api/Sugerencia/listarSugerencias")]
        public IEnumerable<SugerenciaCLS> ListarSugerencias()
        {
            using (M_VPSA_V3Context bd = new M_VPSA_V3Context())
            {

                List<SugerenciaCLS> listaSugerencia = (from sugerencia in bd.Sugerencia
                                                 
                                                 where sugerencia.Bhabilitado == 1 && sugerencia.Estado==1
                                                 select new SugerenciaCLS
                                                 {
                                                     idSugerencia = sugerencia.IdSugerencia,
                                                     fechaGenerada = (DateTime)sugerencia.FechaGenerada,
                                                     descripcion = sugerencia.Descripcion
                                                 }).ToList();
                return listaSugerencia;
            }

        }

        // Este metodo para la edicion significa que debo modificar si una sugerencia 
        //es irrelevante                Usuario oUsuario = bd.Usuario.Where(p => p.IdUsuario == oUsuarioCLS.IdUsuario).First();





    }
}
