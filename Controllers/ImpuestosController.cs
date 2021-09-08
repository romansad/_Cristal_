using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MUNICIPALIDAD_V4.clases;
using MUNICIPALIDAD_V4.Data;
using MUNICIPALIDAD_V4.models;
using System;
using System.Collections;
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

        //Impuestos Por Lote 
        [HttpGet]
        [Route("api/Impuesto/ListarImpuestosAdeudados/{idLote}")]
        public IEnumerable<ImpuestoInmobiliarioCLS> ListarTrabajos(int idLote)
        {
            List<ImpuestoInmobiliarioCLS> listaImpuestos;
            using (M_VPSA_V3Context bd = new M_VPSA_V3Context())
            {
                listaImpuestos = (from impuestoinmobiliario in bd.Impuestoinmobiliario
                                where impuestoinmobiliario.IdLote==idLote && impuestoinmobiliario.ImporteBase ==125
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

        private readonly ValuesRepository _repository;

        public ValuesController(ValuesRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable>> Get()
        {
            return await _repository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var response = await _repository.GetById(id);
            if (response == null) { return NotFound(); }
            return response;
        }

        // POST api/values
        [HttpPost]
        public async Task Post([FromBody] Value value)
        {
            await _repository.Insert(value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _repository.DeleteById(id);
        }

    }
}
