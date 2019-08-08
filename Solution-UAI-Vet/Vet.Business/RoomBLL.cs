using ClientPatientManagement.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Vet.Domain;
using Vet.Services;
using System.Linq;

namespace Vet.Business
{
    public class RoomBLL : IRepository<Room>
    {

        public void Delete(int id)
        {
            RoomRepository.Instancia.Delete(id);
        }

        public IEnumerable<Room> GetByFilters(Room entity)
        {
            return RoomRepository.Instancia.GetByFilters(entity);
        }

        public Room GetById(int id)
        {
            return RoomRepository.Instancia.GetById(id);
        }

        public Room Insert(Room entity)
        {
            var rooms = this.GetByFilters(entity);
            if (rooms.Count() == 0)
            {
                RoomRepository.Instancia.Insert(entity);
                return entity;
            }
            else
            {
                return null;
            }            
        }

        public IEnumerable<Room> List()
        {
            return RoomRepository.Instancia.List();
        }

        public void Update(Room entity)
        {
            RoomRepository.Instancia.Update(entity);
        }
    }
}
