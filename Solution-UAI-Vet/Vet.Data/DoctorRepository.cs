﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Vet.Domain;
using Vet.Services;

namespace ClientPatientManagement.Core.Data
{
    public class DoctorRepository : IRepository<Doctor>
    {
        public static DoctorRepository Instancia = new DoctorRepository();

        public void Delete(int id)
        {
            var db = new VetDbContext();
            var doctor = db.Doctors.Find(id);
            db.Doctors.Remove(doctor);
            db.SaveChanges();
        }

        public IEnumerable<Doctor> GetByFilters(Doctor entity)
        {
            var db = new VetDbContext();
            var doctors = db.Doctors.Where(x => x.DNI == entity.DNI && x.Enrollment == entity.Enrollment).ToList();
            return doctors;
        }

        public Doctor GetById(int id)
        {
            var db = new VetDbContext();
            var doctor = db.Doctors.Find(id);
            return doctor;
        }

        public Doctor Insert(Doctor entity)
        {
            var db = new VetDbContext();
            db.Doctors.Add(entity);
            db.SaveChanges();
            return entity;
        }

        public IEnumerable<Doctor> List()
        {
            var db = new VetDbContext();
            IList<Doctor> doctors = db.Doctors.ToList();
            return doctors;
        }

        public void Update(Doctor entity)
        {
            var db = new VetDbContext();
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}