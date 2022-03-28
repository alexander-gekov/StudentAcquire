﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentAcquire.Listing.Service.Data;

namespace StudentAcquire.Listing.Service.Migrations
{
    [DbContext(typeof(StudentAcquireListingServiceContext))]
    [Migration("20220328142910_v1.0")]
    partial class v10
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StudentAcquire.Listing.Service.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ListingId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ListingId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("StudentAcquire.Listing.Service.Models.Listing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CoverImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IconImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MessagesSent")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price_High")
                        .HasColumnType("float");

                    b.Property<double>("Price_Low")
                        .HasColumnType("float");

                    b.Property<bool>("Sold")
                        .HasColumnType("bit");

                    b.Property<int>("Views")
                        .HasColumnType("int");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Listings");
                });

            modelBuilder.Entity("StudentAcquire.Listing.Service.Models.Seller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ListingId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ListingId");

                    b.ToTable("Seller");
                });

            modelBuilder.Entity("StudentAcquire.Listing.Service.Models.Category", b =>
                {
                    b.HasOne("StudentAcquire.Listing.Service.Models.Listing", null)
                        .WithMany("Categories")
                        .HasForeignKey("ListingId");
                });

            modelBuilder.Entity("StudentAcquire.Listing.Service.Models.Seller", b =>
                {
                    b.HasOne("StudentAcquire.Listing.Service.Models.Listing", null)
                        .WithMany("Sellers")
                        .HasForeignKey("ListingId");
                });

            modelBuilder.Entity("StudentAcquire.Listing.Service.Models.Listing", b =>
                {
                    b.Navigation("Categories");

                    b.Navigation("Sellers");
                });
#pragma warning restore 612, 618
        }
    }
}
