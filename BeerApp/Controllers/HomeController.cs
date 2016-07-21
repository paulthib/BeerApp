using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Beer.Data;
using Beer.Model;

namespace BeerApp.Controllers
{
    public class HomeController : Controller
    {
        private IGenericRepository<Ingredient> _repo;
        public HomeController(IGenericRepository<Ingredient> repository )
        {
            _repo = repository;
        }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [HttpPost]
        public JsonResult GetIngredients()
        {
            var data = _repo.SelectAll();
            var ret = data.Select(x => new { x.Id, x.Name }).ToList();
            return Json(ret);
        }
    }
}
