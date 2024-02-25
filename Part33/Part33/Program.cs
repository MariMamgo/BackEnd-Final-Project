using Part33;
using System;

namespace Part33
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentOffice students = new StudentOffice();

            students.AddStudent("Mariam Mamageishvili", 001, 'A');
            students.AddStudent("Natalie Portman", 002, 'B');
            students.AddStudent("Benedict Cumberbetch", 003, 'C');

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add a new student");
                Console.WriteLine("2. View all students");
                Console.WriteLine("3. Search for a student by roll number");
                Console.WriteLine("4. Update a student's grade");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Enter name: ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter Roll Number: ");
                        int rollNumber = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter grade: ");
                        char grade = char.Parse(Console.ReadLine());
                        students.AddStudent(name, rollNumber, grade);
                        break;
                    case "2":
                        students.ShowStudents();
                        break;
                    case "3":
                        Console.WriteLine("Enter student roll number: ");
                        int num = int.Parse(Console.ReadLine());
                        students.SearchByRollNumber(num);
                        break;
                    case "4":
                        Console.WriteLine("Enter student roll number: ");
                        int rollNum = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter new grade: ");
                        char newGrade = char.Parse(Console.ReadLine());
                        students.UpdateGrade(newGrade, rollNum);
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }

            }
        }
            
    }
}
