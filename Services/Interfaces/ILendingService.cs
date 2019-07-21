using Entities;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{

    public interface ILendingService
    {
        bool UpdateLending(int id ,LendingModel lending);
        bool InsertLending(LendingModel lending);
        IEnumerable<LendingModel> GetAll();
        LendingModel GetById(int id);
    }
    
}
