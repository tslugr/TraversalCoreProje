using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IDestinationDal:IGenericDal<Destination>
    {
        //void Insert(Destination destination);
        //void Delete(Destination destination);
        //void Update(Destination destination);
        //List<Destination> GetList();

        //Bu şekilde ayrı ayrı bu işlemleri yapmak yerine tek bir yapı oluşturup o yapı üzerinden crud işlemlerini gerçekleştirebiliriz bu yapımız IGenericDal ve paremetre olarak Destination gönderiyoruz miras aldırırız.


    }
}
