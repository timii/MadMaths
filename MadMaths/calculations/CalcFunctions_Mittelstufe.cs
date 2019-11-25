using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MadMaths.calculations
{
    static public class CalcFunctions_Mittelstufe
    {
        static public Dictionary<string, Delegate> ms_funcs = new Dictionary<string, Delegate>()
        #region
        {
            {"Variablen1", new Func<int,int,int>(Variablen1)},
            {"Variablen2", new Func<int,int,int>(Variablen2)},
            {"Variablen3", new Func<int,int,int>(Variablen3)},
            {"Variablen4", new Func<int,int,int>(Variablen4)},
            {"Variablen5", new Func<int,int, int, int, string>(Variablen5)},
            {"Variablen6", new Func<double, double, double, double, string>(Variablen6)},
            {"Variablen7", new Func<double, double, double>(Variablen7)},
            {"Variablen8", new Func<double, double, double, double>(Variablen8)},
            {"Gleichungen1", new Func<double, double, double>(Gleichungen1)},
            {"Gleichungen2", new Func<double, double, double>(Gleichungen2)},
            {"Gleichungen3", new Func<double, double, double>(Gleichungen3)},
            {"Gleichungen4", new Func<double, double, double, double>(Gleichungen4)},
            {"Gleichungen5", new Func<double, double, double, double, double>(Gleichungen5)},
            {"Gleichungen6", new Func<double, double, double>(Gleichungen6)},
            {"Gleichungen7", new Func<double, double, double, double, double>(Gleichungen7)},
            {"Gleichungen8", new Func<double, double, double, double, double>(Gleichungen8)},
            {"Gleichungssystem1", new Func<double, double, double, double, double, double, string>(Gleichungssystem1)},
            {"Gleichungssystem2", new Func<double, double, double, double, double, double, string>(Gleichungssystem1)},
            {"Gleichungssystem3", new Func<double, double, double, double, double, double, string>(Gleichungssystem1)},
            {"Umwandeln1", new Func<double, double>(Umwandeln1)},
            {"Umwandeln2", new Func<double, double>(Umwandeln2)},
            {"Umwandeln3", new Func<double, double>(Umwandeln3)},
            {"Umwandeln4", new Func<double, double>(Umwandeln4)},
            {"Umwandeln5", new Func<double, double>(Umwandeln5)},
            {"Umwandeln6", new Func<double, double>(Umwandeln6)},
            {"Stochastik1", new Func<double>(Stochastik1)},
            {"Stochastik2", new Func<int,int,double>(Stochastik2)},
            {"Stochastik3", new Func<double>(Stochastik3)},
            {"Stochastik4", new Func<double>(Stochastik4)},
            {"Stochastik5", new Func<double>(Stochastik5)},
            {"Dreisatz1", new Func<double, double, double, double>(Dreisatz1)},
            {"Dreisatz2", new Func<double, double, double, double>(Dreisatz2)},
            {"Dreisatz3", new Func<double, double, double, double>(Dreisatz3)},
            {"Prozentrechnung1", new Func<double, double, double, double>(Prozentrechnung1)},
            {"Prozentrechnung2", new Func<double, double, double>(Prozentrechnung2)},
            {"Prozentrechnung3", new Func<double, double, double, double>(Prozentrechnung3)},
            {"BinomischeFormeln1", new Func<double, double, double, string>(BinomischeFormeln1)},
            {"BinomischeFormeln2", new Func<double, string>(BinomischeFormeln2)},
            {"BinomischeFormeln3", new Func<double, string>(BinomischeFormeln3)},
            {"BinomischeFormeln4", new Func<double, double, string>(BinomischeFormeln4)},
            {"Wurzeln1", new Func<double, double>(Wurzeln1)},
            {"Wurzeln2", new Func<double, double>(Wurzeln2)},
            {"QuadratischeGleichungen1", new Func<double, double, double, double>(QuadratischeGleichungen1)},
            {"Potenzen1", new Func<double, double, double>(Potenzen1)},
            {"Logarithmen1", new Func<double, double, double>(Logarithmen1)},
            {"Logarithmen2", new Func<double, double, double>(Logarithmen2)},
            {"Fakultät1", new Func<double, double>(Fakultät1)},
            {"Fakultät2", new Func<double, double, double>(Fakultät2)},
            {"Urnenmodell1", new Func<double, double, double>(Urnenmodell1)},
            {"Urnenmodell2", new Func<double, double, double>(Urnenmodell2)},
            {"Urnenmodell3", new Func<double, double>(Urnenmodell3)},
            {"HypergeometrischeVerteilung1", new Func<double, double, double, double, double>(HypergeometrischeVerteilung1)},
            {"Mittelwert1", new Func<double, double, double, double, double, double>(Mittelwert1)},
            {"Mittelwert2", new Func<double, double, double, double, double>(Mittelwert2)}
        };
        #endregion

        static private double hoch(double input_a, double hochzahl)
        {
            double ergebnis = 1;
            for (int i = 0; i < hochzahl; i++)
            {
                ergebnis *= input_a;
            }
            return ergebnis;
        }
        static private double Fakultät(double zahl)
        {
            if (zahl < 0)
                throw new ArgumentOutOfRangeException("Zahl darf nicht kleiner 0 sein");

            double fakultät = 1;

            if (zahl == 0 || zahl == 1)
                fakultät = 1;
            else
            {
                for (double i = 1; i <= zahl; i++)
                    fakultät *= i;
            }

            return fakultät;
        }
        static private double Binomialkoeffizient(double input_a, double input_b)
        {
            return (Fakultät(input_a) / Fakultät(input_b) * Fakultät(input_a - input_b));
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
        static public double Variablen7(double input_a, double input_b) { return input_a + input_b; }
        static public double Variablen8(double input_a, double input_b, double input_c) { return input_a * input_c + input_b * input_c; }
        static public double Gleichungen1(double input_a, double input_b) { return input_b - input_a; }
        static public double Gleichungen2(double input_a, double input_b) { return input_b - input_a; }
        static public double Gleichungen3(double input_a, double input_b) { return input_a + input_b; }
        static public double Gleichungen4(double input_a, double input_b, double input_c) { return input_c - input_a - input_b; }
        static public double Gleichungen5(double input_a, double input_b, double input_c, double input_d) { return input_a - input_b + input_c - input_d; }
        static public double Gleichungen6(double input_a, double input_b) { return input_b / input_a; }
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
        static public double Stochastik2(int input_a, int input_b) { if (input_a == input_b) { return 1 / 6; } return (2 / 6); }
        static public double Stochastik3() { return (3 / 6); }
        static public double Stochastik4() { return (3 / 6); }
        static public double Stochastik5() { return (1 / 4); }

        static public double Dreisatz1(double input_a, double input_b, double input_c) { return ((input_b * input_c) / input_a); }
        static public double Dreisatz2(double input_a, double input_b, double input_c) { return ((input_b * input_c) / input_a); }
        static public double Dreisatz3(double input_a, double input_b, double input_c) { return ((input_b * input_c) / input_a); }

        static public double Prozentrechnung1(double input_a, double input_b, double input_c) { return Math.Round(input_b * hoch((input_a * 0.01 + 1), input_c), 2); }
        static public double Prozentrechnung2(double input_a, double input_b) { return Math.Round(input_a * (input_b * 0.01), 2); }
        static public double Prozentrechnung3(double input_a, double input_b, double input_c) { return Math.Round(input_a * hoch(input_b * 0.01 + 1, input_c) - input_a, 2); }

        static public string BinomischeFormeln1(double input_a, double input_b, double input_c)
        {
            double x = Math.Sqrt(input_a);
            double y = Math.Sqrt(input_c);
            return "(" + x + "^2 + " + y + "^2)";

        }
        static public string BinomischeFormeln2(double input_a)
        {
            double x = Math.Pow(input_a, 2);
            return x + " " + 2 * input_a + "b + b^2";
        }
        static public string BinomischeFormeln3(double input_a)
        {
            double x = Math.Pow(input_a, 2);
            return x + " -" + 2 * input_a + "b + b^2";
        }
        static public string BinomischeFormeln4(double input_a, double input_b)
        {
            double x = Math.Pow(input_a, 2);
            return x + " - b^2";
        }
        static public double Wurzeln1(double input_a) { return Math.Sqrt(input_a); }
        static public double Wurzeln2(double input_a) { return Math.Sqrt(input_a); }
        static public double QuadratischeGleichungen1(double input_a, double input_b, double input_c)
        {
            double ergebnis;
            ergebnis = (input_b + Math.Sqrt(-4 * input_a * input_c)) / (input_a * 2);
            return ergebnis;
        }
        static public double Potenzen1(double input_a, double input_b)
        {
            return hoch(input_a, input_b);
        }
        static public double Logarithmen1(double input_a, double input_b)
        {
            return Math.Log(input_a, input_b);
        }
        static public double Logarithmen2(double input_a, double input_b)
        {
            double ergebnis;
            ergebnis = Math.Pow(input_a, 1 / input_b);
            return ergebnis;
        }
        static public double Fakultät1(double input_a)
        {
            return Fakultät(input_a);

        }
        static public double Fakultät2(double input_a, double input_b)
        {
            return (Fakultät(input_a) / Fakultät(input_b));
        }
        static public double Urnenmodell1(double input_a, double input_b)
        {
            return Math.Pow(input_a, input_b);
        }
        static public double Urnenmodell2(double input_a, double input_b)
        {
            return Binomialkoeffizient(input_a, input_b);
        }
        static public double Urnenmodell3(double input_a)
        {
            return Fakultät(input_a);
        }
        static public double HypergeometrischeVerteilung1(double input_a, double input_b, double input_c, double input_d)
        {
            return (Binomialkoeffizient(input_b, input_d) * Binomialkoeffizient(input_a - input_b, input_c - input_d)) / (Binomialkoeffizient(input_a, input_c));
        }
        static public double Mittelwert1(double input_a, double input_b, double input_c, double input_d, double input_e)
        {
            return (input_a + input_b + input_c + input_d + input_e) / 5;
        }
        static public double Mittelwert2(double input_a, double input_b, double input_c, double input_d)
        {
            return (input_a + input_b + input_c + input_d) / 4;
        }


    }
}
