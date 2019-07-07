using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vet.Domain;
using Vet.Services;

namespace ClientPatientManagement.Core.Model
{
    public partial class Room : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }


        public static Room ToModel(RoomModel entity)
        {
            return new Room
            {
                Id = entity.Id,
                Name = entity.Name,
                Location = entity.Location
            };
        }

        public static IEnumerable<Room> ToModelList(IEnumerable<RoomModel> entities)
        {
            IList<Room> rooms = new List<Room>();
            entities.ToList().ForEach(entity => rooms.Add(ToModel(entity)));

            return rooms;
        }

        public static RoomModel FromModel(Room model)
        {
            return new RoomModel
            {
                Id = model.Id,
                Name = model.Name,
                Location = model.Location
            };
        }
    }
}