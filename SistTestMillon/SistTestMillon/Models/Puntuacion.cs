using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistTestMillon.Models
{
    public class Puntuacion
    {
        private string Enfermedad;
        private string Sexo;
        private string Patron;
        private int valor;

        public Puntuacion()
        {
        }

        public Puntuacion(string Enfermedad, string Sexo, string Patron)
        {
            this.Enfermedad = Enfermedad;
            this.Sexo = Sexo;
            this.Patron = Patron;
        }

        public string getEnfermedad()
        {
            return Enfermedad;
        }

        public void setEnfermedad(string Enfermedad)
        {
            this.Enfermedad = Enfermedad;
        }

        public string getSexo()
        {
            return Sexo;
        }

        public void setSexo(string Sexo)
        {
            this.Sexo = Sexo;
        }

        public int getValor()
        {
            return valor;
        }

        public void setValor(int valor)
        {
            this.valor = valor;
        }


        public int ContarPatron(string Patron)
        {
            string car;
            int cont = 0;
            for (int i = 0; i < Patron.Length; i++)
            {
                car = Patron[i] + "";
                if (car=="1")
                {
                    cont++;
                }
            }
            return cont;

        }

        public void CalcularPuntajeEsquizoide()
        {

            int contador = ContarPatron(Patron);
            if (Enfermedad=="Esquizoide" && Sexo=="Masculino")
            {

                if (contador == 1)
                {
                    valor = 9;
                }
                else if (contador == 2)
                {
                    valor = 17;
                }
                else if (contador == 3)
                {
                    valor = 26;
                }
                else if (contador == 4)
                {
                    valor = 34;
                }
                else if (contador == 5)
                {
                    valor = 43;
                }
                else if (contador == 6)
                {
                    valor = 51;
                }
                else if (contador == 7)
                {
                    valor = 60;
                }
                else if (contador == 8)
                {
                    valor = 62;
                }
                else if (contador == 9)
                {
                    valor = 63;
                }
                else if (contador == 10)
                {
                    valor = 65;
                }
                else if (contador == 11)
                {
                    valor = 66;
                }
                else if (contador == 12)
                {
                    valor = 68;
                }
                else if (contador == 13)
                {
                    valor = 69;
                }
                else if (contador == 14)
                {
                    valor = 71;
                }
                else if (contador == 15)
                {
                    valor = 72;
                }
                else if (contador == 16)
                {
                    valor = 74;
                }
            }
            else if (Enfermedad=="Esquizoide" && Sexo=="Femenino")
            {

                if (contador == 1)
                {
                    valor = 8;
                }
                else if (contador == 2)
                {
                    valor = 15;
                }
                else if (contador == 3)
                {
                    valor = 23;
                }
                else if (contador == 4)
                {
                    valor = 30;
                }
                else if (contador == 5)
                {
                    valor = 38;
                }
                else if (contador == 6)
                {
                    valor = 45;
                }
                else if (contador == 7)
                {
                    valor = 53;
                }
                else if (contador == 8)
                {
                    valor = 60;
                }
                else if (contador == 9)
                {
                    valor = 63;
                }
                else if (contador == 10)
                {
                    valor = 65;
                }
                else if (contador == 11)
                {
                    valor = 68;
                }
                else if (contador == 12)
                {
                    valor = 70;
                }
                else if (contador == 13)
                {
                    valor = 73;
                }
                else if (contador == 14)
                {
                    valor = 75;
                }
                else if (contador == 15)
                {
                    valor = 77;
                }
                else if (contador == 16)
                {
                    valor = 79;
                }

            }


        }

        public void CalcularPuntajeEvitativo()
        {

            int contador = ContarPatron(Patron);
            if (Enfermedad=="Evitativo" && Sexo=="Masculino")
            {

                if (contador == 1)
                {
                    valor = 8;
                }
                else if (contador == 2)
                {
                    valor = 15;
                }
                else if (contador == 3)
                {
                    valor = 23;
                }
                else if (contador == 4)
                {
                    valor = 30;
                }
                else if (contador == 5)
                {
                    valor = 38;
                }
                else if (contador == 6)
                {
                    valor = 45;
                }
                else if (contador == 7)
                {
                    valor = 53;
                }
                else if (contador == 8)
                {
                    valor = 60;
                }
                else if (contador == 9)
                {
                    valor = 65;
                }
                else if (contador == 10)
                {
                    valor = 70;
                }
                else if (contador == 11)
                {
                    valor = 75;
                }
                else if (contador == 12)
                {
                    valor = 76;
                }
                else if (contador == 13)
                {
                    valor = 77;
                }
                else if (contador == 14)
                {
                    valor = 78;
                }
                else if (contador == 15)
                {
                    valor = 79;
                }
                else if (contador == 16)
                {
                    valor = 80;
                }
            }
            else if (Enfermedad=="Evitativo" && Sexo=="Femenino")
            {

                if (contador == 1)
                {
                    valor = 9;
                }
                else if (contador == 2)
                {
                    valor = 17;
                }
                else if (contador == 3)
                {
                    valor = 26;
                }
                else if (contador == 4)
                {
                    valor = 34;
                }
                else if (contador == 5)
                {
                    valor = 43;
                }
                else if (contador == 6)
                {
                    valor = 51;
                }
                else if (contador == 7)
                {
                    valor = 60;
                }
                else if (contador == 8)
                {
                    valor = 62;
                }
                else if (contador == 9)
                {
                    valor = 64;
                }
                else if (contador == 10)
                {
                    valor = 66;
                }
                else if (contador == 11)
                {
                    valor = 68;
                }
                else if (contador == 12)
                {
                    valor = 69;
                }
                else if (contador == 13)
                {
                    valor = 71;
                }
                else if (contador == 14)
                {
                    valor = 73;
                }
                else if (contador == 15)
                {
                    valor = 75;
                }
                else if (contador == 16)
                {
                    valor = 77;
                }

            }


        }

        public void CalcularPuntajeDepresivo()
        {

            int contador = ContarPatron(Patron);
            if (Enfermedad=="Depresivo" && Sexo=="Masculino")
            {

                if (contador == 1)
                {
                    valor = 8;
                }
                else if (contador == 2)
                {
                    valor = 10;
                }
                else if (contador == 3)
                {
                    valor = 15;
                }
                else if (contador == 4)
                {
                    valor = 20;
                }
                else if (contador == 5)
                {
                    valor = 25;
                }
                else if (contador == 6)
                {
                    valor = 30;
                }
                else if (contador == 7)
                {
                    valor = 35;
                }
                else if (contador == 8)
                {
                    valor = 40;
                }
                else if (contador == 9)
                {
                    valor = 45;
                }
                else if (contador == 10)
                {
                    valor = 50;
                }
                else if (contador == 11)
                {
                    valor = 55;
                }
                else if (contador == 12)
                {
                    valor = 60;
                }
                else if (contador == 13)
                {
                    valor = 75;
                }
                else if (contador == 14)
                {
                    valor = 76;
                }
                else if (contador == 15)
                {
                    valor = 78;
                }

            }
            else if (Enfermedad=="Depresivo" && Sexo=="Femenino")
            {

                if (contador == 1)
                {
                    valor = 8;
                }
                else if (contador == 2)
                {
                    valor = 15;
                }
                else if (contador == 3)
                {
                    valor = 23;
                }
                else if (contador == 4)
                {
                    valor = 30;
                }
                else if (contador == 5)
                {
                    valor = 38;
                }
                else if (contador == 6)
                {
                    valor = 45;
                }
                else if (contador == 7)
                {
                    valor = 53;
                }
                else if (contador == 8)
                {
                    valor = 60;
                }
                else if (contador == 9)
                {
                    valor = 64;
                }
                else if (contador == 10)
                {
                    valor = 68;
                }
                else if (contador == 11)
                {
                    valor = 71;
                }
                else if (contador == 12)
                {
                    valor = 75;
                }
                else if (contador == 13)
                {
                    valor = 76;
                }
                else if (contador == 14)
                {
                    valor = 77;
                }
                else if (contador == 15)
                {
                    valor = 78;
                }


            }


        }

        public void CalcularPuntajeDependendiente()
        {

            int contador = ContarPatron(Patron);
            if (Enfermedad=="Dependiente" && Sexo=="Masculino")
            {

                if (contador == 1)
                {
                    valor = 6;
                }
                else if (contador == 2)
                {
                    valor = 12;
                }
                else if (contador == 3)
                {
                    valor = 18;
                }
                else if (contador == 4)
                {
                    valor = 24;
                }
                else if (contador == 5)
                {
                    valor = 30;
                }
                else if (contador == 6)
                {
                    valor = 36;
                }
                else if (contador == 7)
                {
                    valor = 42;
                }
                else if (contador == 8)
                {
                    valor = 48;
                }
                else if (contador == 9)
                {
                    valor = 54;
                }
                else if (contador == 10)
                {
                    valor = 60;
                }
                else if (contador == 11)
                {
                    valor = 63;
                }
                else if (contador == 12)
                {
                    valor = 66;
                }
                else if (contador == 13)
                {
                    valor = 69;
                }
                else if (contador == 14)
                {
                    valor = 72;
                }
                else if (contador == 15)
                {
                    valor = 75;
                }

            }
            else if (Enfermedad=="Dependiente" && Sexo=="Femenino")
            {

                if (contador == 1)
                {
                    valor = 7;
                }
                else if (contador == 2)
                {
                    valor = 13;
                }
                else if (contador == 3)
                {
                    valor = 20;
                }
                else if (contador == 4)
                {
                    valor = 27;
                }
                else if (contador == 5)
                {
                    valor = 33;
                }
                else if (contador == 6)
                {
                    valor = 40;
                }
                else if (contador == 7)
                {
                    valor = 47;
                }
                else if (contador == 8)
                {
                    valor = 53;
                }
                else if (contador == 9)
                {
                    valor = 60;
                }
                else if (contador == 10)
                {
                    valor = 62;
                }
                else if (contador == 11)
                {
                    valor = 64;
                }
                else if (contador == 12)
                {
                    valor = 66;
                }
                else if (contador == 13)
                {
                    valor = 69;
                }
                else if (contador == 14)
                {
                    valor = 71;
                }
                else if (contador == 15)
                {
                    valor = 73;
                }


            }


        }
        public void CalcularPuntajeHistrionico()
        {

            int contador = ContarPatron(Patron);
            if (Enfermedad=="Histrionico" && Sexo=="Masculino")
            {

                if (contador == 1)
                {
                    valor = 5;
                }
                else if (contador == 2)
                {
                    valor = 9;
                }
                else if (contador == 3)
                {
                    valor = 14;
                }
                else if (contador == 4)
                {
                    valor = 18;
                }
                else if (contador == 5)
                {
                    valor = 23;
                }
                else if (contador == 6)
                {
                    valor = 28;
                }
                else if (contador == 7)
                {
                    valor = 32;
                }
                else if (contador == 8)
                {
                    valor = 37;
                }
                else if (contador == 9)
                {
                    valor = 42;
                }
                else if (contador == 10)
                {
                    valor = 46;
                }
                else if (contador == 11)
                {
                    valor = 51;
                }
                else if (contador == 12)
                {
                    valor = 55;
                }
                else if (contador == 13)
                {
                    valor = 60;
                }
                else if (contador == 14)
                {
                    valor = 62;
                }
                else if (contador == 15)
                {
                    valor = 63;
                }
                else if (contador == 16)
                {
                    valor = 65;
                }
                else if (contador == 17)
                {
                    valor = 67;
                }
            }
            else if (Enfermedad=="Histrionico" && Sexo=="Femenino")
            {

                if (contador == 1)
                {
                    valor = 3;
                }
                else if (contador == 2)
                {
                    valor = 6;
                }
                else if (contador == 3)
                {
                    valor = 9;
                }
                else if (contador == 4)
                {
                    valor = 12;
                }
                else if (contador == 5)
                {
                    valor = 15;
                }
                else if (contador == 6)
                {
                    valor = 18;
                }
                else if (contador == 7)
                {
                    valor = 21;
                }
                else if (contador == 8)
                {
                    valor = 24;
                }
                else if (contador == 9)
                {
                    valor = 27;
                }
                else if (contador == 10)
                {
                    valor = 30;
                }
                else if (contador == 11)
                {
                    valor = 33;
                }
                else if (contador == 12)
                {
                    valor = 36;
                }
                else if (contador == 13)
                {
                    valor = 39;
                }
                else if (contador == 14)
                {
                    valor = 42;
                }
                else if (contador == 15)
                {
                    valor = 45;
                }
                else if (contador == 16)
                {
                    valor = 48;
                }
                else if (contador == 17)
                {
                    valor = 51;
                }

            }


        }
        public void CalcularPuntajeNarcisista()
        {

            int contador = ContarPatron(Patron);
            if (Enfermedad=="Narcisista" && Sexo=="Masculino")
            {

                if (contador == 1)
                {
                    valor = 0;
                }
                else if (contador == 2)
                {
                    valor = 6;
                }
                else if (contador == 3)
                {
                    valor = 12;
                }
                else if (contador == 4)
                {
                    valor = 18;
                }
                else if (contador == 5)
                {
                    valor = 24;
                }
                else if (contador == 6)
                {
                    valor = 30;
                }
                else if (contador == 7)
                {
                    valor = 36;
                }
                else if (contador == 8)
                {
                    valor = 42;
                }
                else if (contador == 9)
                {
                    valor = 48;
                }
                else if (contador == 10)
                {
                    valor = 54;
                }
                else if (contador == 11)
                {
                    valor = 60;
                }
                else if (contador == 12)
                {
                    valor = 62;
                }
                else if (contador == 13)
                {
                    valor = 63;
                }
                else if (contador == 14)
                {
                    valor = 65;
                }
                else if (contador == 15)
                {
                    valor = 66;
                }
                else if (contador == 16)
                {
                    valor = 68;
                }
                else if (contador == 17)
                {
                    valor = 69;
                }
                else if (contador == 18)
                {
                    valor = 71;
                }
                else if (contador == 19)
                {
                    valor = 72;
                }
                else if (contador == 20)
                {
                    valor = 74;
                }
                else if (contador == 21)
                {
                    valor = 75;
                }
                else if (contador == 22)
                {
                    valor = 77;
                }
                else if (contador == 23)
                {
                    valor = 79;
                }
                else if (contador == 24)
                {
                    valor = 81;
                }

            }
            else if (Enfermedad=="Histrionico" && Sexo=="Femenino")
            {

                if (contador == 1)
                {
                    valor = 6;
                }
                else if (contador == 2)
                {
                    valor = 12;
                }
                else if (contador == 3)
                {
                    valor = 18;
                }
                else if (contador == 4)
                {
                    valor = 24;
                }
                else if (contador == 5)
                {
                    valor = 30;
                }
                else if (contador == 6)
                {
                    valor = 36;
                }
                else if (contador == 7)
                {
                    valor = 42;
                }
                else if (contador == 8)
                {
                    valor = 48;
                }
                else if (contador == 9)
                {
                    valor = 54;
                }
                else if (contador == 10)
                {
                    valor = 60;
                }
                else if (contador == 11)
                {
                    valor = 62;
                }
                else if (contador == 12)
                {
                    valor = 63;
                }
                else if (contador == 13)
                {
                    valor = 65;
                }
                else if (contador == 14)
                {
                    valor = 67;
                }
                else if (contador == 15)
                {
                    valor = 68;
                }
                else if (contador == 16)
                {
                    valor = 70;
                }
                else if (contador == 17)
                {
                    valor = 72;
                }
                else if (contador == 18)
                {
                    valor = 73;
                }
                else if (contador == 19)
                {
                    valor = 75;
                }
                else if (contador == 20)
                {
                    valor = 78;
                }
                else if (contador == 21)
                {
                    valor = 82;
                }
                else if (contador == 22)
                {
                    valor = 85;
                }
                else if (contador == 23)
                {
                    valor = 91;
                }
                else if (contador == 24)
                {
                    valor = 97;
                }

            }


        }

        public void CalcularPuntajeAntisocial()
        {

            int contador = ContarPatron(Patron);
            if (Enfermedad=="Antisocial" && Sexo=="Masculino")
            {

                if (contador == 1)
                {
                    valor = 12;
                }
                else if (contador == 2)
                {
                    valor = 24;
                }
                else if (contador == 3)
                {
                    valor = 36;
                }
                else if (contador == 4)
                {
                    valor = 48;
                }
                else if (contador == 5)
                {
                    valor = 60;
                }
                else if (contador == 6)
                {
                    valor = 62;
                }
                else if (contador == 7)
                {
                    valor = 63;
                }
                else if (contador == 8)
                {
                    valor = 65;
                }
                else if (contador == 9)
                {
                    valor = 67;
                }
                else if (contador == 10)
                {
                    valor = 68;
                }
                else if (contador == 11)
                {
                    valor = 70;
                }
                else if (contador == 12)
                {
                    valor = 72;
                }
                else if (contador == 13)
                {
                    valor = 73;
                }
                else if (contador == 14)
                {
                    valor = 75;
                }
                else if (contador == 15)
                {
                    valor = 77;
                }
                else if (contador == 16)
                {
                    valor = 79;
                }
                else if (contador == 17)
                {
                    valor = 81;
                }


            }
            else if (Enfermedad=="Antisocial" && Sexo=="Femenino")
            {

                if (contador == 1)
                {
                    valor = 9;
                }
                else if (contador == 2)
                {
                    valor = 17;
                }
                else if (contador == 3)
                {
                    valor = 26;
                }
                else if (contador == 4)
                {
                    valor = 34;
                }
                else if (contador == 5)
                {
                    valor = 43;
                }
                else if (contador == 6)
                {
                    valor = 51;
                }
                else if (contador == 7)
                {
                    valor = 60;
                }
                else if (contador == 8)
                {
                    valor = 62;
                }
                else if (contador == 9)
                {
                    valor = 63;
                }
                else if (contador == 10)
                {
                    valor = 65;
                }
                else if (contador == 11)
                {
                    valor = 67;
                }
                else if (contador == 12)
                {
                    valor = 68;
                }
                else if (contador == 13)
                {
                    valor = 70;
                }
                else if (contador == 14)
                {
                    valor = 72;
                }
                else if (contador == 15)
                {
                    valor = 73;
                }
                else if (contador == 16)
                {
                    valor = 75;
                }
                else if (contador == 17)
                {
                    valor = 78;
                }


            }


        }
        public void CalcularPuntajeAgresivoSadico()
        {

            int contador = ContarPatron(Patron);
            if (Enfermedad=="AgresivoSadico" && Sexo=="Masculino")
            {

                if (contador == 1)
                {
                    valor = 8;
                }
                else if (contador == 2)
                {
                    valor = 15;
                }
                else if (contador == 3)
                {
                    valor = 23;
                }
                else if (contador == 4)
                {
                    valor = 30;
                }
                else if (contador == 5)
                {
                    valor = 38;
                }
                else if (contador == 6)
                {
                    valor = 45;
                }
                else if (contador == 7)
                {
                    valor = 53;
                }
                else if (contador == 8)
                {
                    valor = 60;
                }
                else if (contador == 9)
                {
                    valor = 61;
                }
                else if (contador == 10)
                {
                    valor = 63;
                }
                else if (contador == 11)
                {
                    valor = 64;
                }
                else if (contador == 12)
                {
                    valor = 65;
                }
                else if (contador == 13)
                {
                    valor = 67;
                }
                else if (contador == 14)
                {
                    valor = 68;
                }
                else if (contador == 15)
                {
                    valor = 70;
                }
                else if (contador == 16)
                {
                    valor = 71;
                }
                else if (contador == 17)
                {
                    valor = 72;
                }
                else if (contador == 18)
                {
                    valor = 74;
                }
                else if (contador == 19)
                {
                    valor = 75;
                }
                else if (contador == 20)
                {
                    valor = 80;
                }


            }
            else if (Enfermedad=="AgresivoSadico" && Sexo=="Femenino")
            {

                if (contador == 1)
                {
                    valor = 7;
                }
                else if (contador == 2)
                {
                    valor = 15;
                }
                else if (contador == 3)
                {
                    valor = 22;
                }
                else if (contador == 4)
                {
                    valor = 30;
                }
                else if (contador == 5)
                {
                    valor = 38;
                }
                else if (contador == 6)
                {
                    valor = 45;
                }
                else if (contador == 7)
                {
                    valor = 52;
                }
                else if (contador == 8)
                {
                    valor = 60;
                }
                else if (contador == 9)
                {
                    valor = 62;
                }
                else if (contador == 10)
                {
                    valor = 64;
                }
                else if (contador == 11)
                {
                    valor = 65;
                }
                else if (contador == 12)
                {
                    valor = 66;
                }
                else if (contador == 13)
                {
                    valor = 67;
                }
                else if (contador == 14)
                {
                    valor = 68;
                }
                else if (contador == 15)
                {
                    valor = 69;
                }
                else if (contador == 16)
                {
                    valor = 70;
                }
                else if (contador == 17)
                {
                    valor = 71;
                }
                else if (contador == 18)
                {
                    valor = 72;
                }
                else if (contador == 19)
                {
                    valor = 74;
                }
                else if (contador == 20)
                {
                    valor = 75;
                }


            }


        }
        public void CalcularPuntajeCompulsivo()
        {

            int contador = ContarPatron(Patron);
            if (Enfermedad=="Compulsivo" && Sexo=="Masculino")
            {

                if (contador == 1)
                {
                    valor = 0;
                }
                else if (contador == 2)
                {
                    valor = 0;
                }
                else if (contador == 3)
                {
                    valor = 0;
                }
                else if (contador == 4)
                {
                    valor = 5;
                }
                else if (contador == 5)
                {
                    valor = 11;
                }
                else if (contador == 6)
                {
                    valor = 16;
                }
                else if (contador == 7)
                {
                    valor = 22;
                }
                else if (contador == 8)
                {
                    valor = 27;
                }
                else if (contador == 9)
                {
                    valor = 33;
                }
                else if (contador == 10)
                {
                    valor = 38;
                }
                else if (contador == 11)
                {
                    valor = 44;
                }
                else if (contador == 12)
                {
                    valor = 49;
                }
                else if (contador == 13)
                {
                    valor = 55;
                }
                else if (contador == 14)
                {
                    valor = 60;
                }
                else if (contador == 15)
                {
                    valor = 62;
                }
                else if (contador == 16)
                {
                    valor = 64;
                }
                else if (contador == 17)
                {
                    valor = 66;
                }


            }
            else if (Enfermedad=="Compulsivo" && Sexo=="Femenino")
            {

                if (contador == 1)
                {
                    valor = 3;
                }
                else if (contador == 2)
                {
                    valor = 6;
                }
                else if (contador == 3)
                {
                    valor = 9;
                }
                else if (contador == 4)
                {
                    valor = 13;
                }
                else if (contador == 5)
                {
                    valor = 16;
                }
                else if (contador == 6)
                {
                    valor = 19;
                }
                else if (contador == 7)
                {
                    valor = 22;
                }
                else if (contador == 8)
                {
                    valor = 25;
                }
                else if (contador == 9)
                {
                    valor = 28;
                }
                else if (contador == 10)
                {
                    valor = 32;
                }
                else if (contador == 11)
                {
                    valor = 35;
                }
                else if (contador == 12)
                {
                    valor = 38;
                }
                else if (contador == 13)
                {
                    valor = 41;
                }
                else if (contador == 14)
                {
                    valor = 44;
                }
                else if (contador == 15)
                {
                    valor = 47;
                }
                else if (contador == 16)
                {
                    valor = 51;
                }
                else if (contador == 17)
                {
                    valor = 54;
                }


            }


        }
        public void CalcularPuntajeNegativista()
        {

            int contador = ContarPatron(Patron);
            if (Enfermedad=="Negativista" && Sexo=="Masculino")
            {

                if (contador == 1)
                {
                    valor = 5;
                }
                else if (contador == 2)
                {
                    valor = 11;
                }
                else if (contador == 3)
                {
                    valor = 16;
                }
                else if (contador == 4)
                {
                    valor = 22;
                }
                else if (contador == 5)
                {
                    valor = 27;
                }
                else if (contador == 6)
                {
                    valor = 33;
                }
                else if (contador == 7)
                {
                    valor = 38;
                }
                else if (contador == 8)
                {
                    valor = 44;
                }
                else if (contador == 9)
                {
                    valor = 49;
                }
                else if (contador == 10)
                {
                    valor = 55;
                }
                else if (contador == 11)
                {
                    valor = 60;
                }
                else if (contador == 12)
                {
                    valor = 62;
                }
                else if (contador == 13)
                {
                    valor = 64;
                }
                else if (contador == 14)
                {
                    valor = 66;
                }
                else if (contador == 15)
                {
                    valor = 69;
                }
                else if (contador == 16)
                {
                    valor = 71;
                }



            }
            else if (Enfermedad=="Negativista" && Sexo=="Femenino")
            {

                if (contador == 1)
                {
                    valor = 7;
                }
                else if (contador == 2)
                {
                    valor = 13;
                }
                else if (contador == 3)
                {
                    valor = 20;
                }
                else if (contador == 4)
                {
                    valor = 27;
                }
                else if (contador == 5)
                {
                    valor = 33;
                }
                else if (contador == 6)
                {
                    valor = 40;
                }
                else if (contador == 7)
                {
                    valor = 47;
                }
                else if (contador == 8)
                {
                    valor = 53;
                }
                else if (contador == 9)
                {
                    valor = 60;
                }
                else if (contador == 10)
                {
                    valor = 62;
                }
                else if (contador == 11)
                {
                    valor = 63;
                }
                else if (contador == 12)
                {
                    valor = 65;
                }
                else if (contador == 13)
                {
                    valor = 66;
                }
                else if (contador == 14)
                {
                    valor = 68;
                }
                else if (contador == 15)
                {
                    valor = 69;
                }
                else if (contador == 16)
                {
                    valor = 71;
                }



            }


        }
        public void CalcularPuntajeAutoDestructiva()
        {

            int contador = ContarPatron(Patron);
            if (Enfermedad=="AutoDestructiva" && Sexo=="Masculino")
            {

                if (contador == 1)
                {
                    valor = 10;
                }
                else if (contador == 2)
                {
                    valor = 20;
                }
                else if (contador == 3)
                {
                    valor = 30;
                }
                else if (contador == 4)
                {
                    valor = 40;
                }
                else if (contador == 5)
                {
                    valor = 50;
                }
                else if (contador == 6)
                {
                    valor = 60;
                }
                else if (contador == 7)
                {
                    valor = 61;
                }
                else if (contador == 8)
                {
                    valor = 63;
                }
                else if (contador == 9)
                {
                    valor = 64;
                }
                else if (contador == 10)
                {
                    valor = 65;
                }
                else if (contador == 11)
                {
                    valor = 67;
                }
                else if (contador == 12)
                {
                    valor = 68;
                }
                else if (contador == 13)
                {
                    valor = 70;
                }
                else if (contador == 14)
                {
                    valor = 71;
                }
                else if (contador == 15)
                {
                    valor = 72;
                }

            }
            else if (Enfermedad=="AutoDestructiva" && Sexo=="Femenino")
            {

                if (contador == 1)
                {
                    valor = 12;
                }
                else if (contador == 2)
                {
                    valor = 24;
                }
                else if (contador == 3)
                {
                    valor = 36;
                }
                else if (contador == 4)
                {
                    valor = 48;
                }
                else if (contador == 5)
                {
                    valor = 60;
                }
                else if (contador == 6)
                {
                    valor = 62;
                }
                else if (contador == 7)
                {
                    valor = 63;
                }
                else if (contador == 8)
                {
                    valor = 64;
                }
                else if (contador == 9)
                {
                    valor = 65;
                }
                else if (contador == 10)
                {
                    valor = 66;
                }
                else if (contador == 11)
                {
                    valor = 67;
                }
                else if (contador == 12)
                {
                    valor = 68;
                }
                else if (contador == 13)
                {
                    valor = 69;
                }
                else if (contador == 14)
                {
                    valor = 70;
                }
                else if (contador == 15)
                {
                    valor = 71;
                }
            }


        }
        public void CalcularPuntajeEsquizotipica()
        {

            int contador = ContarPatron(Patron);
            if (Enfermedad=="Esquizotipica" && Sexo=="Masculino")
            {

                if (contador == 1)
                {
                    valor = 12;
                }
                else if (contador == 2)
                {
                    valor = 24;
                }
                else if (contador == 3)
                {
                    valor = 36;
                }
                else if (contador == 4)
                {
                    valor = 48;
                }
                else if (contador == 5)
                {
                    valor = 60;
                }
                else if (contador == 6)
                {
                    valor = 61;
                }
                else if (contador == 7)
                {
                    valor = 62;
                }
                else if (contador == 8)
                {
                    valor = 63;
                }
                else if (contador == 9)
                {
                    valor = 64;
                }
                else if (contador == 10)
                {
                    valor = 65;
                }
                else if (contador == 11)
                {
                    valor = 66;
                }
                else if (contador == 12)
                {
                    valor = 67;
                }
                else if (contador == 13)
                {
                    valor = 68;
                }
                else if (contador == 14)
                {
                    valor = 69;
                }
                else if (contador == 15)
                {
                    valor = 70;
                }
                else if (contador == 16)
                {
                    valor = 71;
                }

            }
            else if (Enfermedad=="Esquizotipica" && Sexo=="Femenino")
            {

                if (contador == 1)
                {
                    valor = 12;
                }
                else if (contador == 2)
                {
                    valor = 24;
                }
                else if (contador == 3)
                {
                    valor = 36;
                }
                else if (contador == 4)
                {
                    valor = 48;
                }
                else if (contador == 5)
                {
                    valor = 60;
                }
                else if (contador == 6)
                {
                    valor = 62;
                }
                else if (contador == 7)
                {
                    valor = 63;
                }
                else if (contador == 8)
                {
                    valor = 64;
                }
                else if (contador == 9)
                {
                    valor = 65;
                }
                else if (contador == 10)
                {
                    valor = 66;
                }
                else if (contador == 11)
                {
                    valor = 67;
                }
                else if (contador == 12)
                {
                    valor = 68;
                }
                else if (contador == 13)
                {
                    valor = 69;
                }
                else if (contador == 14)
                {
                    valor = 70;
                }
                else if (contador == 15)
                {
                    valor = 71;
                }
                else if (contador == 16)
                {
                    valor = 72;
                }
            }


        }
        public void CalcularPuntajeLimite()
        {

            int contador = ContarPatron(Patron);
            if (Enfermedad=="Limite" && Sexo=="Masculino")
            {

                if (contador == 1)
                {
                    valor = 7;
                }
                else if (contador == 2)
                {
                    valor = 13;
                }
                else if (contador == 3)
                {
                    valor = 20;
                }
                else if (contador == 4)
                {
                    valor = 27;
                }
                else if (contador == 5)
                {
                    valor = 33;
                }
                else if (contador == 6)
                {
                    valor = 40;
                }
                else if (contador == 7)
                {
                    valor = 47;
                }
                else if (contador == 8)
                {
                    valor = 53;
                }
                else if (contador == 9)
                {
                    valor = 60;
                }
                else if (contador == 10)
                {
                    valor = 63;
                }
                else if (contador == 11)
                {
                    valor = 65;
                }
                else if (contador == 12)
                {
                    valor = 68;
                }
                else if (contador == 13)
                {
                    valor = 70;
                }
                else if (contador == 14)
                {
                    valor = 73;
                }
                else if (contador == 15)
                {
                    valor = 75;
                }
                else if (contador == 16)
                {
                    valor = 76;
                }

            }
            else if (Enfermedad=="Limite" && Sexo=="Femenino")
            {

                if (contador == 1)
                {
                    valor = 9;
                }
                else if (contador == 2)
                {
                    valor = 17;
                }
                else if (contador == 3)
                {
                    valor = 26;
                }
                else if (contador == 4)
                {
                    valor = 34;
                }
                else if (contador == 5)
                {
                    valor = 43;
                }
                else if (contador == 6)
                {
                    valor = 51;
                }
                else if (contador == 7)
                {
                    valor = 60;
                }
                else if (contador == 8)
                {
                    valor = 62;
                }
                else if (contador == 9)
                {
                    valor = 63;
                }
                else if (contador == 10)
                {
                    valor = 65;
                }
                else if (contador == 11)
                {
                    valor = 67;
                }
                else if (contador == 12)
                {
                    valor = 68;
                }
                else if (contador == 13)
                {
                    valor = 70;
                }
                else if (contador == 14)
                {
                    valor = 72;
                }
                else if (contador == 15)
                {
                    valor = 73;
                }
                else if (contador == 16)
                {
                    valor = 75;
                }
            }


        }
        public void CalcularPuntajeParanoide()
        {

            int contador = ContarPatron(Patron);
            if (Enfermedad=="Paranoide" && Sexo=="Masculino")
            {

                if (contador == 1)
                {
                    valor = 12;
                }
                else if (contador == 2)
                {
                    valor = 24;
                }
                else if (contador == 3)
                {
                    valor = 36;
                }
                else if (contador == 4)
                {
                    valor = 48;
                }
                else if (contador == 5)
                {
                    valor = 60;
                }
                else if (contador == 6)
                {
                    valor = 61;
                }
                else if (contador == 7)
                {
                    valor = 63;
                }
                else if (contador == 8)
                {
                    valor = 64;
                }
                else if (contador == 9)
                {
                    valor = 65;
                }
                else if (contador == 10)
                {
                    valor = 67;
                }
                else if (contador == 11)
                {
                    valor = 68;
                }
                else if (contador == 12)
                {
                    valor = 70;
                }
                else if (contador == 13)
                {
                    valor = 71;
                }
                else if (contador == 14)
                {
                    valor = 72;
                }
                else if (contador == 15)
                {
                    valor = 74;
                }
                else if (contador == 16)
                {
                    valor = 75;
                }
                else if (contador == 17)
                {
                    valor = 77;
                }

            }
            else if (Enfermedad=="Paranoide" && Sexo=="Femenino")
            {

                if (contador == 1)
                {
                    valor = 10;
                }
                else if (contador == 2)
                {
                    valor = 20;
                }
                else if (contador == 3)
                {
                    valor = 30;
                }
                else if (contador == 4)
                {
                    valor = 40;
                }
                else if (contador == 5)
                {
                    valor = 50;
                }
                else if (contador == 6)
                {
                    valor = 60;
                }
                else if (contador == 7)
                {
                    valor = 62;
                }
                else if (contador == 8)
                {
                    valor = 64;
                }
                else if (contador == 9)
                {
                    valor = 66;
                }
                else if (contador == 10)
                {
                    valor = 68;
                }
                else if (contador == 11)
                {
                    valor = 69;
                }
                else if (contador == 12)
                {
                    valor = 71;
                }
                else if (contador == 13)
                {
                    valor = 73;
                }
                else if (contador == 14)
                {
                    valor = 75;
                }
                else if (contador == 15)
                {
                    valor = 76;
                }
                else if (contador == 16)
                {
                    valor = 78;
                }
                else if (contador == 17)
                {
                    valor = 79;
                }
            }


        }
        public void CalcularPuntajeAnsiedad()
        {

            int contador = ContarPatron(Patron);
            if (Enfermedad=="Ansiedad" && Sexo=="Masculino")
            {

                if (contador == 1)
                {
                    valor = 9;
                }
                else if (contador == 2)
                {
                    valor = 17;
                }
                else if (contador == 3)
                {
                    valor = 26;
                }
                else if (contador == 4)
                {
                    valor = 34;
                }
                else if (contador == 5)
                {
                    valor = 43;
                }
                else if (contador == 6)
                {
                    valor = 51;
                }
                else if (contador == 7)
                {
                    valor = 60;
                }
                else if (contador == 8)
                {
                    valor = 75;
                }
                else if (contador == 9)
                {
                    valor = 85;
                }
                else if (contador == 10)
                {
                    valor = 88;
                }
                else if (contador == 11)
                {
                    valor = 90;
                }
                else if (contador == 12)
                {
                    valor = 93;
                }
                else if (contador == 13)
                {
                    valor = 96;
                }
                else if (contador == 14)
                {
                    valor = 99;
                }


            }
            else if (Enfermedad=="Ansiedad" && Sexo=="Femenino")
            {

                if (contador == 1)
                {
                    valor = 15;
                }
                else if (contador == 2)
                {
                    valor = 30;
                }
                else if (contador == 3)
                {
                    valor = 45;
                }
                else if (contador == 4)
                {
                    valor = 60;
                }
                else if (contador == 5)
                {
                    valor = 68;
                }
                else if (contador == 6)
                {
                    valor = 75;
                }
                else if (contador == 7)
                {
                    valor = 78;
                }
                else if (contador == 8)
                {
                    valor = 80;
                }
                else if (contador == 9)
                {
                    valor = 83;
                }
                else if (contador == 10)
                {
                    valor = 85;
                }
                else if (contador == 11)
                {
                    valor = 88;
                }
                else if (contador == 12)
                {
                    valor = 91;
                }
                else if (contador == 13)
                {
                    valor = 94;
                }
                else if (contador == 14)
                {
                    valor = 97;
                }

            }


        }
        public void CalcularPuntajeSomatoformo()
        {

            int contador = ContarPatron(Patron);
            if (Enfermedad=="Somatoformo" && Sexo=="Masculino")
            {

                if (contador == 1)
                {
                    valor = 9;
                }
                else if (contador == 2)
                {
                    valor = 17;
                }
                else if (contador == 3)
                {
                    valor = 26;
                }
                else if (contador == 4)
                {
                    valor = 34;
                }
                else if (contador == 5)
                {
                    valor = 43;
                }
                else if (contador == 6)
                {
                    valor = 51;
                }
                else if (contador == 7)
                {
                    valor = 60;
                }
                else if (contador == 8)
                {
                    valor = 65;
                }
                else if (contador == 9)
                {
                    valor = 70;
                }
                else if (contador == 10)
                {
                    valor = 75;
                }
                else if (contador == 11)
                {
                    valor = 78;
                }
                else if (contador == 12)
                {
                    valor = 80;
                }

            }
            else if (Enfermedad=="Somatoformo" && Sexo=="Femenino")
            {

                if (contador == 1)
                {
                    valor = 17;
                }
                else if (contador == 2)
                {
                    valor = 31;
                }
                else if (contador == 3)
                {
                    valor = 46;
                }
                else if (contador == 4)
                {
                    valor = 60;
                }
                else if (contador == 5)
                {
                    valor = 62;
                }
                else if (contador == 6)
                {
                    valor = 64;
                }
                else if (contador == 7)
                {
                    valor = 65;
                }
                else if (contador == 8)
                {
                    valor = 68;
                }
                else if (contador == 9)
                {
                    valor = 69;
                }
                else if (contador == 10)
                {
                    valor = 71;
                }
                else if (contador == 11)
                {
                    valor = 73;
                }
                else if (contador == 12)
                {
                    valor = 75;
                }
            }


        }
        public void CalcularPuntajeBipolar()
        {

            int contador = ContarPatron(Patron);
            if (Enfermedad=="Bipolar" && Sexo=="Masculino")
            {

                if (contador == 1)
                {
                    valor = 10;
                }
                else if (contador == 2)
                {
                    valor = 20;
                }
                else if (contador == 3)
                {
                    valor = 30;
                }
                else if (contador == 4)
                {
                    valor = 40;
                }
                else if (contador == 5)
                {
                    valor = 50;
                }
                else if (contador == 6)
                {
                    valor = 60;
                }
                else if (contador == 7)
                {
                    valor = 63;
                }
                else if (contador == 8)
                {
                    valor = 66;
                }
                else if (contador == 9)
                {
                    valor = 69;
                }
                else if (contador == 10)
                {
                    valor = 72;
                }
                else if (contador == 11)
                {
                    valor = 75;
                }
                else if (contador == 12)
                {
                    valor = 78;
                }
                else if (contador == 13)
                {
                    valor = 82;
                }

            }
            else if (Enfermedad=="Bipolar" && Sexo=="Femenino")
            {

                if (contador == 1)
                {
                    valor = 10;
                }
                else if (contador == 2)
                {
                    valor = 20;
                }
                else if (contador == 3)
                {
                    valor = 30;
                }
                else if (contador == 4)
                {
                    valor = 40;
                }
                else if (contador == 5)
                {
                    valor = 50;
                }
                else if (contador == 6)
                {
                    valor = 60;
                }
                else if (contador == 7)
                {
                    valor = 63;
                }
                else if (contador == 8)
                {
                    valor = 66;
                }
                else if (contador == 9)
                {
                    valor = 69;
                }
                else if (contador == 10)
                {
                    valor = 72;
                }
                else if (contador == 11)
                {
                    valor = 75;
                }
                else if (contador == 12)
                {
                    valor = 78;
                }
                else if (contador == 13)
                {
                    valor = 82;
                }
            }


        }
        public void CalcularPuntajeDistimico()
        {

            int contador = ContarPatron(Patron);
            if (Enfermedad=="Distimia" && Sexo=="Masculino")
            {

                if (contador == 1)
                {
                    valor = 8;
                }
                else if (contador == 2)
                {
                    valor = 15;
                }
                else if (contador == 3)
                {
                    valor = 23;
                }
                else if (contador == 4)
                {
                    valor = 30;
                }
                else if (contador == 5)
                {
                    valor = 38;
                }
                else if (contador == 6)
                {
                    valor = 45;
                }
                else if (contador == 7)
                {
                    valor = 53;
                }
                else if (contador == 8)
                {
                    valor = 60;
                }
                else if (contador == 9)
                {
                    valor = 68;
                }
                else if (contador == 10)
                {
                    valor = 75;
                }
                else if (contador == 11)
                {
                    valor = 77;
                }
                else if (contador == 12)
                {
                    valor = 78;
                }
                else if (contador == 13)
                {
                    valor = 80;
                }

            }
            else if (Enfermedad=="Distimia" && Sexo=="Femenino")
            {

                if (contador == 1)
                {
                    valor = 10;
                }
                else if (contador == 2)
                {
                    valor = 20;
                }
                else if (contador == 3)
                {
                    valor = 30;
                }
                else if (contador == 4)
                {
                    valor = 40;
                }
                else if (contador == 5)
                {
                    valor = 50;
                }
                else if (contador == 6)
                {
                    valor = 60;
                }
                else if (contador == 7)
                {
                    valor = 62;
                }
                else if (contador == 8)
                {
                    valor = 64;
                }
                else if (contador == 9)
                {
                    valor = 66;
                }
                else if (contador == 10)
                {
                    valor = 68;
                }
                else if (contador == 11)
                {
                    valor = 70;
                }
                else if (contador == 12)
                {
                    valor = 71;
                }
                else if (contador == 13)
                {
                    valor = 73;
                }
            }


        }
        public void CalcularPuntajeDependenciaAlcohol()
        {

            int contador = ContarPatron(Patron);
            if (Enfermedad=="DependenciaAlcohol" && Sexo=="Masculino")
            {

                if (contador == 1)
                {
                    valor = 20;
                }
                else if (contador == 2)
                {
                    valor = 40;
                }
                else if (contador == 3)
                {
                    valor = 60;
                }
                else if (contador == 4)
                {
                    valor = 63;
                }
                else if (contador == 5)
                {
                    valor = 66;
                }
                else if (contador == 6)
                {
                    valor = 69;
                }
                else if (contador == 7)
                {
                    valor = 72;
                }
                else if (contador == 8)
                {
                    valor = 75;
                }
                else if (contador == 9)
                {
                    valor = 80;
                }
                else if (contador == 10)
                {
                    valor = 85;
                }
                else if (contador == 11)
                {
                    valor = 90;
                }
                else if (contador == 12)
                {
                    valor = 95;
                }
                else if (contador == 13)
                {
                    valor = 100;
                }
                else if (contador == 14)
                {
                    valor = 105;
                }
                else if (contador == 15)
                {
                    valor = 110;
                }

            }
            else if (Enfermedad=="DependenciaAlcohol" && Sexo=="Femenino")
            {

                if (contador == 1)
                {
                    valor = 15;
                }
                else if (contador == 2)
                {
                    valor = 30;
                }
                else if (contador == 3)
                {
                    valor = 45;
                }
                else if (contador == 4)
                {
                    valor = 60;
                }
                else if (contador == 5)
                {
                    valor = 64;
                }
                else if (contador == 6)
                {
                    valor = 68;
                }
                else if (contador == 7)
                {
                    valor = 71;
                }
                else if (contador == 8)
                {
                    valor = 75;
                }
                else if (contador == 9)
                {
                    valor = 77;
                }
                else if (contador == 10)
                {
                    valor = 78;
                }
                else if (contador == 11)
                {
                    valor = 80;
                }
                else if (contador == 12)
                {
                    valor = 82;
                }
                else if (contador == 13)
                {
                    valor = 83;
                }
                else if (contador == 14)
                {
                    valor = 85;
                }
                else if (contador == 15)
                {
                    valor = 91;
                }
            }


        }
        public void CalcularPuntajeDependenciaDeSustancias()
        {

            int contador = ContarPatron(Patron);
            if (Enfermedad=="DependenciaSustancias" && Sexo=="Masculino")
            {

                if (contador == 1)
                {
                    valor = 30;
                }
                else if (contador == 2)
                {
                    valor = 60;
                }
                else if (contador == 3)
                {
                    valor = 62;
                }
                else if (contador == 4)
                {
                    valor = 63;
                }
                else if (contador == 5)
                {
                    valor = 65;
                }
                else if (contador == 6)
                {
                    valor = 66;
                }
                else if (contador == 7)
                {
                    valor = 68;
                }
                else if (contador == 8)
                {
                    valor = 69;
                }
                else if (contador == 9)
                {
                    valor = 71;
                }
                else if (contador == 10)
                {
                    valor = 72;
                }
                else if (contador == 11)
                {
                    valor = 74;
                }
                else if (contador == 12)
                {
                    valor = 75;
                }
                else if (contador == 13)
                {
                    valor = 78;
                }
                else if (contador == 14)
                {
                    valor = 80;
                }

            }
            else if (Enfermedad=="DependenciaSustancias" && Sexo=="Femenino")
            {

                if (contador == 1)
                {
                    valor = 15;
                }
                else if (contador == 2)
                {
                    valor = 30;
                }
                else if (contador == 3)
                {
                    valor = 45;
                }
                else if (contador == 4)
                {
                    valor = 60;
                }
                else if (contador == 5)
                {
                    valor = 63;
                }
                else if (contador == 6)
                {
                    valor = 65;
                }
                else if (contador == 7)
                {
                    valor = 68;
                }
                else if (contador == 8)
                {
                    valor = 70;
                }
                else if (contador == 9)
                {
                    valor = 73;
                }
                else if (contador == 10)
                {
                    valor = 75;
                }
                else if (contador == 11)
                {
                    valor = 77;
                }
                else if (contador == 12)
                {
                    valor = 79;
                }
                else if (contador == 13)
                {
                    valor = 81;
                }
                else if (contador == 14)
                {
                    valor = 83;
                }
            }


        }
        public void CalcularPuntajeEstresPostraumatico()
        {

            int contador = ContarPatron(Patron);
            if (Enfermedad=="EstresPostraumatico" && Sexo=="Masculino")
            {

                if (contador == 1)
                {
                    valor = 10;
                }
                else if (contador == 2)
                {
                    valor = 20;
                }
                else if (contador == 3)
                {
                    valor = 30;
                }
                else if (contador == 4)
                {
                    valor = 40;
                }
                else if (contador == 5)
                {
                    valor = 50;
                }
                else if (contador == 6)
                {
                    valor = 60;
                }
                else if (contador == 7)
                {
                    valor = 61;
                }
                else if (contador == 8)
                {
                    valor = 63;
                }
                else if (contador == 9)
                {
                    valor = 64;
                }
                else if (contador == 10)
                {
                    valor = 65;
                }
                else if (contador == 11)
                {
                    valor = 66;
                }
                else if (contador == 12)
                {
                    valor = 68;
                }
                else if (contador == 13)
                {
                    valor = 69;
                }
                else if (contador == 14)
                {
                    valor = 70;
                }
                else if (contador == 15)
                {
                    valor = 71;
                }
                else if (contador == 16)
                {
                    valor = 73;
                }

            }
            else if (Enfermedad=="EstresPostraumatico" && Sexo=="Femenino")
            {

                if (contador == 1)
                {
                    valor = 12;
                }
                else if (contador == 2)
                {
                    valor = 24;
                }
                else if (contador == 3)
                {
                    valor = 36;
                }
                else if (contador == 4)
                {
                    valor = 48;
                }
                else if (contador == 5)
                {
                    valor = 60;
                }
                else if (contador == 6)
                {
                    valor = 62;
                }
                else if (contador == 7)
                {
                    valor = 64;
                }
                else if (contador == 8)
                {
                    valor = 65;
                }
                else if (contador == 9)
                {
                    valor = 66;
                }
                else if (contador == 10)
                {
                    valor = 67;
                }
                else if (contador == 11)
                {
                    valor = 68;
                }
                else if (contador == 12)
                {
                    valor = 69;
                }
                else if (contador == 13)
                {
                    valor = 70;
                }
                else if (contador == 14)
                {
                    valor = 71;
                }
                else if (contador == 15)
                {
                    valor = 72;
                }
                else if (contador == 16)
                {
                    valor = 73;
                }
            }


        }

        public void CalcularPuntajeDesordenPensamiento()
        {

            int contador = ContarPatron(Patron);
            if (Enfermedad=="DesordenPensamiento" && Sexo=="Masculino")
            {

                if (contador == 1)
                {
                    valor = 7;
                }
                else if (contador == 2)
                {
                    valor = 13;
                }
                else if (contador == 3)
                {
                    valor = 20;
                }
                else if (contador == 4)
                {
                    valor = 27;
                }
                else if (contador == 5)
                {
                    valor = 33;
                }
                else if (contador == 6)
                {
                    valor = 40;
                }
                else if (contador == 7)
                {
                    valor = 47;
                }
                else if (contador == 8)
                {
                    valor = 53;
                }
                else if (contador == 9)
                {
                    valor = 60;
                }
                else if (contador == 10)
                {
                    valor = 62;
                }
                else if (contador == 11)
                {
                    valor = 63;
                }
                else if (contador == 12)
                {
                    valor = 65;
                }
                else if (contador == 13)
                {
                    valor = 67;
                }
                else if (contador == 14)
                {
                    valor = 68;
                }
                else if (contador == 15)
                {
                    valor = 70;
                }
                else if (contador == 16)
                {
                    valor = 72;
                }
                else if (contador == 17)
                {
                    valor = 73;
                }

            }
            else if (Enfermedad=="DesordenPensamiento" && Sexo=="Femenino")
            {

                if (contador == 1)
                {
                    valor = 9;
                }
                else if (contador == 2)
                {
                    valor = 17;
                }
                else if (contador == 3)
                {
                    valor = 26;
                }
                else if (contador == 4)
                {
                    valor = 34;
                }
                else if (contador == 5)
                {
                    valor = 43;
                }
                else if (contador == 6)
                {
                    valor = 51;
                }
                else if (contador == 7)
                {
                    valor = 60;
                }
                else if (contador == 8)
                {
                    valor = 64;
                }
                else if (contador == 9)
                {
                    valor = 68;
                }
                else if (contador == 10)
                {
                    valor = 71;
                }
                else if (contador == 11)
                {
                    valor = 75;
                }
                else if (contador == 12)
                {
                    valor = 78;
                }
                else if (contador == 13)
                {
                    valor = 82;
                }
                else if (contador == 14)
                {
                    valor = 85;
                }
                else if (contador == 15)
                {
                    valor = 88;
                }
                else if (contador == 16)
                {
                    valor = 92;
                }
                else if (contador == 17)
                {
                    valor = 95;
                }
            }


        }
        public void CalcularPuntajeDepresionMayor()
        {

            int contador = ContarPatron(Patron);
            if (Enfermedad=="DepresionMayor" && Sexo=="Masculino")
            {

                if (contador == 1)
                {
                    valor = 8;
                }
                else if (contador == 2)
                {
                    valor = 15;
                }
                else if (contador == 3)
                {
                    valor = 23;
                }
                else if (contador == 4)
                {
                    valor = 30;
                }
                else if (contador == 5)
                {
                    valor = 38;
                }
                else if (contador == 6)
                {
                    valor = 45;
                }
                else if (contador == 7)
                {
                    valor = 53;
                }
                else if (contador == 8)
                {
                    valor = 60;
                }
                else if (contador == 9)
                {
                    valor = 63;
                }
                else if (contador == 10)
                {
                    valor = 65;
                }
                else if (contador == 11)
                {
                    valor = 68;
                }
                else if (contador == 12)
                {
                    valor = 70;
                }
                else if (contador == 13)
                {
                    valor = 73;
                }
                else if (contador == 14)
                {
                    valor = 75;
                }
                else if (contador == 15)
                {
                    valor = 77;
                }
                else if (contador == 16)
                {
                    valor = 79;
                }
                else if (contador == 17)
                {
                    valor = 81;
                }

            }
            else if (Enfermedad=="DepresionMayor" && Sexo=="Femenino")
            {

                if (contador == 1)
                {
                    valor = 12;
                }
                else if (contador == 2)
                {
                    valor = 24;
                }
                else if (contador == 3)
                {
                    valor = 36;
                }
                else if (contador == 4)
                {
                    valor = 48;
                }
                else if (contador == 5)
                {
                    valor = 60;
                }
                else if (contador == 6)
                {
                    valor = 62;
                }
                else if (contador == 7)
                {
                    valor = 63;
                }
                else if (contador == 8)
                {
                    valor = 65;
                }
                else if (contador == 9)
                {
                    valor = 67;
                }
                else if (contador == 10)
                {
                    valor = 68;
                }
                else if (contador == 11)
                {
                    valor = 70;
                }
                else if (contador == 12)
                {
                    valor = 72;
                }
                else if (contador == 13)
                {
                    valor = 73;
                }
                else if (contador == 14)
                {
                    valor = 75;
                }
                else if (contador == 15)
                {
                    valor = 80;
                }
                else if (contador == 16)
                {
                    valor = 85;
                }
                else if (contador == 17)
                {
                    valor = 89;
                }
            }


        }
        public void CalcularPuntajeDesordenDelusional()
        {

            int contador = ContarPatron(Patron);
            if (Enfermedad=="DesordenDelusional" && Sexo=="Masculino")
            {

                if (contador == 1)
                {
                    valor = 60;
                }
                else if (contador == 2)
                {
                    valor = 63;
                }
                else if (contador == 3)
                {
                    valor = 66;
                }
                else if (contador == 4)
                {
                    valor = 69;
                }
                else if (contador == 5)
                {
                    valor = 72;
                }
                else if (contador == 6)
                {
                    valor = 75;
                }
                else if (contador == 7)
                {
                    valor = 80;
                }
                else if (contador == 8)
                {
                    valor = 85;
                }
                else if (contador == 9)
                {
                    valor = 89;
                }
                else if (contador == 10)
                {
                    valor = 93;
                }
                else if (contador == 11)
                {
                    valor = 96;
                }
                else if (contador == 12)
                {
                    valor = 100;
                }
                else if (contador == 13)
                {
                    valor = 104;
                }


            }
            else if (Enfermedad=="DesordenDelusional" && Sexo=="Femenino")
            {

                if (contador == 1)
                {
                    valor = 60;
                }
                else if (contador == 2)
                {
                    valor = 64;
                }
                else if (contador == 3)
                {
                    valor = 68;
                }
                else if (contador == 4)
                {
                    valor = 71;
                }
                else if (contador == 5)
                {
                    valor = 75;
                }
                else if (contador == 6)
                {
                    valor = 77;
                }
                else if (contador == 7)
                {
                    valor = 78;
                }
                else if (contador == 8)
                {
                    valor = 80;
                }
                else if (contador == 9)
                {
                    valor = 82;
                }
                else if (contador == 10)
                {
                    valor = 83;
                }
                else if (contador == 11)
                {
                    valor = 85;
                }
                else if (contador == 12)
                {
                    valor = 90;
                }
                else if (contador == 13)
                {
                    valor = 95;
                }

            }


        }
        public void CalcularPuntajeDeseabilidadSocial()
        {

            int contador = ContarPatron(Patron);
            if (Enfermedad=="DeseabilidadSocial" && Sexo=="Masculino")
            {

                if (contador == 1)
                {
                    valor = 0;
                }
                else if (contador == 2)
                {
                    valor = 6;
                }
                else if (contador == 3)
                {
                    valor = 12;
                }
                else if (contador == 4)
                {
                    valor = 18;
                }
                else if (contador == 5)
                {
                    valor = 23;
                }
                else if (contador == 6)
                {
                    valor = 29;
                }
                else if (contador == 7)
                {
                    valor = 35;
                }
                else if (contador == 8)
                {
                    valor = 40;
                }
                else if (contador == 9)
                {
                    valor = 45;
                }
                else if (contador == 10)
                {
                    valor = 50;
                }
                else if (contador == 11)
                {
                    valor = 55;
                }
                else if (contador == 12)
                {
                    valor = 60;
                }
                else if (contador == 13)
                {
                    valor = 65;
                }
                else if (contador == 14)
                {
                    valor = 70;
                }
                else if (contador == 15)
                {
                    valor = 75;
                }
                else if (contador == 16)
                {
                    valor = 80;
                }
                else if (contador == 17)
                {
                    valor = 85;
                }
                else if (contador == 18)
                {
                    valor = 89;
                }


            }
            else if (Enfermedad=="DeseabilidadSocial" && Sexo=="Femenino")
            {

                if (contador == 1)
                {
                    valor = 0;
                }
                else if (contador == 2)
                {
                    valor = 0;
                }
                else if (contador == 3)
                {
                    valor = 7;
                }
                else if (contador == 4)
                {
                    valor = 14;
                }
                else if (contador == 5)
                {
                    valor = 21;
                }
                else if (contador == 6)
                {
                    valor = 28;
                }
                else if (contador == 7)
                {
                    valor = 35;
                }
                else if (contador == 8)
                {
                    valor = 39;
                }
                else if (contador == 9)
                {
                    valor = 44;
                }
                else if (contador == 10)
                {
                    valor = 48;
                }
                else if (contador == 11)
                {
                    valor = 53;
                }
                else if (contador == 12)
                {
                    valor = 57;
                }
                else if (contador == 13)
                {
                    valor = 62;
                }
                else if (contador == 14)
                {
                    valor = 66;
                }
                else if (contador == 15)
                {
                    valor = 71;
                }
                else if (contador == 16)
                {
                    valor = 75;
                }
                else if (contador == 17)
                {
                    valor = 80;
                }
                else if (contador == 18)
                {
                    valor = 85;
                }

            }


        }
        public void CalcularPuntajeDevaluacion()
        {

            int contador = ContarPatron(Patron);
            if (Enfermedad=="Devaluacion" && Sexo=="Masculino")
            {

                if (contador == 1)
                {
                    valor = 9;
                }
                else if (contador == 2)
                {
                    valor = 18;
                }
                else if (contador == 3)
                {
                    valor = 26;
                }
                else if (contador == 4)
                {
                    valor = 35;
                }
                else if (contador == 5)
                {
                    valor = 38;
                }
                else if (contador == 6)
                {
                    valor = 40;
                }
                else if (contador == 7)
                {
                    valor = 43;
                }
                else if (contador == 8)
                {
                    valor = 45;
                }
                else if (contador == 9)
                {
                    valor = 48;
                }
                else if (contador == 10)
                {
                    valor = 50;
                }
                else if (contador == 11)
                {
                    valor = 53;
                }
                else if (contador == 12)
                {
                    valor = 55;
                }
                else if (contador == 13)
                {
                    valor = 58;
                }
                else if (contador == 14)
                {
                    valor = 60;
                }
                else if (contador == 15)
                {
                    valor = 63;
                }
                else if (contador == 16)
                {
                    valor = 65;
                }
                else if (contador == 17)
                {
                    valor = 68;
                }
                else if (contador == 18)
                {
                    valor = 70;
                }
                else if (contador == 19)
                {
                    valor = 73;
                }
                else if (contador == 20)
                {
                    valor = 75;
                }
                else if (contador == 21)
                {
                    valor = 77;
                }
                else if (contador == 22)
                {
                    valor = 79;
                }
                else if (contador == 23)
                {
                    valor = 81;
                }


            }
            else if (Enfermedad=="Devaluacion" && Sexo=="Femenino")
            {

                if (contador == 1)
                {
                    valor = 35;
                }
                else if (contador == 2)
                {
                    valor = 37;
                }
                else if (contador == 3)
                {
                    valor = 40;
                }
                else if (contador == 4)
                {
                    valor = 42;
                }
                else if (contador == 5)
                {
                    valor = 44;
                }
                else if (contador == 6)
                {
                    valor = 47;
                }
                else if (contador == 7)
                {
                    valor = 49;
                }
                else if (contador == 8)
                {
                    valor = 51;
                }
                else if (contador == 9)
                {
                    valor = 54;
                }
                else if (contador == 10)
                {
                    valor = 56;
                }
                else if (contador == 11)
                {
                    valor = 59;
                }
                else if (contador == 12)
                {
                    valor = 61;
                }
                else if (contador == 13)
                {
                    valor = 63;
                }
                else if (contador == 14)
                {
                    valor = 66;
                }
                else if (contador == 15)
                {
                    valor = 68;
                }
                else if (contador == 16)
                {
                    valor = 70;
                }
                else if (contador == 17)
                {
                    valor = 73;
                }
                else if (contador == 18)
                {
                    valor = 75;
                }
                else if (contador == 19)
                {
                    valor = 77;
                }
                else if (contador == 20)
                {
                    valor = 79;
                }
                else if (contador == 21)
                {
                    valor = 81;
                }
                else if (contador == 22)
                {
                    valor = 83;
                }
                else if (contador == 23)
                {
                    valor = 85;
                }

            }


        }

        public int PatronValidez(string patron)
        {
            string validez, car;
            int cont = 0;
            validez = patron[64] + "" + patron[109] + "" + patron[156];

            for (int i = 0; i < validez.Count(); i++)
            {
                car = validez[i] + "";
                if (car=="1")
                    cont++;
            }
            return cont;
        }

        public int Sinceridad(string[] patrones)
        {
            string patron = "";
            string car = "";
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
            return TotalSinceridad;
        }
    }
}