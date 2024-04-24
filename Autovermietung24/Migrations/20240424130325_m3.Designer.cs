﻿// <auto-generated />
using Autovermietung24.Daten;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Autovermietung24.Migrations
{
    [DbContext(typeof(AutovermietungsContext))]
    [Migration("20240424130325_m3")]
    partial class m3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.29");

            modelBuilder.Entity("Autovermietung24.Modell.Auto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Erstzulassung")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Getriebe")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Karosserieform")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Kennzeichen")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Kraftstoff")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Marke")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Autos");
                });

            modelBuilder.Entity("Autovermietung24.Modell.Kunde", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Anschrift")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Ausweisnummer")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Bewertung")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("FahrerlaubnisklasseB")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Führerscheinnummer")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Geburtsdatum")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Geburtsort")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Gültigkeitsfrist")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nachname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Staatsangehörigkeit")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Vorname")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Zusatzangaben")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Kunden");
                });
#pragma warning restore 612, 618
        }
    }
}
