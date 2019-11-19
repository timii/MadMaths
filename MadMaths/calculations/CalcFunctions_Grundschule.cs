using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadMaths
{
    public class CalcFunctions_Grundschule
    {
        /* funktions.addieren / funktions.subtrahieren / usw. als berechnung für LÖSUNG */
        public int standard_addieren(int input_a, int input_b) { return (input_a + input_b); }
        public int grundschule_subtrahieren(int input_a, int input_b)
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
        public int standard_multiplizieren(int input_a, int input_b) { return (input_a * input_b); }
        public int grundschule_dividieren_glatt(int input_a, int input_b) /* Ohne gleitkomma */
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
        public int kindersachtext(int input_a)
        {
            return input_a / 4;

        }
        public int timaufgabe(int input_a, int input_b) /* input_a = Anfangsgeld, input_b = Jahr */
        {
            int zaehler = 0;
            for (int i = 2; i < input_b; i++)
            {
                zaehler += i;
            }
            return zaehler + input_a;
        }

        public int timaufgabe_insgesamt(int input_a, int input_b)
        {
            int zaehler = 0;
            for (int i = 1; i < input_b; i++)
            {
                zaehler += timaufgabe(input_a, i);
            }
            return zaehler;
        }
        public int essenaufgabe(int input_a, int input_b) { return (input_b - input_a); }

        public string GroesserKleiner1(int input_a, int input_b)
        {
            if (input_a == input_b) { return "="; }
            else if (input_a > input_b) { return ">"; }
            else return "<";
        }
        public bool GroesserKleiner2(int input_a, int input_user)
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
        public bool GroesserKleiner3(int input_a, int input_user)
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
        public string GeradeUngerade(int input_a)
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

        public int VerdoppelHalbieren1(int input_a) { return input_a * 2; }
        public int VerdoppelHalbieren2(int input_a) { return input_a / 2; }
        
        public int Kettenaufgabe1(int input_a, int input_b, int input_c) { return (input_a - input_b - input_c); }
        public int Kettenaufgabe2(int input_a, int input_b, int input_c) { return (input_a + input_b + input_c); }
        public int Kettenaufgabe3(int input_a, int input_b, int input_c) { return (input_a + input_b - input_c); }
        public int Kettenaufgabe4(int input_a, int input_b, int input_c) { return (input_a - input_b + input_c); }
        public int Kettenaufgabe5(int input_a, int input_b, int input_c) { return (input_a * input_b + input_c); }
        public int Kettenaufgabe6(int input_a, int input_b, int input_c) { return (input_a * input_b - input_c); }
        public int Kettenaufgabe7(int input_a, int input_b, int input_c, int input_d) { return (input_a + input_b - input_c + input_d); }
        
        public string Zeitaufgabe1() { return "10:15"; }
        public string Zeitaufgabe2() { return "18:45"; }
        public string Zeitaufgabe3() { return "11:00"; }
        public string Zeitaufgabe4() { return "03:30"; }
        public string Zeitaufgabe5() { return "00:15"; }
        
        public int Teilenmitrest1(int input_a, int input_b) { return (input_a % input_b); }
        
        public int Runden1(int input_a)
        {
            if (input_a % 10 == 0)
            {
                return input_a;
            }
            return (10 - input_a % 10) + input_a;
        }
        public int Runden2(int input_a)
        {
            if (input_a % 100 == 0)
            {
                return input_a;
            }
            return (100 - input_a % 100) + input_a;
        }
        public int Runden3(int input_a)
        {
            if (input_a % 1000 == 0)
            {
                return input_a;
            }
            return (1000 - input_a % 1000) + input_a;
        }
        public int Gleichungen(int input_a, int input_b, int input_c) { return ((input_a + input_b) - input_c); }

        public int Umwandeln1(int input_a) { return (input_a * 1000); }
        public int Umwandeln2(int input_a) { return (input_a * 1000); }
        public int Umwandeln3(int input_a) { return (input_a * 1000); }
        public int Umwandeln4(int input_a) { return (input_a / 100); }
        public int Umwandeln5(int input_a) { return (input_a / 1000); }
    }
}
