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
    public class PsicologosController : Controller
    {
        // GET: Psicologos
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListaPsicologos(string val, string valSearch, int? page)
        {
            ViewBag.CurrentSort = val;
            ViewBag.Buscar = valSearch;
            IRepository repository = new Model.Repository();
            List<Psicologos> objProduct = new List<Psicologos>();
            if (string.IsNullOrEmpty(valSearch))
                objProduct = repository.FindEntitySet<Psicologos>(c => true).OrderBy(c => c.IdPsicologo).ToList();
            else
                objProduct = repository.FindEntitySet<Psicologos>(c => true && (c.Nombres.Contains(valSearch) || c.Direccion.Contains(valSearch))).OrderBy(c => c.ApellidoPaterno).ToList();

            if (val == "IdPsicologo" || string.IsNullOrEmpty(val))
            {
                val = "IdPsicologo";
                objProduct = objProduct.OrderBy(c => c.IdPsicologo).ToList();
            }

            ViewBag.Order = val;
            int pageSize = 5;
            int pageNumber = page ?? 1;


            return PartialView(objProduct.ToPagedList(pageNumber, pageSize));
        }

        [HttpPost]
        public ActionResult Add(Usuario usuario,Psicologo psicologo)
        {
            IRepository repository = new Model.Repository();
            int id = 0;
            string strMensaje = "No se pudo actualizar la información, intentelo más tarde";
            bool okResult = false;
            if (usuario.IdUsuario > 0)
            {
                id = usuario.IdUsuario;
                Usuarios UpdatePaciente = repository.FindEntity<Usuarios>(c => c.IdUsuario == usuario.IdUsuario);
                if (UpdatePaciente != null)
                {
                    Psicologo actualizar = new Psicologo();
                    strMensaje =actualizar.actualizar(usuario, psicologo);
                    okResult = true;

                }
            }
            else
            {
                    id = psicologo.IdPsicologo;
                    Psicologo actualizar = new Psicologo();
                    strMensaje = actualizar.crear(usuario, psicologo);
                    okResult = true;
               
            }
            return Json(new Response { IsSuccess = okResult, Message = strMensaje, Id = id }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Get(int Id)
        {
            string strMensaje = "No se encontro el producto que desea editar";
            IRepository repository = new Model.Repository();
            var Psicolog = repository.FindEntity<Psicologos>(c => c.IdPsicologo == Id);
            var objUsuario = repository.FindEntity<Usuarios>(c => c.IdUsuario == Psicolog.IdUsuario);
            if (objUsuario != null)
            {

                Psicologo actualizar = new Psicologo();
                var lista = actualizar.Obtener(Psicolog, objUsuario);
                return Json(new Response { IsSuccess = true, Id = Id, Result = lista.ElementAt(0), Result2 = lista.ElementAt(2), Result3 = lista.ElementAt(1).ToString() }, JsonRequestBehavior.AllowGet);

           }

            
            return Json(new Response { IsSuccess = false, Message = strMensaje, Id = Id }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Eliminar(int Id)
        {
            string strMensaje = "No se encontro el producto que desea eliminar";
            bool okResult = false;
            IRepository repository = new Model.Repository();
            var objProd = repository.FindEntity<Psicologos>(c => c.IdPsicologo == Id);
            if (objProd != null)
            {

                var objUsu2 = repository.FindEntity<Usuarios>(c => c.IdUsuario == objProd.IdUsuario);
                repository.Delete(objProd);
                repository.Delete(objUsu2);
                strMensaje = "Se elimino el producto correctamente";
                okResult = true;


            }
            return Json(new Response { IsSuccess = okResult, Message = strMensaje, Id = Id }, JsonRequestBehavior.AllowGet);
        }
    }
}