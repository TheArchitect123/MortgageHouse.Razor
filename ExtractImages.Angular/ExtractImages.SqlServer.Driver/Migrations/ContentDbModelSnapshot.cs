﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MortgageHouse.Backend.SqlServerDriver;

namespace ExtractImages.SqlServer.Driver.Migrations
{
    [DbContext(typeof(ContentDb))]
    partial class ContentDbModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ExtractImages.SqlServer.Driver.Entities.New", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Record_Create_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("document_type_id")
                        .HasColumnType("int");

                    b.Property<string>("filename")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("imagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("image_id")
                        .HasColumnType("int");

                    b.Property<int>("last_download_obua_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("last_download_timestamp")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("upload_date")
                        .HasColumnType("datetime2");

                    b.Property<int>("upload_obua_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("New");
                });
#pragma warning restore 612, 618
        }
    }
}