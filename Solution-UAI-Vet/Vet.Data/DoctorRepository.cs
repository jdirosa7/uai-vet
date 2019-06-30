using ClientPatientManagement.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
                doctor.Name = entity.Name;
                doctor.LastName = entity.LastName;
                doctor.Phone = entity.Phone;
                doctor.Email = entity.Email;

                db.SaveChanges();
            }
        }
    }
}