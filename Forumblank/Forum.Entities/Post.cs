using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Entities
{
    public class Post
    {
        public int Id { get; set; }
        [Required]
        public string Body { get; set; }
        public DateTime Date { get; set; }

        public virtual User User { get; set; }
        public virtual Thread Thread { get; set; }

    }
}
