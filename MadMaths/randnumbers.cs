using System;

namespace MadMaths
{
    static class randnumbers
    {
        static private bool isPrim(int Zahl)
        {
            for (int i = 2; i < Zahl; i++)
            {
                if (Zahl % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
        static public object[] Zahlen(int argnum, string Thema, string Aufgabe)
        {
            Random rand = new Random();
            int minValue = 1;
            int maxValue;
            object[] Zahl_Rückgabe = new object[argnum];
            switch(Thema) {
                case "Kettenaufgaben":  maxValue = 10; break;
                case "Zahlen Runden":  maxValue = 10000; break;
                case "TextaufgabenII":  maxValue = 10; break;
                case "Stochastik":  maxValue = 6; break;
                case "BinomischeFormeln":  maxValue = 25; break;
                case "Wurzeln":  maxValue = 25; break;
                case "Quadratische Gleichungen": maxValue = 25; break;
                case "Potenzen": maxValue = 10; break;
                case "Urnenmodell": maxValue = 15; break;
                case "Hypergeometrische Verteilung": maxValue = 40; break;
                case "Fakultät": maxValue = 10; break;

                default: minValue = 1; maxValue = 100; break;
            }
            switch (Aufgabe)
            {
                case "Mittelwert1": maxValue = 1000;break;
                case "Mittelwert2": maxValue = 5;break;
                default: break;
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
                minValue = 2;
                do
                {
                    Zahl_Rückgabe[0] = rand.Next(minValue, maxValue);
                } while (isPrim(Int32.Parse(Zahl_Rückgabe[0].ToString())));
                do
                {
                    Zahl_Rückgabe[1] = rand.Next(minValue, maxValue);
                } while (Double.Parse(Zahl_Rückgabe[0].ToString()) % Double.Parse(Zahl_Rückgabe[1].ToString()) != 0 || Double.Parse(Zahl_Rückgabe[0].ToString()) == Double.Parse(Zahl_Rückgabe[1].ToString()) || Double.Parse(Zahl_Rückgabe[1].ToString()) == 1);
                return Zahl_Rückgabe;
            }
            if (Aufgabe == "essenaufgabe" || Aufgabe == "grundschule_subtrahieren")
            {
                Zahl_Rückgabe[0] = rand.Next(minValue, maxValue);
                do
                {
                    Zahl_Rückgabe[1] = rand.Next(minValue, maxValue);
                } while (Int32.Parse(Zahl_Rückgabe[0].ToString()) < Int32.Parse(Zahl_Rückgabe[1].ToString()));
                return Zahl_Rückgabe;
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
            if (Thema == "Wurzeln")
            {
                Zahl_Rückgabe[0] = rand.Next(minValue, maxValue);
                Zahl_Rückgabe[0] = Int32.Parse(Zahl_Rückgabe[0].ToString()) * Int32.Parse(Zahl_Rückgabe[0].ToString());
                return Zahl_Rückgabe;
            }

            if (Aufgabe == "Urnenmodell1" || Aufgabe == "Urnenmodell2")
            {
                Zahl_Rückgabe[0] = rand.Next(minValue, maxValue);
                do
                {
                    Zahl_Rückgabe[1] = rand.Next(minValue, maxValue);
                } while (Int32.Parse(Zahl_Rückgabe[0].ToString()) < Int32.Parse(Zahl_Rückgabe[1].ToString())) ;
                return Zahl_Rückgabe;

            }
            if (Thema == "Hypergeometrische Verteilung")
            {
                
                Zahl_Rückgabe[0] = rand.Next(minValue, maxValue);
                do
                {
                    Zahl_Rückgabe[1] = rand.Next(minValue, maxValue);
                } while (Int32.Parse(Zahl_Rückgabe[0].ToString()) < Int32.Parse(Zahl_Rückgabe[1].ToString()));
                do
                {
                    Zahl_Rückgabe[2] = rand.Next(minValue, maxValue);
                } while (Int32.Parse(Zahl_Rückgabe[0].ToString()) < Int32.Parse(Zahl_Rückgabe[2].ToString()));
                do
                {
                    Zahl_Rückgabe[3] = rand.Next(minValue, maxValue);
                } while (Int32.Parse(Zahl_Rückgabe[2].ToString()) < Int32.Parse(Zahl_Rückgabe[3].ToString()) || Int32.Parse(Zahl_Rückgabe[1].ToString()) < Int32.Parse(Zahl_Rückgabe[3].ToString()));
                for (int i = 4; i < argnum; i++)
                {
                    Zahl_Rückgabe[i] = 5;
                }
                return Zahl_Rückgabe;

            }
            if (Aufgabe == "QuadratischeGleichungen1")
            {
                do
                {
                    Zahl_Rückgabe[0] = rand.Next(minValue, maxValue);
                    Zahl_Rückgabe[1] = rand.Next(minValue, maxValue);
                    Zahl_Rückgabe[2] = rand.Next(minValue, maxValue);
                } while (Math.Pow(Int32.Parse(Zahl_Rückgabe[1].ToString()),2) < (Int32.Parse(Zahl_Rückgabe[2].ToString()) * Int32.Parse(Zahl_Rückgabe[0].ToString()) * 4));
                return Zahl_Rückgabe;
            }

            for (int i = 0; i < argnum; i++) {
                Zahl_Rückgabe[i] = rand.Next(minValue, maxValue);
            }
            return Zahl_Rückgabe;
            

        }
    }
}
