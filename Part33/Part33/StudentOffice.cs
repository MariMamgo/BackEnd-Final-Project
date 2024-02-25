using Part33;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Part33
{
    internal class StudentOffice
    {
        private List<Student> students;

        public StudentOffice()
        {
            students = new List<Student>();
        }

        public void AddStudent(string name, int num, char grade)
        {
            // ჩემი აზრით, სტუდენტის ნომერი უნდა იყოს უნიკალური. ამიტომ ახალი სტუდენტის დამატებამდე უნდა გადამოწმდეს აქვს თუ არა ვინმეს იგივე ნომერი.
            bool containsStudent = students.Any(student => student.RollNumber == num);
            if (!containsStudent)
            {
                students.Add(new Student(name, num, grade));
                Console.WriteLine("Student added successfully.");
            }
            else
            {
                Console.WriteLine("Student is already added.");
            }
        }

        public void ShowStudents()
        {
            if (students.Any())
            {
                Console.WriteLine("All students:");
                foreach (var student in students)
                {
                    Console.WriteLine(student.ToString());
                }
            }
            else
            {
                Console.WriteLine("No students available.");
            }
        }

        public void SearchByRollNumber(int num)
        {
            var foundStudent = students.FirstOrDefault(student => student.RollNumber == num);
            if (foundStudent != null)
            {
                Console.WriteLine(foundStudent.ToString());
            }
            else
            {
                Console.WriteLine("Student with given Roll Number does not exist!");
            }
        }

        public void UpdateGrade(char grade, int num)
        {
            var student = students.FirstOrDefault(student => student.RollNumber == num);
            if (student != null)
            {
                student.Grade = grade;
                Console.WriteLine("Grade updated successfully.");
            }
            else
            {
                Console.WriteLine("Student with given Roll Number does not exist!");
            }
        }
    }
}
