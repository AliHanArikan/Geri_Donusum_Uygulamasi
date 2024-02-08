using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.PostDtos
{
    public class PostDtoView
    {
        public int PostId { get; set; }

        public int? UserId { get; set; }

        

        public string PostDescription { get; set; }

        public string PostImageUrl1 { get; set; }
        public string PostImageUrl2 { get; set; }

        public DateTime DateTime { get; set; }

        public string UserName { get; set; }
        public string UserİmageUrl { get; set; }

    }
}
