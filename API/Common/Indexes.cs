using Domain;
using Raven.Client.Documents.Indexes;
using System.Security.Cryptography.X509Certificates;
using static System.Reflection.Metadata.BlobBuilder;

namespace API.Common
{
    public class Indexes
    {
        public class BooksIndex : AbstractIndexCreationTask<Book>
        {
            public BooksIndex()
            {
                Map = books => from book in books
                               select new
                               {
                                   book.Title,
                               };
            }
        }

        public class Books_ByAuthor : AbstractIndexCreationTask<Book>
        {
            public Books_ByAuthor()
            {
                Map = books => from book in books
                               select new
                               {
                                   book.Author
                               };
                Indexes.Add(x => x.Author, FieldIndexing.Search);
            }
        }

        public class ClientsIndex : AbstractIndexCreationTask<Client>
        {
            public ClientsIndex()
            {
                Map = clients => from client in clients
                                 select new
                                 {
                                     client.Name,
                                     client.Email
                                 };
            }
        }

        public class Clients_ByNameAndLastName : AbstractIndexCreationTask<Client>
        {
            public Clients_ByNameAndLastName()
            {
                Map = clients => from client in clients
                                 select new
                                 {
                                     client.Name,
                                     client.LastName
                                 };
            }
        }
    }

    public class EmployeesIndex : AbstractIndexCreationTask<Employee>
    {
        public EmployeesIndex()
        {
            Map = employees => from employee in employees
                               select new
                               {
                                   employee.Name,
                                   employee.Email
                               };
        }
    }

    public class Employees_ByNameAndLastName : AbstractIndexCreationTask<Employee>
    {
        public Employees_ByNameAndLastName()
        {
            Map = employees => from employee in employees
                               select new
                               {
                                   employee.Name,
                                   employee.LastName
                               };
        }
    }

    public class Employees_ByAccessLevel : AbstractIndexCreationTask<Employee>
    {
        public Employees_ByAccessLevel()
        {
            Map = employees => from employee in employees
                               select new
                               {
                                   employee.AccessLevel
                               };
        }
    }

    public class Books_TotalBookCount : AbstractIndexCreationTask<Book, Books_TotalBookCount.Result>
    {
        public class Result
        {
            public string Title { get; set; }
            public uint TotalCount { get; set; }
        }

        public Books_TotalBookCount()
        {
            Map = books => from book in books
                           select new
                           {
                               Title = book.Title,
                               TotalCount = book.BookQuantity
                           };
            Reduce = results => from result in results
                                group result by result.Title into g
                                select new
                                {
                                    Title = g.Key,
                                    TotalCount = g.Sum(x => x.TotalCount)
                                };
        }
    }
}