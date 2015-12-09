using Forum.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Forum.DataContexts
{
    public class ForumDbContext : IdentityDbContext<ApplicationUser>
    {
        public ForumDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Categories> Categories { get; set; }
        public DbSet<Forums> Forums { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Thread> Threads { get; set; }

        public static ForumDbContext Create()
        {
            return new ForumDbContext();
        }
    }
}