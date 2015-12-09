﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class Categories
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Thread> Threads {get;set;}
    }
}
