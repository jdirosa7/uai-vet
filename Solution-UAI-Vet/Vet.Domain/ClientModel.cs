﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet.Services;

namespace Vet.Domain
{
    public partial class ClientModel : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }

    [MetadataType(typeof(ClientMetadata))]
    public partial class ClientModel
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
}
