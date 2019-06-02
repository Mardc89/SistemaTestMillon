using Model;
using Repository;
using SistTestMillon.Attributes;
using SistTestMillon.Helpers;
using SistTestMillon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
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
            HttpContext.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);
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

        [HttpPost]
        public ActionResult Diagnosticar(string Patron,string Dni,string Sexo)
        {
            List<string> Patrones = new List<string>();
            string Esquizoide = PatronClinicoHelper.PatronEsquizoide(Patron);
            Puntuacion puntosEsquizoide = new Puntuacion("Esquizoide", Sexo, Esquizoide);
            puntosEsquizoide.CalcularPuntajeEsquizoide();
            int PuntosEsquizoide = puntosEsquizoide.getValor();
            Patrones.Add(Esquizoide);

            string Evitativo = PatronClinicoHelper.PatronEvitativo(Patron);
            Puntuacion puntosEvitativo = new Puntuacion("Evitativo", Sexo, Evitativo);
            puntosEvitativo.CalcularPuntajeEvitativo();
            int PuntosEvitativo = puntosEvitativo.getValor();
            Patrones.Add(Evitativo);

            string Depresivo = PatronClinicoHelper.PatronDistimia(Patron);
            Puntuacion puntosDepresivo = new Puntuacion("Depresivo", Sexo,Depresivo);
            puntosDepresivo.CalcularPuntajeDistimico();
            int PuntosDepresivo = puntosDepresivo.getValor();
            Patrones.Add(Depresivo);

            string Distimia=PatronClinicoHelper.PatronDistimia(Patron);
            Puntuacion puntosDistimia = new Puntuacion("Distimia",Sexo,Distimia);
            puntosDistimia.CalcularPuntajeDistimico();
            int PuntosDistimia= puntosDistimia.getValor();

            string Dependiente = PatronClinicoHelper.PatronDependiente(Patron);
            Puntuacion puntosDependiente = new Puntuacion("Dependiente", Sexo, Dependiente);
            puntosDependiente.CalcularPuntajeDependendiente();
            int PuntosDependiente = puntosDependiente.getValor();
            Patrones.Add(Dependiente);

            string Histrionico = PatronClinicoHelper.PatronHistrionico(Patron);
            Puntuacion puntosHistrionico = new Puntuacion("Histrionico", Sexo, Histrionico);
            puntosHistrionico.CalcularPuntajeHistrionico();
            int PuntosHistrionico = puntosHistrionico.getValor();
            Patrones.Add(Histrionico);

            string Narcisista = PatronClinicoHelper.PatronNarcisista(Patron);
            Puntuacion puntosNarcisista = new Puntuacion("Narcisista", Sexo, Narcisista);
            puntosNarcisista.CalcularPuntajeNarcisista();
            int PuntosNarcisista = puntosNarcisista.getValor();
            Patrones.Add(Narcisista);

            string Antisocial = PatronClinicoHelper.PatronAntisocial(Patron);
            Puntuacion puntosAntisocial = new Puntuacion("Antisocial", Sexo, Antisocial);
            puntosAntisocial.CalcularPuntajeAntisocial();
            int PuntosAntisocial = puntosAntisocial.getValor();
            Patrones.Add(Antisocial);

            string Agresivo = PatronClinicoHelper.PatronAgresivoSadico(Patron);
            Puntuacion puntosAgresivo = new Puntuacion("AgresivoSadico", Sexo, Antisocial);
            puntosAgresivo.CalcularPuntajeAgresivoSadico();
            int PuntosAgresivo = puntosAntisocial.getValor();
            Patrones.Add(Agresivo);

            string Compulsivo = PatronClinicoHelper.PatronCompulsivo(Patron);
            Puntuacion puntosCompulsivo = new Puntuacion("Compulsivo", Sexo, Compulsivo);
            puntosCompulsivo.CalcularPuntajeCompulsivo();
            int PuntosCompulsivo = puntosCompulsivo.getValor();
            Patrones.Add(Compulsivo);

            string Negativista = PatronClinicoHelper.PatronNegativista(Patron);
            Puntuacion puntosNegativista = new Puntuacion("Negativista", Sexo, Negativista);
            puntosNegativista.CalcularPuntajeNegativista();
            int PuntosNegativista = puntosNegativista.getValor();
            Patrones.Add(Negativista);

            string Autodestructiva = PatronClinicoHelper.PatronAutodestructiva(Patron);
            Puntuacion puntosAutodestructiva = new Puntuacion("AutoDestructiva", Sexo, Autodestructiva);
            puntosAutodestructiva.CalcularPuntajeAutoDestructiva();
            int PuntosAutodestructiva = puntosAutodestructiva.getValor();
            Patrones.Add(Autodestructiva);

            string Esquizotipica = PatronClinicoHelper.PatronEsquizotipica(Patron);
            Puntuacion puntosEsquizotipica = new Puntuacion("Esquizotipica", Sexo, Esquizotipica);
            puntosEsquizotipica.CalcularPuntajeEsquizotipica();
            int PuntosEsquizotipica = puntosEsquizotipica.getValor();

            string Limite = PatronClinicoHelper.PatronLimite(Patron);
            Puntuacion puntosLimite = new Puntuacion("Limite", Sexo, Limite);
            puntosLimite.CalcularPuntajeLimite();
            int PuntosLimite = puntosLimite.getValor();

            string Paranoide = PatronClinicoHelper.PatronParanoide(Patron);
            Puntuacion puntosParanoide = new Puntuacion("Paranoide", Sexo, Paranoide);
            puntosParanoide.CalcularPuntajeParanoide();
            int PuntosParanoide = puntosParanoide.getValor();

            string Ansiedad = PatronClinicoHelper.PatronAnsiedad(Patron);
            Puntuacion puntosAnsiedad = new Puntuacion("Ansiedad", Sexo, Ansiedad);
            puntosAnsiedad.CalcularPuntajeAnsiedad();
            int PuntosAnsiedad = puntosAnsiedad.getValor();

            string Somatoformo = PatronClinicoHelper.PatronSomatoformo(Patron);
            Puntuacion puntosSomatoformo = new Puntuacion("Somatoformo", Sexo, Somatoformo);
            puntosSomatoformo.CalcularPuntajeSomatoformo();
            int PuntosSomatoformo = puntosSomatoformo.getValor();

            string Bipolar = PatronClinicoHelper.PatronBipolar(Patron);
            Puntuacion puntosBipolar = new Puntuacion("Bipolar", Sexo, Bipolar);
            puntosBipolar.CalcularPuntajeBipolar();
            int PuntosBipolar = puntosBipolar.getValor();

            string Alcohol = PatronClinicoHelper.PatronDependenciaAlcohol(Patron);
            Puntuacion puntosAlcohol = new Puntuacion("DependenciaAlcohol", Sexo,Alcohol);
            puntosAlcohol.CalcularPuntajeDependenciaAlcohol();
            int PuntosAlcohol = puntosAlcohol.getValor();

            string Sustancias = PatronClinicoHelper.PatronDependenciaSustancias(Patron);
            Puntuacion puntosSustancias = new Puntuacion("DependenciaSustancias", Sexo, Sustancias);
            puntosSustancias.CalcularPuntajeDependenciaDeSustancias();
            int PuntosSustancias = puntosSustancias.getValor();

            string Estres = PatronClinicoHelper.PatronEstresPostraumatico(Patron);
            Puntuacion puntosEstres = new Puntuacion("EstresPostraumatico", Sexo, Estres);
            puntosEstres.CalcularPuntajeEstresPostraumatico();
            int PuntosEstres = puntosEstres.getValor();

            string Pensamiento = PatronClinicoHelper.PatronDesordenPensamiento(Patron);
            Puntuacion puntosPensamiento = new Puntuacion("DesordenPensamiento", Sexo, Pensamiento);
            puntosPensamiento.CalcularPuntajeDesordenPensamiento();
            int PuntosPensamiento = puntosPensamiento.getValor();

            string DepresionMayor = PatronClinicoHelper.PatronDepresionMayor(Patron);
            Puntuacion puntosDepresionMayor = new Puntuacion("DepresionMayor", Sexo, DepresionMayor);
            puntosDepresionMayor.CalcularPuntajeDepresionMayor();
            int PuntosDepresionMayor = puntosDepresionMayor.getValor();

            string Delusional = PatronClinicoHelper.PatronDesordenDelusional(Patron);
            Puntuacion puntosDelusional = new Puntuacion("DesordenDelusional", Sexo, Delusional);
            puntosDelusional.CalcularPuntajeDesordenDelusional();
            int PuntosDelusional = puntosDelusional.getValor();

            string DeseabilidadSocial = PatronClinicoHelper.PatronDeseabilidadSocial(Patron);
            Puntuacion puntosDeseabilidadSocial = new Puntuacion("DeseabilidadSocial", Sexo, DeseabilidadSocial);
            puntosDeseabilidadSocial.CalcularPuntajeDeseabilidadSocial();
            int PuntosDeseabilidadSocial = puntosDeseabilidadSocial.getValor();

            string Devaluacion = PatronClinicoHelper.PatronDevaluacion(Patron);
            Puntuacion puntosDevaluacion = new Puntuacion("Devaluacion", Sexo, Devaluacion);
            puntosDevaluacion.CalcularPuntajeDevaluacion();
            int PuntosDevaluacion = puntosDevaluacion.getValor();

            Puntuacion puntosValidez = new Puntuacion();            
            int PuntosValidez = puntosValidez.PatronValidez(Patron);

            Puntuacion puntosSinceridad = new Puntuacion();        
            int PuntosSinceridad = puntosValidez.Sinceridad(Patrones);

            IRepository repository = new Model.Repository();
            var objUsuPsicolog = repository.Create(new Diagnosticos
            {
                DniPaciente = Dni,
                Esquizoide=PuntosEsquizoide,
                Evitativo=PuntosEvitativo,
                Depresivo=PuntosDepresivo,
                Dependiente=PuntosDependiente,
                Histriónico=PuntosHistrionico,
                Narcisista=PuntosNarcisista,
                Antisocial=PuntosAntisocial,
                AgresivoSádico=PuntosAgresivo,
                Compulsivo=PuntosCompulsivo,
                Negativista=PuntosNegativista,
                Autodestructiva=PuntosAutodestructiva,
                Esquizotípica=PuntosEsquizotipica,
                Límite=PuntosLimite,
                Paranoide=PuntosParanoide,
                Ansiedad=PuntosAnsiedad,
                Somatoformo=PuntosSomatoformo,
                Bipolar=PuntosBipolar,
                Distímico = PuntosDistimia,
                DependenciaAlcohol=PuntosAlcohol,
                DependenciaSustancias=PuntosSustancias,
                EstrésPostraumático=PuntosEstres,
                DesordenPensamiento=PuntosPensamiento,
                DepresiónMayor=PuntosDepresionMayor,
                DesordenDelusional=PuntosDelusional,
                Sinceridad=PuntosSinceridad,
                DeseabilidadSocial= PuntosDeseabilidadSocial,
                Devaluación=PuntosDevaluacion,
                Validez=PuntosValidez


            });

            return Json(Url.Action("Index", "Home"));
            


        }



    }
}