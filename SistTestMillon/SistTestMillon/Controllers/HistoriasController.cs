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
    public class HistoriasController : Controller
    {
        // GET: Historias
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListaHistorias(string val, string valSearch, int? page)
        {
            ViewBag.CurrentSort = val;
            ViewBag.Buscar = valSearch;
            IRepository repository = new Model.Repository();
            List<Historias> objProduct = new List<Historias>();
            if (string.IsNullOrEmpty(valSearch))
                objProduct = repository.FindEntitySet<Historias>(c =>true).OrderBy(c => c.IdHistoria).ToList();
            else
                objProduct = repository.FindEntitySet<Historias>(c =>true && (c.Observacion.Contains(valSearch) || c.Codigo.Contains(valSearch))).OrderBy(c => c.IdHistoria).ToList();

            if (val == "IdHistoria" || string.IsNullOrEmpty(val))
            {
                val = "IdHistoria";
                objProduct = objProduct.OrderBy(c => c.IdHistoria).ToList();
            }

            ViewBag.Order = val;
            int pageSize = 5;
            int pageNumber = page ?? 1;


            return PartialView(objProduct.ToPagedList(pageNumber, pageSize));
        }

        [HttpPost]
        public ActionResult Add(Historia objProd)
        {
            IRepository repository = new Model.Repository();
            int id = 0;
            string strMensaje = "No se pudo actualizar la información, intentelo más tarde";
            bool okResult = false;
            if (objProd.IdHistoria > 0)
            {
                id = objProd.IdHistoria;
                Historias objUpdateProd = repository.FindEntity<Historias>(c => c.IdHistoria == objProd.IdHistoria);
                if (objUpdateProd != null)
                {
                    //objUpdateProd.Codigo = objProd.Codigo;
                    objUpdateProd.Motivo = objProd.Motivo;
                    objUpdateProd.Observacion = objProd.Observacion;
                    objUpdateProd.CodigoDiagnostico= objProd.CodigoDiagnostico;
                    objUpdateProd.Fecha = objProd.Fecha;
                    objUpdateProd.DniPsicologo = objProd.DniPsicologo;
                    objUpdateProd.Tratamiento = objProd.Tratamiento;
                }
                //Productos objUpdateProd = (Productos)objProd;
                repository.Update(objUpdateProd);
                strMensaje = "Se actualizo el producto";
                okResult = true;
            }
            else
            {

                string coder = PatronClinicoHelper.aletorio();
                var objResultado = repository.Create(new Historias
                {
                    Codigo =coder,
                    CodigoDiagnostico = objProd.CodigoDiagnostico,
                    Motivo= objProd.Motivo,
                    Tratamiento=objProd.Tratamiento,
                    Fecha=DateTime.Now,
                    DniPsicologo=objProd.DniPsicologo,
                    Observacion=objProd.Observacion
                    
                   

                });
                id = objResultado.IdHistoria;
                if (objResultado != null)
                {
                    okResult = true;
                    strMensaje = "Se agrego el producto correctamente";
                    
                }

            }
            return Json(new Response { IsSuccess = okResult, Message = strMensaje, Id = id }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]

        public ActionResult Get(int Id)
        {
            string strMensaje = "No se encontro el producto que desea editar";
            IRepository repository = new Model.Repository();
            var objProd = repository.FindEntity<Historias>(c => c.IdHistoria == Id);
            if (objProd != null)
            {
                Historia historia = new Historia
                {
                    IdHistoria=objProd.IdHistoria,
                    CodigoDiagnostico = objProd.CodigoDiagnostico,
                    Motivo = objProd.Motivo,
                    Tratamiento = objProd.Tratamiento,
                    Fecha = objProd.Fecha,
                    DniPsicologo = objProd.DniPsicologo,
                    Observacion = objProd.Observacion
                };

                return Json(new Response { IsSuccess = true, Id = Id, Result =historia}, JsonRequestBehavior.AllowGet);
            }
            return Json(new Response { IsSuccess = false, Message = strMensaje, Id = Id }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Eliminar(int Id)
        {
            string strMensaje = "No se encontro el producto que desea eliminar";
            bool okResult = false;
            IRepository repository = new Model.Repository();
            var objProd = repository.FindEntity<Historias>(c => c.IdHistoria == Id);
            if (objProd != null)
            {
                repository.Delete(objProd);
                strMensaje = "Se elimino el producto correctamente";
                okResult = true;
            }
            return Json(new Response { IsSuccess = okResult, Message = strMensaje, Id = Id }, JsonRequestBehavior.AllowGet);
        }

    }
}