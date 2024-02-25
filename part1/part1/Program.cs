using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace part1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Calculator
            /*

            // აქ,პირველ რიგში, კალკულატორის დელეგატის ობიექტს შევქმნი, რომელიც თავიდან null იქნება და მოგვიანებით მიენიჭება ფუნქცია 
            // მომხმარებლის არჩევნიდან გამომდინარე.

            CalculatorDelegate calcDel = null;
            Calculator calc = new Calculator();

            // აქ მომხმარებელი ერთვება, რომელმაც უნდა შეარჩიოს ორი რიცხვი და მათემატიკური ოპერაცია ჩამოთვლილ ოთხს შორის.

            Console.WriteLine("Choose first number: ");
            float a = float.Parse(Console.ReadLine());
            Console.WriteLine("Choose second number: ");
            float b = float.Parse(Console.ReadLine());
            Console.WriteLine("Choose operation (+, -, /, *) : ");
            string op = Console.ReadLine();

            // თუ მომხმარებელი ოპერაციას არასწორად ამოარჩევს, ის აუცილებლად გადამოწმდება while ლუპში და მოითხოვს ოპერაციის სულთავიდან შეყვანას
            // სანამ იგი ვალიდური არ გახდება. აგრეთვე დავაწესე ლიმიტი არასწორი მცდელობების რაოდენობის.
            List<string> operations = new List<string>() { "+", "-", "*", "/" };
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
            }
            catch (DivideByZeroException)
            {

                Console.WriteLine("can't divide by 0, start over!");
            }
            catch (Exception ex) { 
                
                Console.WriteLine("Start Over! "); }
            */
            #endregion

            #region GuessNumber
            /*
            Console.WriteLine("Choose your range!");
            Console.WriteLine("Choose starting number:");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Choose ending number:");
            int b = int.Parse(Console.ReadLine());

            Random random = new Random();
            int num = random.Next(a,b);

            Console.WriteLine("Make a guess: ");
            int guess = int.Parse(Console.ReadLine());

            int attempt = 1;

            while (guess != num)
            {
                if (guess > num)
                {
                    Console.WriteLine("Try smaller number: ");
                    guess = int.Parse(Console.ReadLine()) ;
                }
                else
                {
                    Console.WriteLine("Try bigger number: ");
                    guess = int.Parse(Console.ReadLine());
                }
                attempt++;
            }

            Console.WriteLine($"Congratulations, your guess : {guess} was correct. Number of attempts: {attempt}");
           */
            #endregion

            #region Hangman
            /*
            // პირველ რიგში, ვიწყებთ ფაილის გახსნითა და წაკითხვით, რომელშიც სიტყვებია ჩამოწერილი.
            string filename = "words.txt";
            string filePath = Path.GetFullPath(filename);
            StreamReader reader = new StreamReader(filePath);

            string contents = reader.ReadToEnd();

            //იმისთვის რომ, დიდმა და პატარა ასოებმა პრობლემა არ შექმნან ყველაფერი lower case-ზე გადავიყვანოთ.
            contents = contents.ToLower();

            // ფაილის კონტენტის წაკითხვისა და შენახვის შემდეგ, ვქმნი სიტყვების ლისტს.
            string[] words = contents.Split('\n');

            reader.Close();


            // მოთამაშეს შეეძლება აარჩიოს თამაშის სირთულის დონე.
            Console.WriteLine("Choose the level of difficulty:");
            Console.WriteLine("1. Easy (Infinite incorrect attempts)");
            Console.WriteLine("2. Medium (8 incorrect attempts)");
            Console.WriteLine("3. Hard (3 incorrect attempts)");
            Console.Write("Enter your choice: ");

            int choice = int.Parse(Console.ReadLine());
            int maxAttempts = 0;

            switch (choice)
            {
                case 1:
                    maxAttempts = 1000; // აქ იგულისხმება უსასრულო მცდელობები
                    break;
                case 2:
                    maxAttempts = 8;
                    break;
                case 3:
                    maxAttempts = 3;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Exiting the program.");
                    return;
            }

            //სიტყვების ლისტიდან რანდომად ვარჩევთ რომელიმე სიტყვას და თამაშიც დაიწყება.
            Random rand = new Random();
            string chosen = words[rand.Next(words.Length)];

            StringBuilder output = new StringBuilder(chosen.Length + 1);
            output.Append('-', chosen.Length - 1);

            Console.WriteLine("You have to guess the following word: ");
            Console.WriteLine(output);

            int attempts = 0;
            // ლუპში თამაშის ძირითადი ნაწილია მოქცეული
            while (output.ToString().Contains("-") && attempts < maxAttempts)
            {
                Console.WriteLine($"Attempts left: {maxAttempts - attempts}");

                Console.WriteLine("Make a guess:");
                char guess = char.Parse(Console.ReadLine());

                bool correctGuess = false;
                for (int j = 0; j < chosen.Length; j++)
                {
                    if (chosen[j] == guess && output[j] == '-')
                    {
                        output[j] = guess;
                        correctGuess = true;
                    }
                }

                if (!correctGuess)
                {
                    attempts++;
                    Console.WriteLine("Incorrect guess. Try again.");
                }
                else
                {
                    Console.WriteLine("Correct guess!");
                }

                Console.WriteLine(output);
            }

            if (output.ToString().Contains("-"))
            {
                Console.WriteLine("You've run out of attempts. Better luck next time!");
                Console.WriteLine($"Chosen word was: {chosen}");
            }
            else
            {
                Console.WriteLine("Congratulations, you won! <33");
            }

            */
            #endregion

           
        }
    }
}


