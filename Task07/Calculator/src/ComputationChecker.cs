namespace CSharpBasics.src
{
    using System;

    // caclulator verification
    public class ComputationChecker
    {
        public static void Main(string[] args)
        {
            Console.Title = "Calculator via XML";

            // checking command line arguments number
            if (args.Length != 2)
            {
                Console.WriteLine("Illegal arguments number\nUsage: Calculator.exe " + 
                                  "<InputFileName.xml> <OutputFileName.xml>");
                return;
            }

            // creating calculator instance
            Computation calc = new Computation();

            // reading operand and operation sets from input *.xml
            InputData input = InputData.ParseXML(args[0]);
            if (input == null)
            {
                return;
            }

            // creating storage for operation results saving
            OutputData output = new OutputData();

            OperandElement result;

            // performing computation
            for (int i = 0; i < input.InputElements.Count; i += 3)
            {
                result = calc.Compute((OperandElement)input.InputElements[i],
                                      (OperationElement)input.InputElements[i + 1],
                                      (OperandElement)input.InputElements[i + 2]);

                output.OutputElements.Add(result);
            }

            // saving computation results to *.xml
            OutputData.SaveToXML(args[1], output);
        }
    }
}
