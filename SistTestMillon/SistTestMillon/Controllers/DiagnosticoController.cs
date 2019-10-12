using CrystalDecisions.CrystalReports.Engine;
using Model;
using PagedList;
using Repository;
using SistTestMillon.Helpers;
using SistTestMillon.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistTestMillon.Controllers
{
    [Authorize]
    public class DiagnosticoController : Controller
    {
        // GET: Diagnostico
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ListaPsicologos(int? page, string search = null)
        {
            IRepository repository = new Model.Repository();
            List<Psicologos> objProduct = new List<Psicologos>();
            if (string.IsNullOrEmpty(search))
                objProduct = repository.FindEntitySet<Psicologos>(c => true).OrderBy(c => c.IdPsicologo).ToList();
            else
                objProduct = repository.FindEntitySet<Psicologos>(c => true && (c.FechaNacimiento.ToString().Contains(search) || c.Nombres.Contains(search) || c.ApellidoPaterno.Contains(search) || c.ApellidoMaterno.ToString().Contains(search) || c.Dni.Contains(search))).OrderBy(c => c.IdPsicologo).ToList();


            int pageSize = 3;
            int pageNumber = page ?? 1;


            return PartialView(objProduct.ToPagedList(pageNumber, pageSize));
        }



        public ActionResult ListaPsicologos(int? page)
        {
            IRepository repository = new Model.Repository();
            List<Psicologos> objProduct = new List<Psicologos>();

            objProduct = repository.FindEntitySet<Psicologos>(c => true).OrderBy(c => c.IdPsicologo).ToList();
            int pageSize = 3;
            int pageNumber = page ?? 1;


            return PartialView(objProduct.ToPagedList(pageNumber, pageSize));
        }


        [HttpPost]
        public ActionResult ListaPacientes(int? page, string search = null)
        {
            IRepository repository = new Model.Repository();
            List<Pacientes> objProduct = new List<Pacientes>();
            if (string.IsNullOrEmpty(search))
                objProduct = repository.FindEntitySet<Pacientes>(c => true).OrderBy(c => c.IdPaciente).ToList();
            else
                objProduct = repository.FindEntitySet<Pacientes>(c => true && (c.FechaNacimiento.ToString().Contains(search) || c.Nombres.Contains(search) || c.ApellidoPaterno.Contains(search)|| c.ApellidoMaterno.ToString().Contains(search) || c.Dni.Contains(search))).OrderBy(c => c.IdPaciente).ToList();


            int pageSize = 3;
            int pageNumber = page ?? 1;


            return PartialView(objProduct.ToPagedList(pageNumber, pageSize));
        }



        public ActionResult ListaPacientes(int? page)
        {
            IRepository repository = new Model.Repository();
            List<Pacientes> objProduct = new List<Pacientes>();

            objProduct = repository.FindEntitySet<Pacientes>(c => true).OrderBy(c => c.IdPaciente).ToList();
            int pageSize = 3;
            int pageNumber = page ?? 1;


            return PartialView(objProduct.ToPagedList(pageNumber, pageSize));
        }



        [HttpPost]
        public ActionResult ListaDiagnosticos2(int? page, string search = null)
        {
            IRepository repository = new Model.Repository();
            List<Diagnosticos> objProduct = new List<Diagnosticos>();
            if (string.IsNullOrEmpty(search))
                objProduct = repository.FindEntitySet<Diagnosticos>(c => true).OrderBy(c => c.IdDiagnostico).ToList();
            else
                objProduct = repository.FindEntitySet<Diagnosticos>(c => true && (c.Fecha.ToString().Contains(search) || c.HoraInicio.Contains(search) || c.IdDiagnostico.ToString().Contains(search) || c.DniPaciente.Contains(search))).OrderBy(c => c.IdDiagnostico).ToList();


            int pageSize = 3;
            int pageNumber = page ?? 1;


            return PartialView(objProduct.ToPagedList(pageNumber, pageSize));
        }



        public ActionResult ListaDiagnosticos2(int? page)
        {
            IRepository repository = new Model.Repository();
            List<Diagnosticos> objProduct = new List<Diagnosticos>();
            
            objProduct = repository.FindEntitySet<Diagnosticos>(c => true).OrderBy(c => c.IdDiagnostico).ToList();
            int pageSize = 3;
            int pageNumber = page ?? 1;


            return PartialView(objProduct.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult ListaDiagnosticos(string val, string valSearch, int? page)
        {
            ViewBag.CurrentSort = val;
            ViewBag.Buscar = valSearch;
            IRepository repository = new Model.Repository();
            List<Diagnosticos> objProduct = new List<Diagnosticos>();
            if (string.IsNullOrEmpty(valSearch))
                objProduct = repository.FindEntitySet<Diagnosticos>(c => true).OrderBy(c => c.IdDiagnostico).ToList();
            else
                objProduct = repository.FindEntitySet<Diagnosticos>(c => true && (c.Fecha.ToString().Contains(valSearch) || c.HoraInicio.Contains(valSearch) || c.IdDiagnostico.ToString().Contains(valSearch))).OrderBy(c => c.IdDiagnostico).ToList();

            if (val == "IdDiagnostico" || string.IsNullOrEmpty(val))
            {
                val = "IdDiagnostico";
                objProduct = objProduct.OrderBy(c => c.IdDiagnostico).ToList();
            }

            ViewBag.Order = val;
            int pageSize = 5;
            int pageNumber = page ?? 1;


            return PartialView(objProduct.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult ImprimirDetalle(int id)
        {

            var report = this.GenerarDetalleCompra(id);
            var stream = report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            return File(stream, "application/pdf");

        }

        private ReportClass GenerarDetalleCompra(int id)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["TestMillonConnectionString"].ConnectionString;
            var connection = new SqlConnection(connectionString);
            var dataTable = new DataTable();

            var sql = @"SELECT Diagnosticos.IdDiagnostico,Diagnosticos.DniPaciente, Diagnosticos.Esquizoide, Diagnosticos.Evitativo , Diagnosticos.Depresivo, 
                         Diagnosticos.Dependiente, Diagnosticos.HoraFinal, Diagnosticos.HoraInicio, Diagnosticos.Validez, Diagnosticos.Fecha, 
                         Diagnosticos.Devaluación, Diagnosticos.DeseabilidadSocial, Diagnosticos.Sinceridad, Diagnosticos.DesordenDelusional, 
                         Diagnosticos.DepresiónMayor, Diagnosticos.DesordenPensamiento, Diagnosticos.EstrésPostraumático, Diagnosticos.DependenciaSustancias, 
                         Diagnosticos.DependenciaAlcohol, Diagnosticos.Distímico, Diagnosticos.Bipolar, Diagnosticos.Somatoformo, Diagnosticos.Ansiedad, 
                         Diagnosticos.Paranoide, Diagnosticos.Límite, dbo.Diagnosticos.Esquizotípica, Diagnosticos.Autodestructiva, Diagnosticos.Negativista, 
                         Diagnosticos.Compulsivo, Diagnosticos.AgresivoSádico, Diagnosticos.Antisocial, Diagnosticos.Narcisista, Diagnosticos.Histriónico, 
                         Pacientes.Nombres, Pacientes.ApellidoPaterno, dbo.Pacientes.ApellidoMaterno, Pacientes.Direccion, Pacientes.Edad, Pacientes.Sexo, 
                         Pacientes.Telefono, Pacientes.FechaNacimiento, Pacientes.Profesion
                                FROM   Pacientes INNER JOIN
                         Diagnosticos ON Pacientes.Dni = Diagnosticos.DniPaciente

                        WHERE Diagnosticos.IdDiagnostico=" + id;
            try
            {
                connection.Open();
                var command = new SqlCommand(sql, connection);
                var adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);

            }
            catch (Exception ex)
            {
                ex.ToString();
            }

            var report = new ReportClass();
            report.FileName = Server.MapPath("/Reportes/Results.rpt");
            report.Load();
            report.SetDataSource(dataTable);
            return report;
        }


        [HttpPost]
        public ActionResult Add(Diagnostico diag)
        {
            IRepository repository = new Model.Repository();
            int id = 0;
            string strMensaje = "No se pudo actualizar la información, intentelo más tarde";
            bool okResult = false;
            if (diag.IdDiagnostico > 0)
            {
                id = diag.IdDiagnostico;
                Diagnosticos diagnostico = repository.FindEntity<Diagnosticos>(c => c.IdDiagnostico == diag.IdDiagnostico);
                if (diagnostico != null)
                {
                    diagnostico.Esquizoide = diag.Esquizoide;
                    diagnostico.Evitativo =diag.Evitativo;
                    diagnostico.Depresivo = diag.Depresivo;
                    diagnostico.Dependiente = diag.Dependiente;
                    diagnostico.Histriónico = diag.Histriónico;
                    diagnostico.Narcisista = diag.Narcisista;
                    diagnostico.AgresivoSádico = diag.AgresivoSádico;
                    diagnostico.Compulsivo = diag.Compulsivo;
                    diagnostico.Negativista = diag.Negativista;
                    diagnostico.Autodestructiva = diag.Autodestructiva;
                    diagnostico.Esquizotípica = diag.Esquizotípica;
                    diagnostico.Límite = diag.Límite;
                    diagnostico.Paranoide = diag.Paranoide;
                    diagnostico.Ansiedad = diag.Ansiedad;
                    diagnostico.Somatoformo = diag.Somatoformo;
                    diagnostico.Bipolar = diag.Bipolar;
                    diagnostico.Distímico = diag.Distímico;
                    diagnostico.DependenciaAlcohol = diag.DependenciaAlcohol;
                    diagnostico.DependenciaSustancias = diag.DependenciaSustancias;
                    diagnostico.EstrésPostraumático = diag.EstrésPostraumático;
                    diagnostico.DesordenPensamiento = diag.DesordenPensamiento;
                    diagnostico.DepresiónMayor = diag.DepresiónMayor;
                    diagnostico.DesordenDelusional = diag.DesordenDelusional;
                    diagnostico.Sinceridad = diag.Sinceridad;
                    diagnostico.DeseabilidadSocial = diag.DeseabilidadSocial;
                    diagnostico.Devaluación = diag.Devaluación;
                    diagnostico.Validez = diag.Validez;
                }
                //Productos objUpdateProd = (Productos)objProd;
                repository.Update(diagnostico);
                strMensaje = "Se actualizo el producto";
                okResult = true;
            }

            return Json(new Response { IsSuccess = okResult, Message = strMensaje, Id = id }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Get(int Id)
        {
            string strMensaje = "No se encontro el diagnostico que desea editar";
            IRepository repository = new Model.Repository();
            var diagnostico = repository.FindEntity<Diagnosticos>(c => c.IdDiagnostico == Id);
            if (diagnostico != null)
            {
                Diagnostico diag = new Diagnostico
                {
                    IdDiagnostico = diagnostico.IdDiagnostico,
                    DniPaciente = diagnostico.DniPaciente,
                    Fecha = diagnostico.Fecha,
                    Esquizoide = diagnostico.Esquizoide,
                    Evitativo = diagnostico.Evitativo,
                    Depresivo = diagnostico.Depresivo,
                    Dependiente = diagnostico.Dependiente,
                    Histriónico = diagnostico.Histriónico,
                    Narcisista = diagnostico.Narcisista,
                    Antisocial = diagnostico.AgresivoSádico,
                    AgresivoSádico = diagnostico.AgresivoSádico,
                    Compulsivo = diagnostico.Compulsivo,
                    Negativista=diagnostico.Negativista,
                    Autodestructiva=diagnostico.Autodestructiva,
                    Esquizotípica=diagnostico.Esquizotípica,
                    Límite=diagnostico.Límite,
                    Paranoide=diagnostico.Paranoide,
                    Ansiedad=diagnostico.Ansiedad,
                    Somatoformo=diagnostico.Somatoformo,
                    Bipolar=diagnostico.Bipolar,
                    Distímico=diagnostico.Distímico,
                    DependenciaAlcohol=diagnostico.DependenciaAlcohol,
                    DependenciaSustancias=diagnostico.DependenciaSustancias,
                    EstrésPostraumático=diagnostico.EstrésPostraumático,
                    DesordenPensamiento=diagnostico.DesordenPensamiento,
                    DepresiónMayor=diagnostico.DepresiónMayor,
                    DesordenDelusional=diagnostico.DesordenDelusional,
                    Sinceridad=diagnostico.Sinceridad,
                    DeseabilidadSocial=diagnostico.DeseabilidadSocial,
                    Devaluación=diagnostico.Devaluación,
                    Validez=diagnostico.Validez

                };


                return Json(new Response { IsSuccess = true, Id = Id, Result =diag}, JsonRequestBehavior.AllowGet);
            }
            return Json(new Response { IsSuccess = false, Message = strMensaje, Id = Id }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Eliminar(int Id)
        {
            string strMensaje = "No se encontro el producto que desea eliminar";
            bool okResult = false;
            IRepository repository = new Model.Repository();
            var objProd = repository.FindEntity<Diagnosticos>(c => c.IdDiagnostico == Id);
            if (objProd != null)
            {
                try
                {
                    repository.Delete(objProd);
                    strMensaje = "Se elimino el diagnostico correctamente";
                    okResult = true;

                }
                catch (Exception)
                {

                    strMensaje = "No Se puede eliminir el diagnostico";
                    okResult = true;
                }
            }
            return Json(new Response { IsSuccess = okResult, Message = strMensaje, Id = Id }, JsonRequestBehavior.AllowGet);
        }
    }
}