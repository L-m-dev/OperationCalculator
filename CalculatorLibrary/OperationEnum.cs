using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLibrary
{
    public enum Operation
    {   Undefined,
        Add,
        Subtract,
        Multiply,
        Divide,
        SquareRoot,
        Power,
        MultiplyBy10
    }

    public static class OperationEnumHelper
    {
        public static string OperationEnumFriendlyString(Operation op)
        {
            switch (op)
            {
                case Operation.Add:
                    return "+";
                case Operation.Subtract:
                    return "-";
                case Operation.Multiply:
                    return "*";
                case Operation.Divide:
                    return "/";
                case Operation.SquareRoot:
                    return "squared";
                case Operation.Power:
                    return "^";
                case Operation.MultiplyBy10:
                    return "multiplied by 10";
            }
            throw new Exception("Invalid operation.");
        }

    }

}
