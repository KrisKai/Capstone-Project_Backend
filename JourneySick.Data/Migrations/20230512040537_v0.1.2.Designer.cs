﻿// <auto-generated />
using System;
using JourneySick.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JourneySick.Data.Migrations
{
    [DbContext(typeof(journeysick_dbContext))]
    [Migration("20230512040537_v0.1.2")]
    partial class v012
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb4");

            modelBuilder.Entity("JourneySick.Data.Models.Entities.Efmigrationshistory", b =>
                {
                    b.Property<string>("MigrationId")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<string>("ProductVersion")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.HasKey("MigrationId")
                        .HasName("PRIMARY");

                    b.ToTable("__efmigrationshistory", (string)null);
                });

            modelBuilder.Entity("JourneySick.Data.Models.Entities.feedback", b =>
                {
                    b.Property<int>("FeedbackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("FeedbackId");

                    b.Property<string>("CreateBy")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("CreateBy");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("CreateDate");

                    b.Property<int?>("Dislike")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Dislike")
                        .HasDefaultValueSql("'0'");

                    b.Property<string>("Feedback")
                        .HasColumnType("longtext")
                        .HasColumnName("Feedback");

                    b.Property<int?>("Like")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Like")
                        .HasDefaultValueSql("'0'");

                    b.Property<string>("LocationName")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("LocationName");

                    b.Property<float?>("Rate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasColumnName("Rate")
                        .HasDefaultValueSql("'0'");

                    b.Property<string>("TripId")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("TripId");

                    b.Property<string>("UpdateBy")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("UpdateBy");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("UpdateDate");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("UserId");

                    b.HasKey("FeedbackId")
                        .HasName("PRIMARY");

                    b.ToTable("feedback", (string)null);
                });

            modelBuilder.Entity("JourneySick.Data.Models.Entities.item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ItemId");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("CategoryId");

                    b.Property<string>("CreateBy")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("CreateBy");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("CreateDate");

                    b.Property<string>("ItemDescription")
                        .HasColumnType("longtext")
                        .HasColumnName("ItemDescription");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("ItemName");

                    b.Property<string>("ItemUsage")
                        .HasColumnType("longtext")
                        .HasColumnName("ItemUsage");

                    b.Property<decimal?>("PriceMax")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)")
                        .HasColumnName("PriceMax")
                        .HasDefaultValueSql("'0.00'");

                    b.Property<decimal?>("PriceMin")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)")
                        .HasColumnName("PriceMin")
                        .HasDefaultValueSql("'0.00'");

                    b.Property<int?>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Quantity")
                        .HasDefaultValueSql("'0'");

                    b.Property<string>("UpdateBy")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("UpdateBy");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("UpdateDate");

                    b.HasKey("ItemId")
                        .HasName("PRIMARY");

                    b.ToTable("item", (string)null);
                });

            modelBuilder.Entity("JourneySick.Data.Models.Entities.itemcategory", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CategoryId");

                    b.Property<string>("CategoryDescription")
                        .HasColumnType("tinytext")
                        .HasColumnName("CategoryDescription");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("CategoryName");

                    b.Property<string>("CreateBy")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("CreateBy");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("CreateDate");

                    b.Property<string>("UpdateBy")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("UpdateBy");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("UpdateDate");

                    b.HasKey("CategoryId")
                        .HasName("PRIMARY");

                    b.ToTable("itemcategory", (string)null);
                });

            modelBuilder.Entity("JourneySick.Data.Models.Entities.maplocation", b =>
                {
                    b.Property<int>("MapId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MapId");

                    b.Property<string>("Latitude")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Latitude");

                    b.Property<string>("LocationName")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("LocationName");

                    b.Property<string>("Longitude")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Longitude");

                    b.HasKey("MapId")
                        .HasName("PRIMARY");

                    b.ToTable("maplocation", (string)null);
                });

            modelBuilder.Entity("JourneySick.Data.Models.Entities.planlocation", b =>
                {
                    b.Property<int>("PlanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PlanId");

                    b.Property<string>("CreateBy")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("CreateBy");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("CreateDate");

                    b.Property<DateTime?>("LocationArrivalTime")
                        .HasColumnType("datetime")
                        .HasColumnName("LocationArrivalTime");

                    b.Property<int?>("MapId")
                        .HasColumnType("int")
                        .HasColumnName("MapId");

                    b.Property<string>("PlanLocationDescription")
                        .HasColumnType("text")
                        .HasColumnName("PlanLocationDescription");

                    b.Property<string>("PlanLocationId")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("PlanLocationId");

                    b.Property<string>("UpdateBy")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("UpdateBy");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("UpdateDate");

                    b.HasKey("PlanId")
                        .HasName("PRIMARY");

                    b.ToTable("planlocation", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "latin1");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "latin1_swedish_ci");
                });

            modelBuilder.Entity("JourneySick.Data.Models.Entities.routeplan", b =>
                {
                    b.Property<int>("PlanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PlanId");

                    b.Property<string>("PlanDescription")
                        .HasColumnType("tinytext")
                        .HasColumnName("PlanDescription");

                    b.Property<int?>("RouteId")
                        .HasColumnType("int")
                        .HasColumnName("RouteId");

                    b.HasKey("PlanId")
                        .HasName("PRIMARY");

                    b.ToTable("routeplan", (string)null);
                });

            modelBuilder.Entity("JourneySick.Data.Models.Entities.trip", b =>
                {
                    b.Property<string>("TripId")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("TripId");

                    b.Property<decimal?>("TripBudget")
                        .HasPrecision(15, 2)
                        .HasColumnType("decimal(15,2)")
                        .HasColumnName("TripBudget");

                    b.Property<string>("TripDescription")
                        .HasColumnType("longtext")
                        .HasColumnName("TripDescription");

                    b.Property<int?>("TripMember")
                        .HasColumnType("int")
                        .HasColumnName("TripMember");

                    b.Property<string>("TripName")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("TripName")
                        .UseCollation("utf8mb3_general_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("TripName"), "utf8mb3");

                    b.Property<string>("TripPresenter")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("TripPresenter");

                    b.Property<string>("TripStatus")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("TripStatus")
                        .UseCollation("utf8mb3_general_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("TripStatus"), "utf8mb3");

                    b.HasKey("TripId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "TripId" }, "TripId_UNIQUE")
                        .IsUnique();

                    b.ToTable("trip", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "latin1");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "latin1_swedish_ci");
                });

            modelBuilder.Entity("JourneySick.Data.Models.Entities.tripdetail", b =>
                {
                    b.Property<string>("TripId")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("TripId");

                    b.Property<string>("CreateBy")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("CreateBy");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("CreateDate");

                    b.Property<decimal?>("Distance")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)")
                        .HasColumnName("Distance")
                        .HasDefaultValueSql("'0.00'");

                    b.Property<DateOnly?>("EstimateEndDate")
                        .HasColumnType("date")
                        .HasColumnName("EstimateEndDate");

                    b.Property<string>("EstimateEndTime")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("EstimateEndTime")
                        .HasComment("'HH:MM'");

                    b.Property<DateOnly?>("EstimateStartDate")
                        .HasColumnType("date")
                        .HasColumnName("EstimateStartDate");

                    b.Property<string>("EstimateStartTime")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("EstimateStartTime")
                        .HasComment("'HH:MM'");

                    b.Property<int?>("TripDestinationLocationId")
                        .HasColumnType("int")
                        .HasColumnName("TripDestinationLocationId");

                    b.Property<int?>("TripStartLocationId")
                        .HasColumnType("int")
                        .HasColumnName("TripStartLocationId");

                    b.Property<string>("UpdateBy")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("UpdateBy");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("UpdateDate");

                    b.HasKey("TripId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "TripId" }, "TripId_UNIQUE")
                        .IsUnique()
                        .HasDatabaseName("TripId_UNIQUE1");

                    b.ToTable("tripdetail", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "latin1");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "latin1_swedish_ci");
                });

            modelBuilder.Entity("JourneySick.Data.Models.Entities.tripitem", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ItemId");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("CategoryId");

                    b.Property<string>("CreateBy")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("CreateBy");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("CreateDate");

                    b.Property<string>("ItemDescription")
                        .HasColumnType("mediumtext")
                        .HasColumnName("ItemDescription");

                    b.Property<string>("ItemName")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("ItemName");

                    b.Property<decimal?>("PriceMax")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)")
                        .HasColumnName("PriceMax")
                        .HasDefaultValueSql("'0.00'");

                    b.Property<decimal?>("PriceMin")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)")
                        .HasColumnName("PriceMin")
                        .HasDefaultValueSql("'0.00'");

                    b.Property<int?>("Quantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Quantity")
                        .HasDefaultValueSql("'0'");

                    b.Property<string>("TripId")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("TripId");

                    b.Property<string>("UpdateBy")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("UpdateBy");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("UpdateDate");

                    b.HasKey("ItemId")
                        .HasName("PRIMARY");

                    b.ToTable("tripitem", (string)null);
                });

            modelBuilder.Entity("JourneySick.Data.Models.Entities.tripmember", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MemberId");

                    b.Property<string>("Confirmation")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("char(10)")
                        .HasColumnName("Confirmation")
                        .HasDefaultValueSql("'NO'")
                        .IsFixedLength();

                    b.Property<string>("CreateBy")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("CreateBy");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("CreateDate");

                    b.Property<string>("MemberRoleId")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("MemberRoleId");

                    b.Property<string>("NickName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("NickName");

                    b.Property<DateTime?>("SendDate")
                        .HasColumnType("datetime")
                        .HasColumnName("SendDate");

                    b.Property<string>("Status")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("Status");

                    b.Property<string>("TripId")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("TripId");

                    b.Property<string>("UpdateBy")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("UpdateBy");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("UpdateDate");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("UserId");

                    b.HasKey("MemberId")
                        .HasName("PRIMARY");

                    b.ToTable("tripmember", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "latin1");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "latin1_swedish_ci");
                });

            modelBuilder.Entity("JourneySick.Data.Models.Entities.tripplan", b =>
                {
                    b.Property<int>("PlanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PlanId");

                    b.Property<string>("CreateBy")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("CreateBy");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("CreateDate");

                    b.Property<string>("PlanDescription")
                        .HasColumnType("longtext")
                        .HasColumnName("PlanDescription");

                    b.Property<string>("TripId")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("TripId");

                    b.Property<string>("UpdateBy")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("UpdateBy");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("UpdateDate");

                    b.HasKey("PlanId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "PlanId" }, "PlanId_UNIQUE")
                        .IsUnique();

                    b.ToTable("tripplan", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "latin1");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "latin1_swedish_ci");
                });

            modelBuilder.Entity("JourneySick.Data.Models.Entities.triprole", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RoleId");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("Description");

                    b.Property<string>("RoleName")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("RoleName");

                    b.Property<string>("Type")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("Type")
                        .UseCollation("utf8mb3_general_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Type"), "utf8mb3");

                    b.HasKey("RoleId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "RoleId" }, "RoleId_UNIQUE")
                        .IsUnique();

                    b.ToTable("triprole", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "latin1");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "latin1_swedish_ci");
                });

            modelBuilder.Entity("JourneySick.Data.Models.Entities.triproute", b =>
                {
                    b.Property<int>("RouteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("RouteId");

                    b.Property<decimal?>("Distance")
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)")
                        .HasColumnName("Distance");

                    b.Property<decimal?>("EstimateTime")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)")
                        .HasColumnName("EstimateTime")
                        .HasDefaultValueSql("'0.00'");

                    b.Property<int?>("MapId")
                        .HasColumnType("int")
                        .HasColumnName("MapId");

                    b.Property<int?>("Priority")
                        .HasColumnType("int")
                        .HasColumnName("Priority");

                    b.Property<string>("Tripid")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("Tripid");

                    b.HasKey("RouteId")
                        .HasName("PRIMARY");

                    b.ToTable("triproute", (string)null);
                });

            modelBuilder.Entity("JourneySick.Data.Models.Entities.user", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("UserId");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)")
                        .HasColumnName("Password");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("Username");

                    b.HasKey("UserId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "UserId" }, "UserId_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "Username" }, "Username_UNIQUE")
                        .IsUnique();

                    b.ToTable("user", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "latin1");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "latin1_swedish_ci");
                });

            modelBuilder.Entity("JourneySick.Data.Models.Entities.userdetail", b =>
                {
                    b.Property<string>("UserId")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("UserId");

                    b.Property<string>("ActiveStatus")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("ActiveStatus");

                    b.Property<string>("Address")
                        .HasColumnType("longtext")
                        .HasColumnName("Address")
                        .UseCollation("utf8mb3_general_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Address"), "utf8mb3");

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime")
                        .HasColumnName("Birthday");

                    b.Property<string>("CreateBy")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("CreateBy");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("CreateDate");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Email")
                        .UseCollation("utf8mb3_general_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Email"), "utf8mb3");

                    b.Property<float?>("Experience")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasColumnName("Experience")
                        .HasDefaultValueSql("'0'");

                    b.Property<string>("Fullname")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Fullname")
                        .UseCollation("utf8mb3_general_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Fullname"), "utf8mb3");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("Phone");

                    b.Property<string>("Role")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("Role")
                        .UseCollation("utf8mb3_general_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("Role"), "utf8mb3");

                    b.Property<int?>("TripCancelled")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TripCancelled")
                        .HasDefaultValueSql("'0'");

                    b.Property<int?>("TripCompleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TripCompleted")
                        .HasDefaultValueSql("'0'");

                    b.Property<int?>("TripCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TripCreated")
                        .HasDefaultValueSql("'0'");

                    b.Property<int?>("TripJoined")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TripJoined")
                        .HasDefaultValueSql("'0'");

                    b.Property<string>("UpdateBy")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("UpdateBy");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("UpdateDate");

                    b.HasKey("UserId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Email" }, "Email_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "Phone" }, "Phone_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "UserId" }, "UserId_UNIQUE")
                        .IsUnique()
                        .HasDatabaseName("UserId_UNIQUE1");

                    b.ToTable("userdetail", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "latin1");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "latin1_swedish_ci");
                });
#pragma warning restore 612, 618
        }
    }
}
