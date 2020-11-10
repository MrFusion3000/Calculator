using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Text.RegularExpressions;

namespace Calculator
{
    class Program
    {
        static void Main()
        {
            Program program = new Program();
            
                program.InputParameters();

                //if (exit1 == "x")
                //{
                //    Console.WriteLine("Thank you for using the program. Calc You Later.");
                //}
            

            

        }

        //Method for input
        void InputParameters()
        {          
            Console.WriteLine("Enter first number: ");
            int number1 = CorrectInput();
            
            //input operator        fixa char check!
            Console.WriteLine("Enter operator (+ - / *) : ");
            char operator1 = CorrectOpInput();

            //input another number
            Console.WriteLine("Enter second number: ");
            int number2 = CorrectInput();                

            // print result
            double totalSum = InputNumber(number1, number2, operator1);
            PrintResult(totalSum);         
        }

        //Method for handling correct number input
        int CorrectInput()
        {
            bool input = false;
            int number = 0;

            while (!input)
            {                               
                input = int.TryParse(Console.ReadLine(), out number);
                if (!input)
                    Console.WriteLine("That's not a valid number!");
            } 

            return number;
        }
    
        //Method for handling correct operator input
        char CorrectOpInput()
        {
            bool input = false;
            char operator1 = ' ';
            string inputStr = ""; 

            while (!input)
            {
                inputStr = Console.ReadLine();

                //if (!Regex.Match(inputStr, @"^d\{1}$").Success)
                //{
                //    Console.WriteLine("Only one character. Try again!");
                //}                
                //if (!Regex.Match(inputStr, @"(-+/*)").Success)
                //{
                //    Console.WriteLine("That's not a valid operator. Try again!");
                //}

                if (inputStr == "+" || inputStr == "-" || inputStr == "/" || inputStr == "*")
                {
                    input = char.TryParse(inputStr, out operator1);
                }                
                else
                {
                    Console.WriteLine("That's not a valid operator. Try again!");
                }                    
            }            

            return operator1;
        }
        
        //Method for printing the result
        void PrintResult(double totalSum)
        {
            Console.WriteLine("Summa: {0}", totalSum);
            Console.ReadLine();
            
        }

        //Method for calculations
        double InputNumber(int number1, int number2, char operator1)
        {
            double totalSum = number1;

            if (operator1 == '+')
            {
                totalSum = number1 + number2;
            }
            else if (operator1 == '-')
            {
                totalSum = number1 - number2;
            }
            else if (operator1 == '/')
            {
                totalSum = number1 / number2;
            }
            else if (operator1 == '*')
            {
                totalSum = number1 * number2;
            }
            else
            {
                Console.WriteLine("Wrong input");
            }

            return totalSum;
            
        }

    }
}
