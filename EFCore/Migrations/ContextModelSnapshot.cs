﻿// <auto-generated />
using System;
using EFCore.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFCore.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EFCore.Model.Facility", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("FacClosestAdr")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FacItems")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FacName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FacRules")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FacType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Facilities");
                });

            modelBuilder.Entity("EFCore.Model.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<int>("FacilityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.Property<long>("UserCPRNumber")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("FacilityId");

                    b.HasIndex("UserCPRNumber");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("EFCore.Model.User", b =>
                {
                    b.Property<long>("CPRNumber")
                        .HasColumnType("bigint");

                    b.Property<int>("CVR")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.HasKey("CPRNumber");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EFCore.Model.Reservation", b =>
                {
                    b.HasOne("EFCore.Model.Facility", "Facility")
                        .WithMany("Reservations")
                        .HasForeignKey("FacilityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCore.Model.User", "User")
                        .WithMany("Reservations")
                        .HasForeignKey("UserCPRNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Facility");

                    b.Navigation("User");
                });

            modelBuilder.Entity("EFCore.Model.Facility", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("EFCore.Model.User", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
