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
    public class AppointmentRepository : IRepository<Appointment>
    {
        public static AppointmentRepository Instancia = new AppointmentRepository();

        public void Delete(int id)
        {
            var db = new VetDbContext();
            var appointment = db.Appointments.Include(a => a.Doctor).Include(a => a.Patient).Include(a => a.Patient.Owner).Include(a => a.Room).Where(x => x.Id == id).Single();
            db.Appointments.Remove(appointment);
            db.SaveChanges();
        }

        public Appointment GetById(int id)
        {
            var db = new VetDbContext();
            var appointment = db.Appointments.Include(a => a.Doctor).Include(a => a.Patient).Include(a => a.Patient.Owner).Include(a => a.Room).Where(x => x.Id == id).Single();
            return appointment;
        }

        public void Insert(Appointment entity)
        {
            var db = new VetDbContext();
            db.Appointments.Add(entity);
            db.SaveChanges();
        }

        public IEnumerable<Appointment> List()
        {
            var db = new VetDbContext();
            IList<Appointment> appointments = db.Appointments.Include(a => a.Doctor).Include(a => a.Patient).Include(a => a.Patient.Owner).Include(a => a.Room).ToList();
            return appointments;
        }

        public void Update(Appointment entity)
        {
            var db = new VetDbContext();
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}