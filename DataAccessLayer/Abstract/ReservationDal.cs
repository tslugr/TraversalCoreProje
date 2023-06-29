using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ReservationDal:IGenericDal<Reservation>
    {
        List<Reservation> GetListWithReservationByWaitAprroval(int id);//Onay Bekleyen
        List<Reservation> GetListWithReservationByAccepted(int id);//Kabul Edilen
        List<Reservation> GetListWithReservationByPrevious(int id);//Geçmiş
    }
}
