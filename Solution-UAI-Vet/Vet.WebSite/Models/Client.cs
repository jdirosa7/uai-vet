using Vet.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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
}