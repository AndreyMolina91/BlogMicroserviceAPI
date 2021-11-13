﻿// <auto-generated />
using BlogMicroservice.Infraestruture;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlogMicroservice.Infraestruture.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211108173311_UrlImgBlogProm")]
    partial class UrlImgBlogProm
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlogMicroservice.Domain.Models.BlogPromoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MainPrice")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PromoPrice")
                        .HasColumnType("int");

                    b.Property<int>("PromoRatingId")
                        .HasColumnType("int");

                    b.Property<string>("UrlImg")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PromoRatingId");

                    b.ToTable("BlogPromo");
                });

            modelBuilder.Entity("BlogMicroservice.Domain.Models.PromoRatingModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Feedback")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Stars")
                        .HasColumnType("int");

                    b.Property<int>("UserAppId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("RatingPromo");
                });

            modelBuilder.Entity("BlogMicroservice.Domain.Models.BlogPromoModel", b =>
                {
                    b.HasOne("BlogMicroservice.Domain.Models.PromoRatingModel", "PromoRating")
                        .WithMany()
                        .HasForeignKey("PromoRatingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PromoRating");
                });
#pragma warning restore 612, 618
        }
    }
}
