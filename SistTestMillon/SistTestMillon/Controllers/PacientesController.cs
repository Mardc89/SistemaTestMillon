using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistTestMillon.Controllers
{
    public class PacientesController : Controller
    {
        // GET: Pacientes
        public ActionResult Index()
        {

            IRepository repository = new Model.Repository();
            var cuestionario = repository.FindEntitySet<Pacientes>(c => c.IdPaciente > 0 && c.IdPaciente< 6).OrderBy(c => c.IdPaciente);
            return View(cuestionario);
        }
    }
}