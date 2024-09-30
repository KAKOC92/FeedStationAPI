using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FDAPI.Models;

public partial class StatlogContext : DbContext
{
    public StatlogContext(DbContextOptions<StatlogContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Statlog> Statlogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=Pigs;Username=postgres;Password=251992");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Statlog>(entity =>
        {
            entity.HasKey(e => e.Rid).HasName("statlog_pk");

            entity.ToTable("statlog", "skovrn");

            entity.Property(e => e.Rid).HasColumnName("rid");
            entity.Property(e => e.Di)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("di");
            entity.Property(e => e.Errcod).HasColumnName("errcod");
            entity.Property(e => e.Key1)
                .HasMaxLength(15)
                .HasColumnName("key1");
            entity.Property(e => e.Key2)
                .HasMaxLength(15)
                .HasColumnName("key2");
            entity.Property(e => e.Kid)
                .HasMaxLength(50)
                .HasColumnName("kid");
            entity.Property(e => e.Kod)
                .HasMaxLength(50)
                .HasColumnName("kod");
            entity.Property(e => e.Op)
                .HasMaxLength(50)
                .HasColumnName("op");
            entity.Property(e => e.Proto)
                .HasMaxLength(15)
                .HasColumnName("proto");
            entity.Property(e => e.Stid).HasColumnName("stid");
            entity.Property(e => e.Tmaut).HasColumnName("tmaut");
            entity.Property(e => e.Val1)
                .HasMaxLength(127)
                .HasColumnName("val1");
            entity.Property(e => e.Val2)
                .HasMaxLength(127)
                .HasColumnName("val2");
            entity.Property(e => e.Xerr).HasColumnName("xerr");
            entity.Property(e => e.Xip)
                .HasMaxLength(30)
                .HasColumnName("xip");
            entity.Property(e => e.Xtime)
                .HasMaxLength(50)
                .HasColumnName("xtime");
            entity.Property(e => e.Xua)
                .HasMaxLength(127)
                .HasColumnName("xua");
            entity.Property(e => e.Xuser)
                .HasMaxLength(30)
                .HasDefaultValueSql("CURRENT_USER")
                .HasColumnName("xuser");
            entity.Property(e => e.Xver)
                .HasMaxLength(20)
                .HasColumnName("xver");
        });
        modelBuilder.HasSequence("attributes_id_seq", "top");
        modelBuilder.HasSequence("boarline_id_seq", "top");
        modelBuilder.HasSequence("contragent_id_seq", "top");
        modelBuilder.HasSequence("employes_id_seq", "top");
        modelBuilder.HasSequence("groups_id_seq", "top");
        modelBuilder.HasSequence("mojo_id_seq", "top");
        modelBuilder.HasSequence("nicknames_id_seq", "top");
        modelBuilder.HasSequence("position_id_seq", "top");
        modelBuilder.HasSequence("preg_test_id_seq", "top");
        modelBuilder.HasSequence("sowline_id_seq", "top");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public DbSet<Statlog> GetStatlogs => Set<Statlog>();
}
