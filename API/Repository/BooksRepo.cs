using AutoMapper;
using Domain;
using Persistence;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;

namespace API.Repository
{
    public class BooksRepo : BaseRepo
    {
        public List<Book> GetBooks()
        {
            var books = Session
                .Query<Book>()
                .ToList();
            return books;
        }

        public Book GetBook(string id)
        {
            var book = Session.Load<Book>(id);
            return book;
        }

        public void CreateBook(Book newBook)
        {
            Session.Store(newBook);
            Session.SaveChanges();
        }

        public void UpdateBook(string id, Book newBook)
        {
            var book = Session.Load<Book>(id);
            book.Title = newBook.Title;
            book.Author = newBook.Author;
            book.Publisher = newBook.Publisher;
            book.Published = newBook.Published;
            book.Category = newBook.Category;
            book.Description = newBook.Description;
            Session.SaveChanges();
        }

        public void DeleteBook(string id)
        {
            var book = Session.Load<Book>(id);
            if (book == null)
            {
                Console.WriteLine("not found");
                return;
            }
            Session.Delete(book);
            Session.SaveChanges();
        }
    }
}