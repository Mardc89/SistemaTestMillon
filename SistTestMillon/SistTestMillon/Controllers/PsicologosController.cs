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
    public class PsicologosController : Controller
    {
        // GET: Psicologos
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListaPsicologos(string val, string valSearch, int? page)
        {
            ViewBag.CurrentSort = val;
            ViewBag.Buscar = valSearch;
            IRepository repository = new Model.Repository();
            List<Psicologos> objProduct = new List<Psicologos>();
            if (string.IsNullOrEmpty(valSearch))
                objProduct = repository.FindEntitySet<Psicologos>(c => true).OrderBy(c => c.IdPsicologo).ToList();
            else
                objProduct = repository.FindEntitySet<Psicologos>(c => true && (c.Nombres.Contains(valSearch) || c.Direccion.Contains(valSearch))).OrderBy(c => c.ApellidoPaterno).ToList();

            if (val == "IdPsicologo" || string.IsNullOrEmpty(val))
            {
                val = "IdPsicologo";
                objProduct = objProduct.OrderBy(c => c.IdPsicologo).ToList();
            }

            ViewBag.Order = val;
            int pageSize = 5;
            int pageNumber = page ?? 1;


            return PartialView(objProduct.ToPagedList(pageNumber, pageSize));
        }
    }
}