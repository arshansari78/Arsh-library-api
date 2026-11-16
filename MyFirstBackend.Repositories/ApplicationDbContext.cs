using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyFirstBackend.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFirstBackend.Repositories
{
    public class ApplicationDbContext:IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options) 
        { 
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Book> Books { get; set; } 

        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Allotment> Allotments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var hashed = new PasswordHasher<ApplicationUser>();
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {


                Id = "Arsh",
                UserName = "Arsh",
                NormalizedUserName = "ARSH",
                FullName = "Md Arsh Ansari",
                Email = "Arsha2980@gmail.com",
                PhoneNumber = "8756920024",
                PasswordHash = hashed.HashPassword(null, "Arsh1234")

            });
        }
    }
}
