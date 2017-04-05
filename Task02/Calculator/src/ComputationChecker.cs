namespace CSharpBasics.src
{
    using System;

    // class for caclulator verification
    public class ComputationChecker
    {
        public static void Main(string[] args)
        {
            Console.Title = "Custom exception usage in calculator";

            // creating calculator instance
            Computation calc = new Computation();

            bool isContinue = true;    // flag for computations to be continued

            while (isContinue)
            {
                try
                {
                    calc.Compute();
                }
                catch (OutOfModuloException exc)
                {
                    Console.WriteLine(exc);
                }
                catch (FormatException)
                {
                    Console.WriteLine("\n >> No computation will be perform! <<");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("\n >> No computation will be perform! <<");
                }
                finally
                {
                    Console.WriteLine("\nContinue? (y/n)");

                    isContinue = char.ToLower((char)Convert.ChangeType(Console.ReadLine(),
                                                                       typeof(char))) == 'y';

                    Console.WriteLine((isContinue ? "\nOk!\n------" : "Bye!"));
                }
            }
        }
    }
}
