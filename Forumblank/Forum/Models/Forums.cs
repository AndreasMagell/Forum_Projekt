using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class Forums
    {
        public int Id { get; set; }
        public virtual Categories Category { get; set; }
    }
}
