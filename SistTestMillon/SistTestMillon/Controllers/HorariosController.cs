using EFRepository;
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
    public class HorariosController : Controller
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
                objProduct = repository.FindEntitySet<Citas>(c => true && (c.DniPsicologo.Contains(valSearch))).OrderBy(c => c.DniPaciente).ToList();

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


        public ActionResult GetHorarios()
        {
            IRepository repository = new Model.Repository();
            var events = repository.FindEntitySet<Horarios>(c => true).ToList();

            return Json(events.AsEnumerable().Select(e =>new
            {
                Id = e.Id.ToString(),
                title = e.Descripcion,
                start = e.FechaInicio.Value.ToString("yyyy-MM-ddTHH:mm"),
                end = e.FechaFinal.Value.ToString("yyyy-MM-ddTHH:mm"),
                dniPsicologo = e.DniPsicologo.ToString(),
                Psicologo = nombres_Psicologo(e.DniPsicologo)


            }).ToList(), JsonRequestBehavior.AllowGet);



        }




        public static string nombres(string dni)
        {
            IRepository repository = new Model.Repository();
            var nombres = repository.FindEntity<Pacientes>(c => c.Dni == dni).Nombres;
            var apellidoPaterno = repository.FindEntity<Pacientes>(c => c.Dni == dni).ApellidoPaterno;
            var apellidoMaterno = repository.FindEntity<Pacientes>(c => c.Dni == dni).ApellidoMaterno;

            return nombres + " " + apellidoPaterno + " " + apellidoMaterno;
        }

        public static string nombres_Psicologo(string dni)
        {
            IRepository repository = new Model.Repository();
            var nombres = repository.FindEntity<Psicologos>(c => c.Dni == dni).Nombres;
            var apellidoPaterno = repository.FindEntity<Psicologos>(c => c.Dni == dni).ApellidoPaterno;
            var apellidoMaterno = repository.FindEntity<Psicologos>(c => c.Dni == dni).ApellidoMaterno;

            return nombres + " " + apellidoPaterno + " " + apellidoMaterno;
        }


        [HttpPost]
        public JsonResult Pacientes_Nombres(string id)
        {
            IRepository repository = new Model.Repository();

            var events2 = repository.FindEntity<Citas>(c => c.IdCita == Convert.ToInt32(id)).DniPaciente;
            var objProduct2 = repository.FindEntity<Pacientes>(c => c.Dni == events2).Nombres;

            return new JsonResult { Data = objProduct2, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }

        [HttpPost]
        public JsonResult SaveEvent(Horarios e)
        {
            var status = true;
            IRepository repository = new Model.Repository();
            var objUsuNew = new Horarios();
            
            if (e.Id > 0)
            {

                var v = repository.FindEntity<Horarios>(c => c.Id == e.Id);
                status = false;
                if (v != null)
                {
                    v.DniPsicologo = e.DniPsicologo;
                    v.Descripcion = e.Descripcion;
                    v.FechaInicio = e.FechaInicio;
                    v.FechaFinal = e.FechaFinal;

                }
                repository.Update(v);

                return new JsonResult { Data = new { status = status, v = v} };

            }
            else
            {

                objUsuNew = repository.Create(new Horarios
                {
                    DniPsicologo = e.DniPsicologo,
                    FechaInicio = e.FechaInicio,
                    FechaFinal = e.FechaFinal,
                    Descripcion = e.Descripcion
            });

                return new JsonResult { Data = new { status = status, objUsuNew = objUsuNew} };
            }




        }

        [HttpPost]
        public JsonResult DeleEvent(int EventId)
        {
            var status = false;
            using (Entidades dc = new Entidades())
            {

                var v = dc.Horarios.Where(a => a.Id == EventId).FirstOrDefault();

                if (v != null)
                {
                    dc.Horarios.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }

            return new JsonResult { Data = new { status = status } };

        }


    }
}