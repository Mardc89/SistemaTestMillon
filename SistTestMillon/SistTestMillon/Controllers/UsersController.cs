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
    public class UsersController : Controller
    {
        // GET: Users

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Usuario usuario, Paciente paciente,Psicologo psicologo,Administrador admin)
        {
            IRepository repository = new Model.Repository();
            int id = 0;
            string strMensaje = "No se pudo actualizar la información, intentelo más tarde";
            bool okResult = false;
            if (usuario.IdUsuario > 0)
            {
                id = usuario.IdUsuario;
                Usuarios UpdatePaciente = repository.FindEntity<Usuarios>(c => c.IdUsuario == usuario.IdUsuario);
                var Tipo = repository.FindEntity<Usuarios>(c => c.IdUsuario == usuario.IdUsuario).TipoUsuario;
                if (Tipo == "Paciente")
                {
                    Paciente actualizar = new Paciente();                  
                    strMensaje = actualizar.actualizar(usuario, paciente);
                    okResult = true;

                }
                else if (Tipo == "Psicologo")
                {
                    Psicologo actualizar = new Psicologo();                    
                    strMensaje = actualizar.actualizar(usuario, psicologo);
                    okResult = true;
                }
                else if(Tipo == "Administrador") {
                    Administrador actualizar = new Administrador();
                    strMensaje = actualizar.Actualizar(usuario, admin);
                    okResult = true;
                }


            }
            else
            {


                if (usuario.TipoUsuario == "Paciente") {
                    id = paciente.IdPaciente;
                    Paciente actualizar = new Paciente();
                    okResult = true;
                    strMensaje = actualizar.crear(usuario, paciente);
                }

                else if (usuario.TipoUsuario == "Psicologo")
                {
                    id = psicologo.IdPsicologo;
                    Psicologo actualizar = new Psicologo();                    
                    okResult = true;
                    strMensaje = actualizar.crear(usuario, psicologo);

                }

                else if (usuario.TipoUsuario == "Administrador")
                {
                    id = admin.IdAdministrador;
                    Administrador actualizar = new Administrador();                  
                    okResult = true;
                    strMensaje = actualizar.crear(usuario, admin);



                }




            }
            return Json(new Response { IsSuccess = okResult, Message = strMensaje, Id = id }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Get(int Id)
        {
            string strMensaje = "No se encontro el usuario que desea editar";
            IRepository repository = new Model.Repository();
            var objUsuario = repository.FindEntity<Usuarios>(c => c.IdUsuario ==Id);
            if (objUsuario != null)
            {

                if (objUsuario.TipoUsuario == "Paciente")
                {                   
                   
                    var objPaciente = repository.FindEntity<Pacientes>(c => c.IdUsuario ==objUsuario.IdUsuario);
                    Paciente actualizar = new Paciente();
                    var lista = actualizar.Obtener(objPaciente, objUsuario);

                    return Json(new Response { IsSuccess = true, Id = Id, Result = lista.ElementAt(0), Result2 = lista.ElementAt(2), Result3 = lista.ElementAt(1).ToString() }, JsonRequestBehavior.AllowGet);

                }

                else if (objUsuario.TipoUsuario == "Administrador")
                {
                    var admin = repository.FindEntity<Administradores>(c => c.IdUsuario == objUsuario.IdUsuario);
                    Administrador actualizar = new Administrador();
                    var lista = actualizar.Obtener(admin, objUsuario);

                    return Json(new Response { IsSuccess = true, Id = Id, Result = lista.ElementAt(0), Result2 = lista.ElementAt(2), Result3 = lista.ElementAt(1).ToString() }, JsonRequestBehavior.AllowGet);

                }

                else if (objUsuario.TipoUsuario == "Psicologo")
                {

                     var psicologo = repository.FindEntity<Psicologos>(c => c.IdUsuario == objUsuario.IdUsuario);
                     Psicologo actualizar = new Psicologo();
                     var lista = actualizar.Obtener(psicologo, objUsuario);

                     return Json(new Response { IsSuccess = true, Id = Id, Result = lista.ElementAt(0), Result2 = lista.ElementAt(2), Result3 = lista.ElementAt(1).ToString() }, JsonRequestBehavior.AllowGet);

                }





            }
            return Json(new Response { IsSuccess = false, Message = strMensaje, Id = Id }, JsonRequestBehavior.AllowGet);
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

        [HttpPost]
        public ActionResult Eliminar(int Id)
        {
            string strMensaje = "No se encontro el usuario que desea eliminar";
            bool okResult = false;
            IRepository repository = new Model.Repository();
            var objUsu = repository.FindEntity<Usuarios>(c => c.IdUsuario ==Id);
            if (objUsu != null)
            {
                if (objUsu.TipoUsuario=="Paciente")
                {
                    var objProd = repository.FindEntity<Pacientes>(c => c.IdUsuario == Id);
                    var objUsu2 = repository.FindEntity<Usuarios>(c => c.IdUsuario == objProd.IdUsuario);
                    repository.Delete(objProd);
                    repository.Delete(objUsu2);
                    strMensaje = "Se elimino el usuario correctamente";
                    okResult = true;
                }
                else if (objUsu.TipoUsuario == "Psicologo") {
                    var objProd = repository.FindEntity<Psicologos>(c => c.IdUsuario == Id);
                    var objUsu2 = repository.FindEntity<Usuarios>(c => c.IdUsuario == objProd.IdUsuario);
                    repository.Delete(objProd);
                    repository.Delete(objUsu2);
                    strMensaje = "Se elimino el usuario correctamente";
                    okResult = true;

                }

                else if (objUsu.TipoUsuario == "Administrador")
                {
                    var objProd = repository.FindEntity<Administradores>(c => c.IdUsuario == Id);
                    var objUsu2 = repository.FindEntity<Usuarios>(c => c.IdUsuario == objProd.IdUsuario);
                    repository.Delete(objProd);
                    repository.Delete(objUsu2);
                    strMensaje = "Se elimino el usuario correctamente";
                    okResult = true;

                }
            }
            return Json(new Response { IsSuccess = okResult, Message = strMensaje, Id = Id }, JsonRequestBehavior.AllowGet);
        }
    }
}