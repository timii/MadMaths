using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MadMaths.calculations
{
    class CalcFunctions_Oberstufe
    {
        static public Dictionary<string, Delegate> os_funcs = new Dictionary<string, Delegate>()
        {
            //{"", new Func<>()},
        };

        static public string Ableiten1(double input_a, double input_b)
        {
            return (input_a * input_b) + "x^" + (input_b - 1);
        }
        static public string Ableiten2(double input_a, double input_b, double input_c, double input_d)
        {
            double vorx;
            if(input_b == input_d)
            {
                vorx = input_a + input_b;
                return (vorx * input_b) + "x^" + (input_b - 1);
            }
            else
            {
                return (input_a * input_b) + "x^" + (input_b - 1) + " + " + (input_c * input_d) + "x^" + (input_d-1);

            }
        }
        static public string Ableiten3(double input_a, double input_b, double input_c, double input_d, double input_e, double input_f)
        {
            double vorx;
            if (input_b == input_d && input_b == input_f)
            {
                vorx = input_a + input_b + input_c;
                return (vorx * input_b) + "x^" + (input_b - 1);
            }
            if(input_b == input_d || input_b == input_f || input_d == input_f)
            {
                if (input_b == input_d) {
                    vorx = input_a + input_c;
                    return (vorx * input_b) + "x^" + (input_b - 1) + " + " + (input_e * input_f) + "x^" + (input_f - 1);

                }
                if (input_b == input_f)
                {
                    vorx = input_a + input_e;
                    return (vorx * input_b) + "x^" + (input_b - 1) + " + " + (input_c * input_d) + "x^" + (input_d - 1);

                }
                if (input_d == input_f)
                {
                    vorx = input_c + input_e;
                    return (vorx * input_d) + "x^" + (input_d - 1) + " + " + (input_a * input_b) + "x^" + (input_b - 1);
                }
            }
            return (input_a * input_b) + "x^" + (input_b-1) + " + " + (input_c * input_d) + "x^" + (input_d-1) + " + " + (input_e * input_f) + "x^" + (input_f -1);

        }
        static public string Ableiten4(double input_a, double input_b, double input_c, double input_d, double input_e)
        {
            double vorx;
            if (input_b == input_d)
            {
                vorx = (input_a + input_b)*input_e;
                return (vorx * (input_b+1)) + "x^" + (input_b);
            }
            else
            {
                return ((input_a * input_e) * input_b) + "x^" + (input_b) + " + " + (input_c * input_e * input_d) + "x^" + (input_d);

            }
        }


        static public string Ableiten6(double input_a, double input_b, double input_c, double input_d, double input_e, double input_f)
        {
            if ((input_e)  == (input_b))
            {
                return "(" + (input_a * input_b * input_d - input_d * input_e * input_a) + "x^(" + (input_b + input_e - 1) + ") + (" + (input_a*input_b*input_f-input_d*input_c*input_e*-1) + "x^(" + (input_e-1) + "))/"
                    + "(" + input_d + "x^(" + input_e + ") + " + input_f + ")^2";

            }
            return "(" + (input_a * input_b * input_d - input_d * input_e * input_a) + "x^(" + (input_b + input_e - 1) + ") - " + (input_a * input_b * input_f*-1) + "x^(" + (input_b - 1) + ") + " + (input_d * input_c * input_e*-1) + "x^(" + (input_e - 1) + "))/"
                + "(" + input_d + "x^(" + input_e + ") + " + input_f + ")^2";

        }

    }
}
