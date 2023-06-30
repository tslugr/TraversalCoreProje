using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CityController : Controller
    {
       
        private readonly IDestinationService _destinationService;

        public CityController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CityList()
        {
            //Ajax ile veri listeleme
            var jsonCity = JsonConvert.SerializeObject(_destinationService.TGetList());
            return Json(jsonCity);
        }

        [HttpPost]
        public IActionResult AddCityDestination(Destination destination)
        {
            //Ajax ile veri ekleme
            destination.Status = true;
            _destinationService.TAdd(destination);
            var values = JsonConvert.SerializeObject(destination);
            return Json(values);
        }

        public IActionResult GetById(int DestinationID)
        {
            //Ajax ile id ye göre veri bulma
            var values = _destinationService.TGetByID(DestinationID);
            var jsonValues = JsonConvert.SerializeObject(values);
            return Json(jsonValues);
        }

        public IActionResult DeleteCity(int id)
        {
            //Ajax ile veri silme
            var values = _destinationService.TGetByID(id);
            _destinationService.TDelete(values);
            return NoContent();
        }

        public IActionResult UpdateCity(Destination destination)
        {
            //Ajax ile veri güncelleme
            _destinationService.TUpdate(destination);
            var v = JsonConvert.SerializeObject(destination);
            return Json(v);
        }

        //public static List<CityClass> cities = new List<CityClass>
        //{
        //    new CityClass
        //    {
        //        CityID=1,
        //        CityName="Üsküp",
        //        CityCountry="Makedonya"
        //    },
        //    new CityClass
        //    {
        //        CityID=2,
        //        CityName="Roma",
        //        CityCountry="İtalya"
        //    },
        //    new CityClass
        //    {
        //        CityID=3,
        //        CityName="Londra",
        //        CityCountry="İngiltere"
        //    }
        //};
    }
}
