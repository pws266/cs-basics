using System;
using System.IO;
using System.Xml.Serialization;

using Library;

namespace CSharpBasics
{
    // XML calculator implementation
    public class Computation
    {
        // performs simple calculator action using arguments loaded from *.xml
        public OperandElement Compute(OperandElement firstOperand, OperationElement operation,
                                      OperandElement secondOperand)
        {
            char sign = ' ';

            OperandElement result = new OperandElement();

            // performing computation
            switch(operation.Operation)
            {
                case OperationType.Sum:
                    result.Value = Calculator.add(firstOperand.Value, secondOperand.Value);
                    sign = '+';                   
                    break;
                case OperationType.Min:
                    result.Value = Calculator.sub(firstOperand.Value, secondOperand.Value);
                    sign = '-';
                    break;
                default:
                    Console.WriteLine("Unknown operation. No result");
                    return null;
            }

            string answer = string.Format(" > {0} {1} {2} = ", firstOperand.Value, sign, 
                                                               secondOperand.Value);
            answer += Convert.ToString(result.Value);

            Console.WriteLine(answer);

            return result;
        } 
    }

    // caclulator verification
    class VerifyComputation
    {
        public static void Main(string[] args)
        {
            Console.Title = "Calculator via XML";

            // checking command line arguments number
            if (args.Length != 2)
            {
                Console.WriteLine("Illegal arguments number\nUsage: Calculator.exe " +                                                    "<InputFileName.xml> <OutputFileName.xml>");
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
