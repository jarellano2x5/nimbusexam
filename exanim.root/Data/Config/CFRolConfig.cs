using exanim.core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace exanim.root.Data.Config;

public class CFRolConfig : IEntityTypeConfiguration<CFRol>
{
    public void Configure(EntityTypeBuilder<CFRol> builder)
    {
        builder.HasKey(e => e.Id);
        builder.ToTable("CFRol");
    }
}