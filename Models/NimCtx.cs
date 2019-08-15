using System;
using Microsoft.EntityFrameworkCore;

namespace exanim.Models
{
    public class NimCtx : DbContext
    {
        public NimCtx(DbContextOptions<NimCtx> options) : base(options)
        {
        }

        public virtual DbSet<Emisor> Emisores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //revisar el modelo no sigue el estandar de modelos tablas
            modelBuilder.Entity<Emisor>(entity => {
                entity.Property(e => e.activo).HasConversion<Int16>();
                entity.ToTable("emisor");
            });
        }
    }
}
