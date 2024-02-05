using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Post
    {
        public int PostId { get; set; }

        public int? UserId { get; set; }

        public AppUser User { get; set; }

        public string PostDescription { get; set; }

        public DateTime DateTime { get; set; }


    }
}
