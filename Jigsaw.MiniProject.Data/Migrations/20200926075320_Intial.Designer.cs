﻿// <auto-generated />
using System;
using Jigsaw.MiniProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Jigsaw.MiniProject.Data.Migrations
{
    [DbContext(typeof(TreeContext))]
    [Migration("20200926075320_Intial")]
    partial class Intial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Jigsaw.MiniProject.Data.Models.TreeItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("TreeItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "A"
                        },
                        new
                        {
                            Id = 2,
                            Name = "B",
                            ParentId = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "C",
                            ParentId = 2
                        },
                        new
                        {
                            Id = 4,
                            Name = "d",
                            ParentId = 1
                        });
                });

            modelBuilder.Entity("Jigsaw.MiniProject.Data.Models.TreeItem", b =>
                {
                    b.HasOne("Jigsaw.MiniProject.Data.Models.TreeItem", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");
                });
#pragma warning restore 612, 618
        }
    }
}
