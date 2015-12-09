using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class Post
    {
        public int Id { get; set; }
        
        [Required]
        public string Body { get; set; }
        public DateTime Date { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Thread Thread { get; set; }
        
    }
}
