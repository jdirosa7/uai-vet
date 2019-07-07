using ClientPatientManagement.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Vet.Domain;
using Vet.Services;

namespace Vet.Business
{
    public class RoomBLL : IRepository<Room>
    {

        public void Delete(int id)
        {
            RoomRepository.Instancia.Delete(id);
        }

        public Room GetById(int id)
        {
            return RoomRepository.Instancia.GetById(id);
        }

        public void Insert(Room entity)
        {
            RoomRepository.Instancia.Insert(entity);
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
