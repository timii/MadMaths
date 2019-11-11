using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadMaths
{
    class CalcFunctions
    {
        /* funktions.addieren / funktions.subtrahieren / usw. als berechnung für LÖSUNG */
        double funktions_addieren(double input_a, double input_b) { return (input_a + input_b); }
        double funktions_subtrahieren(double input_a, double input_b)
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
        double funktions_multiplizieren(double input_a, double input_b) { return (input_a * input_b);}
        double funktions_dividieren_glatt(double input_a, double input_b) /* Ohne gleitkomma */
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
        double funktions_kindersachtext(double input_a) {
            return input_a / 4;
            
        }
        double funktions_timaufgabe(double input_a, double input_b) /* input_a = Anfangsgeld, input_b = Jahr */
        {
            double zaehler = 0;
            for(int i = 2;i < input_b;i++ )
            {
                zaehler += i;
            }
            return zaehler + input_a;
        }

        double funktions_timaufgabe_insgesamt(double input_a, double input_b) {
            double zaehler = 0;
            for (int i = 1; i < input_b; i++) {
                zaehler += funktions_timaufgabe(input_a, i);
            }
            return zaehler;
        }

    }
}
