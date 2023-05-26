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

        public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
        public virtual DbSet<Item> Items { get; set; } = null!;
        public virtual DbSet<ItemCategory> ItemCategories { get; set; } = null!;
        public virtual DbSet<MapLocation> MapLocations { get; set; } = null!;
        public virtual DbSet<PlanLocation> PlanLocations { get; set; } = null!;
        public virtual DbSet<RoutePlan> RoutePlans { get; set; } = null!;
        public virtual DbSet<Trip> Trips { get; set; } = null!;
        public virtual DbSet<TripDetail> TripDetails { get; set; } = null!;
        public virtual DbSet<TripItem> TripItems { get; set; } = null!;
        public virtual DbSet<TripMember> TripMembers { get; set; } = null!;
        public virtual DbSet<TripPlan> TripPlans { get; set; } = null!;
        public virtual DbSet<TripRole> TripRoles { get; set; } = null!;
        public virtual DbSet<TripRoute> TripRoutes { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserDetail> UserDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=journeysick.mysql.database.azure.com;user=journeysick_root;password=Adminkhaido1;database=journeysick_db", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("feedback");

                entity.Property(e => e.CreateBy).HasMaxLength(20);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Dislike).HasDefaultValueSql("'0'");

                entity.Property(e => e.Like).HasDefaultValueSql("'0'");

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

                entity.Property(e => e.CreateBy).HasMaxLength(20);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.ItemName).HasMaxLength(150);

                entity.Property(e => e.PriceMax)
                    .HasPrecision(12, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.PriceMin)
                    .HasPrecision(12, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.Quantity).HasDefaultValueSql("'0'");

                entity.Property(e => e.UpdateBy).HasMaxLength(20);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ItemCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PRIMARY");

                entity.ToTable("item_category");

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

                entity.Property(e => e.Latitude).HasMaxLength(200);

                entity.Property(e => e.LocationName).HasMaxLength(200);

                entity.Property(e => e.Longitude).HasMaxLength(200);
            });

            modelBuilder.Entity<PlanLocation>(entity =>
            {
                entity.HasKey(e => e.PlanId)
                    .HasName("PRIMARY");

                entity.ToTable("plan_location");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.Property(e => e.CreateBy).HasMaxLength(50);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.LocationArrivalTime).HasColumnType("datetime");

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

                entity.Property(e => e.PlanDescription).HasColumnType("tinytext");
            });

            modelBuilder.Entity<Trip>(entity =>
            {
                entity.ToTable("trip");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.TripId, "fldTripId_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.TripId).HasMaxLength(20);

                entity.Property(e => e.TripBudget).HasPrecision(15, 2);

                entity.Property(e => e.TripCompleted)
                    .HasMaxLength(1)
                    .HasDefaultValueSql("'N'")
                    .IsFixedLength();

                entity.Property(e => e.TripName)
                    .HasMaxLength(100)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.TripPresenter).HasMaxLength(20);

                entity.Property(e => e.TripStatus)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.TripThumbnail).HasMaxLength(255);
            });

            modelBuilder.Entity<TripDetail>(entity =>
            {
                entity.HasKey(e => e.TripId)
                    .HasName("PRIMARY");

                entity.ToTable("trip_detail");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.TripId, "fldTripId_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.TripId).HasMaxLength(20);

                entity.Property(e => e.CreateBy).HasMaxLength(20);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Distance)
                    .HasPrecision(12, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.EstimateEndTime)
                    .HasMaxLength(10)
                    .HasComment("'HH:MM'");

                entity.Property(e => e.EstimateStartTime)
                    .HasMaxLength(10)
                    .HasComment("'HH:MM'");

                entity.Property(e => e.UpdateBy).HasMaxLength(20);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TripItem>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("PRIMARY");

                entity.ToTable("trip_item");

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

                entity.Property(e => e.Quantity).HasDefaultValueSql("'0'");

                entity.Property(e => e.TripId).HasMaxLength(20);

                entity.Property(e => e.UpdateBy).HasMaxLength(20);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TripMember>(entity =>
            {
                entity.HasKey(e => e.MemberId)
                    .HasName("PRIMARY");

                entity.ToTable("trip_member");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

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

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.PlanId, "fldPlanId_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.CreateBy).HasMaxLength(20);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.TripId).HasMaxLength(20);

                entity.Property(e => e.UpdateBy).HasMaxLength(20);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TripRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PRIMARY");

                entity.ToTable("trip_role");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.RoleId, "fldRoleId_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.RoleName).HasMaxLength(150);

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");
            });

            modelBuilder.Entity<TripRoute>(entity =>
            {
                entity.HasKey(e => e.RouteId)
                    .HasName("PRIMARY");

                entity.ToTable("trip_route");

                entity.Property(e => e.Distance).HasPrecision(12, 2);

                entity.Property(e => e.EstimateTime)
                    .HasPrecision(5, 2)
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.Tripid).HasMaxLength(20);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

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

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.Email, "fldEmail_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Phone, "fldPhone_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.UserId, "fldUserId_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.UserId).HasMaxLength(20);

                entity.Property(e => e.ActiveStatus).HasMaxLength(10);

                entity.Property(e => e.Address)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Birthday).HasColumnType("datetime");

                entity.Property(e => e.CreateBy).HasMaxLength(20);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Experience).HasDefaultValueSql("'0'");

                entity.Property(e => e.Fullname)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.Property(e => e.Role)
                    .HasMaxLength(20)
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.TripCancelled).HasDefaultValueSql("'0'");

                entity.Property(e => e.TripCompleted).HasDefaultValueSql("'0'");

                entity.Property(e => e.TripCreated).HasDefaultValueSql("'0'");

                entity.Property(e => e.TripJoined).HasDefaultValueSql("'0'");

                entity.Property(e => e.UpdateBy).HasMaxLength(20);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
