using Vet.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vet.Domain;

namespace ClientPatientManagement.Core.Model
{
    public partial class ClientModel : IEntity
    {        
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int DNI { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public static ClientModel ToModel(Client entity)
        {
            return new ClientModel
            {
                Id = entity.Id,
                Name = entity.Name,
                LastName = entity.LastName,
                DNI = entity.DNI,
                Address = entity.Address,
                Phone = entity.Phone,                
                Email = entity.Email
            };
        }

        public static IEnumerable<ClientModel> ToModelList(IEnumerable<Client> entities)
        {
            IList<ClientModel> clients = new List<ClientModel>();
            entities.ToList().ForEach(entity => clients.Add(ToModel(entity)));

            return clients;
        }

        public static Client FromModel(ClientModel model)
        {
            return new Client
            {
                Id = model.Id,
                Name = model.Name,
                LastName = model.LastName,
                DNI = model.DNI,
                Address = model.Address,
                Phone = model.Phone,
                Email = model.Email
            };
        }
    }    
}