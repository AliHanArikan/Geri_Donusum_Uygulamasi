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
    public class EfOfferDal : GenericRepository<Offer>, IOfferDal
    {
        public List<Offer> GetİncomingOffersWithUserId(int userId)
        {
            using(var context = new Context())
            {
                return context.Offers.Where( x => x.ReceiverUserId == userId).ToList();
            }
        }
    }
}
