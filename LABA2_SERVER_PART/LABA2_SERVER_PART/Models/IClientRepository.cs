using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA2_SERVER_PART.Models
{
    interface IClientRepository
    {
        IEnumerable<Clients> GetAll();
        Clients Get(int id);
        Clients Add(Clients item);
        void Remove(int id);
        bool Update(Clients item);

    }
}
