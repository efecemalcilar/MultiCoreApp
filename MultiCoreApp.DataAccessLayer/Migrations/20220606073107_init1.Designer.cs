﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MultiCoreApp.DataAccessLayer;

#nullable disable

namespace MultiCoreApp.DataAccessLayer.Migrations
{
    [DbContext(typeof(MultiDbContext))]
    [Migration("20220606073107_init1")]
    partial class init1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MultiCoreApp.Core.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("tblCategories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("188f1bbb-c39f-403f-a55c-da1a5cb43683"),
                            IsDeleted = false,
                            Name = "Kalemler"
                        },
                        new
                        {
                            Id = new Guid("e6c88b4e-b2d2-40dc-962d-203f8304f733"),
                            IsDeleted = false,
                            Name = "Defterler"
                        });
                });

            modelBuilder.Entity("MultiCoreApp.Core.Models.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("tblCustomers", (string)null);
                });

            modelBuilder.Entity("MultiCoreApp.Core.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("tblProducts", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("36a3eadc-0a81-4547-a30d-3ae3b9174aed"),
                            CategoryId = new Guid("188f1bbb-c39f-403f-a55c-da1a5cb43683"),
                            IsDeleted = false,
                            Name = "Dolma kalem",
                            Price = 122.53m,
                            Stock = 100
                        },
                        new
                        {
                            Id = new Guid("1e6fe0d4-4531-4a97-81d9-a1537cf90cb1"),
                            CategoryId = new Guid("188f1bbb-c39f-403f-a55c-da1a5cb43683"),
                            IsDeleted = false,
                            Name = "Tukenmez kalem",
                            Price = 18.06m,
                            Stock = 100
                        },
                        new
                        {
                            Id = new Guid("0a1f227a-a4c6-4f48-8fd5-ad538184bccc"),
                            CategoryId = new Guid("188f1bbb-c39f-403f-a55c-da1a5cb43683"),
                            IsDeleted = false,
                            Name = "Kursun Kalem",
                            Price = 62.19m,
                            Stock = 100
                        },
                        new
                        {
                            Id = new Guid("9e1bff21-e94b-4b72-a68f-8498f04c043e"),
                            CategoryId = new Guid("e6c88b4e-b2d2-40dc-962d-203f8304f733"),
                            IsDeleted = false,
                            Name = "Çizgili Defter",
                            Price = 22.53m,
                            Stock = 100
                        },
                        new
                        {
                            Id = new Guid("bbc0f781-db38-4aac-8793-530c73edc909"),
                            CategoryId = new Guid("e6c88b4e-b2d2-40dc-962d-203f8304f733"),
                            IsDeleted = false,
                            Name = "Kareli Defter",
                            Price = 28.06m,
                            Stock = 100
                        },
                        new
                        {
                            Id = new Guid("5eb3ba7d-4ee8-4d5e-ae69-8bfbcd71c949"),
                            CategoryId = new Guid("e6c88b4e-b2d2-40dc-962d-203f8304f733"),
                            IsDeleted = false,
                            Name = "Dumduz defter",
                            Price = 12.19m,
                            Stock = 0
                        });
                });

            modelBuilder.Entity("MultiCoreApp.Core.Models.Product", b =>
                {
                    b.HasOne("MultiCoreApp.Core.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("MultiCoreApp.Core.Models.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
