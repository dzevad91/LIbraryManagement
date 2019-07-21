using Entities;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{

    public interface IClientService
    {
        bool UpdateClient(int id ,ClientModel client);
        bool InsertClient(ClientModel client);
        IEnumerable<ClientModel> GetAll();
        ClientModel GetById(int id);
        bool Delete(int id);
    }
    
}
