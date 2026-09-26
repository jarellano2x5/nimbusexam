using exanim.core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace exanim.root.Data.Opera;

public class OPBrandConfig : IEntityTypeConfiguration<OPBrand>
{
    public void Configure(EntityTypeBuilder<OPBrand> builder)
    {
        builder.HasKey(e => e.Id)
            .HasName("PK_OPBrand");
        builder.ToTable("OPBrand");

        builder.Property(e => e.Name)
            .HasMaxLength(30).IsUnicode(false);
            
        builder.HasMany<VEUnidad>()
            .WithOne(e => e.Marca)
            .HasForeignKey(e => e.MarcaId)
            .OnDelete(DeleteBehavior.Restrict)
            .IsRequired();
    }
}