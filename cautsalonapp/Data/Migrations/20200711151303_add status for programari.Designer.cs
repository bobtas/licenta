﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using cautsalonapp.Data;

namespace cautsalonapp.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200711151303_add status for programari")]
    partial class addstatusforprogramari
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "dc577b2e-bb2e-45ac-9a2b-8cbf96f78104",
                            ConcurrencyStamp = "6c2cd747-df9e-44fd-b9eb-e735b4a6a8f3",
                            Name = "admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "2db1a25e-ce32-4043-8a07-5347279ba2fd",
                            ConcurrencyStamp = "fffff01c-ddac-4cef-ba77-16f7204db0bf",
                            Name = "salonowner",
                            NormalizedName = "SALONOWNER"
                        },
                        new
                        {
                            Id = "790901a5-2482-44ec-9909-003e986b757c",
                            ConcurrencyStamp = "79a84e12-1cab-426c-943a-ef9cb6eec084",
                            Name = "client",
                            NormalizedName = "CLIENT"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("cautsalon.Models.Clienti", b =>
                {
                    b.Property<int>("Cod_client")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Judet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sex")
                        .HasColumnType("int");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebuserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Cod_client")
                        .HasName("cod_client");

                    b.HasIndex("WebuserId");

                    b.ToTable("Clienti");
                });

            modelBuilder.Entity("cautsalon.Models.Firme", b =>
                {
                    b.Property<int>("Cod_firma")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cui")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Denumire")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Registrul_comertului")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebuserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Cod_firma")
                        .HasName("cod_firma");

                    b.HasIndex("WebuserId");

                    b.ToTable("Firme");
                });

            modelBuilder.Entity("cautsalon.Models.Programari", b =>
                {
                    b.Property<int>("Cod_programare")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClientCod_client")
                        .HasColumnType("int");

                    b.Property<bool>("Confirmata")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<string>("Observatii")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SalonCod_salon")
                        .HasColumnType("int");

                    b.Property<int?>("ServiciuCod_serviciu")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebuserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Cod_programare")
                        .HasName("cod_programare");

                    b.HasIndex("ClientCod_client");

                    b.HasIndex("SalonCod_salon");

                    b.HasIndex("ServiciuCod_serviciu");

                    b.HasIndex("WebuserId");

                    b.ToTable("Programari");
                });

            modelBuilder.Entity("cautsalon.Models.Saloane", b =>
                {
                    b.Property<int>("Cod_salon")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descriere")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Facebook")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FirmaCod_firma")
                        .HasColumnType("int");

                    b.Property<string>("Judet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Oras")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon_salon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon_sms")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Cod_salon")
                        .HasName("cod_salon");

                    b.HasIndex("FirmaCod_firma");

                    b.ToTable("Saloane");
                });

            modelBuilder.Entity("cautsalon.Models.Servicii", b =>
                {
                    b.Property<int>("Cod_serviciu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Denumire")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Pret")
                        .HasColumnType("float");

                    b.HasKey("Cod_serviciu")
                        .HasName("cod_serviciu");

                    b.ToTable("Servicii");
                });

            modelBuilder.Entity("cautsalonapp.Models.SaloaneServicii", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("SalonCod_salon")
                        .HasColumnType("int");

                    b.Property<int?>("ServiciuCod_serviciu")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("id");

                    b.HasIndex("SalonCod_salon");

                    b.HasIndex("ServiciuCod_serviciu");

                    b.ToTable("SaloaneServicii");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("cautsalon.Models.Clienti", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Webuser")
                        .WithMany()
                        .HasForeignKey("WebuserId");
                });

            modelBuilder.Entity("cautsalon.Models.Firme", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Webuser")
                        .WithMany()
                        .HasForeignKey("WebuserId");
                });

            modelBuilder.Entity("cautsalon.Models.Programari", b =>
                {
                    b.HasOne("cautsalon.Models.Clienti", "Client")
                        .WithMany()
                        .HasForeignKey("ClientCod_client");

                    b.HasOne("cautsalon.Models.Saloane", "Salon")
                        .WithMany()
                        .HasForeignKey("SalonCod_salon");

                    b.HasOne("cautsalon.Models.Servicii", "Serviciu")
                        .WithMany()
                        .HasForeignKey("ServiciuCod_serviciu");

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Webuser")
                        .WithMany()
                        .HasForeignKey("WebuserId");
                });

            modelBuilder.Entity("cautsalon.Models.Saloane", b =>
                {
                    b.HasOne("cautsalon.Models.Firme", "Firma")
                        .WithMany()
                        .HasForeignKey("FirmaCod_firma");
                });

            modelBuilder.Entity("cautsalonapp.Models.SaloaneServicii", b =>
                {
                    b.HasOne("cautsalon.Models.Saloane", "Salon")
                        .WithMany()
                        .HasForeignKey("SalonCod_salon");

                    b.HasOne("cautsalon.Models.Servicii", "Serviciu")
                        .WithMany()
                        .HasForeignKey("ServiciuCod_serviciu");
                });
#pragma warning restore 612, 618
        }
    }
}
