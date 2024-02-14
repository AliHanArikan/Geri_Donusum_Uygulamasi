using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SocialMediaManager : ISocialMediaService
    {
        private readonly ISocialMediaDal _socialMediaDal;

        public SocialMediaManager(ISocialMediaDal socialMediaDal)
        {
            _socialMediaDal = socialMediaDal;
        }

        public void TDelete(Post t)
        {
            _socialMediaDal.Delete(t);
        }

        public List<Post> TGetAll()
        {
           return _socialMediaDal.GetAll();
        }

        public Post TGetByID(int id)
        {
            return _socialMediaDal.GetByID(id);
        }

        public void TInsert(Post t)
        {
            _socialMediaDal.Insert(t);
        }

       

        public void TUpdate(Post t)
        {
            _socialMediaDal.Update(t);
        }
    }
}
