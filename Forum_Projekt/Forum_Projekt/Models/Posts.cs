using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Forum_Projekt.Models
{
    public class Posts
    {
        public int Id { get; set; }
        [Required]
        public string Body { get; set; }
        public DateTime Date { get; set; }

        public virtual Users User { get; set; }
        public virtual Threads Thread { get; set; }
    }
}