using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Vet.Domain;
using Vet.Services;

namespace ClientPatientManagement.Core.Data
{
    public class RoomRepository : IRepository<RoomModel>
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

        public RoomModel GetById(int id)
        {
            var db = new VetDbContext();
            var room = db.Rooms.Find(id);
            return room;
        }

        public void Insert(RoomModel entity)
        {
            var db = new VetDbContext();
            db.Rooms.Add(entity);
            db.SaveChanges();
        }

        public IEnumerable<RoomModel> List()
        {   
            var db = new VetDbContext();
            IList<RoomModel> rooms = db.Rooms.ToList();
            return rooms;
        }

        public void Update(RoomModel entity)
        {
            var db = new VetDbContext();
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }        
    }
}