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

        public List<RecycableMaterial> GetMaterialWithUserId(int userId)
        {
            using(var context = new Context())
            {
                return context.RecycableMaterials.Where(x=> x.AppUserID == userId).ToList();
            }
        }

        public List<RecycableMaterial> GetMaterialWithUserIdDelivered(int userId)
        {
            //here we try to do that where appUserId equls our userID and where isStatus equls false
            //here we try to find that  app UserId equals our userID and where is Status equals false
            using (var context = new Context())
            {
                return context.RecycableMaterials.Where(x => x.AppUserID == userId).Where(y => y.isStatus == true).ToList();
            }
        }
    }
}
