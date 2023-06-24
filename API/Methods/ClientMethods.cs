using API.Repository;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Methods
{
    public class ClientMethods : ClientRepo
    {
        public RentalRepo rentalRepo = new RentalRepo();
        public BooksRepo booksRepo = new BooksRepo();

        public void DisplayClient(string id)
        {
            if (!id.Contains("clients/"))
            {
                id = "clients/" + id;
            }
            var client = GetClient(id);
            if (client == null)
            {
                Console.WriteLine("No client of given id exists");
                return;
            }

            Console.WriteLine("Id: " + client.Id);
            Console.WriteLine("Name: " + client.Name);
            Console.WriteLine("LastName: " + client.LastName);
            Console.WriteLine("BirthDate: " + client.BirthDate.ToString("yyyy-MM-dd"));
            Console.WriteLine("Country: " + client.Country);
            Console.WriteLine("City: " + client.City);
            Console.WriteLine("Street: " + client.Street);
            Console.WriteLine("PostalCode: " + client.PostalCode);
            Console.WriteLine("Email: " + client.Email);
            Console.WriteLine("PhoneNumber: " + client.PhoneNumber);

            if (client.Rental != null && client.Rental.Count > 0)
            {
                Console.WriteLine("Rentals:");

                foreach (var rental in client.Rental)
                {
                    Console.WriteLine("  RentalId: " + rental.Id);
                    Console.WriteLine("  Rented Book: " + rental.Book.Id + "\n" + rental.Book.Title + "\n" + rental.Book.Author);
                    Console.WriteLine("  Rental release date: " + rental.ReleaseDate.ToShortDateString());
                    Console.WriteLine("  Rental due date: " + rental.ReturnDate.ToShortDateString());
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No rentals found for this client.");
            }
        }

        public void DisplayClientsList()
        {
            var clients = GetClients();
            foreach (var client in clients)
            {
                DisplayClient(client.Id);
                Console.WriteLine("========================\n");
            }
        }

        public void DisplayClientsListSimple()
        {
            Console.WriteLine("Please enter desired page number: ");
            int pagenumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter desired page size: ");
            int pagesize = Convert.ToInt32(Console.ReadLine());

            var clients = GetClientsByNameAndLastNameWithPaging(pagenumber, pagesize);
            foreach (var client in clients)
            {
                int i = 1;
                Console.WriteLine(i + ". Name: " + client.Name + " " + client.LastName + ", Email" + client.Email);
                i++;
            }
        }

        public void CreateClient()
        {
            Console.WriteLine("Add new client to the system\n");
            Console.WriteLine("Please enter correct values\n");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("\nLast Name: ");
            string lastName = Console.ReadLine();
            Console.Write("\nBirth Date (Year, Month, Day): ");
            string birthDateString = Console.ReadLine();
            DateOnly birthDate = DateOnly.Parse(birthDateString);
            Console.Write("\nCountry: ");
            string country = Console.ReadLine();
            Console.Write("\nCity: ");
            string city = Console.ReadLine();
            Console.Write("\nStreet: ");
            string street = Console.ReadLine();
            Console.Write("\nPostal Code: ");
            string postalCode = Console.ReadLine();
            Console.Write("\nEmail: ");
            string email = Console.ReadLine();
            Console.Write("\nPhone Number: ");
            string phoneNumber = Console.ReadLine();

            Client client = new Client()
            {
                Name = name,
                LastName = lastName,
                BirthDate = birthDate,
                Country = country,
                City = city,
                Street = street,
                PostalCode = postalCode,
                Email = email,
                PhoneNumber = phoneNumber,
                Rental = new List<Rental>()
            };

            CreateClient(client);
        }

        public void RentBook(string id)
        {
            id = "clients/" + id;
            var client = GetClient(id);
            if (client == null)
            {
                Console.WriteLine("No client of given id exists");
                return;
            }

            Console.WriteLine("Create a new rental\n");
            Console.WriteLine("Please enter the following information:\n");

            Console.Write("Book Id: ");
            string bookId = Console.ReadLine();

            bookId = "books/" + bookId;
            var book = booksRepo.GetBook(bookId);
            if (book == null)
            {
                Console.WriteLine("No book of given id exists");
                return;
            }

            Console.Write("\nRelease Date (Year, Month, Day): ");
            string releaseDateString = Console.ReadLine();
            DateOnly releaseDate = DateOnly.Parse(releaseDateString);

            DateOnly returnDate = releaseDate.AddDays(14); // Set return date to 2 weeks from release date

            Rental rental = new Rental()
            {
                Book = book,
                ReleaseDate = releaseDate,
                ReturnDate = returnDate
            };

            rentalRepo.RentBookToClient(id, rental);
        }

        public void DisplayRentalList(string id)
        {
            id = "clients/" + id;
            var client = GetClient(id);
            if (client == null)
            {
                Console.WriteLine("No client of given id exists");
                return;
            }

            var rentals = client.Rental;

            int i = 1;
            Console.WriteLine("Books rented to client: ");
            foreach (var rental in rentals)
            {
                Console.WriteLine(" Rental id: " + rental.Id);
                Console.WriteLine("  " + i + ". Id: " + rental.Book.Id + "\nTitle: " + rental.Book.Title + "\nRelease date: " + rental.ReleaseDate.ToShortDateString() + "\nDue date: " + rental.ReturnDate.ToShortDateString());
                Console.WriteLine("========================");
            }
        }

        public void ReturnBook()
        {
            Console.WriteLine("Enter Client Id: ");
            string clientId = Console.ReadLine();
            clientId = "clients/" + clientId;
            var client = GetClient(clientId);

            if (client == null)
            {
                Console.WriteLine("No client of given id exists");
                return;
            }

            DisplayRentalList(clientId);

            Console.WriteLine("Enter Rental Id:");
            string rentalId = Console.ReadLine();
            rentalId = "rentals/" + rentalId;

            rentalRepo.ReturnBook(clientId, rentalId);
        }

        public void UpdateClient(string id)
        {
            id = "clients/" + id;
            var client = GetClient(id);
            if (client == null)
            {
                Console.WriteLine("No client of " + id + " exists");
                return;
            }

            Console.WriteLine("Update client in the system\n");
            Console.WriteLine("Please enter correct values or leave them empty if you do not wish to change the value\n");

            Console.Write("Name: ");
            string name = Console.ReadLine();
            string newName = string.IsNullOrEmpty(name) ? client.Name : name;

            Console.Write("\nLast Name: ");
            string lastName = Console.ReadLine();
            string newLastName = string.IsNullOrEmpty(lastName) ? client.LastName : lastName;

            Console.Write("\nBirth Date (Year, Month, Day): ");
            string birthDateString = Console.ReadLine();
            DateOnly birthDate = string.IsNullOrEmpty(birthDateString) ? client.BirthDate : DateOnly.Parse(birthDateString);

            Console.Write("\nCountry: ");
            string country = Console.ReadLine();
            string newCountry = string.IsNullOrEmpty(country) ? client.Country : country;

            Console.Write("\nCity: ");
            string city = Console.ReadLine();
            string newCity = string.IsNullOrEmpty(city) ? client.City : city;

            Console.Write("\nStreet: ");
            string street = Console.ReadLine();
            string newStreet = string.IsNullOrEmpty(street) ? client.Street : street;

            Console.Write("\nPostal Code: ");
            string postalCode = Console.ReadLine();
            string newPostalCode = string.IsNullOrEmpty(postalCode) ? client.PostalCode : postalCode;

            Console.Write("\nEmail: ");
            string email = Console.ReadLine();
            string newEmail = string.IsNullOrEmpty(email) ? client.Email : email;

            Console.Write("\nPhone Number: ");
            string phoneNumber = Console.ReadLine();
            string newPhoneNumber = string.IsNullOrEmpty(phoneNumber) ? client.PhoneNumber : phoneNumber;

            Client newClient = new Client()
            {
                Id = client.Id,
                Name = newName,
                LastName = newLastName,
                BirthDate = birthDate,
                Country = newCountry,
                City = newCity,
                Street = newStreet,
                PostalCode = newPostalCode,
                Email = newEmail,
                PhoneNumber = newPhoneNumber,
                Rental = client.Rental
            };

            UpdateClient(id, newClient);
        }

        public void DeleteClientFromSystem(string id)
        {
            id = "clients/" + id;
            var client = GetClient(id);
            if (client == null)
            {
                Console.WriteLine("No book of given id exists");
                return;
            }
            DeleteClient(id);
        }
    }
}