using Data2;
using Entities;
using Services.Interfaces;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ClientService : IClientService
    {
        private readonly LibraryManagementDataContext db;

        public ClientService()
        {
            db = new LibraryManagementDataContext();
        }

        public IEnumerable<ClientModel> GetAll()
        {
            var result = db.Clients.Select(x => new ClientModel()
            {
                Id = x.Id,
                Name = x.Name,
                Phone = x.Phone,
                Address = x.Address,
                City = x.City
            });
            return result;
        }

        public ClientModel GetById(int id)
        {
            var dbClient = db.Clients.FirstOrDefault(x => x.Id == id);
            if (dbClient == null)
            {
                return null;

            }
            else
            {
                var client = new ClientModel()
                {
                    Id = dbClient.Id,
                    Name = dbClient.Name,
                    Phone = dbClient.Phone,
                    City = dbClient.City,
                    Address = dbClient.Address
                };

                return client;
            }

        }

        public bool InsertClient(ClientModel client)
        {
            try
            {
                var dbClient = new Client()
                {
                    Id = client.Id,
                    Name = client.Name,
                    Phone = client.Phone,
                    City = client.City,
                    Address = client.Address
                };

                db.Clients.Add(dbClient);
                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var dbclient = db.Clients.FirstOrDefault(x => x.Id == id);
                db.Clients.Remove(dbclient);

                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdateClient ( int id , ClientModel client)
        {
            try
            {
                var dbclient = db.Clients.FirstOrDefault(x => x.Id == id);

                dbclient.Name = client.City;
                dbclient.Phone = client.Phone;
                dbclient.Address = client.Address;
                dbclient.City = client.City;

                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

    }
}
