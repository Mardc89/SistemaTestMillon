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

        public static int CitasTotales()
        {
            IRepository repository = new Model.Repository();

            var objProduct = repository.FindEntitySet<Citas>(c => true).Count();

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