using System;
using System.Globalization;
using System.Linq;
using System.Text;

using Library;

namespace CSharpBasics
{
    // simple calculator implementation
    public sealed class Computation
    {
        private static char separator;   // separator sign in float point value representation
        // char array for possible float point separator values searching
        private static char[] separator_signs_array = ".,".ToCharArray();

        private static double abs_bound = 10;

        public Computation()
        {
            if (separator == default(char))
            {
                // getting separator sign
                CultureInfo ci = new CultureInfo("ru-ru", false);
                separator = ci.NumberFormat.NumberDecimalSeparator.ElementAt<char>(0);
            }
        }

        // reads arguments and mathematical operation sign
        private static T getArgument<T>(String message)
        {
            Console.Write(message);

            String data = Console.ReadLine();
            T result = default(T);

            // replacing illegal separator sign in float point data representation
            if (result is double)
            {
                int symbolPos = data.IndexOfAny(separator_signs_array);

                if (symbolPos != -1 && data.ElementAt<char>(symbolPos) != separator)
                {
                    StringBuilder sb = new StringBuilder(data);
                    sb[symbolPos] = separator;

                    data = sb.ToString();
                }
            }

            result = (T)Convert.ChangeType(data, typeof(T));

            return result;
        }

        public void Compute()
        {
            // getting arguments and mathematical operations sign
            double x = Computation.getArgument<double>("First argument: ");
            if (Math.Abs(x) > abs_bound)
                throw new OutOfModuloException(String.Format("Error: First argument is greater than modulo {0}", abs_bound));

            char sign = Computation.getArgument<char>("Operation: ");

            double y = Computation.getArgument<double>("Second argument: ");
            if (Math.Abs(y) > abs_bound)
                throw new OutOfModuloException(String.Format("Error: Second argument is greater than modulo {0}", abs_bound));


            string answer = string.Format(" > {0} {1} {2} = ", x, sign, y);
            double result = 0;

            // performing computation
            switch(sign)
            {
                case '+':
                    result = Calculator.add(x, y);
                    answer += Convert.ToString(result);
                    break;
                case '-':
                    result = Calculator.sub(x, y);
                    answer += Convert.ToString(result);
                    break;
                default:
                    answer = "Unknown operation. No result";
                    break;
            }

            Console.WriteLine(answer);
        }
    }

    // caclulator verification
    class VerifyComputation
    {
        public static void Main(string[] args)
        {
            // creating calculator instance
            Computation calc = new Computation();

            bool is_continue = true;    // flag for computations to be continued

            while (is_continue)
            {
                try
                {
                    calc.Compute();
                }
                catch (OutOfModuloException exc)
                {
                    Console.WriteLine(exc);
                }
                finally
                {
                    Console.WriteLine("\nContinue? (y/n)");

                    is_continue = char.ToLower(
                        (char)Convert.ChangeType(Console.ReadLine(),
                                                 typeof(char))) == 'y';

                    Console.WriteLine((is_continue ? "\nOk!\n------" : "Bye!"));
                }
            }
        }

    }
}
