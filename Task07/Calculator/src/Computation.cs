namespace CSharpBasics.src
{
    using System;
    using System.IO;
    using System.Xml.Serialization;

    using Library.src;

    // XML calculator implementation
    public class Computation
    {
        // performs simple calculator action using arguments loaded from *.xml
        public OperandElement Compute(OperandElement firstOperand, OperationElement operation,
                                      OperandElement secondOperand)
        {
            char sign = ' ';

            OperandElement result = new OperandElement();

            if (!firstOperand.isCorrectValue || !secondOperand.isCorrectValue ||
                !operation.isCorrectValue)
            {
                result.isCorrectValue = false;
                string errorMessage = String.Format(">> Error in {0} defined in XML. " + 
                                                    "No computation! <<",
                                                    !operation.isCorrectValue ? "operation" : 
                                                    (!firstOperand.isCorrectValue ? "first" :
                                                    "second") + " operand");

                Interface.DisplayMessage(errorMessage, ConsoleColor.Yellow, ConsoleColor.Blue);

                return result;
            }

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
}
