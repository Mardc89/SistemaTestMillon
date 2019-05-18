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
    [Autenticado]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            IRepository repository = new Model.Repository();
            var objResult = repository.FindEntity<Usuarios>(c => true);
            return View(objResult);
        }
    }
}