using System;
using System.Collections.Generic;
using System.Text;
using Vet.Domain;
using Vet.Services;
using WebApp.Data;

namespace Vet.Business
{
    public class ClientBLL : IRepository<ClientModel>
    {
        public void Delete(int id)
        {
            ClientRepository.Instancia.Delete(id);
        }

        public ClientModel GetById(int id)
        {
            return ClientRepository.Instancia.GetById(id);
        }

        public void Insert(ClientModel entity)
        {
            ClientRepository.Instancia.Insert(entity);
        }

        public IEnumerable<ClientModel> List()
        {
            return ClientRepository.Instancia.List();
        }

        public void Update(ClientModel entity)
        {
            ClientRepository.Instancia.Update(entity);
        }
    }
}
