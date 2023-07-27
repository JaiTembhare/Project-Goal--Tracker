using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MiniProject.Models;

public partial class DnprojectContext : DbContext
{
    public DnprojectContext()
    {
    }

    public DnprojectContext(DbContextOptions<DnprojectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<GoalTracker> GoalTrackers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //        => optionsBuilder.UseSqlServer("Server=DESKTOP-3UULQAH;Database=DNProject;Trusted_Connection=True;TrustServerCertificate=True;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GoalTracker>(entity =>
        {
            entity.HasKey(e => e.GoalId);

            entity.ToTable("GoalTracker");

            entity.Property(e => e.Discriptin).HasMaxLength(200);
            entity.Property(e => e.StartDate).HasColumnType("date");
            entity.Property(e => e.Title).HasMaxLength(150);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
