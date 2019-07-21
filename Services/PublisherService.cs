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
    public class PublisherService : IPublisherService
    {
        private readonly LibraryManagementDataContext db;

        public PublisherService()
        {
            db = new LibraryManagementDataContext();
        }

        public IEnumerable<PublisherModel> GetAll()
        {
            var result = db.Publishers.Select(x => new PublisherModel()
            {
                Id = x.Id,
                Name = x.Name,
                Country = x.Country
            });

            return result;
        }

        public PublisherModel GetById(int id)
        {
            var dbPublisher = db.Publishers.FirstOrDefault(x => x.Id == id);
            if (dbPublisher == null)
            {
                return null;

            }
            else
            {
                var publisher = new PublisherModel()
                {
                    Id = dbPublisher.Id,
                    Name = dbPublisher.Name,
                    Country = dbPublisher.Country
                };

                return publisher;
            }

        }

        public bool InsertPublisher(PublisherModel publisher)
        {
            try
            {
                var dbpublisher = new Publisher()
                {
                    Id = publisher.Id,
                    Name = publisher.Name,
                    Country = publisher.Country
                };

                db.Publishers.Add(dbpublisher);
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
                var dbPublisher = db.Publishers.FirstOrDefault(x => x.Id == id);
                db.Publishers.Remove(dbPublisher);

                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UpdatePublisher ( int id , PublisherModel publisher)
        {
            try
            {
                var dbPublisher = db.Publishers.FirstOrDefault(x => x.Id == id);

                dbPublisher.Name = publisher.Name;
                dbPublisher.Country = publisher.Country;

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
