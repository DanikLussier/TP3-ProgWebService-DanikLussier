using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API_FlappyBirb.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace API_FlappyBirb.Data
{
    public class API_FlappyBirbContext : IdentityDbContext<User>
    {
        public API_FlappyBirbContext (DbContextOptions<API_FlappyBirbContext> options)
            : base(options)
        {
        }

        public DbSet<API_FlappyBirb.Models.Score> Score { get; set; } = default!;
    }
}
