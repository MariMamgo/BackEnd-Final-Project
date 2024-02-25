using System;
using System.IO;

namespace part1Translator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filename = "dictionary.txt";
            string filePath = Path.GetFullPath(filename);
            StreamReader reader = new StreamReader(filePath);
            string content = reader.ReadToEnd();

            // კონტენტი სტრინგების ლისტში გადაგვაქვს დასპლიტვის შედეგად
            string[] words = content.Split("\n");

            Console.WriteLine("Select language pair:");
            Console.WriteLine("1. Georgian to English");
            Console.WriteLine("2. English to Georgian");
            int choice = int.Parse(Console.ReadLine());

            string fromLanguage = choice == 1 ? "Georgian" : "English";
            string toLanguage = choice == 1 ? "English" : "Georgian";

            Console.WriteLine($"Enter the text you wish to translate from {fromLanguage} to {toLanguage}: ");
            string toTranslate = Console.ReadLine();

            bool translationFound = false;

            foreach (string word in words)
            {
                // ყოველი ენთრი შედგება "word : სიტყვა" ტიპის ჩანაწერისგან. ორწერტილზე დასპლიტვით ორ ნაწილად დავყოფთ ენთრის.
                string[] parts = word.Split(':');

                // თუ მომხმარებელმა აირჩია 1, ანუ ქართულიდან ინგლისურად უნდა გადავთარგმნოთ და ქართულ სიტყვას ზედმეტი სფეისები მოვაშოროთ და პირიქით.
                string translation = (choice == 1) ? parts[0].Trim() : parts[1].Trim();

                // სიტყვის პოვნის შემთხვევაში შესაბამის თარგმანს სფეისებს მოვაშორებთ და დავაბრუნებინებთ.
                if (choice == 1 && parts[1].Trim() == toTranslate || choice == 2 && parts[0].Trim() == toTranslate)
                {
                    Console.WriteLine($"{toTranslate}: {translation}");
                    translationFound = true;
                    break;
                }
            }
            reader.Close(); // აქ რიდერი უნდა დაიკეტოს, იმიტომ რომ აღარ დაგვჭირდება

            if (!translationFound)
            {
                Console.WriteLine($"Translation not found for '{toTranslate}'. Would you like to add it? (Y/N)");
                string addTranslation = Console.ReadLine();

                if (addTranslation.ToUpper() == "Y")
                {
                    Console.WriteLine($"Enter the translation of '{toTranslate}' in {toLanguage}:");
                    string newTranslation = Console.ReadLine();

                    string newEntry = choice == 2 ? $"{toTranslate} : {newTranslation}" : $"{newTranslation} : {toTranslate}";
                    StreamWriter streamWriter = new StreamWriter(filePath, append: true);
                    streamWriter.WriteLine($"\n{newEntry}"); // თარგმანი დავამატოთ ფაილში
                    streamWriter.Close(); // ტექსტის დამატების შემდეგ ვხურავთ ამასაც.
                    Console.WriteLine($"Translation added: {toTranslate}:{newTranslation}");
                }
            }
        }
    }
}
