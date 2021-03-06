using Microsoft.AspNetCore.Mvc;
using MUNICIPALIDAD_V4.clases;
using MUNICIPALIDAD_V4.models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MUNICIPALIDAD_V4.Controllers
{
    public class ReclamoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("api/Reclamo/ListarTiposReclamo")]
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
        //   Agregaro porque por ahora es todo nu,l!!! tiempo_Max_Tratamiento = (int)tipoReclamo.TiempoMaxTratamiento,
        // FALTA TENER EL LOGIN DE VECINO PARA QUE pueda generar el reclamo. 
        [HttpPost]
        [Route("api/Reclamo/guardarReclamo")]
        public int guardarReclamo([FromBody] ReclamoCLS reclamoCLS)
        {
            int rpta = 0;
            try
            {
                using (M_VPSA_V3Context bd = new M_VPSA_V3Context())
                {
                    Reclamo oReclamo = new Reclamo();
                    oReclamo.CodTipoReclamo = reclamoCLS.codTipoReclamo;
                    oReclamo.Calle = reclamoCLS.calle;
                    oReclamo.Altura = reclamoCLS.altura;
                    oReclamo.EntreCalles = reclamoCLS.entreCalles;
                    oReclamo.CodEstadoReclamo = 1;
                    oReclamo.Descripcion = reclamoCLS.descripcion;
                    oReclamo.Bhabilitado = 1;
                    oReclamo.IdVecino = reclamoCLS.idVecino;
                    bd.Reclamo.Add(oReclamo);
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
        [Route("api/Reclamo/listarReclamos")]
        public IEnumerable<ReclamoCLS> ListarReclamos()
        {
            using (M_VPSA_V3Context bd = new M_VPSA_V3Context())
            {

                List<ReclamoCLS> listaReclamo = (from reclamo in bd.Reclamo
                                                 join estadoReclamo in bd.EstadoReclamo
                                                on reclamo.CodEstadoReclamo equals estadoReclamo.CodEstadoReclamo
                                                 join tipoReclamo in bd.TipoReclamo
                                                 on reclamo.CodTipoReclamo equals tipoReclamo.CodTipoReclamo
                                                 where reclamo.Bhabilitado == 1
                                                 select new ReclamoCLS
                                                 {
                                                     nroReclamo = reclamo.NroReclamo,
                                                     Fecha = (DateTime)reclamo.Fecha,
                                                     estadoReclamo = estadoReclamo.Nombre,
                                                     tipoReclamo = tipoReclamo.Nombre,
                                                 }).ToList();
                return listaReclamo;
            }

        }











        //









    }
}
