using ClientPatientManagement.Core.Data;
using ClientPatientManagement.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClientPatientManagement.Core.Model
{
    public partial class Room : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }

    [MetadataType(typeof(RoomMetadata))]
    public partial class Room
    {
        public class RoomMetadata
        {
            [Key][Required]
            public int Id { get; set; }

            [StringLength(50)][Required]
            public string Name { get; set; }

            [StringLength(50)][Required]
            public string Location { get; set; }
        }
    }

    public class RoomModel
    {
        public IEnumerable<Room> TraerSalas()
        {
            return RoomRepository.Instancia.List();
        }

        public void AgregarRoom(string name, string location)
        {
            RoomRepository.Instancia.Insert(new Room()
            {
                Name = name,
                Location = location
            });
        }

        public Room ObtenerRoomById(int id)
        {
            return RoomRepository.Instancia.GetById(id);
        }

        public void ActualizarRoom(Room room)
        {
            RoomRepository.Instancia.Update(room);
        }

        public void EliminarRoom(int id)
        {
            RoomRepository.Instancia.Delete(id);
        }
    }
}