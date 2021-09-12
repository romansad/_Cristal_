using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MUNICIPALIDAD_V4.clases;
using MUNICIPALIDAD_V4.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MUNICIPALIDAD_V4.Controllers
{
    public class ImpuestosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //Funciona para obtener la ultima fecha de ejecucion Mensual..
        [HttpGet]
        [Route("api/Impuestos/getUltimaFechaInteres")]
        public ControlProcesosCLS getUltimaFechaInteres()
        {
            using (M_VPSA_V3Context bd = new M_VPSA_V3Context())
            {
                ControlProcesosCLS oCtrlCLS = (from CONTROLPROCESOS in bd.ControlProcesos
                                               where CONTROLPROCESOS.IdProceso == 2
                                               select new ControlProcesosCLS
                                               {
                                                   idEjecucion = CONTROLPROCESOS.IdEjecucion,
                                                   idProceso = CONTROLPROCESOS.IdProceso,
                                                   fechaEjecucion = (DateTime)CONTROLPROCESOS.FechaEjecucion
                                               }).Last();
                return oCtrlCLS;
            }
        }
        //Fin ejecucion Interes Mensual.
        [HttpGet]
        [Route("api/Impuestos/getUltimaFechaBoleta")]
        public ControlProcesosCLS getUltimaFechaBoleta()
        {
            using (M_VPSA_V3Context bd = new M_VPSA_V3Context())
            {
                ControlProcesosCLS oCtrlCLS = (from CONTROLPROCESOS in bd.ControlProcesos
                                               where CONTROLPROCESOS.IdProceso == 3
                                               select new ControlProcesosCLS
                                               {
                                                   idEjecucion = CONTROLPROCESOS.IdEjecucion,
                                                   idProceso = CONTROLPROCESOS.IdProceso,
                                                   fechaEjecucion = (DateTime)CONTROLPROCESOS.FechaEjecucion
                                               }).Last();
                return oCtrlCLS;
            }
        }
        //Fin ejecucion Confirmacion Boletas.

        //Impuestos Por Lote 
        [HttpGet]
        [Route("api/Impuesto/ListarImpuestosAdeudados/{idLote}")]
        public IEnumerable<ImpuestoInmobiliarioCLS> ListarTrabajos(int idLote)
        {
            List<ImpuestoInmobiliarioCLS> listaImpuestos;
            using (M_VPSA_V3Context bd = new M_VPSA_V3Context())
            {
                listaImpuestos = (from impuestoinmobiliario in bd.Impuestoinmobiliario
                                  where impuestoinmobiliario.IdLote == idLote && impuestoinmobiliario.ImporteBase == 125
                                  select new ImpuestoInmobiliarioCLS

                                  {
                                      mes = (int)impuestoinmobiliario.Mes,
                                      anio = (int)impuestoinmobiliario.Año,
                                      importeBase = (decimal)impuestoinmobiliario.ImporteBase,
                                      interesValor = (decimal)impuestoinmobiliario.InteresValor,
                                      importeFinal = (decimal)impuestoinmobiliario.ImporteFinal
                                  }).ToList();
                return listaImpuestos;
            }
        }
        //where trabajo.Bhabilitado ==1
        ///SP Generacion Anual de Impuestos
       [HttpGet]
       [Route("api/Impuestos/SP_GeneracionImpuestos")]
        public void getGeneracionImpuestos()
        {
            {
                using (M_VPSA_V3Context bd = new M_VPSA_V3Context())
                {
                    bd.Database.ExecuteSqlCommand("GENERACION_IMPUESTOS_LOTES");
                    bd.SaveChanges();
                }
            }


        }
        ///SP Generacion Mensual Impuestos
        [HttpGet]
        [Route("api/Impuestos/SP_GeneracionInteresesMensuales")]
        public void SP_GeneracionInteresesMensuales()
        {
            {
                using (M_VPSA_V3Context bd = new M_VPSA_V3Context())
                {
                    bd.Database.ExecuteSqlCommand("GENERACION_INTERESES");
                    bd.SaveChanges();
                }
            }


        }
        // Procedimiento almacenado [BORRADO_BOLETAS]
        [HttpGet]
        [Route("api/Impuestos/SP_LimpiezaBoletas")]
        public void SP_LimpiezaBoletas()
        {
            {
                using (M_VPSA_V3Context bd = new M_VPSA_V3Context())
                {
                    bd.Database.ExecuteSqlCommand("BORRADO_BOLETAS");
                    bd.SaveChanges();
                }
            }


        }


        //A partir de aqui termina todo
    }
}
