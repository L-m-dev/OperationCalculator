
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using VoiceRecognition;
using CalculatorLibrary;


Calculator calculator = new();
int calculationsCompleted = 0;
List<string> calculationsHistory = new List<string>();

while (true)
{

    Console.WriteLine("---Calculator---");
    Console.WriteLine("Choose option:");
    Console.WriteLine("1-Compute new problems");
    Console.WriteLine("2-View History");
    Console.WriteLine("3-Delete an item from History");
    Console.WriteLine("4-Delete every item from History");
    Console.WriteLine("0-EXIT");

    int menuChoice = 0;
    while (!Int32.TryParse(Console.ReadLine(), out menuChoice))
    {
        Console.WriteLine("Invalid choice");
        Console.WriteLine("1-Compute new problems");
        Console.WriteLine("2-View History");
        Console.WriteLine("3-Delete an item from History");
        Console.WriteLine("4-Delete every item from History");
        Console.WriteLine("0-EXIT");
    }


    if (menuChoice == 1)
    {
        while (true)
        {

            Console.WriteLine("Operation?\n1-Sum\n2-Minus\n3-Multiply\n4-Divide\n5-Square Root\n6-Elevate to POWER\n7-Multiply by 10\n8-Trig\n0-Go back");

            string? choice = Console.ReadLine().Trim().ToLower();

            Operation operation = Operation.Undefined;

            if (choice == null || !Regex.IsMatch(choice, "[1|2|3|4|5|6|7|8|0]"))
            {
                Console.WriteLine("Invalid choice of operation.");
            }
            else if (choice == "0")
            {
                break;
            }

            else
            {
                Console.WriteLine();
                decimal? num1;
                decimal? num2;

                decimal cleanNum1 = 0;
                decimal cleanNum2 = 0;

                Console.WriteLine("This application utilizes Voice Recognition.");
                Console.WriteLine("Say aloud the first number:");

                while (!Decimal.TryParse(await VoiceRecognition.VoiceRecognition.VoiceRecognitionOnce(), out cleanNum1))
                {
                    if(cleanNum1 == 0)
                    {
                        Console.WriteLine("API failure.");
                        break;
                    }
                    Console.WriteLine("Invalid input. Please try again.");
                    Console.WriteLine("Say aloud the first number:");
                }
                Console.WriteLine($"First argument: {cleanNum1}");

                if (choice != "5" && choice != "7")
                {
                    Console.WriteLine("Say aloud the second number:");

                    while (!Decimal.TryParse(await VoiceRecognition.VoiceRecognition.VoiceRecognitionOnce(), out cleanNum2))
                    {
                        if (cleanNum1 == 0)
                        {
                            Console.WriteLine("API failure.");
                            break;
                        }
                        Console.WriteLine("Invalid input. Please try again.");
                        Console.WriteLine("Say aloud the second number:");
                    }
                    Console.WriteLine($"Second argument: {cleanNum2}");

                }

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
                        case "5":
                            operation = Operation.SquareRoot;
                            break;
                        case "6":
                            operation = Operation.Power;
                            break;
                        case "7":
                            operation = Operation.MultiplyBy10;
                            break;
                        default:
                            throw new InvalidOperationException("Invalid choice of operation.");
                    }

                    if (operation == Operation.Undefined)
                    {
                        break;
                    }

                    decimal? result = 0;
                    if (cleanNum2 == 0)
                    {
                        result = calculator.DoOperation(cleanNum1, operation);

                        calculationsHistory.Add($" {cleanNum1} {OperationEnumHelper.OperationEnumFriendlyString(operation)} = {result}");
                        calculationsCompleted++;

                    }
                    else
                    {
                        result = calculator.DoOperation(cleanNum1, operation, cleanNum2);

                        calculationsHistory.Add($" {cleanNum1} {OperationEnumHelper.OperationEnumFriendlyString(operation)} {cleanNum2} = {result}");
                        calculationsCompleted++;
                    }
                    Console.WriteLine($"The result is {result}");

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.WriteLine("Press Enter to continue. Type 'exit' to move back.");
                if (Console.ReadLine().Trim().ToLower().Equals("exit"))
                {
                    calculator.Finish();
                    break;
                }
            }

        }
    }

    if (menuChoice == 2)
    {
        if (!(calculationsHistory.Count > 0))
        {
            Console.WriteLine("No History found.");
        }
        else
        {
            int index = 0;
            foreach (var item in calculationsHistory)
            {
                Console.WriteLine($"{index} - {item}");
                index++;
            }
            Console.WriteLine("Press key to continue");
            Console.ReadKey();
        }
    }

    if (menuChoice == 3)
    {
        if (EmptyHistoryList())
        {
            Console.WriteLine("No History found.");
        }
        else
        {
            Console.WriteLine("Type number of record you wish to delete. Type 'exit' to move back.");
            int index = 0;
            bool exit = false;

            foreach (var item in calculationsHistory)
            {
                Console.WriteLine($"{index} - {item}");
                index++;
            }
            int deleteChoice = 0;
            string input = "0";
            bool success = false;
            do
            {
                input = Console.ReadLine();
                if (input == "exit")
                {
                    exit = true;
                    break;
                }
                success = Int32.TryParse(input, out deleteChoice);
                if (!success)
                {
                    Console.WriteLine("Enter valid choice.");
                }
            } while (!success);

            calculationsHistory.RemoveAt(deleteChoice);
        }
    }
    if (menuChoice == 4)
    {
        if (EmptyHistoryList())
        {
            Console.WriteLine("No history found.");
        }
        else
        {

            calculationsHistory.Clear();
            Console.WriteLine("History cleared.");
        }
    }
    if (menuChoice == 0)
    {
        break;
    }
    Console.WriteLine();
}

 bool EmptyHistoryList()
{
    if (calculationsHistory.Count > 0)
    {
        return false;
    }
    return true;
}
