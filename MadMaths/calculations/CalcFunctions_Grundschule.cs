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
            {"Addieren1", new Func<int,int,int>(standard_addieren) },
            {"Addieren2", new Func<int,int,int>(standard_addieren) },
            {"Addieren3", new Func<int,int,int>(standard_addieren) },
            {"Addieren4", new Func<int,int,int>(standard_addieren) },
            { "Subtrahieren 1", new Func<int,int,int>(grundschule_subtrahieren)},
            { "Subtrahieren 2", new Func<int,int,int>(grundschule_subtrahieren)},
            {"Multiplizieren 1", new Func<int,int,int>(standard_multiplizieren) },
            {"Multiplizieren 2", new Func<int,int,int>(standard_multiplizieren) },
            { "Dividieren 1", new Func<int,int,int>(grundschule_dividieren_glatt)},
            { "Dividieren 2", new Func<int,int,int>(grundschule_dividieren_glatt)},
            {"essenaufgabe", new Func<int,int,int>(essenaufgabe)},
            {"grundschule_subtrahieren", new Func<int,int,int>(grundschule_subtrahieren) },
            {"standard_addieren", new Func<int,int,int>(standard_addieren) },
            {"standard_multiplizieren", new Func<int,int,int>(standard_multiplizieren) },
            { "kindersachtext", new Func<int,int>(kindersachtext)},
            { "timaufgabe", new Func<int,int,int>(timaufgabe)},
            { "timaufgabe_insgesamt", new Func<int,int,int>(timaufgabe_insgesamt)},
            { "GroesserKleiner1", new Func<int,int,string>(GroesserKleiner1)},
            { "", new Func<>()},
            { "", new Func<>()},
            { "", new Func<>()},
            { "", new Func<>()},


        };

        /* funktions.addieren / funktions.subtrahieren / usw. als berechnung für LÖSUNG */
        static public int standard_addieren(int input_a, int input_b) { return (input_a + input_b); }
        static public int grundschule_subtrahieren(int input_a, int input_b)
        {
            if (input_a > input_b)
            {
                return (input_a - input_b);
            }
            else
            {
                return (input_b - input_a);
            }
        }
        static public int standard_multiplizieren(int input_a, int input_b) { return (input_a * input_b); }
        static public int grundschule_dividieren_glatt(int input_a, int input_b) /* Ohne gleitkomma */
        {
            if (input_a % input_b == 0)
            {
                return input_a / input_b;
            }
            else
            {
                return input_b / input_a;
            }
        }
        static public int kindersachtext(int input_a)
        {
            return input_a / 4;

        }
        static public int timaufgabe(int input_a, int input_b) /* input_a = Anfangsgeld, input_b = Jahr */
        {
            int zaehler = 0;
            for (int i = 2; i < input_b; i++)
            {
                zaehler += i;
            }
            return zaehler + input_a;
        }

        static public int timaufgabe_insgesamt(int input_a, int input_b)
        {
            int zaehler = 0;
            for (int i = 1; i < input_b; i++)
            {
                zaehler += timaufgabe(input_a, i);
            }
            return zaehler;
        }
        static public int essenaufgabe(int input_a, int input_b) { return (input_b - input_a); }

        static public string GroesserKleiner1(int input_a, int input_b)
        {
            if (input_a == input_b) { return "="; }
            else if (input_a > input_b) { return ">"; }
            else return "<";
        }
        static public bool GroesserKleiner2(int input_a, int input_user)
        {
            if (input_a < input_user)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static public bool GroesserKleiner3(int input_a, int input_user)
        {
            if (input_a > input_user)
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
        static string Zeitaufgabe4() { return "03:30"; }
        static public string Zeitaufgabe5() { return "00:15"; }
        
        static public int Teilenmitrest1(int input_a, int input_b) { return (input_a % input_b); }
        
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
        static public int Gleichungen(int input_a, int input_b, int input_c) { return ((input_a + input_b) - input_c); }

        static public int Umwandeln1(int input_a) { return (input_a * 1000); }
        static public int Umwandeln2(int input_a) { return (input_a * 1000); }
        static public int Umwandeln3(int input_a) { return (input_a * 1000); }
        static public int Umwandeln4(int input_a) { return (input_a / 100); }
        static public int Umwandeln5(int input_a) { return (input_a / 1000); }
    }
}
