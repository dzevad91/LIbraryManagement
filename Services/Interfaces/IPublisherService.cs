using Entities;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{

    public interface IPublisherService
    {
        bool UpdatePublisher(int id ,PublisherModel publisher);
        bool InsertPublisher(PublisherModel publisher);
        IEnumerable<PublisherModel> GetAll();
        PublisherModel GetById(int id);
        bool Delete(int id);
    }
    
}
