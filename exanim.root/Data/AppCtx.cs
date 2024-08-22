using System;
using exanim.core.Entities;
using Microsoft.EntityFrameworkCore;

namespace exanim.root.Data;

public class AppCtx : DbContext
{
    public AppCtx(DbContextOptions<AppCtx> options) : base(options)
    {
        base.Database.EnsureCreated();
    }

    public DbSet<Agency> Agencies { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Daybook> Daybooks { get; set; }
    public DbSet<Flow> Flows { get; set; }
    public DbSet<Stage> Stages { get; set; }
    public DbSet<Status> Statuses { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<WorkOrder> WorkOrders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agency>(entity =>
        {
            entity.HasKey(e => e.AgencyId)
                .HasName("PK_Agency");
            entity.ToTable("Agency");

            entity.Property(e => e.Alias).HasMaxLength(30)
                .IsUnicode(false).IsRequired();
            entity.Property(e => e.Name).HasMaxLength(200)
                .IsUnicode(false).IsRequired();
            entity.Property(e => e.Address).HasMaxLength(400)
                .IsUnicode(false).IsRequired();
            entity.Property(e => e.ZipCode).HasMaxLength(5)
                .IsUnicode(false).IsRequired();
            entity.OwnsOne(e => e.Place, p =>
            {
                p.ToJson();
                p.Property(x => x.Lat);
                p.Property(x => x.Lng);
            });

            entity.HasMany<WorkOrder>()
                .WithOne()
                .HasForeignKey(e => e.AgencyId)
                .IsRequired();
        });
        
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.BrandId)
                .HasName("PK_Brand");
            entity.ToTable("Brand");

            entity.Property(e => e.Name).HasMaxLength(30)
                .IsUnicode(false).IsRequired(true);
            
            entity.HasMany<Vehicle>()
                .WithOne()
                .HasForeignKey(e => e.BrandId)
                .IsRequired();
        });

        modelBuilder.Entity<Daybook>(entity =>
        {
            entity.HasKey(e => e.DaybookId)
                .HasName("PK_Daybook");
            entity.ToTable("Daybook");

            entity.Property(e => e.Annotation).HasMaxLength(400)
                .IsUnicode(false).IsRequired(true);
            entity.Property(e => e.Comment).HasMaxLength(200)
                .IsUnicode(false).IsRequired(true);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<Flow>(entity =>
        {
            entity.HasKey(e => e.FlowId)
                .HasName("PK_Flow");
            entity.ToTable("Flow");
        });
        
        modelBuilder.Entity<Stage>(entity =>
        {
            entity.HasKey(e => e.StageId)
                .HasName("PK_Stage");
            entity.ToTable("Stage");

            entity.Property(e => e.Name).HasMaxLength(50)
                .IsUnicode(false).IsRequired(true);
            entity.Property(e => e.Code).HasMaxLength(6)
                .IsUnicode(false).IsRequired(true);

            entity.HasMany<WorkOrder>()
                .WithOne()
                .HasForeignKey(e => e.StageId)
                .IsRequired();
            entity.HasMany<Daybook>()
                .WithOne()
                .HasForeignKey(e => e.StageId)
                .IsRequired();
            entity.HasMany<Flow>()
                .WithOne()
                .HasForeignKey(e => e.Initial)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasMany<Flow>()
                .WithOne()
                .HasForeignKey(e => e.Election)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.StatusId)
                .HasName("PK_Status");
            entity.ToTable("Status");

            entity.Property(e => e.Name).HasMaxLength(50)
                .IsUnicode(false).IsRequired(true);
            entity.Property(e => e.Code).HasMaxLength(6)
                .IsUnicode(false).IsRequired(true);
            
            entity.HasMany<Vehicle>()
                .WithOne()
                .HasForeignKey(e => e.StatusId)
                .IsRequired();
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId)
                .HasName("PK_User");
            entity.ToTable("User");

            entity.Property(e => e.Nick).HasMaxLength(12)
                .IsUnicode(false).IsRequired(true);
            entity.Property(e => e.Password).HasMaxLength(300)
                .IsUnicode(false).IsRequired(true);
            entity.Property(e => e.Mail).HasMaxLength(120)
                .IsUnicode(false).IsRequired(true);

            entity.HasMany<WorkOrder>()
                .WithOne()
                .HasForeignKey(e => e.CreatedBy)
                .IsRequired();
            entity.HasMany<Daybook>()
                .WithOne()
                .HasForeignKey(e => e.CreatedBy)
                .IsRequired();
        });

        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.HasKey(e => e.VehicleId)
                .HasName("PK_Vehicle");
            entity.ToTable("Vehicle");

            entity.Property(e => e.Plate).HasMaxLength(10)
                .IsUnicode(false).IsRequired(true);
            entity.Property(e => e.EnlistAt).HasColumnType("datetime");

            entity.HasMany<WorkOrder>()
                .WithOne()
                .HasForeignKey(e => e.VehicleId)
                .IsRequired();
        });

        modelBuilder.Entity<WorkOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId)
                .HasName("PK_Workorder");
            entity.ToTable("WorkOrder");

            entity.Property(e => e.Problem).HasMaxLength(500)
                .IsUnicode(false).IsRequired(true);
            entity.Property(e => e.Condition).HasMaxLength(500)
                .IsUnicode(false).IsRequired(true);
            entity.Property(e => e.ProvidedAt).HasColumnType("datetime");
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
        });
        
        base.OnModelCreating(modelBuilder);
    }
}
