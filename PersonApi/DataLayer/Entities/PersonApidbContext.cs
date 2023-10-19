using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Entities;

public partial class PersonApidbContext : DbContext
{
    public PersonApidbContext()
    {
    }

    public PersonApidbContext(DbContextOptions<PersonApidbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<PersonMst> PersonMsts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PersonMst>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PersonMs__3214EC07FF03F038");

            entity.ToTable("PersonMst");

            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
