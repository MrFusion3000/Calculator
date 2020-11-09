using System;

namespace Calculator
{
    class Program
    {
        static void Main()
        {
            //input one number
            Console.WriteLine("Enter first number: ");
            int number1 = Int32.Parse(Console.ReadLine());
            

            //input operator
            Console.WriteLine("Enter operator (+ - / *) : ");
            string operator1 = Console.ReadLine();

            //input another number
            Console.WriteLine("Enter second number: ");
            int number2 = Int32.Parse(Console.ReadLine());

            // print result
            InputNumber(number1, number2, operator1);

            //Console.WriteLine("Summa: {0}", num);
        }

        private static void InputNumber(int number1, int number2, string operator1)
        {
            double totalSum = number1;

            if (operator1 == "+")
            {
                totalSum = number1 + number2;
            }
            else if (operator1 == "-")
            {
                totalSum = number1 - number2;
            }
            else if (operator1 == "/")
            {
                totalSum = number1 / number2;
            }
            else if (operator1 == "*")
            {
                totalSum = number1 * number2;
            }
            else
            {
                Console.WriteLine("Wrong input");
            }                        
            Console.WriteLine("Summa: {0}", totalSum);
            Console.ReadLine();
        }

    }
}
