using Model;
using PagedList;
using Repository;
using SistTestMillon.Helpers;
using SistTestMillon.Models;
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
                objProduct = repository.FindEntitySet<Pacientes>(c => true && (c.ApellidoPaterno.Contains(valSearch) || c.ApellidoMaterno.Contains(valSearch))).OrderBy(c => c.Dni).ToList();

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

        [HttpPost]
        public ActionResult BuscarPacientes(string consulta, int? page=null)
        {
            ViewBag.Buscar = consulta;
            IRepository repository = new Model.Repository();
            List<Pacientes> objProduct = new List<Pacientes>();
            if (string.IsNullOrEmpty(consulta))
                objProduct = repository.FindEntitySet<Pacientes>(c => true).OrderBy(c => c.IdPaciente).ToList();
            else
                objProduct = repository.FindEntitySet<Pacientes>(c => true && (c.ApellidoPaterno.Contains(consulta) || c.ApellidoMaterno.Contains(consulta))).OrderBy(c => c.Dni).ToList();


            int pageSize = 5;
            int pageNumber = page ?? 1;


            return View(objProduct.ToPagedList(pageNumber, pageSize));
        }


        [HttpPost]
        public ActionResult Add(Paciente paciente,Usuario usuario)
        {
            IRepository repository = new Model.Repository();
            int id = 0;
            string strMensaje = "No se pudo actualizar la información, intentelo más tarde";
            bool okResult = false;
            if (paciente.IdPaciente > 0)
            {
                id = paciente.IdPaciente;
                Pacientes UpdatePaciente = repository.FindEntity<Pacientes>(c => c.IdPaciente ==paciente.IdPaciente);
                if (UpdatePaciente != null)
                {
                    Paciente actualizar = new Paciente();
                    strMensaje = actualizar.actualizar(usuario,paciente);
                    okResult = true;

                }
            }
            else
            {
                id = paciente.IdPaciente;                
                Paciente actualizar = new Paciente();
                okResult = true;
                strMensaje = actualizar.crear(usuario, paciente);

            }
            return Json(new Response { IsSuccess = okResult, Message = strMensaje, Id = id }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Get(int Id)
        {
            string strMensaje = "No se encontro el paciente que desea editar";
            IRepository repository = new Model.Repository();
            var paciente = repository.FindEntity<Pacientes>(c => c.IdPaciente == Id);
            var objUsuario = repository.FindEntity<Usuarios>(c => c.IdUsuario ==paciente.IdUsuario);
            if (objUsuario != null)
            {

                Paciente actualizar = new Paciente();
                var lista = actualizar.Obtener(paciente, objUsuario);
                return Json(new Response { IsSuccess = true, Id = Id, Result = lista.ElementAt(0), Result2 = lista.ElementAt(2), Result3 = lista.ElementAt(1).ToString() }, JsonRequestBehavior.AllowGet);

            }
            return Json(new Response { IsSuccess = false, Message = strMensaje, Id = Id }, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public ActionResult Eliminar(int Id)
        {
            string strMensaje = "No se encontro el paciente que desea eliminar";
            bool okResult = false;
            IRepository repository = new Model.Repository();
            var objProd = repository.FindEntity<Pacientes>(c => c.IdPaciente == Id);
            var objUsu = repository.FindEntity<Usuarios>(c => c.IdUsuario == objProd.IdUsuario);
            if (objProd != null)
            {
                repository.Delete(objProd);
                repository.Delete(objUsu);
                strMensaje = "Se elimino el paciente correctamente";
                okResult = true;
            }
            return Json(new Response { IsSuccess = okResult, Message = strMensaje, Id = Id }, JsonRequestBehavior.AllowGet);
        }


    }
}