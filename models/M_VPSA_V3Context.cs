using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MUNICIPALIDAD_V4.models
{
    public partial class M_VPSA_V3Context : DbContext
    {
        public M_VPSA_V3Context()
        {
        }

        public M_VPSA_V3Context(DbContextOptions<M_VPSA_V3Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Boleta> Boleta { get; set; }
        public virtual DbSet<ControlProcesos> ControlProcesos { get; set; }
        public virtual DbSet<Denuncia> Denuncia { get; set; }
        public virtual DbSet<Detalleboleta> Detalleboleta { get; set; }
        public virtual DbSet<EstadoDenuncia> EstadoDenuncia { get; set; }
        public virtual DbSet<EstadoReclamo> EstadoReclamo { get; set; }
        public virtual DbSet<EstadoSolicitud> EstadoSolicitud { get; set; }
        public virtual DbSet<Impuestoinmobiliario> Impuestoinmobiliario { get; set; }
        public virtual DbSet<Lote> Lote { get; set; }
        public virtual DbSet<Pagina> Pagina { get; set; }
        public virtual DbSet<Paginaxrol> Paginaxrol { get; set; }
        public virtual DbSet<Pago> Pago { get; set; }
        public virtual DbSet<ParametriaProcesos> ParametriaProcesos { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<Prioridad> Prioridad { get; set; }
        public virtual DbSet<PrioridadReclamo> PrioridadReclamo { get; set; }
        public virtual DbSet<PruebaGraficaDenuncia> PruebaGraficaDenuncia { get; set; }
        public virtual DbSet<PruebaGraficaReclamo> PruebaGraficaReclamo { get; set; }
        public virtual DbSet<Reclamo> Reclamo { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<Sesiones> Sesiones { get; set; }
        public virtual DbSet<Solicitud> Solicitud { get; set; }
        public virtual DbSet<TipoDenuncia> TipoDenuncia { get; set; }
        public virtual DbSet<Tipopago> Tipopago { get; set; }
        public virtual DbSet<TipoReclamo> TipoReclamo { get; set; }
        public virtual DbSet<TipoSolicitud> TipoSolicitud { get; set; }
        public virtual DbSet<Trabajo> Trabajo { get; set; }
        public virtual DbSet<TrabajoReclamo> TrabajoReclamo { get; set; }
        public virtual DbSet<TrabajoSolicitud> TrabajoSolicitud { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<UsuarioVecino> UsuarioVecino { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Data Source=DESKTOP-THJSEM4;Initial Catalog=M_VPSA_V3;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Boleta>(entity =>
            {
                entity.HasKey(e => e.IdBoleta);

                entity.ToTable("BOLETA");

                entity.Property(e => e.Bhabilitado).HasColumnName("BHabilitado");

                entity.Property(e => e.FechaGenerada)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaPago).HasColumnType("datetime");

                entity.Property(e => e.FechaVencimiento)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(dateadd(day,(1),getdate()))");

                entity.Property(e => e.Importe)
                    .HasColumnName("importe")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TipoMoneda)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasMaxLength(350)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ControlProcesos>(entity =>
            {
                entity.HasKey(e => e.IdEjecucion);

                entity.ToTable("CONTROL_PROCESOS");

                entity.Property(e => e.FechaEjecucion)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdProcesoNavigation)
                    .WithMany(p => p.ControlProcesos)
                    .HasForeignKey(d => d.IdProceso)
                    .HasConstraintName("FK__CONTROL_P__IdPro__1975C517");
            });

            modelBuilder.Entity<Denuncia>(entity =>
            {
                entity.HasKey(e => e.NroDenuncia);

                entity.ToTable("DENUNCIA");

                entity.Property(e => e.NroDenuncia).HasColumnName("Nro_Denuncia");

                entity.Property(e => e.Altura)
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.Property(e => e.ApellidoInfractor)
                    .HasColumnName("Apellido_Infractor")
                    .HasMaxLength(75)
                    .IsUnicode(false);

                entity.Property(e => e.Bhabilitado).HasColumnName("BHabilitado");

                entity.Property(e => e.Calle)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CodEstadoDenuncia).HasColumnName("Cod_Estado_Denuncia");

                entity.Property(e => e.CodTipoDenuncia).HasColumnName("Cod_Tipo_Denuncia");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(2500)
                    .IsUnicode(false);

                entity.Property(e => e.EntreCalles)
                    .HasColumnName("Entre_Calles")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.MailNotificacion)
                    .HasColumnName("Mail_Notificacion")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MovilNotificacion)
                    .HasColumnName("Movil_Notificacion")
                    .HasMaxLength(18)
                    .IsUnicode(false);

                entity.Property(e => e.NombreInfractor)
                    .HasColumnName("Nombre_Infractor")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.NroPrioridad).HasColumnName("Nro_Prioridad");

                entity.HasOne(d => d.CodEstadoDenunciaNavigation)
                    .WithMany(p => p.Denuncia)
                    .HasForeignKey(d => d.CodEstadoDenuncia)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__DENUNCIA__Cod_Es__3A81B327");

                entity.HasOne(d => d.CodTipoDenunciaNavigation)
                    .WithMany(p => p.Denuncia)
                    .HasForeignKey(d => d.CodTipoDenuncia)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__DENUNCIA__Cod_Ti__3B75D760");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Denuncia)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__DENUNCIA__IdUsua__3C69FB99");

                entity.HasOne(d => d.NroPrioridadNavigation)
                    .WithMany(p => p.Denuncia)
                    .HasForeignKey(d => d.NroPrioridad)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Prioridad");
            });

            modelBuilder.Entity<Detalleboleta>(entity =>
            {
                entity.HasKey(e => e.IdDetalleBoleta);

                entity.ToTable("DETALLEBOLETA");

                entity.Property(e => e.Bhabilitado).HasColumnName("BHabilitado");

                entity.Property(e => e.Importe).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdBoletaNavigation)
                    .WithMany(p => p.Detalleboleta)
                    .HasForeignKey(d => d.IdBoleta)
                    .HasConstraintName("FK__DETALLEBO__IdBol__7720AD13");

                entity.HasOne(d => d.IdImpuestoNavigation)
                    .WithMany(p => p.Detalleboleta)
                    .HasForeignKey(d => d.IdImpuesto)
                    .HasConstraintName("FK__DETALLEBO__IdImp__762C88DA");
            });

            modelBuilder.Entity<EstadoDenuncia>(entity =>
            {
                entity.HasKey(e => e.CodEstadoDenuncia);

                entity.ToTable("ESTADO_DENUNCIA");

                entity.Property(e => e.CodEstadoDenuncia).HasColumnName("Cod_Estado_Denuncia");

                entity.Property(e => e.Bhabilitado).HasColumnName("BHabilitado");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EstadoReclamo>(entity =>
            {
                entity.HasKey(e => e.CodEstadoReclamo);

                entity.ToTable("ESTADO_RECLAMO");

                entity.Property(e => e.CodEstadoReclamo).HasColumnName("Cod_Estado_Reclamo");

                entity.Property(e => e.Bhabilitado).HasColumnName("BHabilitado");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EstadoSolicitud>(entity =>
            {
                entity.HasKey(e => e.CodEstadoSolicitud);

                entity.ToTable("ESTADO_SOLICITUD");

                entity.Property(e => e.CodEstadoSolicitud).HasColumnName("Cod_Estado_Solicitud");

                entity.Property(e => e.Bhabilitado).HasColumnName("BHabilitado");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Impuestoinmobiliario>(entity =>
            {
                entity.HasKey(e => e.IdImpuesto);

                entity.ToTable("IMPUESTOINMOBILIARIO");

                entity.Property(e => e.Bhabilitado).HasColumnName("BHabilitado");

                entity.Property(e => e.FechaEmision).HasColumnType("datetime");

                entity.Property(e => e.FechaVencimiento).HasColumnType("datetime");

                entity.Property(e => e.ImporteBase).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ImporteFinal).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.InteresValor).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdLoteNavigation)
                    .WithMany(p => p.Impuestoinmobiliario)
                    .HasForeignKey(d => d.IdLote)
                    .HasConstraintName("FK__IMPUESTOI__IdLot__73501C2F");
            });

            modelBuilder.Entity<Lote>(entity =>
            {
                entity.HasKey(e => e.IdLote);

                entity.ToTable("LOTE");

                entity.Property(e => e.Altura)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BaseImponible).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Calle)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoInmueble)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IdPersona).HasColumnName("idPersona");

                entity.Property(e => e.NomenclaturaCatastral)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.SupEdificada).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.SupTerreno).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.TipoInmueble)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ValuacionTotal).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Lote)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__LOTE__idPersona__54CB950F");
            });

            modelBuilder.Entity<Pagina>(entity =>
            {
                entity.HasKey(e => e.IdPagina);

                entity.ToTable("PAGINA");

                entity.Property(e => e.Accion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Bvisible).HasColumnName("BVisible");

                entity.Property(e => e.Mensaje)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Paginaxrol>(entity =>
            {
                entity.HasKey(e => e.IdPaginaxRol);

                entity.ToTable("PAGINAXROL");

                entity.Property(e => e.Bhabilitado).HasColumnName("BHabilitado");

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.HasOne(d => d.IdPaginaNavigation)
                    .WithMany(p => p.Paginaxrol)
                    .HasForeignKey(d => d.IdPagina)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__PAGINAXRO__IdPag__3E52440B");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Paginaxrol)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("FK__PAGINAXRO__idRol__68487DD7");
            });

            modelBuilder.Entity<Pago>(entity =>
            {
                entity.HasKey(e => e.IdPago);

                entity.ToTable("PAGO");

                entity.Property(e => e.Bhabilitado).HasColumnName("BHabilitado");

                entity.Property(e => e.FechaDePago)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Importe).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdTipoPagoNavigation)
                    .WithMany(p => p.Pago)
                    .HasForeignKey(d => d.IdTipoPago)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__PAGO__IdTipoPago__6ABAD62E");
            });

            modelBuilder.Entity<ParametriaProcesos>(entity =>
            {
                entity.HasKey(e => e.IdProceso);

                entity.ToTable("PARAMETRIA_PROCESOS");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Periodicidad)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdPersona);

                entity.ToTable("PERSONA");

                entity.HasIndex(e => e.Mail)
                    .HasName("UQ__PERSONA__2724B2D1B54B986F")
                    .IsUnique();

                entity.Property(e => e.IdPersona).HasColumnName("idPersona");

                entity.Property(e => e.Altura)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Apellido)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Bhabilitado).HasColumnName("BHabilitado");

                entity.Property(e => e.BtieneUser).HasColumnName("BTieneUser");

                entity.Property(e => e.Cuil)
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.Property(e => e.Dni)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Domicilio)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaNac).HasColumnType("date");

                entity.Property(e => e.Mail)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Prioridad>(entity =>
            {
                entity.HasKey(e => e.NroPrioridad);

                entity.ToTable("PRIORIDAD");

                entity.Property(e => e.NroPrioridad).HasColumnName("Nro_Prioridad");

                entity.Property(e => e.Bhabilitado).HasColumnName("BHabilitado");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NombrePrioridad)
                    .HasColumnName("Nombre_Prioridad")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PrioridadReclamo>(entity =>
            {
                entity.HasKey(e => e.NroPrioridad);

                entity.ToTable("PRIORIDAD_RECLAMO");

                entity.Property(e => e.NroPrioridad).HasColumnName("Nro_Prioridad");

                entity.Property(e => e.Bhabilitado).HasColumnName("BHabilitado");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NombrePrioridad)
                    .HasColumnName("Nombre_Prioridad")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PruebaGraficaDenuncia>(entity =>
            {
                entity.HasKey(e => e.NroImagen);

                entity.ToTable("PRUEBA_GRAFICA_DENUNCIA");

                entity.Property(e => e.NroImagen).HasColumnName("Nro_Imagen");

                entity.Property(e => e.Bhabilitado).HasColumnName("BHabilitado");

                entity.Property(e => e.Foto)
                    .HasColumnName("foto")
                    .IsUnicode(false);

                entity.Property(e => e.NroDenuncia).HasColumnName("Nro_Denuncia");

                entity.Property(e => e.NroTrabajo)
                    .HasColumnName("Nro_Trabajo")
                    .HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.PruebaGraficaDenuncia)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__PRUEBA_GR__IdUsu__693CA210");

                entity.HasOne(d => d.NroDenunciaNavigation)
                    .WithMany(p => p.PruebaGraficaDenuncia)
                    .HasForeignKey(d => d.NroDenuncia)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__PRUEBA_GR__Nro_D__4222D4EF");

                entity.HasOne(d => d.NroTrabajoNavigation)
                    .WithMany(p => p.PruebaGraficaDenuncia)
                    .HasForeignKey(d => d.NroTrabajo)
                    .HasConstraintName("_PGD_FK_TRABAJO");
            });

            modelBuilder.Entity<PruebaGraficaReclamo>(entity =>
            {
                entity.HasKey(e => e.NroImagen);

                entity.ToTable("PRUEBA_GRAFICA_RECLAMO");

                entity.Property(e => e.NroImagen).HasColumnName("Nro_Imagen");

                entity.Property(e => e.Bhabilitado).HasColumnName("BHabilitado");

                entity.Property(e => e.NroReclamo).HasColumnName("Nro_Reclamo");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.PruebaGraficaReclamo)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__PRUEBA_GR__IdUsu__6B24EA82");

                entity.HasOne(d => d.IdVecinoNavigation)
                    .WithMany(p => p.PruebaGraficaReclamo)
                    .HasForeignKey(d => d.IdVecino)
                    .HasConstraintName("FK__PRUEBA_GR__IdVec__6C190EBB");

                entity.HasOne(d => d.NroReclamoNavigation)
                    .WithMany(p => p.PruebaGraficaReclamo)
                    .HasForeignKey(d => d.NroReclamo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__PRUEBA_GR__Nro_R__44FF419A");
            });

            modelBuilder.Entity<Reclamo>(entity =>
            {
                entity.HasKey(e => e.NroReclamo);

                entity.ToTable("RECLAMO");

                entity.Property(e => e.NroReclamo).HasColumnName("Nro_Reclamo");

                entity.Property(e => e.Altura)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Bhabilitado).HasColumnName("BHabilitado");

                entity.Property(e => e.Calle)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CodEstadoReclamo).HasColumnName("Cod_Estado_Reclamo");

                entity.Property(e => e.CodTipoReclamo).HasColumnName("Cod_Tipo_Reclamo");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(2500)
                    .IsUnicode(false);

                entity.Property(e => e.EntreCalles)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.CodEstadoReclamoNavigation)
                    .WithMany(p => p.Reclamo)
                    .HasForeignKey(d => d.CodEstadoReclamo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__RECLAMO__Cod_Est__45F365D3");

                entity.HasOne(d => d.CodTipoReclamoNavigation)
                    .WithMany(p => p.Reclamo)
                    .HasForeignKey(d => d.CodTipoReclamo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__RECLAMO__Cod_Tip__46E78A0C");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Reclamo)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__RECLAMO__IdUsuar__6FE99F9F");

                entity.HasOne(d => d.IdVecinoNavigation)
                    .WithMany(p => p.Reclamo)
                    .HasForeignKey(d => d.IdVecino)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__RECLAMO__IdVecin__48CFD27E");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol);

                entity.ToTable("ROL");

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.Property(e => e.Bhabilitado).HasColumnName("BHabilitado");

                entity.Property(e => e.NombreRol)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sesiones>(entity =>
            {
                entity.HasKey(e => e.IdSesion);

                entity.ToTable("SESIONES");

                entity.Property(e => e.IdSesion)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.FechaFin).HasColumnType("datetime");

                entity.Property(e => e.FechaInicio).HasColumnType("datetime");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Maquina)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Sesiones)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__SESIONES__idUsua__49C3F6B7");
            });

            modelBuilder.Entity<Solicitud>(entity =>
            {
                entity.HasKey(e => e.NroSolicitud);

                entity.ToTable("SOLICITUD");

                entity.Property(e => e.NroSolicitud).HasColumnName("Nro_Solicitud");

                entity.Property(e => e.Bhabilitado).HasColumnName("BHabilitado");

                entity.Property(e => e.CodEstadoSolicitud).HasColumnName("Cod_Estado_Solicitud");

                entity.Property(e => e.CodTipoSolicitud).HasColumnName("Cod_Tipo_Solicitud");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(2500)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.HasOne(d => d.CodEstadoSolicitudNavigation)
                    .WithMany(p => p.Solicitud)
                    .HasForeignKey(d => d.CodEstadoSolicitud)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__SOLICITUD__Cod_E__4865BE2A");

                entity.HasOne(d => d.CodTipoSolicitudNavigation)
                    .WithMany(p => p.Solicitud)
                    .HasForeignKey(d => d.CodTipoSolicitud)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__SOLICITUD__Cod_T__477199F1");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Solicitud)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__SOLICITUD__IdUsu__467D75B8");

                entity.HasOne(d => d.IdVecinoNavigation)
                    .WithMany(p => p.Solicitud)
                    .HasForeignKey(d => d.IdVecino)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__SOLICITUD__IdVec__4589517F");
            });

            modelBuilder.Entity<TipoDenuncia>(entity =>
            {
                entity.HasKey(e => e.CodTipoDenuncia);

                entity.ToTable("TIPO_DENUNCIA");

                entity.Property(e => e.CodTipoDenuncia).HasColumnName("Cod_Tipo_Denuncia");

                entity.Property(e => e.Bhabilitado).HasColumnName("BHabilitado");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(90)
                    .IsUnicode(false);

                entity.Property(e => e.TiempoMaxTratamiento).HasColumnName("Tiempo_Max_Tratamiento");
            });

            modelBuilder.Entity<Tipopago>(entity =>
            {
                entity.HasKey(e => e.IdTipoPago);

                entity.ToTable("TIPOPAGO");

                entity.Property(e => e.Bhabilitado).HasColumnName("BHabilitado");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoReclamo>(entity =>
            {
                entity.HasKey(e => e.CodTipoReclamo);

                entity.ToTable("TIPO_RECLAMO");

                entity.Property(e => e.CodTipoReclamo).HasColumnName("Cod_Tipo_Reclamo");

                entity.Property(e => e.Bhabilitado).HasColumnName("BHabilitado");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(90)
                    .IsUnicode(false);

                entity.Property(e => e.TiempoMaxTratamiento).HasColumnName("Tiempo_Max_Tratamiento");
            });

            modelBuilder.Entity<TipoSolicitud>(entity =>
            {
                entity.HasKey(e => e.CodTipoSolicitud);

                entity.ToTable("TIPO_SOLICITUD");

                entity.Property(e => e.CodTipoSolicitud).HasColumnName("Cod_Tipo_Solicitud");

                entity.Property(e => e.Bhabilitado).HasColumnName("BHabilitado");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(90)
                    .IsUnicode(false);

                entity.Property(e => e.TiempoMaxTratamiento).HasColumnName("Tiempo_Max_Tratamiento");
            });

            modelBuilder.Entity<Trabajo>(entity =>
            {
                entity.HasKey(e => e.NroTrabajo);

                entity.ToTable("TRABAJO");

                entity.Property(e => e.NroTrabajo).HasColumnName("Nro_trabajo");

                entity.Property(e => e.Bhabilitado).HasColumnName("BHabilitado");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(2500)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NroDenuncia).HasColumnName("Nro_Denuncia");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Trabajo)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__TRABAJO__IdUsuar__72C60C4A");

                entity.HasOne(d => d.NroDenunciaNavigation)
                    .WithMany(p => p.Trabajo)
                    .HasForeignKey(d => d.NroDenuncia)
                    .HasConstraintName("FK__TRABAJO__Nro_Den__4BAC3F29");
            });

            modelBuilder.Entity<TrabajoReclamo>(entity =>
            {
                entity.HasKey(e => e.NroTrabajo);

                entity.ToTable("TRABAJO_RECLAMO");

                entity.Property(e => e.NroTrabajo).HasColumnName("Nro_trabajo");

                entity.Property(e => e.Bhabilitado).HasColumnName("BHabilitado");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(2500)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NroReclamo).HasColumnName("Nro_Reclamo");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.TrabajoReclamo)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__TRABAJO_R__IdUsu__74AE54BC");

                entity.HasOne(d => d.IdVecinoNavigation)
                    .WithMany(p => p.TrabajoReclamo)
                    .HasForeignKey(d => d.IdVecino)
                    .HasConstraintName("FK__TRABAJO_R__IdVec__75A278F5");

                entity.HasOne(d => d.NroReclamoNavigation)
                    .WithMany(p => p.TrabajoReclamo)
                    .HasForeignKey(d => d.NroReclamo)
                    .HasConstraintName("FK__TRABAJO_R__Nro_R__4E88ABD4");
            });

            modelBuilder.Entity<TrabajoSolicitud>(entity =>
            {
                entity.HasKey(e => e.NroTrabajo);

                entity.ToTable("TRABAJO_SOLICITUD");

                entity.Property(e => e.NroTrabajo).HasColumnName("Nro_trabajo");

                entity.Property(e => e.Bhabilitado).HasColumnName("BHabilitado");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(2500)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NroSolicitud).HasColumnName("Nro_Solicitud");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.TrabajoSolicitud)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__TRABAJO_S__IdUsu__4D2A7347");

                entity.HasOne(d => d.IdVecinoNavigation)
                    .WithMany(p => p.TrabajoSolicitud)
                    .HasForeignKey(d => d.IdVecino)
                    .HasConstraintName("FK__TRABAJO_S__IdVec__4E1E9780");

                entity.HasOne(d => d.NroSolicitudNavigation)
                    .WithMany(p => p.TrabajoSolicitud)
                    .HasForeignKey(d => d.NroSolicitud)
                    .HasConstraintName("FK__TRABAJO_S__Nro_S__4C364F0E");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("USUARIO");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Bhabilitado).HasColumnName("BHabilitado");

                entity.Property(e => e.Contrasenia)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaAlta)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaBaja).HasColumnType("date");

                entity.Property(e => e.IdPersona).HasColumnName("idPersona");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.NombreUser)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__USUARIO__idPerso__4F7CD00D");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK__USUARIO__idTipoU__787EE5A0");
            });

            modelBuilder.Entity<UsuarioVecino>(entity =>
            {
                entity.HasKey(e => e.IdVecino);

                entity.ToTable("USUARIO_VECINO");

                entity.Property(e => e.IdVecino).HasColumnName("idVecino");

                entity.Property(e => e.Bhabilitado).HasColumnName("BHabilitado");

                entity.Property(e => e.Contrasenia)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FechaAlta)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaBaja).HasColumnType("date");

                entity.Property(e => e.IdPersona).HasColumnName("idPersona");

                entity.Property(e => e.NombreUser)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithMany(p => p.UsuarioVecino)
                    .HasForeignKey(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__USUARIO_V__idPer__5165187F");
            });
        }
    }
}
