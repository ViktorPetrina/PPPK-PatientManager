﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PatientManager.Models;

#nullable disable

namespace PatientManager.Migrations
{
    [DbContext(typeof(PatientManagerContext))]
    [Migration("20250110215106_Migration1")]
    partial class Migration1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PatientManager.Models.Patient", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_of_birth");

                    b.Property<string>("FirstName")
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.Property<string>("Oib")
                        .HasMaxLength(11)
                        .HasColumnType("character varying(11)")
                        .HasColumnName("oib");

                    b.Property<long?>("PatientId")
                        .HasColumnType("bigint");

                    b.Property<char>("Sex")
                        .HasColumnType("character(1)")
                        .HasColumnName("sex");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("patient");
                });

            modelBuilder.Entity("PatientManager.Models.Patient", b =>
                {
                    b.HasOne("PatientManager.Models.Patient", null)
                        .WithMany("CheckUps")
                        .HasForeignKey("PatientId");
                });

            modelBuilder.Entity("PatientManager.Models.Patient", b =>
                {
                    b.Navigation("CheckUps");
                });
#pragma warning restore 612, 618
        }
    }
}
