﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace SistTestMillon.Helpers
{
    public class SessionHelper
    {
        public static bool ExistUserInSession()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }
        public static void DestroyUserSession()
        {
            FormsAuthentication.SignOut();
        }
        public static int GetUser()
        {
            int user_id = 0;
            if (HttpContext.Current.User != null && HttpContext.Current.User.Identity is FormsIdentity)
            {
                FormsAuthenticationTicket ticket = ((FormsIdentity)HttpContext.Current.User.Identity).Ticket;
                if (ticket != null)
                {
                    user_id = Convert.ToInt32(ticket.UserData);
                }
            }
            return user_id;
        }

        public static void AddUserToSession(string id, bool persist)
        {
            var cookie = FormsAuthentication.GetAuthCookie("UserInventory", persist);

            cookie.Name = FormsAuthentication.FormsCookieName;
            cookie.Expires = DateTime.Now.AddHours(1);

            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            var newTicket = new FormsAuthenticationTicket(ticket.Version, ticket.Name, ticket.IssueDate, ticket.Expiration, ticket.IsPersistent, id);

            cookie.Value = FormsAuthentication.Encrypt(newTicket);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public static void ActualizarSession(Usuarios Usuario)
        {
            HttpContext.Current.Session["Usuario_Id"] = Usuario.IdUsuario;
            HttpContext.Current.Session["TipoUsuario"] = Usuario.TipoUsuario;
            HttpContext.Current.Session["NombreUsuario"] = Usuario.NombreUsuario;
            HttpContext.Current.Session["Contraseña"] = Usuario.Contraseña;
        }

        public static void ActualizarSessionPacienteUser(Usuarios Usuario,Pacientes Paciente)
        {
            HttpContext.Current.Session["Usuario_Id"] = Usuario.IdUsuario;
            HttpContext.Current.Session["TipoUsuario"] = Usuario.TipoUsuario;
            HttpContext.Current.Session["NombreUsuario"] = Usuario.NombreUsuario;
            HttpContext.Current.Session["Contraseña"] = Usuario.Contraseña;
            HttpContext.Current.Session["Id"] = Paciente.IdPaciente;
            HttpContext.Current.Session["Sexo"] = Paciente.Sexo;
            HttpContext.Current.Session["Dni"] = Paciente.Dni;
            HttpContext.Current.Session["Nombres"] = Paciente.Nombres;
            HttpContext.Current.Session["ApellidoPaterno"] = Paciente.ApellidoPaterno;
            HttpContext.Current.Session["ApellidoMaterno"] = Paciente.ApellidoMaterno;
        }

        public static void ActualizarSessionAdmin(Usuarios Usuario,Administradores admin)
        {
            HttpContext.Current.Session["Usuario_Id"] = Usuario.IdUsuario;
            HttpContext.Current.Session["TipoUsuario"] = Usuario.TipoUsuario;
            HttpContext.Current.Session["NombreUsuario"] = Usuario.NombreUsuario;
            HttpContext.Current.Session["Contraseña"] = Usuario.Contraseña;
            HttpContext.Current.Session["Id"] = admin.IdAdministrador;
            HttpContext.Current.Session["Sexo"] = admin.Sexo;
            HttpContext.Current.Session["Dni"] = admin.Dni;
            HttpContext.Current.Session["Nombres"] = admin.Nombres;
            HttpContext.Current.Session["ApellidoPaterno"] = admin.ApellidoPaterno;
            HttpContext.Current.Session["ApellidoMaterno"] = admin.ApellidoMaterno;
        }

        public static void ActualizarSessionPsicolog(Usuarios Usuario, Psicologos psicolo)
        {
            HttpContext.Current.Session["Usuario_Id"] = Usuario.IdUsuario;
            HttpContext.Current.Session["TipoUsuario"] = Usuario.TipoUsuario;
            HttpContext.Current.Session["NombreUsuario"] = Usuario.NombreUsuario;
            HttpContext.Current.Session["Contraseña"] = Usuario.Contraseña;
            HttpContext.Current.Session["Id"] = psicolo.IdPsicologo;
            HttpContext.Current.Session["Sexo"] = psicolo.Sexo;
            HttpContext.Current.Session["Dni"] = psicolo.Dni;
            HttpContext.Current.Session["Nombres"] = psicolo.Nombres;
            HttpContext.Current.Session["ApellidoPaterno"] = psicolo.ApellidoPaterno;
            HttpContext.Current.Session["ApellidoMaterno"] = psicolo.ApellidoMaterno;
        }

    }

}