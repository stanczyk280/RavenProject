using System.Globalization;
using Domain;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;

namespace Persistence
{
    public static class Seed
    {
        public static void SeedData()
        {
            var cultureInfo = new CultureInfo("pl-PL");

            using (var session = DocumentStoreHolder.Store.OpenSession())
            {
                var query = from Book in session.Query<Book>() select Book;
                var result = query.ToList();
                if (result.Count != 0) return;
            }

            var books = new List<Book>
            {
                new Book()
                {
                    Title= "Title",
                    Author = "Author",
                    Publisher = "Publisher",
                    Published = new DateOnly(1998,1,1),
                    Category = "Category",
                    Description = "Description",
                    BookQuantity = new BookQuantity
                    {
                        Quantity = 1,
                        Borrowed = 0
                    }
                },

                new Book()
        {
                    Title = "Ołowiany Świt",
                    Author = "Michał Gołkowski",
                    Publisher = "Fabryka Słów",
                    Published = new DateOnly(2013,4,26),
                    Category = "Fantastyka",
                    Description = "Zona - tajemnica, która wciąga, kusi i intryguje.\r\n\r\nJej historią jest świat współczesny. Jej dzieci to my.\r\n\r\nUniwersum S.T.A.L.K.E.R.a oczami Polaka – stara mleczarnia, martwy cieć, zapomniany kalendarz i wieża w środku lasu.\r\n\r\nWchodzisz w to? Zresztą, już jesteś. Wszyscy jesteśmy – stalkerami. Dziećmi Sarkofagu.\r\n\r\nTutaj wrogiem jest zło, które może czaić się tuż obok, za naszymi plecami. Może przyjmować różne postaci, imiona i kształty; jednak najstraszniejszym, co możemy spotkać w Zonie - jest człowiek.\r\n\r\nWstaje nowy dzień. Czy przeżyjesz go - całym sobą?",
                    BookQuantity = new BookQuantity
                    {
                        Quantity = 100,
                        Borrowed = 0
                    }
                },

                new Book()
        {
            Title = "Stalowe Szczury. Błoto",
                    Author = "Michał Gołkowski",
                    Publisher = "Fabryka Słów",
                    Published = new DateOnly(2015,1,1),
                    Category = "Fantastyka",
                    Description = "Wiosna 1922. Samobójcze natarcie na pozycje przeciwnika po raz kolejny prowadzi kapral Reinhardt i jego kompania karna – kundle wojny, dezerterzy, podpalacze i najgorsze szumowiny. Straceńcy gotowi na wszystko.",
                    BookQuantity = new BookQuantity
                    {
                        Quantity = 150,
                        Borrowed = 0
                    }
                },

                new Book()
        {
            Title = "Komornik",
                    Author = "Michał Gołkowski",
                    Publisher = "Fabryka Słów",
                    Published = new DateOnly(2016,1,1),
                    Category = "Fantastyka",
                    Description = "Nadchodzi Koniec.\r\nAle taki w cholerę prawdziwy, biblijny. Ziemia zatrzymuje się, gwiazdy spadają, woda zamienia się w krew. Umarli wstają z grobów, otwiera się otchłań. Państwa upadają, brat powstaje przeciw bratu, a dzieci podnoszą rękę na rodziców. Widać, że lada chwila świat spłonie.\r\nTylko że coś w systemie nie zaskoczyło. Generalnie, zasadniczo i pobieżnie: zamiast bomby termojądrowej wychodzi fajerwerk.",
                    BookQuantity = new BookQuantity
                    {
                        Quantity = 80,
                        Borrowed = 0
                    }
                },

                new Book()
        {
            Title = "Inside RavenDB 4.0",
                    Author = "Oren Eini",
                    Publisher = "HybernatingRhinos",
                    Published = new DateOnly(2017,1,1),
                    Category = "Poradniki",
                    Description = "What you're reading now is effectively a book-length blog post. The main idea here is that I want to give you a way to grok RavenDB.2 This means not only gaining knowledge of what RavenDB does, but also all the reasoning behind the bytes. In effect, I want you to understand all the whys of RavenDB.",
                    BookQuantity = new BookQuantity
                    {
                        Quantity = 200,
                        Borrowed = 0
                    }
                },
            };
            var clients = new List<Client>
            {
                new Client()
                {
                    Name = "John",
                    LastName = "Doe",
                    BirthDate = new DateOnly(1990, 5, 15),
                    Country = "United States",
                    City = "New York",
                    Street = "123 Main Street",
                    PostalCode = "10001",
                    Email = "john.doe@example.com",
                    PhoneNumber = "555-1234",
                    Rental = new List<Rental>()
                },
                new Client()
                {
                    Name = "Alice",
                    LastName = "Johnson",
                    BirthDate = new DateOnly(1992, 8, 20),
                    Country = "United States",
                    City = "Chicago",
                    Street = "789 Oak Street",
                    PostalCode = "60601",
                    Email = "alice.johnson@example.com",
                    PhoneNumber = "555-9012",
                    Rental = new List<Rental>()
                },
                new Client()
                {
                    Name = "David",
                    LastName = "Brown",
                    BirthDate = new DateOnly(1987, 3, 12),
                    Country = "United Kingdom",
                    City = "London",
                    Street = "456 High Street",
                    PostalCode = "SW1A 1AA",
                    Email = "david.brown@example.com",
                    PhoneNumber = "555-3456",
                    Rental = new List<Rental>()
                },
                new Client()
                {
                    Name = "Sophia",
                    LastName = "Wilson",
                    BirthDate = new DateOnly(1995, 11, 5),
                    Country = "Canada",
                    City = "Toronto",
                    Street = "321 Maple Avenue",
                    PostalCode = "M5H 2N2",
                    Email = "sophia.wilson@example.com",
                    PhoneNumber = "555-6789",
                    Rental = new List<Rental>()
                },
                new Client()
                {
                    Name = "Michael",
                    LastName = "Lee",
                    BirthDate = new DateOnly(1990, 6, 30),
                    Country = "Australia",
                    City = "Sydney",
                    Street = "987 George Street",
                    PostalCode = "2000",
                    Email = "michael.lee@example.com",
                    PhoneNumber = "555-2345",
                    Rental = new List<Rental>()
                }
             };

            var employees = new List<Employee>
            {
                new Employee()
                {
                    Name = "Jane",
                    LastName = "Smith",
                    BirthDate = new DateOnly(1985, 9, 10),
                    Country = "United States",
                    City = "Los Angeles",
                    Street = "456 Elm Street",
                    PostalCode = "90001",
                    Email = "jane.smith@example.com",
                    PhoneNumber = "555-5678",
                    AccessLevel = "Manager"
                },
                new Employee()
                {
                    Name = "John",
                    LastName = "Smith",
                    BirthDate = new DateOnly(1985, 12, 10),
                    Country = "United States",
                    City = "New York",
                    Street = "123 Main Street",
                    PostalCode = "10001",
                    Email = "john.smith@example.com",
                    PhoneNumber = "555-1234",
                    AccessLevel = "Admin"
                },
                new Employee()
                {
                    Name = "Emily",
                    LastName = "Johnson",
                    BirthDate = new DateOnly(1990, 6, 15),
                    Country = "United Kingdom",
                    City = "London",
                    Street = "456 Park Lane",
                    PostalCode = "SW1A 2AB",
                    Email = "emily.johnson@example.com",
                    PhoneNumber = "555-5678",
                    AccessLevel = "Standard"
                },
                new Employee()
                {
                    Name = "Daniel",
                    LastName = "Brown",
                    BirthDate = new DateOnly(1988, 4, 22),
                    Country = "Canada",
                    City = "Toronto",
                    Street = "789 Elm Street",
                    PostalCode = "M4W 1N4",
                    Email = "daniel.brown@example.com",
                    PhoneNumber = "555-9012",
                    AccessLevel = "Standard"
                },
                new Employee()
                {
                    Name = "Sophia",
                    LastName = "Wilson",
                    BirthDate = new DateOnly(1993, 9, 7),
                    Country = "Australia",
                    City = "Sydney",
                    Street = "987 Queen Street",
                    PostalCode = "2000",
                    Email = "sophia.wilson@example.com",
                    PhoneNumber = "555-3456",
                    AccessLevel = "Standard"
                }
            };

            using (var session = DocumentStoreHolder.Store.OpenSession())
            {
                foreach (var book in books)
                {
                    session.Store(book);
                }

                foreach (var client in clients)
                {
                    session.Store(client);
                }

                foreach (var employee in employees)
                {
                    session.Store(employee);
                }

                session.SaveChanges();
                Console.WriteLine("Seed successful");
            }
        }
    }
}