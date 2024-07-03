﻿﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace FPTJobMatch.Models
    {
        public class DBContext : IdentityDbContext<IdentityUser>
        {
            public DBContext(DbContextOptions<DBContext> options) : base(options)
            {

            }


            public DbSet<Category> Categories { get; set; }
            public DbSet<Job> Jobs { get; set; }
            public DbSet<FPTJobMatch.Models.Profile> Profile { get; set; } = default!;
            public DbSet<FPTJobMatch.Models.ProJob> ProJob { get; set; } = default!;
        }
}
