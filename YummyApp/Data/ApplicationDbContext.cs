using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YummyApp.Models;

namespace YummyApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<MenuCategory> menuCategories { get; set; }

        public DbSet<Meal> meals { get; set; }

        public DbSet<PhotoAlbum> photoAlbums { get; set; }

        public DbSet<Photo> photos { get; set; }

        public DbSet<Contact> contacts { get; set; }
        public DbSet<Event> events { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MenuCategory>().HasData(new MenuCategory
            {
                Id = 1,
                Name = "Breakfast"
            },
            new MenuCategory
            {
                Id = 2,
                Name = "Lunch"
            },
            new MenuCategory
            {
                Id = 3,
                Name = "Dinner"
            });


            //GUID
            string ADMIN_ROLE_ID = "2a697dda-1c5a-4470-8878-8870d474f66c";
            string CHEF_ROLE_ID = "f34ce696-c2d9-4f42-9854-16a02518b04f";
            string ADMIN_USER_ID = "bacbe84a-94e8-418d-8e7d-7fba7cece7a0";
            //string User_ROLE_ID = "2a697dda-1c5a-4470-8878-8870d474f66c";


            //Add Role
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = ADMIN_ROLE_ID,
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                ConcurrencyStamp = ADMIN_ROLE_ID,
            });

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = CHEF_ROLE_ID,
                Name = "Chef",
                NormalizedName = "CHEF",
                ConcurrencyStamp = CHEF_ROLE_ID,
            });


            //Add Admin User

            var AdminUser = new ApplicationUser
            {
                Email = "admin@admin.com",
                FirstName = "Admin",
                LastName = "Admin",
                Id = ADMIN_USER_ID,
                userType = UserType.Administrator,
                NormalizedEmail = "ADMIN@ADMIN.COM",
                UserName = "Admin",
            };

            //PasswordHasher

            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();

            AdminUser.PasswordHash = passwordHasher.HashPassword(AdminUser, "Password");

            builder.Entity<ApplicationUser>().HasData(AdminUser);

            // Add Role To Admin User

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ADMIN_ROLE_ID,
                UserId = ADMIN_USER_ID,
            });



            string CHEF_ID_1 = "5afdb732-6ff6-4b37-a77f-34596b472e14";

            var Chef_1 = new ApplicationUser
            {


                Email = "chef1@chef.com",
                FirstName = "Mohammed",
                LastName = "Abdo",
                Id = CHEF_ID_1,
                userType = UserType.Chef,
                NormalizedEmail = "CHEF1@CHEF.COM",
                UserName = "CHEF1",
                NormalizedUserName = "CHEF1"
            };



            Chef_1.PasswordHash = passwordHasher.HashPassword(Chef_1, "Password");

            builder.Entity<ApplicationUser>().HasData(Chef_1);


            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = CHEF_ROLE_ID,
                UserId = CHEF_ID_1,
            });


            base.OnModelCreating(builder);
        }






    }
}