using System;
using System.Collections.Generic;

namespace MadMaths.calculations
{
    static public class CalcFunctions_Mittelstufe
    {
        static public Dictionary<string, Delegate> ms_funcs = new Dictionary<string, Delegate>()
        #region
        {
            {"Variablen1", new Func<double,double,double>(Variablen1)},
            {"Variablen2", new Func<double,double,double>(Variablen2)},
            {"Variablen3", new Func<double,double,double>(Variablen3)},
            {"Variablen4", new Func<double,double,double>(Variablen4)},
            {"Variablen5", new Func<double,double, double, double, string>(Variablen5)},
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
            {"Gleichungssystem2", new Func<double, double, double, double, double, double, string>(Gleichungssystem2)},
            {"Gleichungssystem3", new Func<double, double, double, double, double, double, string>(Gleichungssystem3)},
            {"Umwandeln1", new Func<double, double>(Umwandeln1)},
            {"Umwandeln2", new Func<double, double>(Umwandeln2)},
            {"Umwandeln3", new Func<double, double>(Umwandeln3)},
            {"Umwandeln4", new Func<double, double>(Umwandeln4)},
            {"Umwandeln5", new Func<double, double>(Umwandeln5)},
            {"Umwandeln6", new Func<double, double>(Umwandeln6)},
            {"Stochastik1", new Func<int,double>(Stochastik1)},
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
            {"BinomischeFormeln4", new Func<double, string>(BinomischeFormeln4)},
            {"Wurzeln1", new Func<double, double>(Wurzeln1)},
            {"Wurzeln2", new Func<double, double>(Wurzeln2)},
            {"QuadratischeGleichungen1", new Func<double, double, double, string>(QuadratischeGleichungen1)},
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
        private static double Runden(double input)
        {
            return Math.Round(input, 2, MidpointRounding.ToEven);
        }
        private static double Hoch(double input_a, double hochzahl)
        {
            double ergebnis = 1;
            for (int i = 0; i < hochzahl; i++)
            {
                ergebnis *= input_a;
            }
            return ergebnis;
        }
        private static double Fakultät(double zahl)
        {
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
        private static double Binomialkoeffizient(double N, double K)
        {
            double result = 1;
            for (int i = 1; i <= K; i++)
            {
                result *= N - (K - i);
                result /= i;
            }
            return result;
        }
        public static double Variablen1(double input_a, double input_b) { return input_b - input_a; }
        public static double Variablen2(double input_a, double input_b) { return input_b + input_a; }
        public static double Variablen3(double input_a, double input_b) { return Runden(input_b / input_a); }
        public static double Variablen4(double input_a, double input_b) { return input_b * input_a; }
        public static string Variablen5(double input_a, double input_b, double input_c, double input_d)
        {
            Double ergebnis_a = input_a + input_b;
            Double ergebnis_b = input_c + input_d;
            return string.Format("{0}x + {1}y",ergebnis_a,ergebnis_b);
        }
        public static string Variablen6(double input_a, double input_b, double input_c, double input_d)
        {
            double ergebnis_a = input_a - input_c;
            double ergebnis_b = input_b + input_d;
            return string.Format("{0}x + {1}y", ergebnis_a, ergebnis_b);
        }
        public static double Variablen7(double input_a, double input_b) { return input_a + input_b; }
        public static double Variablen8(double input_a, double input_b, double input_c) { return input_a * input_c + input_b * input_c; }
        public static double Gleichungen1(double input_a, double input_b) { return input_b - input_a; }
        public static double Gleichungen2(double input_a, double input_b) { return input_b - input_a; }
        public static double Gleichungen3(double input_a, double input_b) { return input_a + input_b; }
        public static double Gleichungen4(double input_a, double input_b, double input_c) { return input_c - input_a - input_b; }
        public static double Gleichungen5(double input_a, double input_b, double input_c, double input_d) { return input_a - input_b + input_c - input_d; }
        public static double Gleichungen6(double input_a, double input_b) { return Runden(input_b / input_a); }
        public static double Gleichungen7(double input_a, double input_b, double input_c, double input_d) { return Runden((input_d - (input_b * input_c)) / input_a); }
        public static double Gleichungen8(double input_a, double input_b, double input_c, double input_d)
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
            return Runden(nummernseite / variablenseite);
        }

        public static string Gleichungssystem1(double input_a, double input_b, double input_c, double input_d, double input_e, double input_f)
        {
            double y = Math.Round(((input_c / input_a) - (input_f / input_d)) / ((input_b / input_a) - (input_e / input_d)),2,MidpointRounding.AwayFromZero);
            double x = Math.Round((input_c - input_b * y) / input_a,2);
            return string.Format("x = {0}, y = {1}", x, y);
            //return "x = " + x + ", y = " + y;

        }
        public static string Gleichungssystem2(double input_a, double input_b, double input_c, double input_d, double input_e, double input_f)
        {
            double y = Math.Round(((input_c / input_a) - (input_f / input_d)) / ((input_b / input_a) + (input_e / input_d)),2, MidpointRounding.AwayFromZero);
            double x = Math.Round((input_c - input_b * y) / input_a,2, MidpointRounding.AwayFromZero);

            return string.Format("x = {0}, y = {1}", x, y);
        }
        public static string Gleichungssystem3(double input_a, double input_b, double input_c, double input_d, double input_e, double input_f)
        {
            double y = Math.Round(((input_c / input_a) - (input_f / input_d)) / (-(input_b / input_a) + (input_e / input_d)),2, MidpointRounding.AwayFromZero);
            double x = Math.Round((input_c + input_b * y) / input_a,2,MidpointRounding.AwayFromZero);

            return string.Format("x = {0}, y = {1}", x, y);
            //return "x = " + x + ", y = " + y;
        }
        public static double Umwandeln1(double input_a) { return input_a / 1000; }
        public static double Umwandeln2(double input_a) { return input_a / 100; }
        public static double Umwandeln3(double input_a) { return input_a / 1000; }
        public static double Umwandeln4(double input_a) { return input_a * 1000; }
        public static double Umwandeln5(double input_a) { return input_a * 1000; }
        public static double Umwandeln6(double input_a) { return input_a * 100; }

        public static double Stochastik1(int _) { return Math.Round(1.0 / 6.0,2, MidpointRounding.AwayFromZero); }
        public static double Stochastik2(int input_a, int input_b) { if (input_a == input_b) { return Math.Round(1.0 / 6.0,2, MidpointRounding.AwayFromZero); } return Math.Round((2.0 / 6.0),2, MidpointRounding.AwayFromZero); }
        public static double Stochastik3() { return (3.0 / 6.0); }
        public static double Stochastik4() { return (3.0 / 6.0); }
        public static double Stochastik5() { return (1.0 / 4.0); }

        public static double Dreisatz1(double input_a, double input_b, double input_c) { return Math.Round(((input_b * input_c) / input_a),2, MidpointRounding.AwayFromZero); }
        public static double Dreisatz2(double input_a, double input_b, double input_c) { return Math.Round(((input_b * input_c) / input_a),2, MidpointRounding.AwayFromZero); }
        public static double Dreisatz3(double input_a, double input_b, double input_c) { return Runden((input_b * input_c) / input_a); }

        public static double Prozentrechnung1(double input_a, double input_b, double input_c) { return Math.Round(input_b * Hoch((input_a * 0.01 + 1), input_c), 2, MidpointRounding.AwayFromZero); }
        public static double Prozentrechnung2(double input_a, double input_b) { return Math.Round(input_a * (input_b * 0.01), 2, MidpointRounding.AwayFromZero); }
        public static double Prozentrechnung3(double input_a, double input_b, double input_c) { return Math.Round(input_a * Hoch(input_b * 0.01 + 1, input_c) - input_a, 2, MidpointRounding.AwayFromZero); }

        public static string BinomischeFormeln1(double input_a, double input_b, double input_c)
        {
            double x = Runden(Math.Sqrt(input_a));
            double y = Runden(Math.Sqrt(input_c));
            return string.Format("({0}x + {1})^2", x,y);

        }
        public static string BinomischeFormeln2(double input_a)
        {
            double x = Math.Pow(input_a, 2);
            return string.Format("{0} + {1}b + b^2", x, input_a*2);
        }
        public static string BinomischeFormeln3(double input_a)
        {
            double x = Math.Pow(input_a, 2);
            return string.Format("{0} - {1}b + b^2", x, input_a * 2);
        }
        public static string BinomischeFormeln4(double input_a)
        {
            double x = Math.Pow(input_a, 2);
            return string.Format("{0} - b^2", x);
        }
        public static double Wurzeln1(double input_a) { return Runden(Math.Sqrt(input_a)); }
        public static double Wurzeln2(double input_a) { return Runden(Math.Sqrt(input_a)); }
        public static string QuadratischeGleichungen1(double input_a, double input_b, double input_c)
        {
            double ergebnis1;
            double ergebnis2;
            ergebnis1 = (-input_b + Math.Sqrt(Math.Pow(input_b,2)- 4 * input_a * input_c)) / (input_a * 2);
            ergebnis2 = (-input_b - Math.Sqrt(Math.Pow(input_b,2)- 4 * input_a * input_c)) / (input_a * 2);


            return string.Format("{0} , {1}",Runden(ergebnis1),Runden(ergebnis2));
        }
        public static double Potenzen1(double input_a, double input_b)
        {
            return Math.Round(Hoch(input_a, input_b), 2, MidpointRounding.AwayFromZero);
        }
        public static double Logarithmen1(double input_a, double input_b)
        {
            return Math.Round(Math.Log(input_a, input_b), 2, MidpointRounding.AwayFromZero);
        }
        public static double Logarithmen2(double input_a, double input_b)
        {
            double ergebnis;
            ergebnis = Math.Pow(input_a, 1 / input_b);
            return Math.Round(ergebnis,2, MidpointRounding.AwayFromZero);
        }
        public static double Fakultät1(double input_a)
        {
            return Fakultät(input_a);

        }
        public static double Fakultät2(double input_a, double input_b)
        {
            return Runden(Fakultät(input_a) / Fakultät(input_b));
        }
        public static double Urnenmodell1(double input_a, double input_b)
        {
            return Math.Pow(input_a, input_b);
        }
        public static double Urnenmodell2(double input_a, double input_b)
        {
            return Binomialkoeffizient(input_a, input_b);
        }
        public static double Urnenmodell3(double input_a)
        {
            return Fakultät(input_a);
        }
        public static double HypergeometrischeVerteilung1(double input_a, double input_b, double input_c, double input_d)
        {
            return Math.Round((Binomialkoeffizient(input_b, input_d) * Binomialkoeffizient(input_a - input_b, input_c - input_d)) / (Binomialkoeffizient(input_a, input_c)), 2, MidpointRounding.AwayFromZero);
        }
        public static double Mittelwert1(double input_a, double input_b, double input_c, double input_d, double input_e)
        {
            return Runden((input_a + input_b + input_c + input_d + input_e) / 5);
        }
        public static double Mittelwert2(double input_a, double input_b, double input_c, double input_d)
        {
            return Runden((input_a + input_b + input_c + input_d) / 4);
        }


    }
}
