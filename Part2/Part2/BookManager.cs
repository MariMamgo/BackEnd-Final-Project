using System;
using System.Collections.Generic;
using System.Linq;

namespace Part2
{
    internal class BookManager
    {
        List<Book> books;

        public BookManager()
        {
            books = new List<Book>();
        }

        public void AddBook(string title, string author, int yearOfPublication)
        {
            bool containAny = books.Any(book => book.title.Equals(title) && book.author.Equals(author) && book.yearOfPublish == yearOfPublication);
            if (!containAny)
            {
                books.Add(new Book(title, author, yearOfPublication));
                Console.WriteLine("Book added successfully.");
            }
            else { Console.WriteLine("Book is already added"); }
        }

        public void ShowBooks()
        {
            if (books.Any())
            {
                Console.WriteLine("All books:");
                foreach (var book in books)
                {
                    Console.WriteLine(book.ToString());
                }
            }
            else
            {
                Console.WriteLine("No books available.");
            }
        }

    public void SearchByTitle(string title)
        {
            var foundBook = (from book in books
                             where book.title.Equals(title)
                             select book).FirstOrDefault();
                if(foundBook != null)
            {
                Console.WriteLine(foundBook.ToString());
            }
            else { Console.WriteLine("Book with given title does not exist!"); }
        }

    }
}

