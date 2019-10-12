using Model;
using Repository;
using SistTestMillon.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

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

    public class NoCache : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            filterContext.HttpContext.Response.Cache.SetValidUntilExpires(false);
            filterContext.HttpContext.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            filterContext.HttpContext.Response.Cache.SetNoStore();

            base.OnResultExecuting(filterContext);
        }
    }


}