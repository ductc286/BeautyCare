using System.Data.Entity;
using BeautyCare.DAL.InitData;
using BeautyCare.Models.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BeautyCare.DAL.DatabaseContext
{

    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        static ApplicationDbContext()
        {
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            Database.SetInitializer<ApplicationDbContext>(new DBInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Headquaters> Headquaters { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Configuration> Configurations { get; set; }
        public virtual DbSet<Advisory> Advisories { get; set; }
        public virtual DbSet<Trainer> Trainers { get; set; }
        public virtual DbSet<TraineeOpinion> TraineeOpinions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityUser>().ToTable("User");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
        }
    }
}