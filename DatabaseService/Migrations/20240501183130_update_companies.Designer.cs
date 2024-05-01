﻿// <auto-generated />
using System;
using DatabaseService;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DatabaseService.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240501183130_update_companies")]
    partial class update_companies
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DatabaseService.Data.Models.Company", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<double>("Budget")
                        .HasColumnType("double precision");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("DatabaseService.Data.Models.PositionInCompany", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("CompanyId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("Permissions")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("PositionInCompanies");
                });

            modelBuilder.Entity("DatabaseService.Data.Models.ProfilePhoto", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("PictureLink")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PictureName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("ProfilePhotos");
                });

            modelBuilder.Entity("DatabaseService.Data.Models.RefreshToken", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("Created")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("Expired")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("DatabaseService.Data.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("character varying(64)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("PasswordResetToken")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("ResetTokenExpires")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("VerificationToken")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<DateTime?>("VerifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DatabaseService.Data.Models.UserCompany", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("CompanyId")
                        .HasColumnType("bigint");

                    b.Property<long>("PositionInCompanyId")
                        .HasColumnType("bigint");

                    b.Property<double>("Salary")
                        .HasColumnType("double precision");

                    b.HasKey("UserId", "CompanyId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("PositionInCompanyId");

                    b.ToTable("UserCompanies");
                });

            modelBuilder.Entity("DatabaseService.Data.Models.PositionInCompany", b =>
                {
                    b.HasOne("DatabaseService.Data.Models.Company", "Company")
                        .WithMany("PositionInCompanies")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("DatabaseService.Data.Models.ProfilePhoto", b =>
                {
                    b.HasOne("DatabaseService.Data.Models.User", "User")
                        .WithOne("ProfilePhoto")
                        .HasForeignKey("DatabaseService.Data.Models.ProfilePhoto", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DatabaseService.Data.Models.RefreshToken", b =>
                {
                    b.HasOne("DatabaseService.Data.Models.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DatabaseService.Data.Models.UserCompany", b =>
                {
                    b.HasOne("DatabaseService.Data.Models.Company", "Company")
                        .WithMany("UserCompanies")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DatabaseService.Data.Models.PositionInCompany", "PositionInCompany")
                        .WithMany("UserCompanies")
                        .HasForeignKey("PositionInCompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DatabaseService.Data.Models.User", "User")
                        .WithMany("UserCompanies")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("PositionInCompany");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DatabaseService.Data.Models.Company", b =>
                {
                    b.Navigation("PositionInCompanies");

                    b.Navigation("UserCompanies");
                });

            modelBuilder.Entity("DatabaseService.Data.Models.PositionInCompany", b =>
                {
                    b.Navigation("UserCompanies");
                });

            modelBuilder.Entity("DatabaseService.Data.Models.User", b =>
                {
                    b.Navigation("ProfilePhoto")
                        .IsRequired();

                    b.Navigation("RefreshTokens");

                    b.Navigation("UserCompanies");
                });
#pragma warning restore 612, 618
        }
    }
}
