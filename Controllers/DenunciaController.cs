using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MUNICIPALIDAD_V4.clases;
using MUNICIPALIDAD_V4.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace MUNICIPALIDAD_V4.Controllers
{
    public class DenunciaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("api/Denuncia/listarTiposDenuncia")]
        public IEnumerable<TipoDenunciaCLS> listarTiposDenuncia()
        {
            List<TipoDenunciaCLS> listaTipoDenuncia;
            using (M_VPSA_V3Context bd = new M_VPSA_V3Context())
            {

                listaTipoDenuncia = (from TipoDenuncia in bd.TipoDenuncia
                                     where TipoDenuncia.Bhabilitado == 1
                                     select new TipoDenunciaCLS
                                     {
                                         Cod_Tipo_Denuncia = TipoDenuncia.CodTipoDenuncia,
                                         Nombre = TipoDenuncia.Nombre,
                                         Tiempo_Max_Tratamiento = (int)TipoDenuncia.TiempoMaxTratamiento,
                                         Descripcion = TipoDenuncia.Descripcion

                                     }).ToList();
                return listaTipoDenuncia;
            }

        }

        [HttpGet]
        [Route("api/Denuncia/listarEstadosDenuncia")]
        public IEnumerable<DenunciaCLS> listarEstadosDenuncia()
        {
            List<DenunciaCLS> listaEstadoDenuncia;
            using (M_VPSA_V3Context bd = new M_VPSA_V3Context())
            {

                listaEstadoDenuncia = (from EstadoDenuncia in bd.EstadoDenuncia
                                       where EstadoDenuncia.Bhabilitado == 1
                                       select new DenunciaCLS
                                       {
                                           cod_Estado_Denuncia = EstadoDenuncia.CodEstadoDenuncia,
                                           nombre = EstadoDenuncia.Nombre,
                                           bHabilitado = (int)EstadoDenuncia.Bhabilitado,
                                           descripcion = EstadoDenuncia.Descripcion

                                       }).ToList();
                return listaEstadoDenuncia;
            }

        }

        [HttpGet]
        [Route("api/Denuncia/listarDenuncias")]
        public IEnumerable<DenunciaCLS2> listarDenuncias()
        {
            using (M_VPSA_V3Context bd = new M_VPSA_V3Context())
            {
                Prioridad oPriorodad = new Prioridad();
                UsuarioCLS usuarioCLS = new UsuarioCLS();

                List<DenunciaCLS2> listaDenuncia = (from Denuncia in bd.Denuncia
                                                    join EstadoDenuncia in bd.EstadoDenuncia
                                                   on Denuncia.CodEstadoDenuncia equals EstadoDenuncia.CodEstadoDenuncia
                                                    join TipoDenuncia in bd.TipoDenuncia
                                                    on Denuncia.CodTipoDenuncia equals TipoDenuncia.CodTipoDenuncia
                                                    join Prioridad in bd.Prioridad
                                                    on Denuncia.NroPrioridad equals Prioridad.NroPrioridad
                                                    join Usuario in bd.Usuario
                                                    on Denuncia.IdUsuario equals Usuario.IdUsuario
                                                    where Denuncia.Bhabilitado == 1
                                                    select new DenunciaCLS2
                                                    {
                                                        Nro_Denuncia = Denuncia.NroDenuncia,
                                                        Fecha = (DateTime)Denuncia.Fecha,
                                                        Estado_Denuncia = EstadoDenuncia.Nombre,
                                                        Tipo_Denuncia = TipoDenuncia.Nombre,
                                                        Prioridad = Prioridad.NombrePrioridad,
                                                        IdUsuario = (int)((Denuncia.IdUsuario.HasValue) ? Denuncia.IdUsuario : 0),
                                                        NombreUser = (string)Usuario.NombreUser

                                                    }).ToList();
                return listaDenuncia;
            }

        }
        [HttpPost]
        [Route("api/Denuncia/guardarDenuncia")]
        public int guardarDenuncia([FromBody] DenunciaCLS2 DenunciaCLS2)
        {
            int rpta = 0;
            try
            {
                using (M_VPSA_V3Context bd = new M_VPSA_V3Context())
                {
                    //Usaremos transacciones porque tocaremos dos tablas imultaneamente.
                    using (var transaccion = new TransactionScope())
                    {
                        Denuncia oDenuncia = new Denuncia();
                        //Usuario oUsuario = new Usuario();
                        // oDenuncia.NroDenuncia = Denuncia.Nro_Denuncia; // es identity en el bakend no es necesario
                        oDenuncia.CodTipoDenuncia = int.Parse(DenunciaCLS2.Tipo_Denuncia);
                        oDenuncia.Calle = DenunciaCLS2.Calle;
                        oDenuncia.Altura = DenunciaCLS2.Altura;
                        oDenuncia.EntreCalles = DenunciaCLS2.Entre_Calles;
                        oDenuncia.NombreInfractor = DenunciaCLS2.Nombre_Infractor;
                        oDenuncia.ApellidoInfractor = DenunciaCLS2.Apellido_Infractor;
                        oDenuncia.CodEstadoDenuncia = 3;
                        oDenuncia.Descripcion = DenunciaCLS2.Descripcion;
                        oDenuncia.MailNotificacion = DenunciaCLS2.Mail_Notificacion;
                        oDenuncia.MovilNotificacion = DenunciaCLS2.Movil_Notificacion;
                        oDenuncia.NroPrioridad = 4;
                        // oUsuario = bd.Usuario.Where(u => u.NombreUser.Contains("Sin Asignar")).First();

                        oDenuncia.IdUsuario = 2;  //oUsuario.IdUsuario;
                                                  //oDenuncia.IdUsuario = AÑADIR FUNCIONALIDAD PARA CUANDO EL VECINO ESTA LOGUEADO
                        oDenuncia.Bhabilitado = 1;
                        bd.Denuncia.Add(oDenuncia);
                        int NroDenunciaTemp = oDenuncia.NroDenuncia;
                        if (DenunciaCLS2.Foto != null)
                        {
                            PruebaGraficaDenuncia oPrueba = new PruebaGraficaDenuncia();
                            oPrueba.Foto = DenunciaCLS2.Foto;
                            oPrueba.NroDenuncia = NroDenunciaTemp;
                            oPrueba.Bhabilitado = 1;

                            bd.PruebaGraficaDenuncia.Add(oPrueba);
                        }
                        if (DenunciaCLS2.Foto2 != null)
                        {
                            PruebaGraficaDenuncia oPrueba = new PruebaGraficaDenuncia();
                            oPrueba.Foto = DenunciaCLS2.Foto2;
                            oPrueba.NroDenuncia = NroDenunciaTemp;
                            oPrueba.Bhabilitado = 1;
                            bd.PruebaGraficaDenuncia.Add(oPrueba);
                        }
                        if (DenunciaCLS2.Foto3 != null)
                        {
                            PruebaGraficaDenuncia oPrueba = new PruebaGraficaDenuncia();
                            oPrueba.Foto = DenunciaCLS2.Foto3;
                            oPrueba.NroDenuncia = NroDenunciaTemp;
                            oPrueba.Bhabilitado = 1;
                            bd.PruebaGraficaDenuncia.Add(oPrueba);

                        }
                        bd.SaveChanges();
                        transaccion.Complete();

                        // oDenuncia = bd.Denuncia.Where(d => d.NroDenuncia == DenunciaCLS.NroDenuncia).First();


                    } //Fin de La Transaccion
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

        [HttpPost]
        [Route("api/Denuncia/DerivaPriorizaDenuncia")]
        public int DerivaPriorizaDenuncia([FromBody] DenunciaCLS2 DenunciaCLS2)
        {
            int rpta = 0;
            try
            {
                using (M_VPSA_V3Context bd = new M_VPSA_V3Context())
                {

                    Denuncia oDenuncia = bd.Denuncia.Where(d => d.NroDenuncia == DenunciaCLS2.Nro_Denuncia).First();
                    // oDenuncia.CodTipoDenuncia = int.Parse(DenunciaCLS2.Tipo_Denuncia);
                    oDenuncia.CodEstadoDenuncia = 2;
                    oDenuncia.NroPrioridad = DenunciaCLS2.Nro_Prioridad;
                    oDenuncia.IdUsuario = DenunciaCLS2.IdUsuario;
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


        [HttpPost]
        [Route("api/Denuncia/solucionarDenuncia")]
        public int solucionarDenuncia([FromBody] TrabajoCLS oTrabajoCLS)
        {
            int rpta = 0;
            try
            {
                int idTipoRol = int.Parse(HttpContext.Session.GetString("tipoEmpleado"));
                if (idTipoRol == 5)
                {
                    using (M_VPSA_V3Context bd = new M_VPSA_V3Context())
                    {
                        Denuncia oDenuncia = bd.Denuncia.Where(d => d.NroDenuncia == oTrabajoCLS.Nro_Denuncia).First();
                        oDenuncia.CodEstadoDenuncia = 10;
                        oDenuncia.Bhabilitado = 0;
                        bd.SaveChanges();

                    }
                    rpta = 1;
                }
                else
                {
                    using (M_VPSA_V3Context bd = new M_VPSA_V3Context())
                    {
                        Denuncia oDenuncia = bd.Denuncia.Where(d => d.NroDenuncia == oTrabajoCLS.Nro_Denuncia).First();
                        oDenuncia.CodEstadoDenuncia = 9;
                        bd.SaveChanges();

                    }
                    rpta = 1;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                rpta = 0;
            }
            return rpta;
        }



        [HttpPost]
        [Route("api/Denuncia/devolverAMEsa")]  ///{nroDenuncia} [FromBody]{id}
        public int devolverAMEsa([FromBody] TrabajoCLS oTrabajoCLS)
        {
            int rpta = 0;
            try
            {
                using (M_VPSA_V3Context bd = new M_VPSA_V3Context())
                {

                    Denuncia oDenuncia = bd.Denuncia.Where(d => d.NroDenuncia == oTrabajoCLS.Nro_Denuncia).First();
                    oDenuncia.CodEstadoDenuncia = 8;
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
        [Route("api/Denuncia/DenunciasxEmpleado")]
        public ChartDenuncia DenunciasxEmpleado()
        {
            using (M_VPSA_V3Context bd = new M_VPSA_V3Context())
            {
                ChartDenuncia oChartEmpleado = new ChartDenuncia();
                oChartEmpleado.IdUsuario = (int)(int.Parse(HttpContext.Session.GetString("empleado")));

                oChartEmpleado.totalDenunAsignaEmpleado = (from denuncia in bd.Denuncia
                                                           join usuario in bd.Usuario
                                                           on denuncia.IdUsuario equals usuario.IdUsuario
                                                           where denuncia.Bhabilitado == 1
                                                           && denuncia.IdUsuario == oChartEmpleado.IdUsuario
                                                           select new DenunciaCLS2
                                                           {
                                                               Nro_Denuncia = (int)denuncia.NroDenuncia,
                                                               IdUsuario = (int)(denuncia.IdUsuario),
                                                           }).Count();

                oChartEmpleado.totalDenuncias = (from denuncia in bd.Denuncia
                                                 where denuncia.Bhabilitado == 1
                                                 select new DenunciaCLS2
                                                 {
                                                     Nro_Denuncia = (int)denuncia.NroDenuncia,
                                                 }).Count();

                if (oChartEmpleado.totalDenunAsignaEmpleado > 0)
                {
                    Usuario oUsuario = (from denuncia in bd.Denuncia
                                        join usuario in bd.Usuario
                                        on denuncia.IdUsuario equals usuario.IdUsuario
                                        where denuncia.Bhabilitado == 1
                                        && denuncia.IdUsuario == oChartEmpleado.IdUsuario
                                        select new Usuario
                                        {
                                            NombreUser = usuario.NombreUser
                                        }).First();
                    oChartEmpleado.nombreEmpleado = oUsuario.NombreUser;
                }
                else
                {
                    oChartEmpleado.nombreEmpleado = "";
                }
                return oChartEmpleado;
            }
        }







    } //Cierre de la Clase


}
