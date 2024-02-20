using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Calculator
            /*
            CalculatorDelegate calcDel = null;
            Calculator calc = new Calculator();

            Console.WriteLine("Choose first number: ");
            float a = float.Parse(Console.ReadLine());
            Console.WriteLine("Choose second number: ");
            float b = float.Parse(Console.ReadLine());
            Console.WriteLine("Choose operation (+, -, /, *) : ");
            string op = Console.ReadLine();

            List<string> operations = new List<string>() {"+", "-", "*", "/" };
            int limit = 10;
            int attempt = 0;
            while (!operations.Contains(op) && attempt<limit)
            {
                Console.WriteLine("Choose operation again (+, -, /, *) : ");
                op = Console.ReadLine();
                attempt++;
            }

            switch (op)
            {
                case "+":
                    calcDel = calc.Sum; 
                    break;
                case "-":
                    calcDel = calc.Sub;
                    break;
                case "*":
                    calcDel = calc.Mul;
                    break;
                case "/":
                    calcDel = calc.Div;
                    break;
                default:
                    break;
            }
            try
            {
                calcDel.Invoke(a, b);
            } catch (Exception ex) { Console.WriteLine("Start Over! "); }
            */
            #endregion

            #region GuessNumber




            #endregion
        }
    }
}
