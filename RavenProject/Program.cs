using API.Common;
using API.Methods;
using Persistence;
using Raven.Client.Documents.Session;

namespace RavenProject
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BookMethods m = new BookMethods();
            using (var session = DocumentStoreHolder.Store.OpenSession())
            {
                session.SeedData();
            }
            //m.DisplayBooksList();
            //m.CreateBook();
            //m.UpdateBook("97-A");
            //m.DeleteBookFromSystem("65-A");
        }
    }
}