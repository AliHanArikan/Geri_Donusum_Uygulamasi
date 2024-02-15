using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IRecycAbleMaterialService : IGenericService<RecycableMaterial>, IBaseService
    {
        public List<RecycableMaterial> TGetMaterialWithCityName(string cityName);
        public List<RecycableMaterial> TGetMaterialWithUserId(int userId);

        public List<RecycableMaterial> TGetMaterialWithUserIdDelivered(int userId);
    }
}
