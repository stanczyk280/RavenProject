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

        public List<Client> GetClientsWithPaging(int pagenumber, int pagesize)
        {
            if (pagenumber > 0 || pagesize > 0)
            {
                var clients = Session
                .Query<Client>()
                .OrderBy(c => c.Name)
                .Skip((pagenumber - 1) * pagesize)
                .Take(pagesize);
                return clients.ToList();
            }
            else
            {
                Console.WriteLine("Invalid page number or page size. Returning empty query");
                return null;
            }
        }

        public List<Client> GetClientsByNameAndLastNameWithPaging(int pagenumber, int pagesize)
        {
            if (pagenumber > 0 || pagesize > 0)
            {
                var clients = Session
                .Query<Client>()
                .OrderBy(c => c.Name)
                .ThenBy(c => c.LastName)
                .Skip((pagenumber - 1) * pagesize)
                .Take(pagesize);
                return clients.ToList();
            }
            else
            {
                Console.WriteLine("Invalid page number or page size. Returning empty query");
                return null;
            }
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