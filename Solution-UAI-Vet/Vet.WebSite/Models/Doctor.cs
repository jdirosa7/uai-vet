﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vet.Domain;
using Vet.Services;

namespace ClientPatientManagement.Core.Model
{
    public partial class Doctor : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public static Doctor ToModel(DoctorModel entity)
        {
            return new Doctor
            {
                Id = entity.Id,
                Name = entity.Name,
                LastName = entity.LastName,
                Phone = entity.Phone,
                Email = entity.Email
            };
        }

        public static IEnumerable<Doctor> ToModelList(IEnumerable<DoctorModel> entities)
        {
            IList<Doctor> doctors = new List<Doctor>();
            entities.ToList().ForEach(entity => doctors.Add(ToModel(entity)));

            return doctors;
        }

        public static DoctorModel FromModel(Doctor model)
        {
            return new DoctorModel
            {
                Id = model.Id,
                Name = model.Name,
                LastName = model.LastName,
                Phone = model.Phone,
                Email = model.Email
            };
        }
    }
}