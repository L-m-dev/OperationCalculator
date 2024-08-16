using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class Calculator
    {
        public static decimal? DoOperation(decimal num1, decimal num2, string op)
        {
            decimal? result = 0;
            switch (op)
            {
                case "sum":
                    return num1+ num2;
                case "minus":
                    return num1-num2;
                case "multiply":
                    return num1 * num2;
                case "divide":
                    if (num2 != 0)
                    {
                        return num1 / num2;
                    }
                    break;
                default:
                    throw new InvalidOperationException("Invalid choice");
            }
            return result;

        }

    }
}
