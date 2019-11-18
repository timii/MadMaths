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
        int standard_addieren(int input_a, int input_b) { return (input_a + input_b); }
        int grundschule_subtrahieren(int input_a, int input_b)
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
        int standard_multiplizieren(int input_a, int input_b) { return (input_a * input_b); }
        int grundschule_dividieren_glatt(int input_a, int input_b) /* Ohne gleitkomma */
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
        int kindersachtext(int input_a)
        {
            return input_a / 4;

        }
        int timaufgabe(int input_a, int input_b) /* input_a = Anfangsgeld, input_b = Jahr */
        {
            int zaehler = 0;
            for (int i = 2; i < input_b; i++)
            {
                zaehler += i;
            }
            return zaehler + input_a;
        }

        int timaufgabe_insgesamt(int input_a, int input_b)
        {
            int zaehler = 0;
            for (int i = 1; i < input_b; i++)
            {
                zaehler += timaufgabe(input_a, i);
            }
            return zaehler;
        }
        int essenaufgabe(int input_a, int input_b) { return (input_b - input_a); }

        string GroesserKleiner1(int input_a, int input_b)
        {
            if (input_a == input_b) { return "="; }
            else if (input_a > input_b) { return ">"; }
            else return "<";
        }
        bool GroesserKleiner2(int input_a, int input_user)
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
        bool GroesserKleiner3(int input_a, int input_user)
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
        string GeradeUngerade(int input_a)
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
        int Kettenaufgabe1(int input_a, int input_b, int input_c) { return (input_a - input_b - input_c); }
        int Kettenaufgabe2(int input_a, int input_b, int input_c) { return (input_a + input_b + input_c); }
        int Kettenaufgabe3(int input_a, int input_b, int input_c) { return (input_a + input_b - input_c); }
        int Kettenaufgabe4(int input_a, int input_b, int input_c) { return (input_a - input_b + input_c); }
        int Kettenaufgabe5(int input_a, int input_b, int input_c) { return (input_a * input_b + input_c); }
        int Kettenaufgabe6(int input_a, int input_b, int input_c) { return (input_a * input_b - input_c); }
        int Kettenaufgabe7(int input_a, int input_b, int input_c, int input_d) { return (input_a + input_b - input_c + input_d); }

        int VerdoppelHalbieren1(int input_a) { return input_a * 2; }
        int VerdoppelHalbieren2(int input_a) { return input_a / 2; }


    }
}
