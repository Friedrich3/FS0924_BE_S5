﻿// <auto-generated />
using System;
using FS0924_BE_S5.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FS0924_BE_S5.Migrations
{
    [DbContext(typeof(PraticaBES5))]
    [Migration("20250312143155_UpdateTablesAndRelation")]
    partial class UpdateTablesAndRelation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FS0924_BE_S5.Models.Genere", b =>
                {
                    b.Property<int>("IdGenere")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdGenere"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdGenere");

                    b.ToTable("Generi");
                });

            modelBuilder.Entity("FS0924_BE_S5.Models.Libro", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Autore")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Copertina")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Disponibilita")
                        .HasColumnType("bit");

                    b.Property<int>("IdGenere")
                        .HasColumnType("int");

                    b.Property<string>("Titolo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("IdGenere");

                    b.ToTable("Libri");
                });

            modelBuilder.Entity("FS0924_BE_S5.Models.Libro", b =>
                {
                    b.HasOne("FS0924_BE_S5.Models.Genere", "Genere")
                        .WithMany("LibriGenere")
                        .HasForeignKey("IdGenere")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genere");
                });

            modelBuilder.Entity("FS0924_BE_S5.Models.Genere", b =>
                {
                    b.Navigation("LibriGenere");
                });
#pragma warning restore 612, 618
        }
    }
}
