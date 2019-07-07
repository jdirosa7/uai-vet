using Vet.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vet.Domain;

namespace ClientPatientManagement.Core.Model
{
    public partial class Client : IEntity
    {        
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public static Client ToModel(ClientModel entity)
        {
            return new Client
            {
                Id = entity.Id,
                Name = entity.Name,
                LastName = entity.LastName,
                Email = entity.Email
            };
        }

        public static IEnumerable<Client> ToModelList(IEnumerable<ClientModel> entities)
        {
            IList<Client> clients = new List<Client>();
            entities.ToList().ForEach(entity => clients.Add(ToModel(entity)));

            return clients;
        }

        public static ClientModel FromModel(Client model)
        {
            return new ClientModel
            {
                Id = model.Id,
                Name = model.Name,
                LastName = model.LastName,
                Email = model.Email
            };
        }
    }    
}