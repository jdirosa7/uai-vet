using ClientPatientManagement.Core.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Vet.Domain;
using Vet.Services;

namespace WebApp.Data
{
    public class PatientRepository : IRepository<Patient>
    {
        public static PatientRepository Instancia = new PatientRepository();

        public void Delete(int id)
        {
            var db = new VetDbContext();
            var patient = db.Patients.Include(a => a.Owner).Where(x => x.Id == id).Single();
            db.Patients.Remove(patient);
            db.SaveChanges();
        }

        public IEnumerable<Patient> GetByFilters(Patient entity)
        {
            var db = new VetDbContext();
            var patients = db.Patients.Include(a => a.Owner).
                Where(x => x.ClientId == entity.ClientId && x.Name == entity.Name).ToList();
            return patients;
        }

        public Patient GetById(int id)
        {
            var db = new VetDbContext();
            var patient = db.Patients.Include(a => a.Owner).Where(x => x.Id == id).Single();
            return patient;
        }

        public Patient Insert(Patient entity)
        {
            var db = new VetDbContext();
            db.Patients.Add(entity);
            db.SaveChanges();
            return entity;
        }

        public IEnumerable<Patient> List()
        {
            var db = new VetDbContext();
            IList<Patient> patients = db.Patients.Include(a => a.Owner).ToList();
            return patients;
        }

        public void Update(Patient entity)
        {
            var db = new VetDbContext();
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}