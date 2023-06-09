﻿// <auto-generated />
using System;
using MVCProjem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVCProjem.Migrations
{
    [DbContext(typeof(MVCProjemContext))]
    [Migration("20230608225032_Mig5")]
    partial class Mig5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MVCProjem.Models.KitapModel", b =>
                {
                    b.Property<int>("kitapno")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("kitapno"), 1L, 1);

                    b.Property<string>("ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("puan")
                        .HasColumnType("int");

                    b.Property<int>("sayfasayisi")
                        .HasColumnType("int");

                    b.Property<int>("turno")
                        .HasColumnType("int");

                    b.Property<int>("yazarno")
                        .HasColumnType("int");

                    b.HasKey("kitapno");

                    b.ToTable("Kitaplar");
                });

            modelBuilder.Entity("MVCProjem.Models.OgrenciModel", b =>
                {
                    b.Property<int>("ogrno")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ogrno"), 1L, 1);

                    b.Property<string>("ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cinsiyet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("dtarih")
                        .HasColumnType("datetime2");

                    b.Property<int>("puan")
                        .HasColumnType("int");

                    b.Property<string>("sinif")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("soyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ogrno");

                    b.ToTable("Ogrenciler");
                });

            modelBuilder.Entity("MVCProjem.Models.YazarModel", b =>
                {
                    b.Property<int>("yazarno")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("yazarno"), 1L, 1);

                    b.Property<string>("ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("soyad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("yazarno");

                    b.ToTable("Yazarlar");
                });
#pragma warning restore 612, 618
        }
    }
}