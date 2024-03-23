using Cupboard.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cupboard.Contexts
{
    public class CupboardContext : DbContext
    {
        public CupboardContext(DbContextOptions<CupboardContext> options) : base(options) {

        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Recipe>()
                .HasOne(r => r.User)
                .WithMany(u => u.Recipes)
                .HasForeignKey(r => r.UserID)
                .OnDelete(DeleteBehavior.NoAction);

            
            modelBuilder.Entity<Review>()
                .HasOne(rev => rev.Recipe)
                .WithMany(r => r.Reviews)
                .HasForeignKey(rev => rev.RecipeID)
                .OnDelete(DeleteBehavior.Cascade);

            
            modelBuilder.Entity<Recipe>()
                .HasOne(r => r.Category)
                .WithMany(c => c.Recipes)
                .HasForeignKey(r => r.CategoryID)
                .OnDelete(DeleteBehavior.Cascade);

            
            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserID)
                .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
