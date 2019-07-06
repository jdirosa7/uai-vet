using ClientPatientManagement.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vet.Domain;
using Vet.Services;

namespace WebApp.Data
{
    public class ClientRepository : IRepository<ClientModel>
    {
        public static ClientRepository Instancia = new ClientRepository();

        public void Delete(int id)
        {
            var db = new VetDbContext();
            var client = db.Clients.Find(id);
            db.Clients.Remove(client);
            db.SaveChanges();
        }

        public ClientModel GetById(int id)
        {
            var db = new VetDbContext();
            var client = db.Clients.Find(id);
            return client;
        }

        public void Insert(ClientModel entity)
        {
            var db = new VetDbContext();
            db.Clients.Add(entity);
            db.SaveChanges();
        }

        public IEnumerable<ClientModel> List()
        {
            var db = new VetDbContext();
            IList<ClientModel> clients = db.Clients.ToList();
            return clients;
        }

        public void Update(ClientModel entity)
        {
            var db = new VetDbContext();
            var client = db.Clients.Find(entity.Id);

            if (client != null)
            {
                client.Name = entity.Name;
                client.LastName = entity.LastName;
                client.Email = entity.Email;

                db.SaveChanges();
            }
        }
    }
}