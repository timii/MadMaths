using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadMaths
{
    public class CalcFunctions_Mittelstufe
    {
        int Variablen1(int input_a, int input_b) { return input_b - input_a; }
        int Variablen2(int input_a, int input_b) { return input_b + input_a; }
        int Variablen3(int input_a, int input_b) { return input_b / input_a; }
        int Variablen4(int input_a, int input_b) { return input_b * input_a; }
        string Variablen5(int input_a, int input_b, int input_c, int input_d)
        {
            int ergebnis_a = input_a + input_c;
            string ergebnis = ergebnis_a + "x";
            int ergebnis_b = input_b + input_d;
            ergebnis = ergebnis + " + " + ergebnis_b + "y";

            return ergebnis;
        }
        string Variablen6(int input_a, int input_b, int input_c, int input_d)
        {
            int ergebnis_a = input_a - input_c;
            string ergebnis = ergebnis_a + "x";
            int ergebnis_b = input_b + input_d;
            ergebnis = ergebnis + " + " + ergebnis_b + "y";

            return ergebnis;
        }
        int Variablen7(int input_a, int input_b){ return input_a + input_b; }
        int Variablen8(int input_a, int input_b,int input_c) { return input_a * input_c + input_b * input_c; }






    }
}
