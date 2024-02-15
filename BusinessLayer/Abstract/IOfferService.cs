﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IOfferService : IGenericService<Offer>, IBaseService
    {
        public List<Offer> TGetİncomingOffersWithUserId(int userId);
        public List<Offer> TGetSendedOffers(int userId);

    }
}
