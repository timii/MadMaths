using System;
using System.Collections.Generic;

namespace MadMaths.calculations
{
    //Beinhaltet alle Funktionen zur Berechnung der Grundschule-Aufgaben
    static public class CalcFunctions_Grundschule
    {

        /// <summary>
        /// Funktionen werden in einem Dictionary gehalten, um auf sie mithilfe eines Keys (Aufgabenname/Controller.currentExercise) zu zugreifen
        /// </summary>
        public static Dictionary<string, Delegate> gs_funcs = new Dictionary<string, Delegate>()
        #region["Dictionary mit den Funktionen zur Berechnung"]
        {
            {"Addieren1", new Func<int,int,int>(standard_addieren)},
            {"Addieren2", new Func<int,int,int>(standard_addieren)},
            {"Addieren3", new Func<int,int>(standard_addieren)},
            {"Addieren4", new Func<int,int,int>(standard_addieren)},
            {"Subtrahieren 1", new Func<int,int,int>(standard_subtrahieren)},
            {"Subtrahieren 2", new Func<int,int,int,int>(standard_subtrahieren)},
            {"Multiplizieren 1", new Func<int,int,int>(standard_multiplizieren)},
            {"Multiplizieren 2", new Func<int,int,int>(standard_multiplizieren)},
            {"Dividieren 1", new Func<int,int,int>(grundschule_dividieren_glatt)},
            {"Dividieren 2", new Func<int,int,int>(grundschule_dividieren_glatt)},
            {"Textaufgabe1", new Func<int,int,int>(essenaufgabe)},
            {"Textaufgabe2", new Func<int,int,int>(standard_subtrahieren)},
            {"Textaufgabe3", new Func<int,int,int>(standard_subtrahieren)},
            {"Textaufgabe4", new Func<int,int,int>(standard_multiplizieren)},
            {"kindersachtext", new Func<int,int>(kindersachtext)},
            {"timaufgabe", new Func<int,int,int>(timaufgabe)},
            {"timaufgabe_insgesamt", new Func<int,int,int>(timaufgabe_insgesamt)},
            {"GroesserKleiner1", new Func<int,int,string>(GroesserKleiner1)},
            {"GroesserKleiner2", new Func<int,int,bool>(GroesserKleiner2)},
            {"GeradeUngerade", new Func<int, string>(GeradeUngerade)},
            {"VerdoppelHalbieren1", new Func<int, int>(VerdoppelHalbieren1)},
            {"VerdoppelHalbieren2", new Func<int, int>(VerdoppelHalbieren2)},
            {"Kettenaufgabe1", new Func<int, int, int ,int>(Kettenaufgabe1)},
            {"Kettenaufgabe2", new Func<int, int, int ,int>(Kettenaufgabe2)},
            {"Kettenaufgabe3", new Func<int, int, int ,int>(Kettenaufgabe3)},
            {"Kettenaufgabe4", new Func<int, int, int ,int>(Kettenaufgabe4)},
            {"Kettenaufgabe5", new Func<int, int, int ,int>(Kettenaufgabe5)},
            {"Kettenaufgabe6", new Func<int, int, int ,int>(Kettenaufgabe6)},
            {"Kettenaufgabe7", new Func<int, int, int ,int, int>(Kettenaufgabe7)},
            {"Zeitaufgabe1", new Func<string>(Zeitaufgabe1)},
            {"Zeitaufgabe2", new Func<string>(Zeitaufgabe2)},
            {"Zeitaufgabe3", new Func<string>(Zeitaufgabe3)},
            {"Zeitaufgabe4", new Func<string>(Zeitaufgabe4)},
            {"Zeitaufgabe5", new Func<string>(Zeitaufgabe5)},
            {"TeilenmitRest1", new Func<int, int, int>(TeilenmitRest1)},
            {"Runden1", new Func<int, int>(Runden1)},
            {"Runden2", new Func<int, int>(Runden2)},
            {"Runden3", new Func<int, int>(Runden3)},
            {"Gleichungen1", new Func<int, int, int, int>(Gleichungen1)},
            {"Umwandeln1", new Func<int, float>(Umwandeln1)},
            {"Umwandeln2", new Func<int, float>(Umwandeln2)},
            {"Umwandeln3", new Func<int, float>(Umwandeln3)},
            {"Umwandeln4", new Func<float, float>(Umwandeln4)},
            {"Umwandeln5", new Func<float, float>(Umwandeln5)}
        };
        #endregion

        #region["Die einzelnen Funktionen"]
        public static int standard_addieren(int input_a, int input_b)
        {
            return (input_a + input_b);
        }
        public static int standard_addieren(int a)
        {
            return a + a;
        }
        public static int standard_subtrahieren(int input_a, int input_b)
        {
            return input_b - input_a;
        }
        public static int standard_subtrahieren(int input_a, int input_b, int input_c)
        {
            return input_a - input_b - input_c;
        }

        public static int standard_multiplizieren(int input_a, int input_b)
        {
            return (input_a * input_b);
        }
        public static int grundschule_dividieren_glatt(int input_a, int input_b) 
        {
            return input_a / input_b;
        }
        public static int kindersachtext(int input_a) 
        {
            return input_a / 4;

        }
        public static int timaufgabe(int input_a, int input_b) /* input_a = Anfangsgeld, input_b = Jahr */
        {
            int zaehler = 0;
            for (int i = 2; i <= input_b; i++)
            {
                zaehler += i;
            }
            return zaehler + input_a;
        }

        public static int timaufgabe_insgesamt(int input_a, int input_b)
        {
            int zaehler = 0;
            for (int i = 1; i <= input_b; i++)
            {
                zaehler += timaufgabe(input_a, i);
            }
            return zaehler;
        }
        public static int essenaufgabe(int input_a, int input_b) { return (input_a - input_b); }


        public static string GroesserKleiner1(int input_a, int input_b)
        {
            if (input_a == input_b) { return "gleich"; }
            else if (input_a > input_b) { return ">"; }
            else return "<";
        }
        public static bool GroesserKleiner2(int input_a, int input_b)
        {
            if (input_a < input_b)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static string GeradeUngerade(int input_a)
        {
            if (input_a % 2 == 0)
            {
                return "gerade";
            }
            else
            {
                return "ungerade";
            }
        }

        public static int VerdoppelHalbieren1(int input_a) { return input_a * 2; }
        public static int VerdoppelHalbieren2(int input_a) { return input_a / 2; }

        public static int Kettenaufgabe1(int input_a, int input_b, int input_c) { return (input_a - input_b - input_c); }
        public static int Kettenaufgabe2(int input_a, int input_b, int input_c) { return (input_a + input_b + input_c); }
        public static int Kettenaufgabe3(int input_a, int input_b, int input_c) { return (input_a + input_b - input_c); }
        public static int Kettenaufgabe4(int input_a, int input_b, int input_c) { return (input_a - input_b + input_c); }
        public static int Kettenaufgabe5(int input_a, int input_b, int input_c) { return (input_a * input_b + input_c); }
        public static int Kettenaufgabe6(int input_a, int input_b, int input_c) { return (input_a * input_b - input_c); }
        public static int Kettenaufgabe7(int input_a, int input_b, int input_c, int input_d) { return (input_a + input_b - input_c + input_d); }

        public static string Zeitaufgabe1() { return "10:15"; }
        public static string Zeitaufgabe2() { return "18:45"; }
        public static string Zeitaufgabe3() { return "11:00"; }
        public static string Zeitaufgabe4() { return "03:30"; }
        public static string Zeitaufgabe5() { return "00:15"; }

        public static int TeilenmitRest1(int input_a, int input_b) { return (input_a % input_b); }

        public static int Runden1(int input_a)
        {
            if (input_a % 10 == 0)
            {
                return input_a;
            }
            return (10 - input_a % 10) + input_a;
        }
        public static int Runden2(int input_a)
        {
            if (input_a % 100 == 0)
            {
                return input_a;
            }
            return (100 - input_a % 100) + input_a;
        }
        public static int Runden3(int input_a)
        {
            if (input_a % 1000 == 0)
            {
                return input_a;
            }
            return (1000 - input_a % 1000) + input_a;
        }
        public static int Gleichungen1(int input_a, int input_b, int input_c) { return ((input_a + input_b) - input_c); }

        public static float Umwandeln1(int input_a) { return (input_a * 1000); }
        public static float Umwandeln2(int input_a) { return (input_a * 1000); }
        public static float Umwandeln3(int input_a) { return (input_a * 1000); }
        public static float Umwandeln4(float input_a) { return (input_a / 100); }
        public static float Umwandeln5(float input_a) { return (input_a / 1000); }

        #endregion
    }
}
