using ClientPatientManagement.Core.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClientPatientManagement.Core.Model
{
    public partial class Doctor : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }

    [MetadataType(typeof(RoomMetadata))]
    public partial class Doctor
    {
        public class RoomMetadata
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
            public string Phone { get; set; }

            [StringLength(50)]
            [Required]
            public string Email { get; set; }
        }
    }

    public class DoctorModel
    {
        public IEnumerable<Doctor> ObtenerDoctores()
        {
            return DoctorRepository.Instancia.List();
        }

        public void AgregarDoctor(Doctor doctor)
        {
            DoctorRepository.Instancia.Insert(doctor);
        }

        public Doctor ObtenerDoctorById(int id)
        {
            return DoctorRepository.Instancia.GetById(id);
        }

        public void ActualizarDoctor(Doctor doctor)
        {
            DoctorRepository.Instancia.Update(doctor);
        }

        public void EliminarDoctor(int id)
        {
            DoctorRepository.Instancia.Delete(id);
        }
    }
}