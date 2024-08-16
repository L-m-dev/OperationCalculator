using System.Diagnostics;
using Newtonsoft.Json;

namespace CalculatorLibrary
{
    public class Calculator
    {
        JsonWriter writer;
        public Calculator()
        {
            StreamWriter logFile = File.CreateText("calculatorlog.json");
            logFile.AutoFlush = true;
            writer = new JsonTextWriter(logFile);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartObject();
            writer.WritePropertyName("Operations");
            writer.WriteStartArray();
        }

        public decimal? DoOperation(decimal num1, decimal num2, Operation op)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("Operand1");
            writer.WriteValue(num1);
            writer.WritePropertyName("Operand2");
            writer.WriteValue(num2);
            writer.WritePropertyName("Operation");

            decimal? result = 0;
            switch (op)
            {
                case Operation.Add:
                    result = num1 + num2;
                    writer.WriteValue("Add");
                    break;
                case Operation.Subtract:
                    result = num1 - num2;
                    writer.WriteValue("Subtract");

                    break;                case Operation.Multiply:
                    result = num1 * num2;
                    writer.WriteValue("Multiply");
                    break;
                case Operation.Divide:
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                        writer.WriteValue("Divide");
                        break;                    }
                    else
                    {
                        num2 = 1;
                        result = num1 / num2;
                        writer.WriteValue("Divide");
                        break;
                    }

                default:
                    throw new InvalidOperationException("Invalid choice");
            }

            writer.WritePropertyName("Result");
            writer.WriteValue(result);
            writer.WriteEndObject();

            return result;

        }

        public void Finish()
        {
            writer.WriteEndArray();
            writer.WriteEndObject();
            writer.Close();
        }

    }

}

