using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRecycAbleMaterialDal : IGenericDal<RecycableMaterial>
    {
        public List<RecycableMaterial> GetMaterialWithCityName(string cityName);  
        public List<RecycableMaterial> GetMaterialWithUserId(int userId);
    }
}
