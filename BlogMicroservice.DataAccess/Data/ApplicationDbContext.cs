using BlogMicroservice.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogMicroservice.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
         
        public DbSet<BlogPromoModel> BlogPromo { get; set; }
        public DbSet<PromoRatingModel> RatingPromo { get; set; }
    }
}
