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
                case "Prozentrechnung": maxValue = 10; break;
                default: minValue = 1; maxValue = 50; break;
            }
            switch (Aufgabe)
            {
                case "Mittelwert1": maxValue = 1000;break;
                case "Mittelwert2": maxValue = 5;break;
                case "ExtrempunktI": maxValue = 10;break;
                case "NullstellenI": maxValue = 10;break;
                case "WendepunkteI": maxValue = 10;break;
                case "Urnenmodell1": maxValue = 10;break;
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
            //Kettenaufgaben
            #region
            if (Aufgabe == "Kettenaufgabe1")
            {
                do
                {
                    Zahl_Rückgabe[0] = rand.Next(minValue, maxValue);
                    Zahl_Rückgabe[1] = rand.Next(minValue, maxValue);
                    Zahl_Rückgabe[2] = rand.Next(minValue, maxValue);
                } while (Int32.Parse(Zahl_Rückgabe[0].ToString()) < (Int32.Parse(Zahl_Rückgabe[1].ToString()) + Int32.Parse(Zahl_Rückgabe[2].ToString())));
                return Zahl_Rückgabe;
            }
            if (Aufgabe == "Kettenaufgabe3")
            {
                do
                {
                    Zahl_Rückgabe[0] = rand.Next(minValue, maxValue);
                    Zahl_Rückgabe[1] = rand.Next(minValue, maxValue);
                    Zahl_Rückgabe[2] = rand.Next(minValue, maxValue);
                } while (Int32.Parse(Zahl_Rückgabe[2].ToString()) > (Int32.Parse(Zahl_Rückgabe[1].ToString()) + Int32.Parse(Zahl_Rückgabe[0].ToString())));
                return Zahl_Rückgabe;
            }
            if (Aufgabe == "Kettenaufgabe4")
            {
                do
                {
                    Zahl_Rückgabe[0] = rand.Next(minValue, maxValue);
                    Zahl_Rückgabe[1] = rand.Next(minValue, maxValue);
                    Zahl_Rückgabe[2] = rand.Next(minValue, maxValue);
                } while (Int32.Parse(Zahl_Rückgabe[1].ToString()) > (Int32.Parse(Zahl_Rückgabe[0].ToString()) - Int32.Parse(Zahl_Rückgabe[2].ToString())));
                return Zahl_Rückgabe;
            }
            if (Aufgabe == "Kettenaufgabe6")
            {
                do
                {
                    Zahl_Rückgabe[0] = rand.Next(minValue, maxValue);
                    Zahl_Rückgabe[1] = rand.Next(minValue, maxValue);
                    Zahl_Rückgabe[2] = rand.Next(minValue, maxValue);
                } while (Int32.Parse(Zahl_Rückgabe[2].ToString()) > (Int32.Parse(Zahl_Rückgabe[0].ToString()) * Int32.Parse(Zahl_Rückgabe[1].ToString())));
                return Zahl_Rückgabe;
            }
            if (Aufgabe == "Kettenaufgabe7")
            {
                do
                {
                    Zahl_Rückgabe[0] = rand.Next(minValue, maxValue);
                    Zahl_Rückgabe[1] = rand.Next(minValue, maxValue);
                    Zahl_Rückgabe[2] = rand.Next(minValue, maxValue);
                    Zahl_Rückgabe[3] = rand.Next(minValue, maxValue);
                } while (Int32.Parse(Zahl_Rückgabe[2].ToString()) > (Int32.Parse(Zahl_Rückgabe[1].ToString()) + Int32.Parse(Zahl_Rückgabe[0].ToString()) + Int32.Parse(Zahl_Rückgabe[3].ToString())));
                return Zahl_Rückgabe;
            }
            #endregion
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
            if (Aufgabe == "Textaufgabe1")
            {
                do
                {
                    Zahl_Rückgabe[0] = rand.Next(minValue, maxValue);
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
            if (Aufgabe == "Textaufgabe3")
            {
                do
                {
                    Zahl_Rückgabe[0] = rand.Next(minValue, maxValue);
                    Zahl_Rückgabe[1] = rand.Next(minValue, maxValue);
                } while (Int32.Parse(Zahl_Rückgabe[1].ToString()) < Int32.Parse(Zahl_Rückgabe[0].ToString()));
                return Zahl_Rückgabe;
            }
            if (Aufgabe == "Textaufgabe2")
            {
                do
                {
                    Zahl_Rückgabe[0] = rand.Next(minValue, maxValue);
                    Zahl_Rückgabe[1] = rand.Next(minValue, maxValue);

                } while ((Int32.Parse(Zahl_Rückgabe[1].ToString()) - Int32.Parse(Zahl_Rückgabe[0].ToString())) < 0);
                return Zahl_Rückgabe;

            }
            if (Thema == "Gleichungen")
            {
                do
                {
                    Zahl_Rückgabe[0] = rand.Next(minValue, maxValue);
                    Zahl_Rückgabe[1] = rand.Next(minValue, maxValue);
                    Zahl_Rückgabe[2] = rand.Next(minValue, maxValue);
                } while (Int32.Parse(Zahl_Rückgabe[0].ToString()) + Int32.Parse(Zahl_Rückgabe[1].ToString()) - Int32.Parse(Zahl_Rückgabe[2].ToString()) < 0);
                return Zahl_Rückgabe;
            }
            if (Thema == "Wurzeln")
            {
                Zahl_Rückgabe[0] = rand.Next(minValue, maxValue);
                Zahl_Rückgabe[0] = Int32.Parse(Zahl_Rückgabe[0].ToString()) * Int32.Parse(Zahl_Rückgabe[0].ToString());
                return Zahl_Rückgabe;
            }
            if (Aufgabe == "ExtrempunktI") 
            {
                double rand_vorzeichen = 1;
                for (int i = 0; i < rand.Next(1,10);i++)
                {
                    rand_vorzeichen *= -1;
                }

                double input_a;
                double input_b;
                double input_c;
                double input_d;

                double vorx1;
                double vorx2;
                do
                {
                    for (int i = 0; i < rand.Next(1, 10); i++)
                    {
                        rand_vorzeichen *= -1;
                    }
                    input_a = rand.Next(minValue, maxValue) * rand_vorzeichen;
                    input_b = rand.Next(minValue+2, maxValue);
                    for (int i = 0; i < rand.Next(1, 10); i++)
                    {
                        rand_vorzeichen *= -1;
                    }
                    input_c = rand.Next(minValue, maxValue) * rand_vorzeichen;
                    input_d = rand.Next(minValue+2, maxValue);
                    vorx1 = input_a * input_b;
                    vorx2 = input_c * input_d;
                    if  (input_d > input_b )
                    {
                        if ((-vorx1 / vorx2) > 0)
                        {
                            break;
                        }
                    }
                    else
                    {
                        if ((-vorx2 / vorx1) > 0)
                        {
                            break;
                        }
                    }
                } while (true);
                Zahl_Rückgabe[0] = input_a;
                Zahl_Rückgabe[1] = input_b;
                Zahl_Rückgabe[2] = input_c;
                Zahl_Rückgabe[3] = input_d;

                return Zahl_Rückgabe;
            }
            if (Aufgabe == "Wendepunkte1")
            {
                double rand_vorzeichen = 1;
                for (int i = 0; i < rand.Next(1, 10); i++)
                {
                    rand_vorzeichen *= -1;
                }

                double input_a;
                double input_b;
                double input_c;
                double input_d;

                double vorx1;
                double vorx2;
                do
                {
                    for (int i = 0; i < rand.Next(1, 10); i++)
                    {
                        rand_vorzeichen *= -1;
                    }
                    input_a = rand.Next(minValue, maxValue) * rand_vorzeichen;
                    input_b = rand.Next(minValue + 2, maxValue);
                    for (int i = 0; i < rand.Next(1, 10); i++)
                    {
                        rand_vorzeichen *= -1;
                    }
                    input_c = rand.Next(minValue, maxValue) * rand_vorzeichen;
                    input_d = rand.Next(minValue + 2, maxValue);
                    if (input_b == input_d)
                    {
                        continue;
                    }
                    vorx1 = input_a * input_b;
                    vorx2 = input_c * input_d;
                    if (input_d > input_b)
                    {
                        if ((-vorx1 / vorx2) > 0)
                        {
                            break;
                        }
                    }
                    else
                    {
                        if ((-vorx2 / vorx1) > 0)
                        {
                            break;
                        }
                    }
                } while (true);
                Zahl_Rückgabe[0] = input_a;
                Zahl_Rückgabe[1] = input_b;
                Zahl_Rückgabe[2] = input_c;
                Zahl_Rückgabe[3] = input_d;

                return Zahl_Rückgabe;
            }
            if (Aufgabe == "Dreisatz2")
            {
                do
                {
                    Zahl_Rückgabe[0] = rand.Next(minValue, maxValue);
                    Zahl_Rückgabe[1] = rand.Next(minValue, maxValue);
                    Zahl_Rückgabe[2] = rand.Next(minValue, maxValue);
                } while (Int32.Parse(Zahl_Rückgabe[2].ToString()) < Int32.Parse(Zahl_Rückgabe[0].ToString()));
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
            if (Aufgabe == "Integral1")
            {
                do
                {
                    Zahl_Rückgabe[0] = rand.Next(minValue, maxValue);
                    Zahl_Rückgabe[1] = rand.Next(minValue, maxValue);
                    Zahl_Rückgabe[2] = rand.Next(minValue, maxValue);
                    Zahl_Rückgabe[3] = rand.Next(minValue, maxValue);
                } while (Int32.Parse(Zahl_Rückgabe[2].ToString()) > Int32.Parse(Zahl_Rückgabe[3].ToString()));
                return Zahl_Rückgabe;
            }
            if (Aufgabe == "NullstellenI")
            {
                double rand_vorzeichen = 1;
                for (int i = 0; i < rand.Next(1, 10); i++)
                {
                    rand_vorzeichen *= -1;
                }

                double input_a;
                double input_b;
                double input_c;
                double input_d;
                do
                {
                    for (int i = 0; i < rand.Next(1, 10); i++)
                    {
                        rand_vorzeichen *= -1;
                    }
                    input_a = rand.Next(minValue, maxValue) * rand_vorzeichen;
                    input_b = rand.Next(minValue + 2, maxValue);
                    for (int i = 0; i < rand.Next(1, 10); i++)
                    {
                        rand_vorzeichen *= -1;
                    }
                    input_c = rand.Next(minValue, maxValue) * rand_vorzeichen;
                    input_d = rand.Next(minValue + 2, maxValue);
                    if (input_d > input_b)
                    {
                        if ((-input_a / input_c) > 0)
                        {
                            break;
                        }
                    }
                    else
                    {
                        if ((-input_c / input_a) > 0)
                        {
                            break;
                        }
                    }
                } while (true);
                Zahl_Rückgabe[0] = input_a;
                Zahl_Rückgabe[1] = input_b;
                Zahl_Rückgabe[2] = input_c;
                Zahl_Rückgabe[3] = input_d;
                return Zahl_Rückgabe;
            }

            for (int i = 0; i < argnum; i++) {
                Zahl_Rückgabe[i] = rand.Next(minValue, maxValue);
            }
            return Zahl_Rückgabe;
            

        }
    }
}
