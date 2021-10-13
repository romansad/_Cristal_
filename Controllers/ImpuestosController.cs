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
                                      idImpuesto=(int)impuestoinmobiliario.IdImpuesto,
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

        [HttpPost]
        [Route("api/Impuestos/guardarBoleta")]
        public async Task<IActionResult> guardarBoleta([FromBody] DetalleBoletaCLS oDetalleBoletaCLS)
        //public int guardarBoleta([FromBody] DetalleBoletaCLS oDetalleBoletaCLS)
        {
            //objeto global boleta para enviar a mobbex
            BoletaCLS oBoletaCLS = new BoletaCLS();

           // int rpta = 0;
            try
            {
                using (M_VPSA_V3Context bd = new M_VPSA_V3Context())
                {
                    //Usaremos transacciones porque tocaremos dos tablas imultaneamente.
                    using (var transaccion = new TransactionScope())
                    {
                        // if (oDetalleBoletaCLS.IdDetalleBoleta == 0)
                        // {
                        Boleta oBoleta = new Boleta();
                        oBoleta.FechaGenerada = DateTime.Today;
                        oBoleta.Estado = 0;
                        oBoleta.TipoMoneda = "AR$";
                        oBoleta.Url = "https://POST NUESTRA URL";
                        //oBoleta.Importe
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

                           Boleta oBoleta2 = bd.Boleta.Last();
                            //Llenaremos los campos del objeto boleta para enviarlo a mobbex
                            oBoletaCLS.idBoleta = oBoleta2.IdBoleta;
                            oBoletaCLS.currency = "ARS";
                            //idBoleta = oBoleta2.IdBoleta;
                            //bd.Database.ExecuteSqlCommand("ACTUALIZACION_DETALLESBOLETA");
                            SqlParameter boletaid = new SqlParameter("@IdBoleta_par", oBoletaCLS.idBoleta);
                            bd.Database.ExecuteSqlCommand("ACTUALIZACION_DETALLESBOLETA @IdBoleta_par", boletaid);
                            
                            HttpContext.Session.SetString("idBoleta", oBoleta2.IdBoleta.ToString());
                             // VER LA POSIBILIDAD DE INSERTAR TODOS LOS PARAMETROS EN LA SESION Y LUEGO BORRARLOS 
                            // CUANDO FINALICE LA MISMA O POR LO MENOS EL ID DE BOLEta PARA LUEGO RECUPERARLO 
                              bd.SaveChanges();

                        transaccion.Complete();
                        try { 
                        Boleta oboleta = bd.Boleta.Where(b => b.IdBoleta == oBoletaCLS.idBoleta).First();
                        oBoletaCLS.importe = oboleta.Importe;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                            //rpta = 0;
                        }
                        //Crear BOLETACLS porque no puedo tomar un model
                        List <BoletaCLS> ListaBoleta= new List<BoletaCLS>();
                       
                        using (var httpClient = new HttpClient())
                        {
                            StringContent content = new StringContent(JsonConvert.SerializeObject(oBoletaCLS), Encoding.UTF8, "application/json");
                            content.Headers.Add("x-api-key", "BQ32LI_kA4b3DgIfCuYYaRZJcxPRQqt52LXarr_Q");
                            content.Headers.Add("x-access-token", "0aac0a06-799e-4251-aff1-11d079ee79f7");
                            content.Headers.Add("Content-Type", "application/json");
                            using (var response = await httpClient.PostAsync("https://api.mobbex.com/p/checkout", content))
                            {
                                string apiResponse = await response.Content.ReadAsStringAsync();
                                oBoletaCLS = JsonConvert.DeserializeObject<BoletaCLS>(apiResponse);
                            }
                        }
                        return View(oBoletaCLS);

//                        var request = new RestRequest(Method.POST);
//                        request.AddHeader("x-api-key", "zJ8LFTBX6Ba8D611e9io13fDZAwj0QmKO1Hn1yIj");
//                        request.AddHeader("x-access-token", "d31f0721-2f85-44e7-bcc6-15e19d1a53cc");
//                        request.AddHeader("Content-Type", "application/json");
//                        var body = @"{
//" + "\n" +
//                        @"    ""total"": ""100.53"",
//" + "\n" +
//                        @"    ""description"": ""Checkout de Prueba"",
//" + "\n" +
//                        @"    ""reference"": ""260520210954"",
//" + "\n" +
//                        @"    ""currency"": ""ARS"",
//" + "\n" +
//                        @"    ""test"": true,
//" + "\n" +
//                        @"    ""return_url"": ""https://mobbex.com/return_url"",
//" + "\n" +
//                        @"    ""webhook"": ""https://mobbex.com/webhook"",
//" + "\n" +
//                        @"    ""customer"": {
//" + "\n" +
//                        @"        ""email"": ""demo@mobbex.com"",
//" + "\n" +
//                        @"        ""name"": ""Cliente Demo"",
//" + "\n" +
//                        @"        ""identification"": ""12123123""
//" + "\n" +
//                        @"    }
//" + "\n" +
//                        @"}";
//                        request.AddParameter("application/json", body, ParameterType.RequestBody);
//                        IRestResponse response = client.Execute(request);
//                        Console.WriteLine(response.Content);



                        //rpta = 1;
                        
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                //rpta = 0;
            }
            //  return rpta;
            return Ok(oBoletaCLS);
        }   //FIN GUARdar Boleta y enviar a mobex


        //A partir de aqui termina todo
    }
}
