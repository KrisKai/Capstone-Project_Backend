using System;
using System.Collections.Generic;
using JourneySick.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JourneySick.Data.Context
{
    public partial class journeysick_dbContext : DbContext
    {
        public journeysick_dbContext()
        {
        }

        public journeysick_dbContext(DbContextOptions<journeysick_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Tblfeedback> Tblfeedbacks { get; set; } = null!;
        public virtual DbSet<Tblitem> Tblitems { get; set; } = null!;
        public virtual DbSet<Tblitemcategory> Tblitemcategories { get; set; } = null!;
        public virtual DbSet<Tblmaplocation> Tblmaplocations { get; set; } = null!;
        public virtual DbSet<Tblplanlocation> Tblplanlocations { get; set; } = null!;
        public virtual DbSet<Tbltrip> Tbltrips { get; set; } = null!;
        public virtual DbSet<Tbltripdetail> Tbltripdetails { get; set; } = null!;
        public virtual DbSet<Tbltripitem> Tbltripitems { get; set; } = null!;
        public virtual DbSet<Tbltripmember> Tbltripmembers { get; set; } = null!;
        public virtual DbSet<Tbltripplan> Tbltripplans { get; set; } = null!;
        public virtual DbSet<Tbltriprole> Tbltriproles { get; set; } = null!;
        public virtual DbSet<Tbluser> Tblusers { get; set; } = null!;
        public virtual DbSet<Tbluserdetail> Tbluserdetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;user=root;database=journeysick_db", ServerVersion.Parse("8.0.27-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Tblfeedback>(entity =>
            {
                entity.HasKey(e => e.FldFeedbackId)
                    .HasName("PRIMARY");

                entity.ToTable("tblfeedback");

                entity.Property(e => e.FldFeedbackId).HasColumnName("fldFeedbackId");

                entity.Property(e => e.FldCreateBy)
                    .HasMaxLength(50)
                    .HasColumnName("fldCreateBy");

                entity.Property(e => e.FldCreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fldCreateDate");

                entity.Property(e => e.FldDislike).HasColumnName("fldDislike");

                entity.Property(e => e.FldFeedback).HasColumnName("fldFeedback");

                entity.Property(e => e.FldLike).HasColumnName("fldLike");

                entity.Property(e => e.FldLocationName)
                    .HasMaxLength(100)
                    .HasColumnName("fldLocationName");

                entity.Property(e => e.FldRate)
                    .HasColumnName("fldRate")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.FldTripId)
                    .HasMaxLength(50)
                    .HasColumnName("fldTripId");

                entity.Property(e => e.FldUpdateBy)
                    .HasMaxLength(50)
                    .HasColumnName("fldUpdateBy");

                entity.Property(e => e.FldUpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fldUpdateDate");

                entity.Property(e => e.FldUserId)
                    .HasMaxLength(50)
                    .HasColumnName("fldUserId");
            });

            modelBuilder.Entity<Tblitem>(entity =>
            {
                entity.HasKey(e => e.FldItemId)
                    .HasName("PRIMARY");

                entity.ToTable("tblitem");

                entity.Property(e => e.FldItemId)
                    .HasMaxLength(50)
                    .HasColumnName("fldItemId")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.FldCreateBy)
                    .HasMaxLength(50)
                    .HasColumnName("fldCreateBy");

                entity.Property(e => e.FldCreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fldCreateDate");

                entity.Property(e => e.FldItemCategory)
                    .HasMaxLength(50)
                    .HasColumnName("fldItemCategory");

                entity.Property(e => e.FldItemDescription)
                    .HasColumnType("mediumtext")
                    .HasColumnName("fldItemDescription");

                entity.Property(e => e.FldItemName)
                    .HasColumnType("mediumtext")
                    .HasColumnName("fldItemName");

                entity.Property(e => e.FldItemUsage).HasColumnName("fldItemUsage");

                entity.Property(e => e.FldPriceMax)
                    .HasPrecision(10, 2)
                    .HasColumnName("fldPriceMax");

                entity.Property(e => e.FldPriceMin)
                    .HasPrecision(10, 2)
                    .HasColumnName("fldPriceMin");

                entity.Property(e => e.FldUpdateBy)
                    .HasMaxLength(50)
                    .HasColumnName("fldUpdateBy");

                entity.Property(e => e.FldUpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fldUpdateDate");
            });

            modelBuilder.Entity<Tblitemcategory>(entity =>
            {
                entity.HasKey(e => e.FldCategoryId)
                    .HasName("PRIMARY");

                entity.ToTable("tblitemcategory");

                entity.Property(e => e.FldCategoryId)
                    .HasMaxLength(50)
                    .HasColumnName("fldCategoryId");

                entity.Property(e => e.FldCategoryDescription)
                    .HasColumnType("tinytext")
                    .HasColumnName("fldCategoryDescription");

                entity.Property(e => e.FldCategoryName)
                    .HasMaxLength(50)
                    .HasColumnName("fldCategoryName");

                entity.Property(e => e.FldCreateBy)
                    .HasMaxLength(50)
                    .HasColumnName("fldCreateBy");

                entity.Property(e => e.FldCreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fldCreateDate");

                entity.Property(e => e.FldUpdateBy)
                    .HasMaxLength(50)
                    .HasColumnName("fldUpdateBy");

                entity.Property(e => e.FldUpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fldUpdateDate");
            });

            modelBuilder.Entity<Tblmaplocation>(entity =>
            {
                entity.HasKey(e => e.FldMapId)
                    .HasName("PRIMARY");

                entity.ToTable("tblmaplocation");

                entity.Property(e => e.FldMapId)
                    .ValueGeneratedNever()
                    .HasColumnName("fldMapId");

                entity.Property(e => e.FldLatitude)
                    .HasMaxLength(45)
                    .HasColumnName("fldLatitude");

                entity.Property(e => e.FldLocationName)
                    .HasMaxLength(45)
                    .HasColumnName("fldLocationName");

                entity.Property(e => e.FldLongitude)
                    .HasMaxLength(100)
                    .HasColumnName("fldLongitude");
            });

            modelBuilder.Entity<Tblplanlocation>(entity =>
            {
                entity.HasKey(e => e.FldPlanId)
                    .HasName("PRIMARY");

                entity.ToTable("tblplanlocation");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.FldPlanId).HasColumnName("fldPlanId");

                entity.Property(e => e.FldCreateBy)
                    .HasMaxLength(50)
                    .HasColumnName("fldCreateBy");

                entity.Property(e => e.FldCreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fldCreateDate");

                entity.Property(e => e.FldLocationArrivalTime)
                    .HasColumnType("datetime")
                    .HasColumnName("fldLocationArrivalTime");

                entity.Property(e => e.FldMapId).HasColumnName("fldMapId");

                entity.Property(e => e.FldPlanLocationDescription)
                    .HasColumnType("text")
                    .HasColumnName("fldPlanLocationDescription");

                entity.Property(e => e.FldPlanLocationId)
                    .HasMaxLength(50)
                    .HasColumnName("fldPlanLocationId");

                entity.Property(e => e.FldUpdateBy)
                    .HasMaxLength(50)
                    .HasColumnName("fldUpdateBy");

                entity.Property(e => e.FldUpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fldUpdateDate");
            });

            modelBuilder.Entity<Tbltrip>(entity =>
            {
                entity.HasKey(e => e.FldTripId)
                    .HasName("PRIMARY");

                entity.ToTable("tbltrip");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.FldTripId, "fldTripId_UNIQUE")
                    .IsUnique();

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

                entity.Property(e => e.FldTripMember).HasColumnName("fldTripMember");

                entity.Property(e => e.FldTripName)
                    .HasMaxLength(50)
                    .HasColumnName("fldTripName")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.FldTripPresenter)
                    .HasMaxLength(50)
                    .HasColumnName("fldTripPresenter");

                entity.Property(e => e.FldTripStatus)
                    .HasMaxLength(50)
                    .HasColumnName("fldTripStatus")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<Tbltripdetail>(entity =>
            {
                entity.HasKey(e => e.FldTripId)
                    .HasName("PRIMARY");

                entity.ToTable("tbltripdetail");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.FldTripId, "fldTripId_UNIQUE")
                    .IsUnique();

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

            modelBuilder.Entity<Tbltripitem>(entity =>
            {
                entity.HasKey(e => e.FldItemId)
                    .HasName("PRIMARY");

                entity.ToTable("tbltripitem");

                entity.Property(e => e.FldItemId)
                    .HasMaxLength(50)
                    .HasColumnName("fldItemId")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.FldCreateBy)
                    .HasMaxLength(50)
                    .HasColumnName("fldCreateBy");

                entity.Property(e => e.FldCreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fldCreateDate");

                entity.Property(e => e.FldItemCategory)
                    .HasMaxLength(50)
                    .HasColumnName("fldItemCategory")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.FldItemDescription).HasColumnName("fldItemDescription");

                entity.Property(e => e.FldItemName)
                    .HasMaxLength(150)
                    .HasColumnName("fldItemName");

                entity.Property(e => e.FldPriceMax)
                    .HasPrecision(10, 2)
                    .HasColumnName("fldPriceMax");

                entity.Property(e => e.FldPriceMin)
                    .HasPrecision(10, 2)
                    .HasColumnName("fldPriceMin");

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

            modelBuilder.Entity<Tbltripmember>(entity =>
            {
                entity.HasKey(e => e.FldMemberId)
                    .HasName("PRIMARY");

                entity.ToTable("tbltripmember");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.FldMemberId).HasColumnName("fldMemberId");

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
                    .HasColumnName("fldNickName");

                entity.Property(e => e.FldStatus)
                    .HasMaxLength(10)
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

                entity.Property(e => e.FldUserId)
                    .HasMaxLength(50)
                    .HasColumnName("fldUserId");
            });

            modelBuilder.Entity<Tbltripplan>(entity =>
            {
                entity.HasKey(e => e.FldPlanId)
                    .HasName("PRIMARY");

                entity.ToTable("tbltripplan");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.FldPlanId, "fldPlanId_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.FldPlanId).HasColumnName("fldPlanId");

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
                entity.HasKey(e => e.FldRoleId)
                    .HasName("PRIMARY");

                entity.ToTable("tbltriprole");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.FldRoleId, "fldRoleId_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.FldRoleId).HasColumnName("fldRoleId");

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
                entity.HasKey(e => e.FldUserId)
                    .HasName("PRIMARY");

                entity.ToTable("tbluser");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.FldUserId, "fldUserId_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.FldUsername, "fldUsername_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.FldUserId)
                    .HasMaxLength(50)
                    .HasColumnName("fldUserId");

                entity.Property(e => e.FldPassword)
                    .HasMaxLength(1000)
                    .HasColumnName("fldPassword");

                entity.Property(e => e.FldUsername)
                    .HasMaxLength(45)
                    .HasColumnName("fldUsername");
            });

            modelBuilder.Entity<Tbluserdetail>(entity =>
            {
                entity.HasKey(e => e.FldUserId)
                    .HasName("PRIMARY");

                entity.ToTable("tbluserdetail");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.FldEmail, "fldEmail_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.FldPhone, "fldPhone_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.FldUserId, "fldUserId_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.FldUserId)
                    .HasMaxLength(50)
                    .HasColumnName("fldUserId");

                entity.Property(e => e.FldActiveStatus)
                    .HasMaxLength(10)
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
                    .HasMaxLength(50)
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
                    .HasMaxLength(20)
                    .HasColumnName("fldPhone");

                entity.Property(e => e.FldRole)
                    .HasMaxLength(20)
                    .HasColumnName("fldRole")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.FldTripCancelled).HasColumnName("fldTripCancelled");

                entity.Property(e => e.FldTripCompleted).HasColumnName("fldTripCompleted");

                entity.Property(e => e.FldTripCreated).HasColumnName("fldTripCreated");

                entity.Property(e => e.FldTripJoined).HasColumnName("fldTripJoined");

                entity.Property(e => e.FldUpdateBy)
                    .HasMaxLength(50)
                    .HasColumnName("fldUpdateBy");

                entity.Property(e => e.FldUpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fldUpdateDate");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
