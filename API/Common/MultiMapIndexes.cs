using Domain;
using Raven.Client.Documents.Indexes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Common
{
    public class MultiMapIndexes
    {
        public class People_Search : AbstractMultiMapIndexCreationTask<People_Search.Result>
        {
            public class Result
            {
                public string PersonId { get; set; }
                public string Name { get; set; }
                public string LastName { get; set; }
                public string Email { get; set; }
            }

            public People_Search()
            {
                AddMap<Client>(clients =>
                    from client in clients
                    select new Result
                    {
                        PersonId = client.Id,
                        Name = client.Name,
                        LastName = client.LastName,
                        Email = client.Email
                    });

                AddMap<Employee>(employees =>
                    from client in employees
                    select new Result
                    {
                        PersonId = client.Id,
                        Name = client.Name,
                        LastName = client.LastName,
                        Email = client.Email
                    });

                Index(entry => entry.Name, FieldIndexing.Search);

                Store(entry => entry.PersonId, FieldStorage.Yes);
                Store(entry => entry.Name, FieldStorage.Yes);
                Store(entry => entry.LastName, FieldStorage.Yes);
                Store(entry => entry.Email, FieldStorage.Yes);
            }
        }
    }
}