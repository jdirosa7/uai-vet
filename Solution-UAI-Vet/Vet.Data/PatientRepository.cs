using ClientPatientManagement.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vet.Domain;
using Vet.Services;

namespace WebApp.Data
{
    public class PatientRepository : IRepository<PatientModel>
    {
        public static PatientRepository Instancia = new PatientRepository();

        public void Delete(int id)
        {
            var db = new VetDbContext();
            var patient = db.Patients.Find(id);
            db.Patients.Remove(patient);
            db.SaveChanges();
        }

        public PatientModel GetById(int id)
        {
            var db = new VetDbContext();
            var patient = db.Patients.Find(id);
            return patient;
        }

        public void Insert(PatientModel entity)
        {
            var db = new VetDbContext();
            db.Patients.Add(entity);
            db.SaveChanges();
        }

        public IEnumerable<PatientModel> List()
        {
            var db = new VetDbContext();
            IList<PatientModel> patients = db.Patients.ToList();
            return patients;
        }

        public void Update(PatientModel entity)
        {
            var db = new VetDbContext();
            var patient = db.Patients.Find(entity.Id);

            if (patient != null)
            {
                patient.Name = entity.Name;
                patient.Gender = entity.Gender;
                //patient.Owner = entity.Owner;
                patient.ClientId = entity.ClientId;

                db.SaveChanges();
            }
        }
    }
}