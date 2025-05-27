using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FDAPI.Models;

public partial class TestPigsContext : DbContext
{
    public TestPigsContext()
    {
    }

    public TestPigsContext(DbContextOptions<TestPigsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Station> Stations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=test_pigs;Username=postgres;Password=251992");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Station>(entity =>
        {
            entity.HasKey(e => e.Stid).HasName("stations_pk");

            entity.ToTable("stations", "skovrn");

            entity.Property(e => e.Stid).HasColumnName("stid");
            entity.Property(e => e.Descr).HasColumnName("descr");
            entity.Property(e => e.Di)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("di");
            entity.Property(e => e.Kid)
                .HasMaxLength(50)
                .HasColumnName("kid");
            entity.Property(e => e.Kod)
                .HasMaxLength(50)
                .HasDefaultValueSql("(floor((random() * ('100000000'::numeric)::double precision)))::character varying")
                .HasColumnName("kod");
            entity.Property(e => e.Locat)
                .HasMaxLength(50)
                .HasColumnName("locat");
            entity.Property(e => e.MId).HasColumnName("m_id");
            entity.Property(e => e.Operate).HasColumnName("operate");
            entity.Property(e => e.Paused).HasColumnName("paused");
            entity.Property(e => e.Stn)
                .HasMaxLength(50)
                .HasColumnName("stn");
            entity.Property(e => e.Timout).HasColumnName("timout");
            entity.Property(e => e.Xuser)
                .HasMaxLength(30)
                .HasDefaultValueSql("CURRENT_USER")
                .HasColumnName("xuser");
        });
        modelBuilder.HasSequence("attributes_id_seq", "top");
        modelBuilder.HasSequence("boarline_id_seq", "top");
        modelBuilder.HasSequence("contragent_id_seq", "top");
        modelBuilder.HasSequence("dorost_id_seq", "top");
        modelBuilder.HasSequence("employes_id_seq", "top");
        modelBuilder.HasSequence("farrow_group_id_seq", "top");
        modelBuilder.HasSequence("feeds_id_seq", "top");
        modelBuilder.HasSequence("groups_id_seq", "top");
        modelBuilder.HasSequence("isolator_id_seq", "top");
        modelBuilder.HasSequence("mojo_id_seq", "top");
        modelBuilder.HasSequence("nicknames_id_seq", "top");
        modelBuilder.HasSequence("otkorm_id_seq", "top");
        modelBuilder.HasSequence("pigies_id_seq", "top");
        modelBuilder.HasSequence("planting_id_seq", "top");
        modelBuilder.HasSequence("position_id_seq", "top");
        modelBuilder.HasSequence("preg_test_id_seq", "top");
        modelBuilder.HasSequence("realization_id_seq", "top");
        modelBuilder.HasSequence("sowline_id_seq", "top");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
