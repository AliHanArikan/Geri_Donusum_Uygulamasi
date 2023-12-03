using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class RecycableMaterial
    {
       public int RecycableMaterialID {  get; set; }
        public string RecycableMaterialType { get; set; }

        public string LocationCity { get; set; }
        public string LocationDistrict { get; set; }
        public string LocationFullAdress {  get; set; }

        public int AppUserID { get; set; }
        public AppUser AppUser { get; set; }

        public DateTime ProcessDate { get; set; }
        public Boolean? isStatus { get; set; }

        public string? materialAmount { get; set; }
        public string? imageUrl { get; set; }

    }
}
