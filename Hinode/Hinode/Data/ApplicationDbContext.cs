using System;
using System.Collections.Generic;
using System.Text;
using Hinode.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hinode.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserConfig> UserConfig { get; set; }

        public DbSet<UserDiv> UserDiv { get; set; }




    }
}
