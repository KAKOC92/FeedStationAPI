using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace FDAPI.Models;

public partial class FSAPIContext : DbContext
{
    public FSAPIContext(DbContextOptions<FSAPIContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Chk> Chks { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
 /// <summary>
 /// /https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
 /// </summary>
 /// <param name="modelBuilder"></param>
        //=> optionsBuilder.UseNpgsql("Host=localhost;Database=Pigs;Username=postgres;Password=251992");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chk>(entity =>
        {
            entity.HasKey(e => e.Rid).HasName("chks_pk");

            entity.ToTable("chks", "stn");

            entity.HasIndex(e => e.Animid, "chks_animid_idx");

            entity.HasIndex(e => e.Dat, "chks_dat_idx");

            entity.HasIndex(e => e.Datetimein, "chks_datetimein_idx");

            entity.HasIndex(e => e.Datetimeout, "chks_datetimeout_idx");

            entity.Property(e => e.Rid).HasColumnName("rid");
            entity.Property(e => e.Animid).HasColumnName("animid");
            entity.Property(e => e.BulkId).HasColumnName("bulk_id");
            entity.Property(e => e.Chip)
                .HasMaxLength(50)
                .HasColumnName("chip");
            entity.Property(e => e.Dat).HasColumnName("dat");
            entity.Property(e => e.Datetimein)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("datetimein");
            entity.Property(e => e.Datetimeout)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("datetimeout");
            entity.Property(e => e.Di)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("di");
            entity.Property(e => e.Masin).HasColumnName("masin");
            entity.Property(e => e.Masout).HasColumnName("masout");
            entity.Property(e => e.Numgroup).HasColumnName("numgroup");
            entity.Property(e => e.Numstation).HasColumnName("numstation");
            entity.Property(e => e.Rat).HasColumnName("rat");
            entity.Property(e => e.StnType).HasColumnName("stn_type");
            entity.Property(e => e.Tatno)
                .HasMaxLength(50)
                .HasColumnName("tatno");
            entity.Property(e => e.Totalfeed).HasColumnName("totalfeed");
            entity.Property(e => e.Xmode).HasColumnName("xmode");
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

    public DbSet <Chk> GetChk => Set<Chk>();
}
