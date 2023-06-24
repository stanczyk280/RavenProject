using API.Common;
using Persistence;
using Raven.Client.Documents;
using Raven.Client.Documents.Indexes;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static API.Common.Books_CategoryBookCount;
using static API.Common.Indexes;
using static API.Common.MultiMapIndexes;

namespace API.Repository
{
    public class BaseRepo
    {
        protected IDocumentStore Store { get; }
        protected IDocumentSession Session { get; }

        public BaseRepo()
        {
            Store = DocumentStoreHolder.Store;
            IndexCreation.CreateIndexes(typeof(BooksIndex).Assembly, Store);
            IndexCreation.CreateIndexes(typeof(ClientsIndex).Assembly, Store);
            IndexCreation.CreateIndexes(typeof(EmployeesIndex).Assembly, Store);
            IndexCreation.CreateIndexes(typeof(Books_ByAuthor).Assembly, Store);
            IndexCreation.CreateIndexes(typeof(Clients_ByNameAndLastName).Assembly, Store);
            IndexCreation.CreateIndexes(typeof(Employees_ByNameAndLastName).Assembly, Store);
            IndexCreation.CreateIndexes(typeof(Employees_ByAccessLevel).Assembly, Store);
            IndexCreation.CreateIndexes(typeof(Books_CategoryBookCount).Assembly, Store);
            IndexCreation.CreateIndexes(typeof(Employees_AccessLevelCount).Assembly, Store);
            IndexCreation.CreateIndexes(typeof(People_Search).Assembly, Store);
            IndexCreation.CreateIndexes(typeof(Book_Search).Assembly, Store);
            Session = Store.OpenSession();
            Session.Advanced.WaitForIndexesAfterSaveChanges(timeout: TimeSpan.FromSeconds(5), throwOnTimeout: false);
        }
    }
}