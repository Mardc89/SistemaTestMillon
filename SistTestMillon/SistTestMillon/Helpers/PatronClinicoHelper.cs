using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistTestMillon.Helpers
{
    public class PatronClinicoHelper
    {

        public static string Sinceridad(string[] patrones)
        {

            string patron = "";
            string car = "";
            string diagnostico = "";
            int TotalSinceridad = 0, sinceridad = 0;

            for (int i = 0; i < patrones.Count(); i++)
            {
                patron = patrones[i];
                for (int j = 0; j < patron.Count(); j++)
                {
                    car = patron[j] + "";
                    if (car=="1")
                    {
                        sinceridad++;
                    }
                }
                if (i == 5)
                    TotalSinceridad = TotalSinceridad + (sinceridad * 2 / 3);
                else
                    TotalSinceridad = TotalSinceridad + sinceridad;
                sinceridad = 0;
            }

            if ((TotalSinceridad >= 0 && TotalSinceridad <= 34) || (TotalSinceridad >= 178 && TotalSinceridad <= 262))
                diagnostico = "Exageró o Minimizó síntomas significativos";
            else if ((TotalSinceridad >= 35 && TotalSinceridad <= 85))
                diagnostico = "Trata de responder con sinceridad";
            else if ((TotalSinceridad >= 86 && TotalSinceridad <= 177))
                diagnostico = "Ha sido bastante sincero en sus respuestas";

           
            return diagnostico;
        }

        public static string PatronValidez(string patron)
        {

            string validez, car;
            int cont = 0;
            string diagnostico = "";

            validez = patron[64] + "" + patron[109] + "" + patron[156];

            for (int i = 0; i < validez.Count(); i++)
            {
                car = validez[i] + "";
                if (car=="1")
                    cont++;
            }

            if (cont == 0)
                diagnostico = "Puntaje Valido";
            else if (cont == 1)
                diagnostico = "Puntaje Cuestionable";
            else
                diagnostico = "Puntaje No Leyo o Comprendio bien";

            return diagnostico;
        }
        
        public static string PatronDeseabilidadSocial(string patron)
        {
            string diagnostico = "";
            string deseabilidad, car;
            int cont = 0;

            deseabilidad = patron[19] + "" + patron[31] + "" + patron[34] + "" + patron[39] + "" + patron[50] + "" +
                    patron[56] + "" + patron[58] + "" + patron[68] + "" + patron[79] + "" + patron[81] + "" +
                    patron[87] + "" + patron[96] + "" + patron[103] + "" + patron[111] + "" + patron[122] + "" +
                    patron[136] + "" + patron[140] + "" + patron[147] + "" + patron[150] + "" + patron[171] + "";




            for (int i = 0; i < deseabilidad.Count(); i++)
            {
                car = deseabilidad[i] + "";
                if (car=="1")
                    cont++;
            }


            return diagnostico;
        }

        public static string PatronDevaluacion(string patron)
        {
            string diagnostico = "";
            string devaluacion, car;
            int cont = 0;

            devaluacion = patron[0] + "" + patron[3] + "" + patron[7] + "" + patron[14] + "" + patron[21] + "" +
                    patron[23] + "" + patron[29] + "" + patron[33] + "" + patron[35] + "" + patron[43] + "" +
                    patron[54] + "" + patron[55] + "" + patron[57] + "" + patron[61] + "" + patron[62] + "" +
                    patron[69] + "" + patron[73] + "" + patron[74] + "" + patron[75] + "" + patron[82] + "" +
                    patron[83] + "" + patron[85] + "" + patron[98] + "" + patron[110] + "" + patron[122] + "" +
                    patron[127] + "" + patron[132] + "" + patron[133] + "" + patron[141] + "" + patron[144] + "" +
                    patron[149] + "" + patron[170] + "";



            for (int i = 0; i < devaluacion.Count(); i++)
            {
                car = devaluacion[i] + "";
                if (car=="1")
                    cont++;
            }

            return diagnostico;
        }





        public static string PatronEsquizoide(string patron)
        {
            string esquizoide;
            esquizoide = patron[3] + "" + patron[9] + "" + patron[26] + "" + patron[31] + "" + patron[37] + "" +
                         patron[45] + "" + patron[47] + "" + patron[56] + "" + patron[91] + "" + patron[100] + "" +
                         patron[104] + "" + patron[141] + "" + patron[147] + "" + patron[155] + "" + patron[164] + "" +
                         patron[166] + "";

            return esquizoide;
        }

        public static string PatronEvitativo(string patron)
        {
            string evitativo;
            evitativo = patron[17] + "" + patron[39] + "" + patron[46] + "" + patron[47] + "" + patron[56] + "" +
                        patron[68] + "" + patron[79] + "" + patron[83] + "" + patron[98] + "" + patron[126] + "" +
                        patron[140] + "" + patron[145] + "" + patron[147] + "" + patron[150] + "" + patron[157] + "" +
                        patron[173] + "";

            return evitativo;
        }

        public static string PatronDepresivo(string patron)
        {
            string depresivo;
            depresivo = patron[19] + "" + patron[23] + "" + patron[24] + "" + patron[42] + "" + patron[46] + "" +
                        patron[82] + "" + patron[85] + "" + patron[111] + "" + patron[122] + "" + patron[132] + "" +
                        patron[141] + "" + patron[144] + "" + patron[147] + "" + patron[150] + "" + patron[153] + "";
            

            return depresivo;
        }

        public static string PatronDependiente(string patron)
        {
            string dependiente;
            dependiente = patron[15] + "" + patron[34] + "" + patron[44] + "" + patron[46] + "" + patron[55] + "" +
                          patron[72] + "" + patron[81] + "" + patron[83] + "" + patron[93] + "" + patron[107] + "" +
                          patron[119] + "" + patron[132] + "" + patron[134] + "" + patron[140] + "" + patron[150] + "" +
                          patron[168] + "";
            
            return dependiente;
        }

        public static string PatronHistronico(string patron)
        {
            string histrionico;
            histrionico = patron[9] + "" + patron[11] + "" + patron[20] + "" + patron[23] + "" + patron[26] + "" +
                          patron[31] + "" + patron[47] + "" + patron[50] + "" + patron[56] + "" + patron[68] + "" +
                          patron[79] + "" + patron[87] + "" + patron[91] + "" + patron[98] + "" + patron[122] + "" +
                          patron[126] + "" + patron[173] + "";

            return histrionico;
        }

        public static string PatronNarcisista(string patron)
        {
            string narcisista;
            narcisista = patron[4] + "" + patron[20] + "" + patron[25] + "" + patron[30] + "" + patron[34] + "" +
                          patron[37] + "" + patron[39] + "" + patron[46] + "" + patron[56] + "" + patron[66] + "" +
                          patron[68] + "" + patron[79] + "" + patron[83] + "" + patron[84] + "" + patron[85] + "" +
                          patron[87] + "" + patron[92] + "" + patron[93] + "" + patron[98] + "" + patron[115] + "" +
                          patron[140] + "" + patron[143] + "" + patron[158] + "" + patron[168] + "";

            return narcisista;
        }

        public static string PatronAntisocial(string patron)
        {
            string antisocial;
            antisocial = patron[6] + "" + patron[12] + "" + patron[13] + "" + patron[16] + "" + patron[20] + "" +
                          patron[37] + "" + patron[40] + "" + patron[51] + "" + patron[52] + "" + patron[92] + "" +
                          patron[100] + "" + patron[112] + "" + patron[121] + "" + patron[135] + "" + patron[138] + "" +
                          patron[165] + "" + patron[171] + "";

            return antisocial;
        }

        public static string PatronAgresivoSadico(string patron)
        {
            string agresivosadico;
            agresivosadico = patron[6] + "" + patron[8] + "" + patron[12] + "" + patron[13] + "" + patron[16] + "" +
                              patron[27] + "" + patron[32] + "" + patron[35] + "" + patron[38] + "" + patron[40] + "" +
                              patron[48] + "" + patron[52] + "" + patron[63] + "" + patron[78] + "" + patron[86] + "" +
                              patron[92] + "" + patron[94] + "" + patron[95] + "" + patron[115] + "" + patron[165] + "";

            return agresivosadico;
        }

        public static string PatronCompulsivo(string patron)
        {
            string compulsivo;
            compulsivo = patron[1] + "" + patron[6] + "" + patron[13] + "" + patron[21] + "" + patron[28] + "" +
                          patron[40] + "" + patron[52] + "" + patron[58] + "" + patron[71] + "" + patron[81] + "" +
                          patron[96] + "" + patron[100] + "" + patron[113] + "" + patron[136] + "" + patron[138] + "" +
                          patron[165] + "" + patron[171] + "";

            return compulsivo;
        }

        public static string PatronNegativista(string patron)
        {
            string negativista;
            negativista = patron[5] + "" + patron[6] + "" + patron[14] + "" + patron[21] + "" + patron[35] + "" +
                          patron[41] + "" + patron[49] + "" + patron[59] + "" + patron[78] + "" + patron[82] + "" +
                          patron[97] + "" + patron[114] + "" + patron[121] + "" + patron[125] + "" + patron[132] + "" +
                          patron[165] + "";

            return negativista;
        }

        public static string PatronAutodestructiva(string patron)
        {
            string autodestructiva;
            autodestructiva = patron[17] + "" + patron[18] + "" + patron[23] + "" + patron[24] + "" + patron[34] + "" +
                              patron[39] + "" + patron[42] + "" + patron[69] + "" + patron[89] + "" + patron[97] + "" +
                              patron[103] + "" + patron[121] + "" + patron[147] + "" + patron[160] + "" + patron[168] + "";

            return autodestructiva;
        }

        public static string PatronEsquizotipica(string patron)
        {
            string esquizotipica;
            esquizotipica = patron[7] + "" + patron[47] + "" + patron[68] + "" + patron[70] + "" + patron[75] + "" +
                          patron[98] + "" + patron[101] + "" + patron[116] + "" + patron[133] + "" + patron[137] + "" +
                          patron[140] + "" + patron[147] + "" + patron[150] + "" + patron[155] + "" + patron[157] + "" +
                          patron[161] + "";

            return esquizotipica;
        }

        public static string PatronLimite(string patron)
        {
            string limite;
            limite = patron[6] + "" + patron[21] + "" + patron[29] + "" + patron[40] + "" + patron[71] + "" +
                     patron[82] + "" + patron[97] + "" + patron[119] + "" + patron[121] + "" + patron[133] + "" +
                     patron[134] + "" + patron[141] + "" + patron[153] + "" + patron[160] + "" + patron[170] + "" +
                     patron[165] + "";

            return limite;
        }

        public static string PatronParanoide(string patron)
        {
            string paranoide;
            paranoide = patron[5] + "" + patron[7] + "" + patron[32] + "" + patron[41] + "" + patron[47] + "" +
                        patron[48] + "" + patron[59] + "" + patron[62] + "" + patron[88] + "" + patron[102] + "" +
                        patron[114] + "" + patron[137] + "" + patron[145] + "" + patron[157] + "" + patron[158] + "" +
                        patron[166] + "" + patron[174] + "";

            return paranoide;
        }

        public static string PatronAnsiedad(string patron)
        {
            string ansiedad;
            ansiedad = patron[39] + "" + patron[57] + "" + patron[60] + "" + patron[74] + "" + patron[75] + "" +
                       patron[107] + "" + patron[108] + "" + patron[123] + "" + patron[134] + "" + patron[144] + "" +
                       patron[146] + "" + patron[148] + "" + patron[163] + "" + patron[169] + "";

            return ansiedad;
        }

        public static string PatronSomatoformo(string patron)
        {
            string somatoformo;
            somatoformo = patron[0] + "" + patron[3] + "" + patron[10] + "" + patron[36] + "" + patron[54] + "" +
                          patron[73] + "" + patron[74] + "" + patron[106] + "" + patron[110] + "" + patron[129] + "" +
                          patron[144] + "" + patron[147] + "";

            return somatoformo;
        }

        public static string PatronBipolar(string patron)
        {
            string bipolar;
            bipolar = patron[2] + "" + patron[21] + "" + patron[40] + "" + patron[50] + "" + patron[53] + "" +
                      patron[82] + "" + patron[95] + "" + patron[105]+ "" + patron[116] + "" + patron[124] + "" +
                      patron[133] + "" + patron[165] + "" + patron[169] + "";

            return bipolar;
        }
        
        public static string PatronDistimia(string patron)
        {
            string distimia;
            distimia = patron[14] + "" + patron[23] + "" + patron[24] + "" + patron[54] + "" + patron[61] + "" +
                       patron[82] + "" + patron[85] + "" + patron[103] + "" + patron[110] + "" + patron[129] + "" +
                       patron[140] + "" + patron[141] + "" + patron[147] + "";

            return distimia;
        }

        public static string PatronDependenciaAlcohol(string patron)
        {
            string dependenciaalcohol;
            dependenciaalcohol = patron[13] + "" + patron[22] + "" + patron[40] + "" + patron[51] + "" + patron[63] + "" +
                                 patron[76] + "" + patron[92] + "" + patron[99] + "" + patron[100] + "" + patron[112] + "" +
                                 patron[121] + "" + patron[130] + "" + patron[138] + "" + patron[151] + "" + patron[165] + "";

            return dependenciaalcohol;
        }

        public static string PatronDependenciaSustancias(string patron)
        {
            string dependenciasustancias;
            dependenciasustancias = patron[6] + "" + patron[12] + "" + patron[20] + "" + patron[37] + "" + patron[38] + "" +
                                    patron[40] + "" + patron[52] + "" + patron[65] + "" + patron[90] + "" + patron[100] + "" +
                                    patron[112] + "" + patron[117] + "" + patron[135] + "" + patron[138] + "";

            return dependenciasustancias;
        }

        public static string PatronEstresPostraumatico(string patron)
        {
            string estrespostraumatico;
            estrespostraumatico = patron[61] + "" + patron[75] + "" + patron[82] + "" + patron[108] + "" + patron[122] + "" +
                                  patron[128] + "" + patron[132] + "" + patron[141] + "" + patron[146] + "" + patron[147] + "" +
                                  patron[148] + "" + patron[150] + "" + patron[153] + "" + patron[159] + "" + patron[163] + "" +
                                  patron[172] + "";

            return estrespostraumatico;
        }

        public static string PatronDesordenPensamiento(string patron)
        {
            string desordenpensamiento;
            desordenpensamiento = patron[21] + "" + patron[33] + "" + patron[55] + "" + patron[60] + "" + patron[67] + "" +
                                  patron[71] + "" + patron[75] + "" + patron[77] + "" + patron[82] + "" + patron[101] + "" +
                                  patron[116] + "" + patron[133] + "" + patron[141] + "" + patron[147] + "" + patron[150] + "" +
                                  patron[161] + "" + patron[167];

            return desordenpensamiento;
        }

        public static string PatronDepresionMayor(string patron)
        {
            string depresionmayor;
            depresionmayor = patron[0] + "" + patron[3] + "" + patron[33] + "" + patron[43] + "" + patron[54] + "" +
                             patron[73] + "" + patron[103] + "" + patron[106] + "" + patron[110] + "" + patron[127] + "" +
                             patron[129] + "" + patron[141] + "" + patron[147] + "" + patron[148] + "" + patron[149] + "" +
                             patron[153] + "" + patron[170] + "";

            return depresionmayor;
        }

        public static string PatronDesordenDelusional(string patron)
        {
            string desordendelusional;
            desordendelusional = patron[4] + "" + patron[37] + "" + patron[48] + "" + patron[62] + "" + patron[66] + "" +
                                 patron[88] + "" + patron[102] + "" + patron[118] + "" + patron[137] + "" + patron[139] + "" +
                                 patron[152] + "" + patron[158] + "" + patron[174] + "";

            return desordendelusional;
        }
    }
}