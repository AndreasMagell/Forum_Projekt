﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Entities
{
    public class Thread
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        public DateTime Date { get; set; }

        public virtual Categories Category { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Post> Posts { get; set; }

        public static implicit operator Thread(int v)
        {
            throw new NotImplementedException();
        }
    }
}
