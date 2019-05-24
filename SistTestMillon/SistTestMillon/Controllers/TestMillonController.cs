using Model;
using Repository;
using SistTestMillon.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistTestMillon.Controllers
{
    
    public class TestMillonController : Controller
    {
        // GET: TestMillon
        [CloseSesion]
        public ActionResult Cerrar()
        {
            return View();
        }



        public ActionResult Index()
        {
            IRepository repository = new Model.Repository();
            var cuestionario = repository.FindEntitySet<Cuestionario>(c =>c.Id>0 &&c.Id<6).OrderBy(c=>c.Id);
            return View(cuestionario);
        }

        [HttpPost]
        public ActionResult Index(int min,int max)
        {
            IRepository repository = new Model.Repository();
            var cuestionario = repository.FindEntitySet<Cuestionario>(c => c.Id >min && c.Id < max+1).OrderBy(c => c.Id);
            return Json(cuestionario.ToList());
            

        }

        [HttpPost]
        public ActionResult Retroceso(int min, int max)
        {
            IRepository repository = new Model.Repository();
            var cuestionario = repository.FindEntitySet<Cuestionario>(c => c.Id >=min && c.Id < max + 1).OrderBy(c => c.Id);
            return Json(cuestionario.ToList());


        }



    }
}