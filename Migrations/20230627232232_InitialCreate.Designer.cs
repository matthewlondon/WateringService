﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WateringService;

#nullable disable

namespace WateringService.Migrations
{
    [DbContext(typeof(WateringServiceContext))]
    [Migration("20230627232232_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.8");

            modelBuilder.Entity("WateringService.Models.Park", b =>
                {
                    b.Property<Guid>("ParkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ParkId");

                    b.ToTable("Parks");
                });

            modelBuilder.Entity("WateringService.Models.RainGauge", b =>
                {
                    b.Property<Guid>("GaugeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("ParkId")
                        .HasColumnType("TEXT");

                    b.HasKey("GaugeId");

                    b.HasIndex("ParkId");

                    b.ToTable("RainGauges");
                });

            modelBuilder.Entity("WateringService.Models.Tree", b =>
                {
                    b.Property<Guid>("TreeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Binomial")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ParkId")
                        .HasColumnType("TEXT");

                    b.HasKey("TreeId");

                    b.HasIndex("ParkId");

                    b.ToTable("Trees");
                });

            modelBuilder.Entity("WateringService.Models.RainGauge", b =>
                {
                    b.HasOne("WateringService.Models.Park", null)
                        .WithMany("RainGauges")
                        .HasForeignKey("ParkId");
                });

            modelBuilder.Entity("WateringService.Models.Tree", b =>
                {
                    b.HasOne("WateringService.Models.Park", "Park")
                        .WithMany("Trees")
                        .HasForeignKey("ParkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Park");
                });

            modelBuilder.Entity("WateringService.Models.Park", b =>
                {
                    b.Navigation("RainGauges");

                    b.Navigation("Trees");
                });
#pragma warning restore 612, 618
        }
    }
}
