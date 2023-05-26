﻿// <auto-generated />
using System;
using JourneySick.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JourneySick.Data.Migrations
{
    [DbContext(typeof(journeysick_dbContext))]
    partial class journeysick_dbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb4");

            modelBuilder.Entity("JourneySick.Data.Models.Entities.Feedback", b =>
                {
                    b.Property<int>("FeedbackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CreateBy")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("Dislike")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("'0'");

                    b.Property<string>("FeedbackDescription")
                        .HasColumnType("longtext");

                    b.Property<int?>("Like")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("'0'");

                    b.Property<string>("LocationName")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<float?>("Rate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValueSql("'0'");

                    b.Property<string>("TripId")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("UpdateBy")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("FeedbackId");

                    b.ToTable("feedback", (string)null);
                });

            modelBuilder.Entity("JourneySick.Data.Models.Entities.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("CreateBy")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("ItemDescription")
                        .HasColumnType("longtext");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("ItemUsage")
                        .HasColumnType("longtext");

                    b.Property<decimal?>("PriceMax")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)")
                        .HasDefaultValueSql("'0.00'");

                    b.Property<decimal?>("PriceMin")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)")
                        .HasDefaultValueSql("'0.00'");

                    b.Property<int?>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("'0'");

                    b.Property<string>("UpdateBy")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.HasKey("ItemId");

                    b.ToTable("item", (string)null);
                });

            modelBuilder.Entity("JourneySick.Data.Models.Entities.ItemCategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CategoryDescription")
                        .HasColumnType("tinytext");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("CreateBy")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("UpdateBy")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.HasKey("CategoryId")
                        .HasName("PRIMARY");

                    b.ToTable("item_category", (string)null);
                });

            modelBuilder.Entity("JourneySick.Data.Models.Entities.MapLocation", b =>
                {
                    b.Property<int>("MapId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Latitude")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("LocationName")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Longitude")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.HasKey("MapId")
                        .HasName("PRIMARY");

                    b.ToTable("map_location", (string)null);
                });

            modelBuilder.Entity("JourneySick.Data.Models.Entities.PlanLocation", b =>
                {
                    b.Property<int>("PlanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CreateBy")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("LocationArrivalTime")
                        .HasColumnType("datetime");

                    b.Property<int?>("MapId")
                        .HasColumnType("int");

                    b.Property<string>("PlanLocationDescription")
                        .HasColumnType("text");

                    b.Property<string>("PlanLocationId")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("UpdateBy")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.HasKey("PlanId")
                        .HasName("PRIMARY");

                    b.ToTable("plan_location", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "latin1");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "latin1_swedish_ci");
                });

            modelBuilder.Entity("JourneySick.Data.Models.Entities.RoutePlan", b =>
                {
                    b.Property<int>("PlanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("PlanDescription")
                        .HasColumnType("tinytext");

                    b.Property<int?>("RouteId")
                        .HasColumnType("int");

                    b.HasKey("PlanId")
                        .HasName("PRIMARY");

                    b.ToTable("route_plan", (string)null);
                });

            modelBuilder.Entity("JourneySick.Data.Models.Entities.Trip", b =>
                {
                    b.Property<string>("TripId")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<decimal?>("TripBudget")
                        .HasPrecision(15, 2)
                        .HasColumnType("decimal(15,2)");

                    b.Property<string>("TripCompleted")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(1)
                        .HasColumnType("char(1)")
                        .HasDefaultValueSql("'N'")
                        .IsFixedLength();

                    b.Property<string>("TripDescription")
                        .HasColumnType("longtext");

                    b.Property<int?>("TripMember")
                        .HasColumnType("int");

                    b.Property<string>("TripName")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .UseCollation("utf8mb3_general_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("TripName"), "utf8mb3");

                    b.Property<string>("TripPresenter")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("TripStatus")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .UseCollation("utf8mb3_general_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("TripStatus"), "utf8mb3");

                    b.Property<string>("TripThumbnail")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("TripId");

                    b.HasIndex(new[] { "TripId" }, "fldTripId_UNIQUE")
                        .IsUnique();

                    b.ToTable("trip", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "latin1");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "latin1_swedish_ci");
                });

            modelBuilder.Entity("JourneySick.Data.Models.Entities.TripDetail", b =>
                {
                    b.Property<string>("TripId")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("CreateBy")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<decimal?>("Distance")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)")
                        .HasDefaultValueSql("'0.00'");

                    b.Property<DateOnly?>("EstimateEndDate")
                        .HasColumnType("date");

                    b.Property<string>("EstimateEndTime")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasComment("'HH:MM'");

                    b.Property<DateOnly?>("EstimateStartDate")
                        .HasColumnType("date");

                    b.Property<string>("EstimateStartTime")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasComment("'HH:MM'");

                    b.Property<int?>("TripDestinationLocationId")
                        .HasColumnType("int");

                    b.Property<int?>("TripStartLocationId")
                        .HasColumnType("int");

                    b.Property<string>("UpdateBy")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.HasKey("TripId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "TripId" }, "fldTripId_UNIQUE")
                        .IsUnique()
                        .HasDatabaseName("fldTripId_UNIQUE1");

                    b.ToTable("trip_detail", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "latin1");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "latin1_swedish_ci");
                });

            modelBuilder.Entity("JourneySick.Data.Models.Entities.TripItem", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("CreateBy")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("ItemDescription")
                        .HasColumnType("mediumtext");

                    b.Property<string>("ItemName")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<decimal?>("PriceMax")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)")
                        .HasDefaultValueSql("'0.00'");

                    b.Property<decimal?>("PriceMin")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)")
                        .HasDefaultValueSql("'0.00'");

                    b.Property<int?>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("'0'");

                    b.Property<string>("TripId")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("UpdateBy")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.HasKey("ItemId")
                        .HasName("PRIMARY");

                    b.ToTable("trip_item", (string)null);
                });

            modelBuilder.Entity("JourneySick.Data.Models.Entities.TripMember", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Confirmation")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("char(10)")
                        .HasDefaultValueSql("'N'")
                        .IsFixedLength();

                    b.Property<string>("CreateBy")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("MemberRole")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("NickName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("SendDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Status")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("TripId")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("UpdateBy")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("MemberId")
                        .HasName("PRIMARY");

                    b.ToTable("trip_member", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "latin1");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "latin1_swedish_ci");
                });

            modelBuilder.Entity("JourneySick.Data.Models.Entities.TripPlan", b =>
                {
                    b.Property<int>("PlanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CreateBy")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("PlanDescription")
                        .HasColumnType("longtext");

                    b.Property<string>("TripId")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("UpdateBy")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.HasKey("PlanId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "PlanId" }, "fldPlanId_UNIQUE")
                        .IsUnique();

                    b.ToTable("trip_plan", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "latin1");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "latin1_swedish_ci");
                });

            modelBuilder.Entity("JourneySick.Data.Models.Entities.TripRole", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("RoleName")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Type")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .UseCollation("utf8mb3_general_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Type"), "utf8mb3");

                    b.HasKey("RoleId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "RoleId" }, "fldRoleId_UNIQUE")
                        .IsUnique();

                    b.ToTable("trip_role", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "latin1");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "latin1_swedish_ci");
                });

            modelBuilder.Entity("JourneySick.Data.Models.Entities.TripRoute", b =>
                {
                    b.Property<int>("RouteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal?>("Distance")
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)");

                    b.Property<decimal?>("EstimateTime")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)")
                        .HasDefaultValueSql("'0.00'");

                    b.Property<int?>("MapId")
                        .HasColumnType("int");

                    b.Property<int?>("Priority")
                        .HasColumnType("int");

                    b.Property<string>("Tripid")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.HasKey("RouteId")
                        .HasName("PRIMARY");

                    b.ToTable("trip_route", (string)null);
                });

            modelBuilder.Entity("JourneySick.Data.Models.Entities.User", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Confirmation")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(1)
                        .HasColumnType("char(1)")
                        .HasDefaultValueSql("'N'")
                        .IsFixedLength();

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)");

                    b.Property<DateTime?>("SendDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.HasKey("UserId");

                    b.HasIndex(new[] { "UserId" }, "fldUserId_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "Username" }, "fldUsername_UNIQUE")
                        .IsUnique();

                    b.ToTable("user", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "latin1");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "latin1_swedish_ci");
                });

            modelBuilder.Entity("JourneySick.Data.Models.Entities.UserDetail", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("ActiveStatus")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("Address")
                        .HasColumnType("longtext")
                        .UseCollation("utf8mb3_general_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Address"), "utf8mb3");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime");

                    b.Property<string>("CreateBy")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .UseCollation("utf8mb3_general_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Email"), "utf8mb3");

                    b.Property<float?>("Experience")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasDefaultValueSql("'0'");

                    b.Property<string>("Fullname")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .UseCollation("utf8mb3_general_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Fullname"), "utf8mb3");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Role")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .UseCollation("utf8mb3_general_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Role"), "utf8mb3");

                    b.Property<int?>("TripCancelled")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("'0'");

                    b.Property<int?>("TripCompleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("'0'");

                    b.Property<int?>("TripCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("'0'");

                    b.Property<int?>("TripJoined")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("'0'");

                    b.Property<string>("UpdateBy")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime");

                    b.HasKey("UserId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Email" }, "fldEmail_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "Phone" }, "fldPhone_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "UserId" }, "fldUserId_UNIQUE")
                        .IsUnique()
                        .HasDatabaseName("fldUserId_UNIQUE1");

                    b.ToTable("user_detail", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "latin1");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "latin1_swedish_ci");
                });
#pragma warning restore 612, 618
        }
    }
}
