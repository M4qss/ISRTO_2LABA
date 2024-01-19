using LABA2_SERVER_PART.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace LABA2_SERVER_PART.Controllers
{
    public class ClientController : ApiController
    {
        static readonly IClientRepository repository = new ClientRepository();

        public IEnumerable<Clients> GetAllClients()
        {
            return repository.GetAll();
        }

        public Clients GetClients(int id)
        {
            Clients item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public HttpResponseMessage PostClient(Clients item)
        {
            item = repository.Add(item);
            var response = Request.CreateResponse<Clients>(HttpStatusCode.Created, item);

            string uri = Url.Link("DefaultApi", new { id = item.ID });
            response.Headers.Location = new Uri(uri);
            return response;
        }

        public void PutClient(int id, Clients client)
        {
            client.ID = id;
            if (!repository.Update(client))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        public void DeleteClient(int id)
        {
            repository.Remove(id);
        }

    }
}