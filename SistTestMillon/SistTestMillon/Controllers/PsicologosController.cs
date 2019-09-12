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
                string strPass = CryproHelper.ComputeHash(usuario.Contraseña, CryproHelper.Supported_HA.SHA512, null);
                if (UpdatePaciente != null)
                {
                    UpdatePaciente.TipoUsuario = usuario.TipoUsuario;
                    UpdatePaciente.NombreUsuario = usuario.NombreUsuario;
                    UpdatePaciente.Contraseña = strPass;

                }

                var Tipo = UpdatePaciente.TipoUsuario;

                if (Tipo == "Psicologo")
                {
                    Psicologo actualizar = new Psicologo();
                    actualizar.insertar(usuario, psicologo);
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


                if (Tipo == "Psicologo")
                {
                    id = psicologo.IdPsicologo;
                    Psicologo actualizar = new Psicologo();
                    actualizar.crear(usuario, psicologo);
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
            var objPaciente = repository.FindEntity<Psicologos>(c => c.IdPsicologo == Id);
            var objUsuario = repository.FindEntity<Usuarios>(c => c.IdUsuario == objPaciente.IdUsuario);
            if (objPaciente != null)
            {
                Psicologo Psicolog = new Psicologo
                {
                    IdPsicologo = objPaciente.IdPsicologo,
                    Dni = objPaciente.Dni,
                    Nombres = objPaciente.Nombres,
                    ApellidoPaterno = objPaciente.ApellidoPaterno,
                    ApellidoMaterno = objPaciente.ApellidoMaterno,
                    Direccion = objPaciente.Direccion,
                    Edad = objPaciente.Edad,
                    Sexo = objPaciente.Sexo,
                    Profesion = objPaciente.Profesion,
                    FechaNacimiento = objPaciente.FechaNacimiento,
                    Telefono = objPaciente.Telefono,
                    Correo = objPaciente.Correo,
                };

                var fecha = Psicolog.FechaNacimiento;
                Usuario usuario = new Usuario
                {
                    NombreUsuario = objUsuario.NombreUsuario,
                    Contraseña = objUsuario.Contraseña,
                    TipoUsuario = objUsuario.TipoUsuario

                };

                return Json(new Response { IsSuccess = true, Id = Id, Result = Psicolog, Result2 = usuario, Result3 = fecha.Value.ToString("dd/MM/yyyy") }, JsonRequestBehavior.AllowGet);
            }
            return Json(new Response { IsSuccess = false, Message = strMensaje, Id = Id }, JsonRequestBehavior.AllowGet);
        }
    }
}