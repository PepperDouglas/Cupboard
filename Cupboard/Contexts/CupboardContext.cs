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

            // Configure User-Recipe relationship
            modelBuilder.Entity<Recipe>()
                .HasOne(r => r.User) // Recipe has one User
                .WithMany(u => u.Recipes) // User has many Recipes
                .HasForeignKey(r => r.UserID) // Specify the foreign key in Recipe
                .OnDelete(DeleteBehavior.NoAction); // Prevent deleting User when Recipe is deleted

            // Configure Recipe-Review relationship
            modelBuilder.Entity<Review>()
                .HasOne(rev => rev.Recipe) // Review has one Recipe
                .WithMany(r => r.Reviews) // Recipe has many Reviews
                .HasForeignKey(rev => rev.RecipeID) // Specify the foreign key in Review
                .OnDelete(DeleteBehavior.Cascade); // Allow deleting Reviews when Recipe is deleted

            // Configure Recipe-Category relationship
            modelBuilder.Entity<Recipe>()
                .HasOne(r => r.Category) // Recipe has one Category
                .WithMany(c => c.Recipes) // Category has many Recipes
                .HasForeignKey(r => r.CategoryID) // Specify the foreign key in Recipe
                .OnDelete(DeleteBehavior.Cascade); // Allow deleting Recipes when Category is deleted

            // Configure User-Review direct relationship (if needed, assuming Review has a UserId foreign key)
            modelBuilder.Entity<Review>()
                .HasOne(r => r.User) // Review has one User
                .WithMany() // Optionally, if User does not have a navigation property to Reviews
                .HasForeignKey(r => r.UserID) // Specify the foreign key in Review
                .OnDelete(DeleteBehavior.NoAction); // Prevent deleting User when Review is deleted
        }

    }
}
