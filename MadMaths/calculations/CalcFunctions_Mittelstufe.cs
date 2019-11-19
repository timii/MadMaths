using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace MadMaths
{
    static public class CalcFunctions_Mittelstufe
    {
       static private double hoch(double input_a, double hochzahl)
        {
            double ergebnis = 1;
            for (int i = 0; i < hochzahl; i++)
            {
                ergebnis *= input_a;
            }
            return ergebnis;
        }
       static public int Variablen1(int input_a, int input_b) { return input_b - input_a; }
       static public int Variablen2(int input_a, int input_b) { return input_b + input_a; }
       static public int Variablen3(int input_a, int input_b) { return input_b / input_a; }
       static public int Variablen4(int input_a, int input_b) { return input_b * input_a; }
       static public string Variablen5(int input_a, int input_b, int input_c, int input_d)
        {
            int ergebnis_a = input_a + input_c;
            string ergebnis = ergebnis_a + "x";
            int ergebnis_b = input_b + input_d;
            ergebnis = ergebnis + " + " + ergebnis_b + "y";

            return ergebnis;
        }
       static public string Variablen6(double input_a, double input_b, double input_c, double input_d)
        {
            double ergebnis_a = input_a - input_c;
            string ergebnis = ergebnis_a + "x";
            double ergebnis_b = input_b + input_d;
            ergebnis = ergebnis + " + " + ergebnis_b + "y";

            return ergebnis;
        }
       static public double Variablen7(double input_a, double input_b){ return input_a + input_b; }
       static public double Variablen8(double input_a, double input_b, double input_c) { return input_a * input_c + input_b * input_c; }
       static public double Gleichungen1(double input_a, double input_b) { return input_b - input_a; }
       static public double Gleichungen2(double input_a, double input_b) { return input_b - input_a; }
       static public double Gleichungen3(double input_a, double input_b) { return input_a + input_b; }
       static public double Gleichungen4(double input_a, double input_b, double input_c) { return input_c - input_a - input_b; }
       static public double Gleichungen5(double input_a, double input_b, double input_c, double input_d) { return input_a - input_b + input_c - input_d; }
       static public double Gleichungen6(double input_a, double input_b) {return input_b / input_a; }
       static public double Gleichungen7(double input_a, double input_b, double input_c, double input_d) { return (input_d - (input_b * input_c)) / input_a; }
       static public double Gleichungen8(double input_a, double input_b, double input_c, double input_d)
        {
            double variablenseite;
            double nummernseite;
            if (input_a > input_d)
            {
                variablenseite = input_a - input_d;
                nummernseite = input_b * input_c;

            }
            else
            {
                variablenseite = input_d - input_a;
                nummernseite = (input_b * input_b) * (-1);
            }
            return (nummernseite / variablenseite);
        }

        static public string Gleichungssystem1(double input_a, double input_b, double input_c, double input_d, double input_e, double input_f)
        {
            double y = ((input_c / input_a) - (input_f / input_d)) / ((input_b / input_a) - (input_e / input_d));
            double x = (input_c - input_b * y) / input_a;

            return "x = " + x + " \ny = " + y;

        }
        static public string Gleichungssystem2(double input_a, double input_b, double input_c, double input_d, double input_e, double input_f)
        {
            double y = ((input_c / input_a) - (input_f / input_d)) / ((input_b / input_a) + (input_e / input_d));
            double x = (input_c - input_b * y) / input_a;


            return "x = " + x + " \ny = " + y;
        }
        static public string Gleichungssystem3(double input_a, double input_b, double input_c, double input_d, double input_e, double input_f)
        {
            double y = ((input_c / input_a) - (input_f / input_d)) / (-(input_b / input_a) + (input_e / input_d));
            double x = (input_c + input_b * y) / input_a;


            return "x = " + x + " \ny = " + y;
        }
        static public double Umwandeln1(double input_a) { return input_a / 1000; }
        static public double Umwandeln2(double input_a) { return input_a / 100; }
        static public double Umwandeln3(double input_a) { return input_a / 1000; }
        static public double Umwandeln4(double input_a) { return input_a * 1000; }
        static public double Umwandeln5(double input_a) { return input_a * 1000; }
        static public double Umwandeln6(double input_a) { return input_a * 100; }

        static public double Stochastik1() { return (1 / 6); }
        static public double Stochastik2() { return (2 / 6); }
        static public double Stochastik3() { return (3 / 6); }
        static public double Stochastik4() { return (3 /6); }
        static public double Stochastik5() { return (1 / 4); }

        static public double Dreisatz1(double input_a, double input_b, double input_c) { return ((input_b * input_c) / input_a); }
        static public double Dreisatz2(double input_a, double input_b, double input_c) { return ((input_b * input_c) / input_a); }
        static public double Dreisatz3(double input_a, double input_b, double input_c) { return ((input_b * input_c) / input_a); }
        
        static public double Prozentrechnung1(double input_a, double input_b, double input_c) {return Math.Round(input_b*hoch((input_a * 0.01 + 1), input_c),2);}
        static public double Prozentrechnung2(double input_a, double input_b) { return Math.Round(input_a*(input_b*0.01), 2); }
        static public double Prozentrechnung3(double input_a, double input_b, double input_c) {return Math.Round(input_a*hoch(input_b*0.01+1,input_c)-input_a, 2);}

        static public string BinomischeFormeln1(double input_a, double input_b, double input_c)
        {
            double x = Math.Sqrt(input_a);
            double y = Math.Sqrt(input_c);
            return "(" + x + "^2 + " + y + "^2)";

        }
        static public string BinomischeFormeln2(double input_a)
        {
            double x = Math.Pow(input_a, 2);
            return x +" "+  input_a + "b + b^2"; 
        }
        static public string BinomischeFormeln3(double input_a)
        {
            double x = Math.Pow(input_a, 2);
            return x + " -" + input_a + "b + b^2";
        }
        static public string BinomischeFormeln2(double input_a, double input_b)
        {
            double x = Math.Pow(input_a, 2);
            return x + " - b^2";
        }
        static public double Wurzeln1(double input_a) { return Math.Sqrt(input_a); }
        static public double Wurzeln2(double input_a) { return Math.Sqrt(input_a); }



    }
}
