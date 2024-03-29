﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class RecycAbleMaterialManager : IRecycAbleMaterialService
    {
        private readonly IRecycAbleMaterialDal _recycAbleMaterialDal;

        public RecycAbleMaterialManager(IRecycAbleMaterialDal recycAbleMaterialDal)
        {
            _recycAbleMaterialDal = recycAbleMaterialDal;
        }

        public void TDelete(RecycableMaterial t)
        {
            _recycAbleMaterialDal.Delete(t);
        }

        public List<RecycableMaterial> TGetAll()
        {
           return _recycAbleMaterialDal.GetAll();
        }

        public RecycableMaterial TGetByID(int id)
        {
           return _recycAbleMaterialDal.GetByID(id);
        }

        public List<RecycableMaterial> TGetMaterialWithCityName(string cityName)
        {
            return _recycAbleMaterialDal.GetMaterialWithCityName(cityName);
        }

        public List<RecycableMaterial> TGetMaterialWithUserId(int userId)
        {
            return _recycAbleMaterialDal.GetMaterialWithUserId(userId);
        }

        public List<RecycableMaterial> TGetMaterialWithUserIdDelivered(int userId)
        {
            return _recycAbleMaterialDal.GetMaterialWithUserIdDelivered(userId);
        }

        public void TInsert(RecycableMaterial t)
        {
            _recycAbleMaterialDal.Insert(t);
        }

        public void TUpdate(RecycableMaterial t)
        {
            _recycAbleMaterialDal.Update(t);
        }
    }
}
