using API.Common;
using AutoMapper;
using Domain;
using Persistence;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using static API.Common.Books_CategoryBookCount;
using static API.Common.MultiMapIndexes;

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

        public List<Book> GetBooksWithPaging(int pagenumber, int pagesize)
        {
            if (pagenumber > 0 || pagesize > 0)
            {
                var books = Session
                .Query<Book>()
                .OrderBy(b => b.Title)
                .Skip((pagenumber - 1) * pagesize)
                .Take(pagesize);
                return books.ToList();
            }
            else
            {
                Console.WriteLine("Invalid page number or page size. Returning defualt query");
                return null;
            }
        }

        public List<Book> GetBooksByAuthorWithPaging(int pagenumber, int pagesize)
        {
            if (pagenumber > 0 || pagesize > 0)
            {
                var books = Session
                .Query<Book>()
                .OrderBy(b => b.Author)
                .Skip((pagenumber - 1) * pagesize)
                .Take(pagesize);
                return books.ToList();
            }
            else
            {
                Console.WriteLine("Invalid page number or page size. Returning defualt query");
                return null;
            }
        }

        public Book GetBook(string id)
        {
            var book = Session.Load<Book>(id);
            return book;
        }

        public List<Result> GetCategoryBooksCount()
        {
            var result = Session
                .Query<Result, Books_CategoryBookCount>()
                .Include(b => b.Category)
                .ToList();
            return result;
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