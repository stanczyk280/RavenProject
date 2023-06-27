using API.Common;
using API.Methods;
using Persistence;
using Raven.Client.Documents.Session;
using System.Security.Cryptography.X509Certificates;

namespace RavenProject
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            MenuHandler handler = new MenuHandler();
            Seed.SeedData();

            handler.DisplayMenu();
            while (true)
            {
                handler.MainMenu();
            }
        }
    }
}