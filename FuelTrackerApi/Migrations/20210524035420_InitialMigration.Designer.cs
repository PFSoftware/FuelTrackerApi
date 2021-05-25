﻿// <auto-generated />
using System;
using FuelTrackerApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FuelTrackerApi.Migrations
{
    [DbContext(typeof(Data.AppDbContext))]
    [Migration("20210524035420_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "6.0.0-preview.1.21102.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FuelTrackerApi.Models.Domain.FuelTransaction", b =>
                {
                    b.Property<int>("TransactionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Distance")
                        .HasColumnType("decimal(10,3)");

                    b.Property<decimal>("Gallons")
                        .HasColumnType("decimal(6,3)");

                    b.Property<int>("Octane")
                        .HasColumnType("int");

                    b.Property<decimal>("Odometer")
                        .HasColumnType("decimal(7,1)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(5,3)");

                    b.Property<int>("Range")
                        .HasColumnType("int");

                    b.Property<string>("Store")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VehicleID")
                        .HasColumnType("int");

                    b.HasKey("TransactionID");

                    b.HasIndex("VehicleID");

                    b.ToTable("FuelTransactions");
                });

            modelBuilder.Entity("FuelTrackerApi.Models.Domain.Vehicle", b =>
                {
                    b.Property<int>("VehicleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("VehicleID");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("FuelTrackerApi.Models.Domain.FuelTransaction", b =>
                {
                    b.HasOne("FuelTrackerApi.Models.Domain.Vehicle", "Vehicle")
                        .WithMany("Transactions")
                        .HasForeignKey("VehicleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("FuelTrackerApi.Models.Domain.Vehicle", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
