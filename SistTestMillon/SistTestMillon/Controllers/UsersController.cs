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
                string strPass = CryproHelper.ComputeHash(usuario.Contraseña, CryproHelper.Supported_HA.SHA512, null);
                if (UpdatePaciente != null)
                {
                    UpdatePaciente.TipoUsuario = usuario.TipoUsuario;
                    UpdatePaciente.NombreUsuario = usuario.NombreUsuario;
                    UpdatePaciente.Contraseña = strPass;

                }

                var Tipo=UpdatePaciente.TipoUsuario;
                if (Tipo == "Paciente")
                {
                    Paciente actualizar = new Paciente();
                    actualizar.actualizar(usuario, paciente);

                }
                else if (Tipo == "Psicologos")
                {
                    Psicologo actualizar = new Psicologo();
                    actualizar.insertar(usuario, psicologo);
                }
                else {
                    Administrador actualizar = new Administrador();
                    actualizar.insertar(usuario, admin);
                }

                repository.Update(UpdatePaciente);
                
                //Productos objUpdateProd = (Productos)objProd;

                strMensaje = "Se actualizo el producto";
                okResult = true;
            }
            else
            {


                string strPass = CryproHelper.ComputeHash(usuario.Contraseña, CryproHelper.Supported_HA.SHA512, null);
                var objUsuarios = repository.Create(new Usuarios
                {
                    TipoUsuario = usuario.TipoUsuario,
                    NombreUsuario = usuario.NombreUsuario,
                    Contraseña = strPass

                });
                var Tipo = usuario.TipoUsuario;


                if (Tipo=="Paciente") {
                id = paciente.IdPaciente;
                    Paciente actualizar = new Paciente();
                    actualizar.crear(usuario, paciente);
                    okResult = true;
                    strMensaje = "Se agrego el producto correctamente";

                

                }

                else if (Tipo == "Psicologo")
                {
                    id = psicologo.IdPsicologo;
                    Psicologo actualizar = new Psicologo();
                    actualizar.crear(usuario, psicologo);
                    okResult = true;
                    strMensaje = "Se agrego el producto correctamente";

                }

                else
                {
                    id = admin.IdAdministrador;
                    Administrador actualizar = new Administrador();
                    actualizar.crear(usuario,admin);
                    okResult = true;
                    strMensaje = "Se agrego el producto correctamente";



                }




            }
            return Json(new Response { IsSuccess = okResult, Message = strMensaje, Id = id }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Get(int Id)
        {
            string strMensaje = "No se encontro el producto que desea editar";
            IRepository repository = new Model.Repository();
            var objUsuario = repository.FindEntity<Usuarios>(c => c.IdUsuario ==Id);
            if (objUsuario != null)
            {

                if (objUsuario.TipoUsuario == "Paciente")
                {
                    var objPaciente = repository.FindEntity<Pacientes>(c => c.IdUsuario == Id);
                    var objUsuario2 = repository.FindEntity<Usuarios>(c => c.IdUsuario == objPaciente.IdUsuario);
                    Paciente actualizar = new Paciente();
                    var lista = actualizar.Obtener(objPaciente, objUsuario2);

                    return Json(new Response { IsSuccess = true, Id = Id, Result = lista.ElementAt(0), Result2 = lista.ElementAt(2), Result3 = lista.ElementAt(1).ToString() }, JsonRequestBehavior.AllowGet);

                }

                else if (objUsuario.TipoUsuario == "Administrador")
                {
                    var admin = repository.FindEntity<Administradores>(c => c.IdUsuario == Id);
                    objUsuario = repository.FindEntity<Usuarios>(c => c.IdUsuario == admin.IdUsuario);
                    Administrador actualizar = new Administrador();
                    var lista = actualizar.Obtener(admin, objUsuario);

                    return Json(new Response { IsSuccess = true, Id = Id, Result = lista.ElementAt(0), Result2 = lista.ElementAt(2), Result3 = lista.ElementAt(1).ToString() }, JsonRequestBehavior.AllowGet);

                }

                else {

                     var psicologo = repository.FindEntity<Psicologos>(c => c.IdUsuario == Id);
                     var objUsuario3 = repository.FindEntity<Usuarios>(c => c.IdUsuario == psicologo.IdUsuario);
                     Psicologo actualizar = new Psicologo();
                     var lista = actualizar.Obtener(psicologo, objUsuario3);

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
            string strMensaje = "No se encontro el producto que desea eliminar";
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
                    strMensaje = "Se elimino el producto correctamente";
                    okResult = true;
                }
                else if (objUsu.TipoUsuario == "Psicologo") {
                    var objProd = repository.FindEntity<Psicologos>(c => c.IdUsuario == Id);
                    var objUsu2 = repository.FindEntity<Usuarios>(c => c.IdUsuario == objProd.IdUsuario);
                    repository.Delete(objProd);
                    repository.Delete(objUsu2);
                    strMensaje = "Se elimino el producto correctamente";
                    okResult = true;

                }

                else {
                    var objProd = repository.FindEntity<Administradores>(c => c.IdUsuario == Id);
                    var objUsu2 = repository.FindEntity<Usuarios>(c => c.IdUsuario == objProd.IdUsuario);
                    repository.Delete(objProd);
                    repository.Delete(objUsu2);
                    strMensaje = "Se elimino el producto correctamente";
                    okResult = true;

                }
            }
            return Json(new Response { IsSuccess = okResult, Message = strMensaje, Id = Id }, JsonRequestBehavior.AllowGet);
        }
    }
}