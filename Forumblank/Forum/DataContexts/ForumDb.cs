using Forum.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Forum.DataContexts
{
    public class ForumDb : DbContext
    {
        public ForumDb()
            : base("DefaultConnection")
        {

        }

        public DbSet<Forums> Forums { get; set; }
    }
}