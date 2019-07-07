using System;
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

        private DoctorRepository()
        {
            //Instancia = new RepositoryRoom();
        }

        public void Delete(int id)
        {
            var db = new VetDbContext();
            var doctor = db.Doctors.Find(id);
            db.Doctors.Remove(doctor);
            db.SaveChanges();
        }

        public Doctor GetById(int id)
        {
            var db = new VetDbContext();
            var doctor = db.Doctors.Find(id);
            return doctor;
        }

        public void Insert(Doctor entity)
        {
            var db = new VetDbContext();
            db.Doctors.Add(entity);
            db.SaveChanges();
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
            var doctor = db.Doctors.Find(entity.Id);

            if (doctor != null)
            {
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}