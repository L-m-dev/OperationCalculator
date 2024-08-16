using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLibrary
{
    public enum Operation
    {
        Add,
        Subtract,
        Multiply,
        Divide
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

            }
            throw new Exception("Invalid operation.");
        }

    }

}
