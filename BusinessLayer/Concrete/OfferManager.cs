using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class OfferManager : BaseManager, IOfferService
    {
        private readonly IOfferDal _offerDal;
        private readonly ILoggerService _loggerService;

        public OfferManager(IOfferDal offerDal, ILoggerService loggerService)
        {
            _offerDal = offerDal;
            _loggerService = loggerService;
        }

        public void TDelete(Offer t)
        {
                _offerDal.Delete(t);
        }

        public List<Offer> TGetAll()
        {
            return _offerDal.GetAll();
        }

        public Offer TGetByID(int id)
        {
            return _offerDal.GetByID(id);
        }

        public List<Offer> TGetSendedOffers(int userId)
        {
            return _offerDal.GetSendedOffer(userId);
        }

        public List<Offer> TGetİncomingOffersWithUserId(int userId)
        {
            return _offerDal.GetİncomingOffersWithUserId(userId);
        }

        public void TInsert(Offer t)
        {
           _offerDal.Insert(t);
        }

       

        public void TUpdate(Offer t)
        {
            _offerDal.Update(t);
        }
    }
}
