﻿
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using CalculatorLibrary;


Calculator calculator = new();
int calculationsCompleted = 0;
List<string> calculationsHistory = new List<string>();

while (true) {

    Console.WriteLine("---Calculator---");
    Console.WriteLine("Choose option:");
    Console.WriteLine("1-Compute new problems");
    Console.WriteLine("2-View History");
    Console.WriteLine("3-Delete an item from History");
    Console.WriteLine("4-Delete every item from History");
    Console.WriteLine("0-EXIT");

    int menuChoice = 0;
    while(!Int32.TryParse(Console.ReadLine(), out menuChoice))
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

            Console.WriteLine("Operation?\n1-Sum\n2-Minus\n3-Multiply\n4-Divide\n0-Go back");

            string? choice = Console.ReadLine().Trim().ToLower();

            Operation operation = Operation.Undefined;

            if (choice == null || !Regex.IsMatch(choice, "[1|2|3|4|0]"))
            {
                Console.WriteLine("Invalid choice of operation.");
            }
            else
            {
                try
                {
                    switch (choice)
                    {
                        case "0":
                            break;
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

                    if(operation == Operation.Undefined)
                    {
                        break;
                    }

                        decimal? result = calculator.DoOperation(cleanNum1, cleanNum2, operation);
                        calculationsHistory.Add($" {cleanNum1} {OperationEnumHelper.OperationEnumFriendlyString(operation)} {cleanNum2} = {result}");
                        calculationsCompleted++;

                        Console.WriteLine(result);
                    
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

    if(menuChoice == 2)
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

    if(menuChoice == 3)
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
    if(menuChoice == 4)
    {
        calculationsHistory.Clear();
        Console.WriteLine("History cleared.");

    }
    if(menuChoice == 0)
    {
        break;
    }
}

