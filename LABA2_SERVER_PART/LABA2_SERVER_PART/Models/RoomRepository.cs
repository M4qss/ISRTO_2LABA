using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LABA2_SERVER_PART.Models
{
    public class RoomRepository : IRoomRepository
    {
        private List<Room> rooms = new List<Room>();
        Entities entities = new Entities();
        public RoomRepository()
        {
            RoomRepUpdate();
        }
        public Room RConvert(ROOM input)
        {
            return new Room(){ ID = input.ID, BEDS = input.BEDS, CLASS = input.CLASS, FLOOR = input.FLOOR };
        }
        public ROOM RConvert(Room input)
        {
            return new ROOM() { ID = input.ID, BEDS = input.BEDS, CLASS = input.CLASS, FLOOR = input.FLOOR };
        }
        public void RoomRepUpdate()
        {
            List<ROOM> buffRooms = entities.ROOM.ToList<ROOM>();
            List<Room> resRooms = new List<Room>();
            foreach(ROOM rm in buffRooms)
            {
                resRooms.Add(RConvert(rm));
            }
            rooms = resRooms;
        }
        public Room Add(Room item)
        {
            if (item == null)
                throw new ArgumentNullException();

            entities.ROOM.Add(RConvert(item));
            entities.SaveChanges();
            return item;
        }

        public Room Get(int id)
        {
            RoomRepUpdate();
            return rooms.Find(p => p.ID == id);
        }

        public IEnumerable<Room> GetAll()
        {
            RoomRepUpdate();
            return rooms;
        }

        public void Remove(int id)
        {
            entities.ROOM.Remove(entities.ROOM.Find(id));
            entities.SaveChanges();
        }

        public bool Update(Room item)
        {
            if (item == null)
                throw new ArgumentNullException();
            int index = rooms.FindIndex(p => p.ID == item.ID);
            if (index == -1)
                return false;
            rooms.RemoveAt(index);
            rooms.Add(item);
            return true;
        }

    }
}