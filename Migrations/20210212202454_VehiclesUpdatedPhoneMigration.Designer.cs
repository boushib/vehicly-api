﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using vehicly.DAO;

namespace vehicly.Migrations
{
    [DbContext(typeof(VehiclesContext))]
    [Migration("20210212202454_VehiclesUpdatedPhoneMigration")]
    partial class VehiclesUpdatedPhoneMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasPostgresExtension("uuid-ossp")
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("vehicly.Models.Vehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Fuel")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("GearBox")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Horsepower")
                        .HasColumnType("integer");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
