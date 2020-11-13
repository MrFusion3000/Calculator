using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Text.RegularExpressions;

namespace Calculator
{
    class Program
    {
        public static void Main()
        {
            Calc1 calc1 = new Calc1();
            calc1.Menu();
        }
    }

    public class Calc1
    { 
        //Menu
        public void Menu()
        {
            int antalMenyval = 9;                       // initiera antal menyval på huvudmenyn
            int menyVal;                                // initiera heltalsvariabel menyVal för användarinput

            // *** Switch och case med do-while-loop så länge menyVal är annat än 0
            do
            {
                Console.Clear();                        // Rensa skärmen
                Console.WriteLine("* ** *** H U V U D M E N Y *** ** *\n");
                Console.WriteLine("Välj ett alternativ (och tryck Enter):\n");
                Console.WriteLine("1. Calc1 - Rad-för-rad");
                Console.WriteLine("2. Calc2 - Allt-i-ett");

                Console.WriteLine("0. Avsluta \n");

                menyVal = Check_Valid(antalMenyval);   // Kontroll av godkända tecken och blockering av annat än siffror

                switch (menyVal)
                {
                    case 1:
                        Calc1InputParameters();
                        break;
                    case 2:
                        Calc2InputParameters();
                        break;
                    case 0:                             // Val 0, ger meddelande till användaren och avslutar programmet.
                        Console.WriteLine("You have left the calculator. Bye, Calc You Later!.");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Flalse choice. Choose between  0 - " + (antalMenyval--) + ".");
                        break;
                }

            } while (menyVal != 0);
        } // **** End Run() ****    

        //Method for input Calc1
        public void Calc1InputParameters()
        {
            Console.WriteLine("Rad-För-Rad");

            Console.WriteLine("Enter first number: ");
            double number1 = CorrectInput();

            //input operator        fixa char check!
            Console.WriteLine("Enter operator (+ - / *) : ");
            char operator1 = CorrectOpInput();

            //input another number
            Console.WriteLine("Enter second number: ");
            double number2 = CorrectInput();

            // print result
            double totalSum = InputNumber(number1, number2, operator1);
            PrintResult(totalSum);
        }

        //Method for intput Calc2
        public void Calc2InputParameters()
        {
            Console.WriteLine("Allt-i-Ett");

            Console.WriteLine("Enter your calculation in one row: ");
            string  rowCalc = Console.ReadLine();            
            char operator1 = ' ';          

            if (rowCalc.Contains("+"))
            {
                operator1 = '+'; 
            }
            else if (rowCalc.Contains("-"))
            {
                operator1 = '-';
            }
            else if (rowCalc.Contains("/"))
            {
                operator1 = '/';
            }
            else if (rowCalc.Contains("*"))
            {
                operator1 = '*';
            }
            else
            {
                Console.WriteLine("Wrong operator!");
            }

            // pick out 1st number from string
            string number1ToStr = rowCalc.Substring(0, rowCalc.IndexOf(operator1));

            // pick out 2nd number from string
            string number2ToStr = rowCalc.Substring(rowCalc.IndexOf(operator1) + 1);

            //convert strings to numbers(integers)
            double number1 = CorrectInput2(number1ToStr);
            double number2 = CorrectInput2(number2ToStr);

            Console.WriteLine("No1: " + number1);
            Console.WriteLine("No2: " + number2);
            Console.WriteLine("operator: " + operator1);            

            // print result
            double totalSum = InputNumber(number1, number2, operator1);
            PrintResult(totalSum);
        }

        //Method for handling correct number input Calc1
        double CorrectInput()
        {
            bool input = false;
            double number = 0.0;

            while (!input)
            {
                input = double.TryParse(Console.ReadLine(), out number);
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

            while (!input)
            {
                string inputStr;
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
        double InputNumber(double number1, double number2, char operator1)
        {
            double totalSum = 0;

            if (operator1 == '+')
            {
                //totalSum = number1 + number2;
                totalSum = CalcAdd(number1, number2);
            }
            else if (operator1 == '-')
            {
                //totalSum = number1 - number2;
                totalSum = CalcSub(number1, number2);
            }
            else if (operator1 == '/')
            {
                //totalSum = number1 / number2;
                totalSum = CalcDiv(number1, number2);
            }
            else if (operator1 == '*')
            {
                //totalSum = number1 * number2;
                totalSum = CalcMult(number1, number2);
            }
            else
            {
                Console.WriteLine("Wrong input");
            }

            return totalSum;
        }

        //Method for addition
        double CalcAdd(double number1, double number2)
        {
            double totalSum;
            totalSum = number1 + number2;
            return totalSum;
        }

        //Method for subtraction
        double CalcSub(double number1, double number2)
        {
            double totalSum;
            totalSum = number1 - number2;
            return totalSum;
        }
        //Method for division
        double CalcDiv(double number1, double number2)
        {
            double totalSum;
            totalSum = number1 / number2;
            return totalSum;
        }

        //Method for multiplication
        double CalcMult(double number1, double number2)
        {
            double totalSum;
            totalSum = number1 * number2;
            return totalSum;
        }

        public int Check_Valid(int _antalMenyval)       // Metoden tar med sig argumentet _antalMenyval
        {
            int antalMenyval = _antalMenyval;
            int _menyVal;
            while (!int.TryParse(Console.ReadLine(), out _menyVal))
            {
                Console.WriteLine("Endast något av menyvalen 0 - " + (antalMenyval--) + " är giltiga.");

            }
            return _menyVal;        // Metoden returnerar ett korrekt valalternativ

        }   // **** End Check_Valid() ****

        //Method for handling correct number input Calc2
        double CorrectInput2(string num2Str)
        {
            string _number2Str = num2Str;
            bool input = false;
            double number = 0;

            while (!input)
            {
                input = double.TryParse(_number2Str, out number);
                if (!input)
                    Console.WriteLine("That's not a valid number!");
            }

            return number;
        }
    }
}
