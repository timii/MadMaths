using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadMaths.calculations
{
    static public class CalcFunctions_Oberstufe
    {
        static public Dictionary<string, Delegate> os_funcs = new Dictionary<string, Delegate>()
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
        };
        #endregion

        static public string Ableiten1(double input_a, double input_b)
        {
            return string.Format("{0}x^{1}", input_a*input_b, input_b-1);
        }
        static public string Ableiten2(double input_a, double input_b, double input_c, double input_d)
        {
            double vorx;
            if (input_b == input_d)
            {
                vorx = input_a + input_b;
                return string.Format("{0}x^{1}", vorx*input_b, input_b-1);
            }
            else
            {
                return string.Format("{0}x^{1} +  {2}x^{3}", input_a*input_b, input_b-1,input_c*input_d,input_d-1);

            }
        }
        static public string Ableiten3(double input_a, double input_b, double input_c, double input_d, double input_e, double input_f)
        {
            double vorx;
            if (input_b == input_d && input_b == input_f)
            {
                vorx = input_a + input_b + input_c;
                return string.Format("{0}x^{1}", vorx*input_b, input_b-1);
            }
            if (input_b == input_d || input_b == input_f || input_d == input_f)
            {
                if (input_b == input_d)
                {
                    vorx = input_a + input_c;
                    return string.Format("{0}x^{1} + {2}x^{3}", input_b*vorx, input_b-1,input_e*input_f,input_f-1);

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
            return string.Format("{0}x^{1} + {2}x^{3} + {4}x^{5}", input_a * input_a, input_b - 1, input_c * input_d, input_d - 1,input_e*input_f,input_f-1);
        }
        static public string Ableiten4(double input_a, double input_b, double input_c, double input_d, double input_e)
        {
            double vorx;
            if (input_b == input_d)
            {
                vorx = (input_a + input_b) * input_e;
                return string.Format("{0}x^{1}", vorx * (input_b-1), input_b);
            }
            else
            {
                return string.Format("{0}x^{1} + {2}x^{3}", input_a * input_e*input_b, input_b, input_c * input_e * input_d, input_d);

            }
        }

        static public string Ableiten5(int var1, int pot1, int var2, int pot2, int var3, int pot3, int var4, int pot4)
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
                        return string.Format("{0}x^{1}+{2}x^{3}", x1, --xpot1, x4, --xpot4);
                    }
                }
                else if (xpot1 == xpot4)
                {
                    x1 += x4;
                    x1 *= xpot1;
                    x3 *= xpot3;
                    return string.Format("{0}x^{1}+{2}x^{3}", x1, --xpot1, x3, --xpot3);
                }
                else if (xpot3 == xpot4)
                {
                    x2 = x3 + x4;
                    x2 *= xpot3;
                    x1 *= xpot1;
                    return string.Format("{0}x^{1}+{2}x^{3}", x1, --xpot1, x2, --xpot3);
                }
                else
                {
                    x1 *= xpot1;
                    x3 *= xpot3;
                    x4 *= xpot4;
                    return string.Format("{0}x^{1}+{2}x^{3}+{4}x^{5}", x1, --xpot1, x3, --xpot3, x4, --xpot4);
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
                    return string.Format("{0}x^{1}+{2}x^{3}", x1, --xpot1, x2, --xpot2);
                }
                else if (xpot2 == xpot4)
                {
                    x1 += x4;
                    x2 += x4;
                    x1 *= xpot1;
                    x2 *= xpot2;
                    return string.Format("{0}x^{1}+{2}x^{3}", x1, --xpot1, x2, --xpot2);
                }
                else
                {
                    x1 *= xpot1;
                    x2 *= xpot2;
                    x4 *= xpot4;
                    return string.Format("{0}x^{1}+{2}x^{3}+{4}x^{5}", x1, --xpot1, x2, --xpot2, x4, --xpot4);
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
                    return string.Format("{0}x^{1}+{2}x^{3}", x1, --xpot1, x2, --xpot2);
                }
                else
                {
                    x1 *= xpot1;
                    x2 *= xpot2;
                    x3 *= xpot3;
                    return string.Format("{0}x^{1}+{2}x^{3}+{4}x^{5}", x1, --xpot1, x2, --xpot2, x3, --xpot3);
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
                    return string.Format("{0}x^{1}+{2}x^{3}", x1, --xpot1, x2, --xpot2);
                }
                else
                {
                    x1 *= xpot1;
                    x2 *= xpot2;
                    x4 *= xpot4;
                    return string.Format("{0}x^{1}+{2}x^{3}+{4}x^{5}", x1, --xpot1, x2, --xpot2, x4, --xpot4);
                }
            }
            else if (xpot2 == xpot4)
            {
                x2 += x4;
                x1 *= xpot1;
                x2 *= xpot2;
                x3 *= xpot3;
                return string.Format("{0}x^{1}+{2}x^{3}+{4}x^{5}", x1, --xpot1, x2, --xpot2, x3, --xpot3);
            }
            else if (xpot3 == xpot4)
            {
                x3 += x4;
                x1 *= xpot1;
                x2 *= xpot2;
                x3 *= xpot3;
                return string.Format("{0}x^{1}+{2}x^{3}+{4}x^{5}", x1, --xpot1, x2, --xpot2, x3, --xpot3);
            }
            else
            {
                x1 *= xpot1;
                x2 *= xpot2;
                x3 *= xpot3;
                x4 *= xpot4;
                return string.Format("{0}x^{1}+{2}x^{3}+{4}x^{5}+{6}x^{7}", x1, --xpot1, x2, --xpot2, x3, --xpot3, x4, --xpot4);
            }
            #endregion
        }


        static public string Ableiten6(double input_a, double input_b, double input_c, double input_d, double input_e, double input_f)
        {
            if ((input_e) == (input_b))
            {
                return string.Format("({0}x^{1} + {2}x^{3})/({4}x^{5} + {6})^2", (input_a*input_b*input_d-input_d*input_e*input_a), (input_b - 1 + input_e), (input_a*input_b*input_f-input_d*input_c*input_e * -1 ), (input_e - 1),(input_d), (input_e), (input_f));


            }
            return string.Format("({0}x^{1} + {2}x^{3} + {4}x^{5})/({6}x^{7} + {8})^2", (input_a * input_b * input_d - input_d * input_e * input_a), (input_b - 1 + input_e),(input_a*input_b*input_f*-1),(input_b-1) , (input_d * input_c * input_e * -1), (input_e - 1), (input_d), (input_e), (input_f));

        }
        static public string Ableiten7(double input_a, double input_b)
        {
            return string.Format("{0}e^({1}x+{2}", (input_a),  (input_a), (input_b));
        }
        static public string Ableiten8(double input_a, double input_b, double input_c)
        {
            return string.Format("{0} * ({1}x - {2})^({3})", (input_a*input_c),(input_a),(input_b),(input_c-1));
        }
        static public string Ableiten9(double input_a, double input_b)
        {
            return string.Format("{0} * sin({1}x) + {2} * cos({3}x) * {4}x", input_a,input_b,input_b,input_b,input_a);
        }
        static public string HöherAbleiten1(double input_a, double input_b, double input_c)
        {
            int i;
            for(i = 0; i < input_a; i++)
            {

                input_b *= (input_c - i);
            }
            return string.Format("{0}x^{1}", input_b, input_c - 1);
        }
        static public string HöherAbleiten2(double input_a, double input_b, double input_c, double input_d)
        {
            return "";
        }
    }
}