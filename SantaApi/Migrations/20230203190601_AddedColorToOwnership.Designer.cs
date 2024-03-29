﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SantaApi.Persistence;

#nullable disable

namespace SantaApi.Migrations
{
    [DbContext(typeof(SantaDb))]
    [Migration("20230203190601_AddedColorToOwnership")]
    partial class AddedColorToOwnership
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("SantaApi.Model.Child", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name", "Age")
                        .IsUnique();

                    b.ToTable("Children");
                });

            modelBuilder.Entity("SantaApi.Model.ChildGiftOwnership", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("ChildId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("GiftId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ChildId");

                    b.HasIndex("GiftId");

                    b.ToTable("ChildGiftOwnership");
                });

            modelBuilder.Entity("SantaApi.Model.Gift", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Cost")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Gifts");
                });

            modelBuilder.Entity("SantaApi.Model.ChildGiftOwnership", b =>
                {
                    b.HasOne("SantaApi.Model.Child", "Child")
                        .WithMany("ChildGiftOwnership")
                        .HasForeignKey("ChildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SantaApi.Model.Gift", "Gift")
                        .WithMany("ChildGiftOwnership")
                        .HasForeignKey("GiftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Child");

                    b.Navigation("Gift");
                });

            modelBuilder.Entity("SantaApi.Model.Child", b =>
                {
                    b.Navigation("ChildGiftOwnership");
                });

            modelBuilder.Entity("SantaApi.Model.Gift", b =>
                {
                    b.Navigation("ChildGiftOwnership");
                });
#pragma warning restore 612, 618
        }
    }
}
