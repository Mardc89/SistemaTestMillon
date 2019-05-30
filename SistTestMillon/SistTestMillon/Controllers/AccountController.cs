﻿using Model;
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
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string Usuario, string password, bool? recordar)
        {
            IRepository repository = new Model.Repository();
            var objUsu = repository.FindEntity<Usuarios>(c => c.NombreUsuario==Usuario);
            var UsuID = repository.FindEntity<Usuarios>(c => c.NombreUsuario == Usuario).IdUsuario;
            var UsuIDPaciente = repository.FindEntity<Pacientes>(c => c.IdUsuario ==UsuID);
            var Nombre = repository.FindEntity<Usuarios>(c => c.NombreUsuario == Usuario).NombreUsuario;
            var TipoUsuario = repository.FindEntity<Usuarios>(c => c.NombreUsuario == Usuario).TipoUsuario;
            int id = 0;
            string strMensaje = "El usuario y/o contraseña son incorrectos.";
            recordar = recordar == null ? false : true;
            if (objUsu != null)
            {
                if (TipoUsuario == "Psicologo") {
                    if (CryproHelper.Confirm(password, objUsu.Contraseña, CryproHelper.Supported_HA.SHA512))
                    {
                        id = -1;
                        SessionHelper.AddUserToSession(objUsu.IdUsuario.ToString(), (bool)recordar);
                        SessionHelper.ActualizarSession(objUsu);
                        if (objUsu.IdUsuario == UsuID)
                        {
                            strMensaje = Url.Content("~/Home");
                            
                        }
                    }
                }

                if (TipoUsuario == "Paciente")
                {
                    if (CryproHelper.Confirm(password, objUsu.Contraseña, CryproHelper.Supported_HA.SHA512))
                    {
                        id = -1;
                        SessionHelper.AddUserToSession(objUsu.IdUsuario.ToString(), (bool)recordar);
                        SessionHelper.ActualizarSessionPacienteUser(objUsu,UsuIDPaciente);
                        if (objUsu.IdUsuario == UsuID)
                        {
                            strMensaje = Url.Content("~/Home");

                        }
                    }
                }

                if (TipoUsuario=="administrador")
                {
                    id = -1;
                    SessionHelper.AddUserToSession(objUsu.IdUsuario.ToString(), (bool)recordar);
                    SessionHelper.ActualizarSession(objUsu);
                    if (objUsu.IdUsuario == UsuID)
                    {
                        strMensaje = Url.Content("~/Home");
                        
                    }
                }


            }
            return Json(new Response { IsSuccess = true, Message = strMensaje, Id = id }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Registrarme()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registrarme(string Dni, string Nombres, string APaterno,string AMaterno,string Direccion,int edad,string sexo,string Profesion,string fecha,string correo,string telefono,string contraseña,string NombreUsu,string TipoUsu)
        {
            IRepository repository = new Model.Repository();
            var objUsuNom = repository.FindEntity<Usuarios>(c => c.NombreUsuario ==NombreUsu);
            string strMensaje = "";
            int id = 0;
            if (objUsuNom!=null)
            {
                strMensaje = "El usuario ya existe en nuestra base de datos, intente recuperar su cuenta para cambiar su contraseña.";
            }
            else
            {
                string strPass = CryproHelper.ComputeHash(contraseña, CryproHelper.Supported_HA.SHA512, null);
                var objUsuarios = repository.Create(new Usuarios
                {
                    TipoUsuario = TipoUsu,
                    NombreUsuario = NombreUsu,
                    Contraseña = strPass

                });
                var objUsuID = repository.FindEntity<Usuarios>(c => c.NombreUsuario==NombreUsu).IdUsuario;
                var objUsuNew = new Pacientes();
                var objUsuPsicolog = new Psicologos();
                if (objUsuarios != null)
                {
                    if (TipoUsu == "Paciente")
                    {
                        objUsuNew = repository.Create(new Pacientes
                        {
                            DniPaciente = Dni,
                            Nombres = Nombres,
                            ApellidoPaterno = APaterno,
                            ApellidoMaterno = AMaterno,
                            Direccion = Direccion,
                            Edad = edad,
                            Sexo = sexo,
                            Profesion = Profesion,
                            FechaNacimiento = Convert.ToDateTime(fecha),
                            Telefono = telefono,
                            Correo = correo,
                            IdUsuario = objUsuID

                        });
                    }

                    if (TipoUsu=="Psicologo") {
                        objUsuPsicolog = repository.Create(new Psicologos
                        {
                            DniPsicologo = Dni,
                            Nombres = Nombres,
                            ApellidoPaterno = APaterno,
                            ApellidoMaterno = AMaterno,
                            Direccion = Direccion,
                            Edad = edad,
                            Sexo = sexo,
                            Profesion = Profesion,
                            FechaNacimiento = Convert.ToDateTime(fecha),
                            Telefono = telefono,
                            Correo = correo,
                            IdUsuario = objUsuID

                        });
                    }



                    if (objUsuNew != null || objUsuPsicolog !=null)
                    {
                        var baseAddress = new Uri(ToolsHelper.UrlOriginal(Request));
                        string Mensaje = "Gracias por inscribirse al sistema de Psicologia, puede entrar con el usuario " +
                            "y contraseña registrada. <a href='" + baseAddress + "'>INVENTARIOS</a>";
                        ToolsHelper.SendMail(correo, "Gracias por registrarte a INVENTARIOS", Mensaje);
                        strMensaje = "Te registraste correctamente, ya puedes entrar al sistema.";
                        
                        if (TipoUsu == "Paciente")
                        {
                            ViewBag.DniPaciente = Dni;
                            //strMensaje = Url.Action("Index", "TestMillon");
                            //return Json(new Response { IsSuccess = true, Message = strMensaje, Id = -1 }, JsonRequestBehavior.AllowGet);
                            return RedirectToAction("Index","TestMillon");
                            
                        }
                        else {
                            strMensaje = Url.Action("Index", "Home");
                            return Json(new Response { IsSuccess = true, Message = strMensaje, Id = -1 }, JsonRequestBehavior.AllowGet);

                        }


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

        public ActionResult RecuperarCuenta()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RecuperarCuenta(string CorreoElectronico)
        {
            IRepository repository = new Model.Repository();
            var objUsu = repository.FindEntity<Pacientes>(c => c.Correo == CorreoElectronico);
            int id = 0;
            string strMensaje = "El correo no se encuentra registrado.";
            if (objUsu != null)
            {
                string strToken = objUsu.IdPaciente.ToString() + objUsu.Correo;
                string strTknAjax = CryproHelper.ComputeHash(strToken, CryproHelper.Supported_HA.SHA512, null);
                objUsu.Token = Server.UrlEncode(strTknAjax);
                repository.Update(objUsu);
                var baseAddress = ToolsHelper.UrlOriginal(Request) + "/Account/ResetPass/?tkn=" + objUsu.Token;
                string Mensaje = "Para restaurar tu cuenta de INVENTARIOS, entra a la siguiente liga y crea una nueva contraseña. <br/><br/> <a href='" + baseAddress + "'>INVENTARIOS recuperar cuenta</a>";
                ToolsHelper.SendMail(CorreoElectronico, "Recuperar cuenta de INVENTARIOS", Mensaje);
                strMensaje = "Se envío un correo con la información requerida para recuperar su cuenta.";
            }
            return Json(new Response { IsSuccess = true, Message = strMensaje, Id = id }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult ResetPass(string tkn)
        {
            if (!string.IsNullOrEmpty(tkn))
            {
                IRepository repository = new Model.Repository();
                tkn = Server.UrlEncode(tkn);
                ViewBag.tkn = tkn;
                var objUsu = repository.FindEntity<Pacientes>(c => c.Token == tkn);
                if (objUsu != null)
                {
                    return View();
                }
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult ResetPass(string Password, string tkn)
        {
            IRepository repository = new Model.Repository();
            var objUsu = repository.FindEntity<Pacientes>(c => c.Token == tkn);
            var objUsub = repository.FindEntity<Pacientes>(c => c.Token == tkn).IdUsuario;
            var objUsuc = repository.FindEntity<Usuarios>(c => c.IdUsuario == objUsub);
            string strMensaje = "";
            int id = 0;
            if (objUsu != null)
            {
                string strPass = CryproHelper.ComputeHash(Password, CryproHelper.Supported_HA.SHA512, null);
                objUsuc.Contraseña = strPass;
                objUsu.Token = "";
                repository.Update(objUsu);
                strMensaje = "Se actualizó la contraseña correctamente, ya puede entrar al sistema INVENTARIOS.";
            }
            else
            {
                strMensaje = "El token se encuentra vencido, necesita recuperar nuevamente su cuenta.";
            }
            return Json(new Response { IsSuccess = true, Message = strMensaje, Id = id }, JsonRequestBehavior.AllowGet);
        }

    }
}
