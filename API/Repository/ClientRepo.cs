using Domain;
using Persistence;
using Raven.Client.ServerWide.Operations.Certificates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Repository
{
    public class ClientRepo : BaseRepo
    {
        public List<Client> GetClients()
        {
            var clients = Session
                .Query<Client>()
                .ToList();
            return clients;
        }

        public Client GetClient(string id)
        {
            var client = Session.Load<Client>(id);
            return client;
        }

        public void CreateClient(Client newClient)
        {
            Session.Store(newClient);
            Session.SaveChanges();
        }

        public void UpdateClient(string id, Client newClient)
        {
            var client = Session.Load<Client>(id);
            client.Name = newClient.Name; ;
            client.LastName = newClient.LastName;
            client.BirthDate = newClient.BirthDate;
            client.Country = newClient.Country;
            client.City = newClient.City;
            client.Street = newClient.Street;
            client.PostalCode = newClient.PostalCode;
            client.Email = newClient.Email;
            client.PhoneNumber = newClient.PhoneNumber;
            Session.SaveChanges();
        }

        public void DeleteClient(string id)
        {
            var client = Session.Load<Client>(id);
            if (client == null)
            {
                Console.WriteLine("not found");
                return;
            }
            Session.Delete(client);
            Session.SaveChanges();
        }
    }
}