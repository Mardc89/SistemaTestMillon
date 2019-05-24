using Model;
using Repository;
using SistTestMillon.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SistTestMillon.Attributes
{
    public class AutenticadoAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (!SessionHelper.ExistUserInSession())
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Account",
                    action = "Index"
                }));
            }
            else
            {
                IRepository Repositorio = new Model.Repository();
                int idUser = SessionHelper.GetUser();
                var Usuario = Repositorio.FindEntity<Usuarios>(c => c.IdUsuario == idUser);
                if (Usuario != null)
                {
                    SessionHelper.ActualizarSession(Usuario);
                }
            }
        }
    }


    public class CloseSesionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            SessionHelper.DestroyUserSession();
            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
             {
                    controller = "Account",
                    action = "Index"
             }));
            
        }
    }

    public class NoLoginAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (SessionHelper.ExistUserInSession())
            {
                IRepository Repositorio = new Model.Repository();
                int idUser = SessionHelper.GetUser();
                var Usuario = Repositorio.FindEntity<Usuarios>(c => c.IdUsuario == idUser);
                var UsuarioID = Repositorio.FindEntity<Usuarios>(c => c.IdUsuario == idUser).IdUsuario;
                if (Usuario != null)
                {
                    SessionHelper.ActualizarSession(Usuario);
                    if (Usuario.IdUsuario == UsuarioID)
                    {
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                        {
                            controller = "Admin",
                            action = "Index"
                        }));
                    }
                }

            }
        }
    }


}