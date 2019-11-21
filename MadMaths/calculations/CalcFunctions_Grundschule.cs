using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadMaths.calculations
{
    static public class CalcFunctions_Grundschule
    {
        static public Dictionary<string, Delegate> gs_funcs = new Dictionary<string, Delegate>()
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
            {"essenaufgabe", new Func<int,int,int>(essenaufgabe)},
            {"grundschule_subtrahieren", new Func<int,int,int>(standard_subtrahieren)},
            {"standard_addieren", new Func<int,int,int>(standard_addieren)},
            {"standard_multiplizieren", new Func<int,int,int>(standard_multiplizieren)},
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
            {"Umwandeln4", new Func<int, float>(Umwandeln4)},
            {"Umwandeln5", new Func<int, float>(Umwandeln5)}
        };

        /* funktions.addieren / funktions.subtrahieren / usw. als berechnung für LÖSUNG */
        static public int standard_addieren(int input_a, int input_b) { return (input_a + input_b); }
        static public int standard_addieren(int a) { return a + a; }
        static public int standard_subtrahieren(int input_a, int input_b) { return input_a - input_b; }
        static public int standard_subtrahieren(int input_a, int input_b, int input_c) { return input_a - input_b - input_c; }

        static public int standard_multiplizieren(int input_a, int input_b) { return (input_a * input_b); }
        static public int grundschule_dividieren_glatt(int input_a, int input_b) /* Ohne gleitkomma */
        {
            if (input_b % input_a == 0)
            {
                return input_b / input_a;
            }
            else
            {
                return input_a / input_b;
            }
        }
        static public int kindersachtext(int input_a) //darf kein nachkomma stellen haben als lösung
        {
            return input_a / 4;

        }
        static public int timaufgabe(int input_a, int input_b) /* input_a = Anfangsgeld, input_b = Jahr */
        {
            int zaehler = 0;
            for (int i = 2; i <= input_b; i++)
            {
                zaehler += i;
            }
            return zaehler + input_a;
        }

        static public int timaufgabe_insgesamt(int input_a, int input_b)
        {
            int zaehler = 0;
            for (int i = 1; i <= input_b; i++)
            {
                zaehler += timaufgabe(input_a, i);
            }
            return zaehler;
        }
        static public int essenaufgabe(int input_a, int input_b) { return (input_b - input_a); }

        static public string GroesserKleiner1(int input_a, int input_b)
        {
            if (input_a == input_b) { return "gleich || ="; }
            else if (input_a > input_b) { return ">"; }
            else return "<";
        }
        static public bool GroesserKleiner2(int input_a, int input_b)
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
        static public string GeradeUngerade(int input_a)
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

        static public int VerdoppelHalbieren1(int input_a) { return input_a * 2; }
        static public int VerdoppelHalbieren2(int input_a) { return input_a / 2; }

        static public int Kettenaufgabe1(int input_a, int input_b, int input_c) { return (input_a - input_b - input_c); }
        static public int Kettenaufgabe2(int input_a, int input_b, int input_c) { return (input_a + input_b + input_c); }
        static public int Kettenaufgabe3(int input_a, int input_b, int input_c) { return (input_a + input_b - input_c); }
        static public int Kettenaufgabe4(int input_a, int input_b, int input_c) { return (input_a - input_b + input_c); }
        static public int Kettenaufgabe5(int input_a, int input_b, int input_c) { return (input_a * input_b + input_c); }
        static public int Kettenaufgabe6(int input_a, int input_b, int input_c) { return (input_a * input_b - input_c); }
        static public int Kettenaufgabe7(int input_a, int input_b, int input_c, int input_d) { return (input_a + input_b - input_c + input_d); }

        static public string Zeitaufgabe1() { return "10:15"; }
        static public string Zeitaufgabe2() { return "18:45"; }
        static public string Zeitaufgabe3() { return "11:00"; }
        static public string Zeitaufgabe4() { return "03:30"; }
        static public string Zeitaufgabe5() { return "00:15"; }

        static public int TeilenmitRest1(int input_a, int input_b) { return (input_a % input_b); }

        static public int Runden1(int input_a)
        {
            if (input_a % 10 == 0)
            {
                return input_a;
            }
            return (10 - input_a % 10) + input_a;
        }
        static public int Runden2(int input_a)
        {
            if (input_a % 100 == 0)
            {
                return input_a;
            }
            return (100 - input_a % 100) + input_a;
        }
        static public int Runden3(int input_a)
        {
            if (input_a % 1000 == 0)
            {
                return input_a;
            }
            return (1000 - input_a % 1000) + input_a;
        }
        static public int Gleichungen1(int input_a, int input_b, int input_c) { return ((input_a + input_b) - input_c); }

        static public float Umwandeln1(int input_a) { return (input_a * 1000); }
        static public float Umwandeln2(int input_a) { return (input_a * 1000); }
        static public float Umwandeln3(int input_a) { return (input_a * 1000); }
        static public float Umwandeln4(int input_a) { return (input_a / 100); }
        static public float Umwandeln5(int input_a) { return (input_a / 1000); }
    }
}
