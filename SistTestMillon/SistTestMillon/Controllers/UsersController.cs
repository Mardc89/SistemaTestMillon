using Model;
using PagedList;
using Repository;
using SistTestMillon.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistTestMillon.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        // GET: Users

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListaUsuarios(string val, string valSearch, int? page)
        {
            ViewBag.CurrentSort = val;
            ViewBag.Buscar = valSearch;
            IRepository repository = new Model.Repository();
            List<Usuarios> objProduct = new List<Usuarios>();
            if (string.IsNullOrEmpty(valSearch))
                objProduct = repository.FindEntitySet<Usuarios>(c => true).OrderBy(c => c.IdUsuario).ToList();
            else
                objProduct = repository.FindEntitySet<Usuarios>(c => true && (c.NombreUsuario.ToString().Contains(valSearch) || c.TipoUsuario.Contains(valSearch))).OrderBy(c => c.IdUsuario).ToList();

            if (val == "IdUsuario)" || string.IsNullOrEmpty(val))
            {
                val = "IdUsuario)";
                objProduct = objProduct.OrderBy(c => c.IdUsuario).ToList();
            }

            ViewBag.Order = val;
            int pageSize = 5;
            int pageNumber = page ?? 1;


            return PartialView(objProduct.ToPagedList(pageNumber, pageSize));
        }


        public ActionResult Users()
        {
            ViewBag.User=SessionHelper.GetUser();
            if (ViewBag.User==0)
            {
                return RedirectToAction("Index", "Account");

            }
            else {
                    return View();
            }
            
        }
    }
}