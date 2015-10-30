using Forum_Projekt.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Forum_Projekt.DataContexts
{
    public class ForumDb : DbContext
    {
        public DbSet<Posts> Posts { get; set; }
        public DbSet<Threads> Threads { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Categories> Categorie { get; set; }
    }
}