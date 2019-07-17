using Model;
using PagedList;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistTestMillon.Controllers
{
    [Authorize]
    public class CitasController : Controller
    {
        // GET: Citas
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Listacitas(string val, string valSearch, int? page)
        {
            ViewBag.CurrentSort = val;
            ViewBag.Buscar = valSearch;
            IRepository repository = new Model.Repository();
            List<Citas> objProduct = new List<Citas>();
            if (string.IsNullOrEmpty(valSearch))
                objProduct = repository.FindEntitySet<Citas>(c => true).OrderBy(c => c.IdCita).ToList();
            else
                objProduct = repository.FindEntitySet<Citas>(c => true && (c.DniPsicologo.Contains(valSearch) || c.Hora.Contains(valSearch))).OrderBy(c => c.DniPaciente).ToList();

            if (val == "IdCita" || string.IsNullOrEmpty(val))
            {
                val = "IdCita";
                objProduct = objProduct.OrderBy(c => c.IdCita).ToList();
            }

            ViewBag.Order = val;
            int pageSize = 5;
            int pageNumber = page ?? 1;


            return PartialView(objProduct.ToPagedList(pageNumber, pageSize));
        }


    }
}