using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LABA2_SERVER_PART.Models
{
    public interface IRoomRepository
    {
        IEnumerable<Room> GetAll();
        Room Get(int id);
        Room Add(Room item);
        void Remove(int id);
        bool Update(Room item);

    }
}