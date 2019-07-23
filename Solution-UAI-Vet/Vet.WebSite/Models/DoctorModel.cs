using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vet.Domain;
using Vet.Services;

namespace ClientPatientManagement.Core.Model
{
    public partial class DoctorModel : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int DNI { get; set; }
        public string Enrollment { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public static DoctorModel ToModel(Vet.Domain.Doctor entity)
        {
            return new DoctorModel
            {
                Id = entity.Id,
                Name = entity.Name,
                LastName = entity.LastName,
                DNI = entity.DNI,
                Enrollment = entity.Enrollment,
                Phone = entity.Phone,
                Email = entity.Email
            };
        }

        public static IEnumerable<DoctorModel> ToModelList(IEnumerable<Vet.Domain.Doctor> entities)
        {
            IList<DoctorModel> doctors = new List<DoctorModel>();
            entities.ToList().ForEach(entity => doctors.Add(ToModel(entity)));

            return doctors;
        }

        public static Doctor FromModel(DoctorModel model)
        {
            return new Vet.Domain.Doctor
            {
                Id = model.Id,
                Name = model.Name,
                LastName = model.LastName,
                DNI = model.DNI,
                Enrollment = model.Enrollment,
                Phone = model.Phone,
                Email = model.Email
            };
        }
    }
}