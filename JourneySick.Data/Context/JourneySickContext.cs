using System;
using System.Collections.Generic;
using JourneySick.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace JourneySick.Data;

public partial class JourneySickContext : DbContext
{
    public JourneySickContext()
    {
    }

    public JourneySickContext(DbContextOptions<JourneySickContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Tblplanlocation> Tblplanlocations { get; set; }

    public virtual DbSet<Tbltrip> Tbltrips { get; set; }

    public virtual DbSet<Tbltripdetail> Tbltripdetails { get; set; }

    public virtual DbSet<Tbltripmember> Tbltripmembers { get; set; }

    public virtual DbSet<Tbltripplan> Tbltripplans { get; set; }

    public virtual DbSet<Tbltriprole> Tbltriproles { get; set; }

    public virtual DbSet<Tbluser> Tblusers { get; set; }

    public virtual DbSet<Tbluserdetail> Tbluserdetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user id=CRM;database=journey_sick_db", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.39-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("latin1_swedish_ci")
            .HasCharSet("latin1");

        modelBuilder.Entity<Tblplanlocation>(entity =>
        {
            entity.HasKey(e => e.FldPlanId).HasName("PRIMARY");

            entity.ToTable("tblplanlocation");

            entity.Property(e => e.FldPlanId)
                .HasMaxLength(50)
                .HasColumnName("fldPlanId");
            entity.Property(e => e.FldCreateBy)
                .HasMaxLength(50)
                .HasColumnName("fldCreateBy");
            entity.Property(e => e.FldCreateDate)
                .HasColumnType("datetime")
                .HasColumnName("fldCreateDate");
            entity.Property(e => e.FldLocationArrivalTime)
                .HasColumnType("datetime")
                .HasColumnName("fldLocationArrivalTime");
            entity.Property(e => e.FldOrdinal)
                .HasColumnType("int(11)")
                .HasColumnName("fldOrdinal");
            entity.Property(e => e.FldPlanLocationDescription)
                .HasColumnType("text")
                .HasColumnName("fldPlanLocationDescription");
            entity.Property(e => e.FldPlanLocationId)
                .HasMaxLength(50)
                .HasColumnName("fldPlanLocationId");
            entity.Property(e => e.FldPlanLocationName)
                .HasMaxLength(50)
                .HasColumnName("fldPlanLocationName")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.FldUpdateBy)
                .HasMaxLength(50)
                .HasColumnName("fldUpdateBy");
            entity.Property(e => e.FldUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("fldUpdateDate");
        });

        modelBuilder.Entity<Tbltrip>(entity =>
        {
            entity.HasKey(e => e.FldTripId).HasName("PRIMARY");

            entity.ToTable("tbltrip");

            entity.HasIndex(e => e.FldTripId, "fldTripId_UNIQUE").IsUnique();

            entity.Property(e => e.FldTripId)
                .HasMaxLength(50)
                .HasColumnName("fldTripId");
            entity.Property(e => e.FldEstimateArrivalTime)
                .HasColumnType("datetime")
                .HasColumnName("fldEstimateArrivalTime");
            entity.Property(e => e.FldEstimateStartTime)
                .HasColumnType("datetime")
                .HasColumnName("fldEstimateStartTime");
            entity.Property(e => e.FldTripBudget)
                .HasPrecision(15, 2)
                .HasColumnName("fldTripBudget");
            entity.Property(e => e.FldTripDescription).HasColumnName("fldTripDescription");
            entity.Property(e => e.FldTripMember)
                .HasColumnType("int(11)")
                .HasColumnName("fldTripMember");
            entity.Property(e => e.FldTripName)
                .HasMaxLength(50)
                .HasColumnName("fldTripName")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.FldTripStatus)
                .HasMaxLength(50)
                .HasColumnName("fldTripStatus")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.FldTripPresenter)
                .HasMaxLength(50)
                .HasColumnName("fldTripPresenter");
        });

        modelBuilder.Entity<Tbltripdetail>(entity =>
        {
            entity.HasKey(e => e.FldTripId).HasName("PRIMARY");

            entity.ToTable("tbltripdetail");

            entity.HasIndex(e => e.FldTripId, "fldTripId_UNIQUE").IsUnique();

            entity.Property(e => e.FldTripId)
                .HasMaxLength(50)
                .HasColumnName("fldTripId");
            entity.Property(e => e.FldCreateBy)
                .HasMaxLength(50)
                .HasColumnName("fldCreateBy");
            entity.Property(e => e.FldCreateDate)
                .HasColumnType("datetime")
                .HasColumnName("fldCreateDate");
            entity.Property(e => e.FldTripDestinationLocationAddress)
                .HasMaxLength(50)
                .HasColumnName("fldTripDestinationLocationAddress")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.FldTripDestinationLocationName)
                .HasMaxLength(50)
                .HasColumnName("fldTripDestinationLocationName")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.FldTripStartLocationAddress)
                .HasMaxLength(50)
                .HasColumnName("fldTripStartLocationAddress")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.FldTripStartLocationName)
                .HasMaxLength(50)
                .HasColumnName("fldTripStartLocationName")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.FldUpdateBy)
                .HasMaxLength(50)
                .HasColumnName("fldUpdateBy");
            entity.Property(e => e.FldUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("fldUpdateDate");
        });

        modelBuilder.Entity<Tbltripmember>(entity =>
        {
            entity.HasKey(e => e.FldMemberId).HasName("PRIMARY");

            entity.ToTable("tbltripmember");

            entity.HasIndex(e => e.FldMemberId, "fldMemberId_UNIQUE").IsUnique();

            entity.Property(e => e.FldMemberId)
                .HasMaxLength(50)
                .HasColumnName("fldMemberId");
            entity.Property(e => e.FldUserId)
                .HasMaxLength(50)
                .HasColumnName("fldUserId");
            entity.Property(e => e.FldCreateBy)
                .HasMaxLength(50)
                .HasColumnName("fldCreateBy");
            entity.Property(e => e.FldCreateDate)
                .HasColumnType("datetime")
                .HasColumnName("fldCreateDate");
            entity.Property(e => e.FldMemberRoleId)
                .HasMaxLength(50)
                .HasColumnName("fldMemberRoleId");
            entity.Property(e => e.FldNickName)
                .HasMaxLength(50)
                .HasColumnName("fldNickName")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.FldStatus)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("fldStatus");
            entity.Property(e => e.FldTripId)
                .HasMaxLength(50)
                .HasColumnName("fldTripId");
            entity.Property(e => e.FldUpdateBy)
                .HasMaxLength(50)
                .HasColumnName("fldUpdateBy");
            entity.Property(e => e.FldUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("fldUpdateDate");
        });

        modelBuilder.Entity<Tbltripplan>(entity =>
        {
            entity.HasKey(e => e.FldPlanId).HasName("PRIMARY");

            entity.ToTable("tbltripplan");

            entity.HasIndex(e => e.FldPlanId, "fldPlanId_UNIQUE").IsUnique();

            entity.Property(e => e.FldPlanId)
                .HasMaxLength(50)
                .HasColumnName("fldPlanId");
            entity.Property(e => e.FldCreateBy)
                .HasMaxLength(50)
                .HasColumnName("fldCreateBy");
            entity.Property(e => e.FldCreateDate)
                .HasColumnType("datetime")
                .HasColumnName("fldCreateDate");
            entity.Property(e => e.FldPlanDescription).HasColumnName("fldPlanDescription");
            entity.Property(e => e.FldTripId)
                .HasMaxLength(50)
                .HasColumnName("fldTripId");
            entity.Property(e => e.FldUpdateBy)
                .HasMaxLength(50)
                .HasColumnName("fldUpdateBy");
            entity.Property(e => e.FldUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("fldUpdateDate");
        });

        modelBuilder.Entity<Tbltriprole>(entity =>
        {
            entity.HasKey(e => e.FldRoleId).HasName("PRIMARY");

            entity.ToTable("tbltriprole");

            entity.HasIndex(e => e.FldRoleId, "fldRoleId_UNIQUE").IsUnique();

            entity.Property(e => e.FldRoleId)
                .HasMaxLength(50)
                .HasColumnName("fldRoleId");
            entity.Property(e => e.FldDescription)
                .HasColumnType("text")
                .HasColumnName("fldDescription");
            entity.Property(e => e.FldRoleName)
                .HasMaxLength(50)
                .HasColumnName("fldRoleName")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.FldType)
                .HasMaxLength(20)
                .HasColumnName("fldType")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
        });

        modelBuilder.Entity<Tbluser>(entity =>
        {
            entity.HasKey(e => e.FldUserId).HasName("PRIMARY");

            entity.ToTable("tbluser");

            entity.HasIndex(e => e.FldUserId, "fldUserId_UNIQUE").IsUnique();

            entity.Property(e => e.FldUserId)
                .HasMaxLength(50)
                .HasColumnName("fldUserId");
            entity.Property(e => e.FldPassword)
                .HasMaxLength(45)
                .HasColumnName("fldPassword");
            entity.Property(e => e.FldUsername)
                .HasMaxLength(45)
                .HasColumnName("fldUsername");
        });

        modelBuilder.Entity<Tbluserdetail>(entity =>
        {
            entity.HasKey(e => e.FldUserId).HasName("PRIMARY");

            entity.ToTable("tbluserdetail");

            entity.HasIndex(e => e.FldEmail, "fldEmail_UNIQUE").IsUnique();

            entity.HasIndex(e => e.FldPhone, "fldPhone_UNIQUE").IsUnique();

            entity.HasIndex(e => e.FldUserId, "fldUserId_UNIQUE").IsUnique();

            entity.Property(e => e.FldUserId)
                .HasMaxLength(50)
                .HasColumnName("fldUserId");
            entity.Property(e => e.FldActiveStatus)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("fldActiveStatus");
            entity.Property(e => e.FldAddress)
                .HasColumnType("text")
                .HasColumnName("fldAddress")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.FldBirthday)
                .HasColumnType("datetime")
                .HasColumnName("fldBirthday");
            entity.Property(e => e.FldCreateBy)
                .HasColumnType("datetime")
                .HasColumnName("fldCreateBy");
            entity.Property(e => e.FldCreateDate)
                .HasColumnType("datetime")
                .HasColumnName("fldCreateDate");
            entity.Property(e => e.FldEmail)
                .HasMaxLength(50)
                .HasColumnName("fldEmail")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.FldExperience).HasColumnName("fldExperience");
            entity.Property(e => e.FldFullname)
                .HasMaxLength(50)
                .HasColumnName("fldFullname")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.FldPhone)
                .HasMaxLength(10)
                .HasColumnName("fldPhone");
            entity.Property(e => e.FldRole)
                .HasMaxLength(20)
                .HasColumnName("fldRole")
                .UseCollation("utf8_general_ci")
                .HasCharSet("utf8");
            entity.Property(e => e.FldTripCancelled)
                .HasColumnType("int(11)")
                .HasColumnName("fldTripCancelled");
            entity.Property(e => e.FldTripCompleted)
                .HasColumnType("int(11)")
                .HasColumnName("fldTripCompleted");
            entity.Property(e => e.FldTripCreated)
                .HasColumnType("int(11)")
                .HasColumnName("fldTripCreated");
            entity.Property(e => e.FldTripJoined)
                .HasColumnType("int(11)")
                .HasColumnName("fldTripJoined");
            entity.Property(e => e.FldUpdateBy)
                .HasColumnType("datetime")
                .HasColumnName("fldUpdateBy");
            entity.Property(e => e.FldUpdateDate)
                .HasColumnType("datetime")
                .HasColumnName("fldUpdateDate");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
