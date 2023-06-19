using System;
using System.Collections.Generic;
using JourneySick.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JourneySick.Data.Context
{
    public partial class journey_sick_dbContext : DbContext
    {
        public journey_sick_dbContext()
        {
        }

        public journey_sick_dbContext(DbContextOptions<journey_sick_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Efmigrationshistory> Efmigrationshistories { get; set; } = null!;
        public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
        public virtual DbSet<Item> Items { get; set; } = null!;
        public virtual DbSet<ItemCategory> ItemCategories { get; set; } = null!;
        public virtual DbSet<MapLocation> MapLocations { get; set; } = null!;
        public virtual DbSet<PlanLocation> PlanLocations { get; set; } = null!;
        public virtual DbSet<RoutePlan> RoutePlans { get; set; } = null!;
        public virtual DbSet<Tblplanlocation> Tblplanlocations { get; set; } = null!;
        public virtual DbSet<Tbltrip> Tbltrips { get; set; } = null!;
        public virtual DbSet<Tbltripdetail> Tbltripdetails { get; set; } = null!;
        public virtual DbSet<Tbltripmember> Tbltripmembers { get; set; } = null!;
        public virtual DbSet<Tbltripplan> Tbltripplans { get; set; } = null!;
        public virtual DbSet<Tbltriprole> Tbltriproles { get; set; } = null!;
        public virtual DbSet<Tbluser> Tblusers { get; set; } = null!;
        public virtual DbSet<Tbluserdetail> Tbluserdetails { get; set; } = null!;
        public virtual DbSet<Trip> Trips { get; set; } = null!;
        public virtual DbSet<TripDetail> TripDetails { get; set; } = null!;
        public virtual DbSet<TripItem> TripItems { get; set; } = null!;
        public virtual DbSet<TripMember> TripMembers { get; set; } = null!;
        public virtual DbSet<TripPlan> TripPlans { get; set; } = null!;
        public virtual DbSet<TripRoute> TripRoutes { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserDetail> UserDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;user=CRM;database=journey_sick_db", ServerVersion.Parse("5.7.39-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__efmigrationshistory");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ProductVersion).HasMaxLength(32);
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("feedback");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.FeedbackId).HasColumnType("int(11)");

                entity.Property(e => e.CreateBy).HasMaxLength(20);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Dislike)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Like)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.LocationName).HasMaxLength(100);

                entity.Property(e => e.Rate).HasDefaultValueSql("'0'");

                entity.Property(e => e.TripId).HasMaxLength(20);

                entity.Property(e => e.UpdateBy).HasMaxLength(20);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(20);
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("item");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.ItemId).HasColumnType("int(11)");

                entity.Property(e => e.CategoryId).HasColumnType("int(11)");

                entity.Property(e => e.CreateBy).HasMaxLength(20);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.ItemName).HasMaxLength(150);

                entity.Property(e => e.PriceMax)
                    .HasPrecision(12, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.PriceMin)
                    .HasPrecision(12, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.Quantity)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.UpdateBy).HasMaxLength(20);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ItemCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PRIMARY");

                entity.ToTable("item_category");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.CategoryId).HasColumnType("int(11)");

                entity.Property(e => e.CategoryDescription).HasColumnType("tinytext");

                entity.Property(e => e.CategoryName).HasMaxLength(150);

                entity.Property(e => e.CreateBy).HasMaxLength(20);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.UpdateBy).HasMaxLength(20);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MapLocation>(entity =>
            {
                entity.HasKey(e => e.MapId)
                    .HasName("PRIMARY");

                entity.ToTable("map_location");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.MapId).HasColumnType("int(11)");

                entity.Property(e => e.Latitude).HasMaxLength(200);

                entity.Property(e => e.LocationName).HasMaxLength(200);

                entity.Property(e => e.Longitude).HasMaxLength(200);
            });

            modelBuilder.Entity<PlanLocation>(entity =>
            {
                entity.HasKey(e => e.PlanId)
                    .HasName("PRIMARY");

                entity.ToTable("plan_location");

                entity.Property(e => e.PlanId).HasColumnType("int(11)");

                entity.Property(e => e.CreateBy).HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.LocationArrivalTime).HasColumnType("datetime");

                entity.Property(e => e.MapId).HasColumnType("int(11)");

                entity.Property(e => e.PlanLocationDescription).HasColumnType("text");

                entity.Property(e => e.PlanLocationId).HasMaxLength(50);

                entity.Property(e => e.UpdateBy).HasMaxLength(50);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<RoutePlan>(entity =>
            {
                entity.HasKey(e => e.PlanId)
                    .HasName("PRIMARY");

                entity.ToTable("route_plan");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.PlanId).HasColumnType("int(11)");

                entity.Property(e => e.PlanDescription).HasColumnType("tinytext");

                entity.Property(e => e.RouteId).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Tblplanlocation>(entity =>
            {
                entity.HasKey(e => e.FldPlanId)
                    .HasName("PRIMARY");

                entity.ToTable("tblplanlocation");

                entity.Property(e => e.FldPlanId)
                    .HasColumnType("int(11)")
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
                entity.HasKey(e => e.FldTripId)
                    .HasName("PRIMARY");

                entity.ToTable("tbltrip");

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

                entity.Property(e => e.FldTripMember)
                    .HasColumnType("int(11)")
                    .HasColumnName("fldTripMember");

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

            modelBuilder.Entity<Tbltripmember>(entity =>
            {
                entity.HasKey(e => e.FldUserId)
                    .HasName("PRIMARY");

                entity.ToTable("tbltripmember");

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
                    .HasColumnName("fldStatus")
                    .IsFixedLength();

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
                entity.HasKey(e => e.FldPlanId)
                    .HasName("PRIMARY");

                entity.ToTable("tbltripplan");

                entity.HasIndex(e => e.FldPlanId, "fldPlanId_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.FldPlanId)
                    .HasColumnType("int(11)")
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

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("updateDate");
            });

            modelBuilder.Entity<Tbltriprole>(entity =>
            {
                entity.HasKey(e => e.FldRoleId)
                    .HasName("PRIMARY");

                entity.ToTable("tbltriprole");

                entity.HasIndex(e => e.FldRoleId, "fldRoleId_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.FldRoleId)
                    .HasColumnType("int(11)")
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
                entity.HasKey(e => e.FldUserId)
                    .HasName("PRIMARY");

                entity.ToTable("tbluser");

                entity.HasIndex(e => e.FldUserId, "fldUserId_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.FldUsername, "fldUsername_UNIQUE")
                    .IsUnique();

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
                entity.HasKey(e => e.FldUserId)
                    .HasName("PRIMARY");

                entity.ToTable("tbluserdetail");

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
                    .HasMaxLength(50)
                    .HasColumnName("fldUpdateBy");

                entity.Property(e => e.FldUpdateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("fldUpdateDate");
            });

            modelBuilder.Entity<Trip>(entity =>
            {
                entity.ToTable("trip");

                entity.HasIndex(e => e.TripId, "fldTripId_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.TripId).HasMaxLength(20);

                entity.Property(e => e.TripBudget).HasPrecision(15, 2);

                entity.Property(e => e.TripCompleted)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'N'")
                    .IsFixedLength();

                entity.Property(e => e.TripMember).HasColumnType("int(11)");

                entity.Property(e => e.TripName)
                    .HasMaxLength(100)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.TripPresenter).HasMaxLength(20);

                entity.Property(e => e.TripStatus)
                    .HasMaxLength(50)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.TripThumbnail).HasMaxLength(255);
            });

            modelBuilder.Entity<TripDetail>(entity =>
            {
                entity.HasKey(e => e.TripId)
                    .HasName("PRIMARY");

                entity.ToTable("trip_detail");

                entity.HasIndex(e => e.TripId, "fldTripId_UNIQUE1")
                    .IsUnique();

                entity.Property(e => e.TripId).HasMaxLength(20);

                entity.Property(e => e.CreateBy).HasMaxLength(20);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Distance)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.EstimateEndTime)
                    .HasMaxLength(10)
                    .HasComment("'HH:MM'");

                entity.Property(e => e.EstimateStartTime)
                    .HasMaxLength(10)
                    .HasComment("'HH:MM'");

                entity.Property(e => e.TripDestinationLocationId).HasColumnType("int(11)");

                entity.Property(e => e.TripStartLocationId).HasColumnType("int(11)");

                entity.Property(e => e.UpdateBy).HasMaxLength(20);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TripItem>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("PRIMARY");

                entity.ToTable("trip_item");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.ItemId).HasColumnType("int(11)");

                entity.Property(e => e.CategoryId).HasColumnType("int(11)");

                entity.Property(e => e.CreateBy).HasMaxLength(20);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.ItemDescription).HasColumnType("mediumtext");

                entity.Property(e => e.ItemName).HasMaxLength(150);

                entity.Property(e => e.PriceMax)
                    .HasPrecision(12, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.PriceMin)
                    .HasPrecision(12, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.Quantity)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.TripId).HasMaxLength(20);

                entity.Property(e => e.UpdateBy).HasMaxLength(20);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TripMember>(entity =>
            {
                entity.HasKey(e => e.MemberId)
                    .HasName("PRIMARY");

                entity.ToTable("trip_member");

                entity.Property(e => e.MemberId).HasColumnType("int(11)");

                entity.Property(e => e.Confirmation)
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'N'")
                    .IsFixedLength();

                entity.Property(e => e.CreateBy).HasMaxLength(20);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.MemberRole).HasMaxLength(50);

                entity.Property(e => e.NickName).HasMaxLength(50);

                entity.Property(e => e.SendDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasMaxLength(10);

                entity.Property(e => e.TripId).HasMaxLength(20);

                entity.Property(e => e.UpdateBy).HasMaxLength(20);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.Property(e => e.UserId).HasMaxLength(20);
            });

            modelBuilder.Entity<TripPlan>(entity =>
            {
                entity.HasKey(e => e.PlanId)
                    .HasName("PRIMARY");

                entity.ToTable("trip_plan");

                entity.HasIndex(e => e.PlanId, "fldPlanId_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.PlanId).HasColumnType("int(11)");

                entity.Property(e => e.CreateBy).HasMaxLength(20);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.TripId).HasMaxLength(20);

                entity.Property(e => e.UpdateBy).HasMaxLength(20);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TripRoute>(entity =>
            {
                entity.HasKey(e => e.RouteId)
                    .HasName("PRIMARY");

                entity.ToTable("trip_route");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.RouteId).HasColumnType("int(11)");

                entity.Property(e => e.Distance).HasPrecision(12, 2);

                entity.Property(e => e.EstimateTime)
                    .HasPrecision(5, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.MapId).HasColumnType("int(11)");

                entity.Property(e => e.Note).HasMaxLength(200);

                entity.Property(e => e.PlanDateTime).HasColumnType("datetime");

                entity.Property(e => e.Priority).HasColumnType("int(11)");

                entity.Property(e => e.TripId).HasMaxLength(20);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.UserId, "fldUserId_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Username, "fldUsername_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.UserId).HasMaxLength(20);

                entity.Property(e => e.Confirmation)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'N'")
                    .IsFixedLength();

                entity.Property(e => e.Password).HasMaxLength(1000);

                entity.Property(e => e.SendDate).HasColumnType("datetime");

                entity.Property(e => e.Username).HasMaxLength(45);
            });

            modelBuilder.Entity<UserDetail>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PRIMARY");

                entity.ToTable("user_detail");

                entity.HasIndex(e => e.Email, "fldEmail_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Phone, "fldPhone_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.UserId, "fldUserId_UNIQUE1")
                    .IsUnique();

                entity.Property(e => e.UserId).HasMaxLength(20);

                entity.Property(e => e.ActiveStatus).HasMaxLength(10);

                entity.Property(e => e.Address)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Birthday).HasColumnType("datetime");

                entity.Property(e => e.CreateBy).HasMaxLength(20);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Experience).HasDefaultValueSql("'0'");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(50)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.Property(e => e.Role)
                    .HasMaxLength(20)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.TripCancelled)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.TripCompleted)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.TripCreated)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.TripJoined)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.UpdateBy).HasMaxLength(20);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
