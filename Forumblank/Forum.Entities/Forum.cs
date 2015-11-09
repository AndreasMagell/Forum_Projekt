using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Entities
{
    class Forum
    {
        public int Id { get; set; }
        public virtual Category Category { get; set; }
    }
}
