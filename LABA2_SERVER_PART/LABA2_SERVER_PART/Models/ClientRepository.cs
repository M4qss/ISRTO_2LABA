using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LABA2_SERVER_PART.Models
{
    public class ClientRepository : IClientRepository
    {
        private List<Clients> clients = new List<Clients>();
        Entities entities = new Entities();
        public ClientRepository()
        {
            ClientRepUpdate();
        }
        public void ClientRepUpdate()
        {
            List<CLIENTS> buffClients = entities.CLIENTS.ToList<CLIENTS>();
            List<Clients> resClients = new List<Clients>();
            foreach (CLIENTS cl in buffClients)
            {
                resClients.Add(RConvert(cl));
            }
            clients = resClients;
        }
        public Clients RConvert(CLIENTS input)
        {
            return new Clients() { ID = input.ID, AGE = input.AGE, FIO = input.FIO };
        }
        public CLIENTS RConvert(Clients input)
        {
            return new CLIENTS() { ID = input.ID, AGE = input.AGE, FIO = input.FIO };
        }
        public Clients Add(Clients item)
        {
            if (item == null)
                throw new ArgumentNullException();
            
            entities.CLIENTS.Add(RConvert(item));
            entities.SaveChanges();
            return item;
        }

        public Clients Get(int id)
        {
            ClientRepUpdate();
            return clients.Find(p => p.ID == id);
        }

        public IEnumerable<Clients> GetAll()
        {
            ClientRepUpdate();
            return clients;
        }

        public void Remove(int id)
        {
            entities.CLIENTS.Remove(entities.CLIENTS.Find(id));
            entities.SaveChanges();
        }

        public bool Update(Clients item)
        {
            if (item == null)
                throw new ArgumentNullException();
            int index = clients.FindIndex(p => p.ID == item.ID);
            if (index == -1)
                return false;
            clients.RemoveAt(index);
            clients.Add(item);
            return true;
        }

    }
}