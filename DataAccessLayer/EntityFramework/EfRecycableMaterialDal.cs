using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfRecycableMaterialDal : GenericRepository<RecycableMaterial>, IRecycAbleMaterialDal
    {
        public List<RecycableMaterial> GetMaterialWithCityName(string cityName)
        {
            using(var context = new Context())
            {
                return context.RecycableMaterials.Where(x => x.LocationCity.Trim() == cityName).ToList();
            }
        }
    }
}
