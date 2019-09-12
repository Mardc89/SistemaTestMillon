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
    public class AdministradoresController : Controller
    {
        // GET: Administradores
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListaAdministradores(string val, string valSearch, int? page)
        {
            ViewBag.CurrentSort = val;
            ViewBag.Buscar = valSearch;
            IRepository repository = new Model.Repository();
            List<Administradores> objProduct = new List<Administradores>();
            if (string.IsNullOrEmpty(valSearch))
                objProduct = repository.FindEntitySet<Administradores>(c => true).OrderBy(c => c.IdAdministrador).ToList();
            else
                objProduct = repository.FindEntitySet<Administradores>(c => true && (c.Nombres.Contains(valSearch) || c.Direccion.Contains(valSearch))).OrderBy(c => c.ApellidoPaterno).ToList();

            if (val == "IdAdministrador" || string.IsNullOrEmpty(val))
            {
                val = "IdAdministrador";
                objProduct = objProduct.OrderBy(c => c.IdAdministrador).ToList();
            }

            ViewBag.Order = val;
            int pageSize = 5;
            int pageNumber = page ?? 1;


            return PartialView(objProduct.ToPagedList(pageNumber, pageSize));
        }

        [HttpPost]
        public ActionResult Add(Usuario usuario, Administrador admin)
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

                var Tipo = UpdatePaciente.TipoUsuario;
                if (Tipo == "Administrador")
                {
                    Administrador actualizar = new Administrador();
                    actualizar.insertar(usuario, admin);
                    repository.Update(UpdatePaciente);
                    strMensaje = "Se actualizo el producto";
                    okResult = true;

                }



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


                if (Tipo == "Administrador")
                {
                    id = admin.IdAdministrador;
                    Administrador actualizar = new Administrador();
                    actualizar.crear(usuario, admin);
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
            var objUsuario = repository.FindEntity<Usuarios>(c => c.IdUsuario == Id);
            if (objUsuario != null)
            {

                if (objUsuario.TipoUsuario == "Administrador")
                {
                    var admin = repository.FindEntity<Administradores>(c => c.IdUsuario == Id);
                    objUsuario = repository.FindEntity<Usuarios>(c => c.IdUsuario == admin.IdUsuario);
                    Administrador actualizar = new Administrador();
                    var lista = actualizar.Obtener(admin, objUsuario);

                    return Json(new Response { IsSuccess = true, Id = Id, Result = lista.ElementAt(0), Result2 = lista.ElementAt(2), Result3 = lista.ElementAt(1).ToString() }, JsonRequestBehavior.AllowGet);

                }

            }
            return Json(new Response { IsSuccess = false, Message = strMensaje, Id = Id }, JsonRequestBehavior.AllowGet);
        }

    }
}