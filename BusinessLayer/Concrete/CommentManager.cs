using BusinessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentManager:ICommentService
    {
        EfCommentDal _efCommentDal;

        public CommentManager(EfCommentDal efCommentDal)
        {
            _efCommentDal = efCommentDal;
        }

        public void TAdd(Comment t)
        {
            _efCommentDal.Insert(t);
        }

        public void TDelete(Comment t)
        {
            _efCommentDal.Delete(t);
        }

        public Comment TGetByID(int id)
        {
            return _efCommentDal.GetByID(id);
        }

        public List<Comment> TGetList()
        {
           return _efCommentDal.GetList();
        }

        public List<Comment> TGetDestinationById(int id) 
        {
            return _efCommentDal.GetListByFilter(x => x.DestinationID == id);
        }

        public void TUpdate(Comment t)
        {
            _efCommentDal.Update(t);
        }
    }
}
