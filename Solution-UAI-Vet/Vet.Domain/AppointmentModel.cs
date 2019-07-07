using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet.Services;

namespace Vet.Domain
{
    public partial class AppointmentModel : IEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Hour { get; set; }
        public DoctorModel Doctor { get; set; }
        public int DoctorId { get; set; }
        public PatientModel Patient { get; set; }
        public int PatientId { get; set; }
        public RoomModel Room { get; set; }
        public int RoomId { get; set; }
    }

    [MetadataType(typeof(AppointmentMetadata))]
    public partial class AppointmentModel
    {
        public class AppointmentMetadata
        {
            [Key]
            [Required]
            public int Id { get; set; }

            [Required]
            public DateTime Date { get; set; }

            [Required]
            public int Hour { get; set; }
        }
    }
}
