using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2
{
    internal class Book
    {
        public string title { get; set; }
        public string author { get; set; }
        public int yearOfPublish { get; set; }

        public Book(string title, string author, int year)
        {
            this.title = title;
            this.author = author;
            this.yearOfPublish = year;

        }

        public override string ToString()
        {
            return $"Book Title: {title}, author: {author}, Year of Publish: {yearOfPublish}.";
        }
    }
}
