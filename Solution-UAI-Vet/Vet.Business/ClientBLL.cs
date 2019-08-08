using System;
using System.Collections.Generic;
using System.Text;
using Vet.Domain;
using Vet.Services;
using WebApp.Data;
using System.Linq;

namespace Vet.Business
{
    public class ClientBLL : IRepository<Client>
    {
        public void Delete(int id)
        {
            ClientRepository.Instancia.Delete(id);
        }

        public IEnumerable<Client> GetByFilters(Client entity)
        {
            return ClientRepository.Instancia.GetByFilters(entity);
        }

        public Client GetById(int id)
        {
            return ClientRepository.Instancia.GetById(id);
        }

        public Client Insert(Client entity)
        {
            var clients = this.GetByFilters(entity);
            if (clients.Count() == 0)
            {
                ClientRepository.Instancia.Insert(entity);
                return entity;
            }
            else
            {                
                return null;
            }
        }

        public IEnumerable<Client> List()
        {
            return ClientRepository.Instancia.List();
        }

        public void Update(Client entity)
        {
            ClientRepository.Instancia.Update(entity);
        }
    }
}
