using ClientPatientManagement.Core.Data;
using ClientPatientManagement.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Data
{
    public class PatientRepository
    {
        public static PatientRepository Instancia = new PatientRepository();

        public void Delete(int id)
        {
            var db = new VetDbContext();
            var patient = db.Patients.Find(id);
            db.Patients.Remove(patient);
            db.SaveChanges();
        }

        public Patient GetById(int id)
        {
            var db = new VetDbContext();
            var patient = db.Patients.Find(id);
            return patient;
        }

        public void Insert(Patient entity)
        {
            var db = new VetDbContext();
            db.Patients.Add(entity);
            db.SaveChanges();
        }

        public IEnumerable<Patient> List()
        {
            var db = new VetDbContext();
            IList<Patient> patients = db.Patients.ToList();
            return patients;
        }

        public void Update(Patient entity)
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