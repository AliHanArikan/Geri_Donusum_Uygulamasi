﻿using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IOfferDal : IGenericDal<Offer>
    {
        public List<Offer> GetİncomingOffersWithUserId(int userId);

       public List<Offer> GetSendedOffer(int userId);
    }
}
