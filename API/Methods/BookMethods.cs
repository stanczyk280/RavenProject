using API.Repository;
using AutoMapper;
using Domain;
using Raven.Client.ServerWide.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Methods
{
    public class BookMethods : BooksRepo
    {
        public void DisplayBook(string id)
        {
            if (!id.Contains("books/"))
            {
                id = "books/" + id;
            }
            var book = GetBook(id);
            if (book == null)
            {
                Console.WriteLine("No book of given id exists");
                return;
            }

            Console.WriteLine("Id: " + book.Id + "\n");
            Console.WriteLine("Title: " + book.Title + "\n");
            Console.WriteLine("Author: " + book.Author + "\n");
            if (book.Published != null)
            {
                DateOnly date = (DateOnly)book.Published;
                Console.WriteLine("Publisher: " + date.ToShortDateString() + "\n");
            }

            Console.WriteLine("Category: " + book.Category + "\n");
            Console.WriteLine("Description: " + book.Description + "\n");
            Console.WriteLine("Available: " + book.BookQuantity.Available + "\n");
        }

        public void DisplayBooksList()
        {
            var books = GetBooks();
            foreach (var book in books)
            {
                DisplayBook(book.Id);
                Console.WriteLine("========================\n");
            }
        }

        public void DisplayBooksTitleList()
        {
            Console.WriteLine("Please enter desired page number: ");
            int pagenumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter desired page size: ");
            int pagesize = Convert.ToInt32(Console.ReadLine());

            var books = GetBooksWithPaging(pagenumber, pagesize);
            foreach (var book in books)
            {
                int i = 1;
                Console.WriteLine(i + ". Book Title: " + book.Title);
                i++;
            }
        }

        public void DisplayBooksAuthorList()
        {
            Console.WriteLine("Please enter desired page number: ");
            int pagenumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter desired page size: ");
            int pagesize = Convert.ToInt32(Console.ReadLine());

            var books = GetBooksWithPaging(pagenumber, pagesize);
            foreach (var book in books)
            {
                int i = 1;
                Console.WriteLine(i + ". Book Title: " + book.Title + ", Author: " + book.Author);
                i++;
            }
        }

        public void DisplayCategoryCount()
        {
            var results = GetCategoryBooksCount();
            foreach (var result in results)
            {
                Console.WriteLine("Category: " + result.Category + " Quantity: " + result.TotalCount);
            }
        }

        public void CreateBook()
        {
            Console.WriteLine("Add new book to the system\n");
            Console.WriteLine("Please enter correct values\n");
            Console.Write("Title: ");
            string title = Console.ReadLine();
            Console.Write("\nAuthor: ");
            string author = Console.ReadLine();
            Console.Write("\nPublisher: ");
            string publisher = Console.ReadLine();
            Console.Write("\nDate of publication (Year,Month,Day): ");
            string dateString = Console.ReadLine();
            DateOnly date = DateOnly.Parse(dateString);
            Console.Write("\nCategory: ");
            string category = Console.ReadLine();
            Console.Write("\nDescription: ");
            string description = Console.ReadLine();
            Console.Write("\nBooks Quantity: ");
            uint quantity = Convert.ToUInt32(Console.ReadLine());

            Book book = new Book()
            {
                Title = title,
                Author = author,
                Publisher = publisher,
                Published = date,
                Category = category,
                Description = description,
                BookQuantity = new BookQuantity
                {
                    Quantity = quantity,
                    Borrowed = 0
                }
            };

            CreateBook(book);
        }

        public void UpdateBook(string id)
        {
            id = "books/" + id;
            var book = GetBook(id);
            if (book == null)
            {
                Console.WriteLine("No book of " + id + " exists");
                return;
            }

            Console.WriteLine("Update book in the system\n");
            Console.WriteLine("Please enter correct values or leave them empty if\nyou do not wish to change the value\n");
            Console.Write("Title: ");
            string title = Console.ReadLine() ?? book.Title;

            Console.Write("\nAuthor: ");
            string author = Console.ReadLine() ?? book.Author;

            Console.Write("\nPublisher: ");
            string publisher = Console.ReadLine() ?? book.Publisher;

            Console.Write("\nDate of publication (Year,Month,Day): ");
            string dateString = Console.ReadLine();
            DateOnly date;
            if (dateString == null)
            {
                date = (DateOnly)book.Published;
            }
            else
            {
                date = DateOnly.Parse(dateString);
            }

            Console.Write("\nCategory: ");
            string category = Console.ReadLine() ?? book.Category;

            Console.Write("\nDescription: ");
            string description = Console.ReadLine() ?? book.Description;

            Book newBook = new Book()
            {
                Title = title,
                Author = author,
                Publisher = publisher,
                Published = date,
                Category = category,
                Description = description,
                BookQuantity = new BookQuantity
                {
                    Quantity = book.BookQuantity.Quantity,
                    Borrowed = book.BookQuantity.Borrowed
                }
            };

            UpdateBook(id, newBook);
        }

        public void DeleteBookFromSystem(string id)
        {
            id = "books/" + id;
            var book = GetBook(id);
            if (book == null)
            {
                Console.WriteLine("No book of given id exists");
                return;
            }
            DeleteBook(id);
        }
    }
}