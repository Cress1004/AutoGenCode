﻿// <auto-generated />
using System;
using AutoGenCode.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AutoGenCode.Migrations
{
    [DbContext(typeof(TagContext))]
    [Migration("20210523112122_AddTanle")]
    partial class AddTanle
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("AutoGenCode.Data.GenUI", b =>
                {
                    b.Property<int>("GenUIId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<float>("Height")
                        .HasColumnType("float");

                    b.Property<float>("Width")
                        .HasColumnType("float");

                    b.HasKey("GenUIId");

                    b.ToTable("GenUIs");
                });

            modelBuilder.Entity("AutoGenCode.Data.GenUITag", b =>
                {
                    b.Property<int>("GenUIId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.Property<int>("GenUITagId")
                        .HasColumnType("int");

                    b.HasKey("GenUIId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("GenUITags");
                });

            modelBuilder.Entity("AutoGenCode.Data.Region", b =>
                {
                    b.Property<int>("RegionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<int>("GenUIId")
                        .HasColumnType("int");

                    b.Property<float>("Height")
                        .HasColumnType("float");

                    b.Property<float>("LeftPos")
                        .HasColumnType("float");

                    b.Property<float>("RightPos")
                        .HasColumnType("float");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.Property<float>("Width")
                        .HasColumnType("float");

                    b.HasKey("RegionId");

                    b.HasIndex("GenUIId");

                    b.HasIndex("TagId");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("AutoGenCode.Data.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<string>("TagName")
                        .HasColumnType("text");

                    b.HasKey("TagId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("AutoGenCode.Data.GenUITag", b =>
                {
                    b.HasOne("AutoGenCode.Data.GenUI", "GenUI")
                        .WithMany("GenUITags")
                        .HasForeignKey("GenUIId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoGenCode.Data.Tag", "Tag")
                        .WithMany("GenUITags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GenUI");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("AutoGenCode.Data.Region", b =>
                {
                    b.HasOne("AutoGenCode.Data.GenUI", "GenUI")
                        .WithMany("Regions")
                        .HasForeignKey("GenUIId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoGenCode.Data.Tag", "Tag")
                        .WithMany("Regions")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GenUI");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("AutoGenCode.Data.GenUI", b =>
                {
                    b.Navigation("GenUITags");

                    b.Navigation("Regions");
                });

            modelBuilder.Entity("AutoGenCode.Data.Tag", b =>
                {
                    b.Navigation("GenUITags");

                    b.Navigation("Regions");
                });
#pragma warning restore 612, 618
        }
    }
}