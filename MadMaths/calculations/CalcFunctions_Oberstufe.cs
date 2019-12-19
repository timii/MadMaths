using System;
using System.Collections.Generic;

namespace MadMaths.calculations
{
    static public class CalcFunctions_Oberstufe
    {
        public static Dictionary<string, Delegate> os_funcs = new Dictionary<string, Delegate>()
        #region
        {
            {"Ableiten1", new Func<double, double, string>(Ableiten1)},
            {"Ableiten2", new Func<double, double, double, double, string>(Ableiten2)},
            {"Ableiten3", new Func<double, double, double, double, double, double, string>(Ableiten3)},
            {"Ableiten4", new Func<double, double, double, double, double, string>(Ableiten4)},
            {"Ableiten5", new Func<int, int, int, int, int, int, int, int, string>(Ableiten5)},
            {"Ableiten6", new Func<double, double, double, double, double, double, string>(Ableiten6)},
            {"Ableiten7", new Func<double, double, string>(Ableiten7)},
            {"Ableiten8", new Func<double, double, double, string>(Ableiten8)},
            {"Ableiten9", new Func<double, double, string>(Ableiten9)},
            {"HöherAbleiten1", new Func<double, double, double, string>(HöherAbleiten1)},
            {"HöherAbleiten2", new Func<double, double, double, double, double, string>(HöherAbleiten2)},
            {"Wendepunkte1", new Func<double, double, double, double, string>(Wendepunkte1)},
            {"Integralregel1", new Func<string>(Intergralregel1)},
            {"Integralregel2", new Func<string>(Intergralregel2)},
            {"Integralregel3", new Func<string>(Intergralregel3)},
            {"Integral1", new Func<double, double, double, double, double>(Integral1)},
            {"Integral2", new Func<double>(Integral2)},
            {"SchwerIntegrieren1", new Func<double, double, double, double>(SchwerIntegrieren1)},
            {"SymmetrieI", new Func<double, double, double, double,double,double,string>(SymmetrieI) },
            {"ExtrempunktI", new Func<double, double, double, double, string>(ExtrempunktI)},
            {"NullstellenI", new Func<double, double, double, double, string>(NullstellenI)},
        };
        #endregion
        private static double runden(double input)
        {
            return Math.Round(input, 2, MidpointRounding.ToEven);
        }
        //Ableiten
        #region
        public static string Ableiten1(double input_a, double input_b)
        {
            return string.Format("{0}x^{1}", input_a * input_b, input_b - 1);
        }
        public static string Ableiten2(double input_a, double input_b, double input_c, double input_d)
        {
            double vorx;
            if (input_b == input_d)
            {
                vorx = input_a + input_b;
                return string.Format("{0}x^{1}", vorx * input_b, input_b - 1);
            }
            else
            {
                return string.Format("{0}x^{1} +  {2}x^{3}", input_a * input_b, input_b - 1, input_c * input_d, input_d - 1);

            }
        }
        public static string Ableiten3(double input_a, double input_b, double input_c, double input_d, double input_e, double input_f)
        {
            double vorx;
            if (input_b == input_d && input_b == input_f)
            {
                vorx = input_a + input_b + input_c;
                return string.Format("{0}x^{1}", vorx * input_b, input_b - 1);
            }
            if (input_b == input_d || input_b == input_f || input_d == input_f)
            {
                if (input_b == input_d)
                {
                    vorx = input_a + input_c;
                    return string.Format("{0}x^{1} + {2}x^{3}", input_b * vorx, input_b - 1, input_e * input_f, input_f - 1);

                }
                if (input_b == input_f)
                {
                    vorx = input_a + input_e;
                    return string.Format("{0}x^{1} + {2}x^{3}", input_b * vorx, input_b - 1, input_c * input_d, input_d - 1);

                }
                if (input_d == input_f)
                {
                    vorx = input_c + input_e;
                    return string.Format("{0}x^{1} + {2}x^{3}", input_a * input_b, input_b - 1, vorx * input_d, input_d - 1);
                }
            }
            return string.Format("{0}x^{1} + {2}x^{3} + {4}x^{5}", input_a * input_a, input_b - 1, input_c * input_d, input_d - 1, input_e * input_f, input_f - 1);
        }
        public static string Ableiten4(double input_a, double input_b, double input_c, double input_d, double input_e)
        {
            double vorx;
            if (input_b == input_d)
            {
                vorx = (input_a + input_b) * input_e;
                return string.Format("{0}x^{1}", vorx * (input_b - 1), input_b);
            }
            else
            {
                return string.Format("{0}x^{1} + {2}x^{3}", input_a * input_e * input_b, input_b, input_c * input_e * input_d, input_d);

            }
        }

        public static string Ableiten5(int var1, int pot1, int var2, int pot2, int var3, int pot3, int var4, int pot4)
        {
            #region
            int x1, x2, x3, x4;
            int xpot1, xpot2, xpot3, xpot4;
            x1 = var1 * var3;
            xpot1 = pot1 + pot3;
            x2 = var1 * var4;
            xpot2 = pot1 + pot4;
            x3 = var2 * var3;
            xpot3 = pot2 + pot3;
            x4 = var2 * var4;
            xpot4 = pot2 + pot4;
            if (xpot1 == xpot2)
            {
                x1 += x2;
                if (xpot1 == xpot3)
                {
                    x1 += x3;
                    if (xpot1 == xpot4)
                    {
                        x1 += x4;
                        x1 *= xpot1;
                        return string.Format("{0}x^{1}", x1, --xpot1);
                    }
                    else
                    {
                        x1 *= xpot1;
                        x4 *= xpot4;
                        return string.Format("{0}x^{1} + {2}x^{3}", x1, --xpot1, x4, --xpot4);
                    }
                }
                else if (xpot1 == xpot4)
                {
                    x1 += x4;
                    x1 *= xpot1;
                    x3 *= xpot3;
                    return string.Format("{0}x^{1} + {2}x^{3}", x1, --xpot1, x3, --xpot3);
                }
                else if (xpot3 == xpot4)
                {
                    x2 = x3 + x4;
                    x2 *= xpot3;
                    x1 *= xpot1;
                    return string.Format("{0}x^{1} + {2}x^{3}", x1, --xpot1, x2, --xpot3);
                }
                else
                {
                    x1 *= xpot1;
                    x3 *= xpot3;
                    x4 *= xpot4;
                    return string.Format("{0}x^{1} + {2}x^{3} + {4}x^{5}", x1, --xpot1, x3, --xpot3, x4, --xpot4);
                }
            }
            else if (xpot1 == xpot3)
            {
                x1 += x3;
                if (xpot1 == xpot4)
                {
                    x1 += x4;
                    x1 *= xpot1;
                    x2 *= xpot2;
                    return string.Format("{0}x^{1} + {2}x^{3}", x1, --xpot1, x2, --xpot2);
                }
                else if (xpot2 == xpot4)
                {
                    x1 += x4;
                    x2 += x4;
                    x1 *= xpot1;
                    x2 *= xpot2;
                    return string.Format("{0}x^{1} + {2}x^{3}", x1, --xpot1, x2, --xpot2);
                }
                else
                {
                    x1 *= xpot1;
                    x2 *= xpot2;
                    x4 *= xpot4;
                    return string.Format("{0}x^{1} + {2}x^{3} + {4}x^{5}", x1, --xpot1, x2, --xpot2, x4, --xpot4);
                }
            }
            else if (xpot1 == xpot4)
            {
                x1 += x4;
                if (xpot2 == xpot3)
                {
                    x2 += x3;
                    x1 *= xpot1;
                    x2 *= xpot2;
                    return string.Format("{0}x^{1} + {2}x^{3}", x1, --xpot1, x2, --xpot2);
                }
                else
                {
                    x1 *= xpot1;
                    x2 *= xpot2;
                    x3 *= xpot3;
                    return string.Format("{0}x^{1} + {2}x^{3} + {4}x^{5}", x1, --xpot1, x2, --xpot2, x3, --xpot3);
                }
            }
            else if (xpot2 == xpot3)
            {
                x2 += x3;
                if (xpot2 == xpot4)
                {
                    x2 += x4;
                    x1 *= xpot1;
                    x2 *= xpot2;
                    return string.Format("{0}x^{1} + {2}x^{3}", x1, --xpot1, x2, --xpot2);
                }
                else
                {
                    x1 *= xpot1;
                    x2 *= xpot2;
                    x4 *= xpot4;
                    return string.Format("{0}x^{1} + {2}x^{3} + {4}x^{5}", x1, --xpot1, x2, --xpot2, x4, --xpot4);
                }
            }
            else if (xpot2 == xpot4)
            {
                x2 += x4;
                x1 *= xpot1;
                x2 *= xpot2;
                x3 *= xpot3;
                return string.Format("{0}x^{1} + {2}x^{3} + {4}x^{5}", x1, --xpot1, x2, --xpot2, x3, --xpot3);
            }
            else if (xpot3 == xpot4)
            {
                x3 += x4;
                x1 *= xpot1;
                x2 *= xpot2;
                x3 *= xpot3;
                return string.Format("{0}x^{1} + {2}x^{3} + {4}x^{5}", x1, --xpot1, x2, --xpot2, x3, --xpot3);
            }
            else
            {
                x1 *= xpot1;
                x2 *= xpot2;
                x3 *= xpot3;
                x4 *= xpot4;
                return string.Format("{0}x^{1} + {2}x^{3} + {4}x^{5} + {6}x^{7}", x1, --xpot1, x2, --xpot2, x3, --xpot3, x4, --xpot4);
            }
            #endregion
        }


        public static string Ableiten6(double input_a, double input_b, double input_c, double input_d, double input_e, double input_f)
        {
            if ((input_e) == (input_b))
            {
                return string.Format("({0}x^{1} + {2}x^{3})/({4}x^{5} + {6})^2", (input_a * input_b * input_d - input_d * input_e * input_a), (input_b - 1 + input_e), (input_a * input_b * input_f - input_d * input_c * input_e * -1), (input_e - 1), (input_d), (input_e), (input_f));


            }
            return string.Format("({0}x^{1} + {2}x^{3} + {4}x^{5})/({6}x^{7} + {8})^2", (input_a * input_b * input_d - input_d * input_e * input_a), (input_b - 1 + input_e), (input_a * input_b * input_f * -1), (input_b - 1), (input_d * input_c * input_e * -1), (input_e - 1), (input_d), (input_e), (input_f));

        }
        public static string Ableiten7(double input_a, double input_b)
        {
            return string.Format("{0}e^({1}x + {2}", (input_a), (input_a), (input_b));
        }
        public static string Ableiten8(double input_a, double input_b, double input_c)
        {
            return string.Format("{0} * ({1}x - {2})^{3}", (input_a * input_c), (input_a), (input_b), (input_c - 1));
        }
        public static string Ableiten9(double input_a, double input_b)
        {
            return string.Format("{0} * sin({1}x) + {2} * cos({3}x) * {4}x", input_a, input_b, input_b, input_b, input_a);
        }
        public static string HöherAbleiten1(double input_a, double input_b, double input_c)
        {
            int i;
            for (i = 0; i < input_a; i++)
            {

                input_b *= (input_c - i);
            }
            if (input_b == 0)
            {
                return "0";
            }
            return string.Format("{0}x^{1}", input_b, input_c - i);
        }
        public static string HöherAbleiten2(double input_a, double input_b, double input_c, double input_d, double input_e)
        {
            double vorx1 = input_a * (input_b + 1) * input_e * input_b;
            double vorx2 = input_c * (input_d + 1) * input_e * input_d;
            if (input_b == input_d)
            {
                double zusammenx = vorx1 + vorx2;
                return string.Format("{0}x^{1}", zusammenx, input_d - 1);
            }
            return string.Format("{0}x^{1} + {2}x^{3}", vorx1, input_b - 1, vorx2, input_d - 1);
        }
        #endregion
        public static string Wendepunkte1(double input_a, double input_b, double input_c, double input_d)
        {
            string Lösung = "";

            double vorx1 = input_a * input_b * (input_b-1);
            double vorx2 = input_c * input_d * (input_d-1);
            double extr; //extremstelle
            double LoesHilf;
            //Keine EP wenn 2. ABleitung 0
            if (input_b - 3 < 0 && input_d - 3 < 0)
            {
                Lösung += "NaN";
                return Lösung;
            }

            if (((vorx1 * Math.Pow(0, input_b - 2) + vorx2 * Math.Pow(0, input_d - 2)) == 0) && ((vorx1 * (input_b - 2) * Math.Pow(0, input_b - 3) + vorx2 * (input_d - 2) * Math.Pow(0, input_d - 3)) != 0))
            {
                Lösung += "(0;0),";
            }

            if (input_d > input_b)
            {
                extr = Math.Pow(((-1 * vorx1) / vorx2), 1 / ((input_d - 2) - (input_b - 2)));
            }

            else
            {
                extr = Math.Pow(((-1 * vorx2) / vorx1), 1 / ((input_b - 2) - (input_d - 2)));
            }

            if ((vorx1 * (input_b - 2) + vorx2 * (input_d - 2) * Math.Pow(extr, input_d - 3)) != 0)
            {
                LoesHilf = (input_a * Math.Pow(extr, input_b) + input_c * Math.Pow(extr, input_d));
                if (string.Format("({0};{1})", runden(extr), runden(LoesHilf)) + "," == Lösung)
                {
                    return Lösung;
                }
                Lösung += string.Format("({0};{1})", runden(extr), runden(LoesHilf));
            }
            if (Lösung == "")
            {
                Lösung += "NaN";
            }
            return Lösung;


        }
        //Integral
        #region
        public static string Intergralregel1()
        {
            return "-cos(x) + c";
        }
        public static string Intergralregel2()
        {
            return "sin(x) + c";
        }
        public static string Intergralregel3()
        {
            return "x * ln(x) - x + c";
        }
        public static double Integral1(double input_a, double input_b, double input_c, double input_d)
        {
            double stamm_a = input_a / 2;
            double stamm_b = input_b;
            return Math.Round((input_d * input_d * stamm_a + input_d * input_b) - (input_c * input_c * stamm_a + input_d * input_b),2, MidpointRounding.AwayFromZero);
        }
        public static double Integral2()
        {
            return 1 / 3;
        }

        public static double SchwerIntegrieren1(double input_a, double input_b, double input_c)
        {
            double tmp;
            double x1 = (-(input_a - 1) + Math.Sqrt(Math.Pow((input_a - 1), 2) - 4 * (input_b * input_c))) / 2;
            double x2 = (-(input_a - 1) - Math.Sqrt(Math.Pow((input_a - 1), 2) - 4 * (input_b * input_c))) / 2;
            if (x1 > x2)
            {
                tmp = x1;
                x1 = x2;
                x2 = tmp;
            }
            double Flaeche_Hilfe1 = (1 / 3) * Math.Pow(x2, 3) + (input_a / 2) * Math.Pow(x2, 2) + input_b * x2;
            double Flaeche_Hilfe2 = (1 / 3) * Math.Pow(x1, 3) + (input_a / 2) * Math.Pow(x1, 2) + input_b * x1;
            double Flaeche1 = Flaeche_Hilfe1 - Flaeche_Hilfe2;

            Flaeche_Hilfe1 = (1 / 2) * Math.Pow(x2, 2) + input_c * x2;
            Flaeche_Hilfe2 = (1 / 2) * Math.Pow(x1, 2) + input_c * x1;
            double Flaeche2 = Flaeche_Hilfe1 - Flaeche_Hilfe2;
            if (Flaeche1 < Flaeche2)
            {
                tmp = Flaeche2;
                Flaeche2 = Flaeche1;
                Flaeche1 = tmp;
            }

            return Math.Round(Flaeche1 - Flaeche2,2, MidpointRounding.AwayFromZero);
        }
        #endregion
        public static string SymmetrieI(double a, double b, double c, double d, double e, double f)
        {
            int Zaehler = 0;
            for (int i = 0; i < 50; i++)
            {
                if ((a * Math.Pow(-i, b) + c * Math.Pow(-i, d) + e * Math.Pow(-i, f) == (a * Math.Pow(i, b) + c * Math.Pow(i, d) + e * Math.Pow(i, f))))
                {
                    Zaehler++;
                }
                else
                {
                    break;
                }
            }
            if (Zaehler == 50)
            {
                return "Achsensymmetrisch";
            }
            if (b % 2 != 0 && d % 2 != 0 && f % 2 != 0)
            {
                return "Punktsymmetrisch";
            }


            return "Asymmetrisch";
        }
        public static string SymmetrieII(double a, double b, double c, double d)
        {
            int Zaehler = 0;
            for (int i = 0; i < 50; i++)
            {
                if ((a * Math.Pow(-i, b) + c * Math.Pow(-i, d) == (a * Math.Pow(i, b) + c * Math.Pow(i, d))))
                {
                    Zaehler++;
                }
                else
                {
                    break;
                }
            }
            if (Zaehler == 50)
            {
                return "Achsensymmetrisch";
            }
            if (b % 2 != 0 && d % 2 != 0)
            {
                return "Punktsymmetrisch";
            }


            return "Asymmetrisch";
        }
        public static string ExtrempunktI(double input_a, double input_b, double input_c, double input_d)
        {
            string Lösung = "";

            double vorx1 = input_a * input_b;
            double vorx2 = input_c * input_d;   
            double xextr = 0; //extremstelle
            double yextr = 0; //y Wert der ES
            //Keine EP wenn 2. ABleitung 0
            if (input_b-2 < 0 && input_d-2 < 0)
            {
                double vorx = vorx1 + vorx2;
                if (vorx == 0)
                {
                    Lösung += "NaN";
                    return Lösung;
                }
            }

            if (((vorx1 * Math.Pow(0,input_b-1)+ vorx2 * Math.Pow(0,input_d-1)) == 0))
            {
                Lösung+=  "(0;0),";
            }

            if (input_d > input_b)
            {
                xextr = Math.Pow(((-1 * vorx1) / vorx2), 1/((input_d - 1) - (input_b - 1)));
            }   

            else
            {
                xextr = Math.Pow(((-1 * vorx2) / vorx1), 1/((input_b - 1) - (input_d - 1)));
            }
            
            if ((vorx1 * (input_b - 1) + vorx2 * (input_d - 1) * Math.Pow(xextr, input_d - 2)) != 0)
            {
                yextr = (input_a * Math.Pow(xextr, input_b) + input_c * Math.Pow(xextr, input_d));
                if (string.Format("({0};{1})", runden(xextr), runden(yextr))+"," == Lösung)
                {
                    return Lösung;
                }
                Lösung+=  string.Format("({0};{1})", runden(xextr), runden(yextr));
            }

            if (SymmetrieII(input_a,input_b,input_c,input_d) == "Punktsymmetrisch")
            {
                Lösung+= string.Format("({0};{1})", runden(-xextr), runden(-yextr));
            }
            if (SymmetrieII(input_a, input_b, input_c, input_d) == "Achsensymmetrisch")
            {
                Lösung += string.Format("({0};{1})", runden(-xextr), runden(yextr));
            }
            if (Lösung == "")
            {
                Lösung += "NaN";
            }
            return Lösung;


        }

        public static string NullstellenI(double input_a, double input_b, double input_c, double input_d)
        {
            double vorx;
            double pot;
            string Loesung = "(0;0)";
            if (input_b == input_d)
            {

                vorx = input_a + input_c;
                if (vorx == 0)
                {
                    return "NaN";
                }

                return Loesung;
            }
            else if (input_b > input_d)
            {
                vorx = (-1 * input_c) / input_a;
                pot = 1/(input_b - input_d);
            } 
            else
            {
                vorx = (-1 * input_a) / input_c;
                pot = 1/(input_d - input_b);
            }
            
            double NS= Math.Pow(vorx, pot);
            Loesung += string.Format(" ({0};0)",runden(NS));
            if (SymmetrieII(input_a,input_b,input_c,input_d) == "Punktsymmetrisch")
            {
                Loesung += string.Format(" ({0};0)", runden(-NS));
            }
            if (SymmetrieII(input_a, input_b, input_c, input_d) == "Achsensymmetrisch")
            {
                Loesung += string.Format(" ({0};0)", runden(-NS));
            }
            return Loesung;
        }

    }
}
