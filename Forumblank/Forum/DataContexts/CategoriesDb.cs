using Forum.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Forum.DataContexts
{
    public class CategoriesDb : DbContext
    {
        public CategoriesDb()
            : base("DefaultConnection")
        {

        }

        public DbSet<Categories> Categories { get; set; }
    }
}