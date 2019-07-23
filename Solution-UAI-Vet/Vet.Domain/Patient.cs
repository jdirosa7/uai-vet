using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet.Services;

namespace Vet.Domain
{
    public partial class Patient : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Client Owner { get; set; }
        public int ClientId { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
    }

    [MetadataType(typeof(PatientMetadata))]
    public partial class Patient
    {
        public class PatientMetadata
        {
            [Key]
            [Required]
            public int Id { get; set; }

            [StringLength(50)]
            [Required]
            public string Name { get; set; }

            [Required]
            public Gender Gender { get; set; }

            [Required]
            public int Age { get; set; }
        }        
    }
}
