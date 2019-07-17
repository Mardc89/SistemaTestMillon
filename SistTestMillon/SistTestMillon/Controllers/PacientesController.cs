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
    public class PacientesController : Controller
    {
        // GET: Pacientes
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListaPacientes(string val, string valSearch, int? page)
        {
            ViewBag.CurrentSort = val;
            ViewBag.Buscar = valSearch;
            IRepository repository = new Model.Repository();
            List<Pacientes> objProduct = new List<Pacientes>();
            if (string.IsNullOrEmpty(valSearch))
                objProduct = repository.FindEntitySet<Pacientes>(c => true).OrderBy(c => c.IdPaciente).ToList();
            else
                objProduct = repository.FindEntitySet<Pacientes>(c => true && (c.ApellidoPaterno.Contains(valSearch) || c.ApellidoMaterno.Contains(valSearch))).OrderBy(c => c.DniPaciente).ToList();

            if (val == "IdPaciente" || string.IsNullOrEmpty(val))
            {
                val = "IdPaciente";
                objProduct = objProduct.OrderBy(c => c.IdPaciente).ToList();
            }

            ViewBag.Order = val;
            int pageSize = 5;
            int pageNumber = page ?? 1;


            return PartialView(objProduct.ToPagedList(pageNumber, pageSize));
        }


    }
}