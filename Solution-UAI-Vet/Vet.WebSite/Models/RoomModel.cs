using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vet.Domain;
using Vet.Services;

namespace ClientPatientManagement.Core.Model
{
    public partial class RoomModel : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }


        public static RoomModel ToModel(Vet.Domain.Room entity)
        {
            return new RoomModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Location = entity.Location
            };
        }

        public static IEnumerable<RoomModel> ToModelList(IEnumerable<Vet.Domain.Room> entities)
        {
            IList<RoomModel> rooms = new List<RoomModel>();
            entities.ToList().ForEach(entity => rooms.Add(ToModel(entity)));

            return rooms;
        }

        public static Room FromModel(RoomModel model)
        {
            return new Room
            {
                Id = model.Id,
                Name = model.Name,
                Location = model.Location
            };
        }
    }
}