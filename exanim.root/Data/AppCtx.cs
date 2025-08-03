using exanim.core.Entities;
using Microsoft.EntityFrameworkCore;

namespace exanim.root.Data;

public class AppCtx : DbContext
{
    public AppCtx(DbContextOptions<AppCtx> options) : base(options)
    {
        base.Database.EnsureDeleted();
    }

    public DbSet<Brand> Brands { get; set; }
    public DbSet<CFAgencia> Agencias { get; set; }
    public DbSet<CFConfigura> Configuraciones { get; set; }
    public DbSet<CFOperador> Operadores { get; set; }
    public DbSet<CFParametro> Parametros { get; set; }
    public DbSet<CFPerfil> Perfiles { get; set; }
    public DbSet<CFTaller> Talleres { get; set; }
    public DbSet<CFUsuario> Usuarios { get; set; }
    public DbSet<OPAccion> Acciones { get; set; }
    public DbSet<OPAutoriza> Autorizaciones { get; set; }
    public DbSet<OPAvance> Avances { get; set; }
    public DbSet<OPClase> Clases { get; set; }
    public DbSet<OPEstatus> Estatus { get; set; }
    public DbSet<OPInstalacion> Instalaciones { get; set; }
    public DbSet<OPOrden> Ordenes { get; set; }
    public DbSet<OPPaso> Pasos { get; set; }
    public DbSet<OPPieza> Piezas { get; set; }
    public DbSet<OPRemocion> Remociones { get; set; }
    public DbSet<VECompania> Companias { get; set; }
    public DbSet<VECotizacion> Cotizaciones { get; set; }
    public DbSet<VEGestor> Gestores { get; set; }
    public DbSet<VELinea> Lineas { get; set; }
    public DbSet<VEUnidad> Unidades { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.BrandId)
                .HasName("PK_Brand");
            entity.ToTable("Brand");

            entity.Property(e => e.Name).HasMaxLength(30)
                .IsUnicode(false).IsRequired();
            
            entity.HasMany<VEUnidad>()
                .WithOne()
                .HasForeignKey(e => e.MarcaId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        });

        modelBuilder.Entity<CFAgencia>(entity =>
        {
            entity.HasKey(e => e.AgenciaId)
                .HasName("PK_CFAgencia");
            entity.ToTable("CFAgencia");

            entity.Property(e => e.RFC).HasMaxLength(13)
                .IsUnicode(false).IsRequired();
            entity.Property(e => e.RazonSocial).HasMaxLength(150)
                .IsUnicode(false).IsRequired();
            entity.Property(e => e.Nombre).HasMaxLength(50)
                .IsUnicode(false).IsRequired();

            entity.HasMany<CFConfigura>()
                .WithOne()
                .HasForeignKey(e => e.AgenciaId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
            entity.HasMany<CFOperador>()
                .WithOne()
                .HasForeignKey(e => e.AgenciaId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
            entity.HasMany<CFTaller>()
                .WithOne()
                .HasForeignKey(e => e.AgenciaId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
            entity.HasMany<OPClase>()
                .WithOne()
                .HasForeignKey(e => e.AgenciaId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
            entity.HasMany<OPEstatus>()
                .WithOne()
                .HasForeignKey(e => e.AgenciaId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
            entity.HasMany<OPPieza>()
                .WithOne()
                .HasForeignKey(e => e.AgenciaId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
            entity.HasMany<VECotizacion>()
                .WithOne()
                .HasForeignKey(e => e.AgenciaId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        });

        modelBuilder.Entity<CFConfigura>(entity =>
        {
            entity.HasKey(e => new { e.AgenciaId, e.ParametroId })
                .HasName("PK_CFConfigura");
            entity.ToTable("CFConfigura");

            entity.Property(e => e.Cadena).HasMaxLength(300)
                .IsUnicode(false).IsRequired();
        });

        modelBuilder.Entity<CFOperador>(entity =>
        {
            entity.HasKey(e => e.OperadorId)
                .HasName("PK_CFOperador");
            entity.ToTable("CFOperador");

            entity.Property(e => e.Fecha).HasColumnType("datetime");
        });

        modelBuilder.Entity<CFParametro>(entity =>
        {
            entity.HasKey(e => e.ParametroId)
                .HasName("PK_CFParametro");
            entity.ToTable("CFParametro");

            entity.Property(e => e.Clave).HasMaxLength(10)
                .IsUnicode(false).IsRequired();
            entity.Property(e => e.Nombre).HasMaxLength(100)
                .IsUnicode(false).IsRequired();

            entity.HasMany<CFConfigura>()
                .WithOne()
                .HasForeignKey(e => e.ParametroId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        });

        modelBuilder.Entity<CFPerfil>(entity =>
        {
            entity.HasKey(e => e.PerfilId)
                .HasName("PK_CFPerfil");
            entity.ToTable("CFPerfil");

            entity.Property(e => e.Nombre).HasMaxLength(15)
                .IsUnicode(false).IsRequired();

            entity.HasMany<CFUsuario>()
                .WithOne()
                .HasForeignKey(e => e.PerfilId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        });

        modelBuilder.Entity<CFTaller>(entity =>
        {
            entity.HasKey(e => e.TallerId)
                .HasName("PK_CFTaller");
            entity.ToTable("CFTaller");

            entity.Property(e => e.Codigo).HasMaxLength(15)
                .IsUnicode(false).IsRequired();
            entity.Property(e => e.Nombre).HasMaxLength(50)
                .IsUnicode(false).IsRequired();
            entity.Property(e => e.Direccion).HasMaxLength(150)
                .IsUnicode(false).IsRequired();
            entity.OwnsOne(e => e.Lugar, p =>
            {
                p.ToJson();
                p.Property(x => x.Lat);
                p.Property(x => x.Lng);
            });

            entity.HasMany<OPOrden>()
                .WithOne()
                .HasForeignKey(e => e.TallerId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        });

        modelBuilder.Entity<CFUsuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId)
                .HasName("PK_CFUsuario");
            entity.ToTable("CFUsuario");

            entity.Property(e => e.Nombre).HasMaxLength(150)
                .IsUnicode(false).IsRequired();
            entity.Property(e => e.Usuario).HasMaxLength(20)
                .IsUnicode(false).IsRequired();
            entity.Property(e => e.Password).HasMaxLength(300)
                .IsUnicode(false).IsRequired();
            entity.Property(e => e.Correo).HasMaxLength(150)
                .IsUnicode(false).IsRequired();

            entity.HasMany<CFAgencia>()
                .WithOne()
                .HasForeignKey(e => e.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
            entity.HasMany<CFOperador>()
                .WithOne()
                .HasForeignKey(e => e.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
            entity.HasMany<CFTaller>()
                .WithOne()
                .HasForeignKey(e => e.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
            entity.HasMany<OPAvance>()
                .WithOne()
                .HasForeignKey(e => e.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
            entity.HasMany<OPOrden>()
                .WithOne()
                .HasForeignKey(e => e.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
            entity.HasMany<OPPieza>()
                .WithOne()
                .HasForeignKey(e => e.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
            entity.HasMany<VECotizacion>()
                .WithOne()
                .HasForeignKey(e => e.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
            entity.HasMany<VEGestor>()
                .WithOne()
                .HasForeignKey(e => e.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        });

        modelBuilder.Entity<OPAccion>(entity =>
        {
            entity.HasKey(e => e.AccionId)
                .HasName("PK_OPAccion");
            entity.ToTable("OPAccion");

            entity.HasMany<OPAutoriza>()
                .WithOne()
                .HasForeignKey(e => e.AccionId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        });

        modelBuilder.Entity<OPAutoriza>(entity =>
        {
            entity.HasKey(e => e.AutorizaId)
                .HasName("PK_OPAutoriza");
            entity.ToTable("OPAutoriza");

            entity.Property(e => e.Comentario).HasMaxLength(300)
                .IsUnicode(false).IsRequired();
        });

        modelBuilder.Entity<OPAvance>(entity =>
        {
            entity.HasKey(e => e.AvanceId)
                .HasName("PK_OPAvance");
            entity.ToTable("OPAvance");

            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Anotacion).HasMaxLength(60)
                .IsUnicode(false).IsRequired();
            entity.Property(e => e.Comentario).HasMaxLength(300)
                .IsUnicode(false).IsRequired();

            entity.HasMany<OPAutoriza>()
                .WithOne()
                .HasForeignKey(e => e.AccionId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        });

        modelBuilder.Entity<OPClase>(entity =>
        {
            entity.HasKey(e => e.ClaseId)
                .HasName("PK_OPClase");
            entity.ToTable("OPClase");

            entity.Property(e => e.Nombre).HasMaxLength(50)
                .IsUnicode(false).IsRequired();

            entity.HasMany<OPPieza>()
                .WithOne()
                .HasForeignKey(e => e.ClaseId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        });

        modelBuilder.Entity<OPEstatus>(entity =>
        {
            entity.HasKey(e => e.EstatusId)
                .HasName("PK_OPEstatus");
            entity.ToTable("OPEstatus");

            entity.Property(e => e.Nombre).HasMaxLength(30)
                .IsUnicode(false).IsRequired();
            entity.Property(e => e.Code).HasMaxLength(15)
                .IsUnicode(false).IsRequired();

            entity.HasMany<OPAvance>()
                .WithOne()
                .HasForeignKey(e => e.EstatusId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
            entity.HasMany<OPOrden>()
                .WithOne()
                .HasForeignKey(e => e.EstatusId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
            entity.HasMany<OPPaso>()
                .WithOne()
                .HasForeignKey(e => e.PrevioId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
            entity.HasMany<OPPaso>()
                .WithOne()
                .HasForeignKey(e => e.AvanzaId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        });

        modelBuilder.Entity<OPInstalacion>(entity =>
        {
            entity.HasKey(e => e.InstalacionId)
                .HasName("PK_OPInstalacion");
            entity.ToTable("OPInstalacion");

            entity.Property(e => e.Marca).HasMaxLength(60)
                .IsUnicode(false).IsRequired();
            entity.Property(e => e.Serie).HasMaxLength(30)
                .IsUnicode(false).IsRequired();
            entity.Property(e => e.Comentario).HasMaxLength(120)
                .IsUnicode(false).IsRequired();
            entity.Property(e => e.Fecha).HasColumnType("datetime");
        });

        modelBuilder.Entity<OPOrden>(entity =>
        {
            entity.HasKey(e => e.OrdenId)
                .HasName("PK_OPOrden");
            entity.ToTable("OPOrden");

            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Problema).HasMaxLength(500)
                .IsUnicode(false).IsRequired();
            entity.Property(e => e.Condicion).HasMaxLength(500)
                .IsUnicode(false).IsRequired();
            entity.Property(e => e.Correo).HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.FechaEntrega).HasColumnType("datetime");

            entity.HasMany<OPAvance>()
                .WithOne()
                .HasForeignKey(e => e.OrdenId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
            entity.HasMany<OPInstalacion>()
                .WithOne()
                .HasForeignKey(e => e.OrdenId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
            entity.HasMany<OPRemocion>()
                .WithOne()
                .HasForeignKey(e => e.OrdenId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        });

        modelBuilder.Entity<OPPaso>(entity =>
        {
            entity.HasKey(e => e.PasoId)
                .HasName("PK_OPPaso");
            entity.ToTable("OPPaso");

            entity.HasMany<OPAccion>()
                .WithOne()
                .HasForeignKey(e => e.PasoId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        });

        modelBuilder.Entity<OPPieza>(entity =>
        {
            entity.HasKey(e => e.PiezaId)
                .HasName("PK_OPPieza");
            entity.ToTable("OPPieza");

            entity.Property(e => e.Nombre).HasMaxLength(150)
                .IsUnicode(false).IsRequired();

            entity.HasMany<OPInstalacion>()
                .WithOne()
                .HasForeignKey(e => e.PiezaId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
            entity.HasMany<OPRemocion>()
                .WithOne()
                .HasForeignKey(e => e.PiezaId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        });

        modelBuilder.Entity<OPRemocion>(entity =>
        {
            entity.HasKey(e => e.RemocionId)
                .HasName("PK_OPRemocion");
            entity.ToTable("OPRemocion");

            entity.Property(e => e.Marca).HasMaxLength(50)
                .IsUnicode(false).IsRequired();
            entity.Property(e => e.Serie).HasMaxLength(30)
                .IsUnicode(false).IsRequired();
            entity.Property(e => e.Comentario).HasMaxLength(120)
                .IsUnicode(false).IsRequired();
            entity.Property(e => e.Fecha).HasColumnType("datetime");
        });

        modelBuilder.Entity<VECompania>(entity =>
        {
            entity.HasKey(e => e.CompaniaId)
                .HasName("PK_VECompania");
            entity.ToTable("VECompania");

            entity.Property(e => e.RFC).HasMaxLength(13)
                .IsUnicode(false).IsRequired();
            entity.Property(e => e.RazonSocial).HasMaxLength(150)
                .IsUnicode(false).IsRequired();
            entity.Property(e => e.Nombre).HasMaxLength(50)
                .IsUnicode(false).IsRequired();

            entity.HasMany<VEGestor>()
                .WithOne()
                .HasForeignKey(e => e.CompaniaId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        });

        modelBuilder.Entity<VECotizacion>(entity =>
        {
            entity.HasKey(e => e.CotizacionId)
                .HasName("PK_VECotizacion");
            entity.ToTable("VECotizacion");

            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Clave).HasMaxLength(20)
                .IsUnicode(false).IsRequired();
            entity.Property(e => e.Vigencia).HasColumnType("datetime");

            entity.HasMany<VELinea>()
                .WithOne()
                .HasForeignKey(e => e.CotizacionId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        });

        modelBuilder.Entity<VEGestor>(entity =>
        {
            entity.HasKey(e => e.GestorId)
                .HasName("PK_VEGestor");
            entity.ToTable("VEGestor");

            entity.HasMany<OPOrden>()
                .WithOne()
                .HasForeignKey(e => e.GestorId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        });

        modelBuilder.Entity<VELinea>(entity =>
        {
            entity.HasKey(e => e.LineaId)
                .HasName("PK_VELinea");
            entity.ToTable("VELinea");

            entity.Property(e => e.Clave).HasMaxLength(20)
                .IsUnicode(false).IsRequired();
            entity.Property(e => e.Unidad).HasMaxLength(15)
                .IsUnicode(false).IsRequired();
            entity.Property(e => e.Concepto).HasMaxLength(500)
                .IsUnicode(false).IsRequired();
        });

        modelBuilder.Entity<VEUnidad>(entity =>
        {
            entity.HasKey(e => e.UnidadId).HasName("PK_VEUnidad");
            entity.ToTable("VEUnidad");

            entity.Property(e => e.Placa).HasMaxLength(15)
                .IsUnicode(false).IsRequired();
            entity.Property(e => e.Modelo).HasMaxLength(30)
                .IsUnicode(false).IsRequired();
            entity.Property(e => e.Anio).HasMaxLength(4)
                .IsUnicode(false).IsRequired();
            entity.Property(e => e.Color).HasMaxLength(15)
                .IsUnicode(false).IsRequired();
            entity.Property(e => e.Registrado).HasColumnType("datetime");

            entity.HasMany<OPOrden>()
                .WithOne()
                .HasForeignKey(e => e.UnidadId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        });
        
        base.OnModelCreating(modelBuilder);
    }
}
