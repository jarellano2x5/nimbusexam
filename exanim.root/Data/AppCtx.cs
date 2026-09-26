using exanim.core.Entities;
using Microsoft.EntityFrameworkCore;

namespace exanim.root.Data;

public class AppCtx : DbContext
{
    public AppCtx(DbContextOptions<AppCtx> options) : base(options)
    {
        //base.Database.EnsureDeleted();
    }

    public DbSet<OPBrand> Brands { get; set; }
    public DbSet<CFAgencia> Agencias { get; set; }
    public DbSet<CFConfigura> Configuraciones { get; set; }
    public DbSet<CFOperador> Operadores { get; set; }
    public DbSet<CFParametro> Parametros { get; set; }
    public DbSet<CFPerfil> Perfiles { get; set; }
    public DbSet<CFTaller> Talleres { get; set; }
    public DbSet<CFUsuario> Usuarios { get; set; }
    public DbSet<CFSocio> Socios { get; set; }
    public DbSet<OPAccion> Acciones { get; set; }
    public DbSet<OPAutoriza> Autorizaciones { get; set; }
    public DbSet<OPAvance> Avances { get; set; }
    public DbSet<OPClase> Clases { get; set; }
    public DbSet<OPEstado> Estatus { get; set; }
    public DbSet<OPInstalacion> Instalaciones { get; set; }
    public DbSet<OPOrden> Ordenes { get; set; }
    public DbSet<OPPaso> Pasos { get; set; }
    public DbSet<OPPieza> Piezas { get; set; }
    public DbSet<OPRemocion> Remociones { get; set; }
    public DbSet<VECompania> Companias { get; set; }
    public DbSet<VECotizacion> Cotizaciones { get; set; }
    public DbSet<VECliente> Gestores { get; set; }
    public DbSet<VELinea> Lineas { get; set; }
    public DbSet<VEUnidad> Unidades { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CFOperador>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PK_CFOperador");
            entity.ToTable("CFOperador");

            entity.Property(e => e.Fecha).HasColumnType("datetime");
        });

        modelBuilder.Entity<CFParametro>(entity =>
        {
            entity.HasKey(e => e.Id)
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

        modelBuilder.Entity<CFTaller>(entity =>
        {
            entity.HasKey(e => e.Id)
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
        
        modelBuilder.Entity<OPAccion>(entity =>
        {
            entity.HasKey(e => e.Id)
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
            entity.HasKey(e => e.Id)
                .HasName("PK_OPAutoriza");
            entity.ToTable("OPAutoriza");

            entity.Property(e => e.Comentario).HasMaxLength(300)
                .IsUnicode(false).IsRequired();
        });

        modelBuilder.Entity<OPAvance>(entity =>
        {
            entity.HasKey(e => e.Id)
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
            entity.HasKey(e => e.Id)
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

        modelBuilder.Entity<OPInstalacion>(entity =>
        {
            entity.HasKey(e => e.Id)
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
            entity.HasKey(e => e.Id)
                .HasName("PK_OPOrden");
            entity.ToTable("OPOrden");

            entity.Property(e => e.Fecha)
                .HasColumnType(Dbtas.Tdatetime);
            entity.Property(e => e.Problema).HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Condicion).HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Correo).HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.FechaEntrega)
                .HasColumnType(Dbtas.Tdate);

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
            entity.HasMany<VECotizacion>()
                .WithOne()
                .HasForeignKey(e => e.OrdenId)
                .IsRequired(false);
        });

        modelBuilder.Entity<OPPaso>(entity =>
        {
            entity.HasKey(e => e.Id)
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
            entity.HasKey(e => e.Id)
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
            entity.HasKey(e => e.Id)
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
        
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppCtx).Assembly);
    }
}
