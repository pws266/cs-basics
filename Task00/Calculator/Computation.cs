namespace MainApp
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    using Library;

    // simple calculator implementation
    public sealed class Computation
    {
        private delegate double Action(double x, double y);

        private static char separator;   // separator sign in float point value representation
        // char array for possible float point separator values searching
        private static char[] separatorSignsArray = ".,".ToCharArray();

        // reads arguments and mathematical operation sign
        private static T GetArgument<T>(String message)
        {
            Console.Write(message + ": ");

            String data = Console.ReadLine();
            T result = default(T);

            // replacing illegal separator sign in float point data representation
            if (result is double)
            {
                int symbolPos = data.IndexOfAny(separatorSignsArray);

                if (symbolPos != -1 && data.ElementAt<char>(symbolPos) != separator)
                {
                    StringBuilder sb = new StringBuilder(data);
                    sb[symbolPos] = separator;

                    data = sb.ToString();
                }
            }

            try
            {
                result = (T)Convert.ChangeType(data, typeof(T));
            }
            catch (FormatException exc)
            {
                Console.WriteLine("Error! Illegal format of argument \"" + message + "\"");
                Console.WriteLine("Description: " + exc.Message);

                throw new FormatException();
            }
            catch (OverflowException exc)
            {
                Console.WriteLine("Error! Argument \"" + message + "\" is out of type \"" + 
                                  result.GetType() + "\" range");
                Console.WriteLine("Description: " + exc.Message);

                throw new OverflowException();
            }

            return result;
        }

        public static void Main(string[] args)
        {
            Console.Title = "Basic calculator";

            // getting separator sign
            CultureInfo ci = new CultureInfo("ru-ru", false);
            separator = ci.NumberFormat.NumberDecimalSeparator.ElementAt<char>(0);

            // getting arguments and mathematical operations sign
            double x = default(double); 
            char sign = default(char); 
            double y = default(double);

            Action mathAction;

            try
            {
                x = Computation.GetArgument<double>("First argument");
                sign = Computation.GetArgument<char>("Operation");

                // calculator's operation selection
                switch (sign)
                {
                    case '+':
                        mathAction = Calculator.add;
                        break;

                    case '-':
                        mathAction = Calculator.sub;
                        break;

                    default:
                        Console.WriteLine("\n>> Unknown operation. No computation will be perform! <<");
                        return;
                }                

                y = Computation.GetArgument<double>("Operation");
            }
            catch (FormatException)
            {
                Console.WriteLine("\n >> Abnormal program termination! <<");
                return;
            }
            catch (OverflowException)
            {
                Console.WriteLine("\n >> Abnormal program termination! <<");
                return;
            }

            // performing computation according to selected operation
            double result = mathAction(x, y);
            Console.WriteLine(" > {0} {1} {2} = {3}", x, sign, y, result);
        }
    }
}
