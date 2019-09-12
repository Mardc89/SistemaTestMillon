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
        public ActionResult Add(Paciente paciente,Usuario usuario)
        {
            IRepository repository = new Model.Repository();
            int id = 0;
            string strMensaje = "No se pudo actualizar la información, intentelo más tarde";
            bool okResult = false;
            if (paciente.IdPaciente > 0)
            {
                id = paciente.IdPaciente;
                Pacientes UpdatePaciente = repository.FindEntity<Pacientes>(c => c.IdPaciente == paciente.IdPaciente);
                if (UpdatePaciente != null)
                {
                    //objUpdateProd.Codigo = objProd.Codigo;
                    UpdatePaciente.Dni = paciente.Dni;
                    UpdatePaciente.Nombres = paciente.Nombres;
                    UpdatePaciente.ApellidoPaterno = paciente.ApellidoPaterno;
                    UpdatePaciente.ApellidoMaterno = paciente.ApellidoMaterno;
                    UpdatePaciente.Direccion = paciente.Direccion;
                    UpdatePaciente.Edad = paciente.Edad;
                    UpdatePaciente.Sexo = paciente.Sexo;
                    UpdatePaciente.Profesion = paciente.Profesion;
                    UpdatePaciente.FechaNacimiento = Convert.ToDateTime(paciente.FechaNacimiento);
                    UpdatePaciente.Telefono = paciente.Telefono;
                    UpdatePaciente.Correo = paciente.Correo;

                }
                
                Usuarios objUsuID = repository.FindEntity<Usuarios>(c => c.IdUsuario == UpdatePaciente.IdUsuario);
                string strPass = CryproHelper.ComputeHash(usuario.Contraseña, CryproHelper.Supported_HA.SHA512, null);
                if (objUsuID != null)
                {
                    objUsuID.NombreUsuario =usuario.NombreUsuario;
                    objUsuID.Contraseña = strPass;

                }
                repository.Update(UpdatePaciente);
                repository.Update(objUsuID);
                //Productos objUpdateProd = (Productos)objProd;

                strMensaje = "Se actualizo el producto";
                okResult = true;
            }
            else
            {

                
                string strPass = CryproHelper.ComputeHash(usuario.Contraseña, CryproHelper.Supported_HA.SHA512, null);
                var objUsuarios = repository.Create(new Usuarios
                {
                    TipoUsuario ="Paciente",
                    NombreUsuario =usuario.NombreUsuario,
                    Contraseña = strPass

                });
                var objUsuID = repository.FindEntity<Usuarios>(c => c.NombreUsuario ==usuario.NombreUsuario).IdUsuario;
                var objUsuNew = repository.Create(new Pacientes
                {
                    Dni = paciente.Dni,
                    Nombres = paciente.Nombres,
                    ApellidoPaterno = paciente.ApellidoPaterno,
                    ApellidoMaterno = paciente.ApellidoMaterno,
                    Direccion = paciente.Direccion,
                    Edad = paciente.Edad,
                    Sexo = paciente.Sexo,
                    Profesion = paciente.Profesion,
                    FechaNacimiento = Convert.ToDateTime(paciente.FechaNacimiento),
                    Telefono = paciente.Telefono,
                    Correo = paciente.Correo,
                    IdUsuario = objUsuID
                });

                id = paciente.IdPaciente;
                if (objUsuNew != null)
                {
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
            var objPaciente = repository.FindEntity<Pacientes>(c => c.IdPaciente == Id);
            var objUsuario = repository.FindEntity<Usuarios>(c => c.IdUsuario ==objPaciente.IdUsuario);
            if (objPaciente != null)
            {
                Paciente Paciente = new Paciente
                {
                    IdPaciente= objPaciente.IdPaciente,
                    Dni = objPaciente.Dni,
                    Nombres = objPaciente.Nombres,
                    ApellidoPaterno = objPaciente.ApellidoPaterno,
                    ApellidoMaterno = objPaciente.ApellidoMaterno,
                    Direccion = objPaciente.Direccion,
                    Edad = objPaciente.Edad,
                    Sexo = objPaciente.Sexo,
                    Profesion = objPaciente.Profesion,
                    FechaNacimiento =objPaciente.FechaNacimiento,
                    Telefono = objPaciente.Telefono,
                    Correo = objPaciente.Correo,
                };

                var fecha = Paciente.FechaNacimiento.ToString("dd/MM/yyyy");
                Usuario usuario = new Usuario
                {
                    NombreUsuario= objUsuario.NombreUsuario,
                    Contraseña=objUsuario.Contraseña

                };

                return Json(new Response { IsSuccess = true, Id = Id, Result = Paciente,Result2=usuario,Result3=fecha}, JsonRequestBehavior.AllowGet);
            }
            return Json(new Response { IsSuccess = false, Message = strMensaje, Id = Id }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Registrarme(Paciente paciente)
        {
            IRepository repository = new Model.Repository();
            var objUsuNom = repository.FindEntity<Usuarios>(c => c.NombreUsuario ==paciente.Usuarios.NombreUsuario);
            string strMensaje = "";
            int id = 0;
            if (objUsuNom != null)
            {
                strMensaje = "El usuario ya existe en nuestra base de datos, intente recuperar su cuenta para cambiar su contraseña.";
            }
            else
            {
                string strPass = CryproHelper.ComputeHash(paciente.Usuarios.Contraseña, CryproHelper.Supported_HA.SHA512, null);
                var objUsuarios = repository.Create(new Usuarios
                {
                    TipoUsuario =paciente.Usuarios.TipoUsuario,
                    NombreUsuario = paciente.Usuarios.NombreUsuario,
                    Contraseña = strPass

                });
                var objUsuID = repository.FindEntity<Usuarios>(c => c.NombreUsuario == paciente.Usuarios.NombreUsuario).IdUsuario;
                var objUsuNew = new Pacientes();
                var objUsuPsicolog = new Psicologos();
                if (objUsuarios != null)
                {
                    if (paciente.Usuarios.TipoUsuario == "Paciente")
                    {
                        objUsuNew = repository.Create(new Pacientes
                        {
                            Dni = paciente.Dni,
                            Nombres = paciente.Nombres,
                            ApellidoPaterno = paciente.ApellidoPaterno,
                            ApellidoMaterno = paciente.ApellidoMaterno,
                            Direccion = paciente.Direccion,
                            Edad = paciente.Edad,
                            Sexo = paciente.Sexo,
                            Profesion = paciente.Profesion,
                            FechaNacimiento = Convert.ToDateTime(paciente.FechaNacimiento),
                            Telefono = paciente.Telefono,
                            Correo = paciente.Correo,
                            IdUsuario = objUsuID
                        });

                    }





                    if (objUsuNew != null)
                    {
                        var baseAddress = new Uri(ToolsHelper.UrlOriginal(Request));
                        string Mensaje = "Gracias por inscribirse al sistema de Psicologia, puede entrar con el usuario " +
                            "y contraseña registrada. <a href='" + baseAddress + "'>INVENTARIOS</a>";
                        ToolsHelper.SendMail(paciente.Correo, "Gracias por registrarte a INVENTARIOS", Mensaje);
                        strMensaje = "Te registraste correctamente, ya puedes entrar al sistema.";
                        strMensaje = Url.Content("~/Home");
                        return Json(new Models.Response { IsSuccess = true, Message = strMensaje, Id = -1 }, JsonRequestBehavior.AllowGet);

                    }
                    else
                    {
                        strMensaje = "Disculpe las molestias, por el momento no podemos conectarnos con el servidor, intentelo nuevamente.";
                    }
                }
                else
                {
                    strMensaje = "Disculpe las molestias, por el momento no podemos conectarnos con el servidor, intentelo nuevamente.";
                }
            }
            return Json(new Response { IsSuccess = true, Message = strMensaje, Id = id }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Eliminar(int Id)
        {
            string strMensaje = "No se encontro el producto que desea eliminar";
            bool okResult = false;
            IRepository repository = new Model.Repository();
            var objProd = repository.FindEntity<Pacientes>(c => c.IdPaciente == Id);
            var objUsu = repository.FindEntity<Usuarios>(c => c.IdUsuario == objProd.IdUsuario);
            if (objProd != null)
            {
                repository.Delete(objProd);
                repository.Delete(objUsu);
                strMensaje = "Se elimino el producto correctamente";
                okResult = true;
            }
            return Json(new Response { IsSuccess = okResult, Message = strMensaje, Id = Id }, JsonRequestBehavior.AllowGet);
        }


    }
}