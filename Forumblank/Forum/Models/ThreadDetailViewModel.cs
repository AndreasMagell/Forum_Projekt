using Forum.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class ThreadDetailViewModel
    {
        public string NewPost { get; set; }

        public virtual Post ThreadPosts { get; set; }
        public string Thread { get; set; }
    }
}