using System;
using System.Collections.Generic;
using System.Text;
using Vet.Domain;
using Vet.Services;
using WebApp.Data;

namespace Vet.Business
{
    public class ClientBLL : IRepository<Client>
    {
        public void Delete(int id)
        {
            ClientRepository.Instancia.Delete(id);
        }

        public Client GetById(int id)
        {
            return ClientRepository.Instancia.GetById(id);
        }

        public void Insert(Client entity)
        {
            ClientRepository.Instancia.Insert(entity);
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
