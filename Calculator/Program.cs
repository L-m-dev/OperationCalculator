
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

decimal? num1;
decimal? num2;

decimal cleanNum1 = 0;
decimal cleanNum2 = 0;

Console.WriteLine("Type first number:");

while(!Decimal.TryParse(Console.ReadLine(), out cleanNum1))
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
                choice = "sum";
                break;
            case "2":
                choice = "minus";
                break;
            case "3":
                choice = "multiply";
                break;
            case "4":
                choice = "divide";
                break;
            default:
                throw new InvalidOperationException("Invalid choice of operation.");
        }

        decimal result = Calculator.Calculator.DoOperation(cleanNum1, cleanNum2, choice);

        Console.WriteLine(result);

    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }


}

