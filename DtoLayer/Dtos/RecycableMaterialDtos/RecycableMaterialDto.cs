using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.RecycableMaterialDtos
{
    public class RecycableMaterialDto
    {
        public string RecycableMaterialType { get; set; }

        public string LocationCity { get; set; }
        public string LocationDistrict { get; set; }
        public string LocationFullAdress { get; set; }

    
        public string? materialAmount { get; set; }
        public string? imageUrl { get; set; }

    }
}
