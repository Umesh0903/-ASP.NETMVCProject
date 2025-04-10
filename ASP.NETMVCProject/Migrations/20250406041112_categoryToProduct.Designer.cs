﻿// <auto-generated />
using ASP.NETMVCProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ASP.NETMVCProject.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250406041112_categoryToProduct")]
    partial class categoryToProduct
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ASP.NETMVCProject.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Electronics"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Books"
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Clothing"
                        });
                });

            modelBuilder.Entity("ASP.NETMVCProject.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            CategoryId = 1,
                            ProductName = "Smartphone"
                        },
                        new
                        {
                            ProductId = 2,
                            CategoryId = 1,
                            ProductName = "Laptop"
                        },
                        new
                        {
                            ProductId = 3,
                            CategoryId = 2,
                            ProductName = "Novel"
                        },
                        new
                        {
                            ProductId = 4,
                            CategoryId = 3,
                            ProductName = "T-Shirt"
                        });
                });

            modelBuilder.Entity("ASP.NETMVCProject.Models.Product", b =>
                {
                    b.HasOne("ASP.NETMVCProject.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ASP.NETMVCProject.Models.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
