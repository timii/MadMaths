using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MadMaths
{
    static class randnumbers
    {
        static public object[] Zahlen(int argnum, string Thema, string Aufgabe)
        {
            Random rand = new Random();
            int minValue;
            int maxValue;
            object[] Zahl_Rückgabe = new object[argnum];
            switch(Thema) {
                case "Kettenaufgaben": minValue = 1; maxValue = 10; break;
                case "Zahlen Runden": minValue = 1; maxValue = 10000; break;
                case "Textaufgaben II": minValue = 1; maxValue = 10; break;
                default: minValue = 1; maxValue = 100; break;
            }
            if (Aufgabe == "Subtrahieren 1") {
                Zahl_Rückgabe[0] = rand.Next(minValue, maxValue);
                do
                {
                    Zahl_Rückgabe[1] = rand.Next(minValue, maxValue);
                } while (Int32.Parse(Zahl_Rückgabe[0].ToString()) > Int32.Parse(Zahl_Rückgabe[1].ToString()));
                return Zahl_Rückgabe;
            }
            if (Aufgabe == "Subtrahieren 2") {
                Zahl_Rückgabe[0] = rand.Next(minValue, maxValue);
                do
                {
                    Zahl_Rückgabe[1] = rand.Next(minValue, maxValue);
                } while (Int32.Parse(Zahl_Rückgabe[0].ToString()) < Int32.Parse(Zahl_Rückgabe[1].ToString()));

                do
                {
                    Zahl_Rückgabe[2] = rand.Next(minValue, maxValue);
                } while (Int32.Parse(Zahl_Rückgabe[0].ToString()) < (Int32.Parse(Zahl_Rückgabe[1].ToString()) + Int32.Parse(Zahl_Rückgabe[2].ToString())));
                return Zahl_Rückgabe;
            }

            if (Thema == "Dividieren")
            {
                Zahl_Rückgabe[0] = rand.Next(minValue, maxValue);
                do
                {
                    Zahl_Rückgabe[1] = rand.Next(minValue, maxValue);
                } while (Int32.Parse(Zahl_Rückgabe[0].ToString()) % Int32.Parse(Zahl_Rückgabe[1].ToString()) == 0);
                return Zahl_Rückgabe;
            }
            if (Aufgabe == "essenaufgabe" || Aufgabe == "grundschule_subtrahieren")
            {
                Zahl_Rückgabe[0] = rand.Next(minValue, maxValue);
                do
                {
                    Zahl_Rückgabe[1] = rand.Next(minValue, maxValue);
                } while (Int32.Parse(Zahl_Rückgabe[0].ToString()) < Int32.Parse(Zahl_Rückgabe[1].ToString()));
            }
            if (Aufgabe == "VerdoppelHalbieren2")
            {
                do
                {
                    Zahl_Rückgabe[0] = rand.Next(minValue, maxValue);
                } while (Int32.Parse(Zahl_Rückgabe[0].ToString()) % 2 != 0);
                return Zahl_Rückgabe;
            }
            if (Aufgabe == "kindersachtext") {
                do
                {
                    Zahl_Rückgabe[0] = rand.Next(minValue, maxValue);
                } while (Int32.Parse(Zahl_Rückgabe[0].ToString()) % 4 != 0);
                return Zahl_Rückgabe;
            }



            for (int i = 0; i < argnum; i++) {
                Zahl_Rückgabe[i] = rand.Next(minValue, maxValue);

            }


            return Zahl_Rückgabe;
            

        }
    }
}
