﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SubscriptionBasedFlowInMVCCore.Data;

#nullable disable

namespace SubscriptionBasedFlowInMVCCore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240720190906_M2")]
    partial class M2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.7");

            modelBuilder.Entity("SubscriptionBasedFlowInMVCCore.Models.Subscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("SubscriptionType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("SubscriptionBasedFlowInMVCCore.Models.SubscriptionFeature", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FeatureName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("SubscriptionId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SubscriptionType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SubscriptionId");

                    b.ToTable("SubscriptionFeatures");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FeatureName = "Access to Basic Content",
                            SubscriptionType = "Basic"
                        },
                        new
                        {
                            Id = 2,
                            FeatureName = "Access to Premium Content",
                            SubscriptionType = "Premium"
                        },
                        new
                        {
                            Id = 3,
                            FeatureName = "Access to VIP Content",
                            SubscriptionType = "VIP"
                        },
                        new
                        {
                            Id = 4,
                            FeatureName = "Priority Support",
                            SubscriptionType = "VIP"
                        });
                });

            modelBuilder.Entity("SubscriptionBasedFlowInMVCCore.Models.SubscriptionFeature", b =>
                {
                    b.HasOne("SubscriptionBasedFlowInMVCCore.Models.Subscription", null)
                        .WithMany("Features")
                        .HasForeignKey("SubscriptionId");
                });

            modelBuilder.Entity("SubscriptionBasedFlowInMVCCore.Models.Subscription", b =>
                {
                    b.Navigation("Features");
                });
#pragma warning restore 612, 618
        }
    }
}
