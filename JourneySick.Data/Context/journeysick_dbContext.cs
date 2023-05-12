using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JourneySick.Data.Models.Entities
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

        public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; } = null!;
        public virtual DbSet<Tblfeedback> Tblfeedbacks { get; set; } = null!;
        public virtual DbSet<Tblitem> Tblitems { get; set; } = null!;
        public virtual DbSet<Tblitemcategory> Tblitemcategories { get; set; } = null!;
        public virtual DbSet<Tblmaplocation> Tblmaplocations { get; set; } = null!;
        public virtual DbSet<Tblplanlocation> Tblplanlocations { get; set; } = null!;
        public virtual DbSet<Tblrouteplan> Tblrouteplans { get; set; } = null!;
        public virtual DbSet<Tbltrip> Tbltrips { get; set; } = null!;
        public virtual DbSet<Tbltripdetail> Tbltripdetails { get; set; } = null!;
        public virtual DbSet<Tbltripitem> Tbltripitems { get; set; } = null!;
        public virtual DbSet<Tbltripmember> Tbltripmembers { get; set; } = null!;
        public virtual DbSet<Tbltripplan> Tbltripplans { get; set; } = null!;
        public virtual DbSet<Tbltriprole> Tbltriproles { get; set; } = null!;
        public virtual DbSet<Tbltriproute> Tbltriproutes { get; set; } = null!;
        public virtual DbSet<Tbluser> Tblusers { get; set; } = null!;
        public virtual DbSet<Tbluserdetail> Tbluserdetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=journeysick.mysql.database.azure.com;userid=journeysick_root;password=Adminkhaido1;database=journeysick_db", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ProductVersion).HasMaxLength(32);
            });

            modelBuilder.Entity<Tblfeedback>(entity =>
            {
                entity.HasKey(e => e.FldFeedbackId)
                    .HasName("PRIMARY");

                entity.ToTable("tblfeedback");

                entity.Property(e => e.FldFeedbackId).HasColumnName("fldFeedbackId");

                entity.Property(e => e.FldCreateBy)
                    .HasMaxLength(20)
                    .HasColumnName("fldCreateBy");

                entity.Property(e => e.FldCreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fldCreateDate");

                entity.Property(e => e.FldDislike)
                    .HasColumnName("fldDislike")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.FldFeedback).HasColumnName("fldFeedback");

                entity.Property(e => e.FldLike)
                    .HasColumnName("fldLike")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.FldLocationName)
                    .HasMaxLength(100)
                    .HasColumnName("fldLocationName");

                entity.Property(e => e.FldRate)
                    .HasColumnName("fldRate")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.FldTripId)
                    .HasMaxLength(20)
                    .HasColumnName("fldTripId");

                entity.Property(e => e.FldUpdateBy)
                    .HasMaxLength(20)
                    .HasColumnName("fldUpdateBy");

                entity.Property(e => e.FldUpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fldUpdateDate");

                entity.Property(e => e.FldUserId)
                    .HasMaxLength(20)
                    .HasColumnName("fldUserId");
            });

            modelBuilder.Entity<Tblitem>(entity =>
            {
                entity.HasKey(e => e.FldItemId)
                    .HasName("PRIMARY");

                entity.ToTable("tblitem");

                entity.Property(e => e.FldItemId).HasColumnName("fldItemId");

                entity.Property(e => e.FldCategoryId).HasColumnName("fldCategoryId");

                entity.Property(e => e.FldCreateBy)
                    .HasMaxLength(20)
                    .HasColumnName("fldCreateBy");

                entity.Property(e => e.FldCreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fldCreateDate");

                entity.Property(e => e.FldItemDescription).HasColumnName("fldItemDescription");

                entity.Property(e => e.FldItemName)
                    .HasMaxLength(150)
                    .HasColumnName("fldItemName");

                entity.Property(e => e.FldItemUsage).HasColumnName("fldItemUsage");

                entity.Property(e => e.FldPriceMax)
                    .HasPrecision(12, 2)
                    .HasColumnName("fldPriceMax")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.FldPriceMin)
                    .HasPrecision(12, 2)
                    .HasColumnName("fldPriceMin")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.FldQuantity)
                    .HasColumnName("fldQuantity")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.FldUpdateBy)
                    .HasMaxLength(20)
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

                entity.Property(e => e.FldCategoryId).HasColumnName("fldCategoryId");

                entity.Property(e => e.FldCategoryDescription)
                    .HasColumnType("tinytext")
                    .HasColumnName("fldCategoryDescription");

                entity.Property(e => e.FldCategoryName)
                    .HasMaxLength(150)
                    .HasColumnName("fldCategoryName");

                entity.Property(e => e.FldCreateBy)
                    .HasMaxLength(20)
                    .HasColumnName("fldCreateBy");

                entity.Property(e => e.FldCreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fldCreateDate");

                entity.Property(e => e.FldUpdateBy)
                    .HasMaxLength(20)
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

                entity.Property(e => e.FldMapId).HasColumnName("fldMapId");

                entity.Property(e => e.FldLatitude)
                    .HasMaxLength(200)
                    .HasColumnName("fldLatitude");

                entity.Property(e => e.FldLocationName)
                    .HasMaxLength(200)
                    .HasColumnName("fldLocationName");

                entity.Property(e => e.FldLongitude)
                    .HasMaxLength(200)
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

            modelBuilder.Entity<Tblrouteplan>(entity =>
            {
                entity.HasKey(e => e.FldPlanId)
                    .HasName("PRIMARY");

                entity.ToTable("tblrouteplan");

                entity.Property(e => e.FldPlanId).HasColumnName("fldPlanId");

                entity.Property(e => e.FldPlanDescription)
                    .HasColumnType("tinytext")
                    .HasColumnName("fldPlanDescription");

                entity.Property(e => e.FldRouteId).HasColumnName("fldRouteId");
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
                    .HasMaxLength(20)
                    .HasColumnName("fldTripId");

                entity.Property(e => e.FldTripBudget)
                    .HasPrecision(15, 2)
                    .HasColumnName("fldTripBudget");

                entity.Property(e => e.FldTripDescription).HasColumnName("fldTripDescription");

                entity.Property(e => e.FldTripMember).HasColumnName("fldTripMember");

                entity.Property(e => e.FldTripName)
                    .HasMaxLength(100)
                    .HasColumnName("fldTripName")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.FldTripPresenter)
                    .HasMaxLength(20)
                    .HasColumnName("fldTripPresenter");

                entity.Property(e => e.FldTripStatus)
                    .HasMaxLength(50)
                    .HasColumnName("fldTripStatus")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");
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
                    .HasMaxLength(20)
                    .HasColumnName("fldTripId");

                entity.Property(e => e.FldCreateBy)
                    .HasMaxLength(20)
                    .HasColumnName("fldCreateBy");

                entity.Property(e => e.FldCreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fldCreateDate");

                entity.Property(e => e.FldDistance)
                    .HasPrecision(12, 2)
                    .HasColumnName("fldDistance")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.FldEstimateEndDate).HasColumnName("fldEstimateEndDate");

                entity.Property(e => e.FldEstimateEndTime)
                    .HasMaxLength(10)
                    .HasColumnName("fldEstimateEndTime")
                    .HasComment("'HH:MM'");

                entity.Property(e => e.FldEstimateStartDate).HasColumnName("fldEstimateStartDate");

                entity.Property(e => e.FldEstimateStartTime)
                    .HasMaxLength(10)
                    .HasColumnName("fldEstimateStartTime")
                    .HasComment("'HH:MM'");

                entity.Property(e => e.FldTripDestinationLocationId).HasColumnName("fldTripDestinationLocationId");

                entity.Property(e => e.FldTripStartLocationId).HasColumnName("fldTripStartLocationId");

                entity.Property(e => e.FldUpdateBy)
                    .HasMaxLength(20)
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

                entity.Property(e => e.FldItemId).HasColumnName("fldItemId");

                entity.Property(e => e.FldCategoryId).HasColumnName("fldCategoryId");

                entity.Property(e => e.FldCreateBy)
                    .HasMaxLength(20)
                    .HasColumnName("fldCreateBy");

                entity.Property(e => e.FldCreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fldCreateDate");

                entity.Property(e => e.FldItemDescription)
                    .HasColumnType("mediumtext")
                    .HasColumnName("fldItemDescription");

                entity.Property(e => e.FldItemName)
                    .HasMaxLength(150)
                    .HasColumnName("fldItemName");

                entity.Property(e => e.FldPriceMax)
                    .HasPrecision(12, 2)
                    .HasColumnName("fldPriceMax")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.FldPriceMin)
                    .HasPrecision(12, 2)
                    .HasColumnName("fldPriceMin")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.FldQuantity)
                    .HasColumnName("fldQuantity")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.FldTripId)
                    .HasMaxLength(20)
                    .HasColumnName("fldTripId");

                entity.Property(e => e.FldUpdateBy)
                    .HasMaxLength(20)
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

                entity.Property(e => e.FldConfirmation)
                    .HasMaxLength(10)
                    .HasColumnName("fldConfirmation")
                    .HasDefaultValueSql("'NO'")
                    .IsFixedLength();

                entity.Property(e => e.FldCreateBy)
                    .HasMaxLength(20)
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

                entity.Property(e => e.FldSendDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fldSendDate");

                entity.Property(e => e.FldStatus)
                    .HasMaxLength(10)
                    .HasColumnName("fldStatus");

                entity.Property(e => e.FldTripId)
                    .HasMaxLength(20)
                    .HasColumnName("fldTripId");

                entity.Property(e => e.FldUpdateBy)
                    .HasMaxLength(20)
                    .HasColumnName("fldUpdateBy");

                entity.Property(e => e.FldUpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fldUpdateDate");

                entity.Property(e => e.FldUserId)
                    .HasMaxLength(20)
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
                    .HasMaxLength(20)
                    .HasColumnName("fldCreateBy");

                entity.Property(e => e.FldCreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fldCreateDate");

                entity.Property(e => e.FldPlanDescription).HasColumnName("fldPlanDescription");

                entity.Property(e => e.FldTripId)
                    .HasMaxLength(20)
                    .HasColumnName("fldTripId");

                entity.Property(e => e.FldUpdateBy)
                    .HasMaxLength(20)
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
                    .HasMaxLength(150)
                    .HasColumnName("fldRoleName");

                entity.Property(e => e.FldType)
                    .HasMaxLength(20)
                    .HasColumnName("fldType")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");
            });

            modelBuilder.Entity<Tbltriproute>(entity =>
            {
                entity.HasKey(e => e.FldRouteId)
                    .HasName("PRIMARY");

                entity.ToTable("tbltriproute");

                entity.Property(e => e.FldRouteId).HasColumnName("fldRouteId");

                entity.Property(e => e.FldDistance)
                    .HasPrecision(12, 2)
                    .HasColumnName("fldDistance");

                entity.Property(e => e.FldEstimateTime)
                    .HasPrecision(5, 2)
                    .HasColumnName("fldEstimateTime")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.FldMapId).HasColumnName("fldMapId");

                entity.Property(e => e.FldPriority).HasColumnName("fldPriority");

                entity.Property(e => e.FldTripid)
                    .HasMaxLength(20)
                    .HasColumnName("fldTripid");
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
                    .HasMaxLength(20)
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
                    .HasMaxLength(20)
                    .HasColumnName("fldUserId");

                entity.Property(e => e.FldActiveStatus)
                    .HasMaxLength(10)
                    .HasColumnName("fldActiveStatus");

                entity.Property(e => e.FldAddress)
                    .HasColumnName("fldAddress")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.FldBirthday)
                    .HasColumnType("datetime")
                    .HasColumnName("fldBirthday");

                entity.Property(e => e.FldCreateBy)
                    .HasMaxLength(20)
                    .HasColumnName("fldCreateBy");

                entity.Property(e => e.FldCreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fldCreateDate");

                entity.Property(e => e.FldEmail)
                    .HasMaxLength(50)
                    .HasColumnName("fldEmail")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.FldExperience)
                    .HasColumnName("fldExperience")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.FldFullname)
                    .HasMaxLength(50)
                    .HasColumnName("fldFullname")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.FldPhone)
                    .HasMaxLength(20)
                    .HasColumnName("fldPhone");

                entity.Property(e => e.FldRole)
                    .HasMaxLength(20)
                    .HasColumnName("fldRole")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.FldTripCancelled)
                    .HasColumnName("fldTripCancelled")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.FldTripCompleted)
                    .HasColumnName("fldTripCompleted")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.FldTripCreated)
                    .HasColumnName("fldTripCreated")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.FldTripJoined)
                    .HasColumnName("fldTripJoined")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.FldUpdateBy)
                    .HasMaxLength(20)
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
