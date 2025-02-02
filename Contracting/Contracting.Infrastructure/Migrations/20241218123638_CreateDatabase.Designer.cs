﻿// <auto-generated />
using System;
using Contracting.Infrastructure.StoredModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Contracting.Infrastructure.Migrations
{
    [DbContext(typeof(StoredDbContext))]
    [Migration("20241218123638_CreateDatabase")]
    partial class CreateDatabase
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Contracting.Infrastructure.StoredModel.Entities.AdministratorStoredModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("administratorId");

                    b.Property<string>("AdministratorName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.Property<string>("AdministratorPhone")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("character varying(8)")
                        .HasColumnName("phone");

                    b.HasKey("Id");

                    b.ToTable("administrators");
                });

            modelBuilder.Entity("Contracting.Infrastructure.StoredModel.Entities.ContractStoredModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("contractId");

                    b.Property<Guid>("AdministratorId")
                        .HasColumnType("uuid")
                        .HasColumnName("administratorId");

                    b.Property<DateTime?>("CompletedDate")
                        .HasColumnType("timestamp")
                        .HasColumnName("completedDate");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp")
                        .HasColumnName("creationDate");

                    b.Property<Guid>("PatientId")
                        .HasColumnType("uuid")
                        .HasColumnName("patientId");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp")
                        .HasColumnName("startDate");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("totalCost");

                    b.Property<string>("TransactionStatus")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("transactionStatus");

                    b.Property<string>("TransactionType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("transactionType");

                    b.HasKey("Id");

                    b.HasIndex("AdministratorId");

                    b.HasIndex("PatientId");

                    b.ToTable("contracts");
                });

            modelBuilder.Entity("Contracting.Infrastructure.StoredModel.Entities.DeliveryDayStoredModel", b =>
                {
                    b.Property<Guid>("DeliveryDayId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("deliveryDayId");

                    b.Property<Guid>("ContractId")
                        .HasColumnType("uuid")
                        .HasColumnName("contractId");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date");

                    b.Property<double>("Latitude")
                        .HasColumnType("double precision")
                        .HasColumnName("latitude");

                    b.Property<double>("Longitude")
                        .HasColumnType("double precision")
                        .HasColumnName("longitude");

                    b.Property<int>("Number")
                        .HasColumnType("integer")
                        .HasColumnName("number");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("street");

                    b.HasKey("DeliveryDayId");

                    b.HasIndex("ContractId");

                    b.ToTable("deliverydays");
                });

            modelBuilder.Entity("Contracting.Infrastructure.StoredModel.Entities.PatientStoredModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("patientId");

                    b.Property<string>("PatientName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.Property<string>("PatientPhone")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("character varying(8)")
                        .HasColumnName("phone");

                    b.HasKey("Id");

                    b.ToTable("patients");
                });

            modelBuilder.Entity("Contracting.Infrastructure.StoredModel.Entities.ContractStoredModel", b =>
                {
                    b.HasOne("Contracting.Infrastructure.StoredModel.Entities.AdministratorStoredModel", "Administrator")
                        .WithMany()
                        .HasForeignKey("AdministratorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Contracting.Infrastructure.StoredModel.Entities.PatientStoredModel", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Administrator");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Contracting.Infrastructure.StoredModel.Entities.DeliveryDayStoredModel", b =>
                {
                    b.HasOne("Contracting.Infrastructure.StoredModel.Entities.ContractStoredModel", "Contract")
                        .WithMany()
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contract");
                });
#pragma warning restore 612, 618
        }
    }
}
