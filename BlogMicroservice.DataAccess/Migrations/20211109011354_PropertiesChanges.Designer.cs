// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogMicroservice.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211109011354_PropertiesChanges")]
    partial class PropertiesChanges
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlogMicroservice.Domain.Models.BlogPromoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(140)
                        .HasColumnType("nvarchar(140)");

                    b.Property<int>("MainPrice")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PromoPrice")
                        .HasColumnType("int");

                    b.Property<string>("UrlImg")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BlogPromo");
                });

            modelBuilder.Entity("BlogMicroservice.Domain.Models.PromoRatingModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BlogPromoId")
                        .HasColumnType("int");

                    b.Property<string>("Feedback")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Stars")
                        .HasColumnType("int");

                    b.Property<int?>("UserAppId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BlogPromoId");

                    b.ToTable("RatingPromo");
                });

            modelBuilder.Entity("BlogMicroservice.Domain.Models.PromoRatingModel", b =>
                {
                    b.HasOne("BlogMicroservice.Domain.Models.BlogPromoModel", "BlogPromo")
                        .WithMany("PromoRatings")
                        .HasForeignKey("BlogPromoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BlogPromo");
                });

            modelBuilder.Entity("BlogMicroservice.Domain.Models.BlogPromoModel", b =>
                {
                    b.Navigation("PromoRatings");
                });
#pragma warning restore 612, 618
        }
    }
}
