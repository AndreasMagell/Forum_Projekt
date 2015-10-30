using Forum.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Forum.DataContexts
{
    public class ThreadsDb : DbContext
    {
        public ThreadsDb()
            : base("DefaultConnection")
        {

        }

        public DbSet<Thread> Threads { get; set; }
    }
}