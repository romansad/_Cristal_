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
        public int guardarBoleta([FromBody] DetalleBoletaCLS oDetalleBoletaCLS)
        {
            int rpta = 0;
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

                        try
                        {
                            bd.Database.ExecuteSqlCommand("ACTUALIZACION_DETALLESBOLETA");
                            //SqlParameter boletaid = new SqlParameter("@IdBoleta_par", idBoleta);
                            //bd.Database.ExecuteSqlCommand("ACTUALIZACION_DETALLESBOLETA @IdBoleta_par", boletaid);
                            //bd.Database.ExecuteSqlCommand("ACTUALIZACION_DETALLESBOLETA @IdBoleta_par", idBoleta);
                            //bd.Database.ExecuteSqlCommand("ACTUALIZACION_DETALLESBOLETA", new SqlParameter("@IdBoleta_par", idBoleta));
                            bd.SaveChanges();

                        }
                        catch (Exception ex) {
                            Console.WriteLine(ex); }
                        transaccion.Complete();
                        
                        //var command = connection.CreateCommand();10
                        //bd.CommandType = CommandType.StoredProcedure;
                        //bd.CommandText = "ACTUALIZACION_DETALLESBOLETA";
                        //bd.Parameters.AddWithValue("@IdBoleta_par", idBoleta);

                        //command.ExecuteNonQuery();
                        //bd.Database.ExecuteSqlCommand("ACTUALIZACION_DETALLESBOLETA", new SqlParameter("@IdBoleta_par", idBoleta));
                        //bd.SaveChanges();
                        rpta = 1;
                        //  }
                        //else
                        //{
                        //    //REcuperamos la info.
                        //    Rol oRol = bd.Rol.Where(p => p.IdRol == oRolCLS.IidRol).First();
                        //    oRol.NombreRol = oRolCLS.NombreRol;
                        //    oRol.Bhabilitado = 1;
                        //    bd.SaveChanges();
                        //    String[] idsPaginas = oRolCLS.Valores.Split("-");
                        //    //ahora vamos a deshabilitar todas las paginas asociadas con este rol actualmente. 
                        //    List<Paginaxrol> lista = bd.Paginaxrol.Where(p => p.IdRol == oRolCLS.IidRol).ToList();
                        //    foreach (Paginaxrol pag in lista)
                        //    {
                        //        pag.Bhabilitado = 0;
                        //    }
                        //    //
                        //    int cantidad;
                        //    for (int i = 0; i < idsPaginas.Length; i++)
                        //    {
                        //        cantidad = lista.Where(p => p.IdPagina == int.Parse(idsPaginas[i])).Count();
                        //        //si es = a 0 es porque no existe y debemos registrarlo
                        //        if (cantidad == 0)
                        //        {
                        //            Paginaxrol oPaginaxrol = new Paginaxrol();
                        //            oPaginaxrol.IdPagina = int.Parse(idsPaginas[i]);
                        //            oPaginaxrol.IdRol = oRolCLS.IidRol;
                        //            oPaginaxrol.Bhabilitado = 1;
                        //            bd.Paginaxrol.Add(oPaginaxrol);
                        //        }
                        //        else
                        //        {
                        //            Paginaxrol PxR = lista.Where(p => p.IdPagina == int.Parse(idsPaginas[i])).First();
                        //            PxR.Bhabilitado = 1;
                        //        }
                        //    }
                        //    bd.SaveChanges();
                        //    transaccion.Complete();
                        //    rpta = 1;

                        //}
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                rpta = 0;
            }
            return rpta;
        }


        //A partir de aqui termina todo
    }
}
