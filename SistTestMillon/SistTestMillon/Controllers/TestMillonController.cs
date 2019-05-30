using Model;
using Repository;
using SistTestMillon.Attributes;
using SistTestMillon.Helpers;
using SistTestMillon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SistTestMillon.Controllers
{
    
    public class TestMillonController : Controller
    {
        // GET: TestMillon
        [CloseSesion]
        public ActionResult Cerrar()
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Account");
        }



        public ActionResult Index()
        {
            IRepository repository = new Model.Repository();
            var cuestionario = repository.FindEntitySet<Cuestionario>(c =>c.Id>0 &&c.Id<6).OrderBy(c=>c.Id);
            return View(cuestionario);
        }

        [HttpPost]
        public ActionResult Index(int min,int max)
        {
            IRepository repository = new Model.Repository();
            var cuestionario = repository.FindEntitySet<Cuestionario>(c => c.Id >min && c.Id < max+1).OrderBy(c => c.Id);
            return Json(cuestionario.ToList());
            

        }

        [HttpPost]
        public ActionResult Retroceso(int min, int max)
        {
            IRepository repository = new Model.Repository();
            var cuestionario = repository.FindEntitySet<Cuestionario>(c => c.Id >=min && c.Id < max + 1).OrderBy(c => c.Id);
            return Json(cuestionario.ToList());


        }


        public ActionResult Diagnosticar(string Patron,string Dni,string Sexo)
        {
            
            string Distimia=PatronClinicoHelper.PatronDistimia(Patron);
            Puntuacion puntos = new Puntuacion("Distimia",Sexo,Distimia);
            puntos.CalcularPuntajeDistimico();
            int PuntosDistimia=puntos.getValor();

            IRepository repository = new Model.Repository();
            var objUsuPsicolog = repository.Create(new Diagnosticos
            {
                DniPaciente = Dni,
                Distímico = PuntosDistimia


            });

            return RedirectToAction("Index", "Home");


        }



    }
}