using Model;
using Repository;
using SistTestMillon.Attributes;
using SistTestMillon.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistTestMillon.Controllers
{
    [Autenticado]

    public class HomeController : Controller
    {
        // GET: Home
        [Authorize]
        public ActionResult Index()
        {
            if (HttpContext.Session["TipoUsuario"] == null)
            {
                return RedirectToAction("Index", "Account");

            }
            else
            {
                IRepository repository = new Model.Repository();
                var objResult = repository.FindEntity<Usuarios>(c => true);
                return View(objResult);
            }


        }

        public ActionResult Cerrar()
        {
            SessionHelper.DestroyUserSession();
            HttpContext.Session["TipoUsuario"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}