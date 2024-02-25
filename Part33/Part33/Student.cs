using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part33
{
    internal class Student
    {
        public string Name { get; set; }
        public int RollNumber { get; set; }
        public char Grade { get; set; }


        public Student(string name, int number, char grade)
        {
            this.Name = name;
            this.RollNumber = number;
            this.Grade = grade;
        }

        public override string ToString()
        {
            return $"Student name: {Name}, Roll Number : {RollNumber}, Grade : {Grade}.";
        }
    }
}
