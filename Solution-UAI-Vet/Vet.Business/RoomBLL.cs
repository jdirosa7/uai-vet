using ClientPatientManagement.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Vet.Domain;
using Vet.Services;

namespace Vet.Business
{
    public class RoomBLL : IRepository<RoomModel>
    {

        public void Delete(int id)
        {
            RoomRepository.Instancia.Delete(id);
        }

        public RoomModel GetById(int id)
        {
            return RoomRepository.Instancia.GetById(id);
        }

        public void Insert(RoomModel entity)
        {
            RoomRepository.Instancia.Insert(entity);
        }

        public IEnumerable<RoomModel> List()
        {
            return RoomRepository.Instancia.List();
        }

        public void Update(RoomModel entity)
        {
            RoomRepository.Instancia.Update(entity);
        }
    }
}
