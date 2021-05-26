﻿// <auto-generated />
using System;
using AutoGenCode.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AutoGenCode.Migrations
{
    [DbContext(typeof(TagContext))]
    partial class TagContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.HasKey("GenUIId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("GenUITag");
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

                    b.Property<bool>("HasEndTag")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("TagName")
                        .HasColumnType("text");

                    b.HasKey("TagId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("AutoGenCode.Data.GenUITag", b =>
                {
                    b.HasOne("AutoGenCode.Data.GenUI", "GenUI")
                        .WithMany("Tags")
                        .HasForeignKey("GenUIId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoGenCode.Data.Tag", "Tag")
                        .WithMany("GenUIs")
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
                    b.Navigation("Regions");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("AutoGenCode.Data.Tag", b =>
                {
                    b.Navigation("GenUIs");

                    b.Navigation("Regions");
                });
#pragma warning restore 612, 618
        }
    }
}
