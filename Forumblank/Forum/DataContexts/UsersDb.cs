using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Forum.Entities;

namespace Forum.DataContexts
{
    public class UsersDb : DbContext
    {
        public UsersDb()
            : base("DefaultConnection")
        { 

        }

        public DbSet<User> Users { get; set; }
    }
}