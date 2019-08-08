using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Vet.Domain;
using Vet.Services;

namespace ClientPatientManagement.Core.Data
{
    public class RoomRepository : IRepository<Room>
    {
        public static RoomRepository Instancia = new RoomRepository();

        private RoomRepository()
        {
            //Instancia = new RepositoryRoom();
        }

        public void Delete(int id)
        {
            var db = new VetDbContext();
            var room = db.Rooms.Find(id);
            db.Rooms.Remove(room);
            db.SaveChanges();
        }

        public IEnumerable<Room> GetByFilters(Room entity)
        {
            var db = new VetDbContext();
            var rooms = db.Rooms.Where(x => x.Location == entity.Location && x.Name == entity.Name).ToList();
            return rooms;
        }

        public Room GetById(int id)
        {
            var db = new VetDbContext();
            var room = db.Rooms.Find(id);
            return room;
        }

        public Room Insert(Room entity)
        {
            var db = new VetDbContext();
            db.Rooms.Add(entity);
            db.SaveChanges();
            return entity;
        }

        public IEnumerable<Room> List()
        {   
            var db = new VetDbContext();
            IList<Room> rooms = db.Rooms.ToList();
            return rooms;
        }

        public void Update(Room entity)
        {
            var db = new VetDbContext();
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }        
    }
}