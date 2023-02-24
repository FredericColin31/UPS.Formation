﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\SQL2019;Initial Catalog=bRecipes;Integrated security=SSPI;TrustServerCertificate=true");

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
