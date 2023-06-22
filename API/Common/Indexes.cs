using Domain;
using Raven.Client.Documents.Indexes;

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
                                   book.Title,
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
                                     client.LastName,
                                     client.Email,
                                     client.Rental
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
                                   employee.LastName,
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
                                   employee.Name,
                                   employee.LastName,
                                   employee.AccessLevel
                               };
        }
    }

    public class Books_CategoryBookCount : AbstractIndexCreationTask<Book, Books_CategoryBookCount.Result>
    {
        public class Result
        {
            public string Category { get; set; }
            public uint TotalCount { get; set; }
        }

        public Books_CategoryBookCount()
        {
            Map = books => from book in books
                           select new
                           {
                               Category = book.Category,
                               TotalCount = 1
                           };
            Reduce = results => from result in results
                                group result by result.Category into g
                                select new
                                {
                                    Category = g.Key,
                                    TotalCount = g.Sum(x => x.TotalCount)
                                };
        }

        public class Employees_AccessLevelCount : AbstractIndexCreationTask<Employee, Employees_AccessLevelCount.Result>
        {
            public class Result
            {
                public string AccessLevel { get; set; }
                public uint TotalCount { get; set; }
            }

            public Employees_AccessLevelCount()
            {
                Map = employees => from employee in employees
                                   select new
                                   {
                                       AccessLevel = employee.AccessLevel,
                                       TotalCount = 0
                                   };
                Reduce = results => from result in results
                                    group result by result.AccessLevel into g
                                    select new
                                    {
                                        AccessLevel = g.Key,
                                        TotalCount = g.Sum(x => x.TotalCount)
                                    };
            }
        }
    }
}