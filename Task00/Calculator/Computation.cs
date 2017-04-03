using System;
using System.Globalization;
using System.Linq;
using System.Text;

using Library;

namespace MainApp
{
    // simple calculator implementation
    public sealed class Computation
    {
        private static char separator;   // separator sign in float point value representation
        // char array for possible float point separator values searching
        private static char[] separator_signs_array = ".,".ToCharArray();

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

        public static void Main(string[] args)
        {
            // getting separator sign
            CultureInfo ci = new CultureInfo("ru-ru", false);
            separator = ci.NumberFormat.NumberDecimalSeparator.ElementAt<char>(0);

            // getting arguments and mathematical operations sign
            double x = Computation.getArgument<double>("First argument: ");
            char sign = Computation.getArgument<char>("Operation: ");
            double y = Computation.getArgument<double>("Second argument: ");

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
}
