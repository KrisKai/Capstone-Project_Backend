using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace JourneySick.Data.Models.Entities
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
        public virtual DbSet<Trip> Trips { get; set; } = null!;
        public virtual DbSet<TripDetail> TripDetails { get; set; } = null!;
        public virtual DbSet<TripItem> TripItems { get; set; } = null!;
        public virtual DbSet<TripMember> TripMembers { get; set; } = null!;
        public virtual DbSet<TripRoute> TripRoutes { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserDetail> UserDetails { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;user=CRM;database=journey_sick_db", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.39-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Efmigrationshistory>(entity =>
            {
                entity.HasKey(e => e.MigrationId)
                    .HasName("PRIMARY");

                entity.ToTable("__efmigrationshistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ProductVersion).HasMaxLength(32);
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("feedback");

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

                entity.Property(e => e.ItemId).HasColumnType("int(11)");

                entity.Property(e => e.CategoryId).HasColumnType("int(11)");

                entity.Property(e => e.CreateBy).HasMaxLength(20);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.ItemName).HasMaxLength(150);

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

                entity.Property(e => e.MapId).HasColumnType("int(11)");

                entity.Property(e => e.Latitude).HasMaxLength(200);

                entity.Property(e => e.LocationName).HasMaxLength(200);

                entity.Property(e => e.Longitude).HasMaxLength(200);

                entity.Property(e => e.PlaceId).HasMaxLength(200);
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

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

                entity.HasIndex(e => e.TripId, "fldTripId_UNIQUE1")
                    .IsUnique();

                entity.Property(e => e.TripId).HasMaxLength(20);

                entity.Property(e => e.CreateBy).HasMaxLength(20);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EstimateEndDate).HasColumnType("datetime");

                entity.Property(e => e.EstimateStartDate).HasColumnType("datetime");

                entity.Property(e => e.TripDestinationLocationId).HasColumnType("int(11)");

                entity.Property(e => e.UpdateBy).HasMaxLength(20);

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TripItem>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("PRIMARY");

                entity.ToTable("trip_item");

                entity.Property(e => e.ItemId).HasColumnType("int(11)");

                entity.Property(e => e.CategoryId).HasColumnType("int(11)");

                entity.Property(e => e.CreateBy).HasMaxLength(20);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.ItemDescription).HasColumnType("mediumtext");

                entity.Property(e => e.ItemName).HasMaxLength(150);

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

                entity.HasCharSet("latin1")
                    .UseCollation("latin1_swedish_ci");

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

            modelBuilder.Entity<TripRoute>(entity =>
            {
                entity.HasKey(e => e.RouteId)
                    .HasName("PRIMARY");

                entity.ToTable("trip_route");

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
