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
    public class AdministradoresController : Controller
    {
        // GET: Administradores
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListaAdministradores(string val, string valSearch, int? page)
        {
            ViewBag.CurrentSort = val;
            ViewBag.Buscar = valSearch;
            IRepository repository = new Model.Repository();
            List<Administradores> objProduct = new List<Administradores>();
            if (string.IsNullOrEmpty(valSearch))
                objProduct = repository.FindEntitySet<Administradores>(c => true).OrderBy(c => c.IdAdministrador).ToList();
            else
                objProduct = repository.FindEntitySet<Administradores>(c => true && (c.Nombres.Contains(valSearch) || c.Direccion.Contains(valSearch))).OrderBy(c => c.ApellidoPaterno).ToList();

            if (val == "IdAdministrador" || string.IsNullOrEmpty(val))
            {
                val = "IdAdministrador";
                objProduct = objProduct.OrderBy(c => c.IdAdministrador).ToList();
            }

            ViewBag.Order = val;
            int pageSize = 5;
            int pageNumber = page ?? 1;


            return PartialView(objProduct.ToPagedList(pageNumber, pageSize));
        }
    }
}