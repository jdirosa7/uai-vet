using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet.Services;

namespace Vet.Domain
{
    public partial class Client : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int DNI { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
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

            [Required]
            public int DNI { get; set; }

            [StringLength(100)]
            [Required]
            public string Address { get; set; }

            [StringLength(50)]
            [Required]
            public string Phone { get; set; }

            [StringLength(50)]
            [Required]
            public string Email { get; set; }
        }
    }
}
