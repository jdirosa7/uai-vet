using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet.Services;

namespace Vet.Domain
{
    public class PatientModel : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ClientModel Owner { get; private set; }
        public int ClientId { get; set; }
        public GenderModel Gender { get; set; }
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
            public GenderModel Gender { get; set; }
        }
    }
}
