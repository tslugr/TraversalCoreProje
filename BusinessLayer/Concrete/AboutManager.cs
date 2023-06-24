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
    public class AboutManager : IAboutService
    {

        IAboutDal _aboutDal;//dal sınıfından bir field ürettik

        public AboutManager(IAboutDal aboutDal)//bu yapının ismi depencty ınjectiondur.
        {
            _aboutDal = aboutDal;
        }
        //yukarıdaki yapıyı generic daldaki crud işlemlerine erişebilmek icin yazdık
        public void TAdd(About t)
        {
            _aboutDal.Insert(t);
        }

        public void TDelete(About t)
        {
            _aboutDal.Delete(t);
        }

        public About TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<About> TGetList()
        {
           return _aboutDal.GetList();
        }

        public void TUpdate(About t)
        {
           _aboutDal.Update(t);
        }
    }
}
