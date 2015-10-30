using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Forum_Projekt.Models
{
    public class Threads
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        public virtual Users User { get; set; }
        public virtual Categories Categorie { get; set; }
    }
}