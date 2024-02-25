using System;

namespace Part2
{
    class Program
    {
        static void Main(string[] args)
        {
            BookManager bookManager = new BookManager();
            bookManager.AddBook("Misteriebi", "Knut Hamsun", 1920);
            bookManager.AddBook("Samoseli Pirveli", "Guram Dochanashvili", 1975);
            bookManager.AddBook("Gzaze erti kaci midioda", "Otar Chiladze", 1973);
            bookManager.AddBook("Antonio da Daviti", "Jemal Qarchxadze", 1984);
            bookManager.AddBook("Vefxistyaosani", "Shota Rustaveli", 1210);
            bookManager.AddBook("Kacia-Adamiani?!", "Ilia ChavChavadze", 1901);
            bookManager.AddBook("Idioti", "Fiodor Dostoevsky", 1869);


                while (true)
                {
                    Console.WriteLine("\nSelect an option:");
                    Console.WriteLine("1. Add a new book");
                    Console.WriteLine("2. Show all book details");
                    Console.WriteLine("3. Search for a book by title");
                    Console.WriteLine("4. Exit");

                    Console.Write("Enter your choice: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            Console.Write("Enter title: ");
                            string title = Console.ReadLine();
                            Console.Write("Enter author: ");
                            string author = Console.ReadLine();
                            Console.Write("Enter year of publication: ");
                            int year=int.Parse(Console.ReadLine());
                            bookManager.AddBook(title, author, year);
                            break;

                        case "2":
                            bookManager.ShowBooks();
                            break;

                        case "3":
                            Console.Write("Enter title to search: ");
                            string searchTitle = Console.ReadLine();
                            bookManager.SearchByTitle(searchTitle);
                            break;

                        case "4":
                            Console.WriteLine("Exiting the program. Goodbye!");
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Invalid choice. Please select a valid option.");
                            break;
                    }
                }
            }
        }
    }
