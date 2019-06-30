using ClientPatientManagement.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Data;

namespace Vet.Domain
{
    public class ClientModel
    {
        public IEnumerable<Client> ObtenerClientes()
        {
            return ClientRepository.Instancia.List();
        }

        public void AgregarCliente(Client cliente)
        {
            ClientRepository.Instancia.Insert(cliente);
        }

        public Client ObtenerClienteById(int id)
        {
            return ClientRepository.Instancia.GetById(id);
        }

        public void ActualizarCliente(Client cliente)
        {
            ClientRepository.Instancia.Update(cliente);
        }

        public void EliminarCliente(int id)
        {
            ClientRepository.Instancia.Delete(id);
        }
    }
}
