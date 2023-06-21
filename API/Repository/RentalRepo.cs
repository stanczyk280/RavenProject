using Domain;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Repository
{
    public class RentalRepo : BaseRepo
    {
        public void RentBookToClient(string clientId, Rental rental)
        {
            var client = Session.Load<Client>(clientId);

            if (client.Rental.Count > 3)
            {
                Console.WriteLine("Client exceeded the rental limit");
                return;
            }
            else
            {
                client.Rental.Add(rental);
                var book = Session.Load<Book>(rental.Book.Id);
                book.BookQuantity.Borrowed++;
            }
            Session.SaveChanges();
        }

        public void ReturnBook(string clientId, string rentalId)
        {
            var client = Session.Load<Client>(clientId);

            var rentalToRemove = client.Rental.FirstOrDefault(r => r.Id == rentalId);

            if (rentalToRemove != null)
            {
                var book = Session.Load<Book>(rentalToRemove.Book.Id);
                book.BookQuantity.Borrowed--;
                client.Rental.Remove(rentalToRemove);
                Session.SaveChanges();
                Console.WriteLine("Book returned successfully.");
            }
            else
            {
                Console.WriteLine("Rental not found.");
            }
        }
    }
}