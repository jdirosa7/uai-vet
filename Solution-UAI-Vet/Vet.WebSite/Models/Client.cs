using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApp.Data;

namespace ClientPatientManagement.Core.Model
{
    public partial class Client : IEntity
    {
        public Client()
        {
            
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
 
    }

    [MetadataType(typeof(ClientMetadata))]
    public partial class Client
    {
        public class ClientMetadata
        {
            [Key]
            [Required]
            public int Id { get; set; }

            [StringLength(50)]
            [Required]
            public string Name { get; set; }

            [StringLength(50)]
            [Required]
            public string LastName { get; set; }

            [StringLength(50)]
            [Required]
            public string Email { get; set; }
        }
    }

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