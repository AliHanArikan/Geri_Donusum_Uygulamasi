﻿using BusinessLayer.Abstract;
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
    public class OfferManager : IOfferService
    {
        private readonly IOfferDal _offerDal;

        public OfferManager(IOfferDal offerDal)
        {
            _offerDal = offerDal;
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
