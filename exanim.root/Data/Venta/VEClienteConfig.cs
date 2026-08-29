using exanim.core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace exanim.root.Data.Venta;

public class VEClienteConfig : IEntityTypeConfiguration<VECliente>
{
    public void Configure(EntityTypeBuilder<VECliente> builder)
    {
        builder.HasKey(e => e.Id)
            .HasName("PK_VECliente");
        builder.ToTable("VECliente");

        builder.Property(e => e.Fecha)
            .HasColumnName(Dbtas.Tdatetime);

        builder.HasMany<OPOrden>()
            .WithOne()
            .HasForeignKey(e => e.GestorId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
    }
}