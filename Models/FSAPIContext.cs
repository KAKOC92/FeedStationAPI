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
    public virtual DbSet<Statlog> Statlogs { get; set; }
    public virtual DbSet<Station> Stations { get; set; }

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
}