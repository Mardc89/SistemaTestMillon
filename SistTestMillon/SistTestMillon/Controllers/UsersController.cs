using SistTestMillon.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistTestMillon.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users

        public ActionResult Index()
        {
            return View();
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
    }
}