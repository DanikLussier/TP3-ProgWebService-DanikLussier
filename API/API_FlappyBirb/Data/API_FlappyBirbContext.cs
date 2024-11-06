using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API_FlappyBirb.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace API_FlappyBirb.Data
{
    public class API_FlappyBirbContext : IdentityDbContext<User>
    {
        public API_FlappyBirbContext (DbContextOptions<API_FlappyBirbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            PasswordHasher<User> hasher = new PasswordHasher<User>();

            User u1 = new User
            {
                Id = "11111111-1111-1111-1111-111111111111",
                UserName = "dan",
                Email = "d@d.d",
            };
            u1.PasswordHash = hasher.HashPassword(u1, "Dan13!");

            User u2 = new User
            {
                Id = "22222222-2222-2222-2222-222222222222",
                UserName = "ali",
                Email = "a@a.a",
            };
            u2.PasswordHash = hasher.HashPassword(u2, "Al12!");

            builder.Entity<User>().HasData(u1, u2);

            builder.Entity<Score>().HasData(
                new
                {
                    Id = 1,
                    Value = 5,
                    Temps = 4.6f,
                    Date = DateTime.Now,
                    isVisible = true,
                    userId = "11111111-1111-1111-1111-111111111111"
                },
                new
                {
                    Id = 2,
                    Value = 10,
                    Temps = 9.8f,
                    Date = DateTime.Now,
                    isVisible = false,
                    userId = "11111111-1111-1111-1111-111111111111"
                },
                new
                {
                    Id = 3,
                    Value = 12,
                    Temps = 20.3f,
                    Date = DateTime.Now,
                    isVisible = true,
                    userId = "22222222-2222-2222-2222-222222222222"
                },
                new
                {
                    Id = 4,
                    Value = 23,
                    Temps = 34.9f,
                    Date = DateTime.Now,
                    isVisible = false,
                    userId = "22222222-2222-2222-2222-222222222222"
                }
                );
        }

        public DbSet<API_FlappyBirb.Models.Score> Score { get; set; } = default!;
    }
}
