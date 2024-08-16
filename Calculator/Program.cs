
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using CalculatorLibrary;


Calculator calculator = new();
while (true)
{
    decimal? num1;
    decimal? num2;

    decimal cleanNum1 = 0;
    decimal cleanNum2 = 0;

    

    Console.WriteLine("Type first number:");

    while (!Decimal.TryParse(Console.ReadLine(), out cleanNum1))
    {
        Console.WriteLine("Invalid input. Enter valid number");
    }

    Console.WriteLine("Type second number:");

    while (!Decimal.TryParse(Console.ReadLine(), out cleanNum2))
    {
        Console.WriteLine("Invalid input. Enter valid number");
    }

    Console.WriteLine("Operation?\n1- Sum\n2-Minus\n3-Multiply\n4-Divide");

    string? choice = Console.ReadLine().Trim().ToLower();
    Operation operation;

    if (choice == null || !Regex.IsMatch(choice, "[1|2|3|4]"))
    {
        Console.WriteLine("Invalid choice.");
    }
    else
    {
        try
        {
            switch (choice)
            {
                case "1":
                    operation = Operation.Add;
                    break;
                case "2":
                    operation = Operation.Subtract;
                    break;
                case "3":
                    operation = Operation.Multiply;
                    break;
                case "4":
                    operation = Operation.Divide;
                    break;
                default:
                    throw new InvalidOperationException("Invalid choice of operation.");
            }

            decimal? result = calculator.DoOperation(cleanNum1, cleanNum2, operation);

            Console.WriteLine(result);

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        calculator.Finish();
        Console.WriteLine("Want to quit? type in 'quit'. Want to continue, press Enter");
        if (Console.ReadLine().Trim().ToLower().Equals("quit"))
        {
            break;
        }
    }

}

