using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Services.Core;

namespace Services.DataAccessLayer;

public partial class BRecipesContext : DbContext
{
    public BRecipesContext()
    {
    }

    public BRecipesContext(DbContextOptions<BRecipesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Recipe> Recipes { get; set; }

    public virtual DbSet<Step> Steps { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(Config.GetValueFrom("RecipesConnectionString"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Recipe>(entity =>
        {
            entity.HasIndex(e => e.Title, "IX_Recipes");

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Title).HasMaxLength(50);
        });

        modelBuilder.Entity<Step>(entity =>
        {
            entity.HasIndex(e => e.RecipeId, "IX_Steps");

            entity.HasOne(d => d.Recipe).WithMany(p => p.Steps)
                .HasForeignKey(d => d.RecipeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Steps_Recipes");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
