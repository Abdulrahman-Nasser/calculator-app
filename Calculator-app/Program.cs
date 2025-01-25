using System;

namespace Calculator
{
    class CalculatorApp
    {
        public static int addition(int value, int sum)
        {
            return sum + value;
        }

        public static int substraction(int value, int sum)
        {
            return sum - value;
        }

        public static double multiplication(double value, double product)
        {
            return product * value;
        }

        public static double division(double currentResult, double value)
        {
            if (value == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return currentResult / value;
        }

        static void Main()
        {
            bool endApp = false;
            Console.WriteLine("---- Welcome to our calculator application ---- \n");

            while (!endApp)
            {
                Console.WriteLine("Please choose your operation:");
                Console.WriteLine("1. Addition");
                Console.WriteLine("2. Subtraction");
                Console.WriteLine("3. Multiplication");
                Console.WriteLine("4. Division");
                Console.WriteLine("0. Exit");
                Console.WriteLine("Enter your choice:");

                if (!int.TryParse(Console.ReadLine(), out int operationType) || operationType < 0 || operationType > 4)
                {
                    Console.WriteLine("Invalid input. Please choose a valid option.");
                    continue;
                }

                if (operationType == 0)
                {
                    endApp = true;
                    Console.WriteLine("Exiting the application. Goodbye!");
                    break;
                }

                Console.WriteLine("Enter your numbers one at a time. Enter -1 to finish and see the result.");
                double result = (operationType == 4 || operationType == 3) ? 1.0 : 0;
                bool isFirstInput = true;

                while (true)
                {
                    if (!double.TryParse(Console.ReadLine(), out double value))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                        continue;
                    }

                    if (value == -1)
                    {
                        break;
                    }

                    try
                    {
                        switch (operationType)
                        {
                            case 1:
                                result = addition((int)value, (int)result);
                                break;
                            case 2:
                                result = isFirstInput ? value : substraction((int)value, (int)result);
                                break;
                            case 3:
                                result = multiplication((double)value, (double)result);
                                break;
                            case 4:
                                result = isFirstInput ? value : division(result, value);
                                break;
                        }
                    }
                    catch (DivideByZeroException e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    isFirstInput = false;
                }

                Console.WriteLine($"Result = {result}\n");
            }
        }
    }
}
