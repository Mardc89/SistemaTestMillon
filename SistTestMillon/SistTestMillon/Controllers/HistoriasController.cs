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
    public class HistoriasController : Controller
    {
        // GET: Historias
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListaHistorias(string val, string valSearch, int? page)
        {
            ViewBag.CurrentSort = val;
            ViewBag.Buscar = valSearch;
            IRepository repository = new Model.Repository();
            List<Historias> objProduct = new List<Historias>();
            if (string.IsNullOrEmpty(valSearch))
                objProduct = repository.FindEntitySet<Historias>(c =>true).OrderBy(c => c.IdHistoria).ToList();
            else
                objProduct = repository.FindEntitySet<Historias>(c =>true && (c.Observacion.Contains(valSearch) || c.Codigo.Contains(valSearch))).OrderBy(c => c.IdHistoria).ToList();

            if (val == "Id" || string.IsNullOrEmpty(val))
            {
                val = "Id";
                objProduct = objProduct.OrderBy(c => c.IdHistoria).ToList();
            }

            ViewBag.Order = val;
            int pageSize = 5;
            int pageNumber = page ?? 1;


            return PartialView(objProduct.ToPagedList(pageNumber, pageSize));
        }
    }
}