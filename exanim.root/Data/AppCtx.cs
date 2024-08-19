using System;
using exanim.core.Entities;
using Microsoft.EntityFrameworkCore;

namespace exanim.root.Data;

public class AppCtx : DbContext
{
    public AppCtx(DbContextOptions<AppCtx> options) : base(options)
    {
        
    }

    public DbSet<Agency> Agencies { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
