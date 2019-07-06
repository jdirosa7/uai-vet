using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vet.Domain;
using Vet.Services;

namespace ClientPatientManagement.Core.Data
{
    public class DoctorRepository : IRepository<DoctorModel>
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

        public DoctorModel GetById(int id)
        {
            var db = new VetDbContext();
            var doctor = db.Doctors.Find(id);
            return doctor;
        }

        public void Insert(DoctorModel entity)
        {
            var db = new VetDbContext();
            db.Doctors.Add(entity);
            db.SaveChanges();
        }

        public IEnumerable<DoctorModel> List()
        {
            var db = new VetDbContext();
            IList<DoctorModel> doctors = db.Doctors.ToList();
            return doctors;
        }

        public void Update(DoctorModel entity)
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