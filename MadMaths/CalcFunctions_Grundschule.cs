using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadMaths
{
    class CalcFunctions_Grundschule
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
        int standard_multiplizieren(int input_a, int input_b) { return (input_a * input_b);}
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
        int kindersachtext(int input_a) {
            return input_a / 4;
            
        }
        int timaufgabe(int input_a, int input_b) /* input_a = Anfangsgeld, input_b = Jahr */
        {
            int zaehler = 0;
            for(int i = 2;i < input_b;i++ )
            {
                zaehler += i;
            }
            return zaehler + input_a;
        }

        int timaufgabe_insgesamt(int input_a, int input_b) {
            int zaehler = 0;
            for (int i = 1; i < input_b; i++) {
                zaehler += timaufgabe(input_a, i);
            }
            return zaehler;
        }
        int essenaufgabe(int input_a, int input_b) { return (input_b - input_a); }
    }
}
