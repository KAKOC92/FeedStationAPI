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

    public virtual DbSet<Kntngnt> Kntngnts { get; set; }
    public virtual DbSet<Animal>Animals { get; set; }


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

        modelBuilder.Entity<Kntngnt>(entity =>
        {
            entity.HasKey(e => e.Bid).HasName("kntngnt_pk");

            entity.ToTable("kntngnt", "skovrn");

            entity.Property(e => e.Bid)
                .HasDefaultValueSql("nextval('skovrn.kntngnt_kn_id_seq'::regclass)")
                .HasColumnName("bid");
            entity.Property(e => e.Animid).HasColumnName("animid");
            entity.Property(e => e.Bdate)
                .HasDefaultValueSql("now()")
                .HasColumnName("bdate");
            entity.Property(e => e.Cpn)
                .HasMaxLength(20)
                .HasColumnName("cpn");
            entity.Property(e => e.Cpn2).HasColumnName("cpn2");
            entity.Property(e => e.Dateoff).HasColumnName("dateoff");
            entity.Property(e => e.Dateoff2).HasColumnName("dateoff2");
            entity.Property(e => e.Dateon).HasColumnName("dateon");
            entity.Property(e => e.Descr).HasColumnName("descr");
            entity.Property(e => e.Di)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("di");
            entity.Property(e => e.Oprtr).HasColumnName("oprtr");
            entity.Property(e => e.Stn).HasColumnName("stn");
            entity.Property(e => e.Stn2)
                .HasMaxLength(10)
                .HasColumnName("stn2");
            entity.Property(e => e.Xuser)
                .HasMaxLength(30)
                .HasDefaultValueSql("CURRENT_USER")
                .HasColumnName("xuser");
        });

        modelBuilder.Entity<Animal>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("animal", "top");

            entity.HasIndex(e => e.Brdate, "animal_brdate_idx");

            entity.HasIndex(e => e.Farrow, "animal_farrow_idx");

            entity.HasIndex(e => e.Ferma, "animal_ferma_idx");

            entity.HasIndex(e => e.Reg, "animal_reg_idx");

            entity.HasIndex(e => e.Stado, "animal_stado_idx");

            entity.Property(e => e.Animid)
                .ValueGeneratedOnAdd()
                .HasColumnName("animid");
            entity.Property(e => e.Boar).HasColumnName("boar");
            entity.Property(e => e.BoarLine).HasColumnName("boar_line");
            entity.Property(e => e.Brdate).HasColumnName("brdate");
            entity.Property(e => e.Brweight).HasColumnName("brweight");
            entity.Property(e => e.Comments).HasColumnName("comments");
            entity.Property(e => e.Deleted).HasColumnName("deleted");
            entity.Property(e => e.Dres).HasColumnName("dres");
            entity.Property(e => e.Dres2).HasColumnName("dres2");
            entity.Property(e => e.Elreg)
                .HasMaxLength(50)
                .HasColumnName("elreg");
            entity.Property(e => e.Farrow).HasColumnName("farrow");
            entity.Property(e => e.Ferma).HasColumnName("ferma");
            entity.Property(e => e.Indate).HasColumnName("indate");
            entity.Property(e => e.Isanimal).HasColumnName("isanimal");
            entity.Property(e => e.Korpus).HasColumnName("korpus");
            entity.Property(e => e.Litter).HasColumnName("litter");
            entity.Property(e => e.Lteats).HasColumnName("lteats");
            entity.Property(e => e.Metodv)
                .HasDefaultValueSql("601")
                .HasColumnName("metodv");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Outdate).HasColumnName("outdate");
            entity.Property(e => e.Pdg).HasColumnName("pdg");
            entity.Property(e => e.Pn).HasColumnName("pn");
            entity.Property(e => e.Poroda).HasColumnName("poroda");
            entity.Property(e => e.Reg)
                .HasMaxLength(50)
                .HasColumnName("reg");
            entity.Property(e => e.Reg2)
                .HasMaxLength(50)
                .HasColumnName("reg2");
            entity.Property(e => e.Removed)
                .HasDefaultValueSql("0")
                .HasColumnName("removed");
            entity.Property(e => e.Remres).HasColumnName("remres");
            entity.Property(e => e.Remres2).HasColumnName("remres2");
            entity.Property(e => e.Rteats).HasColumnName("rteats");
            entity.Property(e => e.Sex).HasColumnName("sex");
            entity.Property(e => e.Sow).HasColumnName("sow");
            entity.Property(e => e.SowLine).HasColumnName("sow_line");
            entity.Property(e => e.Stado).HasColumnName("stado");
            entity.Property(e => e.Stan).HasColumnName("stan");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Stdate).HasColumnName("stdate");
            entity.Property(e => e.SublineId).HasColumnName("subline_id");
            entity.Property(e => e.Sublinegen)
                .HasMaxLength(10)
                .HasColumnName("sublinegen");
            entity.Property(e => e.Tag)
                .HasMaxLength(50)
                .HasColumnName("tag");
            entity.Property(e => e.Wnweight).HasColumnName("wnweight");
            entity.Property(e => e.Zal).HasColumnName("zal");
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