using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MUNICIPALIDAD_V4.clases;
using MUNICIPALIDAD_V4.models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

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
                                  where impuestoinmobiliario.IdLote == idLote
                                  select new ImpuestoInmobiliarioCLS

                                  {

                                      idImpuesto = (int)impuestoinmobiliario.IdImpuesto,
                                      mes = (int)impuestoinmobiliario.Mes,
                                      anio = (int)impuestoinmobiliario.Año,
                                      importeBase = (decimal)impuestoinmobiliario.ImporteBase,
                                      interesValor = (decimal)impuestoinmobiliario.InteresValor,
                                      importeFinal = (decimal)impuestoinmobiliario.ImporteFinal
                                  }).ToList();
                if (listaImpuestos != null && listaImpuestos.Count > 0)
                {
                    //Seteo de ID de Lote seleccionado para traer el correo de la persona cuando pague la boleta.
                    HttpContext.Session.SetString("idLoteaPagar", idLote.ToString());
                }
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

        [HttpPost]
        [Route("api/Impuestos/guardarBoleta")]
        public async Task<ActionResult> guardarBoleta([FromBody] DetalleBoletaCLS oDetalleBoletaCLS)
        //  public async Task<IActionResult> guardarBoleta([FromBody] DetalleBoletaCLS oDetalleBoletaCLS)

        {
            //objeto global boleta para enviar a mobbex
            BoletaCLS oBoletaCLS = new BoletaCLS();
            Customer customer = new Customer();
            PersonaCLS oPersonaCLS = new PersonaCLS();
            RespCheckoutMOBXX rtaChMobxx = null;
            try
            {
                using (M_VPSA_V3Context bd = new M_VPSA_V3Context())
                {

                    int idLoteaPagar = int.Parse(HttpContext.Session.GetString("idLoteaPagar"));

                    oPersonaCLS = (from Lote in bd.Lote
                                   join Persona in bd.Persona
                                   on Lote.IdPersona equals Persona.IdPersona
                                   where Persona.Bhabilitado == 1
                                  && Lote.IdLote == idLoteaPagar
                                   select new PersonaCLS
                                   {
                                       Nombre = Persona.Nombre,
                                       apellido = Persona.Apellido,
                                       Mail = Persona.Mail,
                                       Dni = Persona.Dni

                                   }).First();
                    customer.email = oPersonaCLS.Mail;
                    customer.identification = oPersonaCLS.Dni;
                    customer.name = oPersonaCLS.Nombre + " " + oPersonaCLS.apellido;
                    //AL finalizar la obtencion dinamica de la persona ahora eliminaremos la sesion temporal del backend 
                    HttpContext.Session.Remove("idLoteaPagar");
                    //Usaremos transacciones porque tocaremos dos tablas imultaneamente.
                    using (var transaccion = new TransactionScope())
                    {
                        Boleta oBoleta = new Boleta();
                        oBoleta.FechaGenerada = DateTime.Now;
                        oBoleta.Estado = 0;

                        oBoleta.TipoMoneda = "AR$";
                        oBoleta.Url = "https://POSTNGROK";
                        oBoleta.Bhabilitado = 0;
                        bd.Boleta.Add(oBoleta);
                        int idBoleta = oBoleta.IdBoleta;
                        String[] idsDetalles = oDetalleBoletaCLS.Valores.Split("-"); //Separo los valores obtenidos enla variable que tienen el guion como separador y los transformo en un array de objetos separados por coma.
                        for (int i = 0; i < idsDetalles.Length; i++)
                        {
                            Detalleboleta oDetalleboleta = new Detalleboleta();
                            oDetalleboleta.IdBoleta = idBoleta;
                            oDetalleboleta.IdImpuesto = int.Parse(idsDetalles[i]);
                            oDetalleboleta.Estado = 0;
                            bd.Detalleboleta.Add(oDetalleboleta);
                        }

                        bd.SaveChanges();
                        bd.Database.ExecuteSqlCommand("GENERACION_IMPORTE_BOLETA");
                        Boleta oBoleta2 = bd.Boleta.Last();
                        oBoletaCLS.idBoleta = oBoleta2.IdBoleta;
                        // SesioN de BOLETA CREADA EN LA SIGUIETNE LINEA NO UTILIZADA POR ESO LA COMENTO
                        // HttpContext.Session.SetString("idBoleta", oBoleta2.IdBoleta.ToString());
                        transaccion.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            using (M_VPSA_V3Context bd = new M_VPSA_V3Context())
            {
                Boleta oBoleta3 = new Boleta();
                try
                {
                    oBoleta3 = bd.Boleta.Where(b => b.IdBoleta == oBoletaCLS.idBoleta).First();
                    oBoletaCLS.importe = oBoleta3.Importe;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            BoletaMobexx oBolMobexx = new BoletaMobexx(customer.email, customer.name, customer.identification);
            oBolMobexx.total = (decimal)oBoletaCLS.importe;
            oBolMobexx.description = "Pago de Impuestos Vecinos Villa Parque Santa Ana";
            oBolMobexx.reference = oBoletaCLS.idBoleta;
            oBolMobexx.currency = "ARS";
            oBolMobexx.test = true;
            oBolMobexx.return_url = "NGROKNUESTRO";
            oBolMobexx.webhook = "https://mobbex.com/webhook_SegundaApi";
            var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(oBolMobexx);
            using (var httpClient = new HttpClient())
            {
                try
                {
                    httpClient.DefaultRequestHeaders.Add("x-api-key", "BQ32LI_kA4b3DgIfCuYYaRZJcxPRQqt52LXarr_Q");
                    httpClient.DefaultRequestHeaders.Add("x-access-token", "0aac0a06-799e-4251-aff1-11d079ee79f7");

                    //httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");
                    //request.Content.Headers.Add("Content-Type", "application/json");
                    var uri = "https://api.mobbex.com/p/checkout";

                    var response = await httpClient.PostAsync(uri, new StringContent(jsonString, Encoding.UTF8, "application/json"));
                    if (response.IsSuccessStatusCode)
                    {
                        //LA VARIANLE Cuerpo es la que tiene el Ok devuelto por mobexx y debo redireccionar al site para el pago efectivo.
                        var cuerpo = await response.Content.ReadAsStringAsync();
                        rtaChMobxx = JsonConvert.DeserializeObject<RespCheckoutMOBXX>(cuerpo);
                        rtaChMobxx = new RespCheckoutMOBXX(rtaChMobxx.data.id, rtaChMobxx.data.url, rtaChMobxx.data.description, rtaChMobxx.data.total, rtaChMobxx.data.created);
                        HttpContext.Session.SetString("urlMobbex", rtaChMobxx.data.url.ToString());

                        //return Redirect(rtaChMobxx.data.url.ToString());  //RedirectToAction
                        // esta joya.
                        //Console.WriteLine("La respuesta es: " + rtaChMobxx.data.url.ToString());
                        var camposConErrores = Utilidades.ExtraerErrorDelWebApi(cuerpo);
                        if (!(camposConErrores == null))
                        {
                            foreach (var campoErrores in camposConErrores)
                            {
                                Console.WriteLine($"-{campoErrores}");
                                foreach (var error in campoErrores.Value)
                                {
                                    Console.WriteLine($"-{error}");
                                }
                            }
                            Console.WriteLine("La respuesta es: " + cuerpo);
                        }
                    }
                    else
                    {
                        var cuerpo = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("La respuesta es: " + cuerpo);
                    }

                    response.EnsureSuccessStatusCode();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return Redirect(rtaChMobxx.data.url);  //

            //return Ok();
        }   //FIN GUARdar Boleta y enviar a mobex.

        //OBTENER VARIABLE DE SESSION Url Mobexx ver cuando destruirla.....
        [HttpGet]
        [Route("api/Impuesto/obtenerUrlMobbexx")]
        public RedirectResult obtenerUrlMobbexx()
        {
            dataUrlMbxCLS oDataUrlMbx = new dataUrlMbxCLS();

            var varUrl = HttpContext.Session.GetString("urlMobbex");
            if (varUrl == null)
            {
                oDataUrlMbx.valor = "/";
            }
            else
            {

                oDataUrlMbx.valor = varUrl;
            }
            return Redirect(oDataUrlMbx.valor);
        }

        [HttpGet]
        [Route("api/Impuesto/obtenerUrlMobbexx2")]
        public UrlMobexx obtenerUrlMobbexx2()
        {
            UrlMobexx oUrlMbx = new UrlMobexx();

            var varUrl = HttpContext.Session.GetString("urlMobbex");
            if (varUrl == null)
            {
                oUrlMbx.urlMobexx = "/";
            }
            else
            {

                oUrlMbx.urlMobexx = varUrl;
            }
            return oUrlMbx;
        }
        //   Boleta Pagada Recepcion de Pago. 
        // [HttpPost]
        //public async Task<ActionResult> Confirmacion(int id)
        //{
        //    using (M_VPSA_V3Context bd = new M_VPSA_V3Context())
        //    {
        //        var idBoleta = id;
        //    SqlParameter boletaid = new SqlParameter("@IdBoleta", idBoleta);
        //   var llamar= bd.Database.ExecuteSqlCommand("ACTUALIZACION_DETALLES_E_IMPUESTOS @IdBoleta", boletaid);
        //       await bd.SaveChanges();

        //        // await _context.SaveChangesAsync();

        //        //return CreatedAtAction("GetBoletum", new { id = boletum.IdBoleta }, boletum);
        //        return Ok();
        //    }
        //}

        //A partir de aqui termina todo
    
    }
}
