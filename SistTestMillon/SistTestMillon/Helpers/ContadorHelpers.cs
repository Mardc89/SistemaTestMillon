using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistTestMillon.Helpers
{
    public class ContadorHelpers
    {
        

        public static int PacientesTotales()
        {
            IRepository repository = new Model.Repository();

            var objProduct = repository.FindEntitySet<Pacientes>(c => true).Count();

            return objProduct;

        }

        public static string ConsultarFechaIni(DateTime fechaIni)
        {
            IRepository repository = new Model.Repository();

            int cantidadcitas = repository.FindEntitySet<Citas>(c => true).Last().IdCita;
            Citas objProduct = repository.FindEntitySet<Citas>(c =>c.IdCita==cantidadcitas).First();

            if (objProduct.Hora_final<=fechaIni) {

                return fechaIni.ToString();
            
            } else {

                return "error";
            }

        }

        public static DateTime FechaIni()
        {
            IRepository repository = new Model.Repository();

            try
            {
                Citas cantidadcitas = repository.FindEntitySet<Citas>(c => c.IdCita > 0).Last();
                return Convert.ToDateTime(cantidadcitas.Hora_inicial);
            }
            catch (Exception)
            {

                throw;
            }

            



        }

        public static DateTime FechaFinal()
        {
            IRepository repository = new Model.Repository();

            Citas cantidadcitas = repository.FindEntitySet<Citas>(c => c.IdCita > 0).Last();

            return Convert.ToDateTime(cantidadcitas.Hora_final);



        }


        public static string ConsultarFechafin(DateTime fechafinal)
        {
            IRepository repository = new Model.Repository();

            int cantidadcitas = repository.FindEntitySet<Citas>(c => true).Last().IdCita;
            Citas objProduct = repository.FindEntitySet<Citas>(c => c.IdCita == cantidadcitas).First();

            if (objProduct.Hora_final<fechafinal)
            {

                return fechafinal.ToString();

            }
            else
            {

                return "error";
            }



        }


        public static int DiagnosticosTotalesMes(int mes)
        {
            IRepository repository = new Model.Repository();
            var fechayear = DateTime.Now.Year;
            var fechafinal ="";
            var fechames = "0";
            if (mes >= 1 && mes <= 9) {

                fechames = "0" + mes;
                fechafinal = fechayear+"-"+fechames;

            }

            else if (mes>=10 && mes<=12) {
                fechames = mes.ToString();
                fechafinal = fechayear + "-" + fechames;
            }

            
            var objProduct = repository.FindEntitySet<Diagnosticos>(c =>c.Fecha.Value.ToString().Substring(0,7).Equals(fechafinal)).Count();

            return objProduct;

        }



        public static int CitasTotales()
        {
            IRepository repository = new Model.Repository();

            var objProduct = repository.FindEntitySet<Citas>(c => true).Count();

            return objProduct;

        }

        public static int PacientesTotalesSexo(string sexo)
        {
            IRepository repository = new Model.Repository();

            var objProduct = repository.FindEntitySet<Pacientes>(c =>c.Sexo.Equals(sexo)).Count();

            return objProduct;

        }

        public static int CitasHoy()
        {
            IRepository repository = new Model.Repository();
            var fecha = DateTime.Now.ToString("dd/MM/yyyy");
            var objProduct = repository.FindEntitySet<Citas>(c=>c.IdCita>0).Where(c => c.Hora_inicial.Value.ToString("dd/MM/yyyy").Substring(0, 10).Equals(fecha)).Count();

            return objProduct;

        }

        public static int DiagnosticosTotales()
        {
            IRepository repository = new Model.Repository();

            var objProduct = repository.FindEntitySet<Diagnosticos>(c => true).Count();

            return objProduct;

        }

        public static int HistoriasTotales()
        {
            IRepository repository = new Model.Repository();

            var objProduct = repository.FindEntitySet<Historias>(c => true).Count();

            return objProduct;

        }

        public static string horaIni(string horaInicio)
        {
            char[] valornuevo = new char[horaInicio.Length];
            var horaI = horaInicio.ToArray();
            string cadena = "";
            for (int i = 0; i < horaI.Length; i++)
            {
                
                valornuevo[i] = horaI[i];
                if (horaI[i] != 'p'&& horaI[i] != 'm' && horaI[i] != 'a') {
                    cadena = cadena + valornuevo[i];
                }
                
                if (horaI[i]=='p')
                {
                    valornuevo[i] = 'P';
                    cadena = cadena +valornuevo[i];
                }
                if (horaI[i]=='m') {

                    valornuevo[i] = 'M';
                    cadena = cadena + valornuevo[i];
                }

                if (horaI[i] == 'a')
                {

                    valornuevo[i] = 'A';
                    cadena = cadena + valornuevo[i];
                }

            }


         return cadena;
        }

        public static string horaFinal(string horafinal)
        {
            char[] valornuevo = new char[horafinal.Length];
            var horaI = horafinal.ToArray();
            string cadena = "";
            for (int i = 0; i < horaI.Length; i++)
            {

                valornuevo[i] = horaI[i];
                if (horaI[i] != 'P' && horaI[i] != 'M'&& horaI[i] != 'A')
                {
                    if (horaI[i] != '1' && horaI[i + 1] != '2'&& i==0)
                    {
                        cadena = '0' + cadena + valornuevo[i];
                    }
                    else
                    {
                        cadena = cadena + valornuevo[i];
                    }

                }

                if (horaI[i] == 'P')
                {
                    valornuevo[i] = 'P';
                    cadena = cadena + valornuevo[i]+'.';
                }
                if (horaI[i] == 'M')
                {

                    valornuevo[i] = 'M';
                    cadena = cadena + valornuevo[i]+'.';
                }
                if (horaI[i] == 'A')
                {

                    valornuevo[i] = 'A';
                    cadena = cadena + valornuevo[i]+'.';
                }

            }


            return cadena;
        }

    }
}