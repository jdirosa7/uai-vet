using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vet.Services;

namespace Vet.Domain
{
    public partial class Appointment : IEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Hour { get; set; }
        public Doctor Doctor { get; set; }
        public int DoctorId { get; set; }
        public Patient Patient { get; set; }
        public int PatientId { get; set; }
        public Room Room { get; set; }
        public int RoomId { get; set; }
    }

    [MetadataType(typeof(AppointmentMetadata))]
    public partial class Appointment
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
