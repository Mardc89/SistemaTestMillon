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


        public ActionResult GetEvents()
        {
            IRepository repository = new Model.Repository();
            var events= repository.FindEntitySet<Citas>(c => true).ToList();

            return Json(events.AsEnumerable().Select(e => new
            {
                Id=e.IdCita.ToString(),
                title = nombres(e.DniPaciente),
                start =e.Hora_inicial.Value.ToString("yyyy-MM-ddTHH:mm"),
                end=e.Hora_final.Value.ToString("yyyy-MM-ddTHH:mm"),
                description=e.Descripcion,
                dniPsicologo=e.DniPsicologo.ToString(),
                dniPaciente=e.DniPaciente.ToString(),
                Psicologo= nombres_Psicologo(e.DniPsicologo)
            }).ToList(), JsonRequestBehavior.AllowGet);

            

        }

        public static string nombres(string dni) {
            IRepository repository = new Model.Repository();
            var nombres = repository.FindEntity<Pacientes>(c => c.DniPaciente == dni).Nombres;
            var apellidoPaterno = repository.FindEntity<Pacientes>(c => c.DniPaciente == dni).ApellidoPaterno;
            var apellidoMaterno = repository.FindEntity<Pacientes>(c => c.DniPaciente == dni).ApellidoMaterno;

            return nombres + " " + apellidoPaterno + " " + apellidoMaterno;
        }

        public static string nombres_Psicologo(string dni)
        {
            IRepository repository = new Model.Repository();
            var nombres = repository.FindEntity<Psicologos>(c => c.DniPsicologo ==dni).Nombres;
            var apellidoPaterno = repository.FindEntity<Psicologos>(c => c.DniPsicologo == dni).ApellidoPaterno;
            var apellidoMaterno = repository.FindEntity<Psicologos>(c => c.DniPsicologo == dni).ApellidoMaterno;

            return nombres + " " + apellidoPaterno + " " + apellidoMaterno;
        }


        [HttpPost]
        public JsonResult Pacientes_Nombres(string id)
        {
            IRepository repository = new Model.Repository();

            var events2 = repository.FindEntity<Citas>(c =>c.IdCita==Convert.ToInt32(id)).DniPaciente;
            var objProduct2 = repository.FindEntity<Pacientes>(c => c.DniPaciente == events2).Nombres;

            return new JsonResult { Data = objProduct2, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }

        [HttpPost]
        public JsonResult SaveEvent(Citas e)
        {
            var status = true;
            IRepository repository = new Model.Repository();
            var objUsuNew=new Citas();
            var nombrePaciente = nombres(e.DniPaciente);
            var nombrePsicologo = nombres_Psicologo(e.DniPsicologo);

            if (e.IdCita > 0)
                {
                    
                    var v = repository.FindEntity<Citas>(c => c.IdCita ==e.IdCita);
                    status = false;
                    if (v!=null)
                    {
                        v.DniPaciente = e.DniPaciente;
                        v.DniPsicologo = e.DniPsicologo;
                        v.Descripcion = e.Descripcion;
                        v.Hora_inicial = e.Hora_inicial;
                        v.Hora_final = e.Hora_final;

                    }
                    repository.Update(v);
                    
                return new JsonResult { Data = new { status = status, v=v , nombrePaciente = nombrePaciente, nombrePsicologo= nombrePsicologo } };

            }
                else
                {

                objUsuNew = repository.Create(new Citas
                {
                    DniPaciente = e.DniPaciente,
                    DniPsicologo = e.DniPsicologo,
                    Descripcion = e.Descripcion,
                    Hora_inicial = e.Hora_inicial,
                    Hora_final = e.Hora_final
                });
                
                    return new JsonResult { Data = new { status = status, objUsuNew=objUsuNew, nombrePaciente = nombrePaciente, nombrePsicologo= nombrePsicologo } };
                }
            

           

        }

        [HttpPost]
        public JsonResult DeleEvent(int EventId)
        {
            var status = false;
            using (Entidades dc = new Entidades())
            {

                var v = dc.Citas.Where(a => a.IdCita == EventId).FirstOrDefault();
                
                if (v != null)
                {
                  dc.Citas.Remove(v);
                  dc.SaveChanges();
                  status = true;
                }
            }

            return new JsonResult { Data = new { status = status } };

        }


    }
}