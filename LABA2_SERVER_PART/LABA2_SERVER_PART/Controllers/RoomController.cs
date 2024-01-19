using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using LABA2_SERVER_PART.Models;

namespace LABA2_SERVER_PART.Controllers
{
    public class RoomController : ApiController
    {
        static readonly IRoomRepository repository = new RoomRepository();

        public IEnumerable<Room> GetAllRooms()
        {
            return repository.GetAll();
        }

        public IEnumerable<Room> GetRooms(int id)
        {
            IEnumerable<Room> item = repository.GetAll();
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public HttpResponseMessage PostRooms(Room item)
        {
            item = repository.Add(item);
            var response = Request.CreateResponse<Room>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.ID });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutRoom(int id, Room room)
        {
            room.ID = id;
            if (!repository.Update(room))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeleteRoom(int id)
        {
            repository.Remove(id);
        }

    }
}