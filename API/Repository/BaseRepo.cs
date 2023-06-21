using Persistence;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Repository
{
    public class BaseRepo
    {
        protected IDocumentStore Store { get; }
        protected IDocumentSession Session { get; }

        public BaseRepo()
        {
            Store = DocumentStoreHolder.Store;
            Session = Store.OpenSession();
            Session.Advanced.WaitForIndexesAfterSaveChanges(timeout: TimeSpan.FromSeconds(5), throwOnTimeout: false);
        }
    }
}