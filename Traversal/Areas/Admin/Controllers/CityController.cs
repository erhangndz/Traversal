using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Traversal.Models;

namespace Traversal.Areas.Admin.Controllers
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

        [HttpGet]
        public IActionResult CityList()
        {
            var jsonCity = JsonConvert.SerializeObject(_destinationService.TGetList());
            return Json(jsonCity);
        }

        [HttpPost]
        public IActionResult AddCity(Destination p)
        {
            p.Status = true;
            _destinationService.TInsert(p);
           var values= JsonConvert.SerializeObject(p);
            return Json(values);
        }

        public IActionResult GetByID(int id)
        {
            var values = _destinationService.TGetByID(id);
            var jsonValues= JsonConvert.SerializeObject(values);
            return Json(jsonValues);
        }

        public IActionResult DeleteCity(int id)
        {
            var values = _destinationService.TGetByID(id);
            _destinationService.TDelete(values);
            return NoContent();
        }

        public IActionResult UpdateCity(Destination p)
        {
           
            _destinationService.TUpdate(p);
            var jsonValue = JsonConvert.SerializeObject(p); 
            return Json(jsonValue);
        }

        //public static List<CityClass> cities = new List<CityClass>
        //{
        //    new CityClass()
        //    {
        //        CityID= 1,
        //        CityName="Üsküp",
        //        CityCountry="Makedonya"
        //    },
        //    new CityClass()
        //    {
        //         CityID= 2,
        //        CityName="Roma",
        //        CityCountry="İtalya"
        //    },
        //    new CityClass()
        //    {
        //        CityID= 3,
        //        CityName="Barcelona",
        //        CityCountry="İspanya"
        //    }
        //};

        
    }
}
