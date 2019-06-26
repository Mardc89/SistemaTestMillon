using CrystalDecisions.CrystalReports.Engine;
using Model;
using Repository;
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
    public class DiagnosticoController : Controller
    {
        // GET: Diagnostico
        public ActionResult Index()
        {
            IRepository repository = new Model.Repository();
            var Diagnostico = repository.FindEntitySet<Diagnosticos>(c => c.IdDiagnostico > 0 && c.IdDiagnostico < 6).OrderBy(c => c.IdDiagnostico);
            return View(Diagnostico);
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
                         Pacientes.Telefono, Pacientes.Correo, Pacientes.FechaNacimiento, Pacientes.Profesion
                                FROM   Pacientes INNER JOIN
                         Diagnosticos ON Pacientes.DniPaciente = Diagnosticos.DniPaciente

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
    }
}