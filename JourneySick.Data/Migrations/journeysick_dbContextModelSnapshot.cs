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

            modelBuilder.Entity("JourneySick.Data.Models.Entities.Tblfeedback", b =>
                {
                    b.Property<int>("FldFeedbackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("fldFeedbackId");

                    b.Property<string>("FldCreateBy")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("fldCreateBy");

                    b.Property<DateTime?>("FldCreateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("fldCreateDate");

                    b.Property<int?>("FldDislike")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("fldDislike")
                        .HasDefaultValueSql("'0'");

                    b.Property<string>("FldFeedback")
                        .HasColumnType("longtext")
                        .HasColumnName("fldFeedback");

                    b.Property<int?>("FldLike")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("fldLike")
                        .HasDefaultValueSql("'0'");

                    b.Property<string>("FldLocationName")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("fldLocationName");

                    b.Property<float?>("FldRate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasColumnName("fldRate")
                        .HasDefaultValueSql("'0'");

                    b.Property<string>("FldTripId")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("fldTripId");

                    b.Property<string>("FldUpdateBy")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("fldUpdateBy");

                    b.Property<DateTime?>("FldUpdateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("fldUpdateDate");

                    b.Property<string>("FldUserId")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("fldUserId");

                    b.HasKey("FldFeedbackId")
                        .HasName("PRIMARY");

                    b.ToTable("tblfeedback", (string)null);
                });

            modelBuilder.Entity("JourneySick.Data.Models.Entities.Tblitem", b =>
                {
                    b.Property<int>("FldItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("fldItemId");

                    b.Property<int>("FldCategoryId")
                        .HasColumnType("int")
                        .HasColumnName("fldCategoryId");

                    b.Property<string>("FldCreateBy")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("fldCreateBy");

                    b.Property<DateTime?>("FldCreateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("fldCreateDate");

                    b.Property<string>("FldItemDescription")
                        .HasColumnType("longtext")
                        .HasColumnName("fldItemDescription");

                    b.Property<string>("FldItemName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("fldItemName");

                    b.Property<string>("FldItemUsage")
                        .HasColumnType("longtext")
                        .HasColumnName("fldItemUsage");

                    b.Property<decimal?>("FldPriceMax")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)")
                        .HasColumnName("fldPriceMax")
                        .HasDefaultValueSql("'0.00'");

                    b.Property<decimal?>("FldPriceMin")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)")
                        .HasColumnName("fldPriceMin")
                        .HasDefaultValueSql("'0.00'");

                    b.Property<int?>("FldQuantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("fldQuantity")
                        .HasDefaultValueSql("'0'");

                    b.Property<string>("FldUpdateBy")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("fldUpdateBy");

                    b.Property<DateTime?>("FldUpdateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("fldUpdateDate");

                    b.HasKey("FldItemId")
                        .HasName("PRIMARY");

                    b.ToTable("tblitem", (string)null);
                });

            modelBuilder.Entity("JourneySick.Data.Models.Entities.Tblitemcategory", b =>
                {
                    b.Property<int>("FldCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("fldCategoryId");

                    b.Property<string>("FldCategoryDescription")
                        .HasColumnType("tinytext")
                        .HasColumnName("fldCategoryDescription");

                    b.Property<string>("FldCategoryName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("fldCategoryName");

                    b.Property<string>("FldCreateBy")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("fldCreateBy");

                    b.Property<DateTime>("FldCreateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("fldCreateDate");

                    b.Property<string>("FldUpdateBy")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("fldUpdateBy");

                    b.Property<DateTime?>("FldUpdateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("fldUpdateDate");

                    b.HasKey("FldCategoryId")
                        .HasName("PRIMARY");

                    b.ToTable("tblitemcategory", (string)null);
                });

            modelBuilder.Entity("JourneySick.Data.Models.Entities.Tblmaplocation", b =>
                {
                    b.Property<int>("FldMapId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("fldMapId");

                    b.Property<string>("FldLatitude")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("fldLatitude");

                    b.Property<string>("FldLocationName")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("fldLocationName");

                    b.Property<string>("FldLongitude")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("fldLongitude");

                    b.HasKey("FldMapId")
                        .HasName("PRIMARY");

                    b.ToTable("tblmaplocation", (string)null);
                });

            modelBuilder.Entity("JourneySick.Data.Models.Entities.Tblplanlocation", b =>
                {
                    b.Property<int>("FldPlanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("fldPlanId");

                    b.Property<string>("FldCreateBy")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("fldCreateBy");

                    b.Property<DateTime?>("FldCreateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("fldCreateDate");

                    b.Property<DateTime?>("FldLocationArrivalTime")
                        .HasColumnType("datetime")
                        .HasColumnName("fldLocationArrivalTime");

                    b.Property<int?>("FldMapId")
                        .HasColumnType("int")
                        .HasColumnName("fldMapId");

                    b.Property<string>("FldPlanLocationDescription")
                        .HasColumnType("text")
                        .HasColumnName("fldPlanLocationDescription");

                    b.Property<string>("FldPlanLocationId")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("fldPlanLocationId");

                    b.Property<string>("FldUpdateBy")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("fldUpdateBy");

                    b.Property<DateTime?>("FldUpdateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("fldUpdateDate");

                    b.HasKey("FldPlanId")
                        .HasName("PRIMARY");

                    b.ToTable("tblplanlocation", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "latin1");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "latin1_swedish_ci");
                });

            modelBuilder.Entity("JourneySick.Data.Models.Entities.Tbltrip", b =>
                {
                    b.Property<string>("FldTripId")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("fldTripId");

                    b.Property<DateTime?>("FldEstimateArrivalTime")
                        .HasColumnType("datetime")
                        .HasColumnName("fldEstimateArrivalTime");

                    b.Property<DateTime?>("FldEstimateStartTime")
                        .HasColumnType("datetime")
                        .HasColumnName("fldEstimateStartTime");

                    b.Property<decimal?>("FldTripBudget")
                        .HasPrecision(15, 2)
                        .HasColumnType("decimal(15,2)")
                        .HasColumnName("fldTripBudget");

                    b.Property<string>("FldTripDescription")
                        .HasColumnType("longtext")
                        .HasColumnName("fldTripDescription");

                    b.Property<int?>("FldTripMember")
                        .HasColumnType("int")
                        .HasColumnName("fldTripMember");

                    b.Property<string>("FldTripName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("fldTripName")
                        .UseCollation("utf8_general_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("FldTripName"), "utf8");

                    b.Property<string>("FldTripPresenter")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("fldTripPresenter");

                    b.Property<string>("FldTripStatus")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("fldTripStatus")
                        .UseCollation("utf8_general_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("FldTripStatus"), "utf8");

                    b.HasKey("FldTripId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "FldTripId" }, "fldTripId_UNIQUE")
                        .IsUnique();

                    b.ToTable("tbltrip", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "latin1");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "latin1_swedish_ci");
                });

            modelBuilder.Entity("JourneySick.Data.Models.Entities.Tbltripdetail", b =>
                {
                    b.Property<string>("FldTripId")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("fldTripId");

                    b.Property<string>("FldCreateBy")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("fldCreateBy");

                    b.Property<DateTime?>("FldCreateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("fldCreateDate");

                    b.Property<string>("FldTripDestinationLocationAddress")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("fldTripDestinationLocationAddress")
                        .UseCollation("utf8_general_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("FldTripDestinationLocationAddress"), "utf8");

                    b.Property<string>("FldTripDestinationLocationName")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("fldTripDestinationLocationName")
                        .UseCollation("utf8_general_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("FldTripDestinationLocationName"), "utf8");

                    b.Property<string>("FldTripStartLocationAddress")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("fldTripStartLocationAddress")
                        .UseCollation("utf8_general_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("FldTripStartLocationAddress"), "utf8");

                    b.Property<string>("FldTripStartLocationName")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("fldTripStartLocationName");

                    b.Property<string>("FldUpdateBy")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("fldUpdateBy");

                    b.Property<DateTime?>("FldUpdateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("fldUpdateDate");

                    b.HasKey("FldTripId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "FldTripId" }, "fldTripId_UNIQUE1")
                        .IsUnique();

                    b.ToTable("tbltripdetail", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "latin1");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "latin1_swedish_ci");
                });

            modelBuilder.Entity("JourneySick.Data.Models.Entities.Tbltripitem", b =>
                {
                    b.Property<int>("FldItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("fldItemId");

                    b.Property<int?>("FldCategoryId")
                        .HasColumnType("int")
                        .HasColumnName("fldCategoryId");

                    b.Property<string>("FldCreateBy")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("fldCreateBy");

                    b.Property<DateTime?>("FldCreateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("fldCreateDate");

                    b.Property<string>("FldItemDescription")
                        .HasColumnType("mediumtext")
                        .HasColumnName("fldItemDescription");

                    b.Property<string>("FldItemName")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("fldItemName");

                    b.Property<decimal?>("FldPriceMax")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)")
                        .HasColumnName("fldPriceMax")
                        .HasDefaultValueSql("'0.00'");

                    b.Property<decimal?>("FldPriceMin")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(12, 2)
                        .HasColumnType("decimal(12,2)")
                        .HasColumnName("fldPriceMin")
                        .HasDefaultValueSql("'0.00'");

                    b.Property<int?>("FldQuantity")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("fldQuantity")
                        .HasDefaultValueSql("'0'");

                    b.Property<string>("FldTripId")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("fldTripId");

                    b.Property<string>("FldUpdateBy")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("fldUpdateBy");

                    b.Property<DateTime?>("FldUpdateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("fldUpdateDate");

                    b.HasKey("FldItemId")
                        .HasName("PRIMARY");

                    b.ToTable("tbltripitem", (string)null);
                });

            modelBuilder.Entity("JourneySick.Data.Models.Entities.Tbltripmember", b =>
                {
                    b.Property<int>("FldMemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("fldMemberId");

                    b.Property<string>("FldCreateBy")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("fldCreateBy");

                    b.Property<DateTime?>("FldCreateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("fldCreateDate");

                    b.Property<string>("FldMemberRoleId")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("fldMemberRoleId");

                    b.Property<string>("FldNickName")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("fldNickName");

                    b.Property<string>("FldStatus")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("fldStatus");

                    b.Property<string>("FldTripId")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("fldTripId");

                    b.Property<string>("FldUpdateBy")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("fldUpdateBy");

                    b.Property<DateTime?>("FldUpdateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("fldUpdateDate");

                    b.Property<string>("FldUserId")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("fldUserId");

                    b.HasKey("FldMemberId")
                        .HasName("PRIMARY");

                    b.ToTable("tbltripmember", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "latin1");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "latin1_swedish_ci");
                });

            modelBuilder.Entity("JourneySick.Data.Models.Entities.Tbltripplan", b =>
                {
                    b.Property<int>("FldPlanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("fldPlanId");

                    b.Property<string>("FldCreateBy")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("fldCreateBy");

                    b.Property<DateTime?>("FldCreateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("fldCreateDate");

                    b.Property<string>("FldPlanDescription")
                        .HasColumnType("longtext")
                        .HasColumnName("fldPlanDescription");

                    b.Property<string>("FldTripId")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("fldTripId");

                    b.Property<string>("FldUpdateBy")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("fldUpdateBy");

                    b.Property<DateTime?>("FldUpdateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("fldUpdateDate");

                    b.HasKey("FldPlanId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "FldPlanId" }, "fldPlanId_UNIQUE")
                        .IsUnique();

                    b.ToTable("tbltripplan", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "latin1");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "latin1_swedish_ci");
                });

            modelBuilder.Entity("JourneySick.Data.Models.Entities.Tbltriprole", b =>
                {
                    b.Property<int>("FldRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("fldRoleId");

                    b.Property<string>("FldDescription")
                        .HasColumnType("text")
                        .HasColumnName("fldDescription");

                    b.Property<string>("FldRoleName")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("fldRoleName");

                    b.Property<string>("FldType")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("fldType")
                        .UseCollation("utf8_general_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("FldType"), "utf8");

                    b.HasKey("FldRoleId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "FldRoleId" }, "fldRoleId_UNIQUE")
                        .IsUnique();

                    b.ToTable("tbltriprole", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "latin1");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "latin1_swedish_ci");
                });

            modelBuilder.Entity("JourneySick.Data.Models.Entities.Tbluser", b =>
                {
                    b.Property<string>("FldUserId")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("fldUserId");

                    b.Property<string>("FldPassword")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)")
                        .HasColumnName("fldPassword");

                    b.Property<string>("FldUsername")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("fldUsername");

                    b.HasKey("FldUserId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "FldUserId" }, "fldUserId_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "FldUsername" }, "fldUsername_UNIQUE")
                        .IsUnique();

                    b.ToTable("tbluser", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "latin1");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "latin1_swedish_ci");
                });

            modelBuilder.Entity("JourneySick.Data.Models.Entities.Tbluserdetail", b =>
                {
                    b.Property<string>("FldUserId")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("fldUserId");

                    b.Property<string>("FldActiveStatus")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("fldActiveStatus");

                    b.Property<string>("FldAddress")
                        .HasColumnType("longtext")
                        .HasColumnName("fldAddress")
                        .UseCollation("utf8_general_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("FldAddress"), "utf8");

                    b.Property<DateTime?>("FldBirthday")
                        .HasColumnType("datetime")
                        .HasColumnName("fldBirthday");

                    b.Property<string>("FldCreateBy")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("fldCreateBy");

                    b.Property<DateTime?>("FldCreateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("fldCreateDate");

                    b.Property<string>("FldEmail")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("fldEmail")
                        .UseCollation("utf8_general_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("FldEmail"), "utf8");

                    b.Property<float?>("FldExperience")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("float")
                        .HasColumnName("fldExperience")
                        .HasDefaultValueSql("'0'");

                    b.Property<string>("FldFullname")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("fldFullname")
                        .UseCollation("utf8_general_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("FldFullname"), "utf8");

                    b.Property<string>("FldPhone")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("fldPhone");

                    b.Property<string>("FldRole")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("fldRole")
                        .UseCollation("utf8_general_ci");

                    MySqlPropertyBuilderExtensions.HasCharSet(b.Property<string>("FldRole"), "utf8");

                    b.Property<int?>("FldTripCancelled")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("fldTripCancelled")
                        .HasDefaultValueSql("'0'");

                    b.Property<int?>("FldTripCompleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("fldTripCompleted")
                        .HasDefaultValueSql("'0'");

                    b.Property<int?>("FldTripCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("fldTripCreated")
                        .HasDefaultValueSql("'0'");

                    b.Property<int?>("FldTripJoined")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("fldTripJoined")
                        .HasDefaultValueSql("'0'");

                    b.Property<string>("FldUpdateBy")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("fldUpdateBy");

                    b.Property<DateTime?>("FldUpdateDate")
                        .HasColumnType("datetime")
                        .HasColumnName("fldUpdateDate");

                    b.HasKey("FldUserId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "FldEmail" }, "fldEmail_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "FldPhone" }, "fldPhone_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "FldUserId" }, "fldUserId_UNIQUE1")
                        .IsUnique();

                    b.ToTable("tbluserdetail", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "latin1");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "latin1_swedish_ci");
                });
#pragma warning restore 612, 618
        }
    }
}
