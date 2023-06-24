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
            Seed.SeedData();
        }
    }
}